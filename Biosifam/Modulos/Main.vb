Imports GrFingerXLib

Module Main

    Public vsGlo_Log As String = Application.ProductName & ".log"
    Public vsGlo_AppPath As String = IIf(Right(Application.StartupPath, 1) <> "\", Application.StartupPath & "\", Application.StartupPath)

    Public vbResult As Boolean
    Public vh_UltimaAtividade As Date
    Public IdProcessoExe As String = ""

    Public StrConection_NPG_Sanep As String = ""
    Public StrConection_NPG_Biosifam As String = ""
    Public StrConection_NPG_BiosifamInterno As String = ""

    ' o banco atual prevpel2 está com o encode sql-ascii.
    'ao converter todos comandos de odbc para npgsql, o driver npgsql versao 2.0 não consegue
    'entender os caracteres Do banco asc99, gerando erros nas consultas quando elas tem caractres especiais ou acentos.

    'opção 1. converter o banco para utf-8 e para o novo servidor e seguir projeto
    'opção 2. atualizar driver npgsql, o que ocasiona a obrigatoriedade de atualizar o frame work (4 para 4.5) do sistema biosifam 
    '        (mais problemas) talvez alguns windows não funcionem nos clientes.

    'teste no servidor
    'Public StrConection_NPG_Biosifam As String = "Server=externo.pelotas.com.br;Database=prevpel;UserId=postgres;Password=C8KiUx1H;port=54320;preload reader=true;"
    'Public StrConection_NPG_Biosifam As String = "Server=192.168.0.214;Database=prevpel;UserId=postgres;Password=C8KiUx1H;port=5432;preload reader=true;Encoding=sql-ascii;"

    ' conexao para driver odbc
    'Public StrConection_NPG_Biosifam As String = "Provider=sqloledb;DRIVER={PostgreSQL ANSI};UID=ubiosifam;pwd=d4t4b4nk;SERVER=db3.pelotas.com.br;Port=5432;Database=prevpel2;"

    Public _PG As ClsBancoNPG

    'até igual netsan

    'Public _PG_CTRL As New cBancoNPG  '  _PG_CTRL nova nomenclatura
    'Public _banco As New cBancoNPG()
    Public _setup As New cSetup
    Public _util As New clsUtil
    Public _toolsSiFam As clsSiFam

    Public _w As New ClsEstação

    ' k2-------------------------
    Public _e As New ClsEmpresa ' projeto iguar k2
    Public _t As New cTools ' projeto iguar k2
    Public _s As New cSegurança ' projeto iguar k2

    Public _u As New cUsuario    ' padrão _public

    Public VbGlo_Console As Boolean = True  ' so deve ser false se o programa for chamado por outro programa
    Public VsNomeUsuario As String = "Manual"
    '-------------------------------------------

    Public oMedicoConveniado As ClsMedico

    Public vnGlo_idDigital As Integer
    Public vsGlo_frmAtivo As String
    Public vbGlo_InseriuDigital As Boolean
    Public vsGlo_MAC As String

    Public vnGlo_ModoAtual As Long

    Public vsGlo_Modo() As String = Split("Retaguarda,Consulta Digitais,Registra Consulta,Exames Clínicos,Pronto Atendimento,Hospitalar", ",")
    Public StrGloCategoria() As String = Split("Médico,Odontológico,Hospitalar,Pronto Atendimento,Laboratório,Clínica,Serviços Referenciados, Médicos Prestadores, Médicos Vinculados", ",")

    Public vnGlo_idLeitor As Integer = 0

    Public DsGeneric As DataSet
    Public StrGloSQL As String

    Public _appConfig As New AppConfig
    Public IdSelecionadoPesquisa As Integer
    Public NomeSelecionadoPesquisa As String
    Public ValorSelecionadoPesquisa As String
    Public CBHPMSelecionadoPesquisa As String

End Module
