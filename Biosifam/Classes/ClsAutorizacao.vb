Public Class ClsAutorizacao
    Public IntAutorizacao As Integer

    Dim StrCodigoVerificacao As String
    Dim DsGeneric As DataSet

    Public Sub New()
        StrCodigoVerificacao = ""
    End Sub

    Public Function VerificaAutorizacao(IdPessoa As Integer) As Boolean
        IntAutorizacao = 0
        VerificaAutorizacao = False
        IntAutorizacao = Val(InputBox("Informe a Autorização em que será realizada a sessão de fisioterapia?", "Informe a autorização."))
        DsGeneric = _PG.DsQuery("Select id_pessoa, sessoes_autorizadas, sessoes_realizadas, tipo, situacao FROM atendimento_autorizacao WHERE id_atendimento_autorizacao=" & IntAutorizacao)
        If DsGeneric.Tables(0).Rows.Count > 0 Then
            If Trim(DsGeneric.Tables(0).Rows(0).Item("id_pessoa")) <> IdPessoa Then
                MsgBox("Autorização informada pertence a outro Paciente!")
                If ImpeditivosDeUso(DsGeneric) <> "" Then Exit Function
            End If
        Else
            MsgBox("Autorização informada não localizada! Verifique a informação.")
            Exit Function
        End If
        VerificaAutorizacao = True
    End Function

    Public Function GravarTrocaDeSituacao(IntAutorizacao As Long, StrNovaSituacao As String) As Boolean
        GravarTrocaDeSituacao = False
        Try
            If _PG.Conectar = False Then GoTo fim
            _PG.Execute("begin")
            _PG.Execute("update atendimento_autorizacao set situacao='" & StrNovaSituacao & "' where id_atendimento_autorizacao=" & IntAutorizacao)
            _PG.Execute("INSERT INTO historico (Tabela, operacao, valor, observacao, usuario, data, hora, ip) values " &
                  " ('atendimento_autorizacao','a', '" & IntAutorizacao & "', '" & StrNovaSituacao & "','" & frmLogin.TxtUsuario.Text & "', current_date, current_time,'" & _t.ObtemEnderecoIP & "');")
            _PG.Execute("commit")
            _PG.Desconectar()
            GravarTrocaDeSituacao = True
        Catch
        End Try
fim:
    End Function

    Public Function ImpeditivosDeUso(drGeneric As Npgsql.NpgsqlDataReader) As String
        ImpeditivosDeUso = ""
        If drGeneric("situacao") = "C" Then ImpeditivosDeUso = "Solicitação de Autorização está CANCELADA !"
        If drGeneric("situacao") = "P" Then ImpeditivosDeUso = "Solicitação de Autorização ainda não foi autorizada pela PREVPEL !"
        If drGeneric("situacao") = "N" Then ImpeditivosDeUso = "Solicitação de Autorização não foi autorizada pela PREVPEL !"
        If drGeneric("situacao") = "F" Then ImpeditivosDeUso = "Autorização já foi finalizada!"
        If drGeneric("tipo") <> "F" Then ImpeditivosDeUso = "Autorização informada não é para fisioterapias!"
        If drGeneric("sessoes_autorizadas") - drGeneric("sessoes_realizadas") <= 0 Then ImpeditivosDeUso = "Autorização já teve todas sessões realizadas!"
        If ImpeditivosDeUso <> "" Then MsgBox(ImpeditivosDeUso)

fim:
    End Function

    Public Function ImpeditivosDeUso(DsGeneric As DataSet) As String
        ImpeditivosDeUso = ""
        If DsGeneric.Tables(0).Rows(0).Item("situacao") = "P" Then ImpeditivosDeUso = "Solicitação de Autorização ainda não foi autorizada pela PREVPEL !"
        If DsGeneric.Tables(0).Rows(0).Item("situacao") = "N" Then ImpeditivosDeUso = "Solicitação de Autorização não foi autorizada pela PREVPEL !"
        If DsGeneric.Tables(0).Rows(0).Item("situacao") = "F" Then ImpeditivosDeUso = "Autorização já foi finalizada!"
        If DsGeneric.Tables(0).Rows(0).Item("tipo") <> "F" Then ImpeditivosDeUso = "Autorização informada não é para fisioterapias!"
        If DsGeneric.Tables(0).Rows(0).Item("sessoes_autorizadas") - DsGeneric.Tables(0).Rows(0).Item("sessoes_realizadas") <= 0 Then ImpeditivosDeUso = "Autorização já teve todas sessões realizadas!"
        If ImpeditivosDeUso <> "" Then MsgBox(ImpeditivosDeUso)

