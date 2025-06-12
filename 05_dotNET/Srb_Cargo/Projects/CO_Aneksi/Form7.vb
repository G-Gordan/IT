Public Class Form7
    Inherits System.Windows.Forms.Form
    Public SSS As String
    Public PPP As String
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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents menuCoAneksi As System.Windows.Forms.MenuItem
    Friend WithEvents menuCoAnekaiNoviUgovor As System.Windows.Forms.MenuItem
    Friend WithEvents menuIzlaz As System.Windows.Forms.MenuItem
    Friend WithEvents menuCoAneksiKorekcijeUgovora As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form7))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.menuCoAneksi = New System.Windows.Forms.MenuItem
        Me.menuCoAnekaiNoviUgovor = New System.Windows.Forms.MenuItem
        Me.menuCoAneksiKorekcijeUgovora = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.menuIzlaz = New System.Windows.Forms.MenuItem
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCoAneksi, Me.menuIzlaz})
        '
        'menuCoAneksi
        '
        Me.menuCoAneksi.Index = 0
        Me.menuCoAneksi.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCoAnekaiNoviUgovor, Me.menuCoAneksiKorekcijeUgovora, Me.MenuItem2, Me.MenuItem1})
        Me.menuCoAneksi.Text = "        Rad sa aneksima"
        '
        'menuCoAnekaiNoviUgovor
        '
        Me.menuCoAnekaiNoviUgovor.Index = 0
        Me.menuCoAnekaiNoviUgovor.Text = "    Unos novog aneksa za ugovor"
        '
        'menuCoAneksiKorekcijeUgovora
        '
        Me.menuCoAneksiKorekcijeUgovora.Index = 1
        Me.menuCoAneksiKorekcijeUgovora.Text = "    &Korekcija aneksa ugovora"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 2
        Me.MenuItem2.Text = "-"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 3
        Me.MenuItem1.Text = "    Izlaz iz programa"
        '
        'menuIzlaz
        '
        Me.menuIzlaz.Index = 1
        Me.menuIzlaz.Text = "    &Izlaz"
        '
        'Form7
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(848, 569)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "Form7"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aneksi ugovora po centralnom obracunu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

    End Sub

#End Region

  

    Private Sub menuCoAnekaiNoviUgovor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCoAnekaiNoviUgovor.Click
        'Poziva ekran sa elementima za azuriranje ugovora.
        '------------------------------------------------------------------------------------------
        Dim Nova3 As New Form3
        Nova3.ShowDialog()
    End Sub

    Private Sub menuIzlaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuIzlaz.Click
        Me.Dispose()
    End Sub

    Private Sub menuNHMPozicijePrikaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Poziva ekran sa prikazom NHM pozicija u DataGrid-u.
        '------------------------------------------------------------------------------------------
        Dim Nova5 As New Form5
        Nova5.Show()

    End Sub

    Private Sub menuCoAneksiKorekcijeUgovora_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCoAneksiKorekcijeUgovora.Click
        'Poziva ekran sa elementima ugovora. Mogu se menjati sva polja osim "RecId" i "Ugovor".
        '------------------------------------------------------------------------------------------
        Dim Nova9 As New Form9
        Nova9.Show()
    End Sub

    Private Sub menuIzmenaPoz_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Poziva ekran sa prikazom NHM pozicija gde je moguce vrsiti izmene i brisanje stavki.
        '------------------------------------------------------------------------------------------
        Dim Nova8 As New Form8
        Nova8.Show()
    End Sub


    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Close()

    End Sub

 
End Class
