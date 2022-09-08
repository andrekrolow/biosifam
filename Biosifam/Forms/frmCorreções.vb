Imports Microsoft.VisualBasic

Public Class frmCorreções
    Dim drGeneric As Npgsql.NpgsqlDataReader
    Dim drMedico As Npgsql.NpgsqlDataReader
    Dim drConsulta As Npgsql.NpgsqlDataReader
    Dim drConsultaItens As Npgsql.NpgsqlDataReader
    Dim drServicos As Npgsql.NpgsqlDataReader
    Dim idMedico As Integer
    Dim _util As New clsUtil()
    Dim IntAutorizacao As Long
    Dim BolCarregandoCombo As Boolean
    Dim idServicoRealizado1 As Long, idServicoRealizado2 As Long
    Dim _Prestador As ClsMedico
    Dim IntContaItens As Integer

    Private Sub frmCorreções_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2   ' Center form horizontally.
        Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2  ' Center form vertically.

        ' somente vnGlo_ModoAtual =0 pode ter acesso+PA

        ' modo retaguarda
        cmbMedico.Enabled = True
        txtPaciente.Enabled = True
        txtDataConsulta.Enabled = True
        If vnGlo_ModoAtual <> 0 Then
            cmbMedico.Enabled = False
        End If
        LimparFormulario()
        CarregaMedicos()

    End Sub

    Public Sub CarregaMedicos()
        _t.CarregaCombo(cmbMedico, "SELECT id_prestador, to_ascii(nome,'LATIN1') as nome FROM prestador where categoria<>'5' order by nome ")
    End Sub

    Public Sub CarregaConsulta()
        If _PG.Conectar = False Then Exit Sub
        drConsulta = _PG.DrQuery("SELECT id_atendimento, to_ascii(prestador.nome,'LATIN1') as nome_prestador,  to_ascii(pessoas.nome,'LATIN1') as nome_pessoa, a.dt_alteracao, a.situacao, prestador.id_prestador, autorizacao, valor, categoria, usa_exame, current_date FROM atendimento as a, prestador, pessoas where a.id_medico=prestador.id_prestador and a.id_pessoa=pessoas.id_pessoa " &
                             " and id_atendimento =" & txtId.Text)

        IntAutorizacao = 0
        idServicoRealizado1 = 0
        idServicoRealizado2 = 0
        BtnSalvar.Enabled = False
        mskValor.Text = ""
        mskValor2.Text = ""
        IntContaItens = 0

        If drConsulta.HasRows Then
            drConsulta.Read()

            mskTotal.Text = drConsulta.Item("valor").ToString

            Dim Medico As New ClsMedico(drConsulta.Item("id_prestador"))
            If Medico.FazExameNoConsultorio Or Medico.Anestesista Or Medico.Categoria = "O" Or Medico.Modo = 3 Or Medico.Modo = 4 Then
                ' exames em consultório, exames em clnica s e laboratorios, procedimentos de anestesistas, 
                ' procedimentos de pronto atendimentos  usarão a tabela cbhpm e a classificação de exames que somente o médico faz.
                ' dentistas passam a usar somente servicos do seu cadastro em 10/01/2022 - versao 2.2.19 - antes usam tipo 'PO'
                StrGloSQL = "SELECT servico.id_servico, to_ascii(descricao,'LATIN1') || case when valor > 0 then ' , R$ '|| valor else '' end FROM servico inner join prestador_servicos on servico.id_servico=prestador_servicos.id_servico where prestador_servicos.id_prestador=" & Medico.Id & " and servico.ativo='S' "
                If oMedicoConveniado.Tabela = "CB" And oMedicoConveniado.Dentista = False Then
                    ' usar por codigo cbhpm quando for hospital
                    StrGloSQL = " Select servico.id_servico, Case when cbhpm_capitulo > '0' then cbhpm_capitulo || '-' else '' end || to_ascii(descricao,'LATIN1') || Case when valor > 0 then ' , R$ '|| valor else '' end  From servico inner Join prestador_servicos On servico.id_servico=prestador_servicos.id_servico Where prestador_servicos.id_prestador = " & Medico.Id & " and servico.ativo='S' Order By 2"
                End If
                BolCarregandoCombo = True
                If oMedicoConveniado.Modo = 4 Then StrGloSQL = Replace(StrGloSQL, " Order By 2", " and prestador_servicos.id_servico<>16953 Order By 2")  ' no Pronto Atendimento vou excluir DESPESAS EXTRAS do primeiro COMBO
                _t.CarregaCombo(cmbProcedimento, StrGloSQL)
                ' 16950-urgente, 16949-nao urgente
                If oMedicoConveniado.Modo = 4 Then StrGloSQL = Replace(StrGloSQL, " and prestador_servicos.id_servico<>16953 Order By 2", " and prestador_servicos.id_servico<>16950 and prestador_servicos.id_servico<>16949  ") ' no Pronto Atendimento no segundo combo vou excluir as consultas urgente e nao urgente, pode aparece despesas extra e exames
                ' dentista nao usa segundo procedimento
                If oMedicoConveniado.Dentista = False Then _t.CarregaCombo(cmbProcedimento2, StrGloSQL)

                BolCarregandoCombo = False
            Else
                If Medico.Categoria = "M" Then
                    If Medico.Fisioterapeuta Then
                        cmbProcedimento.Items.Add(New ComboData(16981, "FISIOTERAPIA"))
                    ElseIf Medico.Nutricionista Then
                        cmbProcedimento.Items.Add(New ComboData(16999, "CONSULTA NUTRICIONISTA"))
                    Else
                        cmbProcedimento.Items.Add(New ComboData(1, "CONSULTA MÉDICA"))
                    End If
                Else
                    StrGloSQL = "SELECT s.id_servico, to_ascii(descricao,'LATIN1') || ', R$ '|| s.valor FROM servico s inner join atendimento_servico on s.id_servico=atendimento_servico.id_servico where id_atendimento=" & txtId.Text
                    'If Medico.FazExameNoConsultorio = "S" Then StrGloSQL = "SELECT servico.id_servico, to_ascii(descricao,'LATIN1') || ', R$ '|| valor FROM servico inner join prestador_servicos on servico.id_servico=prestador_servicos.id_servico where prestador_servicos.id_prestador=" & drConsulta.Item("id_prestador").ToString
                    'If Medico.Categoria = "O" Then StrGloSQL = "SELECT id_servico, to_ascii(descricao,'LATIN1') || ', R$ '|| valor FROM servico where tabela='PO'"  ' todos procedimentos estão na tabela servico identificados como tipo 'PO' procedimento odontológico
                    BolCarregandoCombo = True
                    _t.CarregaCombo(cmbProcedimento, StrGloSQL)
                    _t.CarregaCombo(cmbProcedimento2, StrGloSQL)

                    BolCarregandoCombo = False
                End If
            End If

            Me.Refresh()

            If _PG.Conectar = False Then Exit Sub

            drConsultaItens = _PG.DrQuery("SELECT id_atendimento_servico, id_servico, to_ascii(descricao,'LATIN1') as nome_servico, a.valor FROM atendimento_servico a inner join servico using (id_servico) where id_atendimento=" & txtId.Text & " order by id_servico")
            If drConsultaItens.HasRows Then
                drConsultaItens.Read()
                If oMedicoConveniado.Modo = 4 And drConsultaItens.Item("id_servico") = 16953 Then GoTo SegundoItem

                _t.PosicionaCombo(cmbProcedimento, drConsultaItens.Item("id_servico").ToString)
                idServicoRealizado1 = drConsultaItens.Item("id_atendimento_servico").ToString

                ' If cmbProcedimento.SelectedItem = "" Then cmbProcedimento.Text = drConsultaItens.Item("nome_servico").ToString
                mskValor.Text = drConsultaItens.Item("valor").ToString

                If drConsultaItens.Read() Then
