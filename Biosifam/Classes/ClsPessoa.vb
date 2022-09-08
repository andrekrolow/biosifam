Public Class ClsPessoa
    Dim drGeneric As Npgsql.NpgsqlDataReader

    Dim IdPessoa As Integer
    Dim StrMatricula As String
    Dim StrNome As String
    Dim StrCPF As String
    Dim StrTipoUsuario As String
    Dim StrTipoUsuarioDescricao As String
    Dim StrEmail As String
    Dim StrEmailTitular As String
    Dim StrCelular As String
    Dim StrTelefone As String
    Dim StrImage As String

    Dim StrSenhaDaPessoaNoBancoas As String
    Dim DatNascimento As Date
    Dim StrSexo As String
    Dim BolLiberaUsoPorSenha As Boolean
    Dim DatSenhaDaPessoa As Date
    Dim StrSituacao As String

    Dim BolMenor12anos As Boolean
    Dim BolMenor1ano As Boolean
    Dim BolIdadeFertil As Boolean

    Dim BolTitular As Boolean
    Dim IntTitular As Integer

    Dim BolPossivelGravida As Boolean   ' alimentado pelo sistema
    Dim BolValidacaoPorDigital As Boolean
    Dim IntDigitaisCadastradas As Integer

    Dim ds As DataSet


    Dim IntConsultasMedicasRealizadas As Integer
    Dim IntConsultasMedicasRealizadasBebes As Integer
    Dim IntConsultasOdontologicasRealizadas As Integer
    Dim IntConsultasNutricionistaRealizadas As Integer
    Dim IntFisioterapiasRealizadas As Integer
    Dim IntExamesClinicosRealizados As Integer
    Dim IntTerceirosMolaresExtraidos As Integer

    Dim IntAutorizacoesEmAberto As Integer
    Dim IdAutorizacaoFisioterapia As Integer
    Dim IntBonusUtilizados365d As Integer
    Dim IntBonusUtilizados30d As Integer
    Dim IntExcedenteUtilizados As Integer

    Dim StrProximaConsulta As String

    Dim StrRetorno As String    ' usado para devolver alguma informação 

    Public vnTotalDisponivelCobertura As Decimal = 0
    Public vnTotalDespesasHospitalares As Decimal = 0

    'Dim NascimentoSelecionado As Date
    'Dim Selecionado_Sexo As String
    'Dim LiberaUsoPorSenha As String = "N"
    'Dim vsEmailTitular As String

    Public Sub Inicializar()
        IdPessoa = 0

        StrMatricula = ""
        StrNome = ""
        StrCPF = ""
        StrTipoUsuario = ""
        StrTipoUsuarioDescricao = ""

        StrEmail = ""
        StrEmailTitular = ""
        StrCelular = ""
        StrTelefone = ""

        StrSenhaDaPessoaNoBancoas = ""
        DatNascimento = Nothing
        StrSexo = ""
        BolLiberaUsoPorSenha = False
        DatSenhaDaPessoa = Nothing
        StrSituacao = ""

        BolMenor12anos = False
        BolMenor1ano = False
        BolIdadeFertil = False

        BolTitular = False
        IntTitular = 0

        BolPossivelGravida = False
        BolValidacaoPorDigital = False
        IntDigitaisCadastradas = 0

        StrRetorno = ""
        StrImage = ""
        vnTotalDisponivelCobertura = 0
        vnTotalDespesasHospitalares = 0

    End Sub

    Public Function CarregarPessoa(intPessoa As Integer) As Boolean
        CarregarPessoa = False
        Inicializar()
        IdPessoa = intPessoa

        If IdPessoa > 0 Then
            Try
                ds = _PG.DsQuery("SELECT matricula, to_ascii(nome,'LATIN1') as NOME, id_tipo_usuario, email, num_telefone, num_celular, senha , dt_nascimento , sexo, situacao, biosifam_senha, senha_data, to_ascii(descricao ,'LATIN1') as Tipo, cpf, image  from pessoas inner join tipo_usuario on id_tipo_usuario=id_tipo WHERE id_pessoa=" & IdPessoa)

                If ds.Tables(0).Rows.Count > 0 Then

                    StrMatricula = Trim(ds.Tables(0).Rows(0).Item(0))
                    StrNome = Trim(ds.Tables(0).Rows(0).Item(1))
                    StrTipoUsuario = ds.Tables(0).Rows(0).Item(2)
                    StrEmail = Trim(ds.Tables(0).Rows(0).Item(3))
                    If IsDBNull(ds.Tables(0).Rows(0).Item("image")) = False Then
                        StrImage = Trim(ds.Tables(0).Rows(0).Item("image"))
                    End If

                    ' pode nao existir o registro na tabela pessoa_dados
                    If IsDBNull(ds.Tables(0).Rows(0).Item(4)) = False Then StrTelefone = ds.Tables(0).Rows(0).Item(4) Else StrTelefone = ""
                    If IsDBNull(ds.Tables(0).Rows(0).Item(5)) = False Then StrCelular = ds.Tables(0).Rows(0).Item(5) Else StrCelular = ""

                    DatNascimento = ds.Tables(0).Rows(0).Item(7)
                    If Int(DateDiff("d", ds.Tables(0).Rows(0).Item(7), Date.Today) / 365) < 1 Then BolMenor1ano = True
                    If Int(DateDiff("d", ds.Tables(0).Rows(0).Item(7), Date.Today) / 365) < 12 Then BolMenor12anos = True

                    StrSexo = ds.Tables(0).Rows(0).Item(8)
                    If StrSexo = "F" And Int(DateDiff("d", ds.Tables(0).Rows(0).Item(7), Date.Today) / 365) > 12 And
                       Int(DateDiff("d", ds.Tables(0).Rows(0).Item(7), Date.Today) / 365) < 50 Then BolIdadeFertil = True

                    StrSituacao = ds.Tables(0).Rows(0).Item(9)

                    BolLiberaUsoPorSenha = IIf(ds.Tables(0).Rows(0).Item(10) = "S", True, False)
                    If BolLiberaUsoPorSenha Then
                        If IsDBNull(ds.Tables(0).Rows(0).Item(11)) = False Then DatSenhaDaPessoa = ds.Tables(0).Rows(0).Item(11) Else DatSenhaDaPessoa = Nothing
                        StrSenhaDaPessoaNoBancoas = ds.Tables(0).Rows(0).Item(6)
                    End If

                    StrTipoUsuarioDescricao = ds.Tables(0).Rows(0).Item(12)
                    StrCPF = ds.Tables(0).Rows(0).Item(13)

                    If StrTipoUsuario <> "2" Then
                        ds = _PG.DsQuery("SELECT id_pessoa, email from pessoas WHERE id_tipo_usuario=2 and matricula='" & StrMatricula & "'")
                        If ds.Tables(0).Rows.Count > 0 Then
                            StrEmailTitular = ds.Tables(0).Rows(0).Item(1)
                            IntTitular = ds.Tables(0).Rows(0).Item(0)
                        End If
                    Else
                        BolTitular = True
                    End If

                    ds = _PG.DsQuery("SELECT count(*) FROM digital WHERE id_pessoa=" & IdPessoa)
                    If ds.Tables(0).Rows.Count > 0 Then
                        IntDigitaisCadastradas = ds.Tables(0).Rows(0).Item(0)
                        BolValidacaoPorDigital = True
                    End If

                End If
                CarregarPessoa = True
            Catch ex As Exception
                IdPessoa = 0
                MsgBox("Erro ao carregar dados do paciente." & ex.Message, vbInformation, Application.ProductName & " - ClsPessoa")
            End Try

        End If

    End Function

    Public Function ValidarBiometria(ByVal Ret As Integer) As Boolean
        ValidarBiometria = False
        ds = _PG.DsQuery("SELECT pessoas.id_pessoa, to_ascii(nome,'LATIN1') as nome, matricula FROM pessoas INNER JOIN digital USING (id_pessoa) WHERE id_digital = " & Ret)
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item(0) <> IdPessoa Then
                'quando for menor, apenas Digitais da matricula estarão PRESENTES no select
                If BolMenor12anos Then
                    If Trim(ds.Tables(0).Rows(0).Item(2)) = StrMatricula Then
                        vsGlo_Log = "Identificado paciente com menos de 12 anos !" & Chr(13) & "Validação aceita pela Matricula, " & ds.Tables(0).Rows(0).Item(1) & Chr(13) & Chr(13)
                        MsgBox(vsGlo_Log)
                    Else
                        vsGlo_Log = "Digital pertence a outro paciente, " & ds.Tables(0).Rows(0).Item(1)
                        MsgBox(vsGlo_Log)
                        Exit Function
                    End If
                Else
                    vsGlo_Log = "Digital pertence a outro paciente, " & ds.Tables(0).Rows(0).Item(1)
                    MsgBox(vsGlo_Log)
                    Exit Function
                End If
            End If
        End If
        ValidarBiometria = True
    End Function


    Public Property Id() As Integer
        Get
            Id = IdPessoa
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property Matricula() As String
        Get
            Matricula = Trim(StrMatricula)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Nome() As String
        Get
            Nome = Trim(StrNome)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property CPF() As String
        Get
            CPF = Trim(StrCPF)
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Property Titular() As Boolean
        Get
            Titular = BolTitular
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property Email() As String
        Get
            Email = Trim(StrEmail)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property EmailTitular() As String
        Get
            EmailTitular = Trim(StrEmailTitular)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Telefone() As String
        Get
            Telefone = Trim(StrTelefone)
        End Get
        Set(ByVal value As String)
            StrTelefone = value
        End Set
    End Property
    Public Property Celular() As String
        Get
            Celular = Trim(StrCelular)
        End Get
        Set(ByVal value As String)
            StrCelular = value
        End Set
    End Property
    Public Property SenhaDaPessoaNoBanco As String
        Get
            SenhaDaPessoaNoBanco = Trim(StrSenhaDaPessoaNoBancoas)
        End Get
        Set(ByVal value As String)
            StrSenhaDaPessoaNoBancoas = value
        End Set
    End Property
    Public Property DataNascimento() As Date
        Get
            DataNascimento = Trim(DatNascimento)
        End Get
        Set(ByVal value As Date)
        End Set
    End Property
    Public Property Sexo() As String
        Get
            Sexo = Trim(StrSexo)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property LiberaUsoPorSenha() As Boolean
        Get
            LiberaUsoPorSenha = BolLiberaUsoPorSenha
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property DataSenhaPessoa() As Date
        Get
            DataSenhaPessoa = DatSenhaDaPessoa
        End Get
        Set(ByVal value As Date)
            DatSenhaDaPessoa = value
        End Set
    End Property
    Public Property TipoUsuarioDescricao() As String
        Get
            TipoUsuarioDescricao = StrTipoUsuarioDescricao
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Property Menor12anos() As Boolean
        Get
            Menor12anos = BolMenor12anos
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property Menor1ano() As Boolean
        Get
            Menor1ano = BolMenor1ano
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property IdadeFertil() As Boolean
        Get
            IdadeFertil = BolIdadeFertil
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property PossivelGravida() As Boolean
        Get
            PossivelGravida = BolPossivelGravida
        End Get
        Set(ByVal value As Boolean)
            BolPossivelGravida = value
        End Set
    End Property

    Public Property IdTitular() As Integer
        Get
            IdTitular = IntTitular
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property ValidacaoPorDigital() As Boolean
        Get
            ValidacaoPorDigital = BolValidacaoPorDigital
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property DigitaisCadastradas() As Integer
        Get
            DigitaisCadastradas = IntDigitaisCadastradas
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property ConsultasMedicasRealizadas() As Integer
        Get
            ConsultasMedicasRealizadas = IntConsultasMedicasRealizadas
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property ConsultasMedicasRealizadasBebes() As Integer
        Get
            ConsultasMedicasRealizadasBebes = IntConsultasMedicasRealizadasBebes
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property ConsultasOdontologicasRealizadas() As Integer
        Get
            ConsultasOdontologicasRealizadas = IntConsultasOdontologicasRealizadas
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property ConsultaExamesClinicosRealizados(ByVal _Prestador As ClsMedico, PrazoEmDias As Integer) As Integer
        Get
            ' prestador com categori=8 = fazem exames de analises laboratoriais
            ' os prestador 1595 e 1596 atendimento interno e pronto atendimento nao podem estrar neste calculo, sao despesas hospitalares e consginado 100%
            IntExamesClinicosRealizados = 0

            ds = _PG.DsQuery("SELECT count(*) FROM atendimento a inner join prestador on id_medico=id_prestador inner join pessoas using(id_pessoa)
                    inner join atendimento_servico using (id_atendimento) WHERE categoria2=8 and id_prestador not in (1595, 1596) and matricula='" & Matricula & "' and (a.situacao <>'C' 
                    and a.situacao <>'E') and a.dt_alteracao > (current_date-" & PrazoEmDias & ")")
            If ds.Tables(0).Rows.Count > 0 Then
                IntExamesClinicosRealizados = ds.Tables(0).Rows(0).Item(0)
            End If
            ConsultaExamesClinicosRealizados = IntExamesClinicosRealizados
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property ExamesClinicosRealizados() As Integer
        Get
            ExamesClinicosRealizados = IntExamesClinicosRealizados
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property TerceirosMolaresExtraidos() As Integer
        Get
            IntTerceirosMolaresExtraidos = 0
            If _PG.Conectar() Then
                drGeneric = _PG.DrQuery("Select count(*) FROM atendimento a inner join atendimento_servico Using (id_atendimento) WHERE a.situacao <>'C' and a.situacao <>'E' and id_servico=42 and id_pessoa=" & IdPessoa)
                If drGeneric.HasRows Then
                    drGeneric.Read()
                    IntTerceirosMolaresExtraidos = drGeneric.Item(0)
                End If
            End If
            TerceirosMolaresExtraidos = IntTerceirosMolaresExtraidos
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property FisioterapiasRealizadas() As Integer
        Get
            FisioterapiasRealizadas = IntFisioterapiasRealizadas
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property ConsultasNutricionistaRealizadas() As Integer
        Get
            ConsultasNutricionistaRealizadas = IntConsultasNutricionistaRealizadas
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property AutorizacoesEmAberto() As Integer
        Get
            AutorizacoesEmAberto = IntAutorizacoesEmAberto
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property AutorizacaoFisioterapia() As Integer
        Get
            AutorizacaoFisioterapia = IdAutorizacaoFisioterapia
        End Get
        Set(ByVal value As Integer)
            IdAutorizacaoFisioterapia = value
        End Set
    End Property
    Public Property BonusUtilizados365d() As Integer
        Get
            BonusUtilizados365d = IntBonusUtilizados365d
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property BonusUtilizados30d() As Integer
        Get
            BonusUtilizados30d = IntBonusUtilizados30d
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property ExcedenteUtilizados() As Integer
        Get
            ExcedenteUtilizados = IntExcedenteUtilizados
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property ProximaConsulta() As String
        Get
            ProximaConsulta = StrProximaConsulta
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Retorno() As String
        Get
            Retorno = StrRetorno
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Situacao() As String
        Get
            Situacao = StrSituacao
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Imagem() As String
        Get
            Imagem = StrImage
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Function CarregaEstatisticas(ByVal _Prestador As ClsMedico) As Boolean

        CarregaEstatisticas = False
        If StrMatricula = "" Then Exit Function

        If _PG.Conectar() = False Then GoTo Fim_Bloco
        Try
            IntConsultasMedicasRealizadas = 0
            IntConsultasMedicasRealizadasBebes = 0
            IntConsultasOdontologicasRealizadas = 0
            IntFisioterapiasRealizadas = 0
            IntAutorizacoesEmAberto = 0
            IdAutorizacaoFisioterapia = 0
            IntBonusUtilizados365d = 0
            IntBonusUtilizados30d = 0
            IntExcedenteUtilizados = 0
            StrProximaConsulta = ""

            IntConsultasMedicasRealizadas = _PG.RecordCount(_toolsSiFam.ObtemConsultas(StrMatricula, "CM", _setup.prazo_de_pesquisa_atendimentos_medicos, 0))
            IntConsultasMedicasRealizadasBebes = _PG.RecordCount(_toolsSiFam.ObtemConsultas(StrMatricula, "BB", _setup.prazo_de_pesquisa_atendimentos_medicos, 0))
            ' bebes tem 1 consulta mes de bonus
            If IntConsultasMedicasRealizadasBebes > 0 Then IntConsultasMedicasRealizadas -= 1
            If IntConsultasMedicasRealizadas > 0 Then StrRetorno &= "Consultas médicas últimos " & _setup.prazo_de_pesquisa_atendimentos_medicos & " dias: " & IntConsultasMedicasRealizadas & Chr(13)
            If IntConsultasMedicasRealizadasBebes > 0 Then StrRetorno &= " (" & IntConsultasMedicasRealizadasBebes & " à bebê)" & Chr(13)

            If _Prestador.Dentista Then
                IntConsultasOdontologicasRealizadas = _PG.RecordCount(_toolsSiFam.ObtemConsultas(StrMatricula, "CO", _setup.prazo_de_pesquisa_atendimentos_dentistas, 0))
                If IntConsultasOdontologicasRealizadas > 0 Then StrRetorno &= "Consultas odontológicas últimos " & _setup.prazo_de_pesquisa_atendimentos_medicos & " dias: " & IntConsultasOdontologicasRealizadas & Chr(13)
            End If
            If _Prestador.Nutricionista Then
                ' especialidade=18
                IntConsultasNutricionistaRealizadas = _PG.RecordCount(_toolsSiFam.ObtemConsultas(StrMatricula, "CN", _setup.prazo_de_pesquisa_atendimentos_medicos, 0))
                If IntConsultasNutricionistaRealizadas > 0 Then StrRetorno &= "Consultas nutricionistas últimos " & _setup.prazo_de_pesquisa_atendimentos_medicos & " dias: " & IntConsultasNutricionistaRealizadas & Chr(13)
            End If

            IntBonusUtilizados365d = _PG.RecordCount(_toolsSiFam.ObtemBonus(StrMatricula, _setup.prazo_de_pesquisa_bonus))
            IntBonusUtilizados30d = _PG.RecordCount(_toolsSiFam.ObtemBonus(StrMatricula, 30))
            IntExcedenteUtilizados = _PG.RecordCount(_toolsSiFam.ObtemExcedente(StrMatricula, _setup.prazo_de_pesquisa_excedentes))
            If IntBonusUtilizados365d > 0 Then StrRetorno &= "Bônus utilizados, últimos " & _setup.prazo_de_pesquisa_bonus & " dias: " & IntBonusUtilizados365d & ", últimos 30 dias:" & IntBonusUtilizados30d & Chr(13)
            If IntExcedenteUtilizados > 0 Then StrRetorno &= "Excedentes utilizados: " & IntExcedenteUtilizados & Chr(13)

            If StrProximaConsulta <> "" Then StrRetorno &= "Liberação próxima consulta: " & StrProximaConsulta & Chr(13)
            If IntConsultasMedicasRealizadas = 0 And IntConsultasOdontologicasRealizadas = 0 And IntBonusUtilizados365d = 0 And IntExcedenteUtilizados = 0 Then StrRetorno &= "Nenhuma consulta nos últimos 30 dias." & Chr(13)
            If BolLiberaUsoPorSenha And SenhaDaPessoaNoBanco <> "" Then StrRetorno &= "Validade da senha: " & Format(DataSenhaPessoa.AddDays(180), "dd/MM/yyyy") & Chr(13)

            If _Prestador.Fisioterapeuta Then
                IntFisioterapiasRealizadas = 0
                IntAutorizacoesEmAberto = 0
                IdAutorizacaoFisioterapia = 0
                If oMedicoConveniado.Fisioterapeuta Or oMedicoConveniado.Especialidade = 10 Or oMedicoConveniado.Especialidade2 = 10 Then
                    ' consulta fisioterapeuta cd 16981, especialidade=34, não é médico,   valor 15,56
                    ' consulta fisiatra       cd 1,     especialidade 10, médico fisiatra, valor 55,00 

                    ' nova procedimento com autorizacao em maio de 2021
                    ' vou localizar se o paciente tem autorizações em aberto, só se tiver poderá registrar consulta, que agora é a sessão de fsioterapia.
                    ' autoriacao esta na nova tabela de autorizacoes, compartilada com outros tipo de servicos
                    drGeneric = _PG.DrQuery("SELECT id_atendimento_autorizacao, codigo_procedimento, sessoes_autorizadas,sessoes_realizadas,situacao FROM atendimento_autorizacao WHERE situacao <>'C' and sessoes_realizadas < sessoes_autorizadas and id_pessoa=" & IdPessoa)
                    If drGeneric.HasRows Then
                        While drGeneric.Read()
                            StrRetorno &= "   Aut. N. " & drGeneric.Item("id_atendimento_autorizacao") & " " & drGeneric.Item("situacao") & ", CID10 " & Trim(drGeneric.Item("codigo_procedimento")) & ", saldo: " & drGeneric.Item("sessoes_autorizadas") - drGeneric.Item("sessoes_realizadas") & " sessões." & Chr(13)
                            IdAutorizacaoFisioterapia = drGeneric.Item("id_atendimento_autorizacao")
                            IntAutorizacoesEmAberto += 1
                            IntFisioterapiasRealizadas += drGeneric.Item("sessoes_autorizadas") - drGeneric.Item("sessoes_realizadas")
                        End While
                    End If
                End If
            End If

            If IntConsultasMedicasRealizadas >= 2 Then
                drGeneric = _PG.DrQuery(_toolsSiFam.ObtemProximaConsultaLiberada(StrMatricula))
                If drGeneric.HasRows Then
                    drGeneric.Read()
                    StrProximaConsulta = drGeneric.Item(0)
                End If
            End If

            If _Prestador.Modo = 5 Then
                CoberturaDisponivel(_Prestador)
            End If
        Catch ex As Exception
            MsgBox("Erro: " + ex.Message)
        End Try
        CarregaEstatisticas = True
Fim_Bloco:
        _PG.Desconectar()

    End Function

    Public Function VerificaAtendimentosPendentes(ByVal cmbProcedimento As ComboBox, PiPrestador As Integer) As Long
        VerificaAtendimentosPendentes = 0
        StrRetorno = ""
        Dim vdDataServidor As Date = _PG.DataServidor
        If _PG.Conectar() = False Then Exit Function

        Dim IntQuantidadePendentes As Long

        drGeneric = _PG.DrQuery("SELECT count(*) FROM atendimento a left join atendimento_servico ats on a.id_atendimento=ats.id_atendimento WHERE a.situacao='P' and id_pessoa=" & IdPessoa & " and id_medico=" & PiPrestador)
        If drGeneric.HasRows Then
            drGeneric.Read()
            IntQuantidadePendentes = drGeneric.Item(0)
        End If
        If IntQuantidadePendentes > 0 Then
            If IntQuantidadePendentes > 1 Then
                IntQuantidadePendentes = Val(InputBox("Informe o atendimento que deseja concluir:"))
                ' If IntQuantidadePendentes = 0 Then
                '     If MsgBox("Deseja prosseguir sem encerrar os atendimentos pendentes ?", vbYesNo) = vbNo Then GoTo Fim_Bloco
                ' End If
                If IntQuantidadePendentes = 0 Then GoTo Fim_Bloco

                If _PG.Conn.State = 0 Then If _PG.Conectar() = False Then Exit Function
                drGeneric = _PG.DrQuery("SELECT a.id_atendimento, id_servico, ats.valor, a.dt_alteracao FROM atendimento a left join atendimento_servico ats on a.id_atendimento=ats.id_atendimento WHERE a.situacao='P' and id_pessoa=" & IdPessoa & " and id_medico=" & PiPrestador & " and a.id_atendimento=" & IntQuantidadePendentes)
                If drGeneric.HasRows = False Then MsgBox("Atendimento não localizado!") : GoTo Fim_Bloco
            Else
                drGeneric = _PG.DrQuery("SELECT a.id_atendimento, id_servico, ats.valor, a.dt_alteracao FROM atendimento a left join atendimento_servico ats on a.id_atendimento=ats.id_atendimento WHERE a.situacao='P' and id_pessoa=" & IdPessoa & " and id_medico=" & PiPrestador)
            End If
            If drGeneric.HasRows Then
                drGeneric.Read()
                If MsgBox("Localizado o atendimento N. " & drGeneric.Item("id_atendimento") & " pendente para a pessoa selecionada! Deseja encerrá-lo agora ?", vbYesNo) = vbYes Then
                    ' vai marca para rotina de gravacao que já existe um lancamento e que este precisa ser fechado
                    VerificaAtendimentosPendentes = drGeneric.Item("id_atendimento")
                    If IsDBNull(drGeneric.Item("id_servico")) = False Then
                        'BolCarregandoCombo = True
                        For i = 0 To cmbProcedimento.Items.Count - 1
                            If cmbProcedimento.Items(i).id = drGeneric.Item("id_servico") Then
                                cmbProcedimento.SelectedIndex = i
                                Exit For
                            End If
                            ' sistema abaixo fica a cada posicionamento vai ate´o change do combo
                            'cmbProcedimento.SelectedIndex = i
                            'If CType(cmbProcedimento.SelectedItem, ComboData).Id = drGeneric.Item("id_servico") Then Exit For
                        Next
                        ' cmbProcedimento.Enabled = False ao encerrar atendimento, vai poder retornar e alterar para urgente e nao urgente
                        'BolCarregandoCombo = False
                        'mskValor.Text = drGeneric.Item(2)
                        'mskValor.Enabled = False
                    End If
                Else
                    ' permite digitar outra consulta
                    ' tem direito a retorno em 48h ou seja, nao pode registrar outro atendimento em 24hs
                    ' se a data da pendencia for meno que 48h nao pode registrar atendimento --> 48hs
                    If Int(DateDiff("h", drGeneric.Item("dt_alteracao"), vdDataServidor)) < 48 Then
                        MsgBox("Existe um atendimento a menos de 48hs para o paciente informado, portanto, qualquer atendimento neste período é considerado RETORNO e não pode ser registrado como novo atendimento.")
                        VerificaAtendimentosPendentes = 9
                    End If
                End If
            End If
        Else
            drGeneric = _PG.DrQuery("SELECT dt_alteracao, id_atendimento FROM atendimento a WHERE a.situacao='A' and id_pessoa=" & IdPessoa & " and id_medico=" & PiPrestador & " order by dt_alteracao desc Limit 1")
            If drGeneric.HasRows Then
                drGeneric.Read()
                ' permite digitar outra consulta
                ' tem direito a retorno em 24h ou seja, nao pode registrar outro atendimento em 24hs
                ' se a data da pendencia for meno que 24hs nao pode registrar atendimento --> 48hs
                ' MsgBox(DateDiff("h", #6/10/2022 08:00:00 AM#, #6/12/2022 07:01:00 AM#))


                If Int(DateDiff("h", drGeneric.Item("dt_alteracao"), vdDataServidor)) < 48 Then
                    If MsgBox("Existe um atendimento (" & drGeneric.Item("id_atendimento") & ") a menos de 48hs para o paciente informado, portanto, qualquer atendimento neste período é considerado RETORNO e não pode ser registrado como novo atendimento." & Chr(13) & "Deseja informar apenas despesas extras ?", vbYesNo) = vbYes Then
                        VerificaAtendimentosPendentes = 1
                    Else
                        VerificaAtendimentosPendentes = 9
                    End If
                End If
            End If
        End If
Fim_Bloco:
        _PG.Desconectar()

    End Function

    Public Function CoberturaDisponivel(_Prestador As ClsMedico) As Boolean

        ' em desenvolvimento   29/04/2022

        CoberturaDisponivel = False
        vnTotalDisponivelCobertura = 0

        Dim vnLimiteConsignacao As Decimal = 0
        Dim vnPortentagemHospital As Decimal = 0
        Dim vnPortentagemConsultorio As Decimal = 0
        Dim vnPrazoEmMeses As Decimal = 0

        DsGeneric = _PG.DsQuery("Select limite_consignado, hospital_porcentagem, consultorio_porcentagem, meses from valores ")
        If DsGeneric.Tables(0).Rows.Count > 0 Then
            vnLimiteConsignacao = DsGeneric.Tables(0).Rows(0).Item(0)
            vnPortentagemHospital = DsGeneric.Tables(0).Rows(0).Item(1)
            vnPortentagemConsultorio = DsGeneric.Tables(0).Rows(0).Item(2)
            vnPrazoEmMeses = DsGeneric.Tables(0).Rows(0).Item(3)
        End If

        '$query->exec("select p.id_pessoa,d.data_inicio from pessoas as p 
        'LEFT JOIN data_inicio_consignacao as d on p.id_pessoa=d.id_pessoa 
        'WHERE p.matricula='".$form_matricula."' and p.id_tipo_usuario=2  
        'order by d.data_inicio desc limit 1");
        '    $query->proximo();

        '   $id_pessoa=$query->record[0];
        '   $dt_inicio=$query->record[1];

        '  $dt_teste=retornaDataBd(SomarData(retornadata($dt_inicio), 0, 0, 1));
        '  $dt_teste2=retornadatabd(date('d/m/Y',mktime(0,0,0,date('m'),date('d'),date('Y')-1)));


        ' //testa se ja existe uma data inicial do prazo para renovar o limite de gastos, se exite ele testa se essa data ainda é valida
        ' if($dt_inicio=='' or $dt_inicio > $dt_teste or $dt_inicio < $dt_teste2){
        ' //se nao exitir data ou se a data ja tiver vencido, ele busca a menor data valida e insere como novo prazo na respctiva tabela
        ' $query->exec("select ar.dt_baixa from ambulatorial_retorno as ar, pessoas as p, ambulatorial as a where p.matricula='".$form_matricula."' and  a.id_ambulatorial=ar.id_ambulatorial_origem and a.id_pessoa=p.id_pessoa
        ' union
        'select hr.dt_baixa from hospitalar_retorno as hr, pessoas as p, hospitalar as h where p.matricula='".$form_matricula."'  and  h.id_hospitalar=hr.id_hospitalar_origem and h.id_pessoa=p.id_pessoa order by 1 desc limit 1");
        '$query->proximo();
        '$n=$query->rows();
        '    if($n==0){
        '      echo callException("Ainda não foram cadastrados atendimentos para esta matrícula!", 2);
        '      exit;
        '    }else{
        '      $dt_inicio=$query->record[0];
        '      $dt_teste=retornaDataBd(SomarData(retornadata($dt_inicio), 0, 0, 1));
        '      $query->insertTupla('data_inicio_consignacao', array($id_pessoa,$dt_inicio));
        '    }
        '}

        ' rotina deve somar todos atendimentos que utilizam limite de cobertura hospitalar nos ultimos 365 dias
        ' tem de juntar tabela hospitalar (velha) com novos registros (Atendimento, onde produto com hospitalar=true)
        Dim vsDataDaConsulta As String = " And h.dt_alteracao>=CURRENT_DATE-365"

        Dim StrMensagem As String = "Nenhuma Despesa Hospitalar foi localizada nos últimos 365 dias."
        vnTotalDespesasHospitalares = 0

        Dim StrQuery As String = "select  sum(hr.medico_valor+hr.juridica_valor) from hospitalar as h, 
                    prestador as j, prestador as m, hospitalar_retorno as hr, pessoas as p 
          where h.matricula='" & StrMatricula & "' and hr.id_hospitalar_origem=h.id_hospitalar and h.id_juridica=j.id_prestador and
          h.id_medicos=m.id_prestador " & vsDataDaConsulta & " and p.id_pessoa=h.id_pessoa"

        StrQuery &= " union select sum(ats.valor) from atendimento as h inner join atendimento_servico ats using(id_atendimento) inner join servico s using(id_servico)
                    inner join pessoas using (id_pessoa) where s.hospital=1 and matricula='" & StrMatricula & "'" & vsDataDaConsulta
        Try
            DsGeneric = _PG.DsQuery(StrQuery)
            If DsGeneric.Tables(0).Rows.Count > 0 Then
                If IsDBNull(DsGeneric.Tables(0).Rows(0).Item(0)) = False Then
                    For i = 0 To DsGeneric.Tables(0).Rows.Count - 1
                        vnTotalDespesasHospitalares += DsGeneric.Tables(0).Rows(0).Item(0)
                    Next
                    If vnTotalDespesasHospitalares > 0 Then
                        ' se item é maior que ZERO é por que existe uma consulta nos ultimos 15dias e nao pode fazer, alias bonus ou excedente.
                        If DsGeneric.Tables(0).Rows(0).Item(0) > 0 Then
                            StrMensagem &= "Despesas hospitalares utilizadas (365d): R$" & vnTotalDespesasHospitalares & Chr(13)
                            StrMensagem &= "Saldo hospitalar disponivel : R$" & vnLimiteConsignacao - vnTotalDespesasHospitalares & Chr(13)
                        End If

                    End If
                End If
            End If
            StrRetorno &= StrMensagem
        Catch ex As Exception
            StrRetorno &= "Pesquisa Despesa Hospitalar: " & ex.Message
        End Try

Fim_OK:
        CoberturaDisponivel = True

    End Function

End Class
