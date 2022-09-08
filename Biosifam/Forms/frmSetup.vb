Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Public Class frmSetup

    dim drSetup As Npgsql.NpgsqlDataReader
    dim drMedico As Npgsql.NpgsqlDataReader
    dim drMedicoBiosifam As Npgsql.NpgsqlDataReader

    ' variaveis publicas
    dim idMedicoP As Integer, idMedico1 As Integer, idMedico2 As Integer, idMedico3 As Integer, idMedico4 As Integer
    dim vsMedicoP As String, vsMedico1 As String, vsMedico2 As String, vsMedico3 As String, vsMedico4 As String

    Public vsTipoJuridico As String = "" ' fisica / juridica
    ReadOnly toolTip1 As New ToolTip

    Private sub frmSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _u.vbUsuarioSuporte = False Then
            MsgBox("Você não tem acesso a este formulário.")
            Me.Close()
            Exit Sub
        End If

        CarregaPrestadorBiosifam()

        ' Define o delay para a ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        ' Força a o texto da ToolTip a ser exibido mesmo que o form não esta ativo
        toolTip1.ShowAlways = True

    End Sub

    Public Sub CarregaPrestadorBiosifam()
        ' _PG.Conectar
        If _PG.Conectar = False Then Exit Sub
        Dim vsSql As String
        cmbMedicoP.Items.Clear() : cmbMedico1.Items.Clear() : cmbMedico2.Items.Clear() : cmbMedico3.Items.Clear() : cmbMedico4.Items.Clear()

        ' 0=retaguarda, 1-consulta digital
        dim vsFiltro As String = ""

        vsSql = "SELECT id_prestador, to_ascii(p.nome,'LATIN1'), to_ascii(s.nome ,'LATIN1') FROM prestador p left join especialidades s using (id_especialidades) where situacao='A' and usa_biosifam <> '' " & vsFiltro & " order by to_ascii(p.nome,'LATIN1') "
        drMedico = _PG.drQuery(vsSql)
        If drMedico.HasRows Then
            While drMedico.Read
                ' monta os combs com todos médicos
                cmbMedicoP.Items.Add(New ComboData(drMedico.Item(0).ToString, Trim(drMedico.Item(1).ToString) & ", " & Trim(drMedico.Item(2).ToString)))
                cmbMedico1.Items.Add(New ComboData(drMedico.Item(0).ToString, Trim(drMedico.Item(1).ToString) & ", " & Trim(drMedico.Item(2).ToString)))
                cmbMedico2.Items.Add(New ComboData(drMedico.Item(0).ToString, Trim(drMedico.Item(1).ToString) & ", " & Trim(drMedico.Item(2).ToString)))
                cmbMedico3.Items.Add(New ComboData(drMedico.Item(0).ToString, Trim(drMedico.Item(1).ToString) & ", " & Trim(drMedico.Item(2).ToString)))
                cmbMedico4.Items.Add(New ComboData(drMedico.Item(0).ToString, Trim(drMedico.Item(1).ToString) & ", " & Trim(drMedico.Item(2).ToString)))
            End While
        End If

        If _w.idPrestador = 0 Then
            MsgBox("Estação sem médico vinculado")
            Exit Sub
        End If

        idMedicoP = _w.idPrestador
        If idMedicoP > 0 Then
            drMedico = _PG.drQuery("SELECT * FROM prestador_biosifam WHERE id_prestador = " & idMedicoP)
            If drMedico.HasRows Then
                drMedico.Read()
                idMedico1 = drMedico.Item("id_medicos1")
                idMedico2 = drMedico.Item("id_medicos2")
                idMedico3 = drMedico.Item("id_medicos3")
                idMedico4 = drMedico.Item("id_medicos4")
            End If
        End If

        If idMedicoP > 0 Then idMedicoP = PosicionaCombo(cmbMedicoP, idMedicoP)
        If idMedico1 > 0 Then idMedico1 = PosicionaCombo(cmbMedico1, idMedico1)
        If idMedico2 > 0 Then idMedico2 = PosicionaCombo(cmbMedico2, idMedico2)
        If idMedico3 > 0 Then idMedico3 = PosicionaCombo(cmbMedico3, idMedico3)
        If idMedico4 > 0 Then idMedico4 = PosicionaCombo(cmbMedico4, idMedico4)
        ' Define o texto da ToolTip para o Button, TextBox, Checkbox e Label
        toolTip1.SetToolTip(Me.cmbMedicoP, "Id. " & idMedicoP)
        toolTip1.SetToolTip(Me.cmbMedico1, "Id. " & idMedico1)
        toolTip1.SetToolTip(Me.cmbMedico2, "Id. " & idMedico2)
        toolTip1.SetToolTip(Me.cmbMedico3, "Id. " & idMedico3)
        toolTip1.SetToolTip(Me.cmbMedico4, "Id. " & idMedico4)
