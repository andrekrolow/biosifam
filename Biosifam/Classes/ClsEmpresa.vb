Public Class ClsEmpresa
    ' igualar a classe do k2 - iniciado para sem uso

    dim vsNome As String = "Instituto de Previdência dos Servidores Públicos Municipais de Pelotas"
    dim vnIdEmpresa As Long = 1

    dim vbUsaLogRemoto As Boolean = True
    dim vbUsaLogLocal As Boolean = True
    Public vbUsaLogTxt As Boolean = True
    dim vbUsaLogRastreamento As Boolean

    Public Property Id() As Long
        Get
            Id = vnIdEmpresa
        End Get
        Set(ByVal value As Long)
        End Set
    End Property
    Public Property Nome() As String
        Get
            Nome = vsNome
        End Get
        Set(ByVal value As String)
        End Set
    End Property

End Class
