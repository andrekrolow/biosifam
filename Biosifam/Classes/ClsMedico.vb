Imports Npgsql
Imports NpgsqlTypes

Public Class ClsMedico

    Dim drMedico As Npgsql.NpgsqlDataReader
    Dim drPrestadorBiosifam As Npgsql.NpgsqlDataReader
    Dim drDocumentos As Npgsql.NpgsqlDataReader
    Dim drTemp As Npgsql.NpgsqlDataReader

    Dim idEspecialidade As Long = 0
    Dim idEspecialidade2 As Long = 0
    Dim vsSituacao As String = ""

    Dim vsCategoria As String = ""          ' é o campo categoria 
    Dim vnModo As Integer = 0               ' conforme campo categoria, indica o tipo de servico (funcionamento) do biosifam
    Dim StrTipoVinculo As String = ""      ' Fisica, Juridica, Sem Vinculo, Vinculado, Setor, indica o tipo de vinculo do prestador
    Dim StrTipoServico As String = ""      ' PM-procedimento médicos (exames), CM-consulta médica ,PA-clinicas, PC-clinicas, CF-consulta fisioterapia, CN-consulta nutricionista
    Dim IntServicoPrincipal As Integer = 0

    Dim vsEndereco As String = ""
    Dim vsCategoriaPessoa As String = ""
    Dim vbResponsavelFinanceiro As Boolean = False
    Dim IdResponsavelFinanceiro As Integer = 0

    Dim BolAnestesista As Boolean = False
    Dim BolFazExameNoConsultorio As Boolean = False
    Dim BolUsaBiosifam As Boolean = False
    Dim BolDentista As Boolean = False
    Dim BolFisioterapeuta As Boolean = False
    Dim BolNutricionista As Boolean = False
    Dim BolLaboratorioAnalisesClinicas As Boolean = False
    Dim BolLaboratorioAnalisesClinicasAtendimentoInterno As Boolean = False
    Dim BolLaboratorioAnalisesClinicasProntoAtendimento As Boolean = False
    Dim BolDespesaHospitalar As Boolean = False

    Dim BolSemAgendamentoPrevio As Boolean = False
    Dim BolLiberaAutorizacao As Boolean = False
    Dim BolLiberaDigitacaoRPJ As Boolean = False        ' agora versao 2.2.48 - libera digitacao offline para novara PA e Atednimento
    Dim BolLiberaCorrecoes As Boolean = False        ' agora versao 2.2.56 - libera correcoes 
    Dim BolLiberaRestricoesDigitacaoRPJ As Boolean = False  ' agora versao 2.2.52 - libera upload e cancelametos apos 5 dia e mes anterior

    Dim vnId As Long = 0
    Dim vsNome As String = ""

    Dim vbUsaLogLocal As Boolean
    Dim vnExpirar As Long = 0
    Dim vsSituacaoBiosifam As String = ""
    Dim StrTabela As String
    Dim BolUsaLog2 As Boolean
    Dim StrClassificacaoExames As String = ""

    Dim StrSituacaoDocumentacao As String = ""
    Dim DatVencimentoDocumentacao As Date
    Dim StrAlerta As String = ""

    Public Sub New(ByVal vnIdMedico As Long)
        IntServicoPrincipal = 0
        BolLiberaAutorizacao = False
        BolFisioterapeuta = False
        BolDentista = False
        BolUsaBiosifam = False
        BolFazExameNoConsultorio = False
        BolAnestesista = False
        BolNutricionista = False
        BolLiberaDigitacaoRPJ = False
        BolLiberaRestricoesDigitacaoRPJ = False
        BolLaboratorioAnalisesClinicas = False
        BolSemAgendamentoPrevio = False
        BolLaboratorioAnalisesClinicasAtendimentoInterno = False
        BolLaboratorioAnalisesClinicasProntoAtendimento = False
        BolDespesaHospitalar = False

        StrTabela = ""
        BolUsaLog2 = False

        If _PG.Conectar = False Then Exit Sub
        If vnIdMedico = 0 Then Exit Sub
        'drMedico = _PG.DrQuery("SELECT * FROM prestador where id_prestador=" & vnIdMedico)
        'Select Case to_ascii(CAMPO,'LATIN1') as NOME from sua_tabela

        drMedico = _PG.DrQuery("SELECT id_prestador, to_ascii(nome,'LATIN1') as nome, situacao, id_especialidades, id_especialidades2, categoria, to_ascii(endereco,'LATIN1') as endereco,to_ascii( bairro,'LATIN1') as  bairro, tipo_pessoa, responsavel_financeiro, usa_exame,usa_biosifam, usa_autorizacao, usa_log_local_biosifam, expiracao_biosifam, situacao_biosifam, libera_modo_rpj, libera_digitacao,tabela, usa_log2,tipo_vinculo,categoria2,ordem_classificacao_servicos, libera_correcoes FROM prestador where id_prestador=" & vnIdMedico)
        If drMedico.HasRows Then
            drMedico.Read()
            vnId = drMedico.Item("id_prestador")
            vsNome = Trim(drMedico.Item("nome"))
            vsSituacao = drMedico.Item("situacao")
            idEspecialidade = drMedico.Item("id_especialidades")
            idEspecialidade2 = drMedico.Item("id_especialidades2")
            vsCategoria = drMedico.Item("categoria")
            '	<option value = "M" <? If($form_categoria== "M")echo "selected"; Else echo 'selected';?> />Consultas M&eacute;dicas
            '	<option value = "O" <? If($form_categoria=="O") echo "selected";?> />Odontol&oacute;gico						
            '	<option value = "1" <? If($form_categoria=="1") echo "selected";?> />Hospitalar
            '	<option value = "2" <? If($form_categoria=="2") echo "selected";?> />Pronto Atendimento<br>
            '	<option value = "3" <? If($form_categoria=="3") echo "selected";?> />Laboratório
            '	<option value = "4" <? If($form_categoria=="4") echo "selected";?> />Clínica
            '	<option value = "5" <? If($form_categoria=="5") echo "selected";?> />Serviços Referenciados

            'vsGlo_Modo = Split("Retaguarda,Consulta Digitais,Consultório Médico,Exames Clínicos,Fisioterapia,Pronto Atendimento", ",")


            '--------------------------------------------------------------------------------------------
            vnModo = 0  ' retaguarda - so pessoal administrativo
            vnModo = 1  ' consulta biometria - default em caso de erro de cadastro
            ' 06/05/2022
            ' campo categoria hoje está marcando o MODO de funcionamento do biosifam 0-retaguarda,1-consulta biometria,2=atendimento consulta,3-exames,5-hospitalar
            ' campo categoria ainda contem resquícios do antigo ´modo´de funcionar onde identifica o tipo de profissinal que agora é categoria2

            ' a ideia é minimzar o uso do modo, forcando o uso da categoria
            ' invrti a logica e parece que o modo deve se soprepor a categoria
            ' modo 0=retguarda,1-consulta biometria,2-atendimento consulta,3-atendimento exames,4-atendimento PA, 5-atendimento hospitalar
            If vsCategoria = "M" Or vsCategoria = "O" Then
                vnModo = 2
                IntServicoPrincipal = 1
                StrTipoServico = "CM" ' consulta médica - medicos que fazem exame tem o tipo modificado para PM, quando servico não for codigo 1

                If idEspecialidade = 1 Then
                    BolAnestesista = True
                    ' especialidade 1 = anestesista
                    StrTipoServico = "AN" ' anestesistas
                End If

                If idEspecialidade = 19 Or idEspecialidade2 = 19 Or idEspecialidade = 42 Or idEspecialidade2 = 42 Then
                    ' especialidade 19 = dentista
                    ' especialidade 42 = bucomaxilo = dentista
                    ' usam procedimentos vinculados 
                    BolDentista = True
                    IntServicoPrincipal = 0
                    StrTipoServico = "CO" ' consulta odontológica - não separo consulta de procedimentos
                End If

                If idEspecialidade = 34 Or idEspecialidade2 = 34 Then
                    BolFisioterapeuta = True
                    IntServicoPrincipal = 16681 ' especialidade 34 = fisioterapia
                    StrTipoServico = "CF"
                End If
                If idEspecialidade = 18 Or idEspecialidade2 = 18 Then
                    BolNutricionista = True
                    IntServicoPrincipal = 16999  ' especialidade 18 = nutricionista
                    StrTipoServico = "CN" ' consulta nutricionista
                End If

            ElseIf vsCategoria = "1" Then
                vnModo = 5 ' Hospitalar -  novo - hositais com setores - 05-01-2022
                StrTipoServico = "PH"

            ElseIf vsCategoria = "2" Then
                vnModo = 4       ' PA -    ' PA - pronto atendimento = categ=2--> pronto atendimento (4)
                StrTipoServico = "PA" ' clinicas

            ElseIf vsCategoria = "3" Then
                vnModo = 3  ' - EXAMES -      ' clinicanp  = categ=1--> hospitalr ---> só faz exames (3)
                StrTipoServico = "PC" ' clinicas

            End If

            '------------------------------------------------------------------------------------------------------------------


            BolLiberaDigitacaoRPJ = drMedico.Item("libera_modo_rpj")
            BolLiberaCorrecoes = drMedico.Item("libera_correcoes")
            BolLiberaRestricoesDigitacaoRPJ = drMedico.Item("libera_digitacao")

            StrTipoVinculo = Trim(drMedico.Item("tipo_vinculo"))
            If StrTipoVinculo = "S" Or StrTipoVinculo = "V" Then
                ' setor de algum conveniado - sempre tem um responsavel financeiro - HOS
                drPrestadorBiosifam = _PG.DrQuery("select p.id_prestador,libera_modo_rpj, libera_correcoes,libera_digitacao from prestador_vinculados inner join prestador p using (id_prestador) where id_vinculado=" & vnId)
                If drPrestadorBiosifam.HasRows Then
                    drPrestadorBiosifam.Read()
                    IdResponsavelFinanceiro = drPrestadorBiosifam.Item(0)
                    BolLiberaDigitacaoRPJ = drPrestadorBiosifam.Item("libera_modo_rpj")
                    BolLiberaCorrecoes = drPrestadorBiosifam.Item("libera_correcoes")
                    BolLiberaRestricoesDigitacaoRPJ = drPrestadorBiosifam.Item("libera_digitacao")

                End If
            End If

            If IsDBNull(drMedico.Item("categoria2")) = False Then
                If drMedico.Item("categoria2") = 8 Then
                    BolLaboratorioAnalisesClinicas = True  ' nova tabela Tatiane
                    If InStr(drMedico.Item("nome"), "INTERNA") Then BolLaboratorioAnalisesClinicasAtendimentoInterno = True : BolDespesaHospitalar = True '1595
                    If InStr(drMedico.Item("nome"), "PRONTO") Then BolLaboratorioAnalisesClinicasProntoAtendimento = True : BolDespesaHospitalar = True '1596
                End If
                If drMedico.Item("categoria2") = 18 Then BolSemAgendamentoPrevio = True  ' nova tabela Tatiane
            End If

            vsEndereco = Trim(drMedico.Item("endereco")) & ", " & Trim(drMedico.Item("bairro"))
            If IsDBNull(drMedico.Item("tipo_pessoa")) = False Then vsCategoriaPessoa = drMedico.Item("tipo_pessoa") Else vsCategoriaPessoa = ""
            vbResponsavelFinanceiro = drMedico.Item("responsavel_financeiro")
            BolFazExameNoConsultorio = IIf(drMedico.Item("usa_exame") = "S", True, False)
            BolUsaBiosifam = IIf(Trim(drMedico.Item("usa_biosifam")) = "S", True, False)

            'BolLiberaAutorizacao = IIf(Trim(drMedico.Item("usa_autorizacao")), True, False)
            'versoes anteriores a 2.1.07, utilizam o test acima, que precisar ser true or false e na realizade o campo é string
            'segue abaixo correção,que apos todos terem essa versao de correcao 2.1.07 posso voltar ao normal, que é a linha baixo
            'BolLiberaAutorizacao = IIf(Trim(drMedico.Item("usa_biosifam")) = "S", True, False)
            If drMedico.Item("usa_autorizacao") = "1" Or drMedico.Item("usa_autorizacao") = "S" Then
                BolLiberaAutorizacao = True
            Else
                BolLiberaAutorizacao = False
            End If

            'novos campo incorprados da tabela prestador_biosifam <- que sera eliminada
            vbUsaLogLocal = drMedico.Item("usa_log_local_biosifam")
            ' eliminados a partir de 12/2021 - versao 2.2.10
            'vbUsaEmail = drMedico.Item("usa_email_biosifam")
            'vbUsaVoz = drMedico.Item("usa_voz_biosifam")
            'vbUsaLoginBiometrico = drMedico.Item("usa_login_biometrico")
            'BolLiberaUpdate = drMedico.Item("libera_update_biosifam")
            vnExpirar = drMedico.Item("expiracao_biosifam")
            vsSituacaoBiosifam = drMedico.Item("situacao_biosifam")

            StrTabela = drMedico.Item("tabela")
            BolUsaLog2 = drMedico.Item("usa_log2")
            If IsDBNull(drMedico.Item("ordem_classificacao_servicos")) = False Then StrClassificacaoExames = drMedico.Item("ordem_classificacao_servicos") Else StrClassificacaoExames = ""
            If StrClassificacaoExames = "" Then
                StrClassificacaoExames = "A"  ' A-alfabetica, C-codigo
                OrdemClassificacaoServicos = "A"  'salva no bancoo de dados
            End If

        End If

        ' bloqueei em 10/0622 - versap 2.2.59 - apos essa pode elimnar a tabela de vez
        GoTo FimBloco

        ' apos todos terem a versao 2.1.02, posso eliminar o prestador_biosifam
        ' apos todos terem a versao 2.2.65,  eliminadoa tabela prestador_biosifam

