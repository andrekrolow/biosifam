Imports System.Net.Dns      ' gethostname
Imports System.Net          ' para update - verifica nova versao web
Imports System.Text.RegularExpressions

Public Class cTools
    ' igualar a classe do k2 - iniciado para sem uso
    Public IP_Externo As String  ' para nao precisar ficar usando a internet a cada chamada

    Public Sub msgK2(ByVal vsMensagem As String, ByVal vsTitulo As String, ByVal vnTempo As Integer, Optional ByVal vsTipoMensagem As String = "vbOKOnly + vbInformation")

        CreateObject("WScript.Shell").Popup(vsMensagem, vnTempo, Application.ProductName.ToString & " " & Application.ProductVersion & ", " & vsTitulo, vsTipoMensagem)

    End Sub

    Public Function ExtraiItemLista(ByVal vsLista As String, ByVal viOrdem As Integer, ByVal vsSeparador As String) As String
        ExtraiItemLista = ""
        dim I As Integer, viContaPalavra As Integer, viInicioPalavra As Integer, viFimPalavra As Integer
        viContaPalavra = 0
        viInicioPalavra = 1
        If vsSeparador = "" Then vsSeparador = "|" ' assume default PIPE
        For I = 1 To Len(vsLista)
            If Mid$(vsLista, I, 1) = vsSeparador Or Len(vsLista) = I Then
                viContaPalavra = viContaPalavra + 1
                If Len(vsLista) = I Then ' ULTIMO CARACTER
                    viFimPalavra = I
                    If Right(vsLista, 1) = vsSeparador Then viFimPalavra = viFimPalavra - viInicioPalavra
                Else
                    viFimPalavra = I - viInicioPalavra
                End If
                ' viordem inicia em 1
                If viOrdem = viContaPalavra Then
                    ExtraiItemLista = Mid$(vsLista, viInicioPalavra, viFimPalavra)
                    Exit Function
                End If
                ' prepara proxima palavra
                viInicioPalavra = I + 1
            End If
        Next I
    End Function

    Public Function ExtraiItemListaObs(ByVal vsLista As String, ByVal viOrdem As Integer) As String
        ExtraiItemListaObs = ""
        ' separador da lista é o caracter chr$(10)
        dim I As Integer, viContaPalavra As Integer, viInicioPalavra As Integer, viFimPalavra As Integer
        viContaPalavra = 0
        viInicioPalavra = 1
        For I = 1 To Len(vsLista)
            ' chr$(10)= 0A = 10 = Line FEED
            ' chr$(13) = 0D = 13 = Carriege Return
            ' preciso tirar fora os dois a ordem é o 13 e depoiis o 10 (0d e 0a)
            ' Todos campos Obs tem os dois ao final de cada linha
            If Mid$(vsLista, I, 1) = Chr(10) Or Len(vsLista) = I Or Mid$(vsLista, I, 1) = Chr(13) Then
                viContaPalavra = viContaPalavra + 1
                If Len(vsLista) = I Then ' ULTIMO CARACTER
                    viFimPalavra = I
                    If Right(vsLista, 1) = Chr(10) Then viFimPalavra = viFimPalavra - viInicioPalavra ' 2 são os dois caracteres que quero retirar

                Else
                    viFimPalavra = I - viInicioPalavra
                End If
                ' viordem inicia em 1
                If viOrdem = viContaPalavra Then ExtraiItemListaObs = Mid$(vsLista, viInicioPalavra, viFimPalavra) : Exit Function
                ' prepara proxima palavra
                viInicioPalavra = I + 2
                I = I + 1
            End If
        Next I
    End Function

    Public Function TransformaFTem01(ByVal Valor As Boolean) As Byte
        If Valor = False Then TransformaFTem01 = 0 Else TransformaFTem01 = 1
    End Function

    Public Function SubsCaracterGráfico(ByVal TrocarCaracterGráfico As String, ByVal vsString As String, ByVal vbSeleção As Boolean) As String
        SubsCaracterGráfico = vsString
        On Error GoTo Fim
        ' seleção permite usar função independente do tipo de impressora - é só usar FALSE e funcionará sempre
        dim I As Integer
        If vbSeleção Then
            If TrocarCaracterGráfico <> "SIM" Then GoTo Fim
        End If
        For I = 1 To Len(vsString)

            Select Case Mid$(vsString, I, 1)
                Case "á" : Mid$(vsString, I, 1) = "a"
                Case "Á" : Mid$(vsString, I, 1) = "A"
                Case "ã" : Mid$(vsString, I, 1) = "a"
                Case "Ã" : Mid$(vsString, I, 1) = "A"

                Case "é" : Mid$(vsString, I, 1) = "e"
                Case "É" : Mid$(vsString, I, 1) = "E"
                Case "ê" : Mid$(vsString, I, 1) = "e"
                Case "Ê" : Mid$(vsString, I, 1) = "E"

                Case "í" : Mid$(vsString, I, 1) = "i"
                Case "Í" : Mid$(vsString, I, 1) = "I"

                Case "ó" : Mid$(vsString, I, 1) = "o"
                Case "Ó" : Mid$(vsString, I, 1) = "O"
                Case "õ" : Mid$(vsString, I, 1) = "o"
                Case "Õ" : Mid$(vsString, I, 1) = "O"

                Case "ú" : Mid$(vsString, I, 1) = "u"
                Case "Ú" : Mid$(vsString, I, 1) = "U"
                Case "ü" : Mid$(vsString, I, 1) = "u"

                Case "ç" : Mid$(vsString, I, 1) = "c"
                Case "Ç" : Mid$(vsString, I, 1) = "C"

            End Select
        Next I
