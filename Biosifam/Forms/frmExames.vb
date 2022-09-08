Imports Microsoft.VisualBasic

Public Class frmExames
    Dim drExames As System.Data.Odbc.OdbcDataReader
    Dim idExame As Integer
    Dim idExameJuridica As Integer
    Dim vbPrecoJaExiste As Boolean
    Dim _util As New clsUtil

    Private Sub frmExames_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmMain.vbUsuarioSuporte = False Then
            MsgBox("Você não tem acesso a este formulário.")
            Me.Close()
            Me.Hide()
            Exit Sub
        End If

        If _banco.Conecta() = False Then Exit Sub
        drExames = _banco.drQuery("SELECT id_servico, descricao FROM servico where ativo='S' and tipo_servico='EX' order by descricao ")
        If drExames.HasRows Then
            While drExames.Read
                cmbExame.Items.Add(New MeuItemData(drExames.Item(0).ToString, Trim(drExames.Item(1).ToString)))
            End While
        End If
        vbPrecoJaExiste = False
        idExameJuridica = 0
        idExame = 0
        If frmSetup.vsModo = "0" Then Button2.Enabled = True
        _banco.Desconecta()

    End Sub

    Private Sub cmbExame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbExame.SelectedIndexChanged
        idExame = CType(cmbExame.SelectedItem, MeuItemData).Id
        If _banco.Conecta() = False Then Exit Sub
        vbPrecoJaExiste = False
        'drExames = _banco.drQuery("SELECT exame_juridica.valor, id_exame_juridica FROM exame, exame_juridica where exame_juridica.id_exame=exame.id_exame and exame.id_exame =" & idExame)
        drExames = _banco.drQuery("SELECT valor, id_exame FROM exame where id_exame =" & idExame)
        If drExames.HasRows Then
            drExames.Read()
            txtValor.Text = drExames.Item(0).ToString
            idExameJuridica = drExames.Item(1).ToString
            vbPrecoJaExiste = True
        End If
        _banco.Desconecta()

    End Sub

    ' desabilitado
    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Exit Sub

        If idExame = 0 Then MsgBox(" Selecione um Exame !", MsgBoxStyle.Information, "") : Exit Sub
        If txtValor.Text = 0 Then MsgBox(" Informe um Valor !", MsgBoxStyle.Information, "") : Exit Sub
        If _banco.Conecta() = False Then Exit Sub
        If vbPrecoJaExiste = False Then
            _banco.executaQuery("insert into exame_juridica (id_juridica, id_exame, valor, situacao, login, ip, dt_alteracao, hr_alteracao) values (" _
                                & frmSetup.idMedicoP & "," & idExame & ",'" & txtValor.Text & ",'','& vsGlo_UsuarioNome &', '" & _util.ObtemEnderecoIP & "', 'CURRENT_DATE' , '" & Date.Now.ToShortTimeString() & "'")
        Else
            _banco.executaQuery("update exame_juridica set valor='" & Replace(txtValor.Text, ",", ".") & "' where id_exame_juridica=" & idExameJuridica)
        End If
        _banco.Desconecta()
        MsgBox(" Atualização atualizada com sucesso !", MsgBoxStyle.Information, "")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCadastrarExame.Click

        If cmbExame.Text = "" Then MsgBox(" Informe um Exame !", MsgBoxStyle.Information, "") : Exit Sub
        If txtValor.Text > 0 Then MsgBox(" Não Informe Valor neste momento !", MsgBoxStyle.Information, "") : txtValor.Text = 0 : Exit Sub
        If _banco.Conecta() = False Then Exit Sub
        _banco.executaQuery("insert into exame (descricao, valor, ativo, login, ip, dt_alteracao, hr_alteracao) values (" _
                                & "'" & cmbExame.Text & "','" & txtValor.Text & ",'S','& vsGlo_UsuarioNome &', '" & _util.ObtemEnderecoIP & "', 'CURRENT_DATE' , '" & Date.Now.ToShortTimeString() & "'")
        MsgBox(" Novo Exame cadastrado com sucesso !, informe agora o valor e salve a modificação !", MsgBoxStyle.Information, "")

        cmbExame.Items.Clear()
        drExames = _banco.drQuery("SELECT id_exame, descricao FROM exame where ativo='S' order by descricao ")
        If drExames.HasRows Then
            While drExames.Read
                cmbExame.Items.Add(New MeuItemData(drExames.Item(0).ToString, Trim(drExames.Item(1).ToString)))
            End While
        End If

        _banco.Desconecta()
        vbPrecoJaExiste = False
        idExameJuridica = 0
        idExame = 0
    End Sub


    Private Sub btnTodosExame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTodosExame.Click
        Dim vnContaLinhas As Long = 0
        Dim streamOutput As IO.StreamWriter                               'Classe de leitura de arquivos (txt)
        Dim dr As System.Data.Odbc.OdbcDataReader

        If _banco.Conecta() = False Then Exit Sub

        dr = _banco.drQuery(" SELECT descricao, ativo FROM servico where ativo = 'S' and tipo_servico='EX' order by descricao")
        If dr.HasRows Then
            'streamOutput = New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\RelatorioConsultas.htm", False)
            streamOutput = New IO.StreamWriter(System.IO.Path.GetTempPath() & "RelatorioExames.htm", False)

            Try
                streamOutput.WriteLine("<HTML>")
                'streamOutput.WriteLine("<STYLE type=text/css>")
                'streamOutput.WriteLine("   U {font-size:9pt;font-family:'times new roman, verdana, helvetica';}")
                'streamOutput.WriteLine("   TD {font-size:9pt;font-family:'times new roman, verdana, helvetica';}")
                'streamOutput.WriteLine("   TD.cab {font-size:9pt;font-family:'times new roman, verdana, helvetica';}")
                'streamOutput.WriteLine("</STYLE>")

                streamOutput.WriteLine("<BODY><H4>Relatorio de Exames existentes </h4>")
                streamOutput.WriteLine("<TABLE border=1 cellspacing=0 cellpadding=0><TR bgcolor=yellow>")
                streamOutput.WriteLine("<TH>Descrição")

                While dr.Read
                    streamOutput.Write("<TR><TD width=380>&nbsp;" & Trim(dr.Item(0).ToString))
                    vnContaLinhas = vnContaLinhas + 1
                End While
                streamOutput.WriteLine("</table>")
                streamOutput.WriteLine("Total de Exames listados: " & vnContaLinhas)
            Catch ex As Exception
                MsgBox("Erro ao gerar relatório : " & ex.ToString())
            End Try
            streamOutput.Close()
            System.Diagnostics.Process.Start(System.IO.Path.GetTempPath() & "RelatorioExames.htm")
        Else
            MsgBox("Nenhum Exame ativo foi encontrada.")
        End If
        _banco.Desconecta()

    End Sub

    ' desativado
    Private Sub btnExamedoLAboratorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExamedoLAboratorio.Click
        Dim vnContaLinhas As Long = 0
        Dim streamOutput As IO.StreamWriter                               'Classe de leitura de arquivos (txt)
        Dim dr As System.Data.Odbc.OdbcDataReader

        If _banco.Conecta() = False Then Exit Sub
        'MsgBox("conectou")

        dr = _banco.drQuery(" SELECT descricao, exame_juridica.valor FROM exame, exame_juridica where exame_juridica.id_exame=exame.id_exame and ativo='S' order by descricao")

        If dr.HasRows Then
            'streamOutput = New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\RelatorioConsultas.htm", False)
            streamOutput = New IO.StreamWriter(System.IO.Path.GetTempPath() & "RelatorioExamesLaboratorio.htm", False)

            Try
                streamOutput.WriteLine("<HTML>")
                'streamOutput.WriteLine("<STYLE type=text/css>")
                'streamOutput.WriteLine("   U {font-size:9pt;font-family:'times new roman, verdana, helvetica';}")
                'streamOutput.WriteLine("   TD {font-size:9pt;font-family:'times new roman, verdana, helvetica';}")
                'streamOutput.WriteLine("   TD.cab {font-size:9pt;font-family:'times new roman, verdana, helvetica';}")
                'streamOutput.WriteLine("</STYLE>")
                streamOutput.WriteLine("<BODY><H4>Relatorio de Exames " & frmSetup.cmbMedicoP.Text & "</h4>")
                streamOutput.WriteLine("<TABLE border=1 cellspacing=0 cellpadding=0><TR bgcolor=yellow>")
                streamOutput.WriteLine("<TH>Exame<TH>Valor")
                While dr.Read
                    streamOutput.Write("<TR>")
                    streamOutput.Write("<TD width=380>&nbsp;" & Trim(dr.Item(0).ToString))
                    streamOutput.Write("<TD align=center>" & Trim(dr.Item(1).ToString))
                    vnContaLinhas = vnContaLinhas + 1
                End While
                streamOutput.WriteLine("</table>")
                streamOutput.WriteLine("Total de Exames listados: " & vnContaLinhas)
            Catch ex As Exception
                MsgBox("Erro ao gerar relatório : " & ex.ToString())
            End Try
            streamOutput.Close()
            System.Diagnostics.Process.Start(System.IO.Path.GetTempPath() & "RelatorioExamesLaboratorio.htm")

        Else
            MsgBox("Nenhum Exame ativo foi encontrada para sua empresa.")
        End If
        _banco.Desconecta()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim vnContaLinhas As Long = 0
        Dim streamOutput As IO.StreamWriter                               'Classe de leitura de arquivos (txt)
        Dim dr As System.Data.Odbc.OdbcDataReader
        Dim drExames As System.Data.Odbc.OdbcDataReader

        If _banco.Conecta() = False Then Exit Sub
        'MsgBox("conectou")

        dr = _banco.drQuery(" SELECT descricao, id_exame FROM exame where ativo='S' order by descricao")
        If dr.HasRows Then
            streamOutput = New IO.StreamWriter(System.IO.Path.GetTempPath() & "RelatorioExamesLaboratorios.htm", False)
            Try

                streamOutput.WriteLine("<HTML><head><title>PREVPEL - " & frmMain.Text & "</title><meta http-equiv='Content-Type' content='1text/html; charset=utf-8'></head>")
                streamOutput.WriteLine("<BODY><H4>Relatorio de Exames - Completo</h4>")
                streamOutput.WriteLine("<TABLE border=1 cellspacing=0 cellpadding=0><TR bgcolor=yellow>")
                streamOutput.WriteLine("<TH>Exame<TH>LAboratórios")
                While dr.Read
                    streamOutput.Write("<TR>")
                    streamOutput.Write("<TD width=380>&nbsp;" & Trim(dr.Item(0).ToString))
                    drExames = _banco.drQuery("SELECT nome, exame_juridica.valor FROM exame_juridica, juridicas where exame_juridica.id_juridica=juridicas.id_juridica and id_exame=" & dr.Item(1).ToString & " order by nome")
                    If drExames.HasRows Then
                        Dim vnConta As Integer = 0
                        While drExames.Read
                            If vnConta = 0 Then
                                streamOutput.Write("<TD>" & Trim(drExames.Item(0).ToString) & "-" & drExames.Item(1).ToString)
                            Else
                                streamOutput.Write("<td></td><TR><TD><TD>" & Trim(drExames.Item(0).ToString) & "-" & drExames.Item(1).ToString)
                            End If
                            vnConta += 1
                        End While
                    Else
                        streamOutput.Write("<td></td>")
                    End If
                    vnContaLinhas = vnContaLinhas + 1
                End While
                streamOutput.WriteLine("</table>")
                streamOutput.WriteLine("Total de Exames listados: " & vnContaLinhas)
            Catch ex As Exception
                MsgBox("Erro ao gerar relatório : " & ex.ToString())
            End Try
            streamOutput.Close()
            System.Diagnostics.Process.Start(System.IO.Path.GetTempPath() & "RelatorioExamesLaboratorios.htm")

        Else
            MsgBox("Nenhum Exame ativo foi encontrada para sua empresa.")
        End If
        _banco.Desconecta()

    End Sub

End Class