FimBloco:

        If vsSituacaoBiosifam = "1" Then MsgBox("Sistema em manutenção, aguarde alguns instantes e tente novo acesso.", MsgBoxStyle.Critical, "Biosifam. Acesso negado.") : End
        If vsSituacaoBiosifam = "2" Then MsgBox("Sistema bloqueado por ordem do Administrador.", MsgBoxStyle.Critical, "Biosifam. Acesso negado.") : End

        _PG.Desconectar()
    End Sub

    Public Sub CarregaComboMedicos(ByRef Combo As ComboBox, ByRef PidResponsavelFinanceiro As Long)
        Combo.Items.Clear()
        PidResponsavelFinanceiro = 0
        If oMedicoConveniado.ResponsavelFinanceiro Then
            ' quando é responsavel - seleciona os vinculados no combo de medicos
            ' atendimento com agrupador financeiro - no retaguarda cadastra apenas o responsavel financeiro-os demais serão buscados aqui.
            _t.CarregaCombo(Combo, "select prestador.id_prestador,to_ascii(prestador.nome,'LATIN1') || case when especialidades.nome <>'' then ' - ' || to_ascii(especialidades.nome,'LATIN1') else '' end  as nome from prestador_vinculados inner join prestador on prestador_vinculados.id_vinculado=prestador.id_prestador left join especialidades on especialidades.id_especialidades=prestador.id_especialidades where prestador_vinculados.id_prestador =" & oMedicoConveniado.Id & " and situacao='A' order by prestador.nome ")
            PidResponsavelFinanceiro = oMedicoConveniado.Id
            Combo.Enabled = True
        Else
            ' s=setor dos hospitais - possuem apenas um vinculo do o seu responsavel financeiro <> dos medicos vinculados
            If StrTipoVinculo = "S" Then
                PidResponsavelFinanceiro = IdResponsavelFinanceiro

            End If
            If oMedicoConveniado.Id > 0 Then Combo.Items.Add(New ComboData(oMedicoConveniado.Id, oMedicoConveniado.Nome))
            ' If oMedicoConveniado.Medico1_id > 0 Then Combo.Items.Add(New ComboData(oMedicoConveniado.Medico1_id, oMedicoConveniado.MedicoNome1))
            ' If oMedicoConveniado.Medico2_id > 0 Then Combo.Items.Add(New ComboData(oMedicoConveniado.Medico2_id, oMedicoConveniado.MedicoNome2))
            ' If oMedicoConveniado.Medico3_id > 0 Then Combo.Items.Add(New ComboData(oMedicoConveniado.Medico3_id, oMedicoConveniado.MedicoNome3))
            'If oMedicoConveniado.Medico4_id > 0 Then Combo.Items.Add(New ComboData(oMedicoConveniado.Medico4_id, oMedicoConveniado.MedicoNome4))
            If Combo.Items.Count > 1 Then Combo.Enabled = True
            If Combo.Items.Count > 0 Then Combo.SelectedIndex = 0
        End If

    End Sub
    Public Property Id() As String
        Get
            Id = vnId
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Nome() As String
        Get
            Nome = vsNome
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Especialidade() As String
        Get
            Especialidade = idEspecialidade
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Especialidade2() As String
        Get
            Especialidade2 = idEspecialidade2
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Categoria() As String
        Get
            Categoria = vsCategoria
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Situacao() As String
        Get
            Situacao = vsSituacao
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Vinculo() As String
        Get
            Vinculo = StrTipoVinculo
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Property TipoServico() As String
        Get
            TipoServico = StrTipoServico
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Property Endereco() As String
        Get
            Endereco = vsEndereco
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property TipoPessoa() As String
        Get
            TipoPessoa = vsCategoriaPessoa
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property ResponsavelFinanceiro() As Boolean
        Get
            ResponsavelFinanceiro = vbResponsavelFinanceiro
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property ResponsavelFinanceiro_Id() As Integer
        Get
            ResponsavelFinanceiro_Id = IdResponsavelFinanceiro
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property Anestesista() As Boolean
        Get
            Anestesista = BolAnestesista
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property Nutricionista() As Boolean
        Get
            Nutricionista = BolNutricionista
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property FazExameNoConsultorio() As Boolean
        Get
            FazExameNoConsultorio = BolFazExameNoConsultorio
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property LaboratorioAnalisesClinicas() As Boolean
        Get
            LaboratorioAnalisesClinicas = BolLaboratorioAnalisesClinicas
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property SemAgendamentoPrevio() As Boolean
        Get
            SemAgendamentoPrevio = BolSemAgendamentoPrevio
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property DespesaHospitalar() As Boolean
        Get
            DespesaHospitalar = BolDespesaHospitalar
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property LaboratorioAnalisesClinicasAtendimentoInterno() As Boolean
        Get
            LaboratorioAnalisesClinicasAtendimentoInterno = BolLaboratorioAnalisesClinicasAtendimentoInterno
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property LaboratorioAnalisesClinicasProntoAtendimento() As Boolean
        Get
            LaboratorioAnalisesClinicasProntoAtendimento = BolLaboratorioAnalisesClinicasProntoAtendimento
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    Public Property UsaBiosifam() As Boolean
        Get
            UsaBiosifam = BolUsaBiosifam
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    Public Property UsaLogLocal() As Boolean
        Get
            UsaLogLocal = vbUsaLogLocal
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    Public Property LiberaRestricoesDigitacaoRPJ() As Boolean
        Get
            LiberaRestricoesDigitacaoRPJ = BolLiberaRestricoesDigitacaoRPJ
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    Public Property LiberaCorrecoes() As Boolean
        Get
            LiberaCorrecoes = BolLiberaCorrecoes
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    Public Property LiberaDigitacaoOffLine() As Boolean
        Get
            LiberaDigitacaoOffLine = BolLiberaDigitacaoRPJ
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property


    Public Property Expirar() As Long
        Get
            Expirar = vnExpirar
        End Get
        Set(ByVal value As Long)
        End Set
    End Property
    Public Property SituacaoBiosifam() As String
        Get
            SituacaoBiosifam = vsSituacaoBiosifam
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Tabela() As String
        Get
            Tabela = StrTabela
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Modo() As Integer
        Get
            Modo = vnModo
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property Dentista() As Boolean
        Get
            Dentista = BolDentista
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    Public Property Fisioterapeuta() As Boolean
        Get
            Fisioterapeuta = BolFisioterapeuta
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    Public Property LiberaAutorizacao() As Boolean
        Get
            LiberaAutorizacao = BolLiberaAutorizacao
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    Public Property Log2() As Boolean
        Get
            Log2 = BolUsaLog2
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property IdServicoPrincipal() As Integer
        Get
            IdServicoPrincipal = IntServicoPrincipal
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property OrdemClassificacaoServicos() As String
        Get
            OrdemClassificacaoServicos = StrClassificacaoExames
        End Get
        Set(ByVal value As String)
            _PG.Execute("update prestador set ordem_classificacao_servicos='" & value & "' WHERE id_prestador=" & Id)
            StrClassificacaoExames = value
        End Set
    End Property

    Public Function VerificaRestricoesOffLine(DataLancamento As Date, Situacao As String) As Boolean
        VerificaRestricoesOffLine = False
        If BolLiberaRestricoesDigitacaoRPJ Then
            ' quando libera restricoes foi ativado é que nao consegue mais alterar o mes  anterior, 
            If Situacao <> "G" Then
                MsgBox("Somente lançamentos GLOSADOS podem ser corrigidos com datas retroativas após o mês anterior.", vbCritical, " Correção Impossível. ")
                Exit Function
            End If
            GoTo Libera
        End If
        If _w.Modo = 0 Then GoTo Libera
        Dim DatDataServidor As Date = _PG.DataServidor()
        ' Primeiro dia do mes
        Dim _data As New ClsData
        Dim DatQuintoDiaUtil As Date = CDate(_data.QuintoDiaUtil(CDate(DatDataServidor.Year & "/" & DatDataServidor.Month & "/01")))
        If DatDataServidor <= DatQuintoDiaUtil Then
            If CDate(DataLancamento).Month < (DatDataServidor.Month - 1) Then
                MsgBox("Você só tem permissão para operações com datas retroativas até o mês anterior. Caso seja necessário ultrapassar este limite, solicite à PREVPEL autorização para o procedimento.", vbCritical, " Data inválida ")
                Exit Function
            End If
        Else
            If CDate(DataLancamento).AddDays(DatDataServidor.Day - 1) < DatDataServidor Then
                MsgBox("Você só tem permissão para oparações com datas no mês corrente. Caso seja necessário ultrapassar este limite, solicite à PREVPEL autorização para o procedimento.", vbCritical, " Data inválida ")
                Exit Function
            End If
        End If