SegundoItem:
                    _t.PosicionaCombo(cmbProcedimento2, drConsultaItens.Item("id_servico").ToString)
                    idServicoRealizado2 = drConsultaItens.Item("id_atendimento_servico").ToString
                    mskValor2.Text = drConsultaItens.Item("valor").ToString
                End If
                IntContaItens = 2
                While drConsultaItens.Read
                    IntContaItens += 1
                End While

            End If
            Me.Refresh()

            ' conveniados só podem ver seu pro´prios lancamentos
            If vnGlo_ModoAtual <> 0 And drConsulta.Item(5).ToString <> oMedicoConveniado.Id Then
                MsgBox("Este atendimento foi realizado por outro prestador e você não tem permissão para visualizá-lo ou acessá-lo.")
                LimparFormulario()
                GoTo Fim
            End If

            cmbMedico.Text = oMedicoConveniado.Nome

            idMedico = drConsulta.Item(5).ToString
            cmbMedico.SelectedIndex = _t.RetornaIndexCombo(cmbMedico, drConsulta.Item(5).ToString)
            _Prestador = New ClsMedico(idMedico)

            txtPaciente.Text = drConsulta.Item(2).ToString
            If IsDBNull(drConsulta.Item("autorizacao")) = False Then IntAutorizacao = drConsulta.Item("autorizacao")

            If drConsulta.Item(3) Is DBNull.Value = False Then txtDataConsulta.Text = drConsulta.Item(3)

            lblSituacaoConsulta.Text = ""

            lblSituacaoConsulta.Visible = False
            If drConsulta.Item(4) = "C" Or drConsulta.Item(4) = "P" Or drConsulta.Item(4) = "G" Then lblSituacaoConsulta.Visible = True
            If drConsulta.Item(4) = "G" Then
                lblSituacaoConsulta.Text = "GLOSADO"
            Else
                If drConsulta.Item(4) = "P" Then lblSituacaoConsulta.Text = "PENDENTE"
                If drConsulta.Item(4) = "C" Then lblSituacaoConsulta.Text = "CANCELADO"
            End If

            lblSituacaoConsulta.Refresh()

            ' parametros desviam validacao de data e glosa
            If oMedicoConveniado.VerificaRestricoesOffLine(CDate(drConsulta.Item(10)), "G") = False Then Exit Sub

            If IntContaItens > 2 Then
                MsgBox("O atendimento possui mais de 2 itens e esta versão não permite a correção deste tipo de lançamento, procure apoio técnico.")
            Else
                BtnSalvar.Enabled = True
            End If

        Else
            MsgBox("o Id informado não foi localizado!")
            txtId.Text = ""

        End If