fim:
    End Function

    Public Function Situacao(strSituacao) As String
        Situacao = ""
        If strSituacao = "P" Then Situacao = "Pendente"
        If strSituacao = "A" Then Situacao = "Autorizado"
        If strSituacao = "C" Then Situacao = "Cancelado"
        If strSituacao = "N" Then Situacao = "Negada"
        If strSituacao = "F" Then Situacao = "Finalizada"
    End Function

    Public Function AutorizarViaSMS(_Pessoa As ClsPessoa, PStrCelular As String, vbModoBNI As Boolean) As Boolean
        AutorizarViaSMS = False
        If _Pessoa.Id = 0 Then
            MsgBox("Selecione primeiro um Paciente. ATENÇÃO o SMS será enviado ao celular do Titular.", vbInformation, "Impossível Prosseguir")
            Exit Function
        End If
        If PStrCelular <> "" Then
            If PStrCelular.Length < 11 Then
                MsgBox("O número do celular (" & PStrCelular & ") está sem prefixo ou mal formatado, procure o setor de Cadastro da PREVPEL para correção.", vbInformation, "Impossível Prosseguir")
                Exit Function
            End If
        Else
            MsgBox("Paciente não possui Celular Cadastrado", vbInformation, "Impossível Prosseguir")
            Exit Function
        End If

        ' 1 envia sms
        ' 2 recebe autorizacao
        ' 3 libera registro

        Dim _SMS As New ClsSMS
        _SMS.idCliente = 1
        _SMS.vsRemetente = _e.Nome
        _SMS.vsProvedorSMS = "" ' default
        If _SMS.Inicializa() = False Then Exit Function

        Dim Resposta As String
        Resposta = Val(InputBox("Selecione sua opção: " & Chr(13) & Chr(13) & "1 - Enviar SMS de confirmação para " & PStrCelular & Chr(13) & "2 - Informar código de autorização.", "", IIf(StrCodigoVerificacao = "", "1", "2")))

        If Resposta = 1 Then
            If vbModoBNI = False Then
                MsgBox("O SMS deve ser utilizado somente após 5 tentativas de leitura biométrica inválidas!", vbOKOnly, "Acesso não permitido")
                Exit Function
            End If
            'PStrCelular = "53981119138"
            _SMS.vsDestino = PStrCelular
            If MsgBox("Confirme o envio do código de autorização para " & _SMS.vsDestino, vbYesNo) = vbNo Then Exit Function

            'StrCodigoVerificacao = GetRandom(100000, 999999)

            ' nova sistema versao 2.2.27
            _PG.Conectar()
            _PG.Execute("begin") ' =============================================================================================================================================
            Dim StrSql As String = "insert into atendimento_autorizacao (matricula, id_prestador, id_pessoa, data, tipo, situacao, ip) values " &
                                   "(" & _Pessoa.Matricula & ", " & oMedicoConveniado.Id & ", " & _Pessoa.Id & ", current_date,'S','A','" & _t.ObtemEnderecoIP & "')"
            If _PG.Execute(StrSql) = False Then _PG.Desconectar() : Exit Function
            Dim drMax As Npgsql.NpgsqlDataReader
            drMax = _PG.DrQuery("select lastval()")
            If drMax.HasRows Then
                drMax.Read()
                StrCodigoVerificacao = drMax.Item(0)
            End If
            _PG.Execute("commit") ' =============================================================================================================================================
            _PG.Desconectar()

            _SMS.vsMensagem = " Código de autorização de registro : " & StrCodigoVerificacao
            _util.Log_Gravar("biosifam_sms_env", "Disparou envio SMS", False, _Pessoa.Id, oMedicoConveniado.Id)

            '0=sms, 1=SMS Interativo(Modo Flash), 2=SMS(Interativo), 5= whats Texto,6=Whatsapp(Imagem), 7=Whatsapp(Áudio), 8=Whatsapp(Vídeo), 99 email
            Call _SMS.EnviarMensagem(0)

            'AutorizarViaSMS = True

        ElseIf Resposta = 2 Then
            Resposta = InputBox("Informe código de Autorização para atendimento.", "")
            If Resposta = "" Then Exit Function
            If IsNumeric(Resposta) = False Then
                MsgBox("Informe apenas números.")
                Exit Function
            End If
            If StrCodigoVerificacao = "" Then
                MsgBox("O código de autorização expirou. Gere novo código.")
                Exit Function
            End If
            IntAutorizacao = Val(Resposta)
            If StrCodigoVerificacao = IntAutorizacao Then
                MsgBox("Código verificado com sucesso. " & Chr(13) & Chr(13) & "Clique em SALVAR Atendimento para registrar.")
                AutorizarViaSMS = True
                ' desativei para FACILITAR a usabilidade - SOMENTE ZERA A CADA TROCE DE MATRICULA
                'StrCodigoVerificacao = "" ' para ninguem mais utilizar 
            Else
                MsgBox("Código informado é inválido.")
            End If

            Dim drGeneric As Npgsql.NpgsqlDataReader
            _PG.Conectar()
            drGeneric = _PG.DrQuery("select data, matricula, id_prestador,id_pessoa, situacao, tipo, id_atendimento_autorizacao from atendimento_autorizacao where id_atendimento_autorizacao=" & IntAutorizacao)
            If drGeneric.HasRows Then
                drGeneric.Read()
                If drGeneric.Item(4) = "C" Then MsgBox("Autorização está cancelada.") : Exit Function
                If drGeneric.Item(4) = "F" Then MsgBox("Autorização já foi utilizada .") : Exit Function
                'vdDataAutorizacao = Format(drGeneric.Item(0), "dd/MM/yyyy")
                If drGeneric.Item(2) <> oMedicoConveniado.Id Then MsgBox("Esta autorização não foi solicitada para o médico atual. Verique com o Paciente o médico que ele selecionou na autorização.") : Exit Function
                If drGeneric.Item(3) <> _Pessoa.Id Then MsgBox("Esta autorização não foi solicitada para o paciente selecionado. Verique o Paciente que foi selecionado.") : Exit Function
                If drGeneric.Item("tipo") <> "S" Then MsgBox("Tipo de autorização não permitido.") : Exit Function
                If drGeneric.Item(0) <> CDate(Today.Date) Then MsgBox("A autorização informada só pode ser utilizada no dia em que foi gerada. ") : Exit Function
            End If
            _PG.Desconectar()
        Else
            If Resposta = 0 Then Exit Function
            MsgBox("Opção inválida.")
        End If

    End Function

    Public Function AutorizarViaQrCode(PidPessoa As Integer) As Boolean
        AutorizarViaQrCode = False
        If PidPessoa = 0 Then
            MsgBox("O paciente não foi informado, nesta situação, será exibido um QrCode para o Profissional selecionado e o paciente deverá selecionar no aplicativo do celular dele o paciente que será atendido. ", vbInformation, "QrCode do Conveniado")
            System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/qrcode.php?p=" & oMedicoConveniado.Id & "&pn=" & oMedicoConveniado.Nome)
            Exit Function
        End If

        ' 1 chama link qrcode e aguarda retorno do paciente com o código de acesso
        ' 2 recebe autorizacao
        ' 3 libera registro

        Dim Resposta As String
        Resposta = Val(InputBox("Selecione sua opção: " & Chr(13) & Chr(13) & "1 - Gerar QrCode de acesso" & Chr(13) & "2 - Informar código de autorização.", "", IIf(StrCodigoVerificacao = "", "1", "2")))

        If Resposta = 1 Then

            System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/qrcode.php?p=" & oMedicoConveniado.Id & "&p2=" & PidPessoa)

        ElseIf Resposta = 2 Then
            Resposta = InputBox("Informe código de Autorização para atendimento.", "")
            If Resposta = "" Then Exit Function
            If IsNumeric(Resposta) = False Then
                MsgBox("Informe apenas números.")
                Exit Function
            End If
            IntAutorizacao = Val(Resposta)
            Dim drGeneric As Npgsql.NpgsqlDataReader
            _PG.Conectar()
            drGeneric = _PG.DrQuery("select data, matricula, id_prestador,id_pessoa, situacao, tipo, id_atendimento_autorizacao from atendimento_autorizacao where id_atendimento_autorizacao=" & IntAutorizacao)
            If drGeneric.HasRows Then
                drGeneric.Read()
                If drGeneric.Item(4) = "C" Then MsgBox("Autorização está cancelada.") : Exit Function
                If drGeneric.Item(4) = "F" Then MsgBox("Autorização já foi utilizada .") : Exit Function
                'vdDataAutorizacao = Format(drGeneric.Item(0), "dd/MM/yyyy")
                If drGeneric.Item(2) <> oMedicoConveniado.Id Then MsgBox("Esta autorização não foi solicitada para o médico atual. Verique com o Paciente o médico que ele selecionou na autorização.") : Exit Function
                If drGeneric.Item(3) <> PidPessoa Then MsgBox("Esta autorização não foi solicitada para o paciente selecionado. Verique o Paciente que foi selecionado.") : Exit Function
                If drGeneric.Item("tipo") <> "Q" Then MsgBox("Tipo de autorização não permitido.") : Exit Function
                If drGeneric.Item(0) <> CDate(Today.Date) Then MsgBox("A autorização informada só pode ser utilizada no dia em que foi gerada. ") : Exit Function
                MsgBox("Código verificado com sucesso. " & Chr(13) & Chr(13) & "Clique em SALVAR Atendimento para registrar.")
                AutorizarViaQrCode = True
            Else
                MsgBox("Código informado não localizado.")
            End If
            _PG.Desconectar()
        Else
            If Resposta = 0 Then Exit Function
            MsgBox("Opção inválida.")
        End If

    End Function


    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' fazendo o Gerador static, preservamos a mesma instância
        ' assim não precisamos criar novas instância com a mesma semente 
        ' entre as chamadas
        Static Gerador As System.Random = New System.Random()
        Return Gerador.Next(Min, Max)
    End Function
End Class
