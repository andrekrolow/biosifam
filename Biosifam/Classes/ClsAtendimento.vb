Public Class ClsAtendimento

    Public IdAtendimento As Integer
    Public IdAtendimentoPendente As Integer
    Public IdResponsavelFinanceiro As Integer
    Public IdAutorizacaoFisioterapia As Integer
    Public IdAutorizacaoRemota As Integer
    Public IntTipoDigitacao As Integer   '1-biosifa,2-offline,3-remoto,4-rpj,5-bni,6-sms

    Public BolGravidaAutorizada As Boolean
    Public vsDataConsulta As String

    Public BolValidacaoPorSenha As Boolean
    Public BolTipoLaboratorial As Integer ' 1-normal (50/50), 2-interno (100/cobertura), 3-PA (100/100)

    Public IntServico(100) As Integer
    Public DecValor(100) As Decimal

    Public ValorServicoPrincipal As Decimal
    Public ValorServicoPrincipalPrestador As Decimal
    Public ValorServicoPrincipalContribuinte As Decimal

    Public vnContaServicos As Integer = 0
    Public vnTotalServicos As Decimal = 0

    Public StrTipoConsulta As String    ' N-Normal, E-Excedente, B-Bonus  (usa variaveis diferente na tabela Campo Situacao e Excedente
    Public UsouExcedenteNaData As Boolean = False

    Dim Email As ClsMail
    Dim drGeneric As Npgsql.NpgsqlDataReader
    Dim dsGeneric As DataSet
    Dim StrJustificativa As String
    Dim _Servico As New ClsServico

    Public Function Inicializar() As Boolean
        IdAtendimento = 0
        IdAtendimentoPendente = 0
        IdResponsavelFinanceiro = 0
        IdAutorizacaoFisioterapia = 0
        IdAutorizacaoRemota = 0
        IntTipoDigitacao = 0

        For i = 0 To 99
            IntServico(i) = 0
            DecValor(i) = 0
        Next i

        vnContaServicos = 0
        vnTotalServicos = 0

        StrJustificativa = ""
        Inicializar = True
        UsouExcedenteNaData = False
        _Servico = Nothing

    End Function

    Public Function TotalizaServico(IndiceDoServico As Integer, IdServico As Long, Valor As Decimal, Optional Exclusao As Boolean = False) As Decimal
        TotalizaServico = 0
        If IdServico = 0 Then Exit Function
        If DecValor(IndiceDoServico) > 0 Then
            ' alteracao de item e valor
            vnTotalServicos -= DecValor(IndiceDoServico)
            vnContaServicos -= 1
        End If
        If Exclusao Then
            ' exclusao só apaga valor velho
            IdServico = 0
            IntServico(IndiceDoServico) = 0
            Valor = 0
            DecValor(IndiceDoServico) = 0
        Else
            ' alteracao de valor, apaga valor velho, soma valor novo
            IntServico(IndiceDoServico) = IdServico
            DecValor(IndiceDoServico) = Valor
            vnTotalServicos += Valor
            vnContaServicos += 1
        End If

Finaliza:
        TotalizaServico = FormatNumber(vnTotalServicos, 2, , TriState.True)
    End Function

    Public Function GravarAtendimento(_Pessoa As ClsPessoa, _Prestador As ClsMedico, ByVal IdServicoPrincipal As Integer, ByVal PvTipoConsulta As String, ByVal vsCategoria As String) As Long

        Dim vsExcedente As String
        Dim vsSituacaoAtendimento As String = "A"
        Dim _Servico As New ClsServico

        If PvTipoConsulta = "B" Then vsSituacaoAtendimento = "B" ' BONUS
        If PvTipoConsulta = "E" Then vsExcedente = "S" Else vsExcedente = "N" ' Excedente

        GravarAtendimento = 0

        ' 0-Retaguarda,             tarefas de manutenção em consultas e digitais
        ' 1-Consulta cadastro,      somente consultas mediante digital ou senha
        ' 2-Consultório Médico,     registros de atendimento 
        '                           se dentista usa             - FACULTATIVO GRAVAR PROCEdimENTO
        '                           se anestesista              - OBRIGATORIO GRAVAR PROCEdimENTO
        '                           se faz exames em consultorio- FACULTATIVO GRAVAR PROCEdimENTO
        ' 3-Exames,                 registros de exames         - OBRIGATORIO GRAVAR PROCEdimENTO
        ' 4-Fisioterapia,           registros de atendimento e SESSOES + fisioterapia_sessoes
        ' 5-Pronto Atendimento      registros de atendimento    - OBRIGATORIO GRAVAR PROCEdimENTO

        If _PG.Conectar() = False Then Exit Function

        Dim vsTipoServico As String = _Prestador.TipoServico
        If _Prestador.Categoria = "M" And _Prestador.FazExameNoConsultorio And IdServicoPrincipal <> 1 Then vsTipoServico = "PM"

        If IdServicoPrincipal = 0 Then
            ' usa mais de 1, nao usa principal
            If _Prestador.Modo = 4 Or _Prestador.Modo = 5 Then
                If IdAtendimento > 0 And IntServico(1) = 0 Then
                    If MsgBox("Você deseja encerrar o Atendimento sem informar mais nenhuma despesa ?", vbYesNo, IIf(_Prestador.Modo = 4, "Pronto Atendimento", "Atendimento Hospitalar")) = vbNo Then GoTo Fim_Bloco
                End If
            End If
        End If