Fim:
        _PG.Desconectar()
    End Sub

    Private Sub cmbMedico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMedico.SelectedIndexChanged
        If cmbMedico.SelectedIndex = -1 Then cmbMedico.SelectedIndex = 0
        idMedico = CType(cmbMedico.SelectedItem, ComboData).Id
    End Sub

    Private Sub LimparFormulario()
        txtPaciente.Text = ""
        txtDataConsulta.Text = ""
        idMedico = 0
        cmbMedico.Text = ""
        lblSituacaoConsulta.Visible = False
        txtId.Text = ""
        IntAutorizacao = 0
        mskValor.Text = ""
        mskValor2.Text = ""
        mskTotal.Text = ""
        cmbProcedimento.Items.Clear()
        cmbProcedimento2.Items.Clear()
        BtnSalvar.Enabled = False
    End Sub

    Private sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        If txtId.Text = "" Then MsgBox("Informe um Id válido") : Exit Sub
        lblSituacaoConsulta.Visible = False
        CarregaConsulta()
    End Sub

    Private Sub txtId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtId.KeyDown
        Dim keyCode As Short = e.KeyCode
        ' teclou ENTER põe o foco no próximo controle 
        If keyCode = System.Windows.Forms.Keys.Return Then
            If txtId.Text = "" Then MsgBox("Informe um Id válido") : Exit Sub
            lblSituacaoConsulta.Visible = False
            CarregaConsulta()
        End If
    End Sub

    Private Sub cmbProcedimento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProcedimento.SelectedIndexChanged
        If cmbProcedimento.Visible = False Then Exit Sub
        If cmbProcedimento.SelectedItem Is Nothing Then Exit Sub
        Try
            If _PG.Conectar() = False Then Exit Sub
            drServicos = _PG.DrQuery("SELECT valor FROM servico where id_servico=" & CType(cmbProcedimento.SelectedItem, ComboData).Id)
            If drServicos.HasRows Then
                drServicos.Read()
                mskValor.Text = drServicos.Item(0)
            End If
            _PG.Desconectar()
        Catch
        End Try
    End Sub


    Private Sub cmbProcedimento2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProcedimento2.SelectedIndexChanged
        If cmbProcedimento2.Visible = False Then Exit Sub
        If _PG.Conectar() = False Then Exit Sub
        If cmbProcedimento2.SelectedItem Is Nothing Then Exit Sub
        drServicos = _PG.DrQuery("SELECT valor FROM servico where id_servico=" & CType(cmbProcedimento2.SelectedItem, ComboData).Id)
        If drServicos.HasRows Then
            drServicos.Read()
            mskValor2.Text = drServicos.Item(0)
        End If
        _PG.Desconectar()
    End Sub
    Private Sub cmbProcedimento2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProcedimento2.KeyDown
        Dim KeyCode As Short = e.KeyCode
        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Delete Then cmbProcedimento2.SelectedIndex = -1 : mskValor2.Text = ""
    End Sub

    Private Sub cmbProcedimento2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProcedimento2.KeyPress
        ' teclou ENTER põe o foco no próximo controle 
        If e.KeyChar = Convert.ToChar(Keys.Delete) Then cmbProcedimento2.SelectedIndex = -1 : mskValor2.Text = ""
    End Sub
    Private Sub cmbProcedimento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProcedimento.KeyDown
        Dim KeyCode As Short = e.KeyCode
        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Delete Then cmbProcedimento.SelectedIndex = -1 : mskValor.Text = ""
    End Sub

    Private Sub cmbProcedimento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProcedimento.KeyPress
        ' teclou ENTER põe o foco no próximo controle 
        If e.KeyChar = Convert.ToChar(Keys.Delete) Then cmbProcedimento.SelectedIndex = -1 : mskValor.Text = ""
    End Sub

    Private Sub mskValor2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskValor2.KeyPress
        If e.KeyChar = "." Then
            If InStr(mskValor2.Text, ",") Then e.Handled = True
            e.KeyChar = ","
        ElseIf Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack And Not e.KeyChar = "," Then
            e.Handled = True
        ElseIf e.KeyChar = "," And InStr(mskValor2.Text, ",") Then
            e.Handled = True
        End If
    End Sub

    Private Sub mskValor2_TextChanged(sender As Object, e As EventArgs) Handles mskValor2.TextChanged
        mskTotal.Text = CDec(IIf(mskValor.Text = "", 0, mskValor.Text)) + CDec(IIf(mskValor2.Text = "", 0, mskValor2.Text))
    End Sub

    Private Sub mskValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskValor.KeyPress
        If e.KeyChar = "." Then
            If InStr(mskValor.Text, ",") Then e.Handled = True
            e.KeyChar = ","
        ElseIf Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack And Not e.KeyChar = "," Then
            e.Handled = True
        ElseIf e.KeyChar = "," And InStr(mskValor.Text, ",") Then
            e.Handled = True
        End If
    End Sub

    Private Sub mskValor_TextChanged(sender As Object, e As EventArgs) Handles mskValor.TextChanged
        mskTotal.Text = CDec(IIf(mskValor.Text = "", 0, mskValor.Text)) + CDec(IIf(mskValor2.Text = "", 0, mskValor2.Text))
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        MsgBox("Opção em desenvolvimento, aguarde as proximas versões.")
        Exit Sub
        'frmMain.PrintDocument1.Print()
    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click
        Dim StrSituacao As String = ""

        ' aqui só chegam usuario da prevpel, conveniados nao.
        If txtId.Text = "" Then MsgBox("Informe um número de atendimento !") : Exit Sub
        If idMedico = 0 Then MsgBox("Informe o novo médico !") : Exit Sub
        If lblSituacaoConsulta.Visible And lblSituacaoConsulta.Text = "CANCELADO" Then MsgBox("Atendimento já foi cancelado !") : Exit Sub
        If _Prestador.Situacao <> "A" Then MsgBox("Prestador está desativado e não pode receber registros!") : Exit Sub
        If _Prestador.UsaBiosifam = False Then MsgBox("Prestador está marcado para não usar Biosifam e não pode receber registros!") : Exit Sub
        If lblSituacaoConsulta.Visible And lblSituacaoConsulta.Text = "PENDENTE" Then
            If MsgBox("Encerrar atendimento ? ", vbYesNo) = vbYes Then
                StrSituacao = ", situacao='A' "
            End If
        End If

        Dim idServico1 As Long, idServico2 As Long
        If cmbProcedimento.SelectedIndex >= 0 Then idServico1 = CType(cmbProcedimento.SelectedItem, ComboData).Id
        If cmbProcedimento2.SelectedIndex >= 0 Then idServico2 = CType(cmbProcedimento2.SelectedItem, ComboData).Id

        Dim StrJustificativa As String
        StrJustificativa = InputBox("Informe uma justificativa para correção dos  registros.")
        If Trim(StrJustificativa) = "" Then MsgBox("Obrigatório informar uma justificativa") : Exit Sub
        If StrJustificativa.ToString.Length < 9 Then MsgBox("A Justificativa precisa ter no mínimo 10 caracteres.") : Exit Sub
        If StrJustificativa.ToString.Length > 100 Then MsgBox("Informe no máximo 100 caracteres.") : Exit Sub

        If _PG.Conectar = False Then Exit Sub
        _PG.Execute("begin")

        drConsulta = _PG.DrQuery("SELECT * FROM atendimento_justificativa where id_atendimento=" & txtId.Text)
        If drConsulta.HasRows Then
            drConsulta.Read()
            If Len(drConsulta.Item("justificativa") & StrJustificativa) > 150 Then
                MsgBox("A justificativa informada junto com a já existente ultrapassam o tamanho maximo permitido de 150 caracteres. Reduza o tamanho da justificativa.")
            End If
            If _PG.Execute("UPDATE atendimento_justificativa SET Justificativa=Justificativa || ', complemento em ' ||  to_char(current_timestamp, 'DD/MM/YYYY') || ' ' ||
                to_char(current_timestamp, 'HH24:MI:SS') || ': " & StrJustificativa & "', ip= '" & _t.ObtemEnderecoIP & "', dt_alteracao=current_timestamp, login='" & _u.Login & "' WHERE id_atendimento=" & txtId.Text) = False Then
                _toolsSiFam.WriteLog("Erro na atualizacao da justificativa.")
                Exit Sub
            End If
        Else
            If _PG.Execute("INSERT INTO atendimento_justificativa (id_atendimento, justificativa, ip, dt_alteracao, login) values (" &
                 txtId.Text & ",'" & StrJustificativa & "', '" & _t.ObtemEnderecoIP & "', current_timestamp ,'" & frmLogin.TxtUsuario.Text & "')") = False Then
                ' JA EXISTE JUSTIFICATIVA, VAI REGRAVAR
                MsgBox("Erro na inserção da justificativa.")
                Exit Sub
            End If
        End If

        Dim vnValorPrestador As Decimal = 0, vnValorContribuinte As Decimal = 0
        Dim vnValorPrestador2 As Decimal = 0, vnValorContribuinte2 As Decimal = 0

        If idServico1 > 0 And idServicoRealizado1 > 0 Then
            drServicos = _PG.DrQuery("SELECT id_servico, valor, valor_excedente, cobertura, consignacao FROM servico where id_servico=" & idServico1)
            If drServicos.HasRows Then
                drServicos.Read()
                vnValorPrestador = CDec(mskValor.Text) * drServicos.Item(3) / 100
                vnValorContribuinte = CDec(mskValor.Text) * drServicos.Item(4) / 100
            End If
            _PG.Execute("update atendimento_servico Set id_servico=" & idServico1 & ", valor=" & Replace(mskValor.Text, ",", ".") & ", valor_prestador =" & Replace(vnValorPrestador, ",", ".") & ", valor_contribuinte = " & Replace(vnValorContribuinte, ",", ".") &
                " where id_atendimento_servico=" & idServicoRealizado1)
        Else
            If idServicoRealizado1 > 0 Then
                _PG.Execute("delete from atendimento_servico where id_atendimento_servico=" & idServicoRealizado1)
            Else
                If idServico1 > 0 Then
                    drServicos = _PG.DrQuery("SELECT id_servico, valor, valor_excedente, cobertura, consignacao FROM servico where id_servico=" & idServico1)
                    If drServicos.HasRows Then
                        drServicos.Read()
                        vnValorPrestador = CDec(mskValor.Text) * drServicos.Item(3) / 100
                        vnValorContribuinte = CDec(mskValor.Text) * drServicos.Item(4) / 100
                        _PG.Execute("INSERT INTO atendimento_servico (id_atendimento, id_servico, valor, valor_prestador, valor_contribuinte) values (" &
                         txtId.Text & ",'" & idServico1 & "', " & Replace(mskValor.Text, ",", ".") & "," & Replace(vnValorPrestador, ",", ".") & "," & Replace(vnValorContribuinte, ",", ".") & ");")
                    End If
                End If
            End If
        End If
        If idServico2 > 0 And idServicoRealizado2 > 0 Then
            drServicos = _PG.DrQuery("SELECT id_servico, valor, valor_excedente, cobertura, consignacao FROM servico where id_servico=" & idServico1)
            If drServicos.HasRows Then
                drServicos.Read()
                vnValorPrestador2 = CDec(mskValor2.Text) * drServicos.Item(3) / 100
                vnValorContribuinte2 = CDec(mskValor2.Text) * drServicos.Item(4) / 100
            End If
            _PG.Execute("update atendimento_servico  Set id_servico=" & idServico2 & ", valor=" & Replace(mskValor2.Text, ",", ".") & ", valor_prestador = " & Replace(vnValorPrestador2, ",", ".") & ", valor_contribuinte = " & Replace(vnValorContribuinte2, ",", ".") &
                " where id_atendimento_servico=" & idServicoRealizado2)
        Else
            If idServicoRealizado2 > 0 Then
                _PG.Execute("delete from atendimento_servico where id_atendimento_servico=" & idServicoRealizado2)
            Else
                If idServico2 > 0 Then
                    drServicos = _PG.DrQuery("SELECT id_servico, valor, valor_excedente, cobertura, consignacao FROM servico where id_servico=" & idServico1)
                    If drServicos.HasRows Then
                        drServicos.Read()
                        vnValorPrestador2 = CDec(mskValor2.Text) * drServicos.Item(3) / 100
                        vnValorContribuinte2 = CDec(mskValor2.Text) * drServicos.Item(4) / 100
                        _PG.Execute("INSERT INTO atendimento_servico (id_atendimento, id_servico, valor, valor_prestador, valor_contribuinte) values (" &
                                        txtId.Text & ",'" & idServico2 & "', " & Replace(mskValor2.Text, ",", ".") & "," & Replace(vnValorPrestador2, ",", ".") & "," & Replace(vnValorContribuinte2, ",", ".") & ");")
                    End If
                End If
            End If
        End If

        _PG.Execute("update atendimento set valor=" & Replace(mskTotal.Text, ",", ".") & ", id_medico = " & idMedico & ", dt_alteracao ='" & Format(CDate(txtDataConsulta.Text), "yyyy/MM/dd") & "'" & StrSituacao & " where id_atendimento=" & txtId.Text)

        _PG.Execute("commit")

        _PG.Desconectar()
        MsgBox("Atualização realizada com sucesso!")
        LimparFormulario()
        txtId.Focus()
erro:

        End Sub


    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        FrmUpload.idAtendimento = Val(txtId.Text)
        FrmUpload.Show()
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        LimparFormulario()
        txtId.Focus()
    End Sub

End Class