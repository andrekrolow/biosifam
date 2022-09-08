Public Class frmAjuda
    dim idMedicoVinculado As Long, vsMedicoVinculado As String
    dim toolTip1 As New ToolTip
    Dim vsFiltro As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Define o delay para a ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        ' Força a o texto da ToolTip a ser exibido mesmo que o form não esta ativo
        toolTip1.ShowAlways = True

    End Sub

    Private sub frmAjuda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _u.vbUsuarioSuporte = False And _u.vbUsuarioPrevpel = False Then
            MsgBox("Você não tem acesso a este formulário.")
            Me.Close()
            Exit Sub
        End If

        txtIdSetup.Text = _w.idWorkstation
        txtVersao.Text = _w.Versao
        txtLicenca.Text = Trim(NumeroLicençaGriaule())
        txtMAC.Text = Trim(_t.ObtemMAC)
        txtUltimaAtualizacao.Text = _w.UltimaAtualizacao
        cmbModo.SelectedIndex = _w.Modo
        If _w.idPrestador > 0 Then
            idMedicoVinculado = _w.idPrestador
            btnEstacao.Enabled = True
        End If
        If idMedicoVinculado > 0 Then idMedicoVinculado = PosicionaCombo(cmbMedicoVinculado, idMedicoVinculado)

    End Sub

    private sub cmbModo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModo.SelectedIndexChanged
        If cmbModo.SelectedIndex = 0 Then
            cmbMedicoVinculado.Text = ""
        End If
        If cmbModo.SelectedIndex > 0 And _w.Modo <> cmbModo.SelectedIndex Then
            _w.Modo = cmbModo.SelectedIndex
            cmbMedicoVinculado.Text = ""
            cmbMedicoVinculado.Items.Clear()
            idMedicoVinculado = 0
            vsMedicoVinculado = ""
        End If

        ' campo categoria passou a indicar tipo de servico no biosifam - versao 2.2.11 - 23/12/2021

        If cmbModo.SelectedIndex = 1 Then                                                                                            ' Consultorio Medico
        End If
        If cmbModo.SelectedIndex = 2 Then                                                                                            ' Consultorio Medico
            vsFiltro = " and (categoria='M' or categoria='O')  "
            lblMedico.Text = "Prestadores conveniados:"
        End If
        If cmbModo.SelectedIndex = 3 Then
            vsFiltro = " and (categoria='3' or categoria='4') "                      ' Clínicas e Laboratorios
            lblMedico.Text = "Laboratórios conveniados:"
        End If
        If cmbModo.SelectedIndex = 4 Then
            vsFiltro = " and categoria='2' "                                             ' Pronto Atendimento
            lblMedico.Text = "Hospitais conveniados :"
        End If
        If cmbModo.SelectedIndex = 5 Then
            vsFiltro = " and categoria='1' "                          ' Hospitalar 
            lblMedico.Text = "Hospitais conveniados :"
        End If
        vsFiltro &= " and categoria<>'7' and tipo_vinculo<>'V' and tipo_vinculo<>'SV' "    ' excluir médicos vnculados, Vvinculado a outro, SV sem vinculo

        If cmbMedicoVinculado.SelectedItem Is Nothing Then
            idMedicoVinculado = 0
            vsMedicoVinculado = ""
            ' Define o texto da ToolTip para o Button, TextBox, Checkbox e Label
            toolTip1.SetToolTip(Me.cmbMedicoVinculado, " ")

            _t.CarregaCombo(cmbMedicoVinculado, "SELECT id_prestador, to_ascii(p.nome,'LATIN1')  FROM prestador p left join especialidades s using (id_especialidades) where situacao='A' and usa_biosifam <> '' " & vsFiltro & " order by to_ascii(p.nome,'LATIN1') ")

            idMedicoVinculado = PosicionaCombo(cmbMedicoVinculado, idMedicoVinculado)
            ' Define o texto da ToolTip para o Button, TextBox, Checkbox e Label
            toolTip1.SetToolTip(Me.cmbMedicoVinculado, "Id. " & idMedicoVinculado)
        End If

    End Sub

    private sub cmbMedicoVinculado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMedicoVinculado.LostFocus
        If cmbMedicoVinculado.SelectedItem Is Nothing Then idMedicoVinculado = 0 : vsMedicoVinculado = ""
    End Sub

    private sub cmbMedicoVinculado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMedicoVinculado.SelectedIndexChanged
        If cmbMedicoVinculado.SelectedItem Is Nothing Then idMedicoVinculado = 0 : vsMedicoVinculado = "" : Exit Sub
        idMedicoVinculado = CType(cmbMedicoVinculado.SelectedItem, ComboData).Id
        If InStr(CType(cmbMedicoVinculado.SelectedItem, ComboData).Descricao, ",") > 0 Then
            vsMedicoVinculado = Mid(CType(cmbMedicoVinculado.SelectedItem, ComboData).Descricao, 1, InStr(CType(cmbMedicoVinculado.SelectedItem, ComboData).Descricao, ",") - 1)
        Else
            vsMedicoVinculado = CType(cmbMedicoVinculado.SelectedItem, ComboData).Descricao
        End If
        toolTip1.SetToolTip(Me.cmbMedicoVinculado, "Id. " & idMedicoVinculado)

    End Sub

    private sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

        If cmbMedicoVinculado.Text = "" Then idMedicoVinculado = 0 : vsMedicoVinculado = ""

        ' vincula configuracao a estacao de trabalho
        _w.idPrestador = idMedicoVinculado
        _w.Modo = cmbModo.SelectedIndex
        vnGlo_ModoAtual = cmbModo.SelectedIndex
        _w.AtualizaWorkstation()
        MsgBox("Atualização realizada com sucesso.")

        _u.BuscarDados(_u.Login)
        _u.BuscarDadosTipoFamiliar()
        _u.BuscarGrupos()

        frmMain.ConfiguraForm()
        Me.Close()
    End Sub

    private sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        _pg.Desconectar()
        frmMain.ConfiguraForm()
        Me.Close()
    End Sub

    Private Sub btnEstacao_Click(sender As Object, e As EventArgs) Handles btnEstacao.Click
        _PG.Conectar()
        _PG.Execute("UPDATE workstation set id_prestador=0 where mac='" & txtMAC.Text & "'")
        _PG.Desconectar()
        '"70:69:79:A6:C5:31"
        _u.IdPrestador = 0
        _w.Carregar(txtMAC.Text)
        cmbMedicoVinculado.SelectedIndex = -1
        MsgBox("Atualização realizada com sucesso.")

        _u.BuscarDados(frmLogin.TxtUsuario.Text)
        _u.BuscarDadosTipoFamiliar()
        _u.BuscarGrupos()
        frmMain.ConfiguraForm()

