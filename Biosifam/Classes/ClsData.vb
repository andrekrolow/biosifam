Public Class ClsData

    ' copia da classe cData do k2tools -13/07/2021

    ' variaveis usada na rotina de calculo de feriados móveis
    Public dt_Pascoa As Date
    Public dt_Carnaval As Date
    Public dt_SextaSanta As Date
    Public dt_CorpusC As Date

    Function k2Left(ByVal vsTexto As String, ByVal vnTamanho As Integer) As String
        k2Left = Left(vsTexto, vnTamanho)
    End Function
    Function MostraDiadaSemana(ByVal vd_Data As Date) As String
        On Error Resume Next
        MostraDiadaSemana = ""
        If Weekday(vd_Data) = 1 Then MostraDiadaSemana = "Domingo"
        If Weekday(vd_Data) = 2 Then MostraDiadaSemana = "Segunda"
        If Weekday(vd_Data) = 3 Then MostraDiadaSemana = "Terça"
        If Weekday(vd_Data) = 4 Then MostraDiadaSemana = "Quarta"
        If Weekday(vd_Data) = 5 Then MostraDiadaSemana = "Quinta"
        If Weekday(vd_Data) = 6 Then MostraDiadaSemana = "Sexta"
        If Weekday(vd_Data) = 7 Then MostraDiadaSemana = "Sábado"
    End Function
    Function Mês(ByVal Data As Date) As String
        ' converte mês de inglês para português
        On Error Resume Next
        Mês = ""
        Select Case Month(Data)
            Case 1 : Mês = "janeiro"
            Case 2 : Mês = "fevereiro"
            Case 3 : Mês = "março"
            Case 4 : Mês = "abril"
            Case 5 : Mês = "maio"
            Case 6 : Mês = "junho"
            Case 7 : Mês = "julho"
            Case 8 : Mês = "agosto"
            Case 9 : Mês = "setembro"
            Case 10 : Mês = "outubro"
            Case 11 : Mês = "novembro"
            Case 12 : Mês = "dezembro"
        End Select
    End Function

    Function ÚltimoDiadoMês(ByVal Mês As String) As String
        ' converte mês de inglês para português
        On Error Resume Next
        ÚltimoDiadoMês = 31
        If Mês = 2 Then ÚltimoDiadoMês = "28"
        If Mês = 4 Or Mês = 6 Or Mês = 9 Or Mês = 11 Then ÚltimoDiadoMês = "30"
    End Function

    Function VerificaData(ByVal DataTeste As String) As String
        VerificaData = ""
        If IsDate(DataTeste) = False Then
            MsgBox("Data Inválida", vbCritical, "Atenção")
        ElseIf Len(DataTeste) < 6 Then
            MsgBox("Data inválida", vbCritical, "Atenção")
        ElseIf Month(DataTeste) > 12 Then
            MsgBox("Mês inválido", vbCritical, "Atenção")
        ElseIf (DataTeste <> " /  /    ") Then
            VerificaData = DateValue(Format(DataTeste, "dd/mm/yyyy"))
        End If
    End Function

    Public Function Data() As Date
        'retorna data no padrão esperando, encerrando o problema de padrões rigionais de data
        Data = Format(Now, "dd/mm/yyyy")
    End Function

    Function Hora(ByVal HoraTeste As String) As String
        If Val(Left(HoraTeste, 2)) > 23 Or Val(Right(HoraTeste, 2)) > 59 Then
            Hora = ""
            Beep()
            MsgBox("Hora Inválida", vbCritical, "Atenção")
        Else
            Hora = Format(HoraTeste, "hh:mm")
        End If
        'Ex.:  Form1.Caption = Data(MskData.Text)
    End Function

    Public Function AvançaMêsCalendário(ByRef objCalendário) As Boolean
        objCalendário.Value = objCalendário.Value + 30
        AvançaMêsCalendário = True
    End Function
    Public Function RetornaMêsCalendário(ByRef objCalendário) As Boolean
        objCalendário.Value = objCalendário.Value - 30
        RetornaMêsCalendário = False
    End Function

    Public Function PeriodoAnterior(ByVal PeriodoAtual As String) As String
        PeriodoAnterior = Val(Left$(PeriodoAtual, 2)) - 1 ' pega mes
        If Val(PeriodoAnterior) = 0 Then
            PeriodoAnterior = "00/" & Right$(PeriodoAtual, 4)
        Else
            If Len(PeriodoAnterior) = 1 Then PeriodoAnterior = "0" & PeriodoAnterior
            PeriodoAnterior = PeriodoAnterior & "/" & Right$(PeriodoAtual, 4)
        End If
    End Function

    Public Function AdicionaAjustaVencto(ByVal Data As Date, ByVal vnPrazoOperadora As Long, ByVal vsFormadePagto As String) As String
        If vnPrazoOperadora > 1 Then Data = Format(Data.AddDays(vnPrazoOperadora), "yyyy/mm/dd")

        CalculaFeriados(Year(Data))

        If vnPrazoOperadora = 0 Then
            ' se for cartão de débito, quero vencto +2, que é geralmente quando as operadoras pagam. por enquanto tá fixo +2
            If InStr(UCase(vsFormadePagto), "DÉBITO") Then Data = Data.AddDays(2)
            If InStr(UCase(vsFormadePagto), "CRÉDITO") Or InStr(UCase$(vsFormadePagto), "PRÉ") Then Data = Data.AddDays(30)
            GoTo Sai
        End If

        ' agora forma de pagamento de prazo para calcula o vencimento
        ' se estiver zero faz como era antes.
        Dim vbFeriado As Boolean
        Select Case Data
            Case dt_Pascoa : vbFeriado = True
            Case dt_Carnaval : vbFeriado = True
            Case dt_SextaSanta : vbFeriado = True
            Case dt_SextaSanta : vbFeriado = True
            Case dt_CorpusC : vbFeriado = True
        End Select

        Select Case Month(Data)
            Case 1 : If Data.Day = 1 Then vbFeriado = True ' 1 de janeiro
            Case 4 : If Data.Day = 21 Then vbFeriado = True ' tiradentes
            Case 5 : If Data.Day = 1 Then vbFeriado = True ' dia do trabalho
            Case 9 : If Data.Day = 7 Then vbFeriado = True ' 7 de setembro
            Case 10 : If Data.Day = 12 Then vbFeriado = True ' nossa sra aparecida - dia das criancas
            Case 11 : If Data.Day = 2 Then vbFeriado = True ' finados
            Case 12
                If Data.Day = 24 Then vbFeriado = True ' vespera de natal
                If Data.Day = 25 Then vbFeriado = True ' natal
                If Data.Day = 1 Then vbFeriado = True ' vespera de ano novo
        End Select
        If vbFeriado Then Data = Data.AddDays(1)
        If Data.DayOfWeek = 0 Then Data = Data.AddDays(1) ' domingo
        If Data.DayOfWeek = 6 Then Data = Data.AddDays(2) ' sabado