Gravacao:

        ' tabela identifica a tabela de serviços e procedimentos que é usada, 
        '       EX - antiga tabela de exames (EXAME) que deverá ser suprimida e utilizada em conjunto com a tabela de servico atraves deste identificador, 
        '       mais adiante este tipo deverá ser extinto e utilizado o tipo CB, que é a tabela Brasileira de códigos que será unica.

        '       PH - antiga tabela de procedimentos hospitalares (PROCEdimENTOS) que deverá ser suprimida e utilizada em conjunto com a tabela de servico atraves deste identificador, 
        '       mais adiante este tipo deverá ser extinto e utilizado o tipo CB, que é a tabela Brasileira de códigos que será unica.

        '       PA - antiga tabela de procedimentos ambulatoriais (PROCEdimENTO_AMB) que deverá ser suprimida e utilizada em conjunto com a tabela de servico atraves deste identificador, 
        '       mais adiante este tipo deverá ser extinto e utilizado o tipo CB, que é a tabela Brasileira de códigos que será unica.

        '       CB - nova tabela CBHPM - Codigo Brasileiro Hospitalar de Procedimentos Médicos. Este tipo deverá ser o único para todos.

        ' tabela_usuarios identifica os profissioanis que poderão utilizar determinada tabela.
        '       A-ambulatorios 
        '       H-hospitais 
        '       M-medicos
        '       N-anestesistas 
        '       O-odontologico 
        '       C-clinicas e laboratorios 
        '       este tipo podera conter a informação de mais de um tipo de uso (até 2) combinando as letras.

        ' esta nova implementação vai desconsiderar os tipos ex, ph, pa buscando o objetivo de usar apenas a tabela cb

        ' o campo tipo servico da tabela atendimento identifica a origem do atendimento.
        '    CM-Consulta Médicas
        '    CO-Consulta Odontológica
        '    CF-Consulta Fisioterapia
        '    AN-Procedimentos de Anestesistas
        '    PA-Pronto atendimento
        '    xx-Procedimentos em Ambulatórios-<---------- ainda nao está implementado - NAO SERA MAIS USADO - incluido no HOSPITALAR
        '    PH-Procedimentos em Hospitais-<---------- 09/2022 implementação
        '    PM-Procedimentos em Consultórios Médicos
        '    PC-Procedimentos em Clínicas e Laboratórios
        ' quem faz exames são Anestesistas, Clínicas e Médicos

        ' ja vem somado do form
        'vnTotalServicos = vnValor + vnValor2 + vnValor3 + vnValor4 + vnValor5 + vnValor6 + vnValor7 + vnValor8 + vnValor9 + vnValor10

        ' procedimento em ambulatorios e em hospitais são controlados pela Sandra e são informado diretamente no SIFAM - opah agora vai ser aqui!!!! 09/2022
        If (_Prestador.Modo = 4 Or _Prestador.Modo = 5) And (IntTipoDigitacao <> 4 And IntTipoDigitacao <> 5) Then
            ' 4 e 5 rpj e os novos offline - se for offline nao deve ficar pendente
            ' pronto atendimento em pronto socorros - situacao fica pendente até fechamento do atendimento
            If IdAtendimentoPendente = 0 Then
                ' deixa pendente na primeira gravacao, vai gravar tipo de consulta no servico1
                vsSituacaoAtendimento = "P"
                ' se for só despesas, nao deve ficar pendentes
                If IntServico(0) = 0 And IntServico(1) > 0 Then vsSituacaoAtendimento = "A"
            Else
                ' deixa ativo no fechamento do atendimento e grava segundo procedimento
                ' atualiza primeiro pois pode ter sio alterado
                _PG.Execute("begin") ' =============================================================================================================================================
                ' apagas os servicos para poder alterar o primeiro - pode troca urgente por nao urgente
                _PG.Execute("delete from atendimento_servico where id_atendimento=" & IdAtendimentoPendente)
                If IntServico(0) > 0 Then
                    _Servico.Carregar(IntServico(0), _Prestador, DecValor(0))
                    _PG.Execute("INSERT INTO atendimento_servico (id_atendimento, id_servico, valor, valor_prestador, valor_contribuinte) values (" & IdAtendimentoPendente & ",'" & IntServico(0) & "', " & Replace(DecValor(0), ",", ".") & "," & Replace(_Servico.ValorPrestador, ",", ".") & "," & Replace(_Servico.ValorContribuinte, ",", ".") & ");")
                    ' _PG.execute("UPDATE atendimento set situacao='A', valor=(select sum(valor) from atendimento_servico where id_atendimento=" & idAtendimento & ") where id_atendimento=" & idAtendimento)
                End If
                If IntServico(1) > 0 And DecValor(1) > 0 Then
                    _Servico.Carregar(IntServico(1), _Prestador, DecValor(1))
                    _PG.Execute("INSERT INTO atendimento_servico (id_atendimento, id_servico, valor, valor_prestador, valor_contribuinte) values (" & IdAtendimentoPendente & ",'" & IntServico(1) & "', " & Replace(DecValor(1), ",", ".") & "," & Replace(_Servico.ValorPrestador, ",", ".") & "," & Replace(_Servico.ValorContribuinte, ",", ".") & ");")
                End If
                '_PG.Execute("UPDATE atendimento_servico set valor='" & Replace(vnValor, ",", ".") & "', valor_Prestador='" & Replace(vnValorPrestador, ",", ".") & "', valor_contribuinte='" & Replace(vnValorContribuinte, ",", ".") & "' where id_atendimento=" & IdAtendimentoPendente & " and id_servico=" & idServico1)
                _PG.Execute("UPDATE atendimento set situacao='A', valor='" & Replace(vnTotalServicos, ",", ".") & "' where id_atendimento=" & IdAtendimentoPendente)
                _PG.Execute("commit") '=============================================================================================================================================
                IdAtendimento = IdAtendimentoPendente
                GoTo Impressão
            End If
        End If


        ' procedimento medicos não fazem parte do processo de bonus/excedentes 
        ' quando tem examea a consulta usa bonus/excedente, mas o procdimento nao deve conter registros de bonus/excedente - são sempre Ids diferentes CM e PM
        If vsTipoServico = "PM" Then vsSituacaoAtendimento = "A" : vsExcedente = "N"

        _PG.Execute("begin") ' =============================================================================================================================================
        '" & Replace(vnValor, ",", ".") & "'

        Dim DecTotalServicos As Decimal = ValorServicoPrincipal
        If IdServicoPrincipal = 0 Then DecTotalServicos = vnTotalServicos - ValorServicoPrincipal


        If _PG.Execute("INSERT INTO atendimento (id_pessoa, id_medico, id_juridica, tipo_servico, situacao, valor, data_pagamento, excedente, biosifam, login, ip, dt_alteracao, hr_alteracao, autorizacao) " &
        " VALUES ( " & _Pessoa.Id & ", " & _Prestador.Id & ", " & IdResponsavelFinanceiro & ", '" & vsTipoServico & "','" & vsSituacaoAtendimento & "', " & Replace(DecTotalServicos, ",", ".") & ", null, '" & vsExcedente & "', '" & IntTipoDigitacao & "','" & frmLogin.TxtUsuario.Text & "', '" & _t.ObtemEnderecoIP &
        "', " & vsDataConsulta & ", substring(cast (current_time as TEXT),1,5)," & IdAutorizacaoFisioterapia & ") RETURNING id_atendimento;") = False Then
            GoTo Fim_Bloco
        End If
        'drMax = _PG.drQuery("select max(id_atendimento) from atendimento")

        Dim drMax As Npgsql.NpgsqlDataReader
        drMax = _PG.DrQuery("select lastval()")
        If drMax.HasRows Then
            drMax.Read()
            IdAtendimento = drMax.Item(0)

            Dim StrSqlInsereItens As String = ""
            If IdServicoPrincipal > 0 Then
                StrSqlInsereItens &= "INSERT INTO atendimento_servico (id_atendimento, id_servico, valor, valor_prestador, valor_contribuinte) values (" &
                IdAtendimento & ",'" & IdServicoPrincipal & "', " & Replace(ValorServicoPrincipal, ",", ".") & "," & Replace(ValorServicoPrincipalPrestador, ",", ".") & "," & Replace(ValorServicoPrincipalContribuinte, ",", ".") & ");"
                _PG.Execute(StrSqlInsereItens)
            Else
                For i = 0 To 99
                    If IntServico(i) > 0 Then

                        ' 2 -pronto atendimento
                        If _Prestador.Categoria = "M" And _Prestador.IdServicoPrincipal = IntServico(i) Then i += 1 ' pula primeiro itens - consulta medica
                        If IntServico(i) = 0 Then GoTo Proximo
                        If _Prestador.Categoria = "2" And IdAtendimentoPendente > 0 And i = 0 Then i += 1 ' pula primeiro itens GoTo SomenteProcedimento2

                        ' rotina atualiza valor DecValorPrestador, DecValorContribuinte
                        _Servico.Carregar(IntServico(i), _Prestador, DecValor(i))
                        StrSqlInsereItens &= "INSERT INTO atendimento_servico (id_atendimento, id_servico, valor, valor_prestador, valor_contribuinte) values (" &
                           IdAtendimento & ",'" & IntServico(i) & "', " & Replace(DecValor(i), ",", ".") & "," & Replace(_Servico.ValorPrestador, ",", ".") & "," & Replace(_Servico.ValorContribuinte, ",", ".") & ");"
                    End If