fim:
        ' _pg.Desconectar()
    End Sub

    private sub LimpaSetup()

         idMedicoP = 0 : vsMedicoP = ""
        _w.Modo = "1"    ' consulta = default
        chkEmail.Checked = False : chkVoz.Checked = False : chkLoginBiometrico.Checked = False : chkLogLocal.Checked = False
        idMedico1 = 0 : idMedico2 = 0 : idMedico3 = 0 : idMedico4 = 0
        CarregaPrestadorBiosifam()

    End Sub

    private sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        If idMedicoP = 0 Then GoTo salvarmodo

        If idMedicoP = 0 And _w.Modo <> "0" Then MsgBox("Médico principal não pode ser zero") : Exit Sub
        If idMedicoP > 0 Then
            If idMedicoP = idMedico1 Or idMedicoP = idMedico2 Or idMedicoP = idMedico3 Or idMedicoP = idMedico4 Then MsgBox("Não são permitidos Médicos duplicados") : Exit Sub
            If idMedicoP = idMedico1 Or idMedicoP = idMedico2 Or idMedicoP = idMedico3 Then MsgBox("Não são permitidos Médicos duplicados") : Exit Sub
        End If
        If idMedico1 > 0 Then If idMedico1 = idMedico2 Or idMedico1 = idMedico3 Or idMedico1 = idMedico4 Then MsgBox("Não são permitidos Médicos duplicados") : Exit Sub
        If idMedico2 > 0 Then If idMedico2 = idMedico3 Or idMedico2 = idMedico4 Then MsgBox("Não são permitidos Médicos duplicados") : Exit Sub
        If idMedico3 > 0 Then If idMedico3 = idMedico4 Then MsgBox("Não são permitidos Médicos duplicados") : Exit Sub
        If cmbMedico1.SelectedItem Is Nothing Then idMedico1 = 0
        If cmbMedico2.SelectedItem Is Nothing Then idMedico2 = 0
        If cmbMedico3.SelectedItem Is Nothing Then idMedico3 = 0
        If cmbMedico4.SelectedItem Is Nothing Then idMedico4 = 0

        dim vsQuery As String

        vsQuery = " usa_email='" & IIf(chkEmail.Checked, "1", "0") & "'"
        vsQuery &= ", usa_voz='" & IIf(chkVoz.Checked, "1", "0") & "'"
        vsQuery &= ", usa_login_biometrico='" & IIf(chkLoginBiometrico.Checked, "1", "0") & "'"
        vsQuery &= ", usa_log_local='" & IIf(chkLogLocal.Checked, "1", "0") & "'"
        vsQuery &= ", id_medicos1=" & idMedico1
        vsQuery &= ", id_medicos2=" & idMedico2
        vsQuery &= ", id_medicos3=" & idMedico3
        vsQuery &= ", id_medicos4=" & idMedico4
        vsQuery &= ", login='" & _u.login & "'"
        vsQuery &= ", ip='" & _t.ObtemEnderecoIP & "'"
        vsQuery &= ", dt_alteracao=current_date"
        vsQuery &= ", hr_alteracao=SUBSTRING(current_time::text, 1, 5)"

        dim vnIdAux As Integer
        vnIdAux = VerificaMedicoSetupOutros(idMedicoP, "id_medicos")
        If vnIdAux > 0 Then
            If MsgBox("Deseja utilizar o SETUP já existente do Médico (id " & vnIdAux & ") ? ", vbYesNo, "") = vbYes Then
                '_PG.id_BiosifamSetup = vnIdAux
                idMedicoP = vnIdAux
            End If
            'Exit Sub
        End If

        If idMedico1 > 0 Then VerificaMedicoSetupOutros(idMedico1, "id_medicos1")
        If idMedico2 > 0 Then VerificaMedicoSetupOutros(idMedico2, "id_medicos2")
        If idMedico3 > 0 Then VerificaMedicoSetupOutros(idMedico3, "id_medicos3")
        If idMedico4 > 0 Then VerificaMedicoSetupOutros(idMedico4, "id_medicos4")
        If _PG.Conectar = False Then Exit Sub

        drMedicoBiosifam = _PG.drQuery("SELECT * FROM prestador_biosifam WHERE id_prestador=" & idMedicoP)
        If drMedicoBiosifam.HasRows Then
            drMedicoBiosifam.Read()
            _PG.execute("update prestador_biosifam set " & vsQuery & " where id_prestador_biosifam=" & drMedicoBiosifam.Item("id_prestador_biosifam"))
        Else
            _PG.execute("insert into prestador_biosifam (id_prestador, usa_email, usa_voz, usa_login_biometrico, usa_log_local, id_medicos1, " &
                                "id_medicos2, id_medicos3, id_medicos4, login, ip, dt_alteracao, hr_alteracao, libera_update, expirar, situacao, ultimo_acesso, modo) values " &
                          "(" & idMedicoP & ",'" & IIf(chkEmail.Checked, "1", "0") & "','" & IIf(chkVoz.Checked, "1", "0") & "','" & IIf(chkLoginBiometrico.Checked, "1", "0") &
                          "','" & IIf(chkLogLocal.Checked, "1", "0") & "'," & idMedico1 & "," & idMedico2 & "," & idMedico3 & "," & idMedico4 & ",'" & _u.Nome & "','" & _t.ObtemEnderecoIP & "', CURRENT_DATE, SUBSTRING(current_time::text, 1, 5),true,0,'0',current_timestamp," & _w.Modo & ")")
            MsgBox(" Nova Configuração atualizada com sucesso !", MsgBoxStyle.Information, "")
        End If

