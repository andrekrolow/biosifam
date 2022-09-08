Public Class FrmPesquisaGenerica
    Dim ds As DataSet
    Public IdSelecionado As Integer
    Public DescricaoSelecionado As String

    Private Sub PicBuscarArquivo_Click(sender As Object, e As EventArgs) Handles PicBuscarArquivo.Click
        CarregaDadosGrid()
    End Sub

    Private Sub CarregaDadosGrid()
        _PG.Conectar()
        ds = _PG.DsQuery("select id_servico as Codigo, to_ascii(descricao,'LATIN1') as Nome, valor from servico where descricao like  '%" & txtFiltro.Text & "%' and situacao='A'")
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Nenhum item foi localizado !" & Chr(13) & Chr(13) & "Por favor informe outro filtro para pesquisa.")
            GoTo Fim_Bloco
        End If
        DgvServicosDisponiveis.DataSource = ds.Tables(0)
        DgvServicosDisponiveis.Width = 510
        DgvServicosDisponiveis.Columns(0).Visible = False
        DgvServicosDisponiveis.Columns(1).Visible = True
        DgvServicosDisponiveis.Columns(2).Visible = True

Fim_Bloco:
        _PG.Desconectar()
    End Sub
    Private Sub CarregaDadosSelecionado()
        IdSelecionado = DgvServicosDisponiveis.CurrentRow.Cells(1).Value()
        DescricaoSelecionado = DgvServicosDisponiveis.CurrentRow.Cells(2).Value()
        Me.Close()
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyDown
        Dim KeyCode As Short = e.KeyCode
        If KeyCode = System.Windows.Forms.Keys.Return Then
            If txtFiltro.Text <> "" Then
                Call CarregaDadosGrid()
                DgvServicosDisponiveis.Focus()
            End If
        End If
    End Sub
End Class