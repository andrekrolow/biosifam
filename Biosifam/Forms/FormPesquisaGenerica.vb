Public Class FrmPesquisaGenerica
    Dim ds As DataSet

    Private Sub PicBuscarArquivo_Click(sender As Object, e As EventArgs) Handles PicBuscarArquivo.Click
        CarregaDadosGrid()
    End Sub

    Private Sub CarregaDadosGrid()
        _PG.Conectar()
        ds = _PG.DsQuery("select s.id_servico as Codigo, to_ascii(descricao,'LATIN1') as Nome,  cbhpm_capitulo as CBHPM, valor as Valor from prestador_servicos inner join servico s using (id_servico) where id_prestador=" & oMedicoConveniado.Id & " and upper(descricao) like  '%" & UCase(txtFiltro.Text) & "%' and s.ativo='S' order by nome")
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Nenhum item foi localizado !" & Chr(13) & Chr(13) & "Por favor informe outro filtro para pesquisa.")
            GoTo Fim_Bloco
        End If
        'DgvServicosDisponiveis.Columns.Clear()
        DgvServicosDisponiveis.DataSource = ds.Tables(0)
        DgvServicosDisponiveis.Width = 600
        DgvServicosDisponiveis.Columns(0).Visible = False
        DgvServicosDisponiveis.Columns(1).Width = 380
        DgvServicosDisponiveis.Columns(2).Width = 75
        DgvServicosDisponiveis.Columns(3).Width = 75
Fim_Bloco:
        _PG.Desconectar()
    End Sub
    Private Sub CarregaDadosSelecionado()
        IdSelecionadoPesquisa = DgvServicosDisponiveis.CurrentRow.Cells(1).Value()
        NomeSelecionadoPesquisa = DgvServicosDisponiveis.CurrentRow.Cells(2).Value()
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

    Private Sub DgvServicosDisponiveis_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvServicosDisponiveis.CellContentDoubleClick
        Try
            IdSelecionadoPesquisa = 0
            NomeSelecionadoPesquisa = ""
            CBHPMSelecionadoPesquisa = ""
            ValorSelecionadoPesquisa = 0

            If DgvServicosDisponiveis.Rows.Count > 0 Then
                IdSelecionadoPesquisa = DgvServicosDisponiveis.CurrentRow.Cells(0).Value()
                NomeSelecionadoPesquisa = DgvServicosDisponiveis.CurrentRow.Cells(1).Value()
                CBHPMSelecionadoPesquisa = DgvServicosDisponiveis.CurrentRow.Cells(2).Value()
                ValorSelecionadoPesquisa = DgvServicosDisponiveis.CurrentRow.Cells(3).Value()
            End If
        Catch
        End Try
        Me.Close()
    End Sub

    Private Sub FrmPesquisaGenerica_Load(sender As Object, e As EventArgs) Handles Me.Load
        Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2   ' Center form horizontally.
        Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2  ' Center form vertically.

        CarregaDadosGrid()
    End Sub

    Private Sub DgvServicosDisponiveis_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvServicosDisponiveis.KeyDown
        Dim KeyCode As Short = e.KeyCode
        If KeyCode = System.Windows.Forms.Keys.Return Then
            IdSelecionadoPesquisa = 0
            NomeSelecionadoPesquisa = ""
            CBHPMSelecionadoPesquisa = ""
            ValorSelecionadoPesquisa = 0
            Try
                If DgvServicosDisponiveis.Rows.Count > 0 Then
                    IdSelecionadoPesquisa = DgvServicosDisponiveis.CurrentRow.Cells(0).Value()
                    NomeSelecionadoPesquisa = DgvServicosDisponiveis.CurrentRow.Cells(1).Value()
                    CBHPMSelecionadoPesquisa = DgvServicosDisponiveis.CurrentRow.Cells(2).Value()
                    ValorSelecionadoPesquisa = DgvServicosDisponiveis.CurrentRow.Cells(3).Value()
                End If
            Catch
            End Try
            Me.Close()
        End If
    End Sub

    Private Sub FrmPesquisaGenerica_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.Close()
    End Sub
End Class