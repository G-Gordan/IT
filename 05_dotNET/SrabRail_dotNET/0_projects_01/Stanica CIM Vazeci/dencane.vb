Imports System.Data.SqlClient
Public Class Dencane
    Inherits System.Windows.Forms.Form
    Dim dsDencane As DataSet
    Public dvDencane As New DataView(dtDencane)

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
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgDencane As System.Windows.Forms.DataGrid
    Friend WithEvents tbDenMasa As System.Windows.Forms.TextBox
    Friend WithEvents btnDenTarifa As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbDenTip As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDodajDen As System.Windows.Forms.Button
    Friend WithEvents btnBrisiDen As System.Windows.Forms.Button
    Friend WithEvents btnIzmeniDen As System.Windows.Forms.Button
    Friend WithEvents tbDenTarifa As System.Windows.Forms.TextBox
    Friend WithEvents numDenKomada As System.Windows.Forms.NumericUpDown
    Friend WithEvents tbDenIznos As System.Windows.Forms.TextBox
    Friend WithEvents tbDenValuta As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbDenRMasa As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Dencane))
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.tbDenRMasa = New System.Windows.Forms.TextBox
        Me.tbDenIznos = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.numDenKomada = New System.Windows.Forms.NumericUpDown
        Me.tbDenTip = New System.Windows.Forms.TextBox
        Me.tbDenTarifa = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnDodajDen = New System.Windows.Forms.Button
        Me.btnBrisiDen = New System.Windows.Forms.Button
        Me.btnIzmeniDen = New System.Windows.Forms.Button
        Me.dgDencane = New System.Windows.Forms.DataGrid
        Me.tbDenMasa = New System.Windows.Forms.TextBox
        Me.btnDenTarifa = New System.Windows.Forms.Button
        Me.tbDenValuta = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.numDenKomada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDencane, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(912, 584)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 2
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.tbDenRMasa)
        Me.GroupBox1.Controls.Add(Me.tbDenIznos)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.numDenKomada)
        Me.GroupBox1.Controls.Add(Me.tbDenTip)
        Me.GroupBox1.Controls.Add(Me.tbDenTarifa)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnDodajDen)
        Me.GroupBox1.Controls.Add(Me.btnBrisiDen)
        Me.GroupBox1.Controls.Add(Me.btnIzmeniDen)
        Me.GroupBox1.Controls.Add(Me.dgDencane)
        Me.GroupBox1.Controls.Add(Me.tbDenMasa)
        Me.GroupBox1.Controls.Add(Me.btnDenTarifa)
        Me.GroupBox1.Controls.Add(Me.tbDenValuta)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(320, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(680, 544)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ Dencane posiljke ] "
        '
        'Label5
        '
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(304, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 15)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Racunska masa"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(424, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 23)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "[ kg ]"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(232, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 23)
        Me.Label15.TabIndex = 64
        Me.Label15.Text = "[ kg ]"
        '
        'tbDenRMasa
        '
        Me.tbDenRMasa.Enabled = False
        Me.tbDenRMasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbDenRMasa.Location = New System.Drawing.Point(302, 35)
        Me.tbDenRMasa.MaxLength = 5
        Me.tbDenRMasa.Name = "tbDenRMasa"
        Me.tbDenRMasa.Size = New System.Drawing.Size(120, 21)
        Me.tbDenRMasa.TabIndex = 63
        Me.tbDenRMasa.Text = "0"
        Me.tbDenRMasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbDenIznos
        '
        Me.tbDenIznos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbDenIznos.Location = New System.Drawing.Point(104, 185)
        Me.tbDenIznos.MaxLength = 5
        Me.tbDenIznos.Name = "tbDenIznos"
        Me.tbDenIznos.Size = New System.Drawing.Size(120, 21)
        Me.tbDenIznos.TabIndex = 4
        Me.tbDenIznos.Text = "0"
        Me.tbDenIznos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Iznos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numDenKomada
        '
        Me.numDenKomada.Location = New System.Drawing.Point(168, 147)
        Me.numDenKomada.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numDenKomada.Name = "numDenKomada"
        Me.numDenKomada.Size = New System.Drawing.Size(56, 20)
        Me.numDenKomada.TabIndex = 3
        Me.numDenKomada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numDenKomada.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'tbDenTip
        '
        Me.tbDenTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDenTip.Location = New System.Drawing.Point(168, 109)
        Me.tbDenTip.Name = "tbDenTip"
        Me.tbDenTip.Size = New System.Drawing.Size(56, 21)
        Me.tbDenTip.TabIndex = 2
        Me.tbDenTip.Text = "0"
        Me.tbDenTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbDenTarifa
        '
        Me.tbDenTarifa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbDenTarifa.Location = New System.Drawing.Point(104, 71)
        Me.tbDenTarifa.MaxLength = 5
        Me.tbDenTarifa.Name = "tbDenTarifa"
        Me.tbDenTarifa.Size = New System.Drawing.Size(120, 21)
        Me.tbDenTarifa.TabIndex = 1
        Me.tbDenTarifa.Text = "0"
        Me.tbDenTarifa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 23)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Masa"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDodajDen
        '
        Me.btnDodajDen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnDodajDen.Image = CType(resources.GetObject("btnDodajDen.Image"), System.Drawing.Image)
        Me.btnDodajDen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDodajDen.Location = New System.Drawing.Point(280, 477)
        Me.btnDodajDen.Name = "btnDodajDen"
        Me.btnDodajDen.Size = New System.Drawing.Size(62, 48)
        Me.btnDodajDen.TabIndex = 6
        Me.btnDodajDen.Text = "Dodaj"
        Me.btnDodajDen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnBrisiDen
        '
        Me.btnBrisiDen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnBrisiDen.Image = CType(resources.GetObject("btnBrisiDen.Image"), System.Drawing.Image)
        Me.btnBrisiDen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrisiDen.Location = New System.Drawing.Point(360, 477)
        Me.btnBrisiDen.Name = "btnBrisiDen"
        Me.btnBrisiDen.Size = New System.Drawing.Size(62, 48)
        Me.btnBrisiDen.TabIndex = 7
        Me.btnBrisiDen.Text = "Brisi"
        Me.btnBrisiDen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnIzmeniDen
        '
        Me.btnIzmeniDen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIzmeniDen.Image = CType(resources.GetObject("btnIzmeniDen.Image"), System.Drawing.Image)
        Me.btnIzmeniDen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIzmeniDen.Location = New System.Drawing.Point(280, 477)
        Me.btnIzmeniDen.Name = "btnIzmeniDen"
        Me.btnIzmeniDen.Size = New System.Drawing.Size(62, 48)
        Me.btnIzmeniDen.TabIndex = 7
        Me.btnIzmeniDen.Text = "Izmeni"
        Me.btnIzmeniDen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIzmeniDen.Visible = False
        '
        'dgDencane
        '
        Me.dgDencane.DataMember = ""
        Me.dgDencane.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.dgDencane.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDencane.Location = New System.Drawing.Point(11, 232)
        Me.dgDencane.Name = "dgDencane"
        Me.dgDencane.Size = New System.Drawing.Size(656, 232)
        Me.dgDencane.TabIndex = 16
        '
        'tbDenMasa
        '
        Me.tbDenMasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbDenMasa.Location = New System.Drawing.Point(104, 36)
        Me.tbDenMasa.MaxLength = 5
        Me.tbDenMasa.Name = "tbDenMasa"
        Me.tbDenMasa.Size = New System.Drawing.Size(120, 21)
        Me.tbDenMasa.TabIndex = 0
        Me.tbDenMasa.Text = "0"
        Me.tbDenMasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDenTarifa
        '
        Me.btnDenTarifa.Location = New System.Drawing.Point(16, 71)
        Me.btnDenTarifa.Name = "btnDenTarifa"
        Me.btnDenTarifa.Size = New System.Drawing.Size(75, 24)
        Me.btnDenTarifa.TabIndex = 34
        Me.btnDenTarifa.Text = "Tarifa"
        '
        'tbDenValuta
        '
        Me.tbDenValuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbDenValuta.Location = New System.Drawing.Point(302, 185)
        Me.tbDenValuta.Name = "tbDenValuta"
        Me.tbDenValuta.Size = New System.Drawing.Size(56, 21)
        Me.tbDenValuta.TabIndex = 5
        Me.tbDenValuta.Text = "17"
        Me.tbDenValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 19)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Komada"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(235, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Valuta"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tip"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(808, 584)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 1
        Me.btnPrihvati.Text = "Prihvati  [ F12 ]"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Dencane
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 746)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Name = "Dencane"
        Me.Text = "Dencane"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.numDenKomada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDencane, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub FormatDenGrid()
        'Col1.AutoIncrement = True
        'Col1.ReadOnly = True
        If dsDencane Is Nothing Then
            dgDencane.DataSource = dtDencane
        Else
            dgDencane.DataSource = dsDencane.Tables(0)
        End If
    End Sub

    Private Sub tbDenMasa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDenMasa.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbDenTip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDenTip.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbIznosNak_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDenValuta.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbDenTarifa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDenTarifa.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub numDenKomada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numDenKomada.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbDenIznos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDenIznos.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub btnDodajDen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodajDen.Click

        Dim dtRow As DataRow = dtDencane.NewRow
        dtDencane.Rows.Add(New Object() {CType(tbDenMasa.Text, Int32), CType(tbDenMasa.Text, Int32), tbDenTarifa.Text, CType(tbDenTip.Text, Int32), CType(numDenKomada.Text, Int32), CType(tbDenIznos.Text, Decimal), tbDenValuta.Text, "I"})

        dgDencane.Refresh()
        Me.tbDenMasa.Clear()
        Me.tbDenRMasa.Clear()
        Me.tbDenTarifa.Clear()
        Me.tbDenTip.Clear()
        Me.numDenKomada.Value = 1
        Me.tbDenIznos.Text = ""
        Me.tbDenValuta.Clear()

        Me.tbDenMasa.Focus()

    End Sub

    Private Sub btnIzmeniDen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzmeniDen.Click
        Me.btnDodajDen.Visible = True
        Me.btnIzmeniDen.Visible = False

        Dim row As Data.DataRow
        row = CType(dgDencane.DataSource, DataTable).Rows(dgDencane.CurrentCell.RowNumber)

        row("SMasa") = Me.tbDenMasa.Text
        row("RMasa") = Me.tbDenMasa.Text
        row("Tarifa") = Me.tbDenTarifa.Text
        row("Tip") = tbDenTip.Text
        row("Komada") = numDenKomada.Text
        row("Iznos") = tbDenIznos.Text
        row("Valuta") = tbDenValuta.Text

        If MasterAction = "New" Then
            row("Action") = "I"
        Else
            row("Action") = "U"
        End If

        dgDencane.Refresh()

        Me.tbDenMasa.Clear()
        Me.tbDenRMasa.Clear()
        Me.tbDenTarifa.Clear()
        Me.tbDenTip.Clear()
        Me.numDenKomada.Value = 1
        Me.tbDenIznos.Text = ""
        Me.tbDenValuta.Clear()

        Me.tbDenMasa.Focus()

    End Sub

    Private Sub btnBrisiDen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrisiDen.Click
        If MasterAction = "New" Then
            Try
                CType(dgDencane.DataSource, DataTable).Rows(dgDencane.CurrentCell.RowNumber).Delete()
            Catch ex As Exception
                MsgBox(ex, MsgBoxStyle.Critical)
            Finally
                Me.tbDenMasa.Clear()
                Me.tbDenRMasa.Clear()
                Me.tbDenTarifa.Clear()
                Me.tbDenTip.Clear()
                Me.numDenKomada.Value = 1
                Me.tbDenIznos.Text = ""
                Me.tbDenValuta.Clear()

                Me.tbDenMasa.Focus()
            End Try
        Else
            Try
                Dim rowDen As Data.DataRow

                rowDen = CType(dgDencane.DataSource, DataTable).Rows(dgDencane.CurrentCell.RowNumber)
                rowDen = dtNaknade.Rows(dgDencane.CurrentCell.RowNumber)
                rowDen("Action") = "D"

                dvDencane.RowFilter = "Action LIKE 'U'"
                dgDencane.DataSource = dvDencane
                dgDencane.Refresh()

            Catch ex As Exception
            Finally
                dgDencane.Refresh()

                Me.tbDenMasa.Clear()
                Me.tbDenTarifa.Clear()
                Me.tbDenTip.Clear()
                Me.numDenKomada.Value = 1
                Me.tbDenIznos.Text = ""
                Me.tbDenValuta.Clear()

                Me.tbDenMasa.Focus()


                Me.btnIzmeniDen.Visible = False
                Me.btnDodajDen.Visible = True

            End Try
        End If

    End Sub

    Private Sub Dencane_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatDenGrid()
        tbDenMasa.Focus()
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        dtDencane.Clear()
        Close()
    End Sub

    Private Sub dgDencane_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDencane.Click
        Me.btnDodajDen.Visible = False
        Me.btnIzmeniDen.Visible = True

        Dim currRow As DataRow
        currRow = CType(dgDencane.DataSource, DataTable).Rows(dgDencane.CurrentCell.RowNumber)

        tbDenMasa.Text = currRow(0, DataRowVersion.Current).ToString()
        tbDenTarifa.Text = currRow(1, DataRowVersion.Current).ToString()
        tbDenTip.Text = currRow(2, DataRowVersion.Current).ToString()
        numDenKomada.Value = currRow(3, DataRowVersion.Current).ToString()
        tbDenIznos.Text = currRow(4, DataRowVersion.Current).ToString()
        tbDenValuta.Text = currRow(5, DataRowVersion.Current).ToString()

    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Close()
    End Sub
End Class
