'   SIFAM - Sistema Informatizado do Fundo de Assistência Médica
' 	Copyright (c) 2010 COINPEL
'   Descrição : Classe frmPrincipal
'   Autor:  Cauê Duarte (caueduar@gmail.com)
'   Criação:     24/08/2010
'   Modificação: 31/01/2018, André Krolow
'   R@ = regras do negócio

' falhas e inconsistencia conhecidas
' - cancelamento de consulta, cancela tabela consulta, mas nao cancelada tabela atendimento - pronto=15/10/19
' - commit da gravação de consulta está separado da gravãção do atendimento,  o que pode e já ocorreu é a gravação do primeiro bloco e a perda dos dados dos segundo bloco.
' - biosifam não salva excedentes na tabela atendimento - distribuir ultima versão - pronto
' - eliminar tabela consultas e suas dependencias - pronto

Imports System.Windows.Forms.DataVisualization.Charting ' para grafico

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Dim components As System.ComponentModel.IContainer
    Friend WithEvents grpIdentificação As System.Windows.Forms.GroupBox
    Friend WithEvents btnMatricula As System.Windows.Forms.Button
    Friend WithEvents lblMatricula As System.Windows.Forms.Label
    Friend WithEvents txtMatricula As System.Windows.Forms.TextBox
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents LogList As System.Windows.Forms.ListBox
    Protected WithEvents grdContribuintes As System.Windows.Forms.DataGridView
    Friend WithEvents lblUsuarioCorrente As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AxGrFingerXCtrl1 As AxGrFingerXLib.AxGrFingerXCtrl
    Friend WithEvents DigitalParaUsuariosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SIFAMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbMedico As System.Windows.Forms.ComboBox
    Friend WithEvents DigitaisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstatísticoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DigitalParaUsuáriosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MarcaçãoOFFLineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AjudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuporteRemotoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents AtualizarÚltimaVersãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents btnExcluir As System.Windows.Forms.Button
    Friend WithEvents RegistroDePacotesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResumoDePacotesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CorreçõesEmProcedimentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLimpar As System.Windows.Forms.Button
    Friend WithEvents panGrafico As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAtendimentosGrafico As System.Windows.Forms.TextBox
    Friend WithEvents cmbMesGrafico As System.Windows.Forms.ComboBox
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents lblPessoa As System.Windows.Forms.Label
    Friend WithEvents SobreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCPF As TextBox
    Friend WithEvents AutorizaçõesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnConsultarSessoes As Button
    Friend WithEvents picLogin As PictureBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents AjustesEspeciaisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GrpMedico As GroupBox
    Friend WithEvents btnNaoCompareceu As Button
    Friend WithEvents picSMS As PictureBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents EspelhoDeNFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WebSitePREVPELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadPlanilhasFechamentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents picAnyDesk As System.Windows.Forms.PictureBox
    Friend WithEvents TabelaCBHPMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutorizaçãoRemotaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GrpSetor As GroupBox
    Friend WithEvents CmbSetor As ComboBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PicQrCode As PictureBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TutorialSMSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnImprimir As Button
    Friend WithEvents RelatórioDeExamesProcedimentosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblIP As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTotal As Label
    Friend WithEvents mskTotal As MaskedTextBox
    Friend WithEvents UploadDeCredenciamentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlterarOrdemDeClassificaçãoDeExamesProcedimentosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PicAlerta As PictureBox
    Friend WithEvents PicCorrigir As PictureBox
    Friend WithEvents GrpServicos As GroupBox
    Protected WithEvents DrgServicosAtendimento As DataGridView
    Friend WithEvents GrpServicoInformado As GroupBox
    Friend WithEvents MskValorServico As MaskedTextBox
    Friend WithEvents BtnAdicionarServico As Button
    Friend WithEvents TxtCBHPM As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnPesquisarServico As Button
    Friend WithEvents TxtServico As TextBox
    Friend WithEvents rtbApoio As RichTextBox
    Public WithEvents grdIdentifica As DataGridView
    Friend WithEvents GroupBiometria As GroupBox
    Friend WithEvents lblSenha As Label
    Public WithEvents picMain As PictureBox
    Friend WithEvents lblSituacao As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PicPessoa As PictureBox
    Friend WithEvents lblValor As Label
    Friend WithEvents GrpResponsavel As GroupBox
    Protected WithEvents ViewResponsavel As DataGridView
    Friend WithEvents chkRegistraSomenteExames As CheckBox
    Friend WithEvents BtnAutoriza As Button
    Friend WithEvents GrpUpload As GroupBox
    Friend WithEvents txtArquivoDespesas As TextBox
    Friend WithEvents PicBuscarArquivo As PictureBox
    Friend WithEvents lblDataAtendimento As Label
    Friend WithEvents grpSenha As GroupBox
    Friend WithEvents btnValidaSenha As Button
    Friend WithEvents mskSenha As MaskedTextBox
    Friend WithEvents grpSenhaConfirmacao As GroupBox
    Friend WithEvents btnValidaSenhaConfirmacao As Button
    Friend WithEvents mskSenhaConfirmacao As MaskedTextBox
    Friend WithEvents GrpSenhaGerencial As GroupBox
    Friend WithEvents BtnSenhaGerecnial As Button
    Friend WithEvents MskSenhaGerencial As MaskedTextBox
    Friend WithEvents GrpConsultas As GroupBox
    Friend WithEvents cmbProcedimento As ComboBox
    Friend WithEvents cmbProcedimento2 As ComboBox
    Friend WithEvents mskValor As MaskedTextBox
    Friend WithEvents mskValor2 As MaskedTextBox
    Friend WithEvents grpAntendimento As GroupBox
    Friend WithEvents DigitalParaUsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea8 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend8 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title8 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle92 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle93 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle94 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle95 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle96 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle97 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle98 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle99 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle100 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle101 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle102 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle103 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle104 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panGrafico = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalAtendimentosGrafico = New System.Windows.Forms.TextBox()
        Me.cmbMesGrafico = New System.Windows.Forms.ComboBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PicCorrigir = New System.Windows.Forms.PictureBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.PicQrCode = New System.Windows.Forms.PictureBox()
        Me.picSMS = New System.Windows.Forms.PictureBox()
        Me.btnNaoCompareceu = New System.Windows.Forms.Button()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.cmbMedico = New System.Windows.Forms.ComboBox()
        Me.grpIdentificação = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCPF = New System.Windows.Forms.TextBox()
        Me.lblPessoa = New System.Windows.Forms.Label()
        Me.grdContribuintes = New System.Windows.Forms.DataGridView()
        Me.btnMatricula = New System.Windows.Forms.Button()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.LogList = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.mskTotal = New System.Windows.Forms.MaskedTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblIP = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.picLogin = New System.Windows.Forms.PictureBox()
        Me.lblUsuarioCorrente = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DigitalParaUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DigitaisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDePacotesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResumoDePacotesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EspelhoDeNFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelatórioDeExamesProcedimentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutorizaçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DigitalParaUsuariosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstatísticoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DigitalParaUsuáriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MarcaçãoOFFLineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CorreçõesEmProcedimentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadPlanilhasFechamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadDeCredenciamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutorizaçãoRemotaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarOrdemDeClassificaçãoDeExamesProcedimentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SIFAMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AtualizarÚltimaVersãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuporteRemotoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebSitePREVPELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabelaCBHPMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SobreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjustesEspeciaisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TutorialSMSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AxGrFingerXCtrl1 = New AxGrFingerXLib.AxGrFingerXCtrl()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnConsultarSessoes = New System.Windows.Forms.Button()
        Me.GrpMedico = New System.Windows.Forms.GroupBox()
        Me.PicAlerta = New System.Windows.Forms.PictureBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.GrpSetor = New System.Windows.Forms.GroupBox()
        Me.CmbSetor = New System.Windows.Forms.ComboBox()
        Me.picAnyDesk = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.GrpServicos = New System.Windows.Forms.GroupBox()
        Me.DrgServicosAtendimento = New System.Windows.Forms.DataGridView()
        Me.grpSenha = New System.Windows.Forms.GroupBox()
        Me.btnValidaSenha = New System.Windows.Forms.Button()
        Me.mskSenha = New System.Windows.Forms.MaskedTextBox()
        Me.GrpServicoInformado = New System.Windows.Forms.GroupBox()
        Me.MskValorServico = New System.Windows.Forms.MaskedTextBox()
        Me.BtnAdicionarServico = New System.Windows.Forms.Button()
        Me.TxtCBHPM = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnAutoriza = New System.Windows.Forms.Button()
        Me.BtnPesquisarServico = New System.Windows.Forms.Button()
        Me.TxtServico = New System.Windows.Forms.TextBox()
        Me.rtbApoio = New System.Windows.Forms.RichTextBox()
        Me.grdIdentifica = New System.Windows.Forms.DataGridView()
        Me.GroupBiometria = New System.Windows.Forms.GroupBox()
        Me.lblSenha = New System.Windows.Forms.Label()
        Me.picMain = New System.Windows.Forms.PictureBox()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicPessoa = New System.Windows.Forms.PictureBox()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.GrpResponsavel = New System.Windows.Forms.GroupBox()
        Me.ViewResponsavel = New System.Windows.Forms.DataGridView()
        Me.chkRegistraSomenteExames = New System.Windows.Forms.CheckBox()
        Me.GrpUpload = New System.Windows.Forms.GroupBox()
        Me.txtArquivoDespesas = New System.Windows.Forms.TextBox()
        Me.PicBuscarArquivo = New System.Windows.Forms.PictureBox()
        Me.lblDataAtendimento = New System.Windows.Forms.Label()
        Me.grpSenhaConfirmacao = New System.Windows.Forms.GroupBox()
        Me.btnValidaSenhaConfirmacao = New System.Windows.Forms.Button()
        Me.mskSenhaConfirmacao = New System.Windows.Forms.MaskedTextBox()
        Me.GrpSenhaGerencial = New System.Windows.Forms.GroupBox()
        Me.BtnSenhaGerecnial = New System.Windows.Forms.Button()
        Me.MskSenhaGerencial = New System.Windows.Forms.MaskedTextBox()
        Me.GrpConsultas = New System.Windows.Forms.GroupBox()
        Me.cmbProcedimento = New System.Windows.Forms.ComboBox()
        Me.cmbProcedimento2 = New System.Windows.Forms.ComboBox()
        Me.mskValor = New System.Windows.Forms.MaskedTextBox()
        Me.mskValor2 = New System.Windows.Forms.MaskedTextBox()
        Me.grpAntendimento = New System.Windows.Forms.GroupBox()
        Me.panGrafico.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PicCorrigir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicQrCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpIdentificação.SuspendLayout()
        CType(Me.grdContribuintes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStatus.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.picLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMedico.SuspendLayout()
        CType(Me.PicAlerta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSetor.SuspendLayout()
        CType(Me.picAnyDesk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpServicos.SuspendLayout()
        CType(Me.DrgServicosAtendimento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSenha.SuspendLayout()
        Me.GrpServicoInformado.SuspendLayout()
        CType(Me.grdIdentifica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBiometria.SuspendLayout()
        CType(Me.picMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicPessoa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpResponsavel.SuspendLayout()
        CType(Me.ViewResponsavel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpUpload.SuspendLayout()
        CType(Me.PicBuscarArquivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSenhaConfirmacao.SuspendLayout()
        Me.GrpSenhaGerencial.SuspendLayout()
        Me.GrpConsultas.SuspendLayout()
        Me.grpAntendimento.SuspendLayout()
        Me.SuspendLayout()
        '
        'panGrafico
        '
        Me.panGrafico.Controls.Add(Me.Label2)
        Me.panGrafico.Controls.Add(Me.txtTotalAtendimentosGrafico)
        Me.panGrafico.Controls.Add(Me.cmbMesGrafico)
        Me.panGrafico.Controls.Add(Me.Chart1)
        Me.panGrafico.Location = New System.Drawing.Point(13, 139)
        Me.panGrafico.Name = "panGrafico"
        Me.panGrafico.Size = New System.Drawing.Size(735, 302)
        Me.panGrafico.TabIndex = 50
        Me.panGrafico.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(611, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 10)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Total no mês"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtTotalAtendimentosGrafico
        '
        Me.txtTotalAtendimentosGrafico.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalAtendimentosGrafico.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAtendimentosGrafico.Location = New System.Drawing.Point(611, 26)
        Me.txtTotalAtendimentosGrafico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalAtendimentosGrafico.Name = "txtTotalAtendimentosGrafico"
        Me.txtTotalAtendimentosGrafico.Size = New System.Drawing.Size(59, 19)
        Me.txtTotalAtendimentosGrafico.TabIndex = 74
        Me.txtTotalAtendimentosGrafico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbMesGrafico
        '
        Me.cmbMesGrafico.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesGrafico.FormattingEnabled = True
        Me.cmbMesGrafico.Items.AddRange(New Object() {"Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"})
        Me.cmbMesGrafico.Location = New System.Drawing.Point(496, 17)
        Me.cmbMesGrafico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbMesGrafico.Name = "cmbMesGrafico"
        Me.cmbMesGrafico.Size = New System.Drawing.Size(85, 24)
        Me.cmbMesGrafico.TabIndex = 71
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.LightBlue
        Me.Chart1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Percent30
        Me.Chart1.BorderlineColor = System.Drawing.Color.DarkRed
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea8.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea8)
        Legend8.Enabled = False
        Legend8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend8.IsTextAutoFit = False
        Legend8.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend8)
        Me.Chart1.Location = New System.Drawing.Point(9, 12)
        Me.Chart1.Name = "Chart1"
        Series8.ChartArea = "ChartArea1"
        Series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series8.Legend = "Legend1"
        Series8.LegendText = "Atendimentos"
        Series8.Name = "Atendimentos"
        Me.Chart1.Series.Add(Series8)
        Me.Chart1.Size = New System.Drawing.Size(718, 260)
        Me.Chart1.TabIndex = 73
        Title8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title8.Name = "Title1"
        Title8.Text = "Atendimentos do Prestador no mês"
        Me.Chart1.Titles.Add(Title8)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.PicCorrigir)
        Me.Panel2.Controls.Add(Me.btnImprimir)
        Me.Panel2.Controls.Add(Me.PicQrCode)
        Me.Panel2.Controls.Add(Me.picSMS)
        Me.Panel2.Controls.Add(Me.btnNaoCompareceu)
        Me.Panel2.Controls.Add(Me.btnLimpar)
        Me.Panel2.Location = New System.Drawing.Point(13, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(327, 46)
        Me.Panel2.TabIndex = 45
        '
        'PicCorrigir
        '
        Me.PicCorrigir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicCorrigir.Image = CType(resources.GetObject("PicCorrigir.Image"), System.Drawing.Image)
        Me.PicCorrigir.Location = New System.Drawing.Point(285, 6)
        Me.PicCorrigir.Name = "PicCorrigir"
        Me.PicCorrigir.Size = New System.Drawing.Size(39, 37)
        Me.PicCorrigir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicCorrigir.TabIndex = 87
        Me.PicCorrigir.TabStop = False
        Me.PicCorrigir.Tag = "Correção de atendimentos"
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(125, 5)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(39, 38)
        Me.btnImprimir.TabIndex = 86
        '
        'PicQrCode
        '
        Me.PicQrCode.Image = CType(resources.GetObject("PicQrCode.Image"), System.Drawing.Image)
        Me.PicQrCode.Location = New System.Drawing.Point(245, 6)
        Me.PicQrCode.Name = "PicQrCode"
        Me.PicQrCode.Size = New System.Drawing.Size(39, 36)
        Me.PicQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicQrCode.TabIndex = 84
        Me.PicQrCode.TabStop = False
        Me.PicQrCode.Tag = "Autorização de atendimento por QrCode"
        '
        'picSMS
        '
        Me.picSMS.Image = CType(resources.GetObject("picSMS.Image"), System.Drawing.Image)
        Me.picSMS.Location = New System.Drawing.Point(206, 6)
        Me.picSMS.Name = "picSMS"
        Me.picSMS.Size = New System.Drawing.Size(39, 36)
        Me.picSMS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSMS.TabIndex = 83
        Me.picSMS.TabStop = False
        Me.picSMS.Tag = "Autorização de atendimento por SMS"
        '
        'btnNaoCompareceu
        '
        Me.btnNaoCompareceu.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnNaoCompareceu.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNaoCompareceu.Location = New System.Drawing.Point(168, 5)
        Me.btnNaoCompareceu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNaoCompareceu.Name = "btnNaoCompareceu"
        Me.btnNaoCompareceu.Size = New System.Drawing.Size(39, 38)
        Me.btnNaoCompareceu.TabIndex = 82
        Me.btnNaoCompareceu.Text = "NC"
        Me.btnNaoCompareceu.UseVisualStyleBackColor = False
        '
        'btnLimpar
        '
        Me.btnLimpar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpar.Image = CType(resources.GetObject("btnLimpar.Image"), System.Drawing.Image)
        Me.btnLimpar.Location = New System.Drawing.Point(9, 5)
        Me.btnLimpar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(39, 38)
        Me.btnLimpar.TabIndex = 48
        '
        'cmbMedico
        '
        Me.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedico.FormattingEnabled = True
        Me.cmbMedico.Location = New System.Drawing.Point(7, 18)
        Me.cmbMedico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbMedico.Name = "cmbMedico"
        Me.cmbMedico.Size = New System.Drawing.Size(367, 21)
        Me.cmbMedico.TabIndex = 31
        '
        'grpIdentificação
        '
        Me.grpIdentificação.BackColor = System.Drawing.SystemColors.Control
        Me.grpIdentificação.Controls.Add(Me.Label3)
        Me.grpIdentificação.Controls.Add(Me.txtCPF)
        Me.grpIdentificação.Controls.Add(Me.lblPessoa)
        Me.grpIdentificação.Controls.Add(Me.grdContribuintes)
        Me.grpIdentificação.Controls.Add(Me.btnMatricula)
        Me.grpIdentificação.Controls.Add(Me.lblMatricula)
        Me.grpIdentificação.Controls.Add(Me.txtMatricula)
        Me.grpIdentificação.ForeColor = System.Drawing.Color.Maroon
        Me.grpIdentificação.Location = New System.Drawing.Point(13, 74)
        Me.grpIdentificação.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpIdentificação.Name = "grpIdentificação"
        Me.grpIdentificação.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpIdentificação.Size = New System.Drawing.Size(738, 47)
        Me.grpIdentificação.TabIndex = 15
        Me.grpIdentificação.TabStop = False
        Me.grpIdentificação.Text = "Identificação do Contribuinte"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(151, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "CPF:"
        '
        'txtCPF
        '
        Me.txtCPF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCPF.Location = New System.Drawing.Point(187, 19)
        Me.txtCPF.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCPF.MaxLength = 15
        Me.txtCPF.Name = "txtCPF"
        Me.txtCPF.Size = New System.Drawing.Size(97, 22)
        Me.txtCPF.TabIndex = 13
        '
        'lblPessoa
        '
        Me.lblPessoa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPessoa.Location = New System.Drawing.Point(327, 17)
        Me.lblPessoa.Name = "lblPessoa"
        Me.lblPessoa.Size = New System.Drawing.Size(402, 23)
        Me.lblPessoa.TabIndex = 16
        Me.lblPessoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdContribuintes
        '
        Me.grdContribuintes.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.grdContribuintes.AllowUserToAddRows = False
        Me.grdContribuintes.AllowUserToDeleteRows = False
        Me.grdContribuintes.AllowUserToResizeColumns = False
        Me.grdContribuintes.AllowUserToResizeRows = False
        DataGridViewCellStyle92.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle92.SelectionBackColor = System.Drawing.Color.Maroon
        Me.grdContribuintes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle92
        Me.grdContribuintes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdContribuintes.BackgroundColor = System.Drawing.Color.White
        Me.grdContribuintes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdContribuintes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle93.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle93.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle93.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle93.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle93.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle93.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle93.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdContribuintes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle93
        Me.grdContribuintes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdContribuintes.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle94.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle94.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle94.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle94.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle94.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle94.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle94.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdContribuintes.DefaultCellStyle = DataGridViewCellStyle94
        Me.grdContribuintes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.grdContribuintes.EnableHeadersVisualStyles = False
        Me.grdContribuintes.GridColor = System.Drawing.Color.Maroon
        Me.grdContribuintes.Location = New System.Drawing.Point(21, 62)
        Me.grdContribuintes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grdContribuintes.MultiSelect = False
        Me.grdContribuintes.Name = "grdContribuintes"
        Me.grdContribuintes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdContribuintes.RowTemplate.Height = 24
        Me.grdContribuintes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdContribuintes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdContribuintes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdContribuintes.ShowCellErrors = False
        Me.grdContribuintes.ShowCellToolTips = False
        Me.grdContribuintes.ShowEditingIcon = False
        Me.grdContribuintes.ShowRowErrors = False
        Me.grdContribuintes.Size = New System.Drawing.Size(615, 221)
        Me.grdContribuintes.TabIndex = 15
        '
        'btnMatricula
        '
        Me.btnMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMatricula.Image = CType(resources.GetObject("btnMatricula.Image"), System.Drawing.Image)
        Me.btnMatricula.Location = New System.Drawing.Point(288, 14)
        Me.btnMatricula.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMatricula.Name = "btnMatricula"
        Me.btnMatricula.Size = New System.Drawing.Size(28, 27)
        Me.btnMatricula.TabIndex = 14
        Me.btnMatricula.UseVisualStyleBackColor = True
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.Location = New System.Drawing.Point(6, 22)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(61, 15)
        Me.lblMatricula.TabIndex = 13
        Me.lblMatricula.Text = "Matricula:"
        '
        'txtMatricula
        '
        Me.txtMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula.Location = New System.Drawing.Point(69, 19)
        Me.txtMatricula.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(76, 22)
        Me.txtMatricula.TabIndex = 12
        '
        'grpStatus
        '
        Me.grpStatus.BackColor = System.Drawing.SystemColors.Control
        Me.grpStatus.Controls.Add(Me.LogList)
        Me.grpStatus.Controls.Add(Me.Panel1)
        Me.grpStatus.Controls.Add(Me.PictureBox1)
        Me.grpStatus.Controls.Add(Me.PictureBox2)
        Me.grpStatus.Controls.Add(Me.lblIP)
        Me.grpStatus.Controls.Add(Me.FlowLayoutPanel1)
        Me.grpStatus.ForeColor = System.Drawing.Color.Maroon
        Me.grpStatus.Location = New System.Drawing.Point(12, 584)
        Me.grpStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpStatus.Size = New System.Drawing.Size(736, 68)
        Me.grpStatus.TabIndex = 16
        Me.grpStatus.TabStop = False
        '
        'LogList
        '
        Me.LogList.Items.AddRange(New Object() {"+"})
        Me.LogList.Location = New System.Drawing.Point(9, 7)
        Me.LogList.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LogList.Name = "LogList"
        Me.LogList.ScrollAlwaysVisible = True
        Me.LogList.Size = New System.Drawing.Size(32, 56)
        Me.LogList.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.mskTotal)
        Me.Panel1.Location = New System.Drawing.Point(595, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(135, 54)
        Me.Panel1.TabIndex = 93
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(18, 3)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(106, 15)
        Me.lblTotal.TabIndex = 95
        Me.lblTotal.Text = "Total dos Serviços"
        '
        'mskTotal
        '
        Me.mskTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskTotal.Location = New System.Drawing.Point(17, 20)
        Me.mskTotal.Name = "mskTotal"
        Me.mskTotal.Size = New System.Drawing.Size(109, 31)
        Me.mskTotal.TabIndex = 94
        Me.mskTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(39, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(140, 54)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = "www.pelotas.com.br"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(184, 9)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(134, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 40
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Tag = "www.coinpel.com.br"
        '
        'lblIP
        '
        Me.lblIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIP.AutoSize = True
        Me.lblIP.ForeColor = System.Drawing.Color.Black
        Me.lblIP.Location = New System.Drawing.Point(181, 49)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(27, 13)
        Me.lblIP.TabIndex = 92
        Me.lblIP.Text = "lblIP"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FlowLayoutPanel1.Controls.Add(Me.picLogin)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblUsuarioCorrente)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(366, 9)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(223, 29)
        Me.FlowLayoutPanel1.TabIndex = 55
        '
        'picLogin
        '
        Me.picLogin.BackColor = System.Drawing.Color.GhostWhite
        Me.picLogin.Image = CType(resources.GetObject("picLogin.Image"), System.Drawing.Image)
        Me.picLogin.Location = New System.Drawing.Point(3, 3)
        Me.picLogin.Name = "picLogin"
        Me.picLogin.Size = New System.Drawing.Size(33, 23)
        Me.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogin.TabIndex = 54
        Me.picLogin.TabStop = False
        Me.picLogin.Tag = "Localize o Conveniado no Google Maps."
        '
        'lblUsuarioCorrente
        '
        Me.lblUsuarioCorrente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblUsuarioCorrente.ForeColor = System.Drawing.Color.Black
        Me.lblUsuarioCorrente.Location = New System.Drawing.Point(42, 8)
        Me.lblUsuarioCorrente.Name = "lblUsuarioCorrente"
        Me.lblUsuarioCorrente.Size = New System.Drawing.Size(156, 12)
        Me.lblUsuarioCorrente.TabIndex = 17
        Me.lblUsuarioCorrente.Text = "lblUsuarioCorrente"
        Me.lblUsuarioCorrente.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DigitalParaUsuariosToolStripMenuItem, Me.AutorizaçõesToolStripMenuItem, Me.DigitalParaUsuariosToolStripMenuItem1, Me.SIFAMToolStripMenuItem, Me.AjudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(3, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(760, 24)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DigitalParaUsuariosToolStripMenuItem
        '
        Me.DigitalParaUsuariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DigitaisToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.RegistroDePacotesToolStripMenuItem, Me.ResumoDePacotesToolStripMenuItem, Me.EspelhoDeNFToolStripMenuItem, Me.RelatórioDeExamesProcedimentosToolStripMenuItem})
        Me.DigitalParaUsuariosToolStripMenuItem.Name = "DigitalParaUsuariosToolStripMenuItem"
        Me.DigitalParaUsuariosToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.DigitalParaUsuariosToolStripMenuItem.Text = "Relatórios"
        '
        'DigitaisToolStripMenuItem
        '
        Me.DigitaisToolStripMenuItem.Name = "DigitaisToolStripMenuItem"
        Me.DigitaisToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.DigitaisToolStripMenuItem.Text = "Digitais"
        Me.DigitaisToolStripMenuItem.Visible = False
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ConsultasToolStripMenuItem.Text = "Registro Diário"
        '
        'RegistroDePacotesToolStripMenuItem
        '
        Me.RegistroDePacotesToolStripMenuItem.Name = "RegistroDePacotesToolStripMenuItem"
        Me.RegistroDePacotesToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.RegistroDePacotesToolStripMenuItem.Text = "Registro de Autorizações"
        '
        'ResumoDePacotesToolStripMenuItem
        '
        Me.ResumoDePacotesToolStripMenuItem.Name = "ResumoDePacotesToolStripMenuItem"
        Me.ResumoDePacotesToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ResumoDePacotesToolStripMenuItem.Text = "Resumo de Autorizações"
        '
        'EspelhoDeNFToolStripMenuItem
        '
        Me.EspelhoDeNFToolStripMenuItem.Name = "EspelhoDeNFToolStripMenuItem"
        Me.EspelhoDeNFToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.EspelhoDeNFToolStripMenuItem.Text = "Faturamento Mensal"
        '
        'RelatórioDeExamesProcedimentosToolStripMenuItem
        '
        Me.RelatórioDeExamesProcedimentosToolStripMenuItem.Name = "RelatórioDeExamesProcedimentosToolStripMenuItem"
        Me.RelatórioDeExamesProcedimentosToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.RelatórioDeExamesProcedimentosToolStripMenuItem.Text = "Relatório de Exames/Procedimentos"
        '
        'AutorizaçõesToolStripMenuItem
        '
        Me.AutorizaçõesToolStripMenuItem.Enabled = False
        Me.AutorizaçõesToolStripMenuItem.Name = "AutorizaçõesToolStripMenuItem"
        Me.AutorizaçõesToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.AutorizaçõesToolStripMenuItem.Text = "Autorizações"
        '
        'DigitalParaUsuariosToolStripMenuItem1
        '
        Me.DigitalParaUsuariosToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EstatísticoToolStripMenuItem, Me.DigitalParaUsuáriosToolStripMenuItem, Me.ToolStripMenuItem1, Me.MarcaçãoOFFLineToolStripMenuItem, Me.CorreçõesEmProcedimentosToolStripMenuItem, Me.UploadPlanilhasFechamentoToolStripMenuItem, Me.UploadDeCredenciamentoToolStripMenuItem, Me.AutorizaçãoRemotaToolStripMenuItem, Me.AlterarOrdemDeClassificaçãoDeExamesProcedimentosToolStripMenuItem})
        Me.DigitalParaUsuariosToolStripMenuItem1.Name = "DigitalParaUsuariosToolStripMenuItem1"
        Me.DigitalParaUsuariosToolStripMenuItem1.Size = New System.Drawing.Size(65, 20)
        Me.DigitalParaUsuariosToolStripMenuItem1.Text = "Controle"
        '
        'EstatísticoToolStripMenuItem
        '
        Me.EstatísticoToolStripMenuItem.Name = "EstatísticoToolStripMenuItem"
        Me.EstatísticoToolStripMenuItem.Size = New System.Drawing.Size(404, 22)
        Me.EstatísticoToolStripMenuItem.Text = "Estatística de Validação Biométrica"
        '
        'DigitalParaUsuáriosToolStripMenuItem
        '
        Me.DigitalParaUsuáriosToolStripMenuItem.Name = "DigitalParaUsuáriosToolStripMenuItem"
        Me.DigitalParaUsuáriosToolStripMenuItem.Size = New System.Drawing.Size(404, 22)
        Me.DigitalParaUsuáriosToolStripMenuItem.Text = "Digital para Usuários"
        Me.DigitalParaUsuáriosToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(401, 6)
        '
        'MarcaçãoOFFLineToolStripMenuItem
        '
        Me.MarcaçãoOFFLineToolStripMenuItem.Name = "MarcaçãoOFFLineToolStripMenuItem"
        Me.MarcaçãoOFFLineToolStripMenuItem.Size = New System.Drawing.Size(404, 22)
        Me.MarcaçãoOFFLineToolStripMenuItem.Text = "Registro Posterior Justificado - RPJ"
        '
        'CorreçõesEmProcedimentosToolStripMenuItem
        '
        Me.CorreçõesEmProcedimentosToolStripMenuItem.Name = "CorreçõesEmProcedimentosToolStripMenuItem"
        Me.CorreçõesEmProcedimentosToolStripMenuItem.Size = New System.Drawing.Size(404, 22)
        Me.CorreçõesEmProcedimentosToolStripMenuItem.Text = "Corrigir/Cancelar Atendimento"
        '
        'UploadPlanilhasFechamentoToolStripMenuItem
        '
        Me.UploadPlanilhasFechamentoToolStripMenuItem.Name = "UploadPlanilhasFechamentoToolStripMenuItem"
        Me.UploadPlanilhasFechamentoToolStripMenuItem.Size = New System.Drawing.Size(404, 22)
        Me.UploadPlanilhasFechamentoToolStripMenuItem.Text = "Upload de Solicitações e Despesas de Procedimentos e Exames"
        '
        'UploadDeCredenciamentoToolStripMenuItem
        '
        Me.UploadDeCredenciamentoToolStripMenuItem.Name = "UploadDeCredenciamentoToolStripMenuItem"
        Me.UploadDeCredenciamentoToolStripMenuItem.Size = New System.Drawing.Size(404, 22)
        Me.UploadDeCredenciamentoToolStripMenuItem.Text = "Upload de Documentos do Credenciado"
        '
        'AutorizaçãoRemotaToolStripMenuItem
        '
        Me.AutorizaçãoRemotaToolStripMenuItem.Name = "AutorizaçãoRemotaToolStripMenuItem"
        Me.AutorizaçãoRemotaToolStripMenuItem.Size = New System.Drawing.Size(404, 22)
        Me.AutorizaçãoRemotaToolStripMenuItem.Text = "Autorização Remota"
        '
        'AlterarOrdemDeClassificaçãoDeExamesProcedimentosToolStripMenuItem
        '
        Me.AlterarOrdemDeClassificaçãoDeExamesProcedimentosToolStripMenuItem.Name = "AlterarOrdemDeClassificaçãoDeExamesProcedimentosToolStripMenuItem"
        Me.AlterarOrdemDeClassificaçãoDeExamesProcedimentosToolStripMenuItem.Size = New System.Drawing.Size(404, 22)
        Me.AlterarOrdemDeClassificaçãoDeExamesProcedimentosToolStripMenuItem.Text = "Alterar Ordem de Classificação de Exames/Procedimentos"
        '
        'SIFAMToolStripMenuItem
        '
        Me.SIFAMToolStripMenuItem.Name = "SIFAMToolStripMenuItem"
        Me.SIFAMToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.SIFAMToolStripMenuItem.Text = "SIFAM"
        '
        'AjudaToolStripMenuItem
        '
        Me.AjudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtualizarÚltimaVersãoToolStripMenuItem, Me.ToolStripMenuItem2, Me.SuporteRemotoToolStripMenuItem, Me.WebSitePREVPELToolStripMenuItem, Me.TabelaCBHPMToolStripMenuItem, Me.ToolStripSeparator1, Me.SobreToolStripMenuItem, Me.AjustesEspeciaisToolStripMenuItem, Me.ToolStripSeparator2, Me.TutorialSMSToolStripMenuItem})
        Me.AjudaToolStripMenuItem.Name = "AjudaToolStripMenuItem"
        Me.AjudaToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.AjudaToolStripMenuItem.Text = "Ajuda"
        '
        'AtualizarÚltimaVersãoToolStripMenuItem
        '
        Me.AtualizarÚltimaVersãoToolStripMenuItem.Name = "AtualizarÚltimaVersãoToolStripMenuItem"
        Me.AtualizarÚltimaVersãoToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.AtualizarÚltimaVersãoToolStripMenuItem.Text = "Atualizar última versão"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(207, 22)
        Me.ToolStripMenuItem2.Text = "Histórico de Atualizações"
        '
        'SuporteRemotoToolStripMenuItem
        '
        Me.SuporteRemotoToolStripMenuItem.Name = "SuporteRemotoToolStripMenuItem"
        Me.SuporteRemotoToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.SuporteRemotoToolStripMenuItem.Text = "Suporte Remoto"
        '
        'WebSitePREVPELToolStripMenuItem
        '
        Me.WebSitePREVPELToolStripMenuItem.Name = "WebSitePREVPELToolStripMenuItem"
        Me.WebSitePREVPELToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.WebSitePREVPELToolStripMenuItem.Text = "WebSite PREVPEL"
        '
        'TabelaCBHPMToolStripMenuItem
        '
        Me.TabelaCBHPMToolStripMenuItem.Name = "TabelaCBHPMToolStripMenuItem"
        Me.TabelaCBHPMToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.TabelaCBHPMToolStripMenuItem.Text = "Tabela CBHPM"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(204, 6)
        '
        'SobreToolStripMenuItem
        '
        Me.SobreToolStripMenuItem.Name = "SobreToolStripMenuItem"
        Me.SobreToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.SobreToolStripMenuItem.Text = "Configuração Estação"
        '
        'AjustesEspeciaisToolStripMenuItem
        '
        Me.AjustesEspeciaisToolStripMenuItem.Name = "AjustesEspeciaisToolStripMenuItem"
        Me.AjustesEspeciaisToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.AjustesEspeciaisToolStripMenuItem.Text = "Ajustes Especiais"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(204, 6)
        '
        'TutorialSMSToolStripMenuItem
        '
        Me.TutorialSMSToolStripMenuItem.Name = "TutorialSMSToolStripMenuItem"
        Me.TutorialSMSToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.TutorialSMSToolStripMenuItem.Text = "Tutoriais"
        '
        'AxGrFingerXCtrl1
        '
        Me.AxGrFingerXCtrl1.Enabled = True
        Me.AxGrFingerXCtrl1.Location = New System.Drawing.Point(371, 0)
        Me.AxGrFingerXCtrl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AxGrFingerXCtrl1.Name = "AxGrFingerXCtrl1"
        Me.AxGrFingerXCtrl1.OcxState = CType(resources.GetObject("AxGrFingerXCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxGrFingerXCtrl1.Size = New System.Drawing.Size(32, 32)
        Me.AxGrFingerXCtrl1.TabIndex = 23
        '
        'PrintDocument1
        '
        '
        'Timer1
        '
        '
        'btnConsultarSessoes
        '
        Me.btnConsultarSessoes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultarSessoes.Location = New System.Drawing.Point(523, 2)
        Me.btnConsultarSessoes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnConsultarSessoes.Name = "btnConsultarSessoes"
        Me.btnConsultarSessoes.Size = New System.Drawing.Size(133, 21)
        Me.btnConsultarSessoes.TabIndex = 53
        Me.btnConsultarSessoes.Text = "Consultar Fisioterapias"
        Me.btnConsultarSessoes.Visible = False
        '
        'GrpMedico
        '
        Me.GrpMedico.BackColor = System.Drawing.SystemColors.Control
        Me.GrpMedico.Controls.Add(Me.PicAlerta)
        Me.GrpMedico.Controls.Add(Me.cmbMedico)
        Me.GrpMedico.Controls.Add(Me.AxGrFingerXCtrl1)
        Me.GrpMedico.ForeColor = System.Drawing.Color.Maroon
        Me.GrpMedico.Location = New System.Drawing.Point(343, 26)
        Me.GrpMedico.Name = "GrpMedico"
        Me.GrpMedico.Size = New System.Drawing.Size(409, 46)
        Me.GrpMedico.TabIndex = 56
        Me.GrpMedico.TabStop = False
        Me.GrpMedico.Text = "Profissional"
        '
        'PicAlerta
        '
        Me.PicAlerta.BackColor = System.Drawing.Color.GhostWhite
        Me.PicAlerta.Image = CType(resources.GetObject("PicAlerta.Image"), System.Drawing.Image)
        Me.PicAlerta.Location = New System.Drawing.Point(378, 18)
        Me.PicAlerta.Name = "PicAlerta"
        Me.PicAlerta.Size = New System.Drawing.Size(28, 22)
        Me.PicAlerta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicAlerta.TabIndex = 94
        Me.PicAlerta.TabStop = False
        Me.PicAlerta.Tag = "Localize o Conveniado no Google Maps."
        Me.PicAlerta.Visible = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipTitle = "Biosifam"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Biosifam-Segundo Plano"
        '
        'GrpSetor
        '
        Me.GrpSetor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpSetor.BackColor = System.Drawing.SystemColors.Control
        Me.GrpSetor.Controls.Add(Me.CmbSetor)
        Me.GrpSetor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpSetor.ForeColor = System.Drawing.Color.Maroon
        Me.GrpSetor.Location = New System.Drawing.Point(331, 2)
        Me.GrpSetor.Name = "GrpSetor"
        Me.GrpSetor.Size = New System.Drawing.Size(358, 22)
        Me.GrpSetor.TabIndex = 91
        Me.GrpSetor.TabStop = False
        Me.GrpSetor.Text = "Setor: "
        Me.GrpSetor.Visible = False
        '
        'CmbSetor
        '
        Me.CmbSetor.BackColor = System.Drawing.Color.Yellow
        Me.CmbSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSetor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSetor.ForeColor = System.Drawing.Color.Red
        Me.CmbSetor.FormattingEnabled = True
        Me.CmbSetor.Location = New System.Drawing.Point(41, -1)
        Me.CmbSetor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbSetor.Name = "CmbSetor"
        Me.CmbSetor.Size = New System.Drawing.Size(317, 24)
        Me.CmbSetor.TabIndex = 31
        '
        'picAnyDesk
        '
        Me.picAnyDesk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picAnyDesk.Image = CType(resources.GetObject("picAnyDesk.Image"), System.Drawing.Image)
        Me.picAnyDesk.Location = New System.Drawing.Point(724, 0)
        Me.picAnyDesk.Name = "picAnyDesk"
        Me.picAnyDesk.Size = New System.Drawing.Size(27, 23)
        Me.picAnyDesk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAnyDesk.TabIndex = 90
        Me.picAnyDesk.TabStop = False
        Me.picAnyDesk.Tag = "Localize o Conveniado no Google Maps."
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(695, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(28, 23)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 46
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Tag = "Localize o Conveniado no Google Maps."
        '
        'btnGravar
        '
        Me.btnGravar.Enabled = False
        Me.btnGravar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.Location = New System.Drawing.Point(61, 31)
        Me.btnGravar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(41, 38)
        Me.btnGravar.TabIndex = 43
        '
        'btnExcluir
        '
        Me.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExcluir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.Image = CType(resources.GetObject("btnExcluir.Image"), System.Drawing.Image)
        Me.btnExcluir.Location = New System.Drawing.Point(97, 31)
        Me.btnExcluir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(42, 38)
        Me.btnExcluir.TabIndex = 44
        '
        'GrpServicos
        '
        Me.GrpServicos.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrpServicos.Controls.Add(Me.DrgServicosAtendimento)
        Me.GrpServicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpServicos.ForeColor = System.Drawing.Color.Maroon
        Me.GrpServicos.Location = New System.Drawing.Point(12, 206)
        Me.GrpServicos.Name = "GrpServicos"
        Me.GrpServicos.Size = New System.Drawing.Size(705, 244)
        Me.GrpServicos.TabIndex = 93
        Me.GrpServicos.TabStop = False
        Me.GrpServicos.Text = "Exames informados"
        Me.GrpServicos.Visible = False
        '
        'DrgServicosAtendimento
        '
        Me.DrgServicosAtendimento.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.DrgServicosAtendimento.AllowUserToAddRows = False
        Me.DrgServicosAtendimento.AllowUserToDeleteRows = False
        Me.DrgServicosAtendimento.AllowUserToResizeColumns = False
        Me.DrgServicosAtendimento.AllowUserToResizeRows = False
        DataGridViewCellStyle95.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle95.SelectionBackColor = System.Drawing.Color.Maroon
        Me.DrgServicosAtendimento.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle95
        Me.DrgServicosAtendimento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DrgServicosAtendimento.BackgroundColor = System.Drawing.Color.White
        Me.DrgServicosAtendimento.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.DrgServicosAtendimento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle96.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle96.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle96.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle96.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle96.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle96.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle96.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DrgServicosAtendimento.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle96
        Me.DrgServicosAtendimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DrgServicosAtendimento.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle97.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle97.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle97.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle97.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle97.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle97.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle97.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DrgServicosAtendimento.DefaultCellStyle = DataGridViewCellStyle97
        Me.DrgServicosAtendimento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.DrgServicosAtendimento.EnableHeadersVisualStyles = False
        Me.DrgServicosAtendimento.GridColor = System.Drawing.Color.Maroon
        Me.DrgServicosAtendimento.Location = New System.Drawing.Point(15, 19)
        Me.DrgServicosAtendimento.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
        Me.DrgServicosAtendimento.MultiSelect = False
        Me.DrgServicosAtendimento.Name = "DrgServicosAtendimento"
        Me.DrgServicosAtendimento.ReadOnly = True
        Me.DrgServicosAtendimento.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DrgServicosAtendimento.RowTemplate.Height = 24
        Me.DrgServicosAtendimento.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DrgServicosAtendimento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DrgServicosAtendimento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DrgServicosAtendimento.ShowCellErrors = False
        Me.DrgServicosAtendimento.ShowCellToolTips = False
        Me.DrgServicosAtendimento.ShowEditingIcon = False
        Me.DrgServicosAtendimento.ShowRowErrors = False
        Me.DrgServicosAtendimento.Size = New System.Drawing.Size(684, 218)
        Me.DrgServicosAtendimento.TabIndex = 54
        '
        'grpSenha
        '
        Me.grpSenha.BackColor = System.Drawing.Color.Aquamarine
        Me.grpSenha.Controls.Add(Me.btnValidaSenha)
        Me.grpSenha.Controls.Add(Me.mskSenha)
        Me.grpSenha.Location = New System.Drawing.Point(272, 193)
        Me.grpSenha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpSenha.Name = "grpSenha"
        Me.grpSenha.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpSenha.Size = New System.Drawing.Size(177, 49)
        Me.grpSenha.TabIndex = 36
        Me.grpSenha.TabStop = False
        Me.grpSenha.Text = "Senha"
        Me.grpSenha.Visible = False
        '
        'btnValidaSenha
        '
        Me.btnValidaSenha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidaSenha.Image = CType(resources.GetObject("btnValidaSenha.Image"), System.Drawing.Image)
        Me.btnValidaSenha.Location = New System.Drawing.Point(135, 19)
        Me.btnValidaSenha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnValidaSenha.Name = "btnValidaSenha"
        Me.btnValidaSenha.Size = New System.Drawing.Size(33, 22)
        Me.btnValidaSenha.TabIndex = 9
        '
        'mskSenha
        '
        Me.mskSenha.Location = New System.Drawing.Point(17, 20)
        Me.mskSenha.Name = "mskSenha"
        Me.mskSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.mskSenha.Size = New System.Drawing.Size(115, 20)
        Me.mskSenha.TabIndex = 7
        '
        'GrpServicoInformado
        '
        Me.GrpServicoInformado.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrpServicoInformado.Controls.Add(Me.MskValorServico)
        Me.GrpServicoInformado.Controls.Add(Me.BtnAdicionarServico)
        Me.GrpServicoInformado.Controls.Add(Me.TxtCBHPM)
        Me.GrpServicoInformado.Controls.Add(Me.Label1)
        Me.GrpServicoInformado.Controls.Add(Me.BtnAutoriza)
        Me.GrpServicoInformado.Controls.Add(Me.BtnPesquisarServico)
        Me.GrpServicoInformado.Controls.Add(Me.TxtServico)
        Me.GrpServicoInformado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpServicoInformado.ForeColor = System.Drawing.Color.Maroon
        Me.GrpServicoInformado.Location = New System.Drawing.Point(12, 162)
        Me.GrpServicoInformado.Name = "GrpServicoInformado"
        Me.GrpServicoInformado.Size = New System.Drawing.Size(705, 46)
        Me.GrpServicoInformado.TabIndex = 93
        Me.GrpServicoInformado.TabStop = False
        Me.GrpServicoInformado.Text = "Informe o Exame/Procedimento realizado"
        Me.GrpServicoInformado.Visible = False
        '
        'MskValorServico
        '
        Me.MskValorServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MskValorServico.Location = New System.Drawing.Point(507, 13)
        Me.MskValorServico.Name = "MskValorServico"
        Me.MskValorServico.Size = New System.Drawing.Size(86, 26)
        Me.MskValorServico.TabIndex = 22
        Me.MskValorServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnAdicionarServico
        '
        Me.BtnAdicionarServico.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdicionarServico.Image = CType(resources.GetObject("BtnAdicionarServico.Image"), System.Drawing.Image)
        Me.BtnAdicionarServico.Location = New System.Drawing.Point(591, 12)
        Me.BtnAdicionarServico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnAdicionarServico.Name = "BtnAdicionarServico"
        Me.BtnAdicionarServico.Size = New System.Drawing.Size(33, 27)
        Me.BtnAdicionarServico.TabIndex = 27
        '
        'TxtCBHPM
        '
        Me.TxtCBHPM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCBHPM.Location = New System.Drawing.Point(471, 0)
        Me.TxtCBHPM.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCBHPM.MaxLength = 15
        Me.TxtCBHPM.Name = "TxtCBHPM"
        Me.TxtCBHPM.Size = New System.Drawing.Size(40, 22)
        Me.TxtCBHPM.TabIndex = 26
        Me.TxtCBHPM.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(470, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Valor :"
        '
        'BtnAutoriza
        '
        Me.BtnAutoriza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAutoriza.Location = New System.Drawing.Point(627, 8)
        Me.BtnAutoriza.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnAutoriza.Name = "BtnAutoriza"
        Me.BtnAutoriza.Size = New System.Drawing.Size(72, 34)
        Me.BtnAutoriza.TabIndex = 108
        Me.BtnAutoriza.Text = "Prescrição Autorização"
        '
        'BtnPesquisarServico
        '
        Me.BtnPesquisarServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPesquisarServico.Image = CType(resources.GetObject("BtnPesquisarServico.Image"), System.Drawing.Image)
        Me.BtnPesquisarServico.Location = New System.Drawing.Point(434, 15)
        Me.BtnPesquisarServico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnPesquisarServico.Name = "BtnPesquisarServico"
        Me.BtnPesquisarServico.Size = New System.Drawing.Size(26, 24)
        Me.BtnPesquisarServico.TabIndex = 24
        Me.BtnPesquisarServico.UseVisualStyleBackColor = True
        '
        'TxtServico
        '
        Me.TxtServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtServico.Location = New System.Drawing.Point(15, 16)
        Me.TxtServico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtServico.Name = "TxtServico"
        Me.TxtServico.Size = New System.Drawing.Size(425, 22)
        Me.TxtServico.TabIndex = 21
        '
        'rtbApoio
        '
        Me.rtbApoio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rtbApoio.Enabled = False
        Me.rtbApoio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbApoio.Location = New System.Drawing.Point(11, 14)
        Me.rtbApoio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rtbApoio.Name = "rtbApoio"
        Me.rtbApoio.Size = New System.Drawing.Size(486, 138)
        Me.rtbApoio.TabIndex = 23
        Me.rtbApoio.Text = ""
        '
        'grdIdentifica
        '
        Me.grdIdentifica.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.grdIdentifica.AllowUserToAddRows = False
        Me.grdIdentifica.AllowUserToDeleteRows = False
        Me.grdIdentifica.AllowUserToResizeColumns = False
        Me.grdIdentifica.AllowUserToResizeRows = False
        DataGridViewCellStyle98.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle98.SelectionBackColor = System.Drawing.Color.Maroon
        Me.grdIdentifica.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle98
        Me.grdIdentifica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdIdentifica.BackgroundColor = System.Drawing.Color.White
        Me.grdIdentifica.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdIdentifica.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle99.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle99.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle99.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle99.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle99.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle99.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle99.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdIdentifica.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle99
        Me.grdIdentifica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdIdentifica.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle100.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle100.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle100.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle100.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle100.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle100.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdIdentifica.DefaultCellStyle = DataGridViewCellStyle100
        Me.grdIdentifica.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.grdIdentifica.EnableHeadersVisualStyles = False
        Me.grdIdentifica.GridColor = System.Drawing.Color.Maroon
        Me.grdIdentifica.Location = New System.Drawing.Point(12, 117)
        Me.grdIdentifica.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grdIdentifica.MultiSelect = False
        Me.grdIdentifica.Name = "grdIdentifica"
        Me.grdIdentifica.ReadOnly = True
        DataGridViewCellStyle101.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle101.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle101.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle101.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle101.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle101.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle101.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdIdentifica.RowHeadersDefaultCellStyle = DataGridViewCellStyle101
        Me.grdIdentifica.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdIdentifica.RowTemplate.Height = 24
        Me.grdIdentifica.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdIdentifica.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.grdIdentifica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdIdentifica.ShowCellErrors = False
        Me.grdIdentifica.ShowCellToolTips = False
        Me.grdIdentifica.ShowEditingIcon = False
        Me.grdIdentifica.ShowRowErrors = False
        Me.grdIdentifica.Size = New System.Drawing.Size(452, 46)
        Me.grdIdentifica.TabIndex = 26
        Me.grdIdentifica.Visible = False
        '
        'GroupBiometria
        '
        Me.GroupBiometria.BackColor = System.Drawing.Color.Maroon
        Me.GroupBiometria.Controls.Add(Me.lblSenha)
        Me.GroupBiometria.Controls.Add(Me.picMain)
        Me.GroupBiometria.Controls.Add(Me.lblSituacao)
        Me.GroupBiometria.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBiometria.ForeColor = System.Drawing.Color.White
        Me.GroupBiometria.Location = New System.Drawing.Point(617, 13)
        Me.GroupBiometria.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBiometria.Name = "GroupBiometria"
        Me.GroupBiometria.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBiometria.Size = New System.Drawing.Size(99, 138)
        Me.GroupBiometria.TabIndex = 29
        Me.GroupBiometria.TabStop = False
        Me.GroupBiometria.Text = "Leitor Biométrico"
        '
        'lblSenha
        '
        Me.lblSenha.BackColor = System.Drawing.Color.Yellow
        Me.lblSenha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSenha.ForeColor = System.Drawing.Color.Black
        Me.lblSenha.Location = New System.Drawing.Point(15, 18)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(68, 96)
        Me.lblSenha.TabIndex = 27
        Me.lblSenha.Text = "Identificação digital desativada. Usuário utilizando senha."
        Me.lblSenha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picMain
        '
        Me.picMain.BackColor = System.Drawing.SystemColors.Control
        Me.picMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMain.Location = New System.Drawing.Point(11, 16)
        Me.picMain.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picMain.Name = "picMain"
        Me.picMain.Size = New System.Drawing.Size(75, 101)
        Me.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMain.TabIndex = 26
        Me.picMain.TabStop = False
        '
        'lblSituacao
        '
        Me.lblSituacao.Location = New System.Drawing.Point(9, 119)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(81, 15)
        Me.lblSituacao.TabIndex = 25
        Me.lblSituacao.Text = "Conexão"
        Me.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Controls.Add(Me.PicPessoa)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(506, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(105, 138)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "DuploClick amplia a foto."
        Me.GroupBox1.Text = "Foto"
        '
        'PicPessoa
        '
        Me.PicPessoa.Location = New System.Drawing.Point(6, 16)
        Me.PicPessoa.Name = "PicPessoa"
        Me.PicPessoa.Size = New System.Drawing.Size(93, 115)
        Me.PicPessoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicPessoa.TabIndex = 92
        Me.PicPessoa.TabStop = False
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.Location = New System.Drawing.Point(558, 10)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(35, 15)
        Me.lblValor.TabIndex = 48
        Me.lblValor.Text = "Valor"
        '
        'GrpResponsavel
        '
        Me.GrpResponsavel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrpResponsavel.Controls.Add(Me.ViewResponsavel)
        Me.GrpResponsavel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpResponsavel.ForeColor = System.Drawing.Color.Maroon
        Me.GrpResponsavel.Location = New System.Drawing.Point(87, 11)
        Me.GrpResponsavel.Name = "GrpResponsavel"
        Me.GrpResponsavel.Size = New System.Drawing.Size(399, 137)
        Me.GrpResponsavel.TabIndex = 54
        Me.GrpResponsavel.TabStop = False
        Me.GrpResponsavel.Text = "Selecione o responsável pela consulta"
        Me.GrpResponsavel.Visible = False
        '
        'ViewResponsavel
        '
        Me.ViewResponsavel.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.ViewResponsavel.AllowUserToAddRows = False
        Me.ViewResponsavel.AllowUserToDeleteRows = False
        Me.ViewResponsavel.AllowUserToResizeColumns = False
        Me.ViewResponsavel.AllowUserToResizeRows = False
        DataGridViewCellStyle102.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle102.SelectionBackColor = System.Drawing.Color.Maroon
        Me.ViewResponsavel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle102
        Me.ViewResponsavel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ViewResponsavel.BackgroundColor = System.Drawing.Color.White
        Me.ViewResponsavel.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.ViewResponsavel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle103.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle103.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle103.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle103.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle103.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle103.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle103.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewResponsavel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle103
        Me.ViewResponsavel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ViewResponsavel.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle104.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle104.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle104.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle104.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle104.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle104.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle104.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewResponsavel.DefaultCellStyle = DataGridViewCellStyle104
        Me.ViewResponsavel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.ViewResponsavel.EnableHeadersVisualStyles = False
        Me.ViewResponsavel.GridColor = System.Drawing.Color.Maroon
        Me.ViewResponsavel.Location = New System.Drawing.Point(15, 20)
        Me.ViewResponsavel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ViewResponsavel.MultiSelect = False
        Me.ViewResponsavel.Name = "ViewResponsavel"
        Me.ViewResponsavel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ViewResponsavel.RowTemplate.Height = 24
        Me.ViewResponsavel.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewResponsavel.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.ViewResponsavel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ViewResponsavel.ShowCellErrors = False
        Me.ViewResponsavel.ShowCellToolTips = False
        Me.ViewResponsavel.ShowEditingIcon = False
        Me.ViewResponsavel.ShowRowErrors = False
        Me.ViewResponsavel.Size = New System.Drawing.Size(369, 102)
        Me.ViewResponsavel.TabIndex = 54
        '
        'chkRegistraSomenteExames
        '
        Me.chkRegistraSomenteExames.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkRegistraSomenteExames.Location = New System.Drawing.Point(616, 16)
        Me.chkRegistraSomenteExames.Name = "chkRegistraSomenteExames"
        Me.chkRegistraSomenteExames.Size = New System.Drawing.Size(82, 46)
        Me.chkRegistraSomenteExames.TabIndex = 89
        Me.chkRegistraSomenteExames.Text = "somente exames"
        Me.chkRegistraSomenteExames.UseVisualStyleBackColor = True
        '
        'GrpUpload
        '
        Me.GrpUpload.BackColor = System.Drawing.Color.Gold
        Me.GrpUpload.Controls.Add(Me.txtArquivoDespesas)
        Me.GrpUpload.Controls.Add(Me.PicBuscarArquivo)
        Me.GrpUpload.ForeColor = System.Drawing.Color.DarkBlue
        Me.GrpUpload.Location = New System.Drawing.Point(102, 300)
        Me.GrpUpload.Name = "GrpUpload"
        Me.GrpUpload.Size = New System.Drawing.Size(490, 48)
        Me.GrpUpload.TabIndex = 88
        Me.GrpUpload.TabStop = False
        Me.GrpUpload.Text = "Upload de comprovantes, informe o arquivo de DESPESAS em PDF/JPG/JPEG"
        Me.GrpUpload.Visible = False
        '
        'txtArquivoDespesas
        '
        Me.txtArquivoDespesas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArquivoDespesas.Location = New System.Drawing.Point(5, 16)
        Me.txtArquivoDespesas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtArquivoDespesas.Name = "txtArquivoDespesas"
        Me.txtArquivoDespesas.Size = New System.Drawing.Size(449, 22)
        Me.txtArquivoDespesas.TabIndex = 92
        '
        'PicBuscarArquivo
        '
        Me.PicBuscarArquivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBuscarArquivo.Image = CType(resources.GetObject("PicBuscarArquivo.Image"), System.Drawing.Image)
        Me.PicBuscarArquivo.Location = New System.Drawing.Point(454, 16)
        Me.PicBuscarArquivo.Name = "PicBuscarArquivo"
        Me.PicBuscarArquivo.Size = New System.Drawing.Size(25, 22)
        Me.PicBuscarArquivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBuscarArquivo.TabIndex = 89
        Me.PicBuscarArquivo.TabStop = False
        Me.PicBuscarArquivo.Tag = "Localize o Conveniado no Google Maps."
        '
        'lblDataAtendimento
        '
        Me.lblDataAtendimento.AutoSize = True
        Me.lblDataAtendimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataAtendimento.Location = New System.Drawing.Point(128, 136)
        Me.lblDataAtendimento.Name = "lblDataAtendimento"
        Me.lblDataAtendimento.Size = New System.Drawing.Size(36, 15)
        Me.lblDataAtendimento.TabIndex = 113
        Me.lblDataAtendimento.Text = "Data:"
        Me.lblDataAtendimento.Visible = False
        '
        'grpSenhaConfirmacao
        '
        Me.grpSenhaConfirmacao.BackColor = System.Drawing.Color.Gold
        Me.grpSenhaConfirmacao.Controls.Add(Me.btnValidaSenhaConfirmacao)
        Me.grpSenhaConfirmacao.Controls.Add(Me.mskSenhaConfirmacao)
        Me.grpSenhaConfirmacao.Location = New System.Drawing.Point(272, 246)
        Me.grpSenhaConfirmacao.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpSenhaConfirmacao.Name = "grpSenhaConfirmacao"
        Me.grpSenhaConfirmacao.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpSenhaConfirmacao.Size = New System.Drawing.Size(177, 49)
        Me.grpSenhaConfirmacao.TabIndex = 37
        Me.grpSenhaConfirmacao.TabStop = False
        Me.grpSenhaConfirmacao.Text = "Confirmação de Senha "
        Me.grpSenhaConfirmacao.Visible = False
        '
        'btnValidaSenhaConfirmacao
        '
        Me.btnValidaSenhaConfirmacao.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidaSenhaConfirmacao.Image = CType(resources.GetObject("btnValidaSenhaConfirmacao.Image"), System.Drawing.Image)
        Me.btnValidaSenhaConfirmacao.Location = New System.Drawing.Point(135, 19)
        Me.btnValidaSenhaConfirmacao.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnValidaSenhaConfirmacao.Name = "btnValidaSenhaConfirmacao"
        Me.btnValidaSenhaConfirmacao.Size = New System.Drawing.Size(33, 23)
        Me.btnValidaSenhaConfirmacao.TabIndex = 9
        '
        'mskSenhaConfirmacao
        '
        Me.mskSenhaConfirmacao.Location = New System.Drawing.Point(17, 20)
        Me.mskSenhaConfirmacao.Name = "mskSenhaConfirmacao"
        Me.mskSenhaConfirmacao.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.mskSenhaConfirmacao.Size = New System.Drawing.Size(115, 20)
        Me.mskSenhaConfirmacao.TabIndex = 7
        '
        'GrpSenhaGerencial
        '
        Me.GrpSenhaGerencial.BackColor = System.Drawing.Color.Red
        Me.GrpSenhaGerencial.Controls.Add(Me.BtnSenhaGerecnial)
        Me.GrpSenhaGerencial.Controls.Add(Me.MskSenhaGerencial)
        Me.GrpSenhaGerencial.ForeColor = System.Drawing.Color.White
        Me.GrpSenhaGerencial.Location = New System.Drawing.Point(272, 137)
        Me.GrpSenhaGerencial.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GrpSenhaGerencial.Name = "GrpSenhaGerencial"
        Me.GrpSenhaGerencial.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GrpSenhaGerencial.Size = New System.Drawing.Size(177, 49)
        Me.GrpSenhaGerencial.TabIndex = 112
        Me.GrpSenhaGerencial.TabStop = False
        Me.GrpSenhaGerencial.Text = "Senha Gerencial"
        Me.GrpSenhaGerencial.Visible = False
        '
        'BtnSenhaGerecnial
        '
        Me.BtnSenhaGerecnial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSenhaGerecnial.Image = CType(resources.GetObject("BtnSenhaGerecnial.Image"), System.Drawing.Image)
        Me.BtnSenhaGerecnial.Location = New System.Drawing.Point(135, 19)
        Me.BtnSenhaGerecnial.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSenhaGerecnial.Name = "BtnSenhaGerecnial"
        Me.BtnSenhaGerecnial.Size = New System.Drawing.Size(33, 22)
        Me.BtnSenhaGerecnial.TabIndex = 9
        '
        'MskSenhaGerencial
        '
        Me.MskSenhaGerencial.Location = New System.Drawing.Point(17, 20)
        Me.MskSenhaGerencial.Name = "MskSenhaGerencial"
        Me.MskSenhaGerencial.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.MskSenhaGerencial.Size = New System.Drawing.Size(115, 20)
        Me.MskSenhaGerencial.TabIndex = 7
        '
        'GrpConsultas
        '
        Me.GrpConsultas.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrpConsultas.Controls.Add(Me.cmbProcedimento)
        Me.GrpConsultas.Controls.Add(Me.cmbProcedimento2)
        Me.GrpConsultas.Controls.Add(Me.mskValor)
        Me.GrpConsultas.Controls.Add(Me.mskValor2)
        Me.GrpConsultas.Controls.Add(Me.lblValor)
        Me.GrpConsultas.Controls.Add(Me.chkRegistraSomenteExames)
        Me.GrpConsultas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpConsultas.ForeColor = System.Drawing.Color.Maroon
        Me.GrpConsultas.Location = New System.Drawing.Point(12, 162)
        Me.GrpConsultas.Name = "GrpConsultas"
        Me.GrpConsultas.Size = New System.Drawing.Size(705, 99)
        Me.GrpConsultas.TabIndex = 114
        Me.GrpConsultas.TabStop = False
        Me.GrpConsultas.Text = "Informe o serviço realizado"
        Me.GrpConsultas.Visible = False
        '
        'cmbProcedimento
        '
        Me.cmbProcedimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProcedimento.FormattingEnabled = True
        Me.cmbProcedimento.Location = New System.Drawing.Point(15, 28)
        Me.cmbProcedimento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbProcedimento.Name = "cmbProcedimento"
        Me.cmbProcedimento.Size = New System.Drawing.Size(421, 24)
        Me.cmbProcedimento.Sorted = True
        Me.cmbProcedimento.TabIndex = 33
        '
        'cmbProcedimento2
        '
        Me.cmbProcedimento2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProcedimento2.FormattingEnabled = True
        Me.cmbProcedimento2.Location = New System.Drawing.Point(15, 59)
        Me.cmbProcedimento2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbProcedimento2.Name = "cmbProcedimento2"
        Me.cmbProcedimento2.Size = New System.Drawing.Size(421, 24)
        Me.cmbProcedimento2.Sorted = True
        Me.cmbProcedimento2.TabIndex = 35
        Me.cmbProcedimento2.Visible = False
        '
        'mskValor
        '
        Me.mskValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskValor.Location = New System.Drawing.Point(507, 28)
        Me.mskValor.Name = "mskValor"
        Me.mskValor.Size = New System.Drawing.Size(86, 26)
        Me.mskValor.TabIndex = 46
        Me.mskValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValor2
        '
        Me.mskValor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskValor2.Location = New System.Drawing.Point(507, 59)
        Me.mskValor2.Name = "mskValor2"
        Me.mskValor2.Size = New System.Drawing.Size(86, 26)
        Me.mskValor2.TabIndex = 47
        Me.mskValor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.mskValor2.Visible = False
        '
        'grpAntendimento
        '
        Me.grpAntendimento.BackColor = System.Drawing.SystemColors.Control
        Me.grpAntendimento.Controls.Add(Me.grpSenha)
        Me.grpAntendimento.Controls.Add(Me.GrpUpload)
        Me.grpAntendimento.Controls.Add(Me.grpSenhaConfirmacao)
        Me.grpAntendimento.Controls.Add(Me.GrpSenhaGerencial)
        Me.grpAntendimento.Controls.Add(Me.lblDataAtendimento)
        Me.grpAntendimento.Controls.Add(Me.GrpServicoInformado)
        Me.grpAntendimento.Controls.Add(Me.GrpResponsavel)
        Me.grpAntendimento.Controls.Add(Me.GroupBox1)
        Me.grpAntendimento.Controls.Add(Me.GroupBiometria)
        Me.grpAntendimento.Controls.Add(Me.grdIdentifica)
        Me.grpAntendimento.Controls.Add(Me.rtbApoio)
        Me.grpAntendimento.Controls.Add(Me.GrpConsultas)
        Me.grpAntendimento.Controls.Add(Me.GrpServicos)
        Me.grpAntendimento.ForeColor = System.Drawing.Color.Maroon
        Me.grpAntendimento.Location = New System.Drawing.Point(13, 125)
        Me.grpAntendimento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpAntendimento.Name = "grpAntendimento"
        Me.grpAntendimento.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpAntendimento.Size = New System.Drawing.Size(738, 456)
        Me.grpAntendimento.TabIndex = 11
        Me.grpAntendimento.TabStop = False
        Me.grpAntendimento.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(760, 656)
        Me.Controls.Add(Me.grpAntendimento)
        Me.Controls.Add(Me.GrpSetor)
        Me.Controls.Add(Me.picAnyDesk)
        Me.Controls.Add(Me.GrpMedico)
        Me.Controls.Add(Me.btnConsultarSessoes)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.btnGravar)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grpIdentificação)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.grpStatus)
        Me.Controls.Add(Me.panGrafico)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Maroon
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = ""
        Me.Text = "Biosifam"
        Me.panGrafico.ResumeLayout(False)
        Me.panGrafico.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PicCorrigir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicQrCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpIdentificação.ResumeLayout(False)
        Me.grpIdentificação.PerformLayout()
        CType(Me.grdContribuintes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.picLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMedico.ResumeLayout(False)
        CType(Me.PicAlerta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSetor.ResumeLayout(False)
        CType(Me.picAnyDesk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpServicos.ResumeLayout(False)
        CType(Me.DrgServicosAtendimento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSenha.ResumeLayout(False)
        Me.grpSenha.PerformLayout()
        Me.GrpServicoInformado.ResumeLayout(False)
        Me.GrpServicoInformado.PerformLayout()
        CType(Me.grdIdentifica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBiometria.ResumeLayout(False)
        CType(Me.picMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PicPessoa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpResponsavel.ResumeLayout(False)
        CType(Me.ViewResponsavel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpUpload.ResumeLayout(False)
        Me.GrpUpload.PerformLayout()
        CType(Me.PicBuscarArquivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSenhaConfirmacao.ResumeLayout(False)
        Me.grpSenhaConfirmacao.PerformLayout()
        Me.GrpSenhaGerencial.ResumeLayout(False)
        Me.GrpSenhaGerencial.PerformLayout()
        Me.GrpConsultas.ResumeLayout(False)
        Me.GrpConsultas.PerformLayout()
        Me.grpAntendimento.ResumeLayout(False)
        Me.grpAntendimento.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public drGeneric As Npgsql.NpgsqlDataReader
    Public drDigitais As Npgsql.NpgsqlDataReader
    Public idDigital As Long

    Dim vbValidaPorDigital As Boolean

    Dim vbPassou As Boolean
    Dim BolLeitorBiometricoAtivado As Boolean = False
    Dim vbSenhaValidada As Boolean

    Dim vnContaDigitalRuim As Integer
    Dim vnContaDigitalNaoIdentificada As Integer
    Dim vnContaDigitalNaoLocalizada As Integer
    Dim vsSenha As String
    Dim vbIdentificouDigital As Boolean = False

    Dim IdUltimoAtendimento As Long = 0

    'variaveis para o relatórios consultas
    Dim vdData As Date, vdDataFim As Date
    Dim vsFiltro As String = "", vsRetorno As String = "", vsFiltroTexto As String = ""
    Dim IdSetor As Integer, vsSetor As String
    Dim IdMedico As Integer, vsMedico As String

    Dim _ServicoPrincipal As New ClsServico
    Dim _Servico As New ClsServico

    Private vbModoOFFLine As Boolean = False
    Private vbModoBNI As Boolean = False    ' Biometria nao identificada
    Private vbModoRPJ As Boolean = False    ' Registro Posterior Justificado
    Private vbModoSMS As Boolean = False    ' Registro com SMS 
    Private vbModoQrCode As Boolean = False ' Registro com QrCode 

    ReadOnly toolTip1 As New ToolTip()
    ReadOnly toolTip2 As New ToolTip()
    ReadOnly toolTip3 As New ToolTip()

    Private vnModeloRelatorio As Integer    '0-digital, 1-consulta, 2-exame
    Private vtTempoConexao As TimeSpan, vdInicioConexao As DateTime, vbEncerrar As Boolean, vnPosicaoMouse As Long
    Private vbPacoteAberto As Boolean = False
    Private vbSelecionouMedico As Boolean = False
    Private QualidadeDaDigital As Integer   ' 1-ruim, 2 media, 3 bom
    Private vdDataServidor As Date

    Private IdProcessoAtual As Long = 0
    Private vsNomeUsuario As String = ""

    Private idResponsavelFinanceiro As Long = 0
    Private vdTempoVerificacaoI As DateTime = Now
    Private vdTempoVerificacaoF As DateTime = Now

    Private IdAutorizacaoRemota As Long = 0   ' identifica autorizacao remota
    Private TipoAutorizacaoRemota As String = ""   ' B=balcao, R-remota, F-fisioterapia, H-hospitalar, A-ambulatorial
    Private IdResponsavelConsulta As Long = 0   ' em caso de menor de 12 , seleciona o responvael pela consulta e validação
    Private vbResponsavelUsaDigital As Boolean = 0   ' em caso de menor de 12 , seleciona o responvael pela consulta e validação

    Public vbLoad As Boolean = False

    Dim _Autorizacao As New ClsAutorizacao
    Dim _Atendimento As New ClsAtendimento
    Dim drServicos As Npgsql.NpgsqlDataReader
    Dim _Pessoa As New ClsPessoa
    Dim vsJustificativa As String
    Dim BolCarregandoCombo As Boolean
    Dim ds As DataSet
    Dim oUpdate As New cUpdate

    Dim StrVesaoApp As String = Application.ProductName.ToString & " Versão " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "0#")

    Dim IntContaTentativasSenhaGerencial As Integer = 0
    Dim BolCorrecao As Boolean
    Dim StrJustificativaCorrecao As String
    Dim IdAtendimentoCorrecao As Integer
    Dim idServicoInformado As Integer
    Dim ServicoGrid(3) As String

    Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        vsGlo_frmAtivo = Me.Text
        If IdSelecionadoPesquisa > 0 Then
            idServicoInformado = IdSelecionadoPesquisa
            TxtServico.Text = NomeSelecionadoPesquisa
            TxtCBHPM.Text = CBHPMSelecionadoPesquisa
            MskValorServico.Text = ValorSelecionadoPesquisa
            If CDec(MskValorServico.Text) > 0 Then
                InserirItemGrid()
                TxtServico.Focus()
            Else
                MskValorServico.Focus()
            End If
        End If

    End Sub

    Public Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vbLoad = True

        ' Cria a ToolTip e associa com o Form container.
        Dim toolTip1 As New ToolTip()     ' Define o delay para a ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500        ' Força a o texto da ToolTip a ser exibido mesmo que o form não esta ativo
        toolTip1.ShowAlways = True        ' Define o texto da ToolTip para o Button, TextBox, Checkbox e Label
        toolTip1.SetToolTip(Me.btnLimpar, "Iniciar novo atendimento")
        toolTip1.SetToolTip(Me.btnMatricula, "Carregar dados da Matricula")
        toolTip1.SetToolTip(Me.btnExcluir, "Cancelar Atendimento")
        toolTip1.SetToolTip(Me.picAnyDesk, "Carregue o AnyDesk para suporte técnico remoto")
        toolTip1.SetToolTip(Me.mskValor, "informe o valor integral do procedimento")
        toolTip1.SetToolTip(Me.mskValor2, "informe o valor integral do procedimento.")
        toolTip1.SetToolTip(Me.picLogin, "Clique Duplo aqui e troque seu usuário e prestador vinculado.")
        toolTip1.SetToolTip(Me.PictureBox1, "www.pelotas.com.br")
        toolTip2.SetToolTip(Me.PictureBox2, "www.pelotas.com.br/coinpel")
        toolTip3.SetToolTip(Me.PictureBox3, "Localize o Conveniado no Google Maps.")
        toolTip3.SetToolTip(Me.btnNaoCompareceu, "Registra Não comparecimento de Pacientes (até 5 dias retroativos).")
        toolTip3.SetToolTip(Me.PicBuscarArquivo, "Seleciona um arquivo para envio ou Informe localize uma autorização já aprovada.")
        toolTip3.SetToolTip(Me.btnImprimir, "Imprime comprovante de atendimento.")
        toolTip3.SetToolTip(Me.picSMS, "Envia e Recebe código para autorização de atendimento via SMS.")
        toolTip3.SetToolTip(Me.chkRegistraSomenteExames, "se marcado, não inclui no registro a consulta médica.")
        toolTip3.SetToolTip(Me.PicQrCode, "Clique aqui para ir ao Portal do Servidor para autorizar atendimento.")
        toolTip3.SetToolTip(Me.PicAlerta, "Clique aqui visualizar alerta.")
        toolTip3.SetToolTip(Me.PicCorrigir, "Clique aqui corrigir atendimentos.")
        cmbMesGrafico.SelectedIndex = Month(Now) - 1

        toolTip3.SetToolTip(Me.LogList, "LOGs - Clique aqui para visualizar o STATUS e os registros da Biometria.")

        ConfiguraForm()

        'MontaGraficoAtendimentos()  ja´fez a carga no configura form

    End Sub

    Public Sub ConfiguraForm()
        Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2   ' Center form horizontally.
        Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2  ' Center form vertically.
        Dim oUpdate As New cUpdate
        lblUsuarioCorrente.Text = "Login: " & _u.Login

        lblIP.Text = "Estação: " & _w.Nome & ", IP: " & _t.ObtemEnderecoIP

        _w.Carregar(_t.ObtemMAC)   ' vai buscar informações da estação, atraves do mac, se estacao nao existir vai criar, atualiza acesso na estacao

        ' modo funcionalidade 0=retaguarda, 1=consulta, 2=consultório,3-exames,4-fisioterapia,5-pronto atendimento
        If _u.IdPrestador = 0 Or _w.Modo = 0 Then
            ' quero evitar que o sistema fique travado em um medico nos prestadores, so vai funcionar se for ZERO
            '  If _u.IdPrestador = 0 Or (_u.IdPrestador <> _w.idPrestador And _w.idPrestador > 0) Or _w.Modo = 0 Then

            ' se for zero é sinal que usuario nao restá relacionado a um prestador ou
            ' usuario/modo não requer um medico específico
            ' ou forçou via setup um médico específico = para carregar dados do médico via login , medico estacao dever ser igual medico usuario
            ' configurações da estação virão da estação - formSetup
            _u.IdPrestador = _w.idPrestador
            oMedicoConveniado = New ClsMedico(_u.IdPrestador)
            If _u.IdPrestador > 0 Then
                vnGlo_ModoAtual = oMedicoConveniado.Modo
            Else
                vnGlo_ModoAtual = _w.Modo
                CorreçõesEmProcedimentosToolStripMenuItem.Visible = True

            End If
            MsgBox("Utilizando configuração da Estação de trabalho.")
        Else
            ' id e modo vem do cadastro do prestador
            oMedicoConveniado = New ClsMedico(_u.IdPrestador)
            vnGlo_ModoAtual = oMedicoConveniado.Modo
            ' tava igual, coloquei diferente
            If _w.Modo <> oMedicoConveniado.Modo Then _w.AtualizaWorkstation()
        End If
        If _w.AtualizacaoConcluida Then _util.Log_Gravar("biosifam_update2", "A Digital extraída está com Qualidade MÉDIA.", False, 0, oMedicoConveniado.Id)

        DigitaisToolStripMenuItem.Visible = False
        EstatísticoToolStripMenuItem.Visible = False
        RegistroDePacotesToolStripMenuItem.Visible = False
        ResumoDePacotesToolStripMenuItem.Visible = False

        btnConsultarSessoes.Visible = False

        cmbMedico.Enabled = False : cmbMedico.Items.Clear() : cmbMedico.Text = ""

        vbModoOFFLine = False
        vbModoBNI = False
        vbModoRPJ = False
        vbModoSMS = False
        vbModoQrCode = False

        vsJustificativa = ""
        idResponsavelFinanceiro = 0

        Me.BackColor = Color.White

Inicializa:
        'MsgBox(vnGlo_ModoAtual)
        Me.Text = StrVesaoApp & " - Modo: " & vsGlo_Modo(vnGlo_ModoAtual)

        ' se usuario nao tem medico, e modo nao é retagarda  assume modo consulta - modo consulta - só verifica digital ou senha
        ' vsModo -> 0=Retaguarda, 1=Consulta, 2=Consultório, 3-exames clinicos, 4-fisioterapeuta,5-pronto atendimento
        If vnGlo_ModoAtual = 0 Then
            toolTip1.SetToolTip(Me.btnExcluir, "Excluir Senha/Digital")
            DigitaisToolStripMenuItem.Visible = True
            EstatísticoToolStripMenuItem.Visible = True
            RegistroDePacotesToolStripMenuItem.Visible = True
            ResumoDePacotesToolStripMenuItem.Visible = True

            ' carrega todos medicos para relatorios
            _t.CarregaCombo(cmbMedico, "SELECT id_prestador, to_ascii(nome,'LATIN1') as nome FROM prestador where situacao='A' and usa_biosifam <> '' order by nome ")
            cmbMedico.Enabled = True
            GoTo Fim_Sub

        ElseIf vnGlo_ModoAtual = 1 Then
            ConsultasToolStripMenuItem.Visible = False
            MsgBox("modo CONSULTA DIGITAL ativado")
            Me.Text = StrVesaoApp & " - " & vsGlo_Modo(vnGlo_ModoAtual)
            ' carrega todos medicos para relatorios
            _t.CarregaCombo(cmbMedico, "SELECT id_prestador, to_ascii(nome,'LATIN1') as nome FROM prestador where situacao='A' and usa_biosifam <> '' order by nome ")
            GoTo Fim_Sub
        End If

        If oMedicoConveniado.Id = 0 Then
            MsgBox("Erro na configuração de funcionalidade do aplicativo, LAboratório/Clínica não informado. modo CONSULTA ativado")
            vnGlo_ModoAtual = "1"
            Me.Text = StrVesaoApp & " - " & vsGlo_Modo(vnGlo_ModoAtual)
            GoTo Fim_Sub
        End If

        If oMedicoConveniado.Dentista Then Me.Text &= " Odontológico"
        Me.Text &= " - " & oMedicoConveniado.Nome

        If oMedicoConveniado.Modo = 5 Then        ' hospitais - vao utilizar setor
            GrpSetor.Visible = True
            oMedicoConveniado.CarregaComboMedicos(CmbSetor, idResponsavelFinanceiro)
            GoTo Fim_Sub
        End If
        GrpSetor.Visible = False

        oMedicoConveniado.CarregaComboMedicos(cmbMedico, idResponsavelFinanceiro)
        ' sugere primeiro da lista = medicoP
        IdMedico = oMedicoConveniado.Id
        If cmbMedico.Items.Count > 1 Then
            If oMedicoConveniado.ResponsavelFinanceiro Then
                Call _t.PosicionaCombo(cmbMedico, oMedicoConveniado.Id)
            Else
                cmbMedico.SelectedIndex = 0
            End If
            ' ao selecinar novo pedido concta no banco e perde a conexao atual, precisa conectar novamente
            If _PG.Conectar() = False Then End
        Else
            If cmbMedico.Items.Count = 0 Then
                If idResponsavelFinanceiro = 0 Then
                    MsgBox("Erro na configuração do prestador. Prestador marcado como responsável financeiro sem vinculados.")
                Else
                    MsgBox("Erro na configuração do prestador. Prestador não localizado.")
                End If
                vnGlo_ModoAtual = "1"
                Me.Text = StrVesaoApp & " - " & vsGlo_Modo(vnGlo_ModoAtual)
                GoTo Fim_Sub
            Else
                cmbMedico.SelectedIndex = 0
            End If
        End If

        RelatórioDeExamesProcedimentosToolStripMenuItem.Visible = False
        If oMedicoConveniado.Modo = 3 Or oMedicoConveniado.Modo = 4 Or oMedicoConveniado.FazExameNoConsultorio Then
            RelatórioDeExamesProcedimentosToolStripMenuItem.Visible = True
        End If

Fim_Sub:
        InicializaBotaoGravar()
        _PG.Desconectar()
        IdProcessoAtual = Process.GetCurrentProcess.Id
        vsNomeUsuario = vsNomeUsuario & IdProcessoAtual
        If _t.AplicacaoJaEstaRodando(vsNomeUsuario, IdMedico) Then End

        Me.Timer1.Enabled = True 'da start na timer
        Me.Timer1.Start()
        Me.Timer1.Interval = 10000 'tempo de 10 segundos
        vnPosicaoMouse = MousePosition.X
        vdInicioConexao = Now

        _s.VerificaMensagemUsuario(_u.Login)

    End Sub

    Private Sub btnMatricula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMatricula.Click
        InicializaBotoes()
        Call CarregaMatricula()
    End Sub

    Private Sub CarregaMatricula()

        _Pessoa.Inicializar()   ' limpa todos dados da pessoa
        _Autorizacao = New ClsAutorizacao

        ' inicializa controles do relatório ============================================
        vsFiltro = "" : vsRetorno = "" : vsFiltroTexto = ""
        ' _PG.DbConn.ClearPool()

        If vnGlo_ModoAtual <> "0" And _u.IdPrestador > 0 Then
            If oMedicoConveniado.Situacao <> "A" Then MsgBox("Prestador de serviço com convênio SUSPENSO. Procure a PREVPEL.") : Exit Sub
            ' desativei teste quando conveniado for somente  vinculado
            If oMedicoConveniado.UsaBiosifam = False And oMedicoConveniado.Vinculo <> "V" Then
                MsgBox("Prestador de serviço sem permissão de acesso ao BioSifam. Procure a PREVPEL.")
                Exit Sub
            End If
            If oMedicoConveniado.SituacaoDocumentacao = "S" Then
                MsgBox("Prestador de serviço suspensão por pendências na documentação, utilize o Menu Controle, opção Upload de Documentos de Credenciamento para regularização.")
                Exit Sub
            End If
        End If
        If txtMatricula.Text = "" And txtCPF.Text = "" Then MsgBox("Informe uma matrícula ou um CPF !") : Exit Sub
        If txtMatricula.Text <> "" And txtCPF.Text <> "" Then MsgBox("Informe ou matrícula ou  cpf !") : Exit Sub

        IdAutorizacaoRemota = 0
        lblPessoa.Text = ""

        ' R@ filhos maiores de 24 anos deixam de ser dependentes e não podem fazem consultas - não aparecem mais na lista da matricula
        Dim vd_datanascimento24anos As Date
        vd_datanascimento24anos = DateTime.Now.AddYears(-24)
        Dim vd_datanascimento21anos As Date
        vd_datanascimento21anos = DateTime.Now.AddYears(-21)
        'If _PG.Conectar() = False Then Exit Sub

        Dim ds As DataSet
        Dim vsSql As String = "select id_pessoa as Codigo, to_ascii(nome,'LATIN1') as NOME, to_ascii(descricao ,'LATIN1') as Tipo, dt_nascimento as Nascimento, sexo as Sexo, situacao as Situacao "
        vsSql &= " from pessoas inner join tipo_usuario on id_tipo_usuario=id_tipo where "

        If txtMatricula.Text <> "" Then
            'ds = _PG.DsQuery(vsSql & " matricula= '" & txtMatricula.Text & "' and ((dt_nascimento > '" & Format(vd_datanascimento24anos.Date, "yyyy/MM/dd") & "' and id_tipo=4) or id_tipo<>4)")
            vsSql &= " matricula= '" & txtMatricula.Text & "' and ( "
            vsSql &= " (dt_nascimento > '" & Format(vd_datanascimento24anos.Date, "yyyy/MM/dd") & "' and (id_tipo=4 or id_tipo=9 or id_tipo=10)) or "
            vsSql &= " (dt_nascimento > '" & Format(vd_datanascimento21anos.Date, "yyyy/MM/dd") & "' and (id_tipo=4 or id_tipo=9 or id_tipo=10) and id_secretaria=16) or " ' 16=pensionista
            vsSql &= " id_tipo<>4 )"
            ds = _PG.DsQuery(vsSql)
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Matricula não localizada !" & Chr(13) & Chr(13) & "Por favor verifique a matricula informada e tente novamente.")
                Exit Sub
            End If
        Else
            ' por CPF - banco está ruim e possui cpf com formatacao e sem formatacao, para desviar agora deste problema vou problemas da duas forma
            ds = _PG.DsQuery(vsSql & " cpf= '" & txtCPF.Text & "' and situacao='A' and ((dt_nascimento > '" & Format(vd_datanascimento24anos.Date, "yyyy/MM/dd") & "' and id_tipo=4) or id_tipo<>4)")
            If ds.Tables(0).Rows.Count = 0 Then
                If InStr(txtCPF.Text.ToString, ".") > 0 Then
                    ' procura sem mascara
                    ds = _PG.DsQuery(vsSql & " cpf= '" & txtCPF.Text & "' and situacao='A' and ((dt_nascimento > '" & Format(vd_datanascimento24anos.Date, "yyyy/MM/dd") & "' and id_tipo=4) or id_tipo<>4)")
                Else
                    ' procura com mascara
                    txtCPF.Text = _t.FormataString("###.###.###-##", txtCPF.Text)
                    ds = _PG.DsQuery(vsSql & " cpf= '" & txtCPF.Text & "' and situacao='A' and ((dt_nascimento > '" & Format(vd_datanascimento24anos.Date, "yyyy/MM/dd") & "' and id_tipo=4) or id_tipo<>4)")
                End If
                If ds.Tables(0).Rows.Count = 0 Then
                    MsgBox("Nenhuma matricula ATIVA foi localizada para o CPF informado !" & Chr(13) & Chr(13) & "Por favor verifique o valor informado ou procure informações com a PREVPEL.")
                    Exit Sub
                End If
            End If
            If ds.Tables(0).Rows.Count = 1 Then
                If CarregaDadosPaciente(ds.Tables(0).Rows(0).Item(0)) = False Then Exit Sub
                txtMatricula.Text = _Pessoa.Matricula
                Me.Cursor = Cursors.Default
                Me.Refresh()
                GoTo Fim
            End If
        End If

        grdContribuintes.DataSource = ds.Tables(0)
        grdContribuintes.Columns(4).Visible = True
        grdContribuintes.Columns(3).Visible = False
        grdContribuintes.Width = 620
        grdContribuintes.Columns(0).Width = 50
        grdContribuintes.Columns(1).Width = 230
        grdContribuintes.Columns(2).Width = 90
        grdContribuintes.Columns(4).Width = 80
        grpIdentificação.Height = 300
        grpAntendimento.Visible = False

Fim:
        panGrafico.Visible = False
        IdResponsavelConsulta = 0
        mskSenha.Text = ""
        GrpResponsavel.Visible = False

        If BolLeitorBiometricoAtivado = False Then
            BolLeitorBiometricoAtivado = True
            Dim err As Integer
            _toolsSiFam = New clsSiFam(LogList, picMain, AxGrFingerXCtrl1)
            err = _toolsSiFam.InitializeGrFinger()
            If err < 0 Then
                _toolsSiFam.ErroGriaule(err)
            Else
                _toolsSiFam.WriteLog("**GrFingerX Inicializado com Sucesso**")
            End If
        End If

    End Sub

    Private Sub InicializaBotoes()
        InicializaBotaoGravar()
        lblSenha.Visible = False
        rtbApoio.Text = ""
        rtbApoio.Enabled = False
        lblPessoa.Text = ""
        idDigital = 0
        grdIdentifica.DataSource = Nothing

        PicPessoa.Visible = False
        LogList.Items.Clear()
        vbIdentificouDigital = False

        LimpaServicos()

        mskTotal.Text = ""

        _Autorizacao = New ClsAutorizacao
        _Atendimento = New ClsAtendimento

        ' se prestador nao tem servico principal, ele vem com zero - AQUI SOMA O PRIMEIRO SERVICO
        _Atendimento.Inicializar()  ' aqui é anova inicialização do atendimento, apos seleciona o paciente

        If _ServicoPrincipal.Id = 0 Then
            cmbProcedimento.Enabled = True
        Else
            cmbProcedimento.SelectedIndex = 0
            mskValor.Text = _ServicoPrincipal.Valor
            mskTotal.Text = _Atendimento.TotalizaServico(0, CType(cmbProcedimento.SelectedItem, ComboData).Id, mskValor.Text)
        End If


        grpSenha.Visible = False
        mskSenha.Text = ""
        vbSenhaValidada = False
        vbPacoteAberto = False

        IdUltimoAtendimento = 0 '  inserir em 27-10-20 inicia aparecimento do grp senha se nao zerar

        If oMedicoConveniado.DespesaHospitalar Then
            ' mantem offline true e botaão salvar enabled
        Else
            btnGravar.Enabled = False
            vbModoOFFLine = False
        End If

        vbModoBNI = False
        vbModoRPJ = False
        vbModoSMS = False
        vbModoQrCode = False

        lblSenha.Text = "Identificação digital desativada. Usuário utilizando senha."
        lblSituacao.Text = ""
        ' Initialize GrFingerX Library
        ' _toolsSiFam.InitializeGrFinger()

    End Sub

    Private Sub grdContribuintes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdContribuintes.CellContentClick
        CarregaDadosPaciente(grdContribuintes.CurrentRow.Cells(0).Value())
        If _Pessoa.Situacao = "S" Then
            MsgBox("Contribuinte está suspenso.", vbInformation, "Impossível prosseguir.")
            LimpaNovoAtendimento()
            txtMatricula.Focus()
        End If

    End Sub

    Private Function CarregaDadosPaciente(ByVal IntPessoa As Long, Optional BolSomenteConsulta As Boolean = False) As Boolean
        CarregaDadosPaciente = False

        If _Pessoa.CarregarPessoa(IntPessoa) = False Then Exit Function

        grpAntendimento.Visible = True
        grpIdentificação.Height = 53
        rtbApoio.Text = "Identificador: " & _Pessoa.Id & ", "
        lblPessoa.Text = Trim(_Pessoa.Nome) & Chr(13)
        Dim ts As TimeSpan = DateTime.Today.Subtract(_Pessoa.DataNascimento)
        rtbApoio.Text = rtbApoio.Text & "idade " & New DateTime(ts.Ticks).ToString("yy") & " anos." & Chr(13)     'dr.Item(2)
        txtMatricula.Text = _Pessoa.Matricula
        Try
            PicPessoa.Visible = True
            PicPessoa.Load("http://sifam.pelotas.com.br/fotos/" & _Pessoa.Imagem)
        Catch
            PicPessoa.Visible = False
        End Try
        Me.Refresh()
        _Pessoa.CarregaEstatisticas(oMedicoConveniado)

        rtbApoio.Text &= _Pessoa.Retorno

        If oMedicoConveniado.Fisioterapeuta Or oMedicoConveniado.Especialidade = 10 Or oMedicoConveniado.Especialidade2 = 10 Then
            If _Pessoa.AutorizacaoFisioterapia = 0 Then
                MsgBox("Contribuinte não possui Autorização de Fisioterapia." & Chr(13) & Chr(13) & "Para prosseguir é necessário que a PREVPEL autorize o procedimento.", vbInformation, "Nenhuma Autorização disponível")
                GoTo Fim_Bloco
            End If
        End If

        If oMedicoConveniado.Modo = 4 Or oMedicoConveniado.Modo = 5 Then      ' PA ou Hospitalar
            cmbProcedimento.Visible = True
            mskValor.Visible = True
            cmbProcedimento2.Visible = False
            mskValor2.Visible = False
            ' pronto atendimento - situacao fica pendente até fechamento do atendimento
            _Atendimento.IdAtendimentoPendente = _Pessoa.VerificaAtendimentosPendentes(cmbProcedimento, oMedicoConveniado.Id)
            If _Atendimento.IdAtendimentoPendente > 0 Or vbModoOFFLine Then

                If oMedicoConveniado.Modo = 4 Then
                    ' proibir atendimento - está tentando digitar um retorno (ou seja atendimento em menos de 24hs)
                    If _Atendimento.IdAtendimentoPendente = 9 Then GoTo Fim_Bloco
                    If _Atendimento.IdAtendimentoPendente = 1 Then
                        cmbProcedimento.Visible = False
                        mskValor.Visible = False
                        _Atendimento.IdAtendimentoPendente = 0
                    End If
                    ' libera digitação proximo procedimento e gravacao final do atendimento SEM validacao biometrica ou de senha
                    cmbProcedimento2.Visible = True
                    mskValor2.Visible = True
                    GrpUpload.Visible = True
                End If

                If oMedicoConveniado.Modo = 5 Then
                    Call MontaGridServicos(_Atendimento.IdAtendimentoPendente)
                End If

                btnGravar.Enabled = True
                vbSenhaValidada = True
                grpSenha.Visible = False

                GoTo Fim_Bloco
            End If
        End If

        If IdAutorizacaoRemota > 0 Then
            lblSenha.Text = "Autorização Remota ATIVA."
            lblSenha.Visible = True
            lblSenha.Refresh()
            If vbValidaPorDigital Then _toolsSiFam.InitializeGrFinger()
            lblSituacao.Text = "N. " & IdAutorizacaoRemota
            lblSituacao.Refresh()
            btnGravar.Enabled = True
            GoTo Fim_Bloco
        End If

LiberaAtendimentos:
        ' verificaões de biometria e senha
        If BolSomenteConsulta = False Then If LiberaAtendimento(_Pessoa.Id) = False Then GoTo Fim_Bloco
        vnContaDigitalRuim = 0
        vnContaDigitalNaoIdentificada = 0

        CarregaDadosPaciente = True
Fim_Bloco:
        Me.Cursor = Cursors.Default
        Me.Refresh()
    End Function

    Public Function LiberaAtendimento(ByVal idSelecionado As Long) As Boolean
        LiberaAtendimento = False
        vbPassou = True
        LogList.Items.Clear()
        If _PG.Conectar() = False Then GoTo Fim_Bloco
        Try
            If IdResponsavelConsulta = 0 Then vbValidaPorDigital = False Else GoTo PegaSenha

            lblSenha.Visible = False : lblSituacao.Text = "aguardando..."

            If _Pessoa.DigitaisCadastradas > 0 Then
                If _toolsSiFam.raw.height > 0 Then _toolsSiFam.PrintBiometricDisplay(False, GrFinger.GR_DEFAULT_CONTEXT)
                rtbApoio.Text = rtbApoio.Text & "Biometrias existentes: " & _Pessoa.DigitaisCadastradas & Chr(13)
                grpSenha.Visible = False
                vbValidaPorDigital = True
            End If

            If vbValidaPorDigital = False Then
                'se for menor libera uso da senha
                'se nao for menor, so libera uso da senha pelo método de 3 tentativas
                If _Pessoa.Menor12anos = False And _Pessoa.SenhaDaPessoaNoBanco = "" Then
                    If vnGlo_ModoAtual = 1 Or vnGlo_ModoAtual = 2 Then
                        MsgBox("Matricula não possui digital nem senha. Dirija-se a PREVPEL para realizar o cadastro.")
                        GoTo Fim_Bloco
                    End If
                    ' se passar é para informar a digital na retaguarda
                    vbValidaPorDigital = True
                    btnGravar.Enabled = True
                    ' nova função v.1.7.14 - permite algumas pessoas usarem diretamente a consulta por senha 
                    If vnGlo_ModoAtual = 0 And _Pessoa.LiberaUsoPorSenha Then vbValidaPorDigital = False
                End If


                If _Pessoa.Menor12anos And _Pessoa.DigitaisCadastradas = 0 And _Pessoa.SenhaDaPessoaNoBanco = "" And IdResponsavelConsulta = 0 Then
                    MsgBox("Paciente MENOR não possui digital nem senha. Deverá utilizar validação de acesso dos Pais ou Responsável.")
                    If vnGlo_ModoAtual <= 1 Then GoTo Fim_Bloco
                    MsgBox("Selecione a seguir um dos responsáveis.")

                    ds = _PG.DsQuery("select id_pessoa as Codigo, to_ascii(nome,'LATIN1') as Nome, biosifam_senha as Usa_Senha, senha, senha_data, num_celular from pessoas inner join tipo_usuario on id_tipo_usuario=id_tipo where matricula = '" & txtMatricula.Text & "' and situacao='A' and extract(year from age(CURRENT_DATE, dt_nascimento)) > 18 and id_tipo<>4")
                    If ds.Tables(0).Rows.Count = 0 Then
                        MsgBox("Nenhum responsável foi localizado !" & Chr(13) & Chr(13) & "Por favor verifique a matricula informada e tente novamente.")
                        GoTo Fim_Bloco
                    End If

                    ViewResponsavel.DataSource = ds.Tables(0)
                    ViewResponsavel.Width = 510
                    ViewResponsavel.Columns(0).Visible = False
                    ViewResponsavel.Columns(1).Visible = True
                    ViewResponsavel.Columns(2).Visible = True
                    ViewResponsavel.Columns(3).Visible = False
                    ViewResponsavel.Columns(4).Visible = False
                    ' versao 2.2.01 dá pau ao abrir o grid na primeira vez, nao sei explicar - suprimi.
                    'ViewResponsavel.Columns(0).Width = 50
                    'ViewResponsavel.Columns(1).Width = 200
                    'ViewResponsavel.Columns(2).Width = 65
                    'ViewResponsavel.Columns(3).Width = 1
                    'ViewResponsavel.Columns(4).Width = 1
                    ViewResponsavel.Refresh()

                    GrpResponsavel.Visible = True
                    GrpResponsavel.Width = 530
                    GrpResponsavel.Refresh()

                    GoTo Fim_Bloco
                End If
            End If
PegaSenha:
            ' nao vai utilizar digital
            If vbValidaPorDigital = False Or vbModoOFFLine Then
                'btnGravar.Enabled = True - desativei em 21/12/2021 - versao 2.2.12
                If _Pessoa.Menor12anos And _Pessoa.LiberaUsoPorSenha = False And vbResponsavelUsaDigital Then
                    'se é menor, vou ter de verificar se senha informada pertence a 'algum' dos Respon'sáveis (matricula)
                    'então não vou verificar a senha agora e sim apos recebela, dai 
                    'verifico se ela é compativel com alguns dos 'outros' da matricula

                    'se é menor e nao tem digital, vou ter de verificar se algum' dos Respon'sáveis (matricula) tem digital
                    'então vou verificar se há digital, se houver testamos lá no final
                    drDigitais = _PG.DrQuery("SELECT binario FROM pessoas, digital WHERE matricula='" & txtMatricula.Text & "' and digital.id_pessoa=pessoas.id_pessoa")
                    If drDigitais.HasRows Then
                        While drDigitais.Read()
                            If drDigitais.Item(0).ToString <> "" Then
                                vbValidaPorDigital = True
                                lblSenha.Visible = False
                            End If
                        End While
                    End If
                Else
                    _toolsSiFam.FinalizeGrFinger()
                    If vbModoOFFLine Then
                        lblSituacao.Text = "Off-Line"
                        lblSituacao.Refresh()
                    End If

                    If vbModoOFFLine Then GoTo PulouSenha
                    lblSenha.Visible = True

                    If vnGlo_ModoAtual <> "0" And _Pessoa.LiberaUsoPorSenha = False And vbValidaPorDigital = False And _Pessoa.Menor12anos = False Then
                        MsgBox("Usuário sem permissão de registro por senha, procure a PREVPEL")
                        GoTo Fim_Bloco
                    End If

                End If

                'vai usar identificacao por senha - ultima modificação 29/09/2014
                If vnGlo_ModoAtual <> 0 And vbValidaPorDigital = False Then
                    If _Pessoa.SenhaDaPessoaNoBanco = "" Then
                        MsgBox("Contribuinte ainda não cadastrou senha, procure a PREVPEL")
                        GoTo Fim_Bloco
                    End If
                    grpSenha.Visible = True
                    mskSenha.Focus()
                ElseIf vnGlo_ModoAtual = 0 Then
                    'RETAGUARDA
                    toolTip1.SetToolTip(Me.btnGravar, "Gravar Nova Senha")
                    lblSituacao.Text = "Desativado"
                End If
            Else
                _toolsSiFam.InitializeGrFinger()
            End If

PulouSenha:
        Catch ex As Exception
            MsgBox("Name cannot be resolved. Error: " + ex.Message)
        End Try
        LiberaAtendimento = True
        If grpSenha.Visible Then mskSenha.Focus()

Fim_Bloco:
        _PG.Desconectar()
    End Function

    Private Sub btnGravar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim id As Integer
        'verifica limitação nas consultas mensais
        Dim drGeneric As Npgsql.NpgsqlDataReader
        Dim vsDataDigitaçãoOFFLine As String = ""
        Dim vsDataConsulta As String = "CURRENT_DATE"

        ' rotina para gravacao de digital - retaguarda
        If vnGlo_ModoAtual = "0" Or vnGlo_ModoAtual = "1" Then
            If vnGlo_ModoAtual = "1" Then  ' consulta
                MsgBox("O modo CONSULTA está ativo e não permite registrar atendimentos.")
                GoTo Fim_Bloco
            End If
            If toolTip1.GetToolTip(btnGravar) = "Revalidar Senha" Then
                grpSenha.Visible = True
                mskSenha.Focus()
                GoTo Fim_Bloco
            End If
            If toolTip1.GetToolTip(btnGravar) = "Gravar Senha" Or toolTip1.GetToolTip(btnGravar) = "Gravar Nova Senha" Then
                CadastraSenha()
                GoTo Fim2
            End If
            If QualidadeDaDigital <= 1 Then
                MsgBox("Digitais de baixa qualidade não são permitidas na gravação. A digital informada foi classificada como ruim, por favor colete novamente a digital.")
                GoTo Fim2
            End If
            If QualidadeDaDigital < 3 Then
                MsgBox("Para melhor resultado na hora da validação das consulta é importante que o cadastro da biometria seja com digitais de alta qualidade. A digital informada foi classificada como média, por favor verifique se não é possível tentar novamente e conseguir um biometria de alta qualidade, caso não seja possível é só prosseguir com o procedimento.")
            End If
            id = _toolsSiFam.Enroll(1, _Pessoa.Id, _u.Login)
            ' localizar outras matriculas da mesma pessoa
            Dim drPessoa2 As Npgsql.NpgsqlDataReader
            Dim id2 As Long
            ' perde a conexao aberta apos salvar digital
            If _PG.Conectar() = False Then Exit Sub

            drPessoa2 = _PG.DrQuery("SELECT id_pessoa,  to_ascii(nome,'LATIN1') as nome, matricula FROM pessoas WHERE nome='" & _Pessoa.Nome & "' and dt_nascimento='" & Format(_Pessoa.DataNascimento, "yyyy/MM/dd ") & "' and id_pessoa <>" & _Pessoa.Id)
            ' drPessoa2 = _PG.drQuery("SELECT id_pessoa, nome, matricula FROM pessoas WHERE nome='" & Trim(NomeSelecionado) & "' and id_pessoa <>" & vnGlo_idPaciente)
            If drPessoa2.HasRows Then
                drPessoa2.Read()
                'gravar digital na outra matricula
                'nao vou dar mensagem , simplesmente vou gravar as duas
                'MsgBox("Encontrada outra matricula para o mesmo Contribuinte ! (N. " & Trim(drContribuinte2.Item(2)) & ")")
                id2 = _toolsSiFam.Enroll(1, drPessoa2.Item(0), _u.Login)
            End If

            If id > 0 Then
                If id2 > 0 Then
                    MsgBox("Digitais gravadas com Sucesso. IDs = " & id & " e " & id2)
                Else
                    MsgBox("Digital gravada com Sucesso. ID = " & id)
                End If
                _util.Log_Gravar("biosifam_erro4", "Digital nova cadastrada com sucesso", True, _Pessoa.Id, IdMedico)

                CarregaDadosPaciente(_Pessoa.Id)
            Else
                MsgBox("Erro ao gravar digital. Digital não localizada.")
            End If
            GoTo Fim2
        End If

        ' validacoes pré-gravacao atendimento =========================================================================
        If _Pessoa.Id = 0 Then MsgBox("Selecione um paciente.") : GoTo Fim_Bloco

        If BolCorrecao Then
            ' descarrgea grid na classe atendimento
            For i = 0 To DrgServicosAtendimento.Rows.Count - 1
                If DrgServicosAtendimento.Rows(i).Cells(3).Value() > 0 Then
                    _Atendimento.IntServico(i) = DrgServicosAtendimento.Rows(i).Cells(0).Value()
                    _Atendimento.DecValor(i) = DrgServicosAtendimento.Rows(i).Cells(3).Value()
                End If
            Next i
            _Atendimento.SalvarCorrecoes(IdAtendimentoCorrecao, oMedicoConveniado, StrJustificativaCorrecao)
            Exit Sub
        End If

        If IdAutorizacaoRemota > 0 Or _Atendimento.IdAtendimentoPendente > 0 Then
            ' libera gravacao sem senha e sem digital

        ElseIf lblSenha.Visible Then
            If grpSenha.Visible = False Then
                grpSenha.Visible = True
                mskSenha.Focus()
                GoTo Fim_Bloco
            End If
            If vbSenhaValidada = False Then ' mskSenha.Text <> vsSenhaDaPessoaNoBanco Then
                MsgBox("Senha informada não confere !")
                grpSenha.Visible = True
                GoTo Fim_Bloco
            End If
            grpSenha.Visible = False
        Else
            If vbIdentificouDigital = False And vbModoOFFLine = False And vbSenhaValidada = False And vbModoSMS = False And vbModoQrCode = False Then
                If grpSenha.Visible Then
                    MsgBox("Senha não foi identificada, Por Favor, informe-a novamente.")
                Else
                    MsgBox("Digital não foi identificada, Por Favor, informe-a novamente.")
                End If
                GoTo Fim_Bloco
            End If
        End If

        vdDataServidor = _PG.DataServidor
        If _PG.Conectar() = False Then Exit Sub

PegaData:
        If vbModoOFFLine Then
            If vbModoRPJ Then
                vsDataDigitaçãoOFFLine = InputBox("Informe a data de realização do atendimento :", "Modo RPJ-Registro Posterior Justificado", Format(Now, "dd/MM/yyyy"))
                If vsDataDigitaçãoOFFLine = "" Then GoTo Fim_Bloco
                If Not IsDate(vsDataDigitaçãoOFFLine) Then
                    MsgBox(" Data Invalida, por favor informe uma data no formato dd/mm/yyyy ", vbCritical, " Data inválida ")
                    GoTo PegaData
                End If
                If CDate(vsDataDigitaçãoOFFLine) > vdDataServidor Then
                    MsgBox("Impossível informar data superior a data atual.", vbCritical, " Data inválida ")
                    GoTo PegaData
                End If
            Else
                vsDataDigitaçãoOFFLine = vdDataServidor
            End If

            ' validação padrão offline
            ' 1. digitação somente até 5 dias retroativos
            ' 2. digitação não pode ser no mesmo dia
            ' 3. exige 5 tentativas de biometria para liberar digitaç~so offline
            ' 4. não permite informar datas futuras

            ' desvios 1. pode ou nao usar digitação offline - deprecate - vou desabilitar - TODOS PODEM USAR OFFLINE
            '         2. pode ou nao desviar das validações padrão do modo offline - vbLiberaRestricoesOffLine

            If oMedicoConveniado.LiberaRestricoesDigitacaoRPJ = False And vbModoBNI = False Then

                If oMedicoConveniado.VerificaRestricoesOffLine(CDate(vsDataDigitaçãoOFFLine), "G") = False Then GoTo PegaData
                If _PG.Conectar() = False Then Exit Sub ' rotina anterior fecha conexao banco
                If oMedicoConveniado.DespesaHospitalar Then
                    'libera digitação offline para estas duas situacoes do novara
                Else
                    If CDate(vsDataDigitaçãoOFFLine) = vdDataServidor Then
                        ' o modo offline não deve aceitar atendimento no mesmo dia se for acionado pelo Menu, se for acionado por erro de digital deve permitir
                        MsgBox("Impossível informar data igual a data atual.", vbCritical, " Data inválida ")
                        If vbModoRPJ Then GoTo PegaData
                    End If

                    If vnContaDigitalRuim < 5 And vbModoRPJ = False Then
                        ' se digital ruim > = 5 entao passa direto e libera digitação
                        ' controle de digitais não identificadas é diferente de ruins
                        drGeneric = _PG.DrQuery("SELECT biometrias_invalidas FROM pessoas WHERE matricula = '" & txtMatricula.Text & "'")
                        If drGeneric.HasRows Then
                            drGeneric.Read()
                            If vdDataServidor = vsDataDigitaçãoOFFLine Then
                                If drGeneric.Item(0).ToString <> "" Then
                                    If drGeneric.Item(0) <> vdDataServidor Then
                                        ' se no mesmo dia nao tiver 5 tentativas nao liberar
                                        MsgBox("O modo BNI-Biometria não identificada só é ativado após 5 tentativas inválidas e essa situação não ocorre ainda hoje.")
                                        GoTo Fim_Bloco
                                    End If
                                Else
                                    MsgBox("O modo BNI-Biometria não identificada só é ativado após 5 tentativas inválidas e essa situação não ocorre ainda hoje.")
                                    GoTo Fim_Bloco
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            vsDataConsulta = "'" & Format(CDate(vsDataDigitaçãoOFFLine), "yyyy/MM/dd") & "'"

        End If

        If cmbMedico.Items.Count > 1 And cmbMedico.SelectedIndex = -1 Then
            MsgBox("Selecione um prestador. ")
            cmbMedico.Focus()
            GoTo Fim_Bloco
        End If

        If oMedicoConveniado.Dentista Then
            If cmbProcedimento.SelectedIndex = -1 Then
                MsgBox("Para Dentistas é necessário selecionar pelo menos um procedimento.")
                cmbProcedimento.Focus()
                GoTo Fim2
            End If
        End If

        If _ServicoPrincipal.Id = 16981 Then   ' fisioterapia
            ' preciso guardar a autorizacao no atendimento,
            ' assim não permitirá que mais de uma sessão seja registrada por dia.
            If _Pessoa.AutorizacoesEmAberto > 0 Then
                If _Pessoa.AutorizacoesEmAberto > 1 Then
                    _Pessoa.AutorizacaoFisioterapia = Val(InputBox("Informe a Autorização em que será realizada a sessão de fisioterapia?", "Paciente possui " & _Pessoa.AutorizacoesEmAberto & " autorizações de Fisioterapia"))
                End If
                drGeneric = _PG.DrQuery("SELECT id_pessoa,sessoes_autorizadas,sessoes_realizadas,tipo,situacao FROM atendimento_autorizacao WHERE id_atendimento_autorizacao=" & _Pessoa.AutorizacaoFisioterapia)
                If drGeneric.HasRows Then
                    drGeneric.Read()
                    If drGeneric("id_pessoa") <> _Pessoa.Id Then
                        MsgBox("Autorização informada pertence a outro Paciente!")
                        GoTo Fim_Bloco
                    End If
                    If _Autorizacao.ImpeditivosDeUso(drGeneric) <> "" Then GoTo Fim_Bloco
                Else
                    MsgBox("Autorização informada não localizada! Verifique a informação.")
                    GoTo Fim_Bloco
                End If
            Else
                MsgBox("Contribuinte não possui Autorização de Fisioterapia." & Chr(13) & Chr(13) & "Para prosseguir é necessário que a PREVPEL autorize o procedimento.", vbInformation, "Nenhuma Autorização disponível")
                GoTo Fim_Bloco
            End If

            ' pesquisa 3 atendimentos na semana - OS OS11813/2021
            drGeneric = _PG.DrQuery("select current_date ")
            If drGeneric.HasRows Then
                drGeneric.Read()
                vdDataServidor = Format(drGeneric.Item(0), "dd/MM/yyyy")
            End If
            Dim vnConsultasFisioterapiaRealizadasSemana As Integer
            Dim diaSemana As Integer = vdDataServidor.DayOfWeek

            vnConsultasFisioterapiaRealizadasSemana = _PG.RecordCount(_toolsSiFam.ObtemConsultas(txtMatricula.Text, "CF", diaSemana, _Pessoa.AutorizacaoFisioterapia))
            If vnConsultasFisioterapiaRealizadasSemana >= 3 Then
                MsgBox("Paciente já registrou " & vnConsultasFisioterapiaRealizadasSemana & " sessões na semana para a Autorização informada (" & _Pessoa.AutorizacaoFisioterapia & "), impossível registrar mais de 3 sessões na semana para a mesma autorização.", vbExclamation, "Registro não permitido.")
                GoTo Fim2
            End If
        End If

IniciaAtendimento:
        ' novo padrão iniciando gravações de consulta na tabela atendimentos, id fixo consulta médica=1, dentista não grava consulta só procedimentos
        IdUltimoAtendimento = 0
        _Atendimento.IdResponsavelFinanceiro = idResponsavelFinanceiro
        _Atendimento.IdAutorizacaoFisioterapia = _Pessoa.AutorizacaoFisioterapia
        _Atendimento.BolValidacaoPorSenha = lblSenha.Visible
        _Atendimento.Justificativa = vsJustificativa
        _Atendimento.IntTipoDigitacao = 1
        _Atendimento.StrTipoConsulta = "N"  ' N-normal, E-Excedente, B-bonus

        If IdAutorizacaoRemota > 0 Then
            _Atendimento.IdAutorizacaoRemota = IdAutorizacaoRemota
            If TipoAutorizacaoRemota = "R" Then
                _Atendimento.IntTipoDigitacao = 3
            Else
                _Atendimento.IntTipoDigitacao = 9   ' autorizacao via balcao de atendimento
            End If
        End If
        If _Autorizacao.IntAutorizacao > 0 Then
            _Atendimento.IdAutorizacaoRemota = _Autorizacao.IntAutorizacao
        End If
        If vbModoOFFLine Then
            _Atendimento.IntTipoDigitacao = 2
            If vbModoRPJ Then _Atendimento.IntTipoDigitacao = 4   ' rpj registro posterior com justificativa
            If vbModoBNI Then _Atendimento.IntTipoDigitacao = 5   ' bni biometria nao identificada
        End If
        If vbModoSMS Then _Atendimento.IntTipoDigitacao = 6   ' autorizacao via SMS
        ' tipo=7=NC
        If vbModoQrCode Then _Atendimento.IntTipoDigitacao = 8   ' autorizacao via qrcode

        _Atendimento.vsDataConsulta = vsDataConsulta

        If oMedicoConveniado.Modo = 3 Or oMedicoConveniado.Modo = 4 Or oMedicoConveniado.Modo = 5 Or
            oMedicoConveniado.FazExameNoConsultorio Or oMedicoConveniado.Anestesista Or chkRegistraSomenteExames.Checked Then
            ' medico que faz exame entra aqui para validar exame repetido - depois segue
            ' categ 1-hospit,2-pronto aten,3-lab,4-clini
            ' modo exames (3) vai direto para gravcao procedimento
            ' anestesistas não grava consulta, pula validações, grava direto tabela atendimento
            ' validacoes ocorre la no gravaprocediemntos
            ' pronto atendimento grava tipo de consulta (urgente ou n urgente) e fica pendente, posterior pode alterar e ainda inserir procedimento.


            ' IdServico = 1   ' default é medico
            ' a consulta medica passou a integrar os servicos de clinicas e prontos atentimentos, entao precisa entrar nas regras de validacao
            If _Atendimento.vnContaServicos > 0 Then

                ' 16950 pronto atendimento nao urgencia '  Or _Atendimento.IntServico(0) = 16950 Or _Atendimento.IntServico(1) = 16950 
                If _Atendimento.IntServico(0) = 1 Or _Atendimento.IntServico(1) = 1 Then
                    If _Atendimento.ValidaLimiteConsultasOuAtivaBonusExcedente(_Pessoa, oMedicoConveniado) = False Then GoTo Fim_Bloco
                End If

                If oMedicoConveniado.Modo = 3 Or oMedicoConveniado.Modo = 4 Or oMedicoConveniado.Modo = 5 Then   ' categ 1-hospit,2-pronto aten,3-lab,4-clini

                    If oMedicoConveniado.LaboratorioAnalisesClinicas Then
                        ' Update servico set valor=0 where cbhpm_capitulo Like '403%'
                        ' insert into prestador_servicos (select id_prestador, id_servico from prestador, servico where categoria2 = 8 And cbhpm_capitulo Like '403%')

                        If _Pessoa.ConsultaExamesClinicosRealizados(oMedicoConveniado, 365) > _setup.limite_maximo_exames_analises_clinicas Then
                            MsgBox("Paciente já usou seu limite máximo de Exames de Análises Clinicas nos últimos 365 dias. São permitidos " & _setup.limite_maximo_exames_analises_clinicas & " exames a cada 365 dias, conforme legislação vigente.", vbInformation, "Impossível registrar atendimento!")
                            GoTo Fim2
                        End If

                        If (_Pessoa.ExamesClinicosRealizados + _Atendimento.vnContaServicos) > _setup.limite_maximo_exames_analises_clinicas Then
                            MsgBox("O exames informados hoje, somados aos já realizados nos últimos 365 dias ultrapassam o limite permitido (" & _setup.limite_maximo_exames_analises_clinicas & "). São permitidos " & _setup.limite_maximo_exames_analises_clinicas & " exames a cada 365 dias,conforme legislação vigente.", vbInformation, "Impossível registrar atendimento!")
                            GoTo Fim2
                        End If
                    End If

                    ' nao usa produto 1, 16949, 16950
                    ' são exames e podem ser repetidos.
                    ' entao desvia os testes abaixo
                    GoTo GravaProcedimentos
                End If

                If _Atendimento.IntServico(0) = _Atendimento.IntServico(1) Then
                    ' 27 nao especificado
                    MsgBox("Não é permitido selecionar dois procedimentos iguais!", vbInformation, "Impossível registrar novo atendimento!")
                    GoTo Fim2
                End If
                If (_Atendimento.IntServico(0) = 16950 And _Atendimento.IntServico(1) = 16949) Or (_Atendimento.IntServico(1) = 16950 And _Atendimento.IntServico(0) = 16949) Then
                    ' 27 nao especificado
                    MsgBox("Não é permitido selecionar procedimento de Urgência e não Urgência ao mesmo tempo ! utilize a tecla Delete para excluir um dos procedimentos.", vbInformation, "Impossível registrar novo atendimento!")
                    GoTo Fim2
                End If
                ' servico 3 nao é usado pelo  modo que usa abaixo

            End If

            ' se só faz exame é Medico entao segue para registrar consulta
            If oMedicoConveniado.Modo = 3 Or oMedicoConveniado.Modo = 4 Or oMedicoConveniado.Anestesista Or chkRegistraSomenteExames.Checked Then
                GoTo GravaProcedimentos
            End If

        End If

        ' Demais Modos  medicos e dentistas (2) e fisioterapeutas (4) - gravam consulta e depois SE usam PROCEdimENTOs não É OBRIGATORIO, 

        ' trava eventos se paciente já registrou consulta no dia no mesmo conveniado - fisoterapia tambem (so uma por dia)
        ' nova regra em 23/02/2022 2.2.30 elimina trava diaria para matricula e passa para usuario

        ' nao tem atendimento no dia, mas é offline e faz exame
        If vbModoOFFLine And oMedicoConveniado.FazExameNoConsultorio Then
            ' ocorre em alguns consultórios que fazem a consulta em um dia e posteriomente fazem o exame
            ' vou permitir gravar somente exame (procedimento)
            If MsgBox("O modo Offline com registro de exames ativado permite registrar exames sem a consulta médica. Deseja registrar somente o procedimento (exame) ?", vbYesNo, "Registro  Offline") = vbYes Then
                If cmbProcedimento.SelectedIndex = -1 And cmbProcedimento2.SelectedIndex = -1 Then
                    MsgBox("Selecione um procedimento !", vbInformation, "Impossível registrar procedimento !")
                    GoTo Fim2
                End If
                GoTo GravaProcedimentos
            Else
                If cmbProcedimento.SelectedIndex = -1 And cmbProcedimento2.SelectedIndex = -1 Then
                    If MsgBox("Nenhum procedimento médico foi informado, registrar somente a consulta médica ?", vbYesNo, "Registro  Offline") = vbNo Then GoTo Fim2
                End If
            End If
        End If

VerificaBonus:

        If _Atendimento.ValidaLimiteConsultasOuAtivaBonusExcedente(_Pessoa, oMedicoConveniado) = False Then GoTo Fim_Bloco  ' rotina unificada para medicos e dentista e nutricionistas

        If _u.Login = "" Then _u.Login = IdMedico

ConfirmaGravacao:
        If _u.vbUsuarioSuporte Or _u.vbUsuarioPrevpel Or oMedicoConveniado.FazExameNoConsultorio Or cmbMedico.Items.Count > 1 Then
            ' desvio para usuario de suporte e manutenção
            If MsgBox("Deseja realmente gravar o atendimento realizado por " & oMedicoConveniado.Nome & " para " & _Pessoa.Nome & " ?", MsgBoxStyle.YesNo, "Confirme a operação de gravação.") = vbNo Then
                GoTo Fim_Bloco
            End If
        End If

        If oMedicoConveniado.Categoria = "M" Then
            _Atendimento.ValorServicoPrincipal = _ServicoPrincipal.Valor
            _Atendimento.ValorServicoPrincipalPrestador = _ServicoPrincipal.ValorPrestador
            _Atendimento.ValorServicoPrincipalContribuinte = _ServicoPrincipal.ValorContribuinte

            IdUltimoAtendimento = _Atendimento.GravarAtendimento(_Pessoa, oMedicoConveniado, _ServicoPrincipal.Id, _Atendimento.StrTipoConsulta, oMedicoConveniado.Categoria)
            If IdUltimoAtendimento > 0 Then
                MsgBox("Atendimento registrado com Sucesso. Identificador N. " & IdUltimoAtendimento)
                ImprimirComprovante()
            End If
        End If

        If oMedicoConveniado.FazExameNoConsultorio Or oMedicoConveniado.Dentista Then
            GoTo GravaProcedimentos
        End If

        GoTo Fim_Bloco

GravaProcedimentos:

        If oMedicoConveniado.Modo = 4 Or oMedicoConveniado.Anestesista Or oMedicoConveniado.Modo = 3 Or oMedicoConveniado.Modo = 5 Then
            ' vsModo=4=pronto atendimento       nao grava consulta
            ' vsModo=2=anestesista = 2          nao grava consulta
            ' vsModo=3=exames -                 não grava consulta
            ' PROCEdimENTOs São OBRIGATORIOs - exceto PA - liberei versao 2.2.11-15/12/2021
            If _Atendimento.vnTotalServicos = 0 Then
                MsgBox("Obrigatório informar um procedimento.", vbInformation, "Informe um procedimento.")
                cmbProcedimento.Focus()
                GoTo Fim2
            End If
        Else
            ' modo consultorio com exame, e nao selecionou nenhum procedimento, entao nao grava nada
            If _Atendimento.vnTotalServicos = _ServicoPrincipal.Valor And chkRegistraSomenteExames.Checked = 0 Then GoTo Fim_Bloco
        End If

        ' modo 3 = exames ' a partir de 03/2022 todos exames tem de ter precrição médica
        Dim StrTipoUpLoad As String = "D" ' dedault D=despesa
        If oMedicoConveniado.Modo = 3 Or oMedicoConveniado.Modo = 5 Then
            If oMedicoConveniado.Vinculo <> "S" Then StrTipoUpLoad = "P"   ' P=prescricao
            If txtArquivoDespesas.Text = "" Then
                If oMedicoConveniado.Vinculo = "S" Then
                    '+ vinculo='S' = laboratorios hu/santa casa/miguel piltcher nao colocam precrição e sim comprovante -16953=pront atend despesa extra
                    If MsgBox("Para exames é necessário anexar a discriminação das despesas! Isso é indispensável ao fechamento financeiro e recebimento dos servicos prestados, porém pode ser informada em outro momento." & Chr(13) &
                      "Deseja realizar o UpLoad agora ? ", vbYesNo) = vbYes Then
                        GrpUpload.Visible = True
                        GoTo Fim2
                    End If
                Else
                    ' so exmae em clinicas e laboratório dai só precisa a prescrição médica
                    If MsgBox("Para exames é necessário anexar a prescrição médica!  A prescrição Médica é indispensável ao fechamento financeiro e recebimento dos servicos prestados. A prescrição pode ser informada em outro momento." & Chr(13) &
                              "Deseja prosseguir e registrar o atendimento ? ", vbYesNo) = vbNo Then
                        GrpUpload.Visible = True
                        GoTo Fim2
                    End If
                End If
            End If
        End If

        If oMedicoConveniado.Modo = "4" Then        ' Pronto Atendimento
            ' só 3 ITENS
            ' modo 4 = pronto atendimento
            If (_Atendimento.IntServico(0) = 16953 Or _Atendimento.IntServico(1) = 16953 Or _Atendimento.IntServico(2) = 16953) Then
                ' 16953=pront atend despesa extra
                If txtArquivoDespesas.Text = "" Then
                    MsgBox("Para Despesas Extras é necessário anexar a discriminação das despesas.")
                    GrpUpload.Visible = True
                    GoTo Fim2
                End If
            End If

        End If

        If oMedicoConveniado.Dentista Then
            ' SO UM SERVICO - USA SERVICO PRINCIPAL
            ' so 1 procedimento, servico=42=extracao 3 molar
            If _ServicoPrincipal.Id = 42 And mskValor.Text > 300 Then
                ' valor maximo 300 em 01/01/2022- versao 2.2.17
                MsgBox("Valor máximo permitido para este procedimento é de R$ 300,00.")
                GoTo Fim2
            End If
            If _ServicoPrincipal.Id = 42 And _Pessoa.TerceirosMolaresExtraidos > 3 Then
                MsgBox("Paciente já teve registro de extração de todos Terceiros Molares. Impossível Prosseguir.")
                GoTo Fim2
            End If
        End If

        ' descarrgea grid na classe atendimento
        For i = 0 To DrgServicosAtendimento.Rows.Count - 1
            If DrgServicosAtendimento.Rows(i).Cells(3).Value() > 0 Then
                _Atendimento.IntServico(i) = DrgServicosAtendimento.Rows(i).Cells(0).Value()
                _Atendimento.DecValor(i) = DrgServicosAtendimento.Rows(i).Cells(3).Value()
            End If
        Next i
        IdUltimoAtendimento = _Atendimento.GravarAtendimento(_Pessoa, oMedicoConveniado, 0, _Atendimento.StrTipoConsulta, oMedicoConveniado.Categoria)
        If IdUltimoAtendimento = 0 Then GoTo Fim2
        If oMedicoConveniado.Categoria = "O" Or oMedicoConveniado.Modo = 4 Or oMedicoConveniado.Modo = 5 Then MsgBox("Procedimento(s) registrado(s) com Sucesso. Identificador N. " & IdUltimoAtendimento)
        If oMedicoConveniado.Modo = 3 Then MsgBox("Exames registrado(s) com Sucesso. Identificador N. " & IdUltimoAtendimento)

        ImprimirComprovante()

        If txtArquivoDespesas.Text <> "" Then
            atualizaLogList("iniciando upload de comprovantes. aguarde a conclusão do processo.")
            NotifyIcon1.Visible = True
            If _PG.InsereArquivoBinario(oMedicoConveniado.Id, StrTipoUpLoad, _Atendimento.IdAtendimento, txtArquivoDespesas.Text) Then MsgBox("Upload realizado com sucesso.")
            NotifyIcon1.Visible = False
        End If

        Me.Cursor = Cursors.Default

Fim_Bloco:
        LimpaNovoAtendimento()

Fim2:
        _PG.Desconectar()
        ' só limpa tudo se deu certo, dependendo da situação faltou alguma informacao e precisa complementar e continuar
        If IdUltimoAtendimento > 0 Then LimpaNovoAtendimento()

    End Sub

    Private Sub ImprimirComprovante()
        Dim vnCopias As String = 1, i As Integer
        If oMedicoConveniado.Modo = 4 And _Atendimento.IdAtendimentoPendente = 0 Then Exit Sub
        vnCopias = Val(InputBox("Se desejar imprimir comprovante, informe número cópias deseja:", "Informe o numero de copias", "1"))
        If vnCopias > 0 Then
            If _PG.Conectar() = False Then Exit Sub
            For i = 1 To Val(vnCopias)
                drServicos = _PG.DrQuery("SELECT id_atendimento, matricula, to_ascii(p.nome ,'LATIN1') nome_paciente,to_ascii(s.descricao ,'LATIN1') nome_servico, a.valor, id_juridica, id_medico, a.situacao, ats.valor FROM atendimento a inner join atendimento_servico ats using(id_atendimento) inner join servico s using(id_servico) inner join pessoas p using(id_pessoa) where a.id_atendimento=" & _Atendimento.IdAtendimento)
                If drServicos.HasRows Then
                    drServicos.Read()
                    PrintDocument1.Print()
                End If
            Next i
        End If
    End Sub

    Private Sub VerifyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ret As Integer
        Dim score As Integer
        Dim sid As String

        score = 0
        sid = InputBox("Digite o ID  para verificar", "Verificar", "")
        If sid <> "" Then
            ret = _toolsSiFam.Verify(_PG, Val(sid), score)
            If ret < 0 Then
                atualizaLogList(ret)
            ElseIf ret = GrFinger.GR_NOT_MATCH Then
                atualizaLogList("Não encontrada com escore = " & score)
            Else
                atualizaLogList("Encontrada com escore = " & score)
                _toolsSiFam.PrintBiometricDisplay(True, GrFinger.GR_DEFAULT_CONTEXT)
            End If
        End If
    End Sub


    ' Escreve Status no list box.
    Public Sub atualizaLogList(ByVal message As String)
        LogList.Items.Add(message)
        LogList.SelectedIndex = LogList.Items.Count - 1
        LogList.ClearSelected()
        Dim _util As New clsUtil
        _util.Mensagem_LogLocal(message, False, "FormMain", True, "")
    End Sub


    ' -----------------------------------------------------------------------------------
    ' GrFingerX events
    ' -----------------------------------------------------------------------------------
    ' A fingerprint reader was plugged on system
    Private Sub AxGrFingerXCtrl1_SensorPlug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) Handles AxGrFingerXCtrl1.SensorPlug
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Conectado.")
        AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
        lblSituacao.BackColor = Color.Green
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "aguardando..."

        ' registra e cataloga modelos de leitora biometrica
        Dim drGeneric As Npgsql.NpgsqlDataReader
        Try
            If e.idSensor <> "File" Then
                If _PG.Conectar() Then
                    drGeneric = _PG.DrQuery("select id_leitor_biometrico from leitor_biometrico where chave='" & Trim(e.idSensor) & "'")
                    If drGeneric.HasRows = False Then
                        _PG.Execute("insert into leitor_biometrico (nome, chave, login, ip, dt_alteracao, hr_alteracao) values ('nome_" & Trim(e.idSensor) & "','" & Trim(e.idSensor) & "', '" & _u.Login & "', '" & _t.ObtemEnderecoIP &
                    "', CURRENT_DATE, '" & Date.Now.ToShortTimeString() & "')")
                    End If
                End If
                _PG.Desconectar()
            End If
        Catch
        End Try
        drGeneric = Nothing
    End Sub

    ' A fingerprint reader was unplugged from system
    Private Sub AxGrFingerXCtrl1_SensorUnplug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) Handles AxGrFingerXCtrl1.SensorUnplug
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Desconectado.")
        AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Desconectado"
    End Sub

    ' A finger was placed on reader
    Private Sub AxGrFingerXCtrl1_FingerDown(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) Handles AxGrFingerXCtrl1.FingerDown
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Dedo posicionado.")
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Dedo Posicionado"
    End Sub

    ' A finger was removed from reader
    Private Sub AxGrFingerXCtrl1_FingerUp(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) Handles AxGrFingerXCtrl1.FingerUp
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Dedo removido.")
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Dedo Removido"
    End Sub

    ' An image was acquired from reader
    Private Sub AxGrFingerXCtrl1_ImageAcquired(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) Handles AxGrFingerXCtrl1.ImageAcquired

        Dim ret As Integer
        Dim vbLiberaBiometria As Boolean = False
        QualidadeDaDigital = 0

        grdIdentifica.DataSource = Nothing
        idDigital = 0
        vbIdentificouDigital = False
        vbSenhaValidada = False

        btnGravar.Enabled = False

        If _Pessoa.Id = 0 Then MsgBox("Informe uma Matricula e selecione um paciente.") : Exit Sub

        lblSituacao.BackColor = Color.Yellow
        lblSituacao.ForeColor = Color.Black
        lblSituacao.Text = "Conectado, avaliando digital."

        _toolsSiFam.raw.height = e.height
        _toolsSiFam.raw.width = e.width
        _toolsSiFam.raw.res = e.res
        _toolsSiFam.raw.img = e.rawImage
        _toolsSiFam.PrintBiometricDisplay(False, GrFinger.GR_DEFAULT_CONTEXT)

        If _PG.Conectar() = False Then Exit Sub

        ret = _toolsSiFam.ExtractTemplate()

        If vnGlo_idLeitor = 0 Then
            ' localiza sensor
            drGeneric = _PG.DrQuery("select id_leitor_biometrico from leitor_biometrico where chave='" & Trim(e.idSensor) & "'")
            If drGeneric.HasRows Then
                drGeneric.Read()
                vnGlo_idLeitor = drGeneric.Item(0)
            End If
        Else
            If vnGlo_idLeitor <> _w.LeitorId Then
                ' atualiza leitor
                _PG.Execute("update workstation set id_leitor_biometrico=" & vnGlo_idLeitor & " where id_workstation='" & _w.idWorkstation & "'")
            End If
        End If

        If ret = GrFinger.GR_BAD_QUALITY Then
            QualidadeDaDigital = 1
            _util.Log_Gravar("biosifam_erro1", "A Digital extraída não foi localizada. ", False, _Pessoa.Id, IdMedico)
            _toolsSiFam.WriteLog("Digital extraída com Qualidade RUIM.")
            vsGlo_Log = "A Digital extraída está com Qualidade RUIM, Por favor tente novamente.(Tentativa:" & vnContaDigitalRuim + 1 & ")"
            MsgBox(vsGlo_Log)

            vbPassou = False
            vnContaDigitalRuim += 1
            If vnGlo_ModoAtual <> "0" Then
                If VerificaAtivaBNI() Then GoTo Fim_Bloco
            Else
                If vnContaDigitalRuim >= 5 Then
                    CadastraSenha()
                    GoTo Fim_Bloco
                End If
            End If
        ElseIf ret = GrFinger.GR_MEDIUM_QUALITY Then
            QualidadeDaDigital = 2
            _util.Log_Gravar("biosifam_erro2", "A Digital extraída está com Qualidade MÉDIA.", False, _Pessoa.Id, IdMedico)
            _toolsSiFam.WriteLog("Digital extraída com Qualidade Média.")
            vbLiberaBiometria = True
            'vnContaDigitalRuim = 0
        ElseIf ret = GrFinger.GR_HIGH_QUALITY Then
            QualidadeDaDigital = 3
            vbLiberaBiometria = True
            vnContaDigitalRuim = 0
            _util.Log_Gravar("biosifam_erro8", "Digital extraída com Alta Qualidade.", False, _Pessoa.Id, IdMedico)
            _toolsSiFam.WriteLog("Digital extraída com Alta Qualidade.")
        Else
            _util.Log_Gravar("biosifam_erro3", "Digital não capturada, Digital ilegível !, Tentativa: " & vnContaDigitalNaoIdentificada + 1, True, _Pessoa.Id, IdMedico)
            'vnContaDigitalRuim = 0     elimimei esta opção
            vnContaDigitalNaoIdentificada += 1
            If VerificaAtivaBNI() Then GoTo Fim_Bloco
        End If

        If vbLiberaBiometria Then
            Dim score As Integer

            score = 0
            ' imprime matriz de ponto sobre a digital
            _toolsSiFam.PrintBiometricDisplay(True, GrFinger.GR_NO_CONTEXT)

            ret = _toolsSiFam.Identify(score, 1, _Pessoa.Id, _Pessoa.Menor12anos, txtMatricula.Text)
            If ret > 0 Then
                _util.Log_Gravar("biosifam_biometria_ok", "Digital identificada com sucesso", True, _Pessoa.Id, IdMedico)
                atualizaLogList("Digital identificada. ID = " & ret & ". Escore = " & score & ".")

                'identificou a digital 
                Dim ds As New DataSet
                grdIdentifica.DataSource = Nothing
                idDigital = ret
                If idDigital > 0 Then
                    btnGravar.Enabled = True
                    If vnGlo_ModoAtual = "0" Then
                        toolTip1.SetToolTip(Me.btnGravar, "Gravar Nova Digital")
                    Else
                        InicializaBotaoGravar()
                        If vnGlo_ModoAtual = "1" Then MsgBox("Digital identificada com sucesso !")
                    End If
                    If _Pessoa.ValidarBiometria(idDigital) Then
                        ds = _PG.DsQuery("SELECT id_digital, to_ascii(nome,'LATIN1') as nome FROM pessoas INNER JOIN digital USING (id_pessoa) WHERE id_digital = " & idDigital)
                        vbIdentificouDigital = True
                        grdIdentifica.DataSource = ds.Tables(0)
                        'ds.Tables.Item(0).Columns(1).ToString
                        grdIdentifica.Columns(0).Width = 50
                        grdIdentifica.Refresh()
                        If vnGlo_ModoAtual > "1" Then MsgBox("Clique em Gravar para registrar o atendimento !", vbInformation, "Atenção !") : btnGravar.Focus()

                    Else
                        btnGravar.Enabled = False
                    End If
                Else
                    ' strModo -> 0=Retaguarda, 1=Consulta, 2=Consultório, 3-exames, 4-fisioterapeuta
                    If vnGlo_ModoAtual = "0" Then
                        toolTip1.SetToolTip(Me.btnGravar, "Gravar Digital")
                        btnGravar.Enabled = True
                    Else
                        _util.Log_Gravar("biosifam_erro5", "Digital informada não localizada na Base de Dados.", True, _Pessoa.Id, IdMedico)
                        CadastraSenha()
                    End If
                End If
            Else
                ' strModo -> 0=Retaguarda, 1=Consulta, 2=Consultório, 3-exames, 4-fisioterapeuta
                If vnGlo_ModoAtual = 0 Then
                    toolTip1.SetToolTip(Me.btnGravar, "Gravar Digital")
                    btnGravar.Enabled = True
                Else
                    _util.Log_Gravar("biosifam_erro5", "Digital informada não localizada para o paciente selecionado ! " & Chr(13) & "Tentativa: " & vnContaDigitalNaoLocalizada + 1, True, _Pessoa.Id, IdMedico)
                    vsGlo_Log = "Digital Não identificada. = " & ret & ". Escore = " & score & "."
                    vnContaDigitalNaoLocalizada += 1
                    If VerificaAtivaBNI() Then GoTo Fim_Bloco
                End If
            End If
            vnGlo_idDigital = ret
            vbGlo_InseriuDigital = True
        End If
Fim_Bloco:
        _PG.Desconectar()

    End Sub

    Public Function VerificaAtivaBNI() As Boolean
        VerificaAtivaBNI = False
        ' versao 2.2.00 - antes so ativa BNI individualmente (vnContaDigitalRuim ou vnContaDigitalNaoIdentificada)
        If (vnContaDigitalRuim + vnContaDigitalNaoIdentificada + vnContaDigitalNaoLocalizada) > 4 Then
            vdDataServidor = _PG.DataServidor
            vbModoBNI = True

            If vnContaDigitalNaoIdentificada >= 5 And vnGlo_ModoAtual <> "1" Then _PG.Execute("update pessoas set biometrias_invalidas=current_date where id_pessoa=" & _Pessoa.Id)

            'If vdDataServidor > CDate("2021/12/31") Then
            _util.Log_Gravar("biosifam_erro6", "Digital com 5 tentativas de identificação sem sucesso, nesta situação, talvez o paciente precise utilizar o modo senha, esta avaliação deve ser realizada na PREVPEL. Para prosseguir o atendimento utilize o sistema de autorização por QrCode ou SMS.", True, _Pessoa.Id, IdMedico)
            If MsgBox("Deseja utilizar o QrCode agora ?", vbYesNo, "") = vbYes Then
                ChamaQrCode()
                Exit Function
            Else
                If MsgBox("Deseja utilizar o SMS agora ?", vbYesNo, "") = vbYes Then
                    MsgBox("A autorização via SMS funciona através do ícone Celular, ao lado do botão NC junto aos demais botões de controle do Biosifam. O funcionamento é simples, ao clicar no botão deve-se primeiro informar que deseja gerar um código de acesso, digitando 1, posteriormente, quando o paciente receber o código, utilize a opção 2 para validar e autorizar o registro.")
                    ChamaSMS()
                    Exit Function
                End If
            End If
            vbModoBNI = False

        End If

    End Function

    ' Escreve Status no list box.
    Public Sub CadastraSenha()
        If _Pessoa.Id = 0 Then
            MsgBox("Paciente não localizado ")
        Else
            'estou lendo lá no inicio - carregaidentificador
            'dr = _PG.drQuery("SELECT senha FROM pessoas where id_pessoa=" & vnGlo_idPaciente)
            'If dr.HasRows Then vsSenhaDaPessoaNoBanco = dr.Item(0)
            If _Pessoa.SenhaDaPessoaNoBanco = "" Then
                If MsgBox("Paciente não possui senha cadastrada, deseja informar agora ?", vbYesNo) = vbYes Then
                    frmSenha.Left = Me.Left + 150
                    frmSenha.Top = Me.Top + 150
                    frmSenha.ShowDialog()
                    vsSenha = frmSenha.mskSenha.Text

                    'confirma senha
                    Dim vsSenhaConfirma As String
                    frmSenha.Text = "Por favor, confirme a senha"
                    frmSenha.ShowDialog()
                    vsSenhaConfirma = frmSenha.mskSenha.Text
                    If vsSenha <> vsSenhaConfirma Then
                        MsgBox("As senhas informadas não conferem, nada será atualizado")
                        lblSenha.Visible = True
                        'vai usar identificacao por senha
                        If vnGlo_ModoAtual <> 2 Then
                            'RETAGUARDA
                            toolTip1.SetToolTip(Me.btnGravar, "Nova Senha")
                            btnGravar.Enabled = True
                            lblSituacao.Text = "Desativado"
                        End If

                        Exit Sub
                    End If
                    'vsSenha = InputBox("Informe sua senha de consulta.", "Senha para Consultas", "*")
                    If vsSenha <> "" Then
                        If _PG.Conectar() = False Then Exit Sub
                        _PG.Execute("update pessoas set senha='" & vsSenha & "', senha_data=current_date, biosifam_senha='S' where id_pessoa=" & _Pessoa.Id)
                        If _PG.RetornoExecute Then
                            _Pessoa.SenhaDaPessoaNoBanco = vsSenha
                            'apaga também todas digitais registradas anteriormente
                            _PG.Execute("delete from digital where id_pessoa=" & _Pessoa.Id)
                            _PG.Desconectar()
                            MsgBox("Senha atualizada com sucesso ! " & Chr(13) & Chr(13) & "Este Paciente a partir de agora terá identificação pela senha informada e não utilizará o sistema Biométrico.")
                            btnMatricula.PerformClick()

                            ' strModo -> 0=Retaguarda, 1=Consulta, 2=Consultório
                            If vnGlo_ModoAtual = 0 Then Exit Sub

                            If MsgBox("Deseja registrar a consulta agora ?", vbYesNo) = vbNo Then Exit Sub
                        End If
                        _PG.Desconectar()
                    Else
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("O paciente já possui uma senha cadastrada. Para alterá-la, exclua a senha atual com o botão excluir e informe uma nova senha.")
            End If

            btnGravar.Enabled = True
            If vnGlo_ModoAtual = "0" Then
                toolTip1.SetToolTip(Me.btnGravar, "Gravar Senha")
            Else
                toolTip1.SetToolTip(Me.btnGravar, "Gravar Atendimento")
            End If

        End If
    End Sub

    Private Sub SIFAMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SIFAMToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://sifam.pelotas.com.br?destino=server")
    End Sub

    Private Sub DigitaisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DigitaisToolStripMenuItem.Click

        If RelatorioAcessosRealizados(IdMedico, vsFiltro, vsFiltroTexto) Then
            System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath & "\RelatorioContribuintesPorTipoAcesso.htm")
        End If

    End Sub

    Private Sub ConsultasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultasToolStripMenuItem.Click
        ' relatório de Consultas Médicas
        Try
            vsRetorno = InputBox("Informe uma data ou intervalo para pesquisar os atendimentos (dd/mm/yyyy ou dd/mm/yyyy-dd/mm/yyyy): ", "Relatório de Atendimentos Realizados", Format(Date.Today, "dd/MM/yyyy"))

            If InStr(vsRetorno, "-") > 0 Then
                vdData = CDate(vsRetorno.Substring(0, 10))
                vdDataFim = CDate(vsRetorno.Substring(11, 10))
            Else
                If IsDate(vsRetorno) = False Then MsgBox("Data inválida ") : Exit Sub
                vdData = CDate(vsRetorno)
                vdDataFim = CDate(vsRetorno)
            End If
            If vsRetorno = "" Then Exit Sub

            ' vsModo -> 0=Retaguarda, 1=Consulta, 2=Consultório, 3-Exames, 4-Fisioterapia, 5-pronto atendimento
            If IdMedico = 0 Then
                MsgBox("Nenhum médico foi informado, por favor selecione um médico.")
                cmbMedico.Focus()
                Exit Sub
            End If

            Dim VarLocalIdResponsavelFinanceiro As Integer = idResponsavelFinanceiro

            If oMedicoConveniado.Dentista Or oMedicoConveniado.Modo = 3 Then
                System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/index.php?destino=reportDiarioGeralExames.php&print=Biosifam&r=" & VarLocalIdResponsavelFinanceiro & "&form_consultorio=" & oMedicoConveniado.FazExameNoConsultorio & " &form_datai= " & Format(vdData, "yyyy-MM-dd") & "&form_dataf=" & Format(vdDataFim, "yyyy-MM-dd") & "&form_id_medico=" & System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(IdMedico)))
            Else
                Dim StrOpcao As String
                If oMedicoConveniado.FazExameNoConsultorio Then
                    StrOpcao = InputBox("Para gerar relatório de Consultas, informe 1, para exames informe 2.", "", 1)
                Else
                    StrOpcao = "1"
                End If
                'If oMedicoConveniado.ResponsavelFinanceiro_Id <> idResponsavelFinanceiro Then

                'End If

                If oMedicoConveniado.ResponsavelFinanceiro Then VarLocalIdResponsavelFinanceiro = oMedicoConveniado.Id
                If StrOpcao = "1" Then
                    System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/index.php?destino=reportDiarioPrestador.php&print=Biosifam&r=" & VarLocalIdResponsavelFinanceiro & "&form_datai=" & Format(vdData, "yyyy-MM-dd") & "&form_dataf=" & Format(vdDataFim, "yyyy-MM-dd") & "&form_id_medico=" & System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(IdMedico)))
                End If

                If StrOpcao = "2" Then
                    System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/index.php?destino=reportDiarioGeralExames.php&print=Biosifam&r=" & VarLocalIdResponsavelFinanceiro & "&form_consultorio=" & oMedicoConveniado.FazExameNoConsultorio & "&form_datai=" & Format(vdData, "yyyy-MM-dd") & "&form_dataf=" & Format(vdDataFim, "yyyy-MM-dd") & "&form_id_medico=" & System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(IdMedico)))
                End If
            End If
        Catch
        Finally
        End Try

    End Sub

    Private Sub btnValidaSenha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidaSenha.Click
        vbSenhaValidada = False
        If mskSenha.Text <> "" And toolTip1.GetToolTip(Me.btnGravar) = "Nova Senha" Then
            grpSenha.Visible = False
            grpSenha.Visible = True
            grpSenhaConfirmacao.Visible = True
            mskSenhaConfirmacao.Text = ""
            mskSenhaConfirmacao.Enabled = True
            mskSenhaConfirmacao.Focus()
        Else
            ' strModo -> 0=Retaguarda, 1=Consulta, 2=Consultório, 3-exames, 4-fisioterapeuta,5-pronto atendimento

            'se for menor vou ter de testar a senha informada em todos da matricula
            If _Pessoa.Menor12anos Then
                If _PG.Conectar() = False Then Exit Sub
                Dim dr As Npgsql.NpgsqlDataReader
                dr = _PG.DrQuery("SELECT senha, senha_data, id_pessoa, to_ascii(nome,'LATIN1') as nome FROM pessoas where matricula='" & txtMatricula.Text & "'")
                'pesquisa se alguma senha 'fecha'
                _Pessoa.SenhaDaPessoaNoBanco = ""
                _Pessoa.DataSenhaPessoa = Nothing

                If dr.HasRows Then
                    While dr.Read
                        _Pessoa.SenhaDaPessoaNoBanco = dr.Item(0)
                        If _Pessoa.SenhaDaPessoaNoBanco <> "" Then
                            If mskSenha.Text = _Pessoa.SenhaDaPessoaNoBanco Then
                                'If dr.Item(1).ToString <> "" Then
                                '    vsSenhaDaPessoa_Data = dr.Item(1).ToString
                                '    If Int(DateDiff("d", vsSenhaDaPessoa_Data, Date.Today)) > 180 Then
                                '        MsgBox("A senha do responsavel (" & dr.Item(3).ToString & ") expirou a mais de 180 dias (" & vsSenhaDaPessoa_Data & ") e precisa ser revalidada.")
                                '        If vnGlo_ModoAtual = "1" Then
                                '            MsgBox("A revalidação precisa ser realizada na PREVPEL.")
                                '        Else
                                '            MsgBox("A revalidação precisa ser feita no identificador do Responsável (" & dr.Item(3).ToString & ").")
                                '        End If
                                '        grpSenha.Visible = False
                                '        Exit Sub
                                '    End If
                                'Else
                                '    'atualiza data para forçar expiração da senha do ID responsavel
                                '    _PG.Execute("update pessoas set senha_data=current_date where id_pessoa=" & dr.Item(2).ToString)
                                'End If
                                grpSenha.Visible = False
                                vbSenhaValidada = True
                                Exit While
                            End If
                        End If
                    End While
                    _PG.Desconectar()
                    'nao localizou nenhuma senha
                    If vbSenhaValidada = False Then
                        MsgBox("A Senha informada não confere com nenhum dos presentes na Matricula !", vbOKOnly, "Validação Menores de 12 anos.")
                        mskSenha.Focus()
                        grpSenha.Visible = True
                        Exit Sub
                    End If
                End If
            End If

            If mskSenha.Text <> _Pessoa.SenhaDaPessoaNoBanco Then
                MsgBox("Senha informada não confere !")
                mskSenha.Focus()
                vbSenhaValidada = False
                grpSenha.Visible = False
                Exit Sub
            Else

                vbSenhaValidada = True
                grpSenha.Visible = False
                lblSenha.Visible = False

                Dim vsRetorno As String = ""

                If vnGlo_ModoAtual >= 2 Then
                    btnGravar.Enabled = True
                    vsRetorno = "clique em GRAVAR Atendimento."
                    If vnGlo_ModoAtual = 2 And cmbMedico.Items.Count > 1 Then vsRetorno = "Selecione o médico e " & vsRetorno
                    If vnGlo_ModoAtual = 3 Then vsRetorno = "Selecione os exames e " & vsRetorno
                    If vnGlo_ModoAtual = 4 Then vsRetorno = "Selecione o tipo de atendimento e " & vsRetorno
                End If

                If _Atendimento.IdAtendimentoPendente > 0 Then vsRetorno = "Complemente os servicos realizados e " & vsRetorno
                If toolTip1.GetToolTip(btnGravar) = "Revalidar Senha" Then
                    _PG.Execute("update pessoas set senha='" & mskSenha.Text & "', senha_data=current_date where id_pessoa=" & _Pessoa.Id)
                    MsgBox("Senha Revalidada com sucesso. " & Chr(13) & Chr(13) & vsRetorno, vbOKOnly, "ReValidação de Senha.")
                Else
                    MsgBox("Senha identificada com sucesso. " & Chr(13) & Chr(13) & vsRetorno, vbOKOnly, "Validação de Senha.")
                End If
                If vnGlo_ModoAtual <> 3 And btnGravar.Enabled Then btnGravar.Focus()
                If vnGlo_ModoAtual = 3 And TxtServico.Enabled Then TxtServico.Focus()
                If vnGlo_ModoAtual = 4 And cmbProcedimento.Enabled Then cmbProcedimento.Focus()

            End If
        End If

    End Sub

    Private Sub btnValidaSenhaConfirmacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidaSenhaConfirmacao.Click
        vbSenhaValidada = False
        If mskSenha.Text <> "" And toolTip1.GetToolTip(Me.btnGravar) = "Nova Senha" Then
            If mskSenha.Text <> mskSenhaConfirmacao.Text Then
                MsgBox("Senha informada difere da anterior !")
                grpSenha.Visible = True
                mskSenha.Text = ""
                mskSenha.Focus()
                grpSenhaConfirmacao.Visible = False
                Exit Sub
            End If
            If _PG.Conectar() = False Then Exit Sub
            _PG.Execute("begin")
            _PG.Execute("update pessoas set senha='" & mskSenha.Text & "', senha_data=current_date where id_pessoa=" & _Pessoa.Id)
            _PG.Execute("commit")
            If _PG.RetornoExecute Then
                _Pessoa.SenhaDaPessoaNoBanco = mskSenha.Text
                MsgBox("Nova senha atualizada com sucesso ! ")
            End If
            _PG.Desconectar()
        End If
        grpSenha.Visible = False
        grpSenhaConfirmacao.Visible = False
        vbSenhaValidada = True
    End Sub

    Private Sub DigitalParaUsuáriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DigitalParaUsuáriosToolStripMenuItem.Click
        ' desativei pois nao é usado e gerou confuso em daniela meggiato
        If BolLeitorBiometricoAtivado = False Then _toolsSiFam.FinalizeGrFinger() : _toolsSiFam = Nothing
        frmUsuario.Show()
    End Sub

    Private Sub MarcaçãoOFFLineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcaçãoOFFLineToolStripMenuItem.Click

        If vnGlo_ModoAtual < 2 Then
            MsgBox("O modo " & IIf(vnGlo_ModoAtual = "0", "RETAGUARDA", IIf(vnGlo_ModoAtual = "1", "CONSULTA", "EXAME")) & " não permite o uso do registro RPJ (Registro Posterior Justificado).")
            Exit Sub
        End If
        vdDataServidor = _PG.DataServidor
        'vdDataServidor = CDate("2022/01/01")

        If oMedicoConveniado.LiberaDigitacaoOffLine = False Then
            MsgBox("O prestador  " & oMedicoConveniado.Nome & " não tem autorizão para digitação de Registros Off Line. Para liberação entre em contato com a PREVPEL. ")
            Exit Sub
        End If
        vsJustificativa = InputBox("Informe uma justificativa para esses registros sem a identificação biométrica.")
        If Trim(vsJustificativa) = "" Then MsgBox("Obrigatório informar uma justificativa") : GoTo Sair
        If vsJustificativa.ToString.Length < 9 Then MsgBox("A Justificativa precisa ter no mínimo 10 caracteres.") : GoTo Sair
        If vsJustificativa.ToString.Length > 100 Then MsgBox("Informe no máximo 100 caracteres.") : GoTo Sair

        vbModoOFFLine = True
        vbModoRPJ = True
        grpSenha.Visible = False
        lblSenha.Visible = False
        lblSituacao.Text = ""
        btnGravar.Enabled = True
        MsgBox("Para concluir o registro, se houver algum procedimento selecione-o, a seguir clique em SALVAR Atendimento.")

        If oMedicoConveniado.Modo = "4" Then
            MsgBox("Atenção, ao inserir atendimentos no MODO RPJ-Registro Posterior Justificado, o atendimento não ficará pendente, portanto, informe consulta e procedimentos extras juntos.")
        End If

        If vbModoOFFLine Then Me.BackColor = Color.Yellow Else Me.BackColor = Color.White
        Exit Sub
Sair:
        vbModoOFFLine = False
        vbModoRPJ = False
        btnGravar.Enabled = False
    End Sub

    Private Sub EstatísticoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstatísticoToolStripMenuItem.Click
        formEstatistica.ShowDialog()
    End Sub

    Private Sub SuporteRemotoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuporteRemotoToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath & "\TeamViewer_Setup_pt.exe")
            'System.Diagnostics.Process.Start("\\fs01\coinpel\Desenv\Projetos .NET\biosifam\loader\bin\TeamViewer_Setup_pt.exe")

        Catch ex As Exception
            If MsgBox("O aplicativo TeamViewer de acesso remoto não foi localizado, deseja localiza-lo no site oficial do aplicativo ?", vbYesNo, "") = vbYes Then
                System.Diagnostics.Process.Start("https://www.teamviewer.com/pt/index.aspx")
            End If
        End Try
    End Sub

    Private Sub AjudaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBrowser.WebBrowser1.Navigate("http://downloads.pelotas.com.br/biosifam/help/biosifam_uso.html")
        frmBrowser.Text = "Help Biosifam"
        frmBrowser.Show()
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("http://www.pelotas.com.br")
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        System.Diagnostics.Process.Start("http://www.pelotas.com.br/coinpel")
    End Sub
    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.Cursor = Cursors.Hand
    End Sub
    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Cursor = Cursors.Default
    End Sub
    Private Sub PictureBox2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseHover
        PictureBox2.Cursor = Cursors.Hand
    End Sub
    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Cursor = Cursors.Default
    End Sub

    Private Sub AtualizarÚltimaVersãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtualizarÚltimaVersãoToolStripMenuItem.Click
        oUpdate.VerificaAtualizacoes()
        'oUpdate.VerificaNovaVersão(True, _u.IdPrestador)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        'System.Diagnostics.Process.Start("http://downloads.pelotas.com.br/biosifam/help/HistoricoVersoesBiosifam.html")
        frmBrowser.WebBrowser1.Navigate("http://downloads.pelotas.com.br/biosifam/help/HistoricoVersoesBiosifam.html")
        frmBrowser.Text = "Histórico de Atualizações Biosifam"
        frmBrowser.Show()
    End Sub

    Private Sub GroupBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox1.MouseLeave
        PictureBox3.Cursor = Cursors.Default
    End Sub
    Private Sub PictureBox3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        PictureBox3.Cursor = Cursors.Hand
    End Sub
    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        PictureBox3.Cursor = Cursors.Default
    End Sub

    Private Sub GroupBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox1.DoubleClick
        'frmBrowser.WebBrowser1.Navigate("http:\\server.pelotas.com.br\xxx\sifam\foto_pessoa.php?id_pessoa=" & vnGlo_idPaciente, False)
        frmBrowser.WebBrowser1.Navigate("http:\\sifam.pelotas.com.br\index.php?destino=foto_pessoa.php&id_pessoa=" & _Pessoa.Id, False)
        frmBrowser.Text = "Help Biosifam"
        frmBrowser.Show()
    End Sub

    Private Sub GroupBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox1.MouseHover
        PictureBox3.Cursor = Cursors.Hand
    End Sub

    Private Sub frmMain_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        vnPosicaoMouse = MousePosition.X
    End Sub

    Private Sub frmMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        vnPosicaoMouse = MousePosition.X
    End Sub

    Private Function PegaPeriodoFisioterapia() As String
        PegaPeriodoFisioterapia = ""
        vsRetorno = ""
        vsRetorno = InputBox("Informe uma data ou intervalo para pesquisar os exames (dd/mm/yyyy ou dd/mm/yyyy-dd/mm/yyyy): ", "Relatório de Sessões Realizadas", Format(Date.Today, "dd/MM/yyyy"))
        If InStr(vsRetorno, "-") > 0 Then
            vdData = CDate(vsRetorno.Substring(0, 10))
            vdDataFim = CDate(vsRetorno.Substring(11, 10))
            vsFiltro = " fisioterapia_sessoes.dt_alteracao >='" & Format(vdData, "yyyy/MM/dd") & "' and fisioterapia_sessoes.dt_alteracao <= '" & Format(vdDataFim, "yyyy/MM/dd") & "'"
        Else
            If IsDate(vsRetorno) = False Then MsgBox("Data inválida ") : Exit Function
            vdData = CDate(vsRetorno)
            vdDataFim = vbNullString
            vsFiltro = " fisioterapia_sessoes.dt_alteracao='" & Format(vdData, "yyyy/MM/dd") & "'"
        End If
        PegaPeriodoFisioterapia = vsRetorno

    End Function

    Private Sub cmbMedico_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMedico.DropDownClosed
        'idMedico = LocalizaIdMedico()
        vbSelecionouMedico = True
    End Sub

    Private Sub cmbMedico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMedico.SelectedIndexChanged

        If vnGlo_ModoAtual <> 0 And cmbMedico.SelectedIndex = -1 Then cmbMedico.SelectedIndex = 0
        If cmbMedico.SelectedIndex = -1 Then Exit Sub

        IdMedico = CType(cmbMedico.SelectedItem, ComboData).Id
        oMedicoConveniado = New ClsMedico(IdMedico)

        If BolCorrecao Then Exit Sub

        ConfiguraConveniado()
        MontaGraficoAtendimentos()
        'LimpaNovoAtendimento()

    End Sub

    Public Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        _Atendimento.ImprimirRecibo(e, drServicos, StrVesaoApp)
    End Sub


    Private Sub btnExcluir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click

        If vnGlo_ModoAtual <> 0 Or BolCorrecao Then
            If BolCorrecao Then
                _Atendimento.CancelarAtendimento(frmLogin.TxtUsuario.Text, IdAtendimentoCorrecao)
            Else
                _Atendimento.CancelarAtendimento(frmLogin.TxtUsuario.Text, 0)
            End If
            LimpaNovoAtendimento()
        Else
            ' Modo = 0 = retaguarda - botao serve para excluir senha ou digital
            If _Pessoa.Id = 0 Then
                MsgBox("Informe um paciente.", MsgBoxStyle.Information, "Impossível proceder com a exclusão.")
                Exit Sub
            End If
            If vbValidaPorDigital = False Then
                If MsgBox("Deseja realmente excluir a senha deste paciente ?", MsgBoxStyle.YesNo, "Confirme a operação de exclusão.") = vbYes Then
                    If _PG.Conectar() = False Then Exit Sub
                    _PG.Execute("update pessoas set senha='' where id_pessoa=" & _Pessoa.Id)
                    _PG.Desconectar()
                    btnMatricula.Focus()
                End If
            Else
                If MsgBox("Deseja realmente excluir as digitais deste Contribuinte ?", MsgBoxStyle.YesNo, "Confirme a operação de exclusão.") = vbYes Then
                    If _PG.Conectar() = False Then Exit Sub
                    _PG.Execute("delete from digital where id_pessoa=" & _Pessoa.Id)
                    _PG.Desconectar()
                    CarregaDadosPaciente(_Pessoa.Id)
                    grdIdentifica.DataSource = Nothing
                End If
            End If
        End If

    End Sub



    Private Sub RegistroDePacotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroDePacotesToolStripMenuItem.Click
        On Error GoTo erro
        ' REGISTRO DE PACOTES
        vnModeloRelatorio = 4

        vsRetorno = ""
        vsRetorno = InputBox("Informe uma data ou intervalo para pesquisar as autorizaçõess (dd/mm/yyyy ou dd/mm/yyyy-dd/mm/yyyy): ", "Registro de Autorizações", Format(Date.Today, "dd/MM/yyyy"))
        If InStr(vsRetorno, "-") > 0 Then
            vdData = CDate(vsRetorno.Substring(0, 10))
            vdDataFim = CDate(vsRetorno.Substring(11, 10))
            vsFiltro = " au.data >='" & Format(vdData, "yyyy/MM/dd") & "' and au.data <= '" & Format(vdDataFim, "yyyy/MM/dd") & "'"
        Else
            If IsDate(vsRetorno) = False Then MsgBox("Data inválida ") : Exit Sub
            vdData = CDate(vsRetorno)
            'vdDataFim = vbNullString
            vsFiltro = " au.data='" & Format(vdData, "yyyy/MM/dd") & "'"
        End If

        ' vsModo -> 0=Retaguarda, 1=Consulta, 2=Consultório, 3-Exames, 4-Fisioterapia
        vsFiltroTexto = "Fisioterapeuta: " & cmbMedico.Text & ", autorizações em " & vsRetorno
        If RegistroPacotes(IdMedico, txtMatricula.Text, vsFiltro, vsFiltroTexto) = False Then Exit Sub
        System.Diagnostics.Process.Start(System.IO.Path.GetTempPath() & "RegistroAutorizacoes.htm")

erro:
    End Sub

    Private Sub ResumoDePacotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumoDePacotesToolStripMenuItem.Click
        ' RESUMO DE PACOTES
        On Error GoTo erro
        vnModeloRelatorio = 5

        vsRetorno = ""
        vsRetorno = InputBox("Informe uma data ou intervalo para pesquisar as autorizações (dd/mm/yyyy ou dd/mm/yyyy-dd/mm/yyyy): ", "Resumo de Autorizações", Format(Date.Today, "dd/MM/yyyy"))
        If InStr(vsRetorno, "-") > 0 Then
            vdData = CDate(vsRetorno.Substring(0, 10))
            vdDataFim = CDate(vsRetorno.Substring(11, 10))
            vsFiltro = " au.data >='" & Format(vdData, "yyyy/MM/dd") & "' and au.data <= '" & Format(vdDataFim, "yyyy/MM/dd") & "'"
        Else
            If IsDate(vsRetorno) = False Then MsgBox("Data inválida ") : Exit Sub
            vdData = CDate(vsRetorno)
            'vdDataFim = vbNullString
            vsFiltro = " au.data='" & Format(vdData, "yyyy/MM/dd") & "'"
        End If

        ' vsModo -> 0=Retaguarda, 1=Consulta, 2=Consultório, 3-Exames, 4-Fisioterapia
        vsFiltroTexto = "Fisioterapeuta: " & cmbMedico.Text & ", autorizações em " & vsRetorno
        If ResumoPacotes(IdMedico, txtMatricula.Text, vsFiltro, vsFiltroTexto) = False Then Exit Sub

        System.Diagnostics.Process.Start(System.IO.Path.GetTempPath() & "ResumoAutorizacoes.htm")
        Exit Sub
erro:
        MsgBox("Ops..., erro inesperado")

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If oMedicoConveniado.Endereco = "" Then
            MsgBox("Endereço não disponível")
            Exit Sub
        End If
        System.Diagnostics.Process.Start("http://maps.google.com/maps?q=Pelotas,+RS+," & "+," & oMedicoConveniado.Endereco)
    End Sub

    Private Sub CorreçõesEmProcedimentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorreçõesEmProcedimentosToolStripMenuItem.Click
        frmCorreções.Show()
        frmCorreções.txtId.Focus()
    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If vbEncerrar Then
            _PG.Desconectar()
            End
        End If
        If _u.IdPrestador > 0 Then
            If oMedicoConveniado Is Nothing Then Exit Sub
            If oMedicoConveniado.Expirar > 0 Then
                Dim vdTempoFinal As DateTime = Now
                vtTempoConexao = vdTempoFinal.Subtract(vdInicioConexao)
                Dim vnPosicaoMouseAgora As Long = MousePosition.X
                If vtTempoConexao.TotalMinutes > oMedicoConveniado.Expirar And vnPosicaoMouse = vnPosicaoMouseAgora Then
                    Me.Timer1.Interval = 100000 '1000=1s
                    vbEncerrar = True
                    If _PG.Conectar() = False Then Exit Sub
                    _util.Log_Gravar("biosifam_encerrar", "Aplicação encerrada automaticamente", False, vtTempoConexao.TotalSeconds.ToString("0.00") & "s", IdMedico)
                    _PG.Desconectar()
                    If MsgBox("O aplicativo está sem atividade a " & vtTempoConexao.TotalMinutes.ToString("0.00") & "min. e irá se encerrar automaticamente em aproximadamente 60s, deseja abortar a finalização ? ", vbYesNo, "Auto Encerramento Ativado") = vbYes Then
                        If _PG.Conectar() = False Then Exit Sub
                        _util.Log_Gravar("biosifam_encerrar1", "Encerramento automatico cancelado", False, vtTempoConexao.TotalSeconds.ToString("0.00") & "s", IdMedico)
                        _PG.Desconectar()
                        vbEncerrar = False
                        Me.Timer1.Interval = 10000 'tempo de 10 segundos
                    End If
                End If
            End If
        End If
        vdTempoVerificacaoF = Now
        vtTempoConexao = vdTempoVerificacaoF.Subtract(vdTempoVerificacaoI)
        If vtTempoConexao.TotalMinutes > 1 Then
            Timer1.Enabled = False
            _s.Controle_Manager("")
            Timer1.Enabled = True
            vdTempoVerificacaoI = Now
        End If

    End Sub

    Private Sub MontaGraficoAtendimentos()

        'If vnGlo_ModoAtual <> "2" And vnGlo_ModoAtual <> "4" Then Exit Sub

        ' grafico de linha ' -------------------------------------------------------------------------------------------------------

        Dim yAtendimentos() As Integer 'define os valores do eixo y - milhoes de pessoas
        Dim xAtendentes() As String   'define os valoes do eixo x - nome dos paises

        Dim vsDataFim As String = Year(Now) & "-" & cmbMesGrafico.SelectedIndex + 1 & "-01"
        Dim vsDataInicio As String = Year(Now) & "-" & cmbMesGrafico.SelectedIndex + 1 & "-01"

        If CDate(vsDataInicio) < "2021-06-01" Then
            MsgBox("Para evitar degradação da performance do banco de dados, datas anteriores à jun/2021 não pode ser visualizadas.")
            cmbMesGrafico.SelectedIndex = Month(Now) - 1
            Exit Sub
        End If

        Dim Func_Ultimo_Dia_Mes As Date
        Func_Ultimo_Dia_Mes = DateAdd("m", 1, DateSerial(Year(vsDataFim), Month(vsDataFim), 1))
        Func_Ultimo_Dia_Mes = DateAdd("d", -1, Func_Ultimo_Dia_Mes)
        vsDataFim = Format(Func_Ultimo_Dia_Mes, "yyyy/MM/dd")

        ' pesquisa guiche selecionado pelo usuário no login-- usa indice data
        Dim i As Long = 0
        Dim ds As DataSet
        ds = _PG.DsQuery("SELECT count(id_atendimento), dt_alteracao FROM atendimento " &
             " WHERE situacao<>'C' and situacao<>'G' and situacao<>'P' and dt_alteracao between '" & vsDataInicio & "' and '" & vsDataFim & "' and id_medico=" & IdMedico & " group by dt_alteracao order by dt_alteracao ")
        If ds Is Nothing Then Exit Sub
        Dim vnMaximo As Long = 0
        txtTotalAtendimentosGrafico.Text = "0"
        If ds.Tables(0).Rows.Count > 0 Then
            'Redim Preserve Arr(12) as Integer
            ReDim Preserve yAtendimentos(ds.Tables(0).Rows.Count - 1)
            ReDim Preserve xAtendentes(ds.Tables(0).Rows.Count - 1)

            For i = 0 To ds.Tables(0).Rows.Count - 1
                yAtendimentos(i) = "" & ds.Tables(0).Rows(i).Item(0).ToString
                txtTotalAtendimentosGrafico.Text = Val(txtTotalAtendimentosGrafico.Text) + yAtendimentos(i)
                If ds.Tables(0).Rows(i).Item(1).ToString.Length > 0 Then
                    xAtendentes(i) = "" & ds.Tables(0).Rows(i).Item(1).ToString.Substring(0, 2)
                Else
                    xAtendentes(i) = ""
                End If
                If vnMaximo <= yAtendimentos(i) Then vnMaximo = yAtendimentos(i)
            Next
        Else
            ReDim Preserve yAtendimentos(0)
            ReDim Preserve xAtendentes(0)
            panGrafico.Visible = False
            Exit Sub
        End If

        vnMaximo = vnMaximo + (vnMaximo * 20 / 100)

        With Chart1
            'define o tipo de gráfico
            .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
            '.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column

            'define o texto da legenda 
            .Series(0).LegendText = ""  'Atendentes
            .ChartAreas(0).Area3DStyle.LightStyle = LightStyle.Simplistic
            .Series(0).IsVisibleInLegend = False

            'define o titulo do eixo y , sua fonte e a cor
            .ChartAreas(0).AxisY.Title = "Atendimentos"   'Atendimentos
            .ChartAreas(0).AxisY.TitleFont = New Font("Times New Roman", 9, FontStyle.Bold)
            .ChartAreas(0).AxisY.TitleForeColor = Color.Blue
            .ChartAreas(0).AxisY.Maximum = vnMaximo

            'define o titulo do eixo x , sua fonte e a cor
            .ChartAreas(0).AxisX.Title = "Dia"
            .ChartAreas(0).AxisX.TitleFont = New Font("Times New Roman", 9, FontStyle.Bold)
            .ChartAreas(0).AxisX.TitleForeColor = Color.Blue
            .ChartAreas(0).AxisX.Interval = 2

            'define a paleta de cores usada
            .Palette = ChartColorPalette.Berry

            'vincula os dados ao gráfico
            .Series(0).Points.DataBindXY(xAtendentes, yAtendimentos)

            'exibe os valores nos eixos
            .Series(0).IsValueShownAsLabel = True

            'desabilita a exibição 3D
            .ChartAreas(0).Area3DStyle.Enable3D = False

        End With
        panGrafico.Visible = True
        panGrafico.Location = New System.Drawing.Point(16, 144)
    End Sub

    Private Sub btnConsultarSessoes_Click(sender As Object, e As EventArgs) Handles btnConsultarSessoes.Click
        If IdMedico = 0 Then
            MsgBox("Selecione um médico ")
            cmbMedico.Focus()
            Exit Sub
        End If
        If RelatorioFisioterapiasRealizadasPaciente(_Pessoa.Id, IdMedico, cmbMedico.SelectedItem.ToString, txtMatricula.Text, vsFiltro, vsFiltroTexto) Then
            frmBrowser.WebBrowser1.Navigate(System.IO.Path.GetTempPath() & "FisioterapiaPaciente.htm")
            frmBrowser.Text = "Biosifam Fisioterapias"
            frmBrowser.Show()
            'System.Diagnostics.Process.Start(System.IO.Path.GetTempPath() & "FisioterapiaPaciente.htm")
        End If

    End Sub

    Private Sub AutorizaçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizaçõesToolStripMenuItem.Click
        frmAutorizações.Show()
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        EncerrarAplicacao()
    End Sub
    Private Sub EncerrarAplicacao()
        Try
            If BolLeitorBiometricoAtivado Then _toolsSiFam.FinalizeGrFinger()
            _PG.Desconectar()
            Application.Exit()
        Catch
        End Try
        End
    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal EventArgs As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim KeyCode As Short = EventArgs.KeyCode
        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Return Then System.Windows.Forms.SendKeys.Send("{TAB}") ' + é{tab} o shit
    End Sub

    Private Sub SobreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SobreToolStripMenuItem.Click
        frmAjuda.Show()
    End Sub

    Private Sub btnNaoCompareceu_Click(sender As Object, e As EventArgs) Handles btnNaoCompareceu.Click
        ' 2-medico, 4-fisioterapia
        If oMedicoConveniado.Modo <> "2" Then
            MsgBox("Acesso Negado. Somente consultórios médico/odontológicos e Fisioterapeutas podem utilizar. Modo ativo : " & _w.Modo, vbOKOnly, "Registro de Não Comparecimento")
            Exit Sub
        End If
        If cmbMedico.Text = "" Then MsgBox("Selecione um prestador", MsgBoxStyle.Information, "Impossível prosseguir.") : Exit Sub
        If txtMatricula.Text = "" Then MsgBox("Informe uma matricula !", vbOKOnly, "Registro de Não Comparecimento") : Exit Sub

        _Atendimento.IdResponsavelFinanceiro = idResponsavelFinanceiro
        _Atendimento.GravarNaoComparecido(_Pessoa, oMedicoConveniado)
        LimpaNovoAtendimento()

    End Sub

    Private Sub cmbMesGrafico_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbMesGrafico.SelectedIndexChanged
        MontaGraficoAtendimentos()
    End Sub

    Private Sub grdContribuintes_KeyDown(ByVal sender As Object, ByVal EventArgs As System.Windows.Forms.KeyEventArgs) Handles grdContribuintes.KeyDown
        Dim KeyCode As Short = EventArgs.KeyCode
        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Return Then
            CarregaDadosPaciente(grdContribuintes.CurrentRow.Cells(0).Value())
        End If
    End Sub

    Private Sub picSMS_Click(sender As Object, e As EventArgs) Handles picSMS.Click
        ChamaSMS()
    End Sub
    Private Function ChamaSMS() As Boolean
        ChamaSMS = False
        vbModoSMS = False
        If _Autorizacao.AutorizarViaSMS(_Pessoa, _Pessoa.Celular, vbModoBNI) Then
            btnGravar.Enabled = True
            lblSenha.Visible = False
            grpSenha.Visible = False
            vbModoSMS = True   ' libera registrar via SMS
            btnGravar.Focus()
        Else
            If oMedicoConveniado.Modo = 4 Then
                Dim IntContaTentativas As Integer = 0
                If MsgBox("Todas tentativas de registro identificado não obtiveram êxito, deseja prosseguir com a SENHA GERENCIAL ?", vbYesNo, "") = vbYes Then
                    GrpSenhaGerencial.Visible = True
                    MskSenhaGerencial.Focus()
                End If
            End If
        End If
    End Function
    Private Sub GrdResponsavel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewResponsavel.CellDoubleClick
        CarregaDadosResponsavel()
    End Sub
    Private Sub GrdResponsavel_KeyDown(sender As Object, e As KeyEventArgs) Handles ViewResponsavel.KeyDown
        Dim KeyCode As Short = e.KeyCode
        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Return Then
            CarregaDadosResponsavel()
        End If
    End Sub
    Private Sub GrdResponsavel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewResponsavel.CellContentClick
        CarregaDadosResponsavel()
    End Sub


    Private Sub CarregaDadosResponsavel()
        IdResponsavelConsulta = ViewResponsavel.CurrentRow.Cells(0).Value()
        GrpResponsavel.Visible = False
        If ViewResponsavel.CurrentRow.Cells(2).Value() = "S" Then
            vbResponsavelUsaDigital = False
            ' pessoa menor passa a carregar a senha do pai seleiconado 
            _Pessoa.SenhaDaPessoaNoBanco = ViewResponsavel.CurrentRow.Cells(3).Value
            _Pessoa.DataSenhaPessoa = ViewResponsavel.CurrentRow.Cells(4).Value
            _Pessoa.Celular = ViewResponsavel.CurrentRow.Cells(5).Value
            ' ja vem com dados do menor , só precisa da senha dos pais
            LiberaAtendimento(IdResponsavelConsulta)
            mskSenha.Focus()

        Else
            vbResponsavelUsaDigital = True
            ' utiliza biosifam por senha
            MsgBox("O responsável selecionado utiliza biometria, o sistema ficará aguardando a entrada da digital.")
            _toolsSiFam.InitializeGrFinger()
        End If

    End Sub

    Private Sub txtMatricula_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMatricula.KeyDown
        Dim KeyCode As Short = e.KeyCode
        ' teclou ENTER põe o foco no próximo controle 

        If KeyCode = System.Windows.Forms.Keys.Return Then
            If txtMatricula.Text <> "" Then
                InicializaBotoes()
                Call CarregaMatricula()
                grdContribuintes.Focus()
                'System.Windows.Forms.SendKeys.Send("{TAB}") ' + é{tab} o shit                
            End If
        End If
        If KeyCode = System.Windows.Forms.Keys.F2 Then
            If txtMatricula.Text <> "" And _u.Login = "andre.krolow" Then
                vbModoBNI = True
                GrpSenhaGerencial.Visible = True
                MskSenhaGerencial.Focus()
            End If
        End If
    End Sub

    Private Sub picLogin_DoubleClick(sender As Object, e As EventArgs) Handles picLogin.DoubleClick
        _PG.Desconectar()
        frmLogin.Show()

    End Sub

    Private Sub picLogin_MouseHover(sender As Object, e As EventArgs) Handles picLogin.MouseHover
        picLogin.Cursor = Cursors.Hand
    End Sub

    Private Sub picLogin_MouseLeave(sender As Object, e As EventArgs) Handles picLogin.MouseLeave
        picLogin.Cursor = Cursors.Default
    End Sub

    Private Sub PicBuscarArquivo_Click(sender As Object, e As EventArgs) Handles PicBuscarArquivo.Click
        txtArquivoDespesas.Enabled = True

        If txtArquivoDespesas.Text.Length < 10 And IsNumeric(txtArquivoDespesas.Text) Then
            Autorizacao(txtArquivoDespesas)
            Exit Sub
        End If

        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "Selecione o arquivo para enviar à PREVPEL"
        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) ' "C:\"
        fd.Filter = "PDF/JPG/JPEG files (*.pdf,*.jpg, *.jpeg)|*.pdf;*.jpg;*.jpeg"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then txtArquivoDespesas.Text = fd.FileName
        If txtArquivoDespesas.Text = "" Then Exit Sub
        If UCase(txtArquivoDespesas.Text.Substring(txtArquivoDespesas.Text.Length - 3, 3)) <> "PDF" And
UCase(txtArquivoDespesas.Text.Substring(txtArquivoDespesas.Text.Length - 3, 3)) <> "JPG" And
UCase(txtArquivoDespesas.Text.Substring(txtArquivoDespesas.Text.Length - 4, 4)) <> "JPEG" Then
            MsgBox("Documento anexado deve ser tipo PDF ou JPEG ou JPG.")
            txtArquivoDespesas.Text = ""
        End If
        'frmBrowser.WebBrowser1.Navigate("http://sifam.pelotas.com.br/index.php?destino=upload_despesa&atendimento=" & _Atendimento.IdAtendimento & "&prestador=" & System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(oMedicoConveniado.Id)) & "&documento=" & txtArquivo.Text)
        'frmBrowser.Text = "UpLoad Biosifam"
        'frmBrowser.Show()

        'System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/index.php?destino=upload_despesa&atendimento=" & _Atendimento.IdAtendimento & "&prestador=" & System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(oMedicoConveniado.Id)) & "&documento=" & txtArquivo.Text)

    End Sub


    Private Sub picVerDocumentoEnviado_Click(sender As Object, e As EventArgs)
        System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/docs/" & txtMatricula.Text & "_")
    End Sub


    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        LimpaNovoAtendimento()
    End Sub

    Private Sub EspelhoDeNFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EspelhoDeNFToolStripMenuItem.Click
        Dim _Data As New ClsData

        Try

            Dim DatDataServidor As Date = _PG.DataServidor()
            ' Primeiro dia do mes
            Dim DatQuintoDiaUtil As Date = CDate(_Data.QuintoDiaUtil(CDate(DatDataServidor.Year & "/" & DatDataServidor.Month & "/01")))
            Dim StrPeriodo As String = Format(Date.Today.AddMonths(-1), "MM/yyyy")
            If DatDataServidor > DatQuintoDiaUtil Then StrPeriodo = Format(Date.Today, "MM/yyyy")

            vsRetorno = InputBox("Informe o período (mm/yyyy): ", "Relatório de Atendimentos Realizados", StrPeriodo)
            If vsRetorno.Substring(2, 1) <> "/" Then
                MsgBox("Formato inválido informe MM/AAAA")
                cmbMedico.Focus()
                Exit Sub
            End If
            If vsRetorno.Substring(3, 4) < "2021" Then
                MsgBox("Ano inválido, informe ano maior que 2021!")
                cmbMedico.Focus()
                Exit Sub
            End If
            If vsRetorno.Substring(0, 2) > 12 Then
                MsgBox("Mês inválido!")
                cmbMedico.Focus()
                Exit Sub
            End If
            If vsRetorno.Substring(0, 2) = 0 Then
                MsgBox("Mês inválido!")
                cmbMedico.Focus()
                Exit Sub
            End If
            vdData = CDate("01/" & vsRetorno)
            vdDataFim = CDate(_Data.ÚltimoDiadoMês(vsRetorno.Substring(0, 2)) & "/" & vsRetorno)

            If vsRetorno = "" Then Exit Sub

            ' vsModo -> 0=Retaguarda, 1=Consulta, 2=Consultório, 3-Exames, 4-Fisioterapia, 5-pronto atendimento
            If IdMedico = 0 Then
                MsgBox("Nenhum médico foi informado, por favor selecione um médico.")
                cmbMedico.Focus()
                Exit Sub
            End If
            If idResponsavelFinanceiro > 0 Then
                System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/php/relatorioProcedimentosPrestador.php?print=Biosifam&idmedico=" & System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(oMedicoConveniado.Id)) & "&datai=" & Format(vdData, "yyyy-MM-dd") & "&dataf=" & Format(vdDataFim, "yyyy-MM-dd") & "&idresponsavel=" & System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(idResponsavelFinanceiro)))
            Else
                System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/php/relatorioProcedimentosPrestador.php?print=Biosifam&idmedico=" & System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(oMedicoConveniado.Id)) & "&datai=" & Format(vdData, "yyyy-MM-dd") & "&dataf=" & Format(vdDataFim, "yyyy-MM-dd"))
            End If
        Catch
        Finally
        End Try

    End Sub

    Private Sub WebSitePREVPELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebSitePREVPELToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://www.pelotas.com.br/servicos/prevpel/")

    End Sub

    Private Sub UploadPlanilhasFechamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadPlanilhasFechamentoToolStripMenuItem.Click
        FrmUpload.Show()
        Exit Sub
    End Sub

    Private Sub LimpaNovoAtendimento()
        ' inicializa controles do relatório ============================================
        vsFiltro = "" : vsRetorno = "" : vsFiltroTexto = ""
        lblPessoa.Text = ""
        InicializaBotoes()
        txtMatricula.Text = ""
        txtMatricula.Enabled = True
        txtCPF.Text = ""
        lblSituacao.Text = ""
        mskSenha.Text = ""
        GrpResponsavel.Visible = False

        Me.BackColor = Color.White
        GrpUpload.Visible = False
        txtArquivoDespesas.Text = ""

        vnContaDigitalNaoIdentificada = 0
        vnContaDigitalNaoLocalizada = 0
        vnContaDigitalRuim = 0

        _Pessoa.Inicializar()
        txtMatricula.Focus()
        TipoAutorizacaoRemota = ""
        IdAutorizacaoRemota = 0
        txtArquivoDespesas.Enabled = True

        chkRegistraSomenteExames.Checked = False
        IntContaTentativasSenhaGerencial = 0
        lblDataAtendimento.Visible = False
        IdAtendimentoCorrecao = 0
        StrJustificativaCorrecao = ""

        MskValorServico.Text = ""
        TxtServico.Text = ""

        If vnGlo_ModoAtual = 0 Then
            cmbMedico.SelectedIndex = -1
        Else
            If BolCorrecao Then ConfiguraConveniado()
        End If
        BolCorrecao = False

    End Sub

    Private Sub AjustesEspeciaisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjustesEspeciaisToolStripMenuItem.Click
        If _u.vbUsuarioSuporte = False Then
            MsgBox("Você não tem acesso a este formulário.")
            Exit Sub
        End If
        Dim drMax As Npgsql.NpgsqlDataReader
        Dim drMovimento As Npgsql.NpgsqlDataReader
        Dim vsCodigodoAjuste As String = InputBox("Informe o código da Rotina que deseja executar:")
        Dim idAutorizacaoFisioterapia As Long
        If vsCodigodoAjuste = "r08062021" Then
            If MsgBox("Rotina de atualização de Movimento de Fisioterapias, prosseguir ?", vbYesNo) = vbNo Then Exit Sub
            If _PG.Conectar() = False Then End
            drMovimento = _PG.DrQuery("select * from fisioterapia_sessoes where id_medicos=453 and dt_alteracao>='2021-06-01' and dt_realizada <= '2021-05-31'")
            Dim vsHora As String
            If drMovimento.HasRows Then
                _PG.Execute("begin")
                While drMovimento.Read

                    drGeneric = _PG.DrQuery("SELECT id_atendimento_autorizacao, codigo_procedimento, sessoes_autorizadas,sessoes_realizadas FROM atendimento_autorizacao WHERE sessoes_realizadas < sessoes_autorizadas and id_pessoa=" & drMovimento.Item("id_requisitante"))
                    If drGeneric.HasRows Then
                        drGeneric.Read()
                        idAutorizacaoFisioterapia = drGeneric.Item("id_atendimento_autorizacao")
                    End If
                    If IsDBNull(drMovimento.Item("hr_realizada")) = False Then
                        vsHora = Trim(drMovimento.Item("hr_realizada"))
                    Else
                        vsHora = ""
                    End If

                    _PG.Execute("INSERT INTO atendimento (id_pessoa, id_medico, id_juridica, tipo_servico, situacao, valor, data_pagamento, excedente, biosifam, login, ip, dt_alteracao, hr_alteracao, autorizacao) " &
                      " VALUES ( " & drMovimento.Item("id_requisitante") & ", 453, 0, 'CF','A',21.22, null, 'N', '" & IIf(vsHora = "", 2, 1) & "','" & drMovimento.Item("login") & "', '" & drMovimento.Item("ip") &
                      "', '" & Format(drMovimento.Item("dt_realizada"), "yyyy/MM/dd") & "','" & vsHora & "'," & idAutorizacaoFisioterapia & ") RETURNING id_atendimento;")
                    drMax = _PG.DrQuery("select lastval()")
                    If drMax.HasRows Then
                        drMax.Read()
                        Dim idAtendimento As Integer
                        idAtendimento = drMax.Item(0)
                        _PG.Execute("INSERT INTO atendimento_servico (id_atendimento, id_servico, valor, valor_prestador, valor_contribuinte) values (" &
                                            idAtendimento & ",'16981', 21.22,21.22, 10.61);")
                    End If

                End While
                _PG.Execute("commit")
                _PG.Desconectar()
                MsgBox("Ajuste Encerrado com sucesso.")
            Else
                MsgBox("Nenhum dado foi localizado.")
            End If

        ElseIf vsCodigodoAjuste = "atualizasessoesrealizadas" Then
            If MsgBox("Rotina de atualização de Sessões Realizadas, prosseguir ?", vbYesNo) = vbNo Then Exit Sub
            If _PG.Conectar() = False Then End
            drMovimento = _PG.DrQuery("select count(*), autorizacao from atendimento where tipo_servico='CF' and dt_alteracao>='2021-06-01' group by autorizacao")
            If drMovimento.HasRows Then
                _PG.Execute("begin")
                While drMovimento.Read
                    _PG.Execute("update atendimento_autorizacao set sessoes_realizadas=" & drMovimento.Item(0) & " where id_atendimento_autorizacao=" & drMovimento.Item(1))
                End While
                _PG.Execute("commit")
            Else
                MsgBox("Nenhum dado foi localizado.")
            End If

        ElseIf vsCodigodoAjuste = "atualizaautorizacoes" Then
            If MsgBox("Rotina de atualização de Autorizacoes, prosseguir ?", vbYesNo) = vbNo Then Exit Sub
            If _PG.Conectar() = False Then End
            drMovimento = _PG.DrQuery("Select aa.id_atendimento_autorizacao, a.id_atendimento from atendimento a inner join atendimento_autorizacao aa Using( id_pessoa ) where tipo_servico='CF' and autorizacao=0 and a.dt_alteracao>='2021-05-01'")
            If drMovimento.HasRows Then
                _PG.Execute("begin")
                While drMovimento.Read
                    _PG.Execute("update atendimento set autorizacao=" & drMovimento.Item(0) & " where id_atendimento=" & drMovimento.Item(1))
                End While
                _PG.Execute("commit")
            Else
                MsgBox("Nenhum dado foi localizado.")
            End If

        Else
            If vsCodigodoAjuste <> "" Then MsgBox("Código da rotina não localizada.")
        End If

    End Sub

    Private Sub InicializaBotaoGravar()
        If vnGlo_ModoAtual = 0 Then
            toolTip1.SetToolTip(Me.btnGravar, "Gravar Biometria")
        ElseIf vnGlo_ModoAtual = 1 Then
            toolTip1.SetToolTip(Me.btnGravar, "Gravar")
        ElseIf oMedicoConveniado.Modo = "3" Then
            toolTip1.SetToolTip(Me.btnGravar, "Gravar EXAME")
        Else
            toolTip1.SetToolTip(Me.btnGravar, "Gravar Atendimento")
        End If
    End Sub


    Private Sub picAnyDesk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picAnyDesk.Click

        _util.ExecutaShell("anydesk.exe", "AnyDesk", "", 1, "http://downloads.pelotas.com.br/ferramentas/anydesk.exe", True)

    End Sub

    Private Sub TabelaCBHPMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TabelaCBHPMToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://downloads.pelotas.com.br/biosifam/help/CBHPM_2015.pdf")
    End Sub

    Private Sub AutorizaçãoRemotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizaçãoRemotaToolStripMenuItem.Click
        IdAutorizacaoRemota = 0
        Dim vdDataAutorizacao As Date
        Dim IntAutorizacao As Long
        Dim drPessoa As Npgsql.NpgsqlDataReader
        Dim Messagem As String = ""  ' para poder fechar rapidamente as conexoes com o banco de dados

        IntAutorizacao = Val(InputBox("Informe o número da autorização : ", "Autorização Remota de Registro"))
        If IntAutorizacao = 0 Then Exit Sub
        If _PG.Conectar() = False Then Exit Sub
        drGeneric = _PG.DrQuery("select data, matricula, id_prestador, situacao, tipo, id_pessoa from atendimento_autorizacao where id_atendimento_autorizacao=" & IntAutorizacao)
        If drGeneric.HasRows Then
            drGeneric.Read()
            vdDataAutorizacao = Format(drGeneric.Item(0), "dd/MM/yyyy")
            TipoAutorizacaoRemota = drGeneric.Item("tipo")
            ' vdDataAutorizacao = "10/07/2021"
            ' solicitacao OS OS9635/2021 15/07/2021
            'If vdDataServidor <> Today.Date Then MsgBox("A data da autorização informada não é para o dia de hoje. Autorização precisa ser informada no dia do atendimento.") : Exit Sub
            If vdDataAutorizacao < CDate(Today.Date).AddDays(-5) Then MsgBox("A data da autorização informada não pode ser anterior a 5 dias da data da autorização. ") : Exit Sub
            If drGeneric.Item(2) <> oMedicoConveniado.Id Then MsgBox("Esta autorização não foi solicitada para o médico selecionado. Verique com o Paciente o médico que ele selecionou na autorização.") : Exit Sub
            If drGeneric.Item(3) = "C" Then MsgBox("Esta autorização está cancelada.") : Exit Sub
            If TipoAutorizacaoRemota <> "R" And TipoAutorizacaoRemota <> "B" Then
                If TipoAutorizacaoRemota = "S" Then
                    If drGeneric.Item("situacao") = "A" Then
                        Messagem = "A autorização informada é do tipo SMS e já foi utilizada."
                    Else
                        Messagem = "A autorização informada é do tipo SMS e não é permitida nesta local, utilize o ícone de SMS para esta autorização."
                    End If
                Else
                    Messagem = "Tipo de autorização não permitido."
                End If
                GoTo Fim
            End If
            If TipoAutorizacaoRemota = "B" Then
                drPessoa = _PG.DrQuery("select matricula from pessoas where id_pessoa=" & drGeneric.Item("id_pessoa"))
                If drPessoa.HasRows Then
                    drPessoa.Read()
                    txtMatricula.Text = drPessoa.Item(0)
                End If
            Else
                txtMatricula.Text = drGeneric.Item(1)

            End If
            txtMatricula.Enabled = False
            CarregaMatricula()

            If vnGlo_ModoAtual >= 2 Then
                IdAutorizacaoRemota = IntAutorizacao
                btnGravar.Enabled = True
                vsRetorno = "clique em GRAVAR Atendimento."
                If cmbMedico.Items.Count > 1 Then vsRetorno = "Selecione o médico e " & vsRetorno
            End If
            If btnGravar.Enabled Then btnGravar.Focus()
            Messagem = "Autorização localizada com sucesso!" & Chr(13) & Chr(13) & "Selecione o paciente ou seus dependentes, informe os procedimentos se houverem e clique em salvar para finalizar o registro do atendimento."

        Else
            IdAutorizacaoRemota = 0
            Messagem = "Autorização não existe."
        End If

Fim:
        _PG.Desconectar()
        If Messagem <> "" Then MsgBox(Messagem)

    End Sub


    Private Sub PicQrCode_Click(sender As Object, e As EventArgs) Handles PicQrCode.Click
        ChamaQrCode()
    End Sub
    Private Function ChamaQrCode() As Boolean
        ChamaQrCode = False
        vbModoQrCode = False
        If vbModoBNI = False Then
            If _u.vbUsuarioSuporte = False And _u.vbUsuarioPrevpel = False Then
                MsgBox("O QrCode deve ser utilizado somente após 5 tentativas de leitura biométrica inválidas!", vbOKOnly, "Acesso não permitido")
                Exit Function
            Else
                MsgBox("Usuário padrão só pode usar após 5 tentativas de leitura biométrica inválidas!", vbOKOnly, "Acesso Administrativo permitido")
            End If

        End If

        ' http://site.pelotas.com.br/portaldoservidor/login_biosifam.php?par=1444-

        If oMedicoConveniado.Id = 0 Then
            MsgBox("O profissional não foi selecionado, por favor, selecione o Profissional na lista de seleção.", vbInformation, "QrCode do Conveniado")
            Exit Function
        End If
        If cmbMedico.Items.Count > 1 And cmbMedico.SelectedIndex = -1 Then
            MsgBox("Selecione um prestador. ")
            cmbMedico.Focus()
            Exit Function
        End If

        If _Autorizacao.AutorizarViaQrCode(_Pessoa.Id) Then
            btnGravar.Enabled = True
            lblSenha.Visible = False
            grpSenha.Visible = False
            vbModoQrCode = True   ' libera registrar via QrCode
            btnGravar.Focus()
        End If
        ChamaQrCode = True
    End Function
    Private Sub TutorialSMSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TutorialSMSToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://downloads.pelotas.com.br/biosifam/help/tutoriais.php")
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim vnId As Long = 0, vsIds As String = ""

        vnId = Val(InputBox("Informe o número de atendimento que deseja reimprimir o recibo", "Reimpressão de Recibo de Atendimento", vsIds))
        If vnId = 0 Then GoTo Encerrar
        If _PG.Conectar() = False Then Exit Sub
        drServicos = _PG.DrQuery("SELECT id_atendimento, matricula, to_ascii(p.nome ,'LATIN1') nome_paciente,to_ascii(s.descricao ,'LATIN1') nome_servico, a.valor, id_juridica, id_medico, a.situacao, ats.valor FROM atendimento a inner join atendimento_servico ats using(id_atendimento) inner join servico s using(id_servico) inner join pessoas p using(id_pessoa) where a.id_atendimento=" & vnId)
        If drServicos.HasRows Then
            drServicos.Read()
            If idResponsavelFinanceiro > 0 And GrpSetor.Visible Then
                If drServicos.Item("id_juridica") <> oMedicoConveniado.Id Then
                    MsgBox("O atendimento informado pertence a outro prestador e só pode ser impresso por ele.")
                    GoTo Encerrar
                End If
            Else
                If drServicos.Item("id_medico") <> oMedicoConveniado.Id Then
                    MsgBox("o Atendimento informado pertence a outro prestador e só pode ser impresso por ele.")
                    GoTo Encerrar
                End If
            End If

            If drServicos.Item("situacao") = "P" Then
                MsgBox("o Atendimento está PENDENTE e nesta situação não é permitida a impressão de comprovante. Conclua primeiro o atendimento.")
                GoTo Encerrar
            End If
            If drServicos.Item("situacao") = "C" Then
                MsgBox("o Atendimento está CANCELADO e nesta situação não é permitida a impressão de comprovante.")
                GoTo Encerrar
            End If

            PrintDocument1.Print()

        Else
            MsgBox("o Identificador informado não foi localizado ou não pertence ao atual paciente e/ou clínica.")
        End If
Encerrar:
        _PG.Desconectar()

    End Sub

    Private Function Autorizacao(ByRef txtAutorizacao As TextBox) As Boolean
        Autorizacao = False
        Dim ds As DataSet
        Dim dsUpload As DataSet
        Dim vsSql As String
        Dim StrWhere As String = ""
        Dim IntAutorizacao As Integer = txtAutorizacao.Text
        If IntAutorizacao = 0 Then Exit Function

        vsSql = "select * from atendimento_autorizacao where id_atendimento_autorizacao=" & IntAutorizacao
        ds = _PG.DsQuery(vsSql)
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Autorização não foi localizada  !")
            Exit Function
        End If
        If ds.Tables(0).Rows(0).Item("tipo").ToString <> "A" Then
            MsgBox("Autorização não pode ser utilzada neste tipo de atendimento !")
            Exit Function
        End If
        If oMedicoConveniado.Modo <> 5 And oMedicoConveniado.Modo <> 3 Then
            ' 5=hospitalar, 3-exames
            MsgBox("Autorização não pode ser utilizada pelo Prestador Atual !")
            Exit Function
        End If
        If ds.Tables(0).Rows(0).Item("situacao").ToString = "F" Then
            MsgBox("Autorização já foi utilizada e finalizada!")
            Exit Function
        End If
        If ds.Tables(0).Rows(0).Item("situacao").ToString <> "A" Then
            MsgBox("Autorização não está autorizada !")
            Exit Function
        End If
        If ds.Tables(0).Rows(0).Item("id_pessoa").ToString <> _Pessoa.Id Then
            MsgBox("Autorização não foi autorizada para a pessoa selecionada !")
            Exit Function
        End If

        vsSql = "select * from upload where tipo='P' and identificador='" & IntAutorizacao & "'"
        dsUpload = _PG.DsQuery(vsSql)
        If dsUpload.Tables(0).Rows.Count = 0 Then
            MsgBox("Upload não foi localizado  !")
            Exit Function
        End If

        If MsgBox("Autorização localizada ! " & Chr(13) & "Deseja visualizar o documento digitalizado da autorização ?", vbYesNo) = vbYes Then
            System.Diagnostics.Process.Start("http:\\sifam.pelotas.com.br\php\viewPrestadorUploads.php?id_upload=" & dsUpload.Tables(0).Rows(0).Item("id_upload").ToString)
        End If

        txtAutorizacao.Text = "Autorizaçao N. " & IntAutorizacao
        txtAutorizacao.Enabled = False
        Autorizacao = True
    End Function

    Private Sub RelatórioDeExamesProcedimentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelatórioDeExamesProcedimentosToolStripMenuItem.Click
        Try
            If IdMedico = 0 Then
                MsgBox("Nenhum médico foi informado, por favor selecione um médico.")
                cmbMedico.Focus()
                Exit Sub
            End If
            System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/php/relatorioTabelaExamesPrestador.php?print=Biosifam&idmedico=" & System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(oMedicoConveniado.Id)) & "&datai=" & Format(vdData, "yyyy-MM-dd") & "&dataf=" & Format(vdDataFim, "yyyy-MM-dd"))
        Catch
        Finally
        End Try

    End Sub

    Private Sub mskValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskValor.KeyPress
        If e.KeyChar = "." Then
            If InStr(mskValor.Text, ",") Then e.Handled = True
            e.KeyChar = ","
        ElseIf Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack And Not e.KeyChar = "," Then
            e.Handled = True
        ElseIf e.KeyChar = "," And InStr(mskValor.Text, ",") Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbProcedimento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcedimento.SelectedIndexChanged
        If cmbProcedimento.Visible = False Then Exit Sub
        If cmbProcedimento.SelectedItem Is Nothing Then Exit Sub
        If cmbProcedimento.SelectedIndex = -1 Then Exit Sub
        Try
            _Servico.Carregar(cmbProcedimento.SelectedItem.Id, oMedicoConveniado, 0)
            mskValor.Text = _Servico.Valor
            If _Servico.HabilitaDigitacaoPreco(mskValor, BolCorrecao) = False Then mskTotal.Text = _Atendimento.TotalizaServico(0, CType(cmbProcedimento.SelectedItem, ComboData).Id, mskValor.Text)
            If (mskValor.Text = 0 Or BolCorrecao) And BolCarregandoCombo = False And mskValor.Enabled Then mskValor.Focus()
        Catch
        End Try
    End Sub

    Private Sub cmbProcedimento2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProcedimento2.KeyPress
        ' teclou ENTER põe o foco no próximo controle 
        If e.KeyChar = Convert.ToChar(Keys.Delete) Then mskValor2.Text = ""
    End Sub

    Private Sub cmbProcedimento2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcedimento2.SelectedIndexChanged
        If cmbProcedimento2.Visible = False Then Exit Sub
        If _PG.Conectar() = False Then Exit Sub
        If cmbProcedimento2.SelectedItem Is Nothing Then Exit Sub
        If cmbProcedimento2.SelectedIndex = -1 Then Exit Sub
        _Servico.Carregar(CType(cmbProcedimento2.SelectedItem, ComboData).Id, oMedicoConveniado, 0)
        mskValor2.Text = _Servico.Valor
        If _Servico.HabilitaDigitacaoPreco(mskValor2, BolCorrecao) = False Then mskTotal.Text = _Atendimento.TotalizaServico(1, CType(cmbProcedimento2.SelectedItem, ComboData).Id, mskValor2.Text)
        If (mskValor2.Text = 0 Or BolCorrecao) And BolCarregandoCombo = False And mskValor2.Enabled Then mskValor2.Focus()
    End Sub

    Private Sub CmbSetor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSetor.SelectedIndexChanged
        GrpUpload.Visible = False
        If CmbSetor.SelectedIndex = -1 Then CmbSetor.SelectedIndex = 0
        IdMedico = CType(CmbSetor.SelectedItem, ComboData).Id
        oMedicoConveniado = New ClsMedico(IdMedico)
        oMedicoConveniado.CarregaComboMedicos(cmbMedico, idResponsavelFinanceiro)
        IdMedico = oMedicoConveniado.Id
        If oMedicoConveniado.ResponsavelFinanceiro = False Then

            ' sugere primeiro da lista = medicoP
            cmbMedico.SelectedIndex = 0

        Else
            idResponsavelFinanceiro = IdMedico
            If oMedicoConveniado.Modo = 1 Then      ' modo=1=consultas
                idResponsavelFinanceiro = IdSetor
                oMedicoConveniado.CarregaComboMedicos(cmbMedico, idResponsavelFinanceiro)
                ' sugere primeiro da lista = medicoP
                IdMedico = oMedicoConveniado.Id
                If cmbMedico.Items.Count > 1 Then
                    If oMedicoConveniado.ResponsavelFinanceiro Then
                        Call _t.PosicionaCombo(cmbMedico, oMedicoConveniado.Id)
                    Else
                        cmbMedico.SelectedIndex = 0
                    End If
                    ' ao selecinar novo pedido concta no banco e perde a conexao atual, precisa conectar novamente
                    If _PG.Conectar() = False Then End
                Else
                    If cmbMedico.Items.Count = 0 Then
                        If idResponsavelFinanceiro = 0 Then
                            MsgBox("Erro na configuração do prestador. Prestador marcado como responsável financeiro sem vinculados.")
                        Else
                            MsgBox("Erro na configuração do prestador. Prestador não localizado.")
                        End If
                        vnGlo_ModoAtual = "1"
                    Else
                        cmbMedico.SelectedIndex = 0
                    End If
                End If

            End If
        End If
        ConfiguraConveniado()

    End Sub
    Private Sub mskValor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskValor.GotFocus
        mskValor.SelectionLength = mskValor.TextLength
    End Sub
    Private Sub mskValor2_GotFocus(sender As Object, e As EventArgs) Handles mskValor2.GotFocus
        mskValor2.SelectionStart = 0
        mskValor2.SelectionLength = mskValor2.Text.Length
    End Sub
    Private Sub mskValor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskValor.Leave
        AtualizaValor(cmbProcedimento, mskValor, 0)

        If mskValor.Text <> "" And cmbProcedimento.SelectedIndex >= 0 And oMedicoConveniado.Modo = "2" Then
            ' mskValor.Text = FormatNumber(mskValor.Text, 2)
            'mskTotal.Text = _Atendimento.TotalizaServico( 0, CType(cmbProcedimento.SelectedItem, ComboData).Id, mskValor.Text)
            ' se valor zero limpa item selecionado 
            'If mskValor.Text = "0,00" And cmbProcedimento.SelectedIndex >= 0 Then cmbProcedimento.SelectedIndex = -1 : mskValor.Text = ""
            ' If BolCorrecao Then Exit Sub
            If mskValor2.Visible Or cmbProcedimento2.Visible Then
                cmbProcedimento2.Focus()
            Else
                If btnGravar.Enabled Then btnGravar.Focus()
            End If
        End If
    End Sub

    Private Sub AtualizaValor(Procedimento As ComboBox, Valor As MaskedTextBox, Indice As Integer)
        If Procedimento.SelectedIndex >= 0 Then
            If Valor.Text = "" Then Valor.Text = FormatNumber(0, 2, , TriState.True) Else Valor.Text = FormatNumber(Valor.Text, 2, , TriState.True)
            If Valor.Text = "0,00" Then
                ' apaga item
                mskTotal.Text = _Atendimento.TotalizaServico(Indice, CType(Procedimento.SelectedItem, ComboData).Id, 0, True)
                Procedimento.SelectedIndex = -1
                Valor.Text = ""
            Else
                mskTotal.Text = _Atendimento.TotalizaServico(Indice, CType(Procedimento.SelectedItem, ComboData).Id, Valor.Text)
            End If
        End If

    End Sub
    Private Sub mskValor2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskValor2.Leave
        AtualizaValor(cmbProcedimento2, mskValor2, 1)
    End Sub

    Private Sub cmbProcedimento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProcedimento.KeyDown
        Dim KeyCode As Short = e.KeyCode
        If KeyCode = System.Windows.Forms.Keys.Delete Then
            mskTotal.Text = _Atendimento.TotalizaServico(0, CType(cmbProcedimento.SelectedItem, ComboData).Id, 0, True)
            mskValor.Text = ""
        End If
    End Sub
    Private Sub cmbProcedimento2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProcedimento2.KeyDown
        Dim KeyCode As Short = e.KeyCode
        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Delete Then
            mskTotal.Text = _Atendimento.TotalizaServico(1, CType(cmbProcedimento2.SelectedItem, ComboData).Id, 0, True)
            mskValor2.Text = ""
        End If
    End Sub

    Private Sub LogList_Click(sender As Object, e As EventArgs) Handles LogList.Click
        If LogList.Width = 32 Then LogList.Width = 580 Else LogList.Width = 32
    End Sub

    Private Sub LimpaServicos()
        cmbProcedimento.SelectedIndex = -1
        cmbProcedimento2.SelectedIndex = -1
        cmbProcedimento.Text = ""
        cmbProcedimento2.Text = ""
        mskValor.Text = ""
        mskValor2.Text = ""

        DrgServicosAtendimento.Columns.Clear()
        DrgServicosAtendimento.Columns.Add("Id", "Id")
        DrgServicosAtendimento.Columns.Add("Descricao", "Descricao")
        DrgServicosAtendimento.Columns.Add("CBHPM", "CBHPM")
        DrgServicosAtendimento.Columns.Add("Valor", "Valor")
        DrgServicosAtendimento.Columns(0).Width = 0
        DrgServicosAtendimento.Columns(0).Visible = False
        DrgServicosAtendimento.Columns(1).Width = 120
        DrgServicosAtendimento.Columns(2).Width = 30
        DrgServicosAtendimento.Columns(3).Width = 70

        Me.Refresh()
    End Sub

    Private Sub UploadDeCredenciamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadDeCredenciamentoToolStripMenuItem.Click
        '   Dim frmBrowser = New frmBrowserChromium("http://sifam.pelotas.com.br/php/formUploadDocumentosPrestador.php")
        '  frmBrowser.Show()
        ' Exit Sub
        System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/php/formUploadDocumentosPrestador.php")
    End Sub

    Private Sub chkRegistraSomenteExames_CheckedChanged(sender As Object, e As EventArgs) Handles chkRegistraSomenteExames.CheckedChanged
        If chkRegistraSomenteExames.Checked Then
            mskValor.Text = "0,00"
            If mskValor.Text = "0,00" And cmbProcedimento.SelectedIndex >= 0 Then
                cmbProcedimento.SelectedIndex = -1
                mskValor.Text = ""
                _Atendimento.IntServico(0) = 0
                _Atendimento.vnTotalServicos -= _Atendimento.DecValor(0)
                _Atendimento.DecValor(0) = -1
            End If
            mskTotal.Text = FormatNumber(_Atendimento.vnTotalServicos, 2, , TriState.True)
            chkRegistraSomenteExames.Refresh()
        Else
            cmbProcedimento.SelectedIndex = 0
            mskTotal.Text = _Atendimento.TotalizaServico(0, CType(cmbProcedimento.SelectedItem, ComboData).Id, mskValor.Text)
        End If
        If oMedicoConveniado.Modo = 4 Then
            If chkRegistraSomenteExames.Checked Then
                cmbProcedimento.Enabled = False
                mskValor.Enabled = False
                cmbProcedimento.SelectedIndex = -1
                mskValor.Text = ""
                cmbProcedimento2.Visible = True
                cmbProcedimento2.SelectedIndex = 0
                mskValor2.Visible = True
                mskValor2.Focus()
            Else
                cmbProcedimento.Enabled = True
                mskValor.Enabled = True
                cmbProcedimento.SelectedIndex = -1
                mskValor.Text = ""
                cmbProcedimento2.Visible = False
                cmbProcedimento2.SelectedIndex = -1
                mskValor2.Text = ""
                mskValor2.Visible = False
            End If

        End If
    End Sub

    Private Sub BtnSenhaGerecnial_Click(sender As Object, e As EventArgs) Handles BtnSenhaGerecnial.Click
        IntContaTentativasSenhaGerencial += 1
        If _u.Senha <> MskSenhaGerencial.Text Then
            MsgBox("Senha não confere, deseja tentar novamente ?")
            If IntContaTentativasSenhaGerencial > 3 Then MsgBox("Tentativas esgotadas, procure a PREVPEL para atualizar a senha Gerecnial.")
        Else
            If oMedicoConveniado.FazExameNoConsultorio Then
                MsgBox("Selecione um procedimento e clique em SALVAR atendimento.")
            Else
                MsgBox("Clique em SALVAR atendimento.")
            End If
            vbModoOFFLine = True
            Me.BackColor = Color.Yellow
            btnGravar.Enabled = True
            btnGravar.Focus()
            GrpSenhaGerencial.Visible = False
        End If
    End Sub

    Private Sub AlterarOrdemDeClassificaçãoDeExamesProcedimentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlterarOrdemDeClassificaçãoDeExamesProcedimentosToolStripMenuItem.Click
        If oMedicoConveniado.OrdemClassificacaoServicos = "A" Then oMedicoConveniado.OrdemClassificacaoServicos = "C" Else oMedicoConveniado.OrdemClassificacaoServicos = "A"
        ConfiguraConveniado()
    End Sub

    Private Sub lblProcecimento_Click(sender As Object, e As EventArgs)
        MsgBox("Para alterar a classificação de exames e/ou procedimentos, utilize o Menu Controle, opção Alterar Ordem de Classificaçao.")
    End Sub

    Private Sub PicAlerta_Click(sender As Object, e As EventArgs) Handles PicAlerta.Click
        System.Diagnostics.Process.Start("http://sifam.pelotas.com.br/php/formUploadDocumentosPrestador.php")
    End Sub

    Private Sub cmbProcedimento_Leave(sender As Object, e As EventArgs) Handles cmbProcedimento.Leave
        If cmbProcedimento.Text <> "" And cmbProcedimento.SelectedIndex = -1 Then
            ' escreveu algo e nao selecionou nada
            cmbProcedimento.Text = ""
        End If
    End Sub
    Private Sub cmbProcedimento2_Leave(sender As Object, e As EventArgs) Handles cmbProcedimento2.Leave
        If cmbProcedimento2.Text <> "" And cmbProcedimento2.SelectedIndex = -1 Then
            ' escreveu algo e nao selecionou nada
            cmbProcedimento2.Text = ""
        End If
    End Sub


    Private Sub ConfiguraConveniado()
        AutorizaçãoRemotaToolStripMenuItem.Enabled = True
        _ServicoPrincipal = New ClsServico
        PicAlerta.Visible = False

        GrpServicoInformado.Visible = False
        GrpServicos.Visible = False
        GrpConsultas.Visible = False
        GrpUpload.Visible = False

        Me.Cursor = Cursors.WaitCursor

        ' medicos otorrinolarringologistas podem fazer somentes exames - Especialidade = 23 
        chkRegistraSomenteExames.Visible = False
        If oMedicoConveniado.LiberaCorrecoes Then CorreçõesEmProcedimentosToolStripMenuItem.Visible = True Else CorreçõesEmProcedimentosToolStripMenuItem.Visible = False
        'If oMedicoConveniado.LiberaDigitacaoOffLine Then CorreçõesEmProcedimentosToolStripMenuItem.Visible = True Else CorreçõesEmProcedimentosToolStripMenuItem.Visible = False

        cmbProcedimento.Items.Clear()
        cmbProcedimento.Enabled = True
        mskValor.Enabled = True

        cmbProcedimento2.Items.Clear()
        cmbProcedimento2.Visible = False
        mskValor2.Visible = False

        cmbProcedimento.DropDownStyle = 2
        cmbProcedimento2.DropDownStyle = 2

        ' consulta fisioterapeuta cd 16981, especialidade=34, não é médico,   valor 15,56
        ' consulta dentista       cd 3348, foi desativada - dentista usa somente procedimentos
        ' consulta fisiatra       cd 1,     especialidade 10, médico fisiatra, valor 55,00 
        ' consulta nutricionista  cd 16999, especialidade 18, médico nutriciinista, valor 75,00 = medico mas 1 a cada trinta dias
        ' o valor dos procedimento é determinado pelo servico, se zero permitie digitar, se nao nao permite
        If oMedicoConveniado.Modo = 2 Then
            GrpConsultas.Visible = True

            If oMedicoConveniado.Fisioterapeuta Then
                _ServicoPrincipal.Id = 16981
                cmbProcedimento.Items.Add(New ComboData(_ServicoPrincipal.Id, "FISIOTERAPIA"))
                'COMPONENTES DAS SESSOES - USADAS PELO MODO=4=FISIOTERAPIA
                btnConsultarSessoes.Visible = True
                RegistroDePacotesToolStripMenuItem.Visible = True
                ResumoDePacotesToolStripMenuItem.Visible = True
                AutorizaçãoRemotaToolStripMenuItem.Enabled = False
            ElseIf oMedicoConveniado.Nutricionista Then
                _ServicoPrincipal.Id = 16999    ' consulta nutricionista
                cmbProcedimento.Items.Add(New ComboData(_ServicoPrincipal.Id, "CONSULTA NUTRICIONISTA"))

            ElseIf oMedicoConveniado.Dentista Then
                ' dentistas passam a usar somente servicos do seu cadastro em 10/01/2022 - versao 2.2.19 - antes usam tipo 'PO'
                ' dentista nao usa segundo procedimento
                StrGloSQL = "SELECT servico.id_servico, to_ascii(descricao,'LATIN1') || case when valor > 0 then ' , R$ '|| valor else '' end FROM servico inner join prestador_servicos on servico.id_servico=prestador_servicos.id_servico where prestador_servicos.id_prestador=" & IdMedico & " and servico.ativo='S' "
                BolCarregandoCombo = True
                _t.CarregaCombo(cmbProcedimento, StrGloSQL)
                GoTo FinalizaBloco

            Else
                _ServicoPrincipal.Id = 1   ' default é consulta medica
                cmbProcedimento.Items.Add(New ComboData(_ServicoPrincipal.Id, "CONSULTA MÉDICA"))
                If (oMedicoConveniado.Especialidade <> 34 And oMedicoConveniado.Especialidade2 <> 34) Then
                    ' qualquer médico , exceto fisioterapeutas poderao fazer solicitacoes de autorizacao
                    If oMedicoConveniado.LiberaAutorizacao Then AutorizaçõesToolStripMenuItem.Enabled = True
                End If
            End If

            cmbProcedimento.SelectedIndex = 0

            _ServicoPrincipal.Carregar(_ServicoPrincipal.Id, oMedicoConveniado, 0)  ' busca valores
            mskValor.Text = _ServicoPrincipal.Valor
            mskValor.Enabled = False
            mskTotal.Text = _Atendimento.TotalizaServico(0, CType(cmbProcedimento.SelectedItem, ComboData).Id, mskValor.Text)

            If oMedicoConveniado.FazExameNoConsultorio And
                (oMedicoConveniado.Especialidade = 23 Or oMedicoConveniado.Especialidade2 = 23 Or
                oMedicoConveniado.Especialidade = 3 Or oMedicoConveniado.Especialidade2 = 3 Or
                oMedicoConveniado.Especialidade = 36 Or oMedicoConveniado.Especialidade2 = 36) Then
                chkRegistraSomenteExames.Visible = True
                ' medicos otorrinolarringologistas 23  podem fazer somentes exames
                ' medicos cardiologistas podem fazer 3 somentes exames
                ' medicos cardiologistas pedriatrico 36 podem fazer somentes exames
            End If

            If oMedicoConveniado.Fisioterapeuta = False And oMedicoConveniado.Nutricionista = False Then
                AutorizaçõesToolStripMenuItem.Enabled = True
            End If

            If oMedicoConveniado.FazExameNoConsultorio Or oMedicoConveniado.Anestesista Then
                ' alguns medicos fazem exame em consultorio, oftal, otorrino, cardiologistas... e ANESTEGISTAS
                ' exames em consultório, sistema busca dos exames vinculados ao medico
                GrpServicoInformado.Location = New System.Drawing.Point(12, 220)
                GrpServicoInformado.Visible = True

                GrpServicos.Visible = True
                GrpServicos.Location = New System.Drawing.Point(12, 265)
                GrpServicos.Height = GrpServicos.Height - 65
                DrgServicosAtendimento.Height = DrgServicosAtendimento.Height - 65

            End If

        ElseIf oMedicoConveniado.Modo = 3 Then
            ' modo 3 = somente exames -            ' exames em clnica s e laboratorios carrega exames vinculados ao cadastro
            BtnAutoriza.Visible = False

            ' exames
            GrpServicoInformado.Visible = True
            GrpServicos.Visible = True

            TxtServico.Focus()

            BtnAutoriza.Visible = True

            ' exame em hospitais (vinculo="S") - devem solicitar upload de despesas
            If oMedicoConveniado.Vinculo <> "S" Then GrpUpload.Text = "Upload de Prescrição Médica, informe o arquivo em PDF."
            If oMedicoConveniado.DespesaHospitalar Then
                'libera digitação offline para estas duas situacoes do novara
                vbModoOFFLine = True
                btnGravar.Enabled = True
            End If


        ElseIf oMedicoConveniado.Modo = 4 Then            '  modo 4 - pronto atendimento (consulta e exames com pendencia)
            GrpConsultas.Visible = True
            chkRegistraSomenteExames.Visible = True
            chkRegistraSomenteExames.Text = "Somente Despesas Extras"

            ' procedimentos de pronto atendimentos  usarão a tabela cbhpm e a classificação de exames que somente o médico faz.
            If oMedicoConveniado.OrdemClassificacaoServicos = "C" Then
                ' ordem de codigo
                StrGloSQL = " Select servico.id_servico, Case when cbhpm_capitulo > '0' then cbhpm_capitulo || '-' else '' end || to_ascii(descricao,'LATIN1') || Case when valor > 0 then ' , R$ '|| valor else '' end  From servico inner Join prestador_servicos On servico.id_servico=prestador_servicos.id_servico Where prestador_servicos.id_prestador= " & IdMedico & " and servico.ativo='S' Order By 2"
            Else
                ' ordem alfabetica
                StrGloSQL = " Select servico.id_servico, to_ascii(descricao,'LATIN1') || Case when cbhpm_capitulo > '0' then '-' || cbhpm_capitulo else '' end || Case when valor > 0 then ' , R$ '|| valor else '' end  From servico inner Join prestador_servicos On servico.id_servico=prestador_servicos.id_servico Where prestador_servicos.id_prestador= " & IdMedico & " and servico.ativo='S' Order By 2"
            End If
            BolCarregandoCombo = True
            ' no Pronto Atendimento vou excluir DESPESAS EXTRAS do primeiro COMBO
            StrGloSQL = Replace(StrGloSQL, " Order By 2", " and prestador_servicos.id_servico<>16953 Order By 2")
            _t.CarregaCombo(cmbProcedimento, StrGloSQL)

            ' 16950-urgente, 16949-nao urgente
            ' no Pronto Atendimento no segundo combo vou excluir as consultas urgente e nao urgente, pode aparece despesas extra e exames
            StrGloSQL = Replace(StrGloSQL, " and prestador_servicos.id_servico<>16953 Order By 2", " and prestador_servicos.id_servico<>16950 and prestador_servicos.id_servico<>16949  ")
            _t.CarregaCombo(cmbProcedimento2, StrGloSQL)

            ' PA não usa combo3
            BtnAutoriza.Visible = False
            BolCarregandoCombo = False

            If cmbProcedimento.Items.Count = 0 Then
                MsgBox("Nenhum exame/procedimento foi localizado para o Prestador de Serviço selecionado, procure apoio técnico.")
                MsgBox("O modo Pronto Atendimento não funciona sem que existam procedimentos do Prestador de Serviço, cadastre os serviços do Prestador ou procure apoio técnico.")
                MsgBox("Nenhum atendimento será realizado até a solução do problema, modo CONSULTA DIGITAL ativado")
                vnGlo_ModoAtual = 1
            End If

            GrpConsultas.Visible = True

        ElseIf oMedicoConveniado.Modo = 5 Then      ' hospitalar

            BtnAutoriza.Visible = True     ' upload de prescricao
            GrpConsultas.Visible = False
            GrpServicoInformado.Visible = True
            GrpServicos.Visible = True

            TxtServico.Focus()

            ' exame em hospitais (vinculo="S") - devem solicitar upload de despesas
            If oMedicoConveniado.Vinculo <> "S" Then GrpUpload.Text = "Upload de Prescrição Médica, informe o arquivo em PDF."

            ' hospitalar com setor - vai depender do vinculado
            AutorizaçõesToolStripMenuItem.Text = "Despesas"
            AutorizaçõesToolStripMenuItem.Enabled = True

        End If

FinalizaBloco:
        oMedicoConveniado.VerificaSituacaoDocumentacao()
        If oMedicoConveniado.SituacaoDocumentacao <> "V" Then
            PicAlerta.Visible = True
            toolTip3.SetToolTip(Me.PicAlerta, oMedicoConveniado.Alerta)
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PicCorrigir_Click(sender As Object, e As EventArgs) Handles PicCorrigir.Click

        ' cancelamento sera permitido aos proprios conveniados, quando no mesmo dia.
        IdAtendimentoCorrecao = Val(InputBox("Informe o número do atendimento :", "Correção de Atendimento"))
        If IdAtendimentoCorrecao = 0 Then Exit Sub

        Dim vdDataServidor As Date = _PG.DataServidor
        Dim ds As DataSet
        ds = _PG.DsQuery("SELECT id_atendimento, to_ascii(prestador.nome,'LATIN1') as nome_prestador,  to_ascii(p.nome,'LATIN1') as nome_pessoa, a.dt_alteracao, a.situacao, prestador.id_prestador, autorizacao, p.id_pessoa, current_date as hoje, matricula FROM atendimento as a, prestador, pessoas p where a.id_medico=prestador.id_prestador and a.id_pessoa=p.id_pessoa and id_atendimento=" & IdAtendimentoCorrecao)

        If ds Is Nothing Then MsgBox("O atendimento não foi localizado.") : GoTo Fim
        If ds.Tables(0).Rows.Count = 0 Then MsgBox("O atendimento não foi localizado.") : GoTo Fim
        If ds.Tables(0).Rows(0).Item(4).ToString() = "C" Then MsgBox("O atendimento N. " & IdAtendimentoCorrecao & " já está cancelado.") : GoTo Fim

        BolCorrecao = True

        If vnGlo_ModoAtual <> 0 Then
            If ds.Tables(0).Rows(0).Item(5).ToString() <> oMedicoConveniado.Id Then MsgBox("O atendimento N. " & IdAtendimentoCorrecao & " foi realizado por outro profissional e você não tem permissão para visualizá-lo.") : GoTo Fim
            If oMedicoConveniado.VerificaRestricoesOffLine(CDate(ds.Tables(0).Rows(0).Item(3)), ds.Tables(0).Rows(0).Item(4)) = False Then GoTo Fim
        Else
            ' retaguarda pode passar - nao alterar nada
            Call _t.PosicionaCombo(cmbMedico, ds.Tables(0).Rows(0).Item(5).ToString())
            GrpServicoInformado.Enabled = False
            GrpServicoInformado.Visible = True
            GrpConsultas.Visible = False
            GrpServicos.Visible = True
        End If

        ' atualiza daods paciente.
        txtMatricula.Text = ds.Tables(0).Rows(0).Item("matricula")
        Call CarregaMatricula()
        CarregaDadosPaciente(ds.Tables(0).Rows(0).Item("id_pessoa"), True)
        grpSenha.Visible = False
        _Atendimento.Inicializar()  ' totalizador

        lblDataAtendimento.Text = "Registro em correção =>  Id.: " & IdAtendimentoCorrecao & ", data: " & Format(ds.Tables(0).Rows(0).Item("dt_alteracao"), "dd/MM/yyyy")
        lblDataAtendimento.Visible = True

        Call MontaGridServicos(IdAtendimentoCorrecao)
        'mskTotal.Text = FormatNumber(_Atendimento.vnTotalServicos, 2, , TriState.True)

        cmbProcedimento.Focus()

        'libera gravacao só para Labotatorios
        StrJustificativaCorrecao = InputBox("Para prosseguir com a correção informe uma justificativa para a correção: ")
        If Trim(StrJustificativaCorrecao) = "" Then GoTo Fim
        If StrJustificativaCorrecao.ToString.Length < 10 Then MsgBox("A Justificativa precisa ter no mínimo 10 caracteres.") : GoTo Fim
        If StrJustificativaCorrecao.ToString.Length > 100 Then MsgBox("Informe no máximo 100 caracteres.") : GoTo Fim

        GrpServicoInformado.Enabled = True
        btnGravar.Enabled = True
        Exit Sub
Fim:

        If vnGlo_ModoAtual = 0 Then cmbMedico.SelectedIndex = -1

    End Sub
    Private Function MontaGridServicos(IdAtendimento As Integer)
        ds = _PG.DsQuery("SELECT s.id_servico as Codigo, to_ascii(descricao,'LATIN1') as Nome,  cbhpm_capitulo as CBHPM, ats.valor as Valor  FROM atendimento_servico as ats inner join servico s using (id_Servico) where id_atendimento=" & IdAtendimento)
        Try
            LimpaServicos()

            For I = 0 To ds.Tables(0).Rows.Count - 1

                ServicoGrid(0) = ds.Tables(0).Rows(I).Item("codigo")
                ServicoGrid(1) = ds.Tables(0).Rows(I).Item("nome")
                ServicoGrid(2) = ds.Tables(0).Rows(I).Item("cbhpm")
                ServicoGrid(3) = FormatNumber(ds.Tables(0).Rows(I).Item("valor"), 2, , TriState.True)
                DrgServicosAtendimento.Rows.Add(ServicoGrid)

                mskTotal.Text = _Atendimento.TotalizaServico(0, DrgServicosAtendimento.Rows(I).Cells(0).Value(), CDec(DrgServicosAtendimento.Rows(I).Cells(3).Value()))
                ' _Atendimento.vnTotalServicos += CDec(DrgServicosAtendimento.Rows(I).Cells(3).Value())
                ' _Atendimento.vnContaServicos += 1

            Next
            DrgServicosAtendimento.Columns(0).Visible = False
            DrgServicosAtendimento.Columns(1).Width = 380
            DrgServicosAtendimento.Columns(2).Width = 75
            DrgServicosAtendimento.Columns(3).Width = 75

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub TxtServico_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtServico.KeyDown
        Dim KeyCode As Short = e.KeyCode
        If KeyCode = System.Windows.Forms.Keys.Return And TxtServico.Text <> "" Then
            If IsNumeric(TxtServico.Text) Then
                _PG.Conectar()
                ds = _PG.DsQuery("select s.id_servico as Codigo, to_ascii(descricao,'LATIN1') as Nome, valor, cbhpm_capitulo from prestador_servicos inner join servico s using (id_servico) where cbhpm_capitulo='" & TxtServico.Text & "'")
                If ds.Tables(0).Rows.Count = 0 Then
                    MsgBox("Código informado não foi localizado ou não está disponível  !" & Chr(13) & Chr(13) & "Por favor informe outro código para pesquisa.")
                    GoTo Fim_Bloco
                End If
                idServicoInformado = ds.Tables(0).Rows(0).Item("codigo")
                TxtServico.Text = ds.Tables(0).Rows(0).Item("nome")
                TxtCBHPM.Text = ds.Tables(0).Rows(0).Item("cbhpm_capitulo")
                MskValorServico.Text = ds.Tables(0).Rows(0).Item("valor")
                If ds.Tables(0).Rows(0).Item("valor") > 0 Then InserirItemGrid()
            Else
                FrmPesquisaGenerica.txtFiltro.Text = TxtServico.Text
                FrmPesquisaGenerica.Show()
            End If
        End If

Fim_Bloco:
        _PG.Desconectar()
    End Sub

    Private Sub BtnAutoriza_Click(sender As Object, e As EventArgs) Handles BtnAutoriza.Click
        If GrpUpload.Visible = True Then GrpUpload.Visible = False Else GrpUpload.Visible = True
    End Sub


    Private Sub InserirItemGrid()
        If idServicoInformado = 0 Then MsgBox("Código do item não localizado.", vbInformation, "Impossível inserir serviço.") : TxtServico.Text = "" : Exit Sub
        If TxtServico.Text <> NomeSelecionadoPesquisa Then MsgBox("Informe um serviço corretamente, selecionando-o através do botão PESQUISAR.", vbInformation, "Impossível inserir serviço.") : Exit Sub
        If TxtServico.Text = "" Then MsgBox("Informe um serviço, selecionando-o através do botão PESQUISAR.", vbInformation, "Impossível inserir serviço.") : Exit Sub
        If MskValorServico.Text = "" Then MsgBox("Informe o valor do serviço.", vbInformation, "Impossível inserir serviço.") : Exit Sub
        If CDec(MskValorServico.Text) = 0 Then MsgBox("Informe o valor do serviço.", vbInformation, "Impossível inserir serviço.") : Exit Sub

        ServicoGrid(0) = idServicoInformado
        ServicoGrid(1) = TxtServico.Text
        ServicoGrid(2) = TxtCBHPM.Text

        If MskValorServico.Text = "" Then MskValorServico.Text = "0"
        MskValorServico.Text = FormatNumber(MskValorServico.Text, 2, , TriState.True)
        ServicoGrid(3) = MskValorServico.Text

        DrgServicosAtendimento.Rows.Add(ServicoGrid)

        mskTotal.Text = _Atendimento.TotalizaServico(DrgServicosAtendimento.Rows.Count, idServicoInformado, MskValorServico.Text)

        ' _Atendimento.vnTotalServicos += CDec(MskValorServico.Text)
        ' _Atendimento.vnContaServicos += 1
        'mskTotal.Text = FormatNumber(_Atendimento.vnTotalServicos, 2, , TriState.True)

        idServicoInformado = 0
        TxtServico.Text = ""
        MskValorServico.Text = ""

        NomeSelecionadoPesquisa = ""
        IdSelecionadoPesquisa = 0
        CBHPMSelecionadoPesquisa = ""
        ValorSelecionadoPesquisa = ""

        DrgServicosAtendimento.Rows(DrgServicosAtendimento.Rows.Count - 1).Selected = True
        DrgServicosAtendimento.FirstDisplayedScrollingRowIndex = DrgServicosAtendimento.RowCount - 1
    End Sub

    Private Sub BtnPesquisarServico_Click(sender As Object, e As EventArgs) Handles BtnPesquisarServico.Click
        'Dim frmchild As New FrmPesquisaGenerica()
        'frmchild.MdiParent = Me
        'frmchild.txtFiltro.Text = TxtServico.Text
        'frmchild.Show()

        FrmPesquisaGenerica.txtFiltro.Text = TxtServico.Text
        FrmPesquisaGenerica.ShowDialog()

        If IdSelecionadoPesquisa > 0 Then
            idServicoInformado = IdSelecionadoPesquisa
            TxtServico.Text = NomeSelecionadoPesquisa
            TxtCBHPM.Text = CBHPMSelecionadoPesquisa
            MskValorServico.Text = ValorSelecionadoPesquisa
            If CDec(MskValorServico.Text) > 0 Then
                InserirItemGrid()
                TxtServico.Focus()
            Else
                MskValorServico.Focus()
            End If
        End If
    End Sub
    Private Sub DrgServicosAtendimento_KeyDown(sender As Object, e As KeyEventArgs) Handles DrgServicosAtendimento.KeyDown
        Dim KeyCode As Short = e.KeyCode
        If KeyCode = System.Windows.Forms.Keys.Delete And DrgServicosAtendimento.CurrentRow.Cells(0).Value() > 0 Then
            If MsgBox("Deseja realmente excluir o item selecionado ?", vbYesNo) = vbYes Then
                _Atendimento.vnTotalServicos -= CDec(DrgServicosAtendimento.CurrentRow.Cells(3).Value())
                _Atendimento.vnContaServicos -= 1
                mskTotal.Text = FormatNumber(_Atendimento.vnTotalServicos, 2, , TriState.True)
                DrgServicosAtendimento.Rows.Remove(DrgServicosAtendimento.CurrentRow)

            End If
        End If
    End Sub
    Private Sub BtnAdicionarServico_Click(sender As Object, e As EventArgs) Handles BtnAdicionarServico.Click
        InserirItemGrid()
        TxtServico.Focus()
    End Sub
    Private Sub MskValorServico_KeyDown(sender As Object, e As KeyEventArgs) Handles MskValorServico.KeyDown
        Dim KeyCode As Short = e.KeyCode
        If KeyCode = System.Windows.Forms.Keys.Return Then
            InserirItemGrid()
            TxtServico.Focus()
        End If
    End Sub

    Private Sub mskValorServico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MskValorServico.KeyPress
        If e.KeyChar = "." Then
            If InStr(MskValorServico.Text, ",") Then e.Handled = True
            e.KeyChar = ","
        ElseIf Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack And Not e.KeyChar = "," Then
            e.Handled = True
        ElseIf e.KeyChar = "," And InStr(MskValorServico.Text, ",") Then
            e.Handled = True
        End If
    End Sub
    Private Sub mskValorServico_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskValorServico.GotFocus
        MskValorServico.SelectionLength = MskValorServico.TextLength
    End Sub
    Private Sub TxtServico_DoubleClick(sender As Object, e As EventArgs) Handles TxtServico.DoubleClick
        FrmPesquisaGenerica.txtFiltro.Text = TxtServico.Text
        FrmPesquisaGenerica.Show()
    End Sub
    Private Sub MskValorServico_LostFocus(sender As Object, e As EventArgs) Handles MskValorServico.LostFocus
        If MskValorServico.Text <> "" Then MskValorServico.Text = FormatNumber(MskValorServico.Text, 2, , TriState.True)
    End Sub
    Private Sub mskTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskTotal.KeyPress
        e.KeyChar = ""
    End Sub
End Class