Fim:
        Me.Close()

    End Sub

    Private Sub cmbModo_Click(sender As Object, e As EventArgs) Handles cmbModo.Click

    End Sub

    Private Function PosicionaCombo(ByVal cmbCombo As ComboBox, ByVal idMedico As Integer) As Long
        PosicionaCombo = 0
        Dim i As Integer

        If cmbCombo.Items.Count = 0 Then Exit Function
        If idMedico = 0 Then Exit Function

        ' medico nunca vem com ZERO, é testado antes
        ' naõ encontrou o medico, o mesmo pode estar suspenso ou nao habilitado para o biosifam

        cmbCombo.SelectedIndex = -1

        Dim ds As New DataSet
        ds = _PG.DsQuery("SELECT id_prestador, to_ascii(nome,'LATIN1') as nome, situacao FROM prestador WHERE id_prestador=" & idMedico)
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("situacao") <> "A" Then
                MsgBox("O médico atualmente configurado, id." & idMedico & ", " & Trim(ds.Tables(0).Rows(0).Item("nome")) & " está desabilitado ou suspenso, por favor verifique a situação.")
                idMedico = 0
            Else
                PosicionaCombo = idMedico
                idMedico = ds.Tables(0).Rows(0).Item("id_prestador")
                For i = 0 To cmbCombo.Items.Count - 1
                    cmbCombo.SelectedIndex = i
                    If CType(cmbCombo.SelectedItem, ComboData).Id = idMedico Then
                        Exit Function
                    End If
                Next
            End If
        Else
            MsgBox("O sistema não encontrou o médico atualmente configurado, id." & idMedico & ", " & Trim(ds.Tables(0).Rows(0).Item("nome")) & ". Ele pode estar desabilitado ou suspenso, por favor verifique a situação.")
            idMedico = 0
        End If

    End Function

End Class