SalvarModo:
        _pg.Desconectar()
        MsgBox(" Configuração encerrada com sucesso !", MsgBoxStyle.Information, "")
        frmMain.ConfiguraForm()
        Me.Hide()
    End Sub


    private function VerificaMedicoSetupOutros(ByVal idMedico As Integer, ByVal vsCampoMedico As String) As Integer
        VerificaMedicoSetupOutros = 0
        If _PG.Conectar = False Then Exit Function
        If idMedico > 0 Then
            dim vsNomeMedico As String = ""
            'drMedico = _PG.drQuery("SELECT * FROM biosifam_setup WHERE id_biosifam_setup <> " & Val(txtIdSetup.Text) & " and " & vsCampoMedico & "=" & idMedico)
            drMedico = _PG.drQuery("SELECT * FROM prestador_biosifam WHERE id_prestador <> " & idMedico & " and (id_medicos1=" & idMedico & " or id_medicos2=" & idMedico & " or id_medicos3=" & idMedico & " or id_medicos4=" & idMedico & ")")
            If drMedico.HasRows Then
                drMedico.Read()
                If vsCampoMedico = "id_medicos" Then vsNomeMedico = cmbMedicoP.SelectedItem.ToString
                If vsCampoMedico = "id_medicos1" Then vsNomeMedico = cmbMedico1.SelectedItem.ToString
                If vsCampoMedico = "id_medicos2" Then vsNomeMedico = cmbMedico2.SelectedItem.ToString
                If vsCampoMedico = "id_medicos3" Then vsNomeMedico = cmbMedico3.SelectedItem.ToString
                If vsCampoMedico = "id_medicos4" Then vsNomeMedico = cmbMedico4.SelectedItem.ToString
                MsgBox("O médico " & vsNomeMedico & " já está cadastrado em outro um SETUP de configuração (id." & drMedico.Item(0) & ").")
                VerificaMedicoSetupOutros = drMedico.Item("id_prestador_biosifam")
                _pg.Desconectar()
                Exit Function
            End If
        End If
        _pg.Desconectar()

    End Function

    private function PosicionaCombo(ByVal cmbCombo As ComboBox, ByVal idMedico As Integer) As Long
        PosicionaCombo = 0
        dim i As Integer
        If cmbCombo.Items.Count = 0 Then Exit Function
        ' medico nunca vem com ZERO, é testado antes
        ' naõ encontrou o medico, o mesmo pode estar suspenso ou nao habilitado para o biosifam
        drMedico = _PG.DrQuery("SELECT id_prestador, to_ascii(nome,'LATIN1') FROM prestador WHERE id_prestador=" & idMedico)
        On Error Resume Next
        cmbCombo.SelectedIndex = -1
        If drMedico.HasRows Then
            drMedico.Read()
            If drMedico.Item("situacao") <> "A" Then
                MsgBox("O médico atualmente configurado, id." & idMedico & ", " & Trim(drMedico.Item("nome")) & " está desabilitado ou suspenso, por favor verifique a situação.")
                idMedico = 0
            Else
                PosicionaCombo = idMedico
                idMedico = drMedico.Item("id_prestador")
                For i = 0 To cmbCombo.Items.Count - 1
                    cmbCombo.SelectedIndex = i
                    If CType(cmbCombo.SelectedItem, ComboData).Id = idMedico Then
                        Exit Function
                    End If
                Next
            End If
        Else
            MsgBox("O sistema não encontrou o médico atualmente configurado, id." & idMedico & ", " & Trim(drMedico.Item("nome")) & ". Ele pode estar desabilitado ou suspenso, por favor verifique a situação.")
            idMedico = 0
        End If
    End Function

    private sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        _pg.Desconectar()
        frmMain.ConfiguraForm()
        Me.Close()
        Exit Sub
    End Sub

    private sub cmbMedicoP_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMedicoP.SelectedIndexChanged
        idMedicoP = CType(cmbMedicoP.SelectedItem, ComboData).Id
        If InStr(CType(cmbMedicoP.SelectedItem, ComboData).Descricao, ",") > 0 Then
            vsMedicoP = Mid(CType(cmbMedicoP.SelectedItem, ComboData).Descricao, 1, InStr(CType(cmbMedicoP.SelectedItem, ComboData).Descricao, ",") - 1)
        Else
            vsMedicoP = CType(cmbMedicoP.SelectedItem, ComboData).Descricao
        End If
        toolTip1.SetToolTip(Me.cmbMedicoP, "Id. " & idMedicoP)


    End Sub
    private sub cmbMedico1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMedico1.KeyPress

    End Sub

    private sub cmbMedico1_MouseCaptureChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMedico1.MouseCaptureChanged

    End Sub
    private sub cmbMedico1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMedico1.SelectedIndexChanged
        idMedico1 = CType(cmbMedico1.SelectedItem, ComboData).Id
        If InStr(CType(cmbMedico1.SelectedItem, ComboData).Descricao, ",") > 0 Then
            vsMedico1 = Mid(CType(cmbMedico1.SelectedItem, ComboData).Descricao, 1, InStr(CType(cmbMedico1.SelectedItem, ComboData).Descricao, ",") - 1)
        Else
            vsMedico1 = CType(cmbMedico1.SelectedItem, ComboData).Descricao
        End If
        toolTip1.SetToolTip(Me.cmbMedico1, "Id. " & idMedico1)
    End Sub


    private sub cmbMedico2_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMedico2.SelectedIndexChanged
        idMedico2 = CType(cmbMedico2.SelectedItem, ComboData).Id
        If InStr(CType(cmbMedico2.SelectedItem, ComboData).Descricao, ",") > 0 Then
            vsMedico2 = Mid(CType(cmbMedico2.SelectedItem, ComboData).Descricao, 1, InStr(CType(cmbMedico2.SelectedItem, ComboData).Descricao, ",") - 1)
        Else
            vsMedico2 = CType(cmbMedico2.SelectedItem, ComboData).Descricao
        End If
        toolTip1.SetToolTip(Me.cmbMedico2, "Id. " & idMedico2)
    End Sub


    private sub cmbMedico3_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMedico3.SelectedIndexChanged
        idMedico3 = CType(cmbMedico3.SelectedItem, ComboData).Id
        If InStr(CType(cmbMedico3.SelectedItem, ComboData).Descricao, ",") > 0 Then
            vsMedico3 = Mid(CType(cmbMedico3.SelectedItem, ComboData).Descricao, 1, InStr(CType(cmbMedico3.SelectedItem, ComboData).Descricao, ",") - 1)
        Else
            vsMedico3 = CType(cmbMedico3.SelectedItem, ComboData).Descricao
        End If
        toolTip1.SetToolTip(Me.cmbMedico3, "Id. " & idMedico3)
    End Sub

    private sub cmbMedico4_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMedico4.SelectedIndexChanged
        idMedico4 = CType(cmbMedico4.SelectedItem, ComboData).Id
        If InStr(CType(cmbMedico4.SelectedItem, ComboData).Descricao, ",") > 0 Then
            vsMedico4 = Mid(CType(cmbMedico4.SelectedItem, ComboData).Descricao, 1, InStr(CType(cmbMedico4.SelectedItem, ComboData).Descricao, ",") - 1)
        Else
            vsMedico4 = CType(cmbMedico4.SelectedItem, ComboData).Descricao
        End If
        toolTip1.SetToolTip(Me.cmbMedico4, "Id. " & idMedico4)
    End Sub

    private sub cmbMedicoP_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMedicoP.LostFocus
        If cmbMedicoP.SelectedItem Is Nothing Then idMedicoP = 0 : vsMedicoP = ""
    End Sub
    private sub cmbMedico1_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMedico2.LostFocus
        If cmbMedico1.SelectedItem Is Nothing Then idMedico1 = 0 : vsMedico1 = ""
    End Sub
    private sub cmbMedico2_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMedico2.LostFocus
        If cmbMedico2.SelectedItem Is Nothing Then idMedico2 = 0 : vsMedico2 = ""
    End Sub
    private sub cmbMedico3_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMedico3.LostFocus
        If cmbMedico3.SelectedItem Is Nothing Then idMedico3 = 0 : vsMedico3 = ""
    End Sub
    private sub cmbMedico4_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMedico4.LostFocus
        If cmbMedico4.SelectedItem Is Nothing Then idMedico4 = 0 : vsMedico4 = ""
    End Sub


End Class