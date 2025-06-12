Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class Form9
    Inherits System.Windows.Forms.Form
    Public Prikaz As String

    Dim Ugovorpom As Integer
    Dim Ugovorpom1 As Integer
    Dim i As Integer

    Protected Const GetAllradeSqlString As String = "SELECT RecID, Ugovor, Saobracaj, StanicaOd, StanicaDo, Osovine, VrstaPrevoza, VlasnistvoKola, VrstaKola, DatumOd, DatumDo, UslovZaStav, Iznos, TipCene, NP, NPTip, NPIznos, UserID FROM CoAneksi"
    Public Sub RefreshData()
        Dim connection As New SqlConnection(ConnectionString)
        SqlConnection1.Open()
        Dim adapter2 As New SqlDataAdapter(Prikaz, _
                           SqlConnection1)
        Dim dataset2 As New DataSet
        adapter2.Fill(dataset2)
        SqlConnection1.Close()
        Dim table2 As DataTable = dataset2.Tables(0)
        AddHandler table2.ColumnChanged, _
          New DataColumnChangeEventHandler(AddressOf ColumnChanged)
        DataGrid1.DataSource = table2
    End Sub

    Protected Sub ColumnChanged(ByVal sender As Object, _
ByVal e As DataColumnChangeEventArgs)
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents txtBrUgovora As System.Windows.Forms.TextBox
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents menuMain As System.Windows.Forms.MainMenu
    Friend WithEvents menuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.txtBrUgovora = New System.Windows.Forms.TextBox
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.menuMain = New System.Windows.Forms.MainMenu
        Me.menuRefresh = New System.Windows.Forms.MenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnPrihvati = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.DataGrid1.BackColor = System.Drawing.Color.DarkGray
        Me.DataGrid1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.White
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy
        Me.DataGrid1.CaptionText = "Aneksi ugovora"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.ForeColor = System.Drawing.Color.Black
        Me.DataGrid1.GridLineColor = System.Drawing.Color.Black
        Me.DataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver
        Me.DataGrid1.HeaderForeColor = System.Drawing.Color.Black
        Me.DataGrid1.LinkColor = System.Drawing.Color.Navy
        Me.DataGrid1.Location = New System.Drawing.Point(16, 72)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White
        Me.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black
        Me.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy
        Me.DataGrid1.SelectionForeColor = System.Drawing.Color.White
        Me.DataGrid1.Size = New System.Drawing.Size(968, 472)
        Me.DataGrid1.TabIndex = 1
        '
        'txtBrUgovora
        '
        Me.txtBrUgovora.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.txtBrUgovora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrUgovora.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.txtBrUgovora.Location = New System.Drawing.Point(16, 32)
        Me.txtBrUgovora.MaxLength = 6
        Me.txtBrUgovora.Name = "txtBrUgovora"
        Me.txtBrUgovora.Size = New System.Drawing.Size(144, 26)
        Me.txtBrUgovora.TabIndex = 0
        Me.txtBrUgovora.Text = ""
        Me.txtBrUgovora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=BGNEM11216XWSB;packet size=4096;user id=radnik;password=roba2006;d" & _
        "ata source=""10.0.4.31"";persist security info=False;initial catalog=OkpWinRoba"
        '
        'menuMain
        '
        Me.menuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuRefresh})
        '
        'menuRefresh
        '
        Me.menuRefresh.Index = 0
        Me.menuRefresh.Text = "     &Osvezi"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(56, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Ugovor broj"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btnPrihvati
        '
        Me.btnPrihvati.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrihvati.ForeColor = System.Drawing.Color.Black
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(896, 560)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 72)
        Me.btnPrihvati.TabIndex = 21
        Me.btnPrihvati.Text = "Izlaz"
        '
        'Form9
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(992, 643)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBrUgovora)
        Me.Controls.Add(Me.DataGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Menu = Me.menuMain
        Me.MinimizeBox = False
        Me.Name = "Form9"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pregled svih aneksa ugovora"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub txtBrUgovora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBrUgovora.KeyPress

        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))

            If txtBrUgovora.Text = "" Then
                MessageBox.Show("Nije unet isptavan broj ugovora! Ne može da bude ni blanko! - Unesite ponovo broj ugovora!")
                txtBrUgovora.Focus()
            Else
                Ugovorpom1 = txtBrUgovora.Text

                Dim intCounter1 As Integer
                Dim str1SQL As String
                Dim objCommand1 As SqlClient.SqlCommand
                Dim objDAA As SqlClient.SqlDataAdapter
                Dim objDSS As New Data.DataSet

                Ugovorpom = 0
                i = 0

                '-------------------------------------------------------------------------------------------
                'Poziva tabelu "Ugovori" pretrazuje je i uparuje unet broj ugovora sa brojevima ugovora u 
                'odgovarajucem polju tabele. Ako ne upari podatke vraca korisnika na ponovni unos broja
                'ugovora. Ako greskom ne unese broj ugovora a pritisne <Enter> takodje ga vraca na pnovni
                'unos.
                '-------------------------------------------------------------------------------------------
                str1SQL = "SELECT * FROM Ugovori"
                objCommand1 = New SqlClient.SqlCommand(str1SQL, New SqlClient.SqlConnection(ConnectionString))
                objCommand1.Connection.Open()
                objDAA = New SqlClient.SqlDataAdapter(str1SQL, ConnectionString)
                objDAA.Fill(objDSS)

                With objDSS.Tables(0)
                    For intCounter1 = 0 To .Rows.Count - 1
                        Ugovorpom = .Rows(intCounter1).Item("BrojUgovora")
                        If Ugovorpom = Ugovorpom1 Then
                            i = 1
                            Exit For
                        End If
                    Next
                End With
                If i = 0 Or txtBrUgovora.Text = "" Then
                    MessageBox.Show("Nije unet isptavan broj ugovora! Ne može da bude ni blanko! - Unesite ponovo broj ugovora!")
                    txtBrUgovora.Focus()
                Else
                    Prikaz = "SELECT RecID, Ugovor, Saobracaj, StanicaOd, StanicaDo, Osovine, VrstaPrevoza, VlasnistvoKola, VrstaKola, DatumOd, DatumDo, UslovZaStav, Iznos, TipCene, NP, NPTip, NPIznos, UserID FROM CoAneksi WHERE Ugovor = '" & txtBrUgovora.Text & "'"
                    RefreshData()
                End If
            End If
        End If
        
    End Sub

 

    Private Sub datagrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        PPRecID = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
        PPUgovor = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
        PPSaobracaj = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
        PPStanicaOd = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)
        PPStanicaDo = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)
        PPOsovine = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5)
        PPVrstaPrevoza = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6)
        PPVlasnistvoKola = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7)
        PPVrstaKola = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8)
        PPDatumOd = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 9)
        PPDatumDo = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 10)
        PPUslovZaStav = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 11)
        PPIznos = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 12)
        PPTipCene = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 13)
        PPNT = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 14)
        PPNPTip = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 15)
        PPNPIznos = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 16)
        'PPUserID = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 17)

        Dim Nova6 As New Form6
        Nova6.Show()

    End Sub

    Private Sub menuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRefresh.Click
        RefreshData()
    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Me.Dispose()

    End Sub
End Class