Libera:
        VerificaRestricoesOffLine = True

    End Function

    Public Property SituacaoDocumentacao() As String
        Get
            SituacaoDocumentacao = StrSituacaoDocumentacao
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property VencimentoDocumentacao() As Date
        Get
            VencimentoDocumentacao = DatVencimentoDocumentacao
        End Get
        Set(ByVal value As Date)
        End Set
    End Property
    Public Property Alerta() As String
        Get
            Alerta = StrAlerta
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Function VerificaSituacaoDocumentacao() As Boolean
        VerificaSituacaoDocumentacao = True
        Dim DatDataServidor As Date = _PG.DataServidor()

        If oMedicoConveniado.Vinculo = "V" Or oMedicoConveniado.Vinculo = "S" Then
            SituacaoDocumentacao = "V"  ' validado
            Exit Function
        End If
        If _PG.Conectar = False Then Exit Function
        drDocumentos = _PG.DrQuery("SELECT * FROM prestador_documentos where id_prestador=" & vnId)
        If drDocumentos.HasRows Then
            drDocumentos.Read()
            StrSituacaoDocumentacao = drDocumentos.Item("situacao")
            DatVencimentoDocumentacao = drDocumentos.Item("vencimento")
        Else
            StrSituacaoDocumentacao = "P"
            DatVencimentoDocumentacao = CDate(DatDataServidor.AddDays(60))
            _PG.Execute("insert into prestador_documentos (id_prestador, situacao, vencimento, data_situacao, login, ip, dt_alteracao, hr_alteracao) values 
                        (" & Id & ",'" & StrSituacaoDocumentacao & "', '" & Format(DatVencimentoDocumentacao, "yyyy/MM/dd") & "',current_date, '" & _u.Login & "','" & _t.IP_Externo & "',current_date,  substring(cast (current_time as TEXT),1,5))")
        End If

        ' alertas ainda nao estão ativos
        StrAlerta = ""
        If SituacaoDocumentacao = "P" Then
            StrAlerta = "A nova sistemática de Credenciamento virtual identificou que seu cadastro está pendente e ainda não possui a documentação requerida digitalizada, por favor utilize no Menu Controle, a opção Upload de Documentos de Credenciamento e envie a documentação solicitada."

        ElseIf strSituacaoDocumentacao = "R" Then
            StrAlerta = "Documentação de Credenciamento está com situação REJEITADA, por favor utilize no Menu Controle, a opção Upload de Documentos de Credenciamento para sanar os problemas detectados."

        Else
            ' situacao = V = validada
            If DatVencimentoDocumentacao < DatDataServidor Then
                StrAlerta = "Documentação de Credenciamento está com situação VENCIDA, por favor utilize no Menu Controle, a opção Upload de Documentos de Credenciamento para atualizar os documentos solicitados e reativar o uso do aplicativo BIOSIFAM."
                StrSituacaoDocumentacao = "S"  'Suspenso
                VerificaSituacaoDocumentacao = False
            Else
                If DatVencimentoDocumentacao = DatDataServidor Then
                    StrAlerta = "Documentação de Credenciamento está VENCENDO HOJE, por favor utilize no Menu Controle, a opção Upload de Documentos de Credenciamento para atualizar os documentos solicitados e evitar o travamento do uso do aplicativo BIOSIFAM."

                ElseIf datVencimentoDocumentacao < DatDataServidor.AddDays(30) And VencimentoDocumentacao > DatDataServidor.AddDays(15) Then
                    StrAlerta = "Documentação de Credenciamento vencerá em " & VencimentoDocumentacao & ", por favor utilize no Menu Controle, a opção Upload de Documentos de Credenciamento para atualizar os documentos solicitados e evitar o travamento do aplicativio BIOSIFAM."

                Else
                    StrAlerta = "Documentação de Credenciamento vencerá em " & VencimentoDocumentacao & ", MENOS DE 15 DIAS!, Por favor utilize no Menu Controle, a opção Upload de Documentos de Credenciamento para atualizar os documentos solicitados e evitar o travamento do aplicativio BIOSIFAM."
                End If
            End If
        End If
Libera:


    End Function

End Class
