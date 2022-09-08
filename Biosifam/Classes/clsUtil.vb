'SIFAM - Sistema Informatizado do Fundo de Assistência Médica
'cUtil - classe contendo objeto exclusivo do biosifam
'				Copyright (c) 2010 COINPEL
'     Descrição : Classe Util
'     Autor:  Cauê Duarte (caueduar@gmail.com)
'     Criação:   24/08/2010
'     Modificação:  24/08/2010

Imports System.Net
Imports System.Net.Dns
Imports System.Management   'usada para pegar o mac

Public Class clsUtil
    dim vsAppBaixado As String = ""
    Dim vnAtingiu(10) As Integer

    Public Sub Mensagem_LogLocal(ByVal Mensagem As String, ByVal MostrarMensagem As Boolean, ByVal NomeAplicativoGerador As String, ByVal GravarLog As Boolean, ByVal NomeLog As String)
        If NomeLog = "" Then NomeLog = "biosifam.log" Else NomeLog = NomeLog & ".log"
        If MostrarMensagem = True Then MsgBox(Mensagem, vbOKOnly, NomeAplicativoGerador)
        If GravarLog = True Then
            Try
                If System.IO.File.Exists(System.Windows.Forms.Application.StartupPath & "\" & NomeLog) Then
                    dim ArquivoTexto As New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\" & NomeLog, True)
                    ArquivoTexto.WriteLine(Date.Now.ToShortDateString() & Space(2) & Date.Now.ToShortTimeString() & "hs" & " - " & Mensagem)
                    ArquivoTexto.Close()
                Else
                    'já existe, append
                    dim ArquivoTexto As New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\" & NomeLog)
                    ArquivoTexto.WriteLine(Date.Now.ToShortDateString() & Space(2) & Date.Now.ToShortTimeString() & "hs" & " - " & Mensagem)
                    ArquivoTexto.Close()
                End If

            Catch ex1 As Exception
                MsgBox("Erro ao tentar criar o arquivo de LOG (" & NomeLog & "). " & vbCrLf & "Erro -> " & Err.Description & " - " & Err.Number)
            End Try
        End If
    End Sub

    Public Sub Log_Gravar(ByVal Fonte As String, ByVal Descricao As String, ByVal vbMostraLog As Boolean, ByVal idSelecionado As String, ByVal idMedico As Integer)
        Dim idAplicativo As Long = 0
        Dim drGeneric As Npgsql.NpgsqlDataReader
        Try
            _PG.Conectar()
            drGeneric = _PG.DrQuery("select codaplicacao from aplicacao where fonte='" & Fonte & "'")
            If drGeneric.HasRows Then
                drGeneric.Read()
                idAplicativo = drGeneric.Item(0)
            Else
                _util.Mensagem_LogLocal("criado aplicativo-" & Fonte, False, "Log_Gravar", True, "")
                _PG.Execute("insert into aplicacao (superior, fonte, descricao, tipo, situacao) values (0, '" & Fonte & "','" & Descricao & "', 'a',1)")
                drGeneric = _PG.DrQuery("select codaplicacao from aplicacao where fonte='" & Fonte & "'")
                If drGeneric.HasRows Then
                    drGeneric.Read()
                    idAplicativo = drGeneric.Item(0)
                End If
            End If
            If idAplicativo = 0 Then
                _util.Mensagem_LogLocal("erro ao localizar aplicativo-" & Fonte & "-" & Descricao, False, "Log_Gravar", True, "")
            Else
                'idSelecionado = idSelecionado.Substring(0, 99)
                _PG.Execute("insert into LOG (codaplicacao, login, datahora, detalhe, id_medico, versao, id_workstation) VALUES (" & idAplicativo & ",'" & _u.Login & "',current_date + current_time,'" & idSelecionado & "'," & idMedico & ",'" & _w.Versao & "'," & _w.idWorkstation & ")", False)
            End If
        Catch

        Finally
            _PG.Desconectar()
        End Try

        If vbMostraLog Then MsgBox(Descricao)
    End Sub

    Public Sub ExecutaShell(vsAplicativoEXE As String, vsAplicativoNome As String, vsParametro As String, vnFoco As Integer, URL As String, Optional vbDesviarLogBanco As Boolean = True)
        Dim vsPath As String, vbGravarLogBanco As Boolean

        'No backup o Banco está fechado e ocaciona erro ao gravar log banco.
        If vbDesviarLogBanco Then vbGravarLogBanco = False Else vbDesviarLogBanco = True

        ' vbRet = oSegurança.Ocorrencias("tracker", "Executor Shell", "", "oT.ExecutaShell", "iniciando, " & vsAplicativo, False, vbGravarLogBanco, True)

        ' se vem com path executa e sai
        If InStr(vsAplicativoEXE, "\") > 0 And InStr(vsAplicativoEXE, ".exe") > 0 Then If Shell(vsAplicativoEXE & " " & vsParametro, 1) Then Exit Sub

        vsPath = System.Windows.Forms.Application.StartupPath   ' oINI.Path_Servidor
        vsAppBaixado = vsPath & "/" & vsAplicativoEXE

        ' primeiro tentar localizar no path do serv idor
        Try
            If IO.File.Exists(vsPath & "\" & vsAplicativoEXE) = False Then

                Log_Gravar("biosifam_update4", "Iniciando download nova versão", 0, 0, _u.IdPrestador)

                ' segundo tentar localizar no path da chamada
                If MsgBox("O aplicativo " & vsAplicativoNome & " não foi encontrado em '" & vsPath & "'. Deseja fazer o download do aplicativo ? ", vbInformation + vbYesNo, "Aplicativo " & vsAplicativoEXE & " não foi localizado.") = vbNo Then
                    Exit Sub
                End If

                Dim myWebClient As New WebClient ' the web client  

                Try
                    'pegaDownloadEmProgresso será disparada sempre que o método DownloadAsync atualizar o status do download do arquivo
                    AddHandler myWebClient.DownloadProgressChanged, AddressOf pegaDownloadEmProgresso
                    AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadTerminou
                    'configura o tratmento da api timer
                    ' AddHandler myWebClient.TimerElapsed, AddressOf AtualizaDownload
                Catch exc As Exception
                    MessageBox.Show(exc.Message, "  Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
                myWebClient.DownloadFileAsync(New Uri(URL), vsPath & "\" & vsAplicativoEXE)
                Exit Sub

            End If

            System.Diagnostics.Process.Start(vsPath & "\" & vsAplicativoEXE, "")

        Catch
            Log_Gravar("biosifam_update6", "Erro ao buscar " & vsPath & "\" & vsAplicativoEXE, False, 0, _u.IdPrestador)
        End Try

        'vbRet = oSegurança.Ocorrencias("alerta", "Executor Shell", "", "oT.ExecutaShell", "concluido", False, vbGravarLogBanco, True)
        Exit Sub

ERRO:
        ' vbRet = oSegurança.Ocorrencias("erro", "Executor Shell", "", "oT.ExecutaShell", "O aplicativo " & vsAplicativoNome & " não foi encontrado no caminho padrão. Caminho de procura: '" & vsPath & "'", True, vbGravarLogBanco, True)

    End Sub

    Sub pegaDownloadEmProgresso(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
        Try
            dim vnMensagem As String = "Total download: " & FormatNumber(e.TotalBytesToReceive / 1024, 2).ToString & " KB, baixados: " & FormatNumber(e.BytesReceived / 1024, 2).ToString & " KB"
            If e.ProgressPercentage > 10 And vnAtingiu(0) = 0 Then frmMain.atualizaLogList(vnMensagem) : vnAtingiu(0) = 1
            If e.ProgressPercentage > 20 And vnAtingiu(1) = 0 Then frmMain.atualizaLogList(vnMensagem) : vnAtingiu(1) = 1
            If e.ProgressPercentage > 30 And vnAtingiu(2) = 0 Then frmMain.atualizaLogList(vnMensagem) : vnAtingiu(2) = 1
            If e.ProgressPercentage > 40 And vnAtingiu(3) = 0 Then frmMain.atualizaLogList(vnMensagem) : vnAtingiu(3) = 1
            If e.ProgressPercentage > 50 And vnAtingiu(4) = 0 Then frmMain.atualizaLogList(vnMensagem) : vnAtingiu(4) = 1
            If e.ProgressPercentage > 60 And vnAtingiu(5) = 0 Then frmMain.atualizaLogList(vnMensagem) : vnAtingiu(5) = 1
            If e.ProgressPercentage > 70 And vnAtingiu(6) = 0 Then frmMain.atualizaLogList(vnMensagem) : vnAtingiu(6) = 1
            If e.ProgressPercentage > 80 And vnAtingiu(7) = 0 Then frmMain.atualizaLogList(vnMensagem) : vnAtingiu(7) = 1
            If e.ProgressPercentage > 90 And vnAtingiu(8) = 0 Then frmMain.atualizaLogList(vnMensagem) : vnAtingiu(8) = 1

        Catch exc As Exception
            MessageBox.Show(exc.Message, "  Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub DownloadTerminou(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Try
            frmMain.atualizaLogList("Download concluído")
            If MsgBox("O aplicativo foi baixado com sucesso, deseja executar agora ? ", vbInformation + vbYesNo, "Download concluído.") = vbNo Then
                Exit Sub
            End If
            System.Diagnostics.Process.Start(vsAppBaixado, "")
        Catch exc As Exception
            MessageBox.Show(e.Error.Message, "  Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

End Class