Proximo:
                Next i
                _PG.Execute(StrSqlInsereItens)
            End If

            ' existem 2 tipo basicos de autorizacoes DE PROCEDIMENTOS (fisioterapias..)
            ' e                         autorizacoes BNI - desvio de biometria - BNI - sms, qrcode, remoto
            If _Prestador.Fisioterapeuta And IdAutorizacaoFisioterapia > 0 Then
                ' atualiza contador sessoes
                _PG.Execute("UPDATE atendimento_autorizacao set sessoes_realizadas=sessoes_realizadas+1 where id_atendimento_autorizacao=" & IdAutorizacaoFisioterapia)
                _PG.Execute("UPDATE atendimento_autorizacao set situacao='F' where id_atendimento_autorizacao=" & IdAutorizacaoFisioterapia & " and sessoes_autorizadas<=sessoes_realizadas")
            End If

            If IdAutorizacaoRemota > 0 Then
                ' a autorizacao de SMS e Qrdcode vou usa o idAutorizacaoRemota (orignal para TeleConsulta e Autorizacao Balcao")
                _PG.Execute("UPDATE atendimento_autorizacao set situacao='F', id_atendimento=" & IdAtendimento & " where id_atendimento_autorizacao=" & IdAutorizacaoRemota)
            End If

            If IntTipoDigitacao = 4 Then
                ' salvar justificativa - rpj
                If _PG.Execute("INSERT INTO atendimento_justificativa (id_atendimento, justificativa, ip, dt_alteracao, login) values (" &
                      IdAtendimento & ",'" & StrJustificativa & "', '" & _t.ObtemEnderecoIP & "', current_timestamp ,'" & frmLogin.TxtUsuario.Text & "')") = False Then
                    _toolsSiFam.WriteLog("Erro na inserção da justificativa do atendimento " & IdAtendimento & "-" & StrJustificativa)
                End If
            End If

            If BolGravidaAutorizada Then
                'vai permitir identifica se a consulta foi liberada ou nao pelo operador
                _PG.Execute("INSERT INTO consulta_gravida (id_consulta) VALUES ( " & IdAtendimento & ");")
            End If

        End If
        _PG.Execute("commit") '=============================================================================================================================================


        If BolValidacaoPorSenha Then
            _util.Log_Gravar("biosifam_ValidacaoSenha", "Consulta registrada por Senha", False, IdAtendimento, _Prestador.Id)
        Else
            ' 3=remota
            If IntTipoDigitacao = 2 Then
                _util.Log_Gravar("biosifam_erro7", "Consulta registrada off-line", False, _Pessoa.Id, _Prestador.Id)
            ElseIf IntTipoDigitacao = 3 Then
                _util.Log_Gravar("biosifam_remota", "Consulta registrada com Autorizacao Remota", False, _Pessoa.Id, _Prestador.Id)
            ElseIf IntTipoDigitacao = 4 Then
                _util.Log_Gravar("biosifam_rpj", "Consulta registrada com RPJ ", False, _Pessoa.Id, _Prestador.Id)
            ElseIf IntTipoDigitacao = 5 Then
                _util.Log_Gravar("biosifam_bni", "Consulta registrada BNI", False, _Pessoa.Id, _Prestador.Id)
            ElseIf IntTipoDigitacao = 6 Then
                _util.Log_Gravar("biosifam_sms", "Consulta registrada com SMS", False, _Pessoa.Id, _Prestador.Id)
            Else
                _util.Log_Gravar("biosifam_ValidacaoBiometrica", "Consulta registrada por Biometria", False, IdAtendimento, _Prestador.Id)
            End If
        End If


Impressão:
        ' IMPRESSAO
        GravarAtendimento = IdAtendimento

        ' idUltimoAtendimento = idAtendimento
        If IntServico(0) = 1 Or IntServico(1) = 3348 Then Exit Function ' consultas  nao imprimem recido de procedimento

        ' disparar email ao paciente.
        If _Pessoa.EmailTitular <> "" Or _Pessoa.Email <> "" Then
            'vsEmailPaciente = "andrekrolow@gmail.com"
            Email = New ClsMail("Prevpel - Biosifam")
            Email.vsAssunto = "Registro de atendimento PREVPEL"
            Email.vsMensagem = "Comunicamos o registro do atendimento N. " & IdAtendimento & " em " & oMedicoConveniado.Nome & " as "
            Email.vsMensagem &= Format(Date.Now, "hh:mm") & " de " & Format(Date.Today, "dd/MM/yyyy") & " na matricula " & _Pessoa.Matricula & ", paciente " & _Pessoa.Nome & "."
            Email.vsMensagem &= Chr(13) & " PREVPEL/Biosifam"
            Email.vbAutomatico = True
            Email.vbAutenticacaoSegura = True
            If _Pessoa.EmailTitular <> "" Then
                Email.vsEmail = _Pessoa.EmailTitular
                Email.Enviar()
            End If
            If _Pessoa.Email <> "" Then
                Email.vsEmail = _Pessoa.Email
                Email.Enviar()
            End If
        End If
Fim_Bloco:
        _PG.Desconectar()

    End Function

    Public Function CancelarAtendimento(PsLogin As String, IdCorrecao As Integer) As Boolean
        CancelarAtendimento = False

        ' cancelamento sera permitido aos proprios conveniados, quando no mesmo dia.
        Dim IdAtendimento As Integer
        If IdCorrecao > 0 Then
            IdAtendimento = IdCorrecao
        Else
            IdAtendimento = Val(InputBox("Informe o número do atendimento à cancelar !", "Cancelamento de Atendimento"))
            If IdAtendimento = 0 Then Exit Function
        End If

        Dim vdDataServidor As Date = _PG.DataServidor
        Dim ds As DataSet
        ds = _PG.DsQuery("SELECT id_atendimento, to_ascii(prestador.nome,'LATIN1') as nome_prestador,  to_ascii(p.nome,'LATIN1') as nome_pessoa, a.dt_alteracao, a.situacao, prestador.id_prestador, autorizacao, p.id_pessoa, current_date as hoje FROM atendimento as a, prestador, pessoas p where a.id_medico=prestador.id_prestador and a.id_pessoa=p.id_pessoa and id_atendimento=" & IdAtendimento)

        If ds Is Nothing Then MsgBox("O atendimento não foi localizado.") : GoTo Fim
        If ds.Tables(0).Rows.Count = 0 Then MsgBox("O atendimento não foi localizado.") : GoTo Fim
        If ds.Tables(0).Rows(0).Item(4).ToString() = "C" Then MsgBox("O atendimento N. " & IdAtendimento & " já está cancelado.") : GoTo Fim
        If ds.Tables(0).Rows(0).Item(5).ToString() <> oMedicoConveniado.Id Then MsgBox("O atendimento N. " & IdAtendimento & " foi realizado por outro profissional e você não tem permissão para cancelá-lo.") : GoTo Fim

        If oMedicoConveniado.VerificaRestricoesOffLine(CDate(ds.Tables(0).Rows(0).Item(3)), ds.Tables(0).Rows(0).Item(4)) = False Then Exit Function

        If MsgBox("Atendimento foi realizado por " & ds.Tables(0).Rows(0).Item(1).ToString() & " para " & ds.Tables(0).Rows(0).Item(2).ToString() & Chr(13) & Chr(13) & "Prosseguir com o cancelamento do atendimento?", vbYesNo) = vbNo Then GoTo Fim

        StrJustificativa = InputBox("Informe uma justificativa para o cancelamento do registro")

        If Trim(StrJustificativa) = "" Then MsgBox("Obrigatório informar uma justificativa") : GoTo Fim
        If StrJustificativa.ToString.Length < 10 Then MsgBox("A Justificativa precisa ter no mínimo 10 caracteres.") : GoTo Fim
        If StrJustificativa.ToString.Length > 100 Then MsgBox("Informe no máximo 100 caracteres.") : GoTo Fim

        If _PG.Conectar = False Then Exit Function
        _PG.Execute("begin")
        _PG.Execute("update atendimento set situacao='C' where id_atendimento=" & IdAtendimento)
        _PG.Execute("INSERT INTO historico (Tabela, operacao, valor, observacao, usuario, data, hora, ip) values " &
                     " ('atendimento','c', '" & IdAtendimento & "', '','" & frmLogin.TxtUsuario.Text & "', current_date, current_time,'" & _t.ObtemEnderecoIP & "');")
        If ds.Tables(0).Rows(0).Item(6).ToString() > 0 Then
            _PG.Execute("update atendimento_autorizacao set sessoes_realizadas=sessoes_realizadas-1 where id_atendimento_autorizacao=" & ds.Tables(0).Rows(0).Item(6).ToString())
        End If

        drGeneric = _PG.DrQuery("SELECT id_atendimento FROM atendimento_justificativa WHERE id_atendimento=" & IdAtendimento)
        If drGeneric.HasRows Then
            _PG.Execute("update atendimento_justificativa set justificativa='" & StrJustificativa & "', ip='" & _t.ObtemEnderecoIP & "', dt_alteracao=current_timestamp, login='" & PsLogin & "' where id_atendimento=" & IdAtendimento)
        Else
            _PG.Execute("INSERT INTO atendimento_justificativa (id_atendimento, justificativa, ip, dt_alteracao, login) values (" &
                        IdAtendimento & ",'" & StrJustificativa & "', '" & _t.ObtemEnderecoIP & "', current_timestamp ,'" & PsLogin & "')", False)
        End If
        _PG.Execute("commit")
        _PG.Desconectar()

        Dim _Pessoa As New ClsPessoa
        _Pessoa.CarregarPessoa(ds.Tables(0).Rows(0).Item(7).ToString())
        If _Pessoa.Email <> "" Then
            'vsEmailPaciente = "andrekrolow@gmail.com"
            Email = New ClsMail("Prevpel - Biosifam")
            Email.vsAssunto = "PREPVEL/Biosifam - Aviso de Cancelamento"
            Email.vsMensagem = "Comunicamos o cancelamento do atendimento N. " & IdAtendimento & " em " & oMedicoConveniado.Nome & " as "
            Email.vsMensagem &= Format(Date.Now, "hh:mm") & " de " & Format(Date.Today, "dd/MM/yyyy") & " na matricula " & _Pessoa.Matricula & ", paciente " & _Pessoa.Nome & "."
            Email.vsMensagem &= Chr(13) & " PREVPEL/Biosifam"
            Email.vbAutomatico = True
            Email.vbAutenticacaoSegura = True
            Email.vsEmail = _Pessoa.Email
            Email.Enviar()
            If _Pessoa.EmailTitular <> "" And _Pessoa.Email <> _Pessoa.EmailTitular Then
                Email.vsEmail = _Pessoa.EmailTitular
                Email.Enviar()
            End If
            If _u.Email <> "" Then
                Email.vsEmail = _u.Email
                Email.Enviar()
            End If
            'Email.vsEmail = "famatendimento.prevpel@pelotas.rs.gov.br"
            'Email.Enviar()

        End If

        MsgBox("Cancelamento realizado com sucesso!")
        CancelarAtendimento = True
        Exit Function
