Imports Microsoft.VisualBasic
Imports System.IO

Public Class formEstatistica

    Public Sub New()
        InitializeComponent()

        dim drGeneric As Npgsql.NpgsqlDataReader
        If _PG.Conectar = False Then Exit Sub

        drGeneric = _PG.DrQuery("SELECT id_prestador, to_ascii(nome,'LATIN1') || CASE WHEN situacao='S' THEN ' - SUSPENSO' ELSE '' END FROM prestador order by nome ")
        If drGeneric.HasRows Then
            While drGeneric.Read
                cmbMedico.Items.Add(New ComboData(drGeneric.Item(0).ToString, Trim(drGeneric.Item(1).ToString)))
            End While
        End If
        drGeneric = _PG.DrQuery("select fonte,  to_ascii(descricao,'LATIN1') from aplicacao where fonte like 'biosifam%' order by descricao")
        If drGeneric.HasRows Then
            While drGeneric.Read
                cmbTipoEstatistica.Items.Add(New ComboData(drGeneric.Item(0).ToString, Trim(drGeneric.Item(1).ToString)))
            End While
        End If

        _PG.Desconectar()

    End Sub

    private sub btnGerarEstatistica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGerarEstatistica.Click
        dim vdData As Date, vdDataFim As Date
        dim vsFiltro As String = "", vsRetorno As String = "", vsFiltroTexto As String = ""

        vsRetorno = InputBox("Informe uma data ou intervalo para pesquisar as consultas (dd/mm/yyyy ou dd/mm/yyyy-dd/mm/yyyy): ", "Relatório Estatístico", Format(Date.Today, "dd/MM/yyyy"))

        If InStr(vsRetorno, "-") > 0 Then
            vdData = CDate(vsRetorno.Substring(0, 10))
            vdDataFim = CDate(vsRetorno.Substring(11, 10))
            vsFiltro = " and date(datahora) >='" & Format(vdData, "yyyy/MM/dd") & "' and date(datahora) <= '" & Format(vdDataFim, "yyyy/MM/dd") & "'"
        Else
            If IsDate(vsRetorno) = False Then MsgBox("Data inválida ") : Exit Sub
            vdData = CDate(vsRetorno)
            vdDataFim = vbNullString
            vsFiltro = " and date(datahora)='" & Format(vdData, "yyyy/MM/dd") & "'"
        End If
        If vsRetorno = "" Then Exit Sub

        dim vsUsuario As String = ""
        dim vsAplicacao As String = ""
        vsFiltroTexto = ""
        If cmbMedico.SelectedIndex >= 0 Then
            vsUsuario = " and prestador.id_prestador=" & CType(cmbMedico.SelectedItem, ComboData).Id & ""
            vsFiltroTexto = "Prestador=" & CType(cmbMedico.SelectedItem, ComboData).Descricao & " em " & vsRetorno
        End If
        If cmbTipoEstatistica.SelectedIndex >= 0 Then
            vsAplicacao = " and fonte='" & CType(cmbTipoEstatistica.SelectedItem, ComboData).Id & "'"
            If vsFiltroTexto <> "" Then vsFiltroTexto = vsFiltroTexto & ", "
            vsFiltroTexto = IIf(vsFiltroTexto <> "", vsFiltroTexto & ",", "") & "Aplicativo=" & CType(cmbTipoEstatistica.SelectedItem, ComboData).Descricao & " em " & vsRetorno
        Else
            vsAplicacao = " and fonte like 'biosifam%'"
            vsFiltroTexto = IIf(vsFiltroTexto <> "", vsFiltroTexto & ",", "") & vsRetorno
        End If

        dim vnContaLinhas As Long = 0
        dim streamOutput As IO.StreamWriter                               'Classe de leitura de arquivos (txt)
        dim dr As Npgsql.NpgsqlDataReader, vsSQL As String, vsArquivo As String
        vsArquivo = System.IO.Path.GetTempPath() & "EstatisticaBiometrica.htm"
        If _PG.Conectar = False Then Exit Sub
        If chkModoResumo.Checked Then
            vsSQL = "select fonte,  to_ascii(descricao,'LATIN1') as descricao, count(*) from log inner join aplicacao on log.codaplicacao=aplicacao.codaplicacao " &
                      "where 1=1 " & vsFiltro & vsAplicacao & " group by descricao, fonte order by descricao "

        ElseIf chkResumoDia.Checked Then
            vsSQL = "select date(datahora), fonte,  to_ascii(descricao,'LATIN1') as descricao, count(*) from log inner join aplicacao on log.codaplicacao=aplicacao.codaplicacao " &
                      "where 1=1 " & vsFiltro & vsAplicacao & " group by descricao, date(datahora), fonte order by descricao "
            'vsSQL = vsSQL & "union select "", fonte, descricao, count(*) from log inner join aplicacao on log.codaplicacao=aplicacao.codaplicacao " & _
            '          "where 1=1 " & vsFiltro & vsAplicacao & " group by descricao, fonte order by descricao "

        Else
            vsSQL = "select datahora, fonte,  to_ascii(descricao,'LATIN1') as descricao, log.login, id_pessoa, pessoas.nome, detalhe from log " &
                    "inner join aplicacao on log.codaplicacao=aplicacao.codaplicacao " &
                    "left join usuario on log.login=usuario.login " &
                    "left join prestador on usuario.id_prestador=prestador.id_prestador " &
                    "left join pessoas on cast(log.detalhe as integer)=pessoas.id_pessoa where 1=1 " & vsFiltro & vsAplicacao & vsUsuario & " order by datahora limit 1000 "

        End If
        dr = _PG.drQuery(vsSQL)
        If dr.HasRows Then
            'streamOutput = New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\RelatorioConsultas.htm", False)
            streamOutput = New IO.StreamWriter(vsArquivo, False)
            Try
                streamOutput.WriteLine("<HTML><head><title>PREVPEL - " & frmMain.Text & "</title><meta http-equiv='Content-Type' content='1text/html; charset=utf-8'>" & vsHTMLStyle & "</head>")
                streamOutput.WriteLine("<BODY><H4>Estatistica de Validacoes Biométricas</h4>")
                If vsFiltroTexto <> "" Then streamOutput.WriteLine("Filtro: <B>" & vsFiltroTexto & ".</b>")
                streamOutput.WriteLine("<TABLE border=1 >")
                If chkModoResumo.Checked Then
                    streamOutput.WriteLine("<TH>Descrição<TH>Fonte")
                ElseIf chkResumoDia.Checked Then
                    streamOutput.WriteLine("<TR><TH>Data")
                    streamOutput.WriteLine("<TH>Descrição<TH>Fonte")
                Else
                    streamOutput.WriteLine("<TR><TH>Data<TH>Hora")
                    If vsAplicacao = "" Then streamOutput.WriteLine("<TH>Fonte<TH>Descrição")
                    If vsUsuario = "" Then streamOutput.WriteLine("<TH>login<TH>Id<TH>Pessoa")
                End If
                streamOutput.WriteLine("<TH>Detalhe")

                While dr.Read
                    streamOutput.Write("<TR>")
                    If chkModoResumo.Checked Then
                        streamOutput.WriteLine("<Td>" & dr.Item(1) & "<Td>" & dr.Item(0))
                        streamOutput.Write("<TD>" & dr.Item(2))
                    ElseIf chkResumoDia.Checked Then
                        streamOutput.Write("<TD>" & Format(dr.Item(0), "dd/MM/yyyy"))
                        streamOutput.WriteLine("<Td>" & dr.Item(2) & "<Td>" & dr.Item(1))
                        streamOutput.Write("<TD>" & dr.Item(3))
                    Else
                        streamOutput.Write("<TD>" & Format(dr.Item(0), "dd/MM/yyyy") & "<TD>" & Format(dr.Item(0), "hh:mm:ss"))
                        If vsAplicacao = "" Then streamOutput.WriteLine("<Td>" & dr.Item(1) & "<Td>" & dr.Item(2))
                        If vsUsuario = "" Then streamOutput.WriteLine("<Td>" & dr.Item(3) & "<Td>" & dr.Item(4) & "<Td>" & dr.Item(5))
                        streamOutput.Write("<TD>" & dr.Item(6))
                    End If
                    vnContaLinhas = vnContaLinhas + 1
                End While
                streamOutput.WriteLine("</table>")
                streamOutput.WriteLine("Total de Registros : " & dr.RecordsAffected)
                'streamOutput.WriteLine("Total de Sessoes realizadas: " & vnContaLinhas)
            Catch ex As Exception
                MsgBox("Erro ao gerar relatório : " & ex.ToString())
            End Try
            streamOutput.Close()
            _pg.Desconectar()
            System.Diagnostics.Process.Start(vsArquivo)
        Else
            MsgBox("Nenhum informação foi encontrada no período especificado.")
        End If
        _pg.Desconectar()

    End Sub


    private sub chkResumoDia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkResumoDia.CheckedChanged
        If chkResumoDia.Checked Then chkModoResumo.Checked = False
    End Sub

    private sub chkModoResumo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkModoResumo.CheckedChanged
        If chkModoResumo.Checked Then chkResumoDia.Checked = False

    End Sub
End Class