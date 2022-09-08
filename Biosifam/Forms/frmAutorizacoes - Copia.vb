Public Class frmAutorizações
    ReadOnly toolTip1 As New ToolTip()
    Dim ds As DataSet
    Dim vbAutorizacaoExiste As Boolean
    Dim vsSql As String
    Private drGeneric As Npgsql.NpgsqlDataReader
    Dim IntAutorizacao As Long
    Dim strSituacao As String

    Private Sub frmAutorizações_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        toolTip1.SetToolTip(Me.btnPesquisarAutorizacao, "Pesquisar Autorização")
        toolTip1.SetToolTip(Me.btnPesquisarMatricula, "Pesquisar Matricula.")
        toolTip1.SetToolTip(Me.btnUploadDocumento, "Pesquisar arquivo de documento para UpLoad .")
        toolTip1.SetToolTip(Me.Button2, "Imprimir CÓPIA da Solicitação de Autorização.")
        toolTip1.SetToolTip(Me.btnAutorizar, "Autoriza/Finalizar Autorização.")
        toolTip1.SetToolTip(Me.Button4, "Limpar informações do formulário e inicializar nova Solicitação de Autorização.")
        toolTip1.SetToolTip(Me.btnExcluir, "Cancelar Solicitação de Autorização.")
        toolTip1.SetToolTip(Me.btnAutorizar, "Salvar Solicitação de Autorização.")
        toolTip1.SetToolTip(Me.btnDocumentoDigitalizado, "Veja aqui o documento digitalizado para autorização.")

        TabControl1.Refresh()
        If oMedicoConveniado.Categoria = "M" Or oMedicoConveniado.Categoria = "7" Then
            TabControl1.TabPages.Remove(tabProcedimentos)
            tabProcedimentos.Visible = False

        Else
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage1)
        End If

        _t.CarregaCombo(cmbFisioterapeuta, "SELECT id_prestador, to_ascii(nome,'LATIN1') as nome FROM prestador where situacao='A' and (id_especialidades=34 or id_especialidades2=34) and categoria='M' order by to_ascii(nome,'LATIN1') ")
        _t.CarregaCombo(cmbHospital, "SELECT id_prestador, to_ascii(nome,'LATIN1') as nome FROM prestador where situacao='A' and tipo_pessoa='J' and(categoria='1' or categoria='2' or categoria='4') order by nome ")

        LimparForm()

    End Sub

    Private Sub btnPesquisarMatricula_Click(sender As Object, e As EventArgs) Handles btnPesquisarMatricula.Click
        If Val(txtMatricula.Text) = 0 Then
            MsgBox("Informe uma Matricula !" & Chr(13) & Chr(13) & "Impossível acessar, a Matricula deve ser informada.")
            Exit Sub
        End If
        cmbPaciente.Items.Clear()

        PopulaPaciente()

    End Sub

    Private Sub PopulaPaciente()
        ds = _PG.DsQuery("SELECT id_pessoa, to_ascii(nome,'LATIN1') as nome  FROM pessoas where situacao='A' and matricula='" & txtMatricula.Text & "' order by nome ")
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Nenhum pessoa localizada para a matricula informada !" & Chr(13) & Chr(13) & "Por favor verifique a matricula informada e tente novamente.")
            Exit Sub
        End If
        For i = 0 To ds.Tables(0).Rows.Count - 1
            cmbPaciente.Items.Add(New ComboData(ds.Tables(0).Rows(i).Item(0).ToString, Trim(ds.Tables(0).Rows(i).Item(1)).ToString))
        Next
        cmbPaciente.SelectedIndex = 0
    End Sub

    Private Sub btnPesquisarAutorizacao_Click(sender As Object, e As EventArgs) Handles btnPesquisarAutorizacao.Click
        If Val(txtId.Text) = 0 Then
            MsgBox("Informe uma Autorização !" & Chr(13) & Chr(13) & "Impossível acessar a Autorização informada.")
            Exit Sub
        End If

        CarregarAutorizacao()

    End Sub

    Private Sub CarregarAutorizacao()

        ds = _PG.DsQuery("SELECT p.matricula, codigo_procedimento, to_ascii(observacao,'LATIN1') as observacao,sessoes_autorizadas, sessoes_realizadas, id_prestador,aa.situacao, aa.id_pessoa,to_ascii(solicitante,'LATIN1') as solicitante,aa.tipo, id_atendimento_autorizacao, prazos,observacao, solicitante_documento FROM atendimento_autorizacao aa inner join pessoas p using (id_pessoa) where id_atendimento_autorizacao=" & txtId.Text)
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Autorização não encontrada !" & Chr(13) & Chr(13) & "Por favor verifique a autorização informada e tente novamente.")
            Exit Sub
        End If

        If ds.Tables(0).Rows(0).Item("id_prestador") <> oMedicoConveniado.Id Then
            MsgBox("Autorização pertence a outro profissional !" & Chr(13) & Chr(13) & "Impossível acessar a Autorização informada.")
            If _u.vbUsuarioSuporte = False Then
                Exit Sub
            Else
                If MsgBox("Usuário Suporte deseja prosseguir mesmo assim ?", vbYesNo) = vbNo Then Exit Sub
            End If
        End If

        LimparForm()
        GrpArquivo.Visible = False
        btnDocumentoDigitalizado.Visible = True

        txtId.Text = ds.Tables(0).Rows(0).Item("id_atendimento_autorizacao")
        IntAutorizacao = ds.Tables(0).Rows(0).Item("id_atendimento_autorizacao")
        txtMatricula.Text = ds.Tables(0).Rows(0).Item("matricula")
        txtCID10.Text = ds.Tables(0).Rows(0).Item("codigo_procedimento")

        txtObsFisioterapia.Text = ds.Tables(0).Rows(0).Item("observacao")

        txtSessoesAutorizadas.Text = ds.Tables(0).Rows(0).Item("sessoes_autorizadas")
        TxtSessoesRealizadas.Text = ds.Tables(0).Rows(0).Item("sessoes_realizadas")
        strSituacao = ds.Tables(0).Rows(0).Item("situacao")
        txtPrazoInternacao.Text = ds.Tables(0).Rows(0).Item("prazos")
        txtObservacaoSolicitacao.Text = ds.Tables(0).Rows(0).Item("observacao")

        If ds.Tables(0).Rows(0).Item("tipo") = "F" Then     ' fisioterapia
            For i = 0 To cmbFisioterapeuta.Items.Count - 1
                cmbFisioterapeuta.SelectedIndex = i
                If CType(cmbFisioterapeuta.SelectedItem, ComboData).Id = ds.Tables(0).Rows(0).Item("id_prestador") Then Exit For
            Next
            'TabControl1.TabPages.Add(TabPage1)

        ElseIf ds.Tables(0).Rows(0).Item("tipo") = "A" Or ds.Tables(0).Rows(0).Item("tipo") = "H" Then    ' ambulatorial
            ' TabControl1.TabPages.Add(TabPage3)
            If ds.Tables(0).Rows(0).Item("tipo") = "A" Then
                cmbTipo.SelectedIndex = 0
            Else
                cmbTipo.SelectedIndex = 1
                txtPrazoInternacao.Visible = True
                Label13.Visible = True
            End If
            For i = 0 To cmbHospital.Items.Count - 1
                cmbHospital.SelectedIndex = i
                If CType(cmbHospital.SelectedItem, ComboData).Id = ds.Tables(0).Rows(0).Item("id_prestador") Then Exit For
            Next
            Dim StrProcedimento As String = Trim(ds.Tables(0).Rows(0).Item("codigo_procedimento"))
            Dim StrProcedimento2 As String = ""
            If InStr(StrProcedimento, ",") > 0 Then
                StrProcedimento = Trim(ds.Tables(0).Rows(0).Item("codigo_procedimento").ToString.Substring(0, 8))
                StrProcedimento2 = Trim(ds.Tables(0).Rows(0).Item("codigo_procedimento").ToString.Substring(9, 8))
            End If
            CmbCBHPM.Visible = False
            CmbCBHPM2.Visible = False
            For i = 0 To CmbCBHPM.Items.Count - 1
                CmbCBHPM.SelectedIndex = i
                If CType(CmbCBHPM.SelectedItem, ComboData).Id = StrProcedimento Then Exit For
            Next
            CmbCBHPM2.SelectedIndex = -1
            If StrProcedimento2 <> "" Then
                For i = 0 To CmbCBHPM2.Items.Count - 1
                    CmbCBHPM2.SelectedIndex = i
                    If CType(CmbCBHPM2.SelectedItem, ComboData).Id = StrProcedimento2 Then Exit For
                Next
            End If
            CmbCBHPM.Visible = True
            CmbCBHPM2.Visible = True

        Else
            TabControl1.TabPages.Add(tabProcedimentos)
        End If

        If ds.Tables(0).Rows(0).Item("situacao") = "F" Then
            lblSituacao.Text = "FINALIZADO"
            lblSituacao.BackColor = Color.Yellow
            lblSituacao.ForeColor = Color.Maroon

        ElseIf ds.Tables(0).Rows(0).Item("situacao") = "C" Then
            lblSituacao.Text = "CANCELADO"
            lblSituacao.BackColor = Color.Red
            lblSituacao.ForeColor = Color.White

        ElseIf ds.Tables(0).Rows(0).Item("situacao") = "A" Then
            lblSituacao.Text = "AUTORIZADO"
            lblSituacao.BackColor = Color.SeaGreen
            lblSituacao.ForeColor = Color.White
            toolTip1.SetToolTip(Me.btnAutorizar, "Finalizar realização dos procedimentos.")

        ElseIf ds.Tables(0).Rows(0).Item("situacao") = "P" Then
            lblSituacao.Text = "Aguardando Autorização"
            lblSituacao.BackColor = Color.Yellow
            lblSituacao.ForeColor = Color.Maroon
            toolTip1.SetToolTip(Me.btnAutorizar, "Autorizar realização dos procedimentos.")

        End If
        lblSituacao.Visible = True

        PopulaPaciente()
        If cmbPaciente.Items.Count = 0 Then Exit Sub

        For i = 0 To cmbPaciente.Items.Count - 1
            cmbPaciente.SelectedIndex = i
            If CType(cmbPaciente.SelectedItem, ComboData).Id = ds.Tables(0).Rows(0).Item("id_pessoa") Then Exit For
        Next

        If vnGlo_ModoAtual = 0 Then btnAutorizar.Enabled = True
        If vnGlo_ModoAtual = 2 Then btnAutorizar.Enabled = False

        vbAutorizacaoExiste = True
        txtId.Focus()


    End Sub

    Private Sub LimparForm()
        lblSituacao.Visible = False
        vbAutorizacaoExiste = True
        txtDataConsulta.Text = Format(Date.Today, "dd/MM/yyyy")
        cmbPaciente.Items.Clear()
        cmbPaciente.Text = ""

        txtId.Text = ""
        txtMatricula.Text = ""

        txtMatricula.Text = ""
        txtCID10.Text = ""
        txtObsFisioterapia.Text = ""
        txtSessoesAutorizadas.Text = ""
        TxtSessoesRealizadas.Text = ""
        cmbFisioterapeuta.Text = ""
        txtPrazoInternacao.Text = ""
        cmbHospital.SelectedIndex = -1
        CmbCBHPM.SelectedIndex = -1
        CmbCBHPM2.SelectedIndex = -1

        btnAutorizar.Enabled = True
        vbAutorizacaoExiste = False

        Label13.Visible = False
        txtPrazoInternacao.Visible = False
        txtPrazoInternacao.Text = ""
        txtObservacaoSolicitacao.Text = ""
        txtArquivo.Text = ""
        GrpArquivo.Visible = True
        btnDocumentoDigitalizado.Visible = False

        strSituacao = ""
        IntAutorizacao = 0

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        ' este formulario nao vai autorizar solicitações, apenas vai salvar ou excluir, a autorizacao será feito pelo sistema web - sifam
        Dim StrProcedimento As String = ""

        If cmbPaciente.SelectedItem Is Nothing Then MsgBox("Selecione um Paciente !") : Exit Sub
        If CType(cmbPaciente.SelectedItem, ComboData).Id = 0 Then MsgBox("Selecione um Paciente !") : Exit Sub
        If txtMatricula.Text = "" Then MsgBox("Informe a Matricula e selecione um paciente !") : Exit Sub

        If TabPage3.Visible Then        'Hospitalar

            _PG.Conectar()
            drGeneric = _PG.DrQuery("SELECT id_hospitalar from hospitalar WHERE id_medicos=" & oMedicoConveniado.Id & " and id_pessoa=" & CType(cmbPaciente.SelectedItem, ComboData).Id & " and codigo_procedimento='" & CmbCBHPM.SelectedItem.ToString.Substring(0, 8) & "' and situacao='P'")
            If drGeneric.HasRows Then
                MsgBox("Atenção JÁ existe uma solicitação em aberto para o Paciente informado.", MsgBoxStyle.Information, "")
            End If
            drGeneric = _PG.DrQuery("SELECT id_hospitalar from hospitalar h inner join hospitalar_procedimentos using (id_hospitalar) WHERE id_medicos=" & oMedicoConveniado.Id & " and id_pessoa=" & CType(cmbPaciente.SelectedItem, ComboData).Id & " and codigo_procedimento='" & CmbCBHPM.SelectedItem.ToString.Substring(0, 8) & "' and h.situacao='P'")
            If drGeneric.HasRows Then
                MsgBox("Já existe uma solicitação em aberto para o Paciente e CBHPM informados.", MsgBoxStyle.Information, "Impossível prosseguir!")
                GoTo Encerrar
            End If
            If txtArquivo.Text = "" Then MsgBox("Documento de Autorização não foi anexado, impossível solicitar autorização !") : Exit Sub

            If vbAutorizacaoExiste = False Then
                If StrProcedimento = "" Then
                    If CmbCBHPM.SelectedItem IsNot Nothing Then StrProcedimento = CmbCBHPM.SelectedItem.ToString.Substring(0, 8)
                    If CmbCBHPM2.SelectedItem IsNot Nothing Then StrProcedimento &= ", " & CmbCBHPM2.SelectedItem.ToString.Substring(0, 8)
                End If
                _PG.Execute("begin") ' =============================================================================================================================================
                ' prestador aqui é o local que fará o atendimento ambulatorio ou hospital
                ' o local pode ser escolhido pelo paciente entaoi pode ficar em branco
                Dim IdLocal As Integer = 0
                If cmbHospital.SelectedItem IsNot Nothing Then IdLocal = CType(cmbHospital.SelectedItem, ComboData).Id

                ' medico é o solicitante, tipo documento = B = biosifam, documento=id mediico colicitante
                vsSql = "INSERT INTO hospitalar (  id_pessoa, id_medicos, id_juridica, resquisitante, dias, documento_resuisitante, tipo_documento, 
                matricula, tipo, id_hospitalar_origem, login, ip, dt_alteracao, hr_alteracao, id_contribuinte, situacao, observacao, material)
                values(" & CType(cmbPaciente.SelectedItem, ComboData).Id & "," & oMedicoConveniado.Id & "," & IdLocal & ",''," & Val(txtPrazoInternacao.Text) & ",'',''," &
                txtMatricula.Text & "','i',0, '" & frmLogin.TxtUsuario.Text & "','" & _t.ObtemEnderecoIP & "',current_date, current_timestamp,'P','" &
                txtObservacaoSolicitacao.Text & "','" & txtMaterial.Text & "')"

                If _PG.Execute(vsSql) Then
                    drGeneric = _PG.DrQuery("select lastval()")
                    If drGeneric.HasRows Then
                        drGeneric.Read()
                        IntAutorizacao = drGeneric.Item(0)
                    End If
                End If

                _PG.Execute("commit") '=============================================================================================================================================

                If IntAutorizacao > 0 Then
                    ' imagens passarão a ser gravadas arquivo, na tabela upload com o tipo 'A'-autorizacao
                    ' vai passar a substituir o autorizacao_medica que usa o padrão de imagem externa, inserida pelo sifam - ainda funciona mas sera extinta num certo momento
                    If _PG.InsereArquivoBinario(oMedicoConveniado.Id, "P", IntAutorizacao, txtArquivo.Text) Then MsgBox("Upload realizado com sucesso.")
                End If

            Else
                If strSituacao = "P" Then MsgBox("Autorização está aguardando autorização !") : Exit Sub
                If oMedicoConveniado.Categoria = "M" Or oMedicoConveniado.Categoria = "7" Then
                    MsgBox("Médicos não podem finalizar Procedimentos Ambulatoriais/Hospitalares !")
                End If
                Exit Sub
            End If

        ElseIf TabPage1.Visible Then                'MsgBox("Fisioterapia")

            If cmbFisioterapeuta.SelectedItem = -1 Then MsgBox("Informe um fisioterapeuta !") : Exit Sub
            If CType(cmbFisioterapeuta.SelectedItem, ComboData).Id = 0 Then MsgBox("Informe um fisioterapeuta !") : Exit Sub
            If txtCID10.Text = "" Then MsgBox("Informe um CID10 !") : Exit Sub
            If IntAutorizacao > 0 And strSituacao <> "P" Then MsgBox("Autorização já está em andamento e não pode mais ser alterada!") : Exit Sub
            If txtArquivo.Text <> "" Then MsgBox("Documento de Autorização não foi anexado, impossível solicitar autorização !") : Exit Sub

            ' veirica existencia de cid10 para o mesmo paciente e outras matriculas
            _PG.Conectar()
            drGeneric = _PG.DrQuery("SELECT id_atendimento_autorizacao from atendimento_autorizacao WHERE tipo='F' and id_pessoa=" & CType(cmbPaciente.SelectedItem, ComboData).Id & " and codigo_procedimento='" & txtCID10.Text & "' and sessoes_realizadas < sessoes_autorizadas")
            If drGeneric.HasRows Then
                MsgBox("Já existe uma autorização em aberto para o CID10 informado.", MsgBoxStyle.Information, "Impossível gravar autorização")
                GoTo Encerrar
            End If
            drGeneric = _PG.DrQuery("SELECT id_atendimento_autorizacao from atendimento_autorizacao aa, pessoas p1, pessoas p2 WHERE tipo='F' and aa.id_pessoa=" & CType(cmbPaciente.SelectedItem, ComboData).Id & " and p1.cpf=p2.cpf and codigo_procedimento='" & txtCID10.Text & "' and sessoes_realizadas < sessoes_autorizadas")
            If drGeneric.HasRows Then
                MsgBox("Já existe uma autorização em aberto para o CPF e CID10 informados.", MsgBoxStyle.Information, "Impossível gravar autorização")
                GoTo Encerrar
            End If

            If vbAutorizacaoExiste = False Then
                _PG.Execute("begin") ' =============================================================================================================================================
                vsSql = "INSERT INTO atendimento_autorizacao ( matricula, id_prestador, Data, situacao, tipo, id_pessoa, sessoes_autorizadas, sessoes_realizadas, solicitante, solicitante_tipo_doc, solicitante_documento, codigo_procedimento, observacao, autorizacao_medica, prazos, ip, dt_alteracao, login)"
                vsSql &= " values('" & txtMatricula.Text & "' , " & CType(cmbFisioterapeuta.SelectedItem, ComboData).Id & ",current_date,'P','F'," & CType(cmbPaciente.SelectedItem, ComboData).Id & ",20,0,'" & oMedicoConveniado.Nome & "','','','" & txtCID10.Text & "','" & txtObsFisioterapia.Text & "','',0,'" & _t.ObtemEnderecoIP & "',current_timestamp,'" & frmLogin.TxtUsuario.Text & "')"
                If _PG.Execute(vsSql) Then
                    drGeneric = _PG.DrQuery("select lastval()")
                    If drGeneric.HasRows Then
                        drGeneric.Read()
                        IntAutorizacao = drGeneric.Item(0)
                    End If
                End If
                _PG.Execute("commit") '=============================================================================================================================================

                ' imagens passarão a ser gravadas arquivo, na tabela upload com o tipo 'A'-autorizacao
                ' vai passar a substituir o autorizacao_medica que usa o padrão de imagem externa, inserida pelo sifam - ainda funciona mas sera extinta num certo momento
                If _PG.InsereArquivoBinario(oMedicoConveniado.Id, "A", IntAutorizacao, txtArquivo.Text) Then MsgBox("Upload realizado com sucesso.")
            Else
                MsgBox("Alterações não estão permitidas, cancele a autorização e faça novamente.")
                Exit Sub
            End If


        ElseIf tabProcedimentos.Visible Then
            'MsgBox("Procedimentos")
            MsgBox("Rotina em implementação.")
            Exit Sub
        End If

        If vbAutorizacaoExiste = False Then
            If IntAutorizacao > 0 Then
                MsgBox("Solicitação de Autorização N. " & IntAutorizacao & " gerada com sucesso. " & Chr(13) & Chr(13) & "Prevpel será notificado por email da solicitação, aguarde comunicação de autorização.")
                ' disparar email ao paciente.
                Dim Email As ClsMail
                Dim _Pessoa As New ClsPessoa
                _Pessoa.CarregarPessoa(CType(cmbPaciente.SelectedItem, ComboData).Id)
                If _Pessoa.Email <> "" Then
                    'vsEmailPaciente = "andrekrolow@gmail.com"
                    Email = New ClsMail("Prevpel - Biosifam")
                    Email.vsAssunto = "PREPVEL/Biosifam - Solicitação de Autorização N." & IntAutorizacao
                    Email.vsMensagem = "Comunicamos o encaminhamento ao setor competente da solicitação de autorização de fisioterapia N. " & IntAutorizacao & " em " & oMedicoConveniado.Nome & " as "
                    Email.vsMensagem &= Format(Date.Now, "hh:mm") & " de " & Format(Date.Today, "dd/MM/yyyy") & " na matricula " & txtMatricula.Text & ", paciente " & _Pessoa.Nome & "."
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
                    Email.vsEmail = "famatendimento.prevpel@pelotas.rs.gov.br"
                    Email.Enviar()
                End If
            End If
        End If

Encerrar:
        _PG.Desconectar()
        LimparForm()
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If Val(txtId.Text) = 0 Then
            MsgBox("Informe uma Autorização !" & Chr(13) & Chr(13) & "Impossível cancelar a Autorização.")
            Exit Sub
        End If
        If strSituacao = "C" Then
            MsgBox("Autorização já está cancelada !" & Chr(13) & Chr(13) & "Impossível cancelar a Autorização.")
            Exit Sub
        End If
        If TxtSessoesRealizadas.Text > 0 Then
            MsgBox("Impossível cancelar Autorização já em andamento !" & Chr(13) & Chr(13) & "Impossível cancelar a Autorização.")
            Exit Sub
        End If
        If strSituacao <> "P" Then
            MsgBox("Impossível cancelar Autorização já em andamento !" & Chr(13) & Chr(13) & "Impossível cancelar a Autorização.")
            Exit Sub
        End If
        If Val(txtId.Text) <> IntAutorizacao Then
            MsgBox("Autorização informada divergente da Autorização carregada ! Recarregue a Autorização." & Chr(13) & Chr(13) & "Impossível cancelar a Autorização.")
            Exit Sub
        End If
        If MsgBox("Confirma o cancelamento da Solicitação de Autorização ?", vbYesNo) = vbNo Then Exit Sub
        _PG.Conectar()
        _PG.Execute("begin")
        vsSql = "update atendimento_autorizacao set situacao='C' where id_atendimento_autorizacao=" & IntAutorizacao
        _PG.Execute(vsSql)
        _PG.Execute("commit")
        _PG.Desconectar()
        MsgBox("Autorização CANCELADA com sucesso!")

        CarregarAutorizacao()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Val(txtId.Text) = 0 Then
            MsgBox("Informe uma Autorização !" & Chr(13) & Chr(13) & "Impossível acessar a Autorização informada.")
            Exit Sub
        End If

        ImprimirAutorizacao(txtId.Text)

    End Sub

    Private Function ImprimirAutorizacao(idAutorizacao As Long)
        If TabPage3.Visible Then                'MsgBox("Hospitalar")
            If cmbTipo.SelectedItem = "Ambulatorial" Then
                System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/php/printAutorizacao.php?id_autorizacao=" & idAutorizacao)
            Else
                System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/php/printAutorizacao.php?id_autorizacao=" & idAutorizacao)
            End If

        ElseIf TabPage1.Visible Then                'MsgBox("Fisioterapia")
            System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/php/printAutorizacao.php?id_autorizacao=" & idAutorizacao)
        End If
        ImprimirAutorizacao = True
    End Function

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs)

        If Val(txtId.Text) = 0 Then
            MsgBox("Informe uma Autorização !" & Chr(13) & Chr(13) & "Impossível acessar a Autorização informada.")
            Exit Sub
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Limpar
        LimparForm()
        txtId.Focus()
    End Sub

    Private Sub txtSessoesAutorizadas_GotFocus(sender As Object, e As EventArgs) Handles txtSessoesAutorizadas.GotFocus
        If txtSessoesAutorizadas.Text = "" Then
            txtSessoesAutorizadas.Text = "20"
            txtSessoesAutorizadas.SelectionLength = 2
        End If
    End Sub


    Private Sub txtId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtId.KeyDown
        Dim KeyCode As Short = e.KeyCode
        ' teclou ENTER põe o foco no próximo controle 

        If KeyCode = System.Windows.Forms.Keys.Return Then
            If txtId.Text <> "" Then
                System.Windows.Forms.SendKeys.Send("{TAB}") ' + é{tab} o shit                
            End If
        End If

    End Sub

    Private Sub txtMatricula_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMatricula.KeyDown
        Dim KeyCode As Short = e.KeyCode
        ' teclou ENTER põe o foco no próximo controle 

        If KeyCode = System.Windows.Forms.Keys.Return Then
            If txtMatricula.Text <> "" Then
                System.Windows.Forms.SendKeys.Send("{TAB}") ' + é{tab} o shit                
            End If
        End If

    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs)
        CmbCBHPM.Items.Clear()
        CmbCBHPM2.Items.Clear()

        If cmbTipo.SelectedItem = "Ambulatorial" Then
            _t.CarregaCombo(CmbCBHPM, "SELECT id_servico, cbhpm_capitulo || ' - '|| to_ascii(descricao,'LATIN1') as nome FROM servico where tabela='CB' and substr(cbhpm_capitulo,1,1)<>'3' and cbhpm_capitulo >'0' order by cbhpm_capitulo || ' - '||(descricao,'LATIN1') ")
            _t.CarregaCombo(CmbCBHPM2, "SELECT id_servico, cbhpm_capitulo || ' - '|| to_ascii(descricao,'LATIN1') as nome FROM servico where tabela='CB' and substr(cbhpm_capitulo,1,1)<>'3'and cbhpm_capitulo >'0' order by cbhpm_capitulo || ' - '||(descricao,'LATIN1') ")
            txtPrazoInternacao.Visible = False
            Label13.Visible = False
        Else
            _t.CarregaCombo(CmbCBHPM, "SELECT id_servico, cbhpm_capitulo || ' - '|| to_ascii(descricao,'LATIN1') as nome FROM servico where tabela='CB'and cbhpm_capitulo >'0' order by cbhpm_capitulo || ' - '||(descricao,'LATIN1') ")
            _t.CarregaCombo(CmbCBHPM2, "SELECT id_servico, cbhpm_capitulo || ' - '|| to_ascii(descricao,'LATIN1') as nome FROM servico where tabela='CB'and cbhpm_capitulo >'0' order by cbhpm_capitulo || ' - '||(descricao,'LATIN1') ")
            txtPrazoInternacao.Visible = True
            Label13.Visible = True
        End If
    End Sub

    Private Sub btnUploadDocumento_Click(sender As Object, e As EventArgs) Handles btnUploadDocumento.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "Selecione o arquivo para enviar à PREVPEL"
        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) ' "C:\"
        fd.Filter = "PDF/JPG/JPEG files (*.pdf,*.jpg, *.jpeg)|*.pdf;*.jpg;*.jpeg"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        If fd.ShowDialog() = DialogResult.OK Then txtArquivo.Text = fd.FileName
        If txtArquivo.Text = "" Then Exit Sub
        If UCase(txtArquivo.Text.Substring(txtArquivo.Text.Length - 3, 3)) <> "PDF" And
           UCase(txtArquivo.Text.Substring(txtArquivo.Text.Length - 3, 3)) <> "JPG" And
           UCase(txtArquivo.Text.Substring(txtArquivo.Text.Length - 4, 4)) <> "JPEG" Then
            MsgBox("Documento anexado deve ser tipo PDF ou JPEG ou JPG.")
            txtArquivo.Text = ""
        End If
    End Sub

    Private Sub btnDocumentoDigitalizado_Click(sender As Object, e As EventArgs) Handles btnDocumentoDigitalizado.Click
        System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/php/viewUploads.php?id_upload=" & txtId.Text)

    End Sub
End Class