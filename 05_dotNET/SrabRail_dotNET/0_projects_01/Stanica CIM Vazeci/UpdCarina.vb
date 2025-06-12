Imports System.Data.SqlClient
Public Class UpdCarina
    Inherits System.Windows.Forms.Form
    Public otRecID As Int32

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbSatVoza As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents tbTrasaVoza As System.Windows.Forms.TextBox
    Friend WithEvents DatumUlaza As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbJCI As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UpdCarina))
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbSatVoza = New System.Windows.Forms.TextBox
        Me.tbTrasaVoza = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.DatumUlaza = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbJCI = New System.Windows.Forms.TextBox
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(192, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Sat voza"
        '
        'tbSatVoza
        '
        Me.tbSatVoza.Location = New System.Drawing.Point(194, 48)
        Me.tbSatVoza.MaxLength = 2
        Me.tbSatVoza.Name = "tbSatVoza"
        Me.tbSatVoza.TabIndex = 1
        Me.tbSatVoza.Text = ""
        '
        'tbTrasaVoza
        '
        Me.tbTrasaVoza.Location = New System.Drawing.Point(88, 48)
        Me.tbTrasaVoza.MaxLength = 5
        Me.tbTrasaVoza.Name = "tbTrasaVoza"
        Me.tbTrasaVoza.TabIndex = 0
        Me.tbTrasaVoza.Text = ""
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'DatumUlaza
        '
        Me.DatumUlaza.Location = New System.Drawing.Point(88, 104)
        Me.DatumUlaza.Name = "DatumUlaza"
        Me.DatumUlaza.Size = New System.Drawing.Size(208, 20)
        Me.DatumUlaza.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(88, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Trasa voza"
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(333, 438)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 2
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(88, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 23)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Izaberite datum za koji se pravi izvestaj"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbJCI)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(104, 240)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 184)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ CARINA ] "
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(208, 120)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 52)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Upis u bazu"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 21)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Rok carinjenja"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 21)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Datum od"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 21)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "MRN broj"
        '
        'tbJCI
        '
        Me.tbJCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbJCI.Location = New System.Drawing.Point(157, 23)
        Me.tbJCI.MaxLength = 18
        Me.tbJCI.Name = "tbJCI"
        Me.tbJCI.Size = New System.Drawing.Size(144, 23)
        Me.tbJCI.TabIndex = 0
        Me.tbJCI.Text = "  "
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker2.Location = New System.Drawing.Point(157, 87)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(144, 22)
        Me.DateTimePicker2.TabIndex = 2
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker1.Location = New System.Drawing.Point(157, 55)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(144, 22)
        Me.DateTimePicker1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPrihvati)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DatumUlaza)
        Me.GroupBox2.Controls.Add(Me.tbTrasaVoza)
        Me.GroupBox2.Controls.Add(Me.tbSatVoza)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(104, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 224)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ VOZ ] "
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(208, 160)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 48)
        Me.btnPrihvati.TabIndex = 3
        Me.btnPrihvati.Text = "Pronadji"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'UpdCarina
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(442, 512)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdCarina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UpdCarina"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbTrasaVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbSatVoza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSatVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DatumIzvestaja_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumUlaza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btn165_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'pozvati grid kao iz korekcije
    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim mRetVal As String
        Dim mTrasaVoza, mSatVoza As String
        Dim mDatumVoza As Date

        mTrasaVoza = tbTrasaVoza.Text
        mSatVoza = tbSatVoza.Text
        mDatumVoza = DatumUlaza.Value.ToShortDateString

        UpdRecID = 0

        NadjiTrasu(Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), CType(mTrasaVoza, Int32), mSatVoza, mDatumVoza, UpdRecID, _
                   mRetVal)

        otRecID = UpdRecID

        If mRetVal = "" Then
            Me.GroupBox1.Enabled = True
            Me.tbJCI.Focus()
        Else
            Me.GroupBox1.Enabled = False
            MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbTrasaVoza.Focus()
        End If

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim slogTrans As SqlTransaction
        Dim updJCI As String
        Dim updDatum1, updDatum2 As Date
        Dim mRetVal As String

        updJCI = tbJCI.Text
        updDatum1 = Me.DateTimePicker1.Value.ToShortDateString
        updDatum2 = Me.DateTimePicker2.Value.ToShortDateString

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        slogTrans = DbVeza.BeginTransaction()

        If updDatum1 >= updDatum2 Then
            MsgBox("Datumi nisu uskladjeni! Datum roka carinjenja mora biti veci od dana prijavljivanja Carini.")
            mRetVal = "Greska"
        Else
            UpdateJCIVoz(slogTrans, CType(tbTrasaVoza.Text, Int32), Me.tbSatVoza.Text, DatumUlaza.Value.ToShortDateString, _
                         updJCI, updDatum1, updDatum2, mRetVal)
        End If


        If mRetVal = "" Then
            Me.GroupBox1.Enabled = False
            slogTrans.Commit()
        Else
            If mRetVal = "Greska" Then

            Else
                MessageBox.Show("Neuspesan upis u bazu! Pokusajte ponovo.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            slogTrans.Rollback()
        End If

        DbVeza.Close()
        Me.tbTrasaVoza.Focus()

    End Sub

    Private Sub tbJCI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbJCI.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DateTimePicker1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

   
End Class
