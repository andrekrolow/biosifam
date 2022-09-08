Imports System.Net
Imports System.IO
Public Class cUpdate
    ReadOnly RemoteUrl As String = "http://downloads.pelotas.com.br/biosifam/"   ' the web location of the files
    Public VersãoInstalada As String = Application.ProductVersion

    Public Function VerificaVersao(ByVal vsNomeNovoExecutavel As String) As String
        Dim fvi As System.Diagnostics.FileVersionInfo
        fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath & "\" & vsNomeNovoExecutavel)
        VerificaVersao = fvi.FileVersion
    End Function

    ' logs a apagar no banco de dados - da verificação anterior
    '    _util.Log_Gravar("biosifam_vnv1", "Atualização verificando nova versão no site", False, 0, idPrestador)
    '    _util.Log_Gravar("biosifam_update3", "Atualização automática desabilitada", False, 0, idPrestador)
    '    _util.Log_Gravar("biosifam_update4", "Iniciando download nova versão", VbGlo_Console, 0, idPrestador)
    '    _util.Log_Gravar("biosifam_update6", "Erro ao buscar nova versão", VbGlo_Console, 0, idPrestador)

    Public Function VerificaAtualizacoes() As Boolean
        VerificaAtualizacoes = False
        ' simplifiquei o processo de atualizaçao - 06/10/2021 - versao 2.2.02
        ' 1 não verifico mais a ultima versao no postgres, agora é no arquivo ultima_versao.txt na pagina do biosifam, rotina VerificaNovaVersão desativada
        ' 2 não verifico mais autorizacao para atualização, TODOS vão atualizar
        ' 3 verificação e atualizações ocorrem antes de qualuqer processo, a fim de evitar que outros processos impeçam a atualização

        ' se alguns dos arquivos nao estiver prsente busca e atualiza - projetar para buscar somente se der erro
        DownloadGenerico(VbGlo_Console, _w.idPrestador, "biosifam.exe.config", Application.StartupPath & "\", Application.StartupPath & "\", False, False, False)
        DownloadGenerico(VbGlo_Console, _w.idPrestador, "biosifam_ultima_versao.txt", Application.StartupPath & "\", Application.StartupPath & "\", False, True, False)

        Dim ArquivoVersao As IO.StreamReader, StrLinha As String = ""
        If IO.File.Exists(Application.StartupPath & "\" & "biosifam_ultima_versao.txt") Then
            ArquivoVersao = New IO.StreamReader(Application.StartupPath & "\" & "biosifam_ultima_versao.txt")
            Try
                StrLinha = ArquivoVersao.ReadLine
                ArquivoVersao.Close()
                If VerificaVersao("biosifam.exe") < StrLinha Then
                    ' traz o arquvio de senha antes, isso permite a cada nova versao substituir as senhas
                    DownloadGenerico(VbGlo_Console, _w.idPrestador, "biosifam.exe.config", Application.StartupPath & "\", Application.StartupPath & "\", False, True, False)
                    DownloadGenerico(VbGlo_Console, _w.idPrestador, "biosifam.exe", Application.StartupPath & "\", Application.StartupPath & "\", True, True, True)
                End If
            Catch ex As Exception
                vbResult = _s.GravaLogTXT(_u.Login, _w.Nome, "", "cUpdate.VerificaAtualizacoes", "Erro ao verificar atualizações - ", ex.Message, False)
            End Try
        End If
    End Function

    Public Function DownloadGenerico(ByVal VbGlo_Console As Boolean, ByVal idPrestador As Long, ByVal StrProgramaExe As String, ByVal StrPathOrigem As String, ByVal StrPathDestino As String, ByVal BolEncerrarAposDownload As Boolean, ByVal BolForcaAtualizacao As Boolean, ByVal BolManterVersaoAnterior As Boolean) As Boolean
        ' ideia que que quando falte algum componente o erro possa sugerir uma atualizacao dele.
        DownloadGenerico = False
        Dim myWebClient As New WebClient ' the web client
        Dim StrNomeArquivoAnterior As String = ""
        Try
            If IO.File.Exists(StrPathOrigem & StrProgramaExe) = False Or BolForcaAtualizacao Then
                vbResult = _s.GravaLogTXT("", "", vsGlo_Log, "cUpdate.DownloadGenerico", "Iniciando download " & StrProgramaExe, False)
                If idPrestador > 0 Then _util.Log_Gravar("download_iniciado", "Iniciando download " & StrProgramaExe, True, 0, idPrestador)

                If BolForcaAtualizacao And IO.File.Exists(StrPathOrigem & StrProgramaExe) Then
                    If BolManterVersaoAnterior Then
                        File.Move(StrPathOrigem & StrProgramaExe, StrPathOrigem & StrProgramaExe & IIf(StrProgramaExe = "biosifam.exe", "_" & VerificaVersao("biosifam.exe"), "") & "_" & Format(Date.Today, "yyyyMMdd") & Format(Date.Now, "hhmmss"))
                    Else
                        StrNomeArquivoAnterior = StrPathOrigem & "_" & StrProgramaExe & IIf(StrProgramaExe = "biosifam.exe", "_" & VerificaVersao("biosifam.exe"), "") & "_" & Format(Date.Today, "yyyyMMdd") & Format(Date.Now, "hhmmss")
                        File.Move(StrPathOrigem & StrProgramaExe, StrNomeArquivoAnterior)
                    End If
                End If
                myWebClient.DownloadFile(RemoteUrl & StrProgramaExe, StrPathDestino & StrProgramaExe)
                vbResult = _s.GravaLogTXT("", "", vsGlo_Log, "cUpdate.DownloadGenerico", "", StrProgramaExe & " atualizado com Sucesso.", False)
                If idPrestador > 0 Then _util.Log_Gravar("download_concluido", StrProgramaExe & "  atualizado com Sucesso. ", True, 0, idPrestador)
                If BolManterVersaoAnterior = False And StrNomeArquivoAnterior <> "" Then File.Delete(StrNomeArquivoAnterior)
                If BolEncerrarAposDownload Then MsgBox("O aplicativo foi atualizado e será encerrado para carga da nova versão.") : End
            End If
        Catch ex As Exception
            vbResult = _s.GravaLogTXT("", _w.Nome, vsGlo_Log, "cUpdate.DownloadGenerico", "Erro ao buscar " & StrProgramaExe & "," & ex.Message, False)
            If idPrestador > 0 Then _util.Log_Gravar("download_erro", "Erro ao buscar nova versão", VbGlo_Console, 0, idPrestador)
            If MsgBox("Ocorreu um erro ao tentar atualizar o aplicativo " & StrProgramaExe & ", deseja localiza-lo no site oficial do aplicativo ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                System.Diagnostics.Process.Start(RemoteUrl & StrProgramaExe)
            Else
                If MsgBox("Deseja tentar um download automatico no site oficial do aplicativo ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                    ' tem de estar em selfextract, dai nao precisa escolher o local
                    System.Diagnostics.Process.Start(RemoteUrl & StrProgramaExe & ".exe")
                End If
            End If
        End Try

        DownloadGenerico = True

    End Function

End Class