Fim:

    End Function

    Public Function DataServidor() As Date
        dsGeneric = _PG.DsQuery("select current_date ")
        If dsGeneric Is Nothing = False Then
            If dsGeneric.Tables(0).Rows.Count > 0 Then
                DataServidor = Format(dsGeneric.Tables(0).Rows(0).Item(0), "dd/MM/yyyy")
            End If
        End If
    End Function

    Public Function GravarNaoComparecido(_Pessoa As ClsPessoa, _Prestador As ClsMedico) As Boolean
        GravarNaoComparecido = False

        If _Prestador.Id = 0 Then MsgBox("Selecione um médico!", vbOKOnly, "Registro de Não Comparecimento") : Exit Function
        If _Pessoa.Id = 0 Then MsgBox("Selecione um paciente!", vbOKOnly, "Registro de Não Comparecimento") : Exit Function

        Dim vdDataServidor As Date = DataServidor()

        Dim StrData As String = vdDataServidor
        StrData = InputBox("Informe a data do não comparecimento (máximo 5 dias retroativos) ", "Registro de Não Comparecimento", StrData)
        If StrData = "" Then Exit Function
        If CDate(StrData) < CDate(vdDataServidor).AddDays(-5) Then MsgBox("A data informada não pode ser anterior a 5 dias da data atual. ") : Exit Function

        Dim _Autorizacao As New ClsAutorizacao

        If _Prestador.Fisioterapeuta Then
            If _Autorizacao.VerificaAutorizacao(_Pessoa.Id) = False Then Exit Function
        End If

        If MsgBox("Prosseguir com o registro do não comparecimento de " & _Pessoa.Nome & " para " & oMedicoConveniado.Nome & "?", vbYesNo, "Registro de Não Comparecimento") = vbNo Then Exit Function

        ' vou eliminar os servicos de nao comparecimento e usar a situacao='N' - tudo leva a creer´que é melhor + simples - versao 2.2.14 - 01/01/2022
        ' inicialmente vou iniciar utilizando a situacao ='N'
        ' em 22/02, versao 2.2.28, modificação anterior OK, o valor do ?NC é o valor da consulta respectiva, não é o valo do excedente.
        '           delete from servico where id_servico=17003

        Dim idServico As Long = 1    '  consulta médica 1
        If _Prestador.Dentista Then idServico = 3348 ' 16985    ' consulta dentista 3348
        If _Prestador.Fisioterapeuta Then idServico = 16981 '16986    ' fisoterapia 16981
        If _Prestador.Nutricionista Then idServico = 16999 ' consulta nutricionista 16999

        Dim TipoServico As String = "CM"
        If _Prestador.Dentista Then TipoServico = "CO"
        If _Prestador.Fisioterapeuta Then TipoServico = "CF"
        If _Prestador.Nutricionista Then TipoServico = "CN"

        ' so um por dia
        Dim vsSql As String = "select count(*) from atendimento where situacao='N' and tipo_servico='" & TipoServico & "' and id_pessoa=" & _Pessoa.Id & " and dt_alteracao='" & Format(CDate(StrData), "yyyy/MM/dd") & "' and id_medico=" & _Prestador.Id
        dsGeneric = _PG.DsQuery(vsSql)
        If dsGeneric Is Nothing = False Then
            If dsGeneric.Tables(0).Rows.Count > 0 Then
                If dsGeneric.Tables(0).Rows(0).Item(0) > 0 Then
                    MsgBox("Não comparecimento já registrado no dia de hoje! ", vbOKOnly, "Registro Não permitido")
                    Exit Function
                End If
            End If
        End If

        IntTipoDigitacao = 7    ' novo tipo NC - nao é OFFLINE ou RPJ

        If _PG.Conectar = False Then Exit Function

        Dim drServicos As Npgsql.NpgsqlDataReader, drMax As Npgsql.NpgsqlDataReader, vnPrecoServicoDefault As Decimal, idUltimoAtendimento As Integer
        drServicos = _PG.DrQuery("Select id_servico, valor, valor_excedente, cobertura, consignacao FROM servico where id_servico=" & idServico)
        If drServicos.HasRows Then
            drServicos.Read()
            vnPrecoServicoDefault = drServicos.Item(1)
        End If

        _PG.Execute("begin") '=============================================================================================================================================
        _PG.Execute("INSERT INTO atendimento (id_pessoa, id_medico, id_juridica, tipo_servico, situacao, valor, data_pagamento, excedente, Biosifam, login, ip, dt_alteracao, hr_alteracao, autorizacao) " &
            " VALUES ( " & _Pessoa.Id & ", " & oMedicoConveniado.Id & ", " & IdResponsavelFinanceiro & ", '" & TipoServico & "','N', '" & Replace(vnPrecoServicoDefault, ",", ".") & "', null, 'N', '" & IntTipoDigitacao & "','" & frmLogin.TxtUsuario.Text & "', '" & _t.ObtemEnderecoIP &
            "', '" & Format(CDate(StrData), "yyyy/MM/dd") & "', substring(cast (current_time as TEXT),1,5)," & _Autorizacao.IntAutorizacao & " ) RETURNING id_atendimento;")

        drMax = _PG.DrQuery("select lastval()")
        If drMax.HasRows Then
            drMax.Read()
            idUltimoAtendimento = drMax.Item(0)
            _PG.Execute("INSERT INTO atendimento_servico (id_atendimento, id_servico, valor, valor_prestador, valor_contribuinte) values (" & idUltimoAtendimento & ", " & idServico & ", " & Replace(vnPrecoServicoDefault, ",", ".") & "," & Replace(vnPrecoServicoDefault * drServicos.Item(3) / 100, ",", ".") & "," & Replace(vnPrecoServicoDefault, ",", ".") & ");")
        End If

        If _Autorizacao.IntAutorizacao > 0 Then
            _PG.Execute("update atendimento_autorizacao set sessoes_realizadas=sessoes_realizadas+1 where id_atendimento_autorizacao=" & _Autorizacao.IntAutorizacao)
        End If

        _PG.Execute("commit") '============================================================================================================================================
        _PG.Desconectar()

        ' disparar email ao paciente.
        Dim Email As ClsMail
        _Pessoa.CarregarPessoa(_Pessoa.Id)
        If _Pessoa.Email <> "" Then
            'vsEmailPaciente = "andrekrolow@gmail.com"
            Email = New ClsMail("Prevpel - Biosifam")
            Email.vsAssunto = "PREPVEL/Biosifam - Registro de Não Comparecimento"
            Email.vsMensagem = "Comunicamos o registro de NÃO COMPARECIMENTO N. " & _Autorizacao.IntAutorizacao & " em " & oMedicoConveniado.Nome & " as "
            Email.vsMensagem &= Format(Date.Now, "hh:mm") & " de " & Format(Date.Today, "dd/MM/yyyy") & " na matricula " & _Pessoa.Matricula & ", paciente " & _Pessoa.Nome & "."
            Email.vsMensagem &= Chr(13) & " PREVPEL/Biosifam"
            Email.vbAutomatico = True
            Email.vbAutenticacaoSegura = True
            Email.vsEmail = _Pessoa.Email
            Email.Enviar()
            If _Pessoa.EmailTitular <> "" And _Pessoa.Email <> _Pessoa.EmailTitular Then
                Email.vsEmail = _Pessoa.EmailTitular
                Email.Enviar()
            End If
            If _u.Email <> "" Then
                Email.vsEmail = _u.Email
                Email.Enviar()
            End If
            ' Email.vsEmail = "famatendimento.prevpel@pelotas.rs.gov.br"
            ' Email.Enviar()

        End If
        MsgBox("Registro criado com sucesso! N." & idUltimoAtendimento)
        GravarNaoComparecido = True


        Dim _SMS As New ClsSMS
        _SMS.idCliente = 1
        _SMS.vsRemetente = _e.Nome
        _SMS.vsProvedorSMS = "" ' default
        If _SMS.Inicializa() = False Then Exit Function
        _SMS.vsMensagem = _Prestador.Nome.Substring(0, 25) & " registrou NÃO COMPARECIMENTO. Valor será descontado."
        If _Pessoa.Telefone = "" Then
            If _Pessoa.EmailTitular = "" Then Exit Function
            _SMS.vsDestino = _Pessoa.EmailTitular
            _util.Log_Gravar("biosifam_email", "Disparou envio EMAIL", False, _Pessoa.Id, oMedicoConveniado.Id)
            Call _SMS.EnviarMensagem(99)
        Else
            _SMS.vsDestino = _Pessoa.Celular
            ' _SMS.vsDestino = "53981119138"
            _util.Log_Gravar("biosifam_sms_env", "Disparou envio SMS", False, _Pessoa.Id, oMedicoConveniado.Id)
            Call _SMS.EnviarMensagem(1)
        End If


