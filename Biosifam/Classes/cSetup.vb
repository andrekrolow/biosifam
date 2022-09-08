
Public Class cSetup

    ' variaveis para configuração biosifam via sifam---------------------
    Public limite_maximo_atendimentos_medicos As Integer = 2
    Public limite_maximo_atendimentos_dentistas As Integer = 2
    Public limite_maximo_exames_analises_clinicas As Integer
    Public limite_maximo_bonus As Integer = 5

    Public prazo_de_pesquisa_atendimentos_medicos As Integer = 30
    Public prazo_de_pesquisa_atendimentos_dentistas As Integer = 30
    'Public prazo_de_pesquisa_atendimentos_fisioterapias As Integer
    Public prazo_de_pesquisa_bonus As Integer = 365
    Public prazo_de_pesquisa_excedentes As Integer = 30

    Dim drSetup As Npgsql.NpgsqlDataReader

    Public Sub Carregar()
        Try
            If _PG.Conectar = False Then End
            drSetup = _PG.DrQuery("SELECT * FROM parametros WHERE id_parametros=1")
            If drSetup.HasRows Then
                drSetup.Read()
                limite_maximo_atendimentos_medicos = drSetup.Item("limite_maximo_atendimentos_medicos")  '2
                limite_maximo_atendimentos_dentistas = drSetup.Item("limite_maximo_atendimentos_dentistas")  '2
                limite_maximo_bonus = drSetup.Item("limite_maximo_bonus")        '5
                prazo_de_pesquisa_atendimentos_medicos = drSetup.Item("prazo_de_pesquisa_atendimentos_medicos") '30
                prazo_de_pesquisa_atendimentos_dentistas = drSetup.Item("prazo_de_pesquisa_atendimentos_dentistas") '30
                prazo_de_pesquisa_bonus = drSetup.Item("prazo_de_pesquisa_bonus")  '365
                prazo_de_pesquisa_excedentes = drSetup.Item("prazo_de_pesquisa_excedentes") '30
            End If

            drSetup = _PG.DrQuery("SELECT * FROM valores WHERE id_valores=1")
            If drSetup.HasRows Then
                drSetup.Read()
                limite_maximo_exames_analises_clinicas = drSetup.Item("limite_exame_analise_clinica")
            End If

        Finally
            _PG.Desconectar()
        End Try
    End Sub

End Class