Sai:
        AdicionaAjustaVencto = Data

    End Function

    Public Sub CalculaFeriados(ByVal Ano As Integer)
        Dim a, B, C, D, E, f, G, H, I, K, L, M, P, Q As Long

        a = (Ano Mod 19)
        B = Int(Ano / 100)
        C = (Ano Mod 100)
        D = Int(B / 4)
        E = (B Mod 4)
        f = Int((B + 8) / 25)
        G = Int((B - f + 1) / 3)
        H = ((19 * a + B - D - G + 15) Mod 30)
        I = Int(C / 4)
        K = (C Mod 4)
        L = ((32 + 2 * E + 2 * I - H - K) Mod 7)
        M = Int((a + 11 * H + 22 * L) / 451)
        P = Int((H + L - 7 * M + 114) / 31)
        Q = ((H + L - 7 * M + 114) Mod 31)

        dt_Pascoa = CDate((Q + 1) & "/" & P & "/" & Ano)
        dt_Carnaval = DateAdd("d", -47, dt_Pascoa)
        dt_SextaSanta = DateAdd("d", -2, dt_Pascoa)
        dt_CorpusC = DateAdd("d", 60, dt_Pascoa)


    End Sub


    Public Function QuintoDiaUtil(ByVal Data As Date) As String
        Dim vbFeriado As Boolean
        CalculaFeriados(Year(Data))
        For i = 1 To 5
            Data = Data.AddDays(1)
            ' agora forma de pagamento de prazo para calcula o vencimento
            ' se estiver zero faz como era antes.
            vbFeriado = False
            Select Case Data
                Case dt_Pascoa : vbFeriado = True
                Case dt_Carnaval : vbFeriado = True
                Case dt_SextaSanta : vbFeriado = True
                Case dt_SextaSanta : vbFeriado = True
                Case dt_CorpusC : vbFeriado = True
            End Select

            Select Case Month(Data)
                Case 1 : If Data.Day = 1 Then vbFeriado = True ' 1 de janeiro
                Case 4 : If Data.Day = 21 Then vbFeriado = True ' tiradentes
                Case 5 : If Data.Day = 1 Then vbFeriado = True ' dia do trabalho
                Case 9 : If Data.Day = 7 Then vbFeriado = True ' 7 de setembro
                Case 10 : If Data.Day = 12 Then vbFeriado = True ' nossa sra aparecida - dia das criancas
                Case 11 : If Data.Day = 2 Then vbFeriado = True ' finados
                Case 12
                    If Data.Day = 24 Then vbFeriado = True ' vespera de natal
                    If Data.Day = 25 Then vbFeriado = True ' natal
                    If Data.Day = 1 Then vbFeriado = True ' vespera de ano novo
            End Select

            If Data.DayOfWeek = 0 Then
                Data = Data.AddDays(1)
            ElseIf Data.DayOfWeek = 6 Then
                Data = Data.AddDays(1)
            Else
                If vbFeriado Then Data = Data.AddDays(1)              ' feriado
            End If

        Next
Sai:
        QuintoDiaUtil = Data

    End Function
End Class
