Imports Microsoft.VisualBasic
Imports System.IO

Module Relatorios
    Public vsHTMLStyle As String = "<STYLE type=text/css>" & _
                            "   U {font-size:9pt;font-family:'times new roman, verdana, helvetica';}" & _
                            "   TD {font-size:9pt;font-family:'times new roman, verdana, helvetica';}" & _
                            "   TD.cab {background-color:#D3D3D3; text-align:center;font-size:9pt;font-family:'times new roman, verdana, helvetica';}" & _
                            "</STYLE>"
    ' D3D3D3 fundo cinza
    dim drGeneric As Npgsql.NpgsqlDataReader

    private function CabecalhoHTML() As String
        CabecalhoHTML = "<HTML><head><title>PREVPEL - " & frmMain.Text & "</title><meta http-equiv='Content-Type' content='1text/html; charset=utf-8'>" & vsHTMLStyle & "</head>"
    End Function

    Public Function RelatorioFisioterapiasRealizadasPaciente(ByVal idPaciente As Long, ByVal idMedico As Long, ByVal NomeMedico As String, ByVal vsMatricula As String, ByVal vsFiltro As String, ByVal vsFiltroTexto As String) As Boolean
        RelatorioFisioterapiasRealizadasPaciente = False
        If idPaciente = 0 Then MsgBox("Selecione um Paciente", vbInformation, "Paciente Inválido") : Exit Function
        If _PG.Conectar = False Then Exit Function

        drGeneric = _PG.DrQuery("SELECT id_pessoa as Codigo, to_ascii(nome,'LATIN1') as Nome, matricula FROM pessoas WHERE id_tipo_usuario=2 and matricula = '" & vsMatricula & "'")
        drGeneric.Read()
        Dim vsTitular As String = Trim(drGeneric.Item(1))
        Dim idTitular As String = drGeneric.Item(0)
        drGeneric = _PG.DrQuery("SELECT id_pessoa as Codigo, to_ascii(nome,'LATIN1') as Nome, matricula FROM pessoas WHERE id_pessoa=" & idPaciente)
        drGeneric.Read()
        vsFiltroTexto = "Paciente: <b>" & Trim(drGeneric.Item(1)) & ", Mat. " & drGeneric.Item(2) & "</b><br>Fisioterapeuta: <b>" & NomeMedico & "</b>"

        Dim vnContaPacotes As Long = 0
        Dim vnSessoesAutorizadas As Long = 0
        Dim vsChaveAux As String = ""
        Dim Arq1 As IO.StreamWriter                               'Classe de leitura de arquivos (txt)
        Dim dr As Npgsql.NpgsqlDataReader
        'dr = _PG.drQuery("SELECT count(*) FROM fisioterapia_sessoes WHERE id_pessoa=" & drGeneric.Item(0) & " and id_requisitante=" & vnGlo_idPaciente & " and id_medicos=" & idMedico & " group by dt_cadastro")
        'If dr.HasRows Then vnContaPacotes = dr.Item(0)
        dr = _PG.DrQuery("SELECT a.id_atendimento, a.autorizacao, sessoes_autorizadas, a.dt_alteracao, a.hr_alteracao FROM atendimento a left join atendimento_autorizacao on autorizacao=id_atendimento_autorizacao WHERE a.situacao<>'C' and tipo='F' and a.id_pessoa=" & idPaciente & " and a.id_medico=" & idMedico & " order by autorizacao, a.id_atendimento  ")
        If dr.HasRows Then
            'Arq1 = New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\RelatorioConsultas.htm", False)
            Arq1 = New IO.StreamWriter(System.IO.Path.GetTempPath() & "FisioterapiaPaciente.htm", False)
            Try
                Arq1.WriteLine(CabecalhoHTML)
                Arq1.WriteLine("<BODY><H4>Consulta de Autorizações e Sessoes de Fisioterapia </h4>")
                If vsFiltroTexto <> "" Then Arq1.WriteLine("Filtro: " & vsFiltroTexto)
                Arq1.WriteLine("<TABLE border=1 cellspacing=0 cellpadding=0><TR>")
                Dim viContador As Integer = 0
                While dr.Read
                    viContador = viContador + 1
                    Arq1.Write("<TR>")
                    If vsChaveAux <> (dr.Item("autorizacao").ToString) Then
                        vsChaveAux = dr.Item("autorizacao").ToString
                        vnContaPacotes = vnContaPacotes + 1
                        vnSessoesAutorizadas += dr.Item("sessoes_autorizadas")
                        Arq1.WriteLine("<TH>Id da Sessão<TH> Autorização <TH> Realizacao da Sessao<TR>")
                    End If
                    Arq1.Write("<TD align=center width=100> " & dr.Item(0))
                    Arq1.Write("<TD align=center width=200> N. " & dr.Item("autorizacao") & " ( " & dr.Item("sessoes_autorizadas") & " sessões )")
                    Arq1.Write("<TD align=center width=200>" & Format(dr.Item("dt_alteracao"), "dd/MM/yyyy") & " - " & Trim(dr.Item("hr_alteracao")).ToString)
                End While
                Arq1.WriteLine("<TR><TD colspan=3>")
                Arq1.WriteLine("<TR><TD colspan=3 align=right><B>Total de autorizações existentes : " & Format(vnContaPacotes, "000"))
                Arq1.WriteLine("<TR><TD colspan=3 align=right><B>Total de sessoes autorizadas : " & Format(vnSessoesAutorizadas, "000"))
                Arq1.WriteLine("<TR><TD colspan=3 bgcolor=cyan   align=right><B>Total de sessoes realizadas : " & Format(viContador, "000"))
                Arq1.WriteLine("<TR><TD colspan=3 bgcolor=yellow align=right><B>Total de sessoes não realizadas : " & Format(vnSessoesAutorizadas - viContador, "000"))
                Arq1.WriteLine("</table>")

                RelatorioFisioterapiasRealizadasPaciente = True
            Catch ex As Exception
                MsgBox("Erro ao gerar relatório : " & ex.ToString())
            End Try
            Arq1.Close()
        Else
            MsgBox("Nenhuma registro de sessão foi encontrado.", vbInformation, "Sessões não localizadas")
        End If
        _PG.Desconectar()
    End Function

    Public Function RegistroPacotes(ByVal idMedico As Long, ByVal vsMatricula As String, ByVal vsFiltro As String, ByVal vsFiltroTexto As String) As Boolean
        RegistroPacotes = False
        If _PG.Conectar = False Then Exit Function
        Dim vnContaLinhas As Long
        Dim vnContaPacotes As Integer
        Dim vsChaveAux As Long
        Dim Arq1 As IO.StreamWriter                               'Classe de leitura de arquivos (txt)
        Dim dr As Npgsql.NpgsqlDataReader
        If idMedico > 0 Then vsFiltro &= " and au.id_prestador=" & idMedico
        dr = _PG.DrQuery("SELECT to_char(au.dt_alteracao , 'dd/mm/yyyy hh:MM')::text as data_autorizacao, to_ascii(nome,'LATIN1')as nome, p.matricula,sessoes_autorizadas, id_atendimento_autorizacao, a.dt_alteracao, a.hr_alteracao, a.situacao,id_atendimento FROM atendimento_autorizacao au left join atendimento a on autorizacao=id_atendimento_autorizacao left join pessoas p on p.id_pessoa=au.id_pessoa WHERE " & vsFiltro & " order by au.id_atendimento_autorizacao, id_atendimento  ")
        If dr.HasRows Then
            'Arq1 = New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\RelatorioConsultas.htm", False)
            Arq1 = New IO.StreamWriter(System.IO.Path.GetTempPath() & "RegistroAutorizacoes.htm", False)
            Try
                Arq1.WriteLine(CabecalhoHTML)
                Arq1.WriteLine("<BODY><H4>Registro de Autorizações de Fisioterapia</h4>")
                If vsFiltroTexto <> "" Then Arq1.WriteLine("<B>" & vsFiltroTexto & "</b>")
                Arq1.WriteLine("<TABLE border=1 cellspacing=0 cellpadding=0>")
                Arq1.WriteLine("<TR bgcolor=d3d3d3><Td> Data da Autorização <Td> Paciente <Td> Matricula <Td> Id da Sessão <Td> Realização da Sessão <Td> Situação")
                Dim viContador As Integer = 0
                vnContaPacotes += 1
                Dim vnSessoesAutorizadas As Long

                While dr.Read
                    viContador = viContador + 1
                    If viContador = 1 Then vnSessoesAutorizadas += dr.Item("sessoes_autorizadas")
                    If vsChaveAux <> dr.Item("id_atendimento_autorizacao") And viContador > 1 Then
                        vsChaveAux = dr.Item("id_atendimento_autorizacao")
                        vnContaPacotes += 1
                        vnSessoesAutorizadas += dr.Item("sessoes_autorizadas")
                    End If
                    Arq1.Write("<TR>")
                    Arq1.Write("<TD align=center>" & dr.Item("data_autorizacao") & ", N. " & dr.Item("id_atendimento_autorizacao"))
                    Arq1.Write("<TD width=280>" & Trim(dr.Item("nome")) & "<TD align=center>" & dr.Item("matricula"))
                    If IsDBNull(dr.Item("dt_alteracao")) = False Then
                        Arq1.Write("<TD align=center width=100>" & dr.Item("id_atendimento"))
                        Arq1.Write("<TD align=center>" & Format(dr.Item("dt_alteracao"), "dd/MM/yyyy") & " - " & Trim(dr.Item("hr_alteracao").ToString))
                        Arq1.Write("<TD align=center width=100>" & IIf(dr.Item("situacao").ToString = "P", "pendente", IIf(dr.Item("situacao").ToString = "C", "Cancelada", "realizada")))
                        If dr.Item("situacao").ToString <> "C" And dr.Item("situacao").ToString <> "P" Then vnContaLinhas += 1
                    Else
                        Arq1.Write("<TD align=center width=100>")
                        Arq1.Write("<TD align=center>")
                        Arq1.Write("<TD align=center width=100>")
                    End If
                End While
                Arq1.WriteLine("</table>")
                Arq1.WriteLine("Total de Pacotes existentes : " & vnContaPacotes & ", com total de " & vnSessoesAutorizadas & " sessoes.<BR>")
                Arq1.WriteLine("Total de Sessoes realizadas : " & vnContaLinhas & "<BR>")
                Arq1.WriteLine("Total de Sessoes em aberto  : <B>" & vnSessoesAutorizadas - vnContaLinhas & "<BR>")
                RegistroPacotes = True
            Catch ex As Exception
                MsgBox("Erro ao gerar relatório : " & ex.ToString())
            End Try
            Arq1.Close()
        Else
            MsgBox("Nenhuma Sessão foi encontrada no período especificado.")
        End If
        _PG.Desconectar()
    End Function

    Public Function ResumoPacotes(ByVal idMedico As Long, ByVal vsMatricula As String, ByVal vsFiltro As String, ByVal vsFiltroTexto As String) As Boolean
        ResumoPacotes = False
        If _PG.Conectar = False Then Exit Function
        Dim vnContaLinhas As Long = 0
        Dim vnSessoesRealizadas As Integer
        Dim vnSessoesRealizadasFora As Integer
        Dim streamOutput As IO.StreamWriter                               'Classe de leitura de arquivos (txt)
        Dim dr As Npgsql.NpgsqlDataReader
        Dim vnContaPacotesAbertos As Integer = 0
        Dim vnTotalizaSaldo As Integer = 0
        Dim vnTotalizaSessoes As Integer = 0
        Dim vsFiltroFora As String

        'vsFiltro = Replace(vsFiltro, "fs.dt_cadastro", "fs1.dt_realizada")
        'vsSessoesRealizadas = "SELECT count(*) as sessoes_realizadas FROM fisioterapia_sessoes as fs1 WHERE realizada='S' and fs1.id_medicos=" & idMedico & " and fs1.id_requisitante=fs.id_requisitante and  fs.hr_cadastro=fs1.hr_cadastro and " & vsFiltro

        vsFiltroFora = vsFiltro
        vsFiltroFora = Replace(vsFiltroFora, ">=", "<")
        vsFiltroFora = Replace(vsFiltroFora, "<=", ">")
        vsFiltroFora = Replace(vsFiltroFora, "and", "or")
        If _PG.Conectar = False Then Exit Function

        dr = _PG.DrQuery("SELECT to_char(au.dt_alteracao , 'dd/mm/yyyy hh:MM')::text as data_autorizacao, to_ascii(nome,'LATIN1') as nome, p.matricula,sessoes_autorizadas, sessoes_realizadas, id_atendimento_autorizacao, codigo_procedimento FROM atendimento_autorizacao au left join pessoas p on p.id_pessoa=au.id_pessoa WHERE " & vsFiltro & " and au.id_prestador=" & idMedico & " and (au.situacao<>'C'or au.situacao<>'N') order by au.id_atendimento_autorizacao  ")

        If dr.HasRows Then
            'streamOutput = New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\RelatorioConsultas.htm", False)
            streamOutput = New IO.StreamWriter(System.IO.Path.GetTempPath() & "ResumoAutorizacoes.htm", False)
            Try
                streamOutput.WriteLine(CabecalhoHTML)
                streamOutput.WriteLine("<BODY><H4>Resumo de Autorizações de Fisioterapia </h4>")
                If vsFiltroTexto <> "" Then streamOutput.WriteLine("<B>" & vsFiltroTexto & ".</b>")
                streamOutput.WriteLine("<TABLE border=1 cellspacing=0 cellpadding=1><TR>")
                streamOutput.WriteLine("<Td class=cab> Cadastro da Autorização<Td class=cab> Paciente <Td class=cab> Matricula <Td class=cab> Sessões Autorizadas <Td class=cab> Sessões Realizadas<Td class=cab> Saldo")
                Dim viContador As Integer = 0

                While dr.Read
                    streamOutput.Write("<TR>")
                    streamOutput.Write("<TD>" & dr.Item("data_autorizacao") & " - " & dr.Item("id_atendimento_autorizacao") & " - CID10 " & dr.Item("codigo_procedimento"))
                    streamOutput.Write("<TD width=200>" & dr.Item("nome") & "<TD align=center>" & dr.Item("matricula"))
                    streamOutput.Write("<TD align=center >" & dr.Item("sessoes_autorizadas"))
                    vnTotalizaSessoes = vnTotalizaSessoes + dr.Item("sessoes_autorizadas")

                    ' vnSessoesRealizadasFora = Val(dr.Item("ForaPeriodo").ToString)
                    vnSessoesRealizadas = Val(dr.Item("sessoes_realizadas").ToString)
                    streamOutput.Write("<TD align=center>" & vnSessoesRealizadas)
                    vnContaLinhas = vnContaLinhas + vnSessoesRealizadas
                    If dr.Item("sessoes_autorizadas") - vnSessoesRealizadas > 0 Then
                        vnContaPacotesAbertos = vnContaPacotesAbertos + 1
                        streamOutput.Write("<TD align=center>" & dr.Item("sessoes_autorizadas") - vnSessoesRealizadasFora - vnSessoesRealizadas)
                    Else
                        streamOutput.Write("<TD align=center>Finalizado")
                    End If

                    vnTotalizaSaldo = vnTotalizaSaldo + dr.Item("sessoes_autorizadas") - vnSessoesRealizadas

                End While

                streamOutput.Write("<TR>")
                streamOutput.Write("<TD>")
                streamOutput.Write("<TD>")
                streamOutput.Write("<TD>")
                streamOutput.Write("<TD align=center>" & vnTotalizaSessoes)
                streamOutput.Write("<TD align=center>" & vnContaLinhas)
                streamOutput.Write("<TD align=center>" & vnTotalizaSaldo)

                streamOutput.WriteLine("</table>")

                dr = _PG.DrQuery("SELECT count(*) FROM atendimento_autorizacao au WHERE au.id_prestador=" & idMedico & " and " & vsFiltro)
                If dr.HasRows Then dr.Read()
                streamOutput.WriteLine("Novas Autorizações no período : " & dr.Item(0) & "<BR>")
                streamOutput.WriteLine("Total de Autorizações em aberto  : <B>" & vnContaPacotesAbertos & "<BR>")
                ResumoPacotes = True
            Catch ex As Exception
                MsgBox("Erro ao gerar relatório : " & ex.ToString())
            End Try
            streamOutput.Close()
        Else
            MsgBox("Nenhuma Sessão foi encontrada no período especificado.")
        End If
        _PG.Desconectar()
    End Function

    Public Function RelatorioAcessosRealizados(ByVal idMedico As Long, ByVal vsFiltro As String, ByVal vsFiltroTexto As String) As Boolean
        RelatorioAcessosRealizados = False
        Dim vnRelatorio As Integer
        Dim vsResultado As String, vnOrdem As Integer
        Dim streamOutput As IO.StreamWriter    'Classe de leitura de arquivos (txt)

        vsResultado = InputBox("Informe o tipo de acesso a exibir: 1-por senha, 2-por digital, 3-sem acesso.", "Relatório de Contribuintes por Tipo de Acessos", 1)
        vnRelatorio = Val(vsResultado)
        If vnRelatorio = 0 Or vnRelatorio > 3 Then Exit Function
        If vnRelatorio = 1 Then vsFiltro = " senha <> '' group by pessoas.id_pessoa, nome, matricula "
        If vnRelatorio = 2 Then vsFiltro = " senha = '' group by pessoas.id_pessoa, nome, matricula HAVING COUNT(id_digital)  > 0 "
        If vnRelatorio = 3 Then vsFiltro = " senha = '' group by pessoas.id_pessoa, nome, matricula HAVING COUNT(id_digital)  = 0 "

        vsResultado = InputBox("Informe o tipo de Ordenacao para o relatório: 1-por Matricula, 2-por Nome.", "Relatório de Contribuintes por Tipo de Acessos", 2)
        vnOrdem = Val(vsResultado)
        If vnOrdem = 1 Then vsFiltro = vsFiltro & " order by matricula "
        If vnOrdem = 2 Then vsFiltro = vsFiltro & " order by nome "
        'If vnOrdem = 3 Then vsFiltro = vsFiltro & " order by dt_alteracao "

        If _PG.Conectar = False Then Exit Function
        Dim dr As Npgsql.NpgsqlDataReader
        Dim drGeneric As Npgsql.NpgsqlDataReader
        Dim vnContaLinhas As Long = 0

        dr = _PG.DrQuery(" SELECT pessoas.id_pessoa,  to_ascii(nome,'LATIN1') as nome, matricula, COUNT(id_digital) as total FROM pessoas " &
                             " LEFT JOIN digital USING(id_pessoa) " &
                             " WHERE " & vsFiltro)
        If dr.HasRows Then
            streamOutput = New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\RelatorioContribuintesPorTipoAcesso.htm", False)
            Try
                streamOutput.WriteLine(CabecalhoHTML)
                streamOutput.WriteLine("<BODY><H4>Relatorio de Contribuintes por Tipo de Acesso </h4>")
                If vnRelatorio = 1 Then streamOutput.WriteLine("Filtro: Contribuintes com acesso por Senha")
                If vnRelatorio = 2 Then streamOutput.WriteLine("Filtro: Contribuintes com acesso por Digital")
                If vnRelatorio = 3 Then streamOutput.WriteLine("Filtro: Contribuintes sem acesso ")
                streamOutput.WriteLine("<TABLE border=1 width=700><TR><TH width=380>Contribuinte<TH>Matricula")
                If vnRelatorio = 2 Then streamOutput.WriteLine("<TH>Numero de Digitais<TH>Ultima Atualizacao")

                While dr.Read
                    streamOutput.Write("<TR><TD width=70%>" & Trim(dr.Item(1).ToString) & "<TD>" & Trim(dr.Item(2).ToString))
                    vnContaLinhas = vnContaLinhas + 1
                    If vnRelatorio = 2 Then
                        drGeneric = _PG.DrQuery(" SELECT dt_alteracao FROM digital where id_pessoa=" & dr.Item(0).ToString & " order by dt_alteracao desc")
                        If drGeneric.HasRows Then
                            streamOutput.WriteLine("<TD align=center>" & dr.Item(3).ToString & "<TD>" & Format(Convert.ToDateTime(drGeneric.Item(0).ToString), "dd/MM/yyyy"))
                        Else
                            streamOutput.WriteLine("<TD align=center>" & dr.Item(3).ToString & "<TD>&nbsp;")
                        End If
                    End If
                End While
                streamOutput.WriteLine("</table>")
                streamOutput.WriteLine("Total de Contribuintes listados: " & vnContaLinhas)
                RelatorioAcessosRealizados = True
            Catch ex As Exception
                MsgBox("Erro ao gerar relatório : " & ex.ToString())
            End Try
            streamOutput.Close()
        End If
        _PG.Desconectar()

    End Function

End Module