Fim:
        SubsCaracterGráfico = vsString
    End Function

    Public Function NomeArquivo(ByVal Path As String) As String
        dim vsAux As String = Path
        NomeArquivo = ""
        While InStr(vsAux, "\") > 0
            ' se tem a barra é que está indicando também o caminho
            NomeArquivo = NomeArquivo & Left(vsAux, InStr(vsAux, "\"))
            vsAux = Right(vsAux, Len(vsAux) - Len(Left(vsAux, InStr(vsAux, "\"))))
        End While
        NomeArquivo = vsAux

    End Function

    Public Function ObtemEnderecoIP() As String
        'Nào funciona
        'dim oEndereco As System.Net.IPAddress
        dim sEndereco As String
        'With System.Net.Dns.GetHostEntry(GetHostName)
        '   oEndereco = New System.Net.IPAddress(.AddressList(0).Address)
        '   oEndereco = New System.Net.IPAddress(0)
        '   sEndereco = oEndereco.ToString()
        'End With

        ' http://labs.developerfusion.co.uk/SourceViewer/browse.aspx?assembly=SSCLI&namespace=System.Net&type=Dns
        ' Resolve the host name.
        sEndereco = ""
        Try
            dim result As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(GetHostName)

            ' Display host name
            'Debug.WriteLine("Host name: " + result.HostName)

            ' Display addresses, if any
            dim add As System.Net.IPAddress
            For Each add In result.AddressList
                'Debug.WriteLine("Address: " + add.ToString())
                sEndereco = add.ToString()
            Next

            ' Display aliases, if any
            'dim s As String
            'For Each s In result.Aliases
            '    Debug.WriteLine("Aliases: " + s)
            'Next

        Catch ex As Exception
            Debug.WriteLine("Name cannot be resolved. Error: " + ex.Message)
        End Try

        ObtemEnderecoIP = sEndereco
    End Function
    Public Function ObtemEnderecoIPExterno() As String
        ObtemEnderecoIPExterno = ""
        Dim Retorno As String = ""
        Try
            Using wClient As New WebClient
                Retorno = wClient.DownloadString("http://www.ip-adress.com/")
                Dim m As Match = Regex.Match(Retorno, "Your IP address is: <strong>([0-9.]+)</strong>", RegexOptions.Compiled)
                Dim key As String = m.Groups(1).Value
                Dim myIP As String = key
                IP_Externo = IPAddress.Parse(myIP).ToString
            End Using
            Return IP_Externo
        Catch
            If IP_Externo = "" Then ObtemEnderecoIP()
        End Try

    End Function

    Public Function ObtemMAC() As String

        Dim mc As System.Management.ManagementClass
        Dim mo As System.Management.ManagementBaseObject
        ObtemMAC = ""
        Try
            mc = New Management.ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim moc As Management.ManagementObjectCollection = mc.GetInstances
            For Each mo In moc
                If mo.Item("IPenabled") Then
                    ObtemMAC = Trim(mo.Item("MacAddress"))
                    'MsgBox(ObtemMAC)
                    vsGlo_MAC = ObtemMAC
                End If
            Next
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar o MAC do computaor: " & ObtemMAC & " erro: " & ex.Message)
        End Try
        'ObtemMAC = "00:0D:A3:14:E5:33" 'daniela azambuja para teste
    End Function


    Public Function AplicacaoJaEstaRodando(ByVal vsNomeUsuario As String, ByVal IdProcessoAtual As Integer) As Boolean
        AplicacaoJaEstaRodando = False
        Try
            ' 2- verificando o limite superior do array , se for  maior que zero então existe duas instâncias
            ' MsgBox("nUMEROD DE PROCESSO " & Process.GetCurrentProcess.ProcessName & "(" & IdProcessoAtual & ") : " & Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).GetUpperBound(0))
            If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).GetUpperBound(0) > 0 Then
                _s.Ocorrencias(1, Application.ProductName, "", "VerificaAplicacaoMemoria", "Aplicação já está em execução (" & Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).GetUpperBound(0) & "), processo " & Process.GetCurrentProcess.ProcessName & " encerrado.", vbGlo_Console, True, True)
                AplicacaoJaEstaRodando = True
                Exit Function ' ja tem um programa sincronizando 
            End If
        Catch ex As Exception
            _s.Ocorrencias(1, Application.ProductName, vsNomeUsuario, "VerificaAplicacaoMemoria", "erro ao localizar processos duplicados " & Application.ProductName & ", " & Err.Description, vbGlo_Console, True, True)
        End Try
    End Function


    Public Function FormataString(mascara As String, valor As String) As String

        Dim novoValor As String = ""
        Dim posicao As Integer = 0

        For i = 0 To Len(mascara) - 1
            If mascara(i) = "#" Then
                If Len(valor) > posicao Then
                    novoValor = novoValor + valor(posicao)
                    posicao += 1
                Else
                    Exit For
                End If
            Else
                If (valor.Length > posicao) Then
                    novoValor = novoValor + mascara(i)
                Else
                    Exit For
                End If
            End If
        Next
        FormataString = novoValor

    End Function

    Public Function AjustaSomaAtendimentoServico(Data As String, TipoServico As String) As Boolean
        AjustaSomaAtendimentoServico = False
        If _PG.Conectar() = False Then Exit Function
        _PG.Execute("begin")
        _PG.Execute("UPDATE atendimento As a Set valor = at.soma FROM ( Select id_atendimento, SUM(valor) soma FROM atendimento_servico GROUP BY id_atendimento ) at WHERE at.id_atendimento= a.id_atendimento And a.dt_alteracao >='" & Data & "' and a.tipo_servico='" & TipoServico & "'")
        _PG.Execute("commit")
        _PG.Desconectar()
        AjustaSomaAtendimentoServico = True
    End Function

    Public Function CarregaCombo(Combo As ComboBox, StrQuery As String) As Boolean
        Try
            CarregaCombo = False
            Combo.Items.Clear()
            Dim ds As DataSet
            ds = _PG.DsQuery(StrQuery)
            If ds Is Nothing Then Exit Function
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Combo.Items.Add(New ComboData(ds.Tables(0).Rows(i).Item(0).ToString, (ds.Tables(0).Rows(i).Item(1).ToString)))
                Next
            End If
            CarregaCombo = True
        Finally
        End Try

    End Function
    Public Function CopiaCombo(Combo As ComboBox, ComboNew As ComboBox) As Boolean
        Try
            ComboNew.Items.Clear()
            For i = 0 To Combo.Items.Count - 1
                Combo.SelectedIndex = i
                ComboNew.Items.Add(New ComboData(CType(Combo.SelectedItem, ComboData).Id, CType(Combo.SelectedItem, ComboData).Descricao))
            Next
            CopiaCombo = True
        Finally
        End Try

    End Function
    Public Sub PosicionaCombo(ByVal CmbCombo As ComboBox, ByVal Id As Integer)
        Dim i As Integer
        If CmbCombo.Items.Count = 0 Then Exit Sub
        If Id = 0 Then Exit Sub
        CmbCombo.SelectedIndex = -1
        For i = 0 To CmbCombo.Items.Count - 1
            ' era assim na vsersao 2.1.07 - nesta rotina cada vez que posiciona o index vai na no select e executa tomanado tempo e fazendo coisa que nao precisa
            'CmbCombo.SelectedIndex = i
            'If CType(CmbCombo.SelectedItem, ComboData).Id = Id Then Exit For
            If CType(CmbCombo.Items(i), ComboData).Id = Id Then
                CmbCombo.SelectedIndex = i
                Exit For
            End If
        Next
        If CmbCombo.SelectedIndex = -1 Then CmbCombo.SelectedText = "Exame não localizado."
    End Sub

    Public Function RetornaIndexCombo(ByVal cmbCombo As ComboBox, ByVal idMedico As Integer) As Long
        RetornaIndexCombo = 0
        Dim i As Integer
        If cmbCombo.Items.Count = 0 Then Exit Function
        For i = 0 To cmbCombo.Items.Count - 1
            If CType(cmbCombo.Items(i), ComboData).Id = idMedico Then
                RetornaIndexCombo = i
                Exit Function
            End If
        Next
    End Function
    Public Function VerificaConexao_TcpSocket() As Boolean
        Try
            Dim cliente As New Sockets.TcpClient("www.google.com", 80)
            cliente.Close()
            Return True
        Catch ex As System.Exception
            Return False
        End Try
    End Function


End Class

Public Class ComboData
    Public Id As Object
    Public Descricao As String
    Public Sub New(ByVal NovoValor As Object, ByVal NovaDescricao As String)
        Id = NovoValor
        Descricao = NovaDescricao
    End Sub
    Public Overrides Function ToString() As String
        Return Descricao
    End Function
End Class