fim:

    End Function

    Public Function ValidaLimiteConsultasOuAtivaBonusExcedente(_Pessoa As ClsPessoa, _Prestador As ClsMedico) As Boolean
        ValidaLimiteConsultasOuAtivaBonusExcedente = False

        If _Pessoa.IdadeFertil And (_Prestador.Especialidade = 13 Or _Prestador.Especialidade2 = 13) Then
            ' desvio especial para gestantes - se é mulher, se idade > 12 and < 50, e médico é Ginecologista =id=13
            ' mas só pode liberar no oitavo mês
            ' DESATIVADO POR ENQUANTO - versao 2.2.75 15/08/2022
            _Pessoa.PossivelGravida = True
        End If

        Dim IntConsultasRealizadas As Long = 0
        Dim IntLimiteDeAtendimentos As Integer = 0
        Dim vsSql As String = ""
        Dim StrDescricaoTipoConsulta As String = ""
        Dim BolConsultaMedica = False
        'MsgBox(_Pessoa.PossivelGravida)

        'https://www.pelotas.com.br/storage/servicos/prevpel/legislacaoFAM/Intru%C3%A7%C3%A3o%20Normativa%20Conjunta%20-%20FAM%201%C2%BA.%2004.%202021.pdf
        ' para usar bonus (5 dos 365 dias) - se for mesmo medico deve respeitar o intervalo de 30 dias. -> Art. 15. , do contrario usa como quiser
        ' excedentes libera sempre
        ' 15 dias - se for mesmo medico nao pode  ->  Art. 15. $1.

        '28/10/2021
        'mesma matricula.
        'med 2 mes intervalo 15d, bonus a q.q. momento.
        'nut 1 mes sem bonus, 
        'odo 2 mes  int 15d, bonus a q.q. momento.
        'bonus 1 cada 30 dias
        'excedente q.q.momento.

        If _Prestador.Nutricionista Then
            '  Nutrição nao usa regra do Limite de Dias, sempre 30 dias
            IntConsultasRealizadas = _Pessoa.ConsultasNutricionistaRealizadas  ' Nutrição
            IntLimiteDeAtendimentos = 1 ' Nutrição
            StrDescricaoTipoConsulta = "Nutricionistas"
            GoTo VerificaLimiteDefault

        ElseIf _Prestador.Fisioterapeuta Then
            ' fisoterapia nao usa Bonus, nâo usa Excedente - Usa Autorização 
            vsSql = "select count(*) from atendimento a where (a.situacao='A' or a.situacao='B') and  id_pessoa='" & _Pessoa.Id & "' and a.dt_alteracao=current_date and id_medico=" & _Prestador.Id & " and autorizacao=" & _Pessoa.AutorizacaoFisioterapia

            ' 2.2.25 liberar por pessoa apenas para as matriculas especificad, apos finalizacao eliminar teste e voltando a ficar travado por matricula
            ' 2.2.30 inverteu o teste mas é a mesma coisa
            If _Prestador.Fisioterapeuta _
            And (_Pessoa.Matricula <> "8100" And _Pessoa.Matricula <> "15264" And _Pessoa.Matricula <> "25359" And _Pessoa.Matricula <> "71011102" And _Pessoa.Matricula <> "20260") _
            Then   ' fisioterapia
                ' o fisioterapeuta é por pessoa
                vsSql = "select count(*) from atendimento a inner join pessoas using (id_pessoa) where (a.situacao='A' or a.situacao='B') and matricula='" & _Pessoa.Matricula & "' and a.dt_alteracao=current_date and id_medico=" & _Prestador.Id & " and autorizacao=" & _Pessoa.AutorizacaoFisioterapia
            End If

            dsGeneric = _PG.DsQuery(vsSql)
            If dsGeneric Is Nothing = False Then
                If dsGeneric.Tables(0).Rows.Count > 0 Then
                    If dsGeneric.Tables(0).Rows(0).Item(0) > 0 Then
                        MsgBox("O paciente já teve registro hoje para o CID informado (" & _Pessoa.AutorizacaoFisioterapia & ")!", vbInformation, "Impossível registrar novo atendimento!")
                        Exit Function
                    End If
                End If
            End If

            GoTo Fim_OK

        ElseIf _Prestador.Dentista Then
            IntConsultasRealizadas = _Pessoa.ConsultasOdontologicasRealizadas
            IntLimiteDeAtendimentos = _setup.limite_maximo_atendimentos_dentistas
            StrDescricaoTipoConsulta = "Odontológicas"

        Else
            IntConsultasRealizadas = _Pessoa.ConsultasMedicasRealizadas
            IntLimiteDeAtendimentos = _setup.limite_maximo_atendimentos_medicos
            StrDescricaoTipoConsulta = "Médicas"
            BolConsultaMedica = True
        End If

        ' se tem alguma consulta nos ultimos 30 dias, verificar se é com o mesmo medico ou nao. se for o mesmo medico verificar se foi em 15 dias 
        If IntConsultasRealizadas > 0 Then

            'versao 2.2.04
            ' se tem alguma consulta nos ultimos 30 d TEM QUE verificar se respeita o intervalo de 15 dias caso seja o mesmo medico
            Dim vsDataDaConsulta As String = vsDataConsulta
            ' 16 a partir 2.2.75 15/08/2022 - retorno ganha mais 1 dia, na realidade só pode registrar no Décimo Sexto dia. 
            ' 29-16=13 pode
            ' 28-15=13 nao pode
            If vsDataDaConsulta = "CURRENT_DATE" Then
                vsDataDaConsulta = " And a.dt_alteracao>=CURRENT_DATE-15"
            Else
                ' para data offline, dai deve testar para tras e para frente
                ' 24-15=9 dia 9 em diante que nao pode ter consultas
                ' ou 8+15=23, consulta pode iniciar dia 24
                vsDataDaConsulta = " And a.dt_alteracao>=Date" & vsDataDaConsulta & "-15 And a.dt_alteracao<=Date" & vsDataDaConsulta & "+15"
            End If

            ' não pode fazer duas consulta em menos de 15 dias - medico ou odontologico- com mesmo medico e mesma matricula
            ' id_requisitante=pessoa que fez a consulta, id_pessoa é o titular

            ' consultas com intervalo mínimo de 15d são para evitar o lançamento do retorno de consulta como nova consulta, 
            ' assim a validação deve ser pelo paciente e não pela matricula. (modificação é bioifam agora validar pelo paciente, vinha validando pela matricula).
            ' interpretacao em 22/02/2022 versao 2.2.28
            ' interpretacao 2.2.30 - dentista saem desta regra
            'dsGeneric = _PG.DsQuery("Select count(*) from atendimento a inner join pessoas Using (id_pessoa) where a.situacao='A' and matricula='" & _Pessoa.Matricula & "'" & vsDataDaConsulta & " and id_medico=" & _Prestador.Id)
            If _Prestador.SemAgendamentoPrevio Then
                ' ProntoCor - medicos podem trocar  no periodo de 15 dias
                ' versao 2.2.44
                dsGeneric = _PG.DsQuery("select count(*) from atendimento a where (a.situacao='A' or a.situacao='B' or a.excedente='S') and tipo_servico='" & _Prestador.TipoServico & "' and id_pessoa=" & _Pessoa.Id & vsDataDaConsulta & " and id_juridica=" & IdResponsavelFinanceiro)
            Else
                dsGeneric = _PG.DsQuery("select count(*) from atendimento a where (a.situacao='A' or a.situacao='B' or a.excedente='S') and tipo_servico='" & _Prestador.TipoServico & "' and id_pessoa=" & _Pessoa.Id & vsDataDaConsulta & " and id_medico=" & _Prestador.Id)
            End If
            If dsGeneric.Tables(0).Rows.Count > 0 Then
                If dsGeneric.Tables(0).Rows(0).Item(0) > 0 Then
                    ' se item é > 0, é que existe uma consulta nos ultimos 15dias e nao pode fazer, inclusive bonus ou excedente.
                    '   a pessoa tem direito a retorna sem pagar e o medido nao pode registrar no atednimento, tem que atender sem registrar
                    If _Pessoa.PossivelGravida Then
                        ' nao faz nada aqui com gravida, teste segue mais abaixo
                        If MsgBox("Informe se este atendimento é de Gestante de último mês ? Atenção, o atestado médico será necessário e verificado na auditagem.", vbYesNo, "Identificada possível Gestante com Limite de consultas excedido !") = vbYes Then
                            BolGravidaAutorizada = True
                            GoTo Fim_OK
                        End If
                    End If

                    If _Prestador.Dentista Then
                        dsGeneric = _PG.DsQuery("Select count(*) from atendimento a where dt_alteracao=current_date And (a.situacao='A' or a.situacao='B') and id_pessoa=" & _Pessoa.Id & " and id_medico=" & _Prestador.Id)
                        If dsGeneric.Tables(0).Rows.Count > 0 Then
                            If dsGeneric.Tables(0).Rows(0).Item(0) > 0 Then
                                MsgBox("Já existe uma consulta hoje. Não é permite dois atendimentos com o mesmo profissional no mesmo dia.")
                                Exit Function
                            End If
                        End If
                        If MsgBox("O paciente já teve registro de consulta no intervalo de 15 dias, só é possível prosseguir se o paciente utilizar excedente. Deseja prosseguir ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then
                            Exit Function
                        End If
                        StrTipoConsulta = "E"
                        GoTo Fim_OK  ' segue para perguntar  excedente
                        'GoTo VerificaLimitesBonus
                    Else
                        MsgBox("Já existe uma consulta a menos de 15 dias para o paciente e o prestador selecionado, nesta situação o sistema considera como RETORNO e não permite o registro de novo atendimento.")
                        Exit Function
                    End If
                End If
            End If
        End If

VerificaLimiteDefault:
        'Int.Normativa 01/2021 - art 15. $3 - no máximo, 02 (duas)consultas médicas e 02 (duas) consultas odontológicas a cada 30 (trinta) dias, mais 05 (cinco) consultas mé
        If IntConsultasRealizadas < IntLimiteDeAtendimentos Then GoTo Fim_OK

        If _Prestador.Dentista Then            ' dentista nao tem mais bonus, é direto excedente
            If MsgBox("Dentistas podem realizar somente 2 consulta a cada " & _setup.prazo_de_pesquisa_atendimentos_medicos & " dias e não tem direito ao bônus, o limite máximo permitido(" & IntLimiteDeAtendimentos & ") foi atingido ! deseja registrar como consulta Excedente ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then
                Exit Function
            End If
            StrTipoConsulta = "E"
            GoTo Fim_OK
        End If

        If _Prestador.Nutricionista Then        ' nutricinista nao tem bonus, é direto excedente
            If MsgBox("Nutricionistas podem realizar somente 1 consulta a cada " & _setup.prazo_de_pesquisa_atendimentos_medicos & " dias, o limite máximo permitido(" & IntLimiteDeAtendimentos & ") foi atingido ! deseja registrar como consulta Excedente ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then
                Exit Function
            End If
            StrTipoConsulta = "E"
            GoTo Fim_OK
        End If

        If _Pessoa.Menor1ano And (_Prestador.Especialidade = 24 Or _Prestador.Especialidade2 = 24) And _Pessoa.ConsultasMedicasRealizadasBebes > 1 Then   ' consulta de pediatra com bebe
            If MsgBox("Já houve UMA consulta pediátrica (menor de 1 ano de idade) nos últimos " & _setup.prazo_de_pesquisa_atendimentos_medicos & " dias. Só é permitida uma consulta a cada " & _setup.prazo_de_pesquisa_atendimentos_medicos & "dias.  Só é possível prosseguir se o paciente utilizar bônus ou excedente. Deseja prosseguir ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then
                Exit Function
            End If
            GoTo VerificaLimitesBonus
        End If

        If MsgBox("O número de consultas " & StrDescricaoTipoConsulta & " desta matricula nos últimos " & _setup.prazo_de_pesquisa_atendimentos_medicos & " dias atingiu o limite máximo permitido(" & IntLimiteDeAtendimentos & ")! Deseja prosseguir usando bônus ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then
            ' impedi a sugestão de excedentes para bonus, na pratica obriga o uso do bonus - versao 2.2.14 - 01/01/2022
            ' poderia pagar um excedente de dentista (21,00) e ficar com bonus para uma consulta medica (75))
            Exit Function
            'If MsgBox("Deseja registrar uma consulta EXCEDENTE ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then Exit Function
            'StrTipoConsulta = "E"
            'GoTo Fim_OK
        End If

VerificaLimitesBonus:

        If _Pessoa.BonusUtilizados365d >= _setup.limite_maximo_bonus Then
            'Int.Normativa 01/2021 - art 15. $3 - bounus a qualquer momento (se nao for com mesmo medico)
            If MsgBox("Todos bônus disponíveis já foram utilizados nos últimos 365 dias. Deseja realizar uma consulta EXCEDENTE ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then Exit Function
            StrTipoConsulta = "E"
            GoTo Fim_OK
        End If

        If _Pessoa.BonusUtilizados30d > 0 Then
            'Int.Normativa 01/2021 - art 15. - versao > 2.2.02 - 06/10/2021 - somente 1 bonus a cada 30 dias SE FOR MESMO MEDICO 
            ' pesquisa abaixo, serve para identificar se o ultimo atendimento foi com o mesmo medico, introduzico versao 2.2.14 em 27/12/2021
            ' em 05/08/22 - retirar 30dias orientacao tatiane - bonus a qualquer momento
            'dsGeneric = _PG.DsQuery("select id_medico from atendimento a inner join pessoas using(id_pessoa) where a.situacao='B' and matricula='" & _Pessoa.Matricula & "' order by a.dt_alteracao desc limit 1")
            'If dsGeneric.Tables(0).Rows.Count > 0 Then
            '    If dsGeneric.Tables(0).Rows(0).Item(0) <> _Prestador.Id Then GoTo BonusAutorizado
            'End If

            ' If MsgBox("É permitido utilizar somente 1 bônus a cada 30 dias e este já foi utilizado. Deseja realizar uma consulta EXCEDENTE ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then Exit Function
            ' StrTipoConsulta = "E"
            ' GoTo Fim_OK
        End If
BonusAutorizado:
        ' bonus autorizado
        If MsgBox("O sistema liberou o registro do atendimento utilizando seus  bônus disponíveis. Deseja prosseguir ?", vbYesNo, "Bônus Liberado !") = vbNo Then Exit Function
        StrTipoConsulta = "B"

Fim_OK:
        ValidaLimiteConsultasOuAtivaBonusExcedente = True

    End Function

    Private Function VerificaExcedente() As String
        VerificaExcedente = ""
        If MsgBox("Deseja registrar uma consulta EXCEDENTE (contribuinte consigna 100%) ?", vbYesNo, "Limite de Consultas atingido !") = vbYes Then VerificaExcedente = "E"

    End Function

    Public Property Justificativa() As String
        Get
            Justificativa = StrJustificativa
        End Get
        Set(ByVal value As String)
            StrJustificativa = value
        End Set
    End Property

    ' instrução normativa - https://www.pelotas.com.br/storage/servicos/prevpel/legislacaoFAM/Intru%C3%A7%C3%A3o%20Normativa%20Conjunta%20-%20FAM%201%C2%BA.%2004.%202021.pdf
    ' Art. 3º,§ 2º, para cada matrícula poderá ser feita no máximo uma consulta com nutricionista a cada intervalo de 30 (trinta) dias.
    '        ,§ 3º,´para cada matrícula, poderão ser autorizadas pelo FAM, no máximo, 02 (duas) consultas médicas e 02 (duas) consultas odontológicas a cada 30 (trinta) dias, mais
    '               05 (cinco) consultas médicas e/ou odontológicas anuais, em qualquer momento, a escolha do contribuinte
    ' Art. 4º,§ 3º A autorização de mais de 60 (sessenta) seções de fisioterapia dentro de um período de 12 (doze) meses dependerá de demonstração da necessidade mediante
    '               perícia médica a cargo Do FAM.
    ' Art. 15. A utilização das 05 (cinco) consultas médicas/odontológicas extraordinárias previstas na segunda parte Do caput Do art. 5º-H da Lei nº 1.984,
    '               de 1972, incluído pela Lei Municipal nº 5.499, de 2008, por um mesmo usuário (titular ou dependente) com um mesmo profissional, deverá observar, entre cada
    '               consulta, o intervalo mínimo de 30 (trinta) dias.
    '   § 1º O limite máximo de uma consulta com um mesmo profissional a cada intervalo de 15 (quinze) dias, estabelecido no § 2º do art. 5º-H da Lei nº 1.984, de 1972,
    '           incluído pela Lei Municipal nº 5.499, de 2008, é computado por matrícula.
    '   § 2º Ao dependente de segurado será garantido o direito a uma consulta mensal de puericultura no primeiro ano de vida, não computável no limite de 02 (duas)
    '           consultas médicas a cada 30 (trinta) dias, estabelecido no § 2º Do art. 5º-H da Lei nº 1.984, de 1972, incluído pela Lei Municipal nº 5.499, de 2008.


    Public Sub ImprimirRecibo(ByVal e As System.Drawing.Printing.PrintPageEventArgs, drAtendimento As Npgsql.NpgsqlDataReader, StrVesaoApp As String)

        Dim viLinha As Integer = 40
        e.Graphics.DrawString("Prefeitura Municipal de Pelotas", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 20

        e.Graphics.DrawString("PREVPEL - Institulo de Previdencia dos Municipários de Pelotas", New Font("arial", 8, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 15
        e.Graphics.DrawString("__________________________________________", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 20

        e.Graphics.DrawString(" Registro de Atendimento Biosifam", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 14

        e.Graphics.DrawString("__________________________________________", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 30

        e.Graphics.DrawString("Data: " & Date.Now.ToShortDateString(), New Font("arial", 12, FontStyle.Regular), Brushes.Black, 10, viLinha)
        e.Graphics.DrawString("Identificador: " & drAtendimento.Item("id_atendimento"), New Font("arial", 12, FontStyle.Regular), Brushes.Black, 160, viLinha)
        viLinha = viLinha + 30

        e.Graphics.DrawString("Prestador Serviço: ", New Font("arial", 9, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 20

        Dim Str38 As String = ""
        Str38 = oMedicoConveniado.Nome
        If Str38.Length > 38 Then Str38 = Str38.Substring(0, 38)
        e.Graphics.DrawString(Str38, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 30

        e.Graphics.DrawString("Paciente: " & drAtendimento.Item("nome_paciente"), New Font("arial", 9, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 20

        e.Graphics.DrawString("Matricula: " & drAtendimento.Item("matricula"), New Font("arial", 9, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 30

        Dim vnTotal As Decimal = drAtendimento.Item("valor")
        e.Graphics.DrawString("Serviço Realizado : ", New Font("arial", 9, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 20

        Str38 = drAtendimento.Item("nome_servico").ToString
        If Str38.Length > 38 Then Str38 = Str38.Substring(0, 30)
        e.Graphics.DrawString(Str38, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 10, viLinha)
        e.Graphics.DrawString("R$ " & Format(drAtendimento.Item(8), "##,##0.00"), New Font("arial", 8, FontStyle.Regular), Brushes.Black, 280, viLinha)
        viLinha = viLinha + 20

        While drAtendimento.Read
            Str38 = drAtendimento.Item("nome_servico").ToString
            If Str38.Length > 38 Then Str38 = Str38.Substring(0, 30)
            e.Graphics.DrawString(Str38, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 10, viLinha)
            e.Graphics.DrawString("R$ " & Format(drAtendimento.Item(8), "##,##0.00"), New Font("arial", 8, FontStyle.Regular), Brushes.Black, 280, viLinha)
            viLinha = viLinha + 20
        End While

        viLinha = viLinha + 20

        e.Graphics.DrawString(Space(35) & "Total : R$ " & Format(vnTotal, "##,##0.00"), New Font("arial", 12, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 20

        viLinha = viLinha + 20
        e.Graphics.DrawString("__________________________________________", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 10, viLinha)
        viLinha = viLinha + 20
        e.Graphics.DrawString(StrVesaoApp & " - impressão em " & Date.Now.ToShortDateString() & Space(2) & Date.Now.ToShortTimeString() & "hs - " & "COINPEL", New Font("arial", 7, FontStyle.Regular), Brushes.Black, 10, viLinha)

        viLinha = viLinha + 20
        e.Graphics.DrawString(".", New Font("arial", 4, FontStyle.Regular), Brushes.Black, 10, viLinha)

    End Sub


    public Sub SalvarCorrecoes(idAtendimento As Long, _Prestador As ClsMedico, StrJustificativa As String) ' as boolean

        Dim StrSituacao As String = ""

        ' aqui só chegam usuario da prevpel, conveniados nao.
        If idAtendimento = 0 Then MsgBox("Identificador não pode ser ZERO!") : Exit Sub
        If _Prestador.Id = 0 Then MsgBox("Prestador não pode ser ZERO !") : Exit Sub
        If _Prestador.Situacao <> "A" Then MsgBox("Prestador está desativado e não pode receber registros!") : Exit Sub
        If _Prestador.UsaBiosifam = False Then MsgBox("Prestador está marcado para não usar Biosifam e não pode receber registros!") : Exit Sub
        If Trim(StrJustificativa) = "" Then MsgBox("Obrigatório informar uma justificativa") : Exit Sub

        If _PG.Conectar = False Then Exit Sub
        _PG.Execute("begin")

        Dim StrSql As String = ""
        Dim _Servico As New ClsServico


        ' apaga todos e insere tudo novamente
        _PG.Execute("delete from atendimento_servico where id_atendimento=" & idAtendimento)

        For i = 0 To 99
            If IntServico(i) > 0 Then
                ' rotina atualiza valor DecValorPrestador, DecValorContribuinte
                _Servico.Carregar(IntServico(i), _Prestador, DecValor(i))
                StrSql = "INSERT INTO atendimento_servico (id_atendimento, id_servico, valor, valor_prestador, valor_contribuinte) values (" &
                           idAtendimento & ",'" & IntServico(i) & "', " & Replace(DecValor(i), ",", ".") & "," & Replace(_Servico.ValorPrestador, ",", ".") & "," & Replace(_Servico.ValorContribuinte, ",", ".") & ");"
                _PG.Execute(StrSql)
            End If
        Next i

        _PG.Execute("update atendimento set valor=" & Replace(vnTotalServicos, ",", ".") & " where id_atendimento=" & idAtendimento)

        Dim drConsulta As Npgsql.NpgsqlDataReader
        drConsulta = _PG.DrQuery("SELECT * FROM atendimento_justificativa where id_atendimento=" & idAtendimento)
        If drConsulta.HasRows Then
            drConsulta.Read()
            If Len(drConsulta.Item("justificativa") & StrJustificativa) > 500 Then
                MsgBox("A justificativa informada junto com a já existente ultrapassam o tamanho maximo permitido de 500 caracteres. Reduza o tamanho da justificativa.")
            End If
            If _PG.Execute("UPDATE atendimento_justificativa SET Justificativa=Justificativa || ', complemento em ' ||  to_char(current_timestamp, 'DD/MM/YYYY') || ' ' ||
                to_char(current_timestamp, 'HH24:MI:SS') || ': " & StrJustificativa & "', ip= '" & _t.ObtemEnderecoIP & "', dt_alteracao=current_timestamp, login='" & _u.Login & "' WHERE id_atendimento=" & idAtendimento) = False Then
                _toolsSiFam.WriteLog("Erro na atualizacao da justificativa.")
                Exit Sub
            End If
        Else
            If _PG.Execute("INSERT INTO atendimento_justificativa (id_atendimento, justificativa, ip, dt_alteracao, login) values (" &
                 idAtendimento & ",'" & StrJustificativa & "', '" & _t.ObtemEnderecoIP & "', current_timestamp ,'" & frmLogin.TxtUsuario.Text & "')") = False Then
                ' JA EXISTE JUSTIFICATIVA, VAI REGRAVAR
                MsgBox("Erro na inserção da justificativa.")
                Exit Sub
            End If
        End If
        _PG.Execute("commit")
        _PG.Desconectar()

        MsgBox("Correção realizada com sucesso!")

        Dim _Pessoa As New ClsPessoa
        Dim Email As ClsMail
        Dim ds As DataSet

        ds = _PG.DsQuery("SELECT id_atendimento, to_ascii(prestador.nome,'LATIN1') as nome_prestador,  to_ascii(p.nome,'LATIN1') as nome_pessoa, a.dt_alteracao, a.situacao, prestador.id_prestador, autorizacao, p.id_pessoa, current_date as hoje, matricula FROM atendimento as a, prestador, pessoas p where a.id_medico=prestador.id_prestador and a.id_pessoa=p.id_pessoa and id_atendimento=" & idAtendimento)

        _Pessoa.CarregarPessoa(ds.Tables(0).Rows(0).Item(7).ToString())
        If _Pessoa.Email <> "" Then
            'vsEmailPaciente = "andrekrolow@gmail.com"
            Email = New ClsMail("Prevpel - Biosifam")
            Email.vsAssunto = "PREPVEL/Biosifam - Aviso de Correção"
            Email.vsMensagem = "Comunicamos a correção do atendimento N. " & idAtendimento & " em " & oMedicoConveniado.Nome & " as "
            Email.vsMensagem &= Format(Date.Now, "hh:mm") & " de " & Format(Date.Today, "dd/MM/yyyy") & " na matricula " & _Pessoa.Matricula & ", paciente " & _Pessoa.Nome & "."
            Email.vsMensagem &= Chr(13) & " PREVPEL/Biosifam"
            Email.vbAutomatico = True
            Email.vbAutenticacaoSegura = True
            Email.vsEmail = _Pessoa.Email
            Email.Enviar()
            If _Pessoa.EmailTitular <> "" And _Pessoa.Email <> _Pessoa.EmailTitular Then
                Email.vsEmail = _Pessoa.EmailTitular
                Email.Enviar()
            End If
            If _u.Email <> "" Then
                Email.vsEmail = _u.Email
                Email.Enviar()
            End If
            'Email.vsEmail = "famatendimento.prevpel@pelotas.rs.gov.br"
            'Email.Enviar()

        End If

erro:

    End Sub

End Class
