Public Class ClsServico

    Public Id As Integer
    Public Valor As Decimal
    Public ValorPrestador As Decimal
    Public ValorContribuinte As Decimal
    Public BolFinanciavel As Boolean

    Public Function Carregar(PIntServico As Integer, _Prestador As ClsMedico, ByRef PDecValor As Decimal) As Boolean
        If PIntServico = 0 Then Exit Function
        Id = PIntServico
        If _Prestador.DespesaHospitalar And PDecValor > 0 Then
            ' internacao - paga 100%, consigna conforme limite cobertura
            ' pa         - paga 100%, consigna tudo para o paciente
            ValorPrestador = PDecValor
            If _Prestador.LaboratorioAnalisesClinicasAtendimentoInterno Then
                ' calcula limite de cobertura, se ultrapassar paga tudo, se nao não paga. <== ESTA ERRADO AINDA - PRECISO SALDO CONSGINACAO
                ValorContribuinte = PDecValor
            End If
            If _Prestador.LaboratorioAnalisesClinicasProntoAtendimento Then
                ValorContribuinte = PDecValor
            End If

            Exit Function
        End If

        ' a principio terceiro parametros somente para exames categoria 3 e 4
        BolFinanciavel = False

        Dim dsServico As DataSet
        dsServico = _PG.DsQuery("SELECT valor, cobertura, consignacao, finan FROM servico where id_servico=" & Id)
        If dsServico Is Nothing Then Exit Function
        If dsServico.Tables(0).Rows.Count > 0 Then
            ' quando digita valor utiliza valor digitador, do contrario busca o valor do cadastro
            If PDecValor = 0 Then PDecValor = dsServico.Tables(0).Rows(0).Item(0).ToString
            Valor = PDecValor
            ValorPrestador = Valor * dsServico.Tables(0).Rows(0).Item(1).ToString / 100
            ValorContribuinte = Valor * dsServico.Tables(0).Rows(0).Item(2).ToString / 100
            If IsDBNull(dsServico.Tables(0).Rows(0).Item(3)) = False Then
                If dsServico.Tables(0).Rows(0).Item(3).ToString = "S" Then BolFinanciavel = True
            End If
        End If

        Carregar = True

    End Function

    Public Function HabilitaDigitacaoPreco(ByRef MskValor As MaskedTextBox, Optional Correcao As Boolean = False) As Boolean
        ' defalut é nao digitar valor, exceto se valor for zero ou for correção (correç~cao valor nao é zero)
        HabilitaDigitacaoPreco = False
        If MskValor.Text = 0 Or Correcao Then
            MskValor.Enabled = True
            HabilitaDigitacaoPreco = True
        Else
            MskValor.Enabled = False
        End If
    End Function

End Class
