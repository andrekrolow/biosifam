
Public Class FrmUpload

    Dim TipoGrid As String = ""
    Public idAtendimento As Long = 0

    Private Sub FrmUpload_Load(sender As Object, e As EventArgs) Handles Me.Load

        CmbMes.SelectedIndex = Today.Month - 1
        CmbAno.SelectedIndex = Today.Year - 2022      '2022=0 
        Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2   ' Center form horizontally.
        Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2  ' Center form vertically.
        Dim toolTip1 As New ToolTip()     ' Define o delay para a ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500        ' Força a o texto da ToolTip a ser exibido mesmo que o form não esta ativo
        toolTip1.ShowAlways = True        ' Define o texto da ToolTip para o Button, TextBox, Checkbox e Label
        toolTip1.SetToolTip(Me.grdUploads, "Clique aqui e visualize o documento arquivado, Utilize a tecla DELETE para excluir documentos.")
        toolTip1.SetToolTip(Me.btnPesquisar, "Clique aqui e visualize os documentos arquivados no período informado.")
        toolTip1.SetToolTip(Me.btnAuditagem, "Clique aqui e visualize os atendimentos sem upploads no período informado.")
        toolTip1.SetToolTip(Me.PicCapturarDocumentoCelular, "Clique aqui para realizar Uploads pelo Celular.")

        ' exames usa prescricao medica + faturamento (todo usam faturamento)
        ' pa     usa despesa extra + boletim atendimento  + faturamento (todo usam faturamento)
        If oMedicoConveniado.Modo = 3 Then
            CmbTipo.Items.Add("Prescrição Médica")
        Else

            If oMedicoConveniado.Modo = 2 And (oMedicoConveniado.Especialidade = 13 Or oMedicoConveniado.Especialidade2 = 13) Then
                ' desvio especial para gestantes - se é mulher, se idade > 12 and < 50, e médico é Ginecologista =id=13
                ' mas só pode liberar no oitavo mês
                ' DESATIVADO POR ENQUANTO - versao 2.2.75 15/08/2022
                CmbTipo.Items.Add("Gravidez ùltimo mês")
            Else
                CmbTipo.Items.Add("Boletim de Atendimento")
                CmbTipo.Items.Add("Despesas Extras")

            End If
        End If
        'CmbTipo.Items.Add("Faturamento Mensal")

        CmbTipo.SelectedIndex = 0
        If idAtendimento > 0 Then CarregaDocumentos(idAtendimento)

    End Sub

    Private Sub btnMatricula_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        If oMedicoConveniado.Id = 0 Then MsgBox("Selecione um Profissional.") : Exit Sub
        CarregaDocumentos(0)
    End Sub

    Private Function CarregaDocumentos(idAtendimento As Long) As Boolean
        CarregaDocumentos = False
        TipoGrid = "SIM"

        Dim ds As DataSet
        Dim vsSql As String
        Dim StrWhere As String = ""
        If CmbTipo.SelectedItem = "Boletim de Atendimento" Then StrWhere = " and tipo='B'"
        If CmbTipo.SelectedItem = "Despesas Extras" Then StrWhere = " and tipo='D'"
        If CmbTipo.SelectedItem = "Faturamento Mensal" Then StrWhere = " and tipo='F'"
        If CmbTipo.SelectedItem = "Prescrição Médica" Then StrWhere = " and tipo='P'"
        If CmbTipo.SelectedItem = "Gravidez ùltimo mês" Then StrWhere = " and tipo='G'"
        If idAtendimento > 0 Then
            vsSql = "select id_upload as Id, dt_alteracao as Data, hr_alteracao as Hora, case when tipo='A' then 'Autorização' when tipo='F' then 'Faturamento' when tipo='D' then 'Despesa'  when tipo='B' then 'Boletim'  when tipo='P' then 'Prescrição' end as Tipo, identificador, case when situacao='A' then 'AUDITADO'  when situacao='R' then 'REJEITADO' else 'PENDENTE' end as Situação, situacao_data, to_ascii(situacao_detalhe,'LATIN1') as situacao_detalhe from upload where identificador='" & idAtendimento & "'"
            vsSql &= " and id_prestador=" & oMedicoConveniado.Id & StrWhere
            'vsSql = "select id_upload, dt_alteracao, hr_alteracao from upload where id_prestador=1 And tipo ='F'"
        Else
            vsSql = "select id_upload as Id, dt_alteracao as Data, hr_alteracao as Hora, case when tipo='A' then 'Autorização' when tipo='F' then 'Faturamento' when tipo='D' then 'Despesa'  when tipo='B' then 'Boletim'  when tipo='P' then 'Prescrição' end as Tipo, identificador, case when situacao='A' then 'AUDITADO'  when situacao='R' then 'REJEITADO' else 'PENDENTE' end as Situação, situacao_data, to_ascii(situacao_detalhe,'LATIN1') as situacao_detalhe from upload where extract(month from dt_alteracao)=" & CmbMes.SelectedItem & " and extract(year from dt_alteracao)=" & CmbAno.SelectedItem
            vsSql &= " and id_prestador=" & oMedicoConveniado.Id & StrWhere
            'vsSql = "select id_upload, dt_alteracao, hr_alteracao from upload where id_prestador=1 And tipo ='F'"

        End If
        ds = _PG.DsQuery(vsSql)
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Nenhum upload foi localizado para o período especificado !")
            grdUploads.DataSource = Nothing
            Exit Function
        End If

        grdUploads.DataSource = ds.Tables(0)
        grdUploads.Columns(6).Visible = False
        grdUploads.Columns.Item(7).Visible = False
        CarregaDocumentos = True
    End Function

    Private Sub PicBuscarArquivo_Click(sender As Object, e As EventArgs) Handles PicBuscarArquivo.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        txtArquivo.Text = ""
        fd.Title = "Selecione o arquivo para enviar à PREVPEL"
        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) ' "C:\"
        fd.Filter = "PDF/JPG/JPEG files (*.pdf,*.jpg, *.jpeg)|*.pdf;*.jpg;*.jpeg"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        If fd.ShowDialog() = DialogResult.OK Then txtArquivo.Text = fd.FileName
    End Sub

    Private Sub grdUploads_KeyDown(sender As Object, e As KeyEventArgs) Handles grdUploads.KeyDown
        Dim KeyCode As Short = e.KeyCode
        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Return Then
            ExibirPDF(grdUploads.CurrentRow.Cells(0).Value())
        End If
        If KeyCode = System.Windows.Forms.Keys.Delete Then
            If TipoGrid = "NAO" Then
                MsgBox("Exclusão impossível neste grid!")
                Exit Sub
            End If

            If MsgBox("Deseja realmente excluir o documento selecionado ?", MsgBoxStyle.YesNo, "Confirme a operação de exclusão.") = vbYes Then
                Try
                    If grdUploads.CurrentRow.Cells(5).Value = "AUDITADO" Then
                        MsgBox("Documento AUDITADO não pode ser excluído!")
                        Exit Sub
                    End If

                    If _PG.Conectar() = False Then Exit Sub

                    Dim _Atendimento As New ClsAtendimento
                    Dim ds As DataSet
                    ds = _PG.DsQuery("select situacao from atendimento where id_atendimento=" & grdUploads.CurrentRow.Cells(4).Value())
                    If ds.Tables(0).Rows.Count = 0 Then
                        MsgBox("Atendimento não localizado !")
                        Exit Sub
                    End If

                    If oMedicoConveniado.VerificaRestricoesOffLine(CDate(grdUploads.CurrentRow.Cells(1).Value), ds.Tables(0).Rows(0).Item(0).ToString) = False Then Exit Sub

                    _PG.Execute("delete from upload where id_upload=" & grdUploads.CurrentRow.Cells(0).Value())
                    _PG.Desconectar()
                    CarregaDocumentos(0)
                Catch
                    MsgBox("Exclusão falhou, verifique e procure apoio técnico!")
                End Try

            End If
        End If
    End Sub

    Private Sub grdUploads_DoubleClick(sender As Object, e As EventArgs) Handles grdUploads.DoubleClick
        If TipoGrid = "NAO" Then Exit Sub
        If grdUploads.CurrentRow Is Nothing Then Exit Sub
        ExibirPDF(grdUploads.CurrentRow.Cells(0).Value())
        If grdUploads.CurrentRow.Cells(5).Value = "REJEITADO" Then
            MsgBox("Data: " & grdUploads.CurrentRow.Cells(6).Value & Chr(13) & "Detalhe: " & grdUploads.CurrentRow.Cells(7).Value, vbInformation, "Documento REJEITADO")
        End If
    End Sub

    Private Function ExibirPDF(ByVal IdUpload As Long) As Boolean
        ExibirPDF = False
        'frmBrowser.WebBrowser1.Navigate("http:\\sifam.pelotas.com.br\php\viewPrestadorUploads.php?id_upload=" & IdUpload)
        'frmBrowser.Text = "Help Biosifam"
        'frmBrowser.Show()
        System.Diagnostics.Process.Start("http:\\sifam.pelotas.com.br\php\viewPrestadorUploads.php?id_upload=" & IdUpload)
        ExibirPDF = True
    End Function

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        If txtArquivo.Text = "" Then Exit Sub
        If UCase(txtArquivo.Text.Substring(txtArquivo.Text.Length - 3, 3)) <> "PDF" And
            UCase(txtArquivo.Text.Substring(txtArquivo.Text.Length - 3, 3)) <> "JPG" And
            UCase(txtArquivo.Text.Substring(txtArquivo.Text.Length - 4, 4)) <> "JPEG" Then
            MsgBox("Documento anexado deve ser tipo PDF ou JPEG ou JPG.")
            txtArquivo.Text = ""
        End If
        If txtArquivo.Text = "" Then MsgBox("Selecione ou informe o arquivo a ser enviado.") : Exit Sub
        If CmbTipo.SelectedIndex < 0 Then MsgBox("Informe o tipo de documento a ser enviado.") : Exit Sub
        If oMedicoConveniado.Id = 0 Then MsgBox("Selecione um Profissional.") : Exit Sub
        Dim StrTipo As String = "D"
        Dim StrIdentificador As String = ""

        If CmbTipo.SelectedItem = "Boletim de Atendimento" Then StrTipo = "B"
        If CmbTipo.SelectedItem = "Despesas Extras" Then StrTipo = "D"
        If CmbTipo.SelectedItem = "Faturamento Mensal" Then StrTipo = "F"
        If CmbTipo.SelectedItem = "Prescrição Médica" Then StrTipo = "P"
        If CmbTipo.SelectedItem = "Gravidez ùltimo mês" Then StrTipo = "G"
        Dim ds As DataSet
        If StrTipo <> "F" Then
            StrIdentificador = ""
            Try
                If grdUploads.Rows.Count > 0 Then StrIdentificador = grdUploads.CurrentRow.Cells(0).Value()
            Catch
                StrIdentificador = ""
            End Try

            StrIdentificador = InputBox("Informe o Id do registro do atendimento deste documento.", "", StrIdentificador)
            If StrIdentificador = "" Then MsgBox("Obrigatório informar o Id do atendimento") : Exit Sub
            ds = _PG.DsQuery("select id_atendimento, id_medico, dt_alteracao, situacao from atendimento where id_atendimento=" & StrIdentificador)
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Atendimento não localizado !")
                grdUploads.DataSource = Nothing
                Exit Sub
            End If
            If Month(ds.Tables(0).Rows(0).Item(2).ToString) <> CmbMes.SelectedItem And Year(ds.Tables(0).Rows(0).Item(2).ToString) <> CmbAno.SelectedItem Then
                MsgBox("Atendimento não pertence ao período informado!")
                grdUploads.DataSource = Nothing
                Exit Sub
            End If
            If ds.Tables(0).Rows(0).Item(1).ToString <> oMedicoConveniado.Id Then
                MsgBox("Atendimento não pertence ao Prestador Atual !")
                grdUploads.DataSource = Nothing
                Exit Sub
            End If

            If oMedicoConveniado.VerificaRestricoesOffLine(CDate(ds.Tables(0).Rows(0).Item(2).ToString), ds.Tables(0).Rows(0).Item(3).ToString) = False Then Exit Sub

            ds = _PG.DsQuery("select id_upload as Id, dt_alteracao as Data, hr_alteracao as Hora, Tipo, identificador, situacao from upload where tipo='" & StrTipo & "' and identificador='" & StrIdentificador & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                MsgBox("Número do Id informado já foi utilizado !")
                grdUploads.DataSource = Nothing
                Exit Sub
            End If


        End If
        If CmbTipo.SelectedIndex = 2 Then StrIdentificador = CmbMes.SelectedItem & "/" & CmbAno.SelectedItem

        If _PG.InsereArquivoBinario(oMedicoConveniado.Id, StrTipo, StrIdentificador, txtArquivo.Text) Then
            MsgBox("Upload realizado com sucesso.")
            CarregaDocumentos(0)
        End If

    End Sub

    Private Sub btnAuditagem_Click(sender As Object, e As EventArgs) Handles btnAuditagem.Click
        If oMedicoConveniado.Id = 0 Then MsgBox("Selecione um Profissional.") : Exit Sub
        CarregaDocumentosNaoInformados()
    End Sub

    Private Sub CarregaDocumentosNaoInformados()
        TipoGrid = "NAO"
        Dim ds As DataSet
        Dim vsSql As String
        vsSql = "select id_atendimento, a.dt_alteracao as Data_Atendimento,  trim(to_ascii(nome ,'LATIN1')) from atendimento a inner join pessoas using (id_pessoa) where a.situacao<>'C' and id_medico=" & oMedicoConveniado.Id & " and extract(month from a.dt_alteracao)=" & CmbMes.SelectedItem & " and extract(year from a.dt_alteracao)=" & CmbAno.SelectedItem & " and cast(id_atendimento as text) not in (select identificador from upload where identificador=cast(id_atendimento as text))"
        ds = _PG.DsQuery(vsSql)
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Todos atendimento possuem seus comprovantes!")
            grdUploads.DataSource = Nothing
            Exit Sub
        End If
        grdUploads.DataSource = ds.Tables(0)
        grdUploads.Columns.Item(0).Width = 20
        grdUploads.Columns.Item(1).Width = 25
        grdUploads.Columns.Item(2).Width = 300

    End Sub

    Private Sub PicCapturarDocumentoCelular_Click(sender As Object, e As EventArgs) Handles PicCapturarDocumentoCelular.Click
        System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/qrcode_uploaddocumentos.php")
        'System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/php/formUploadDocumentos.php")

    End Sub


End Class