
Public Class Form1
    Inherits System.Windows.Forms.Form
    Public OtpravnaUprava As String
    Public OtpravniBroj As Integer
    Public Datum As Date
    Public OtpravnaStanica As String
    Public RecID As Integer
    Public Stanica As String
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOtpravniBroj As System.Windows.Forms.TextBox
    Friend WithEvents dtpDatum As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOtpravna As System.Windows.Forms.TextBox
    Friend WithEvents txtOtpUprava As System.Windows.Forms.TextBox
    Friend WithEvents btnRecID As System.Windows.Forms.Button
    Friend WithEvents con As System.Data.SqlClient.SqlConnection
    Friend WithEvents daRecID As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents cmdRecID As System.Data.SqlClient.SqlCommand
    Friend WithEvents DsRecID1 As BrisanjeSlogova.DsRecID
    Friend WithEvents lblRecID As System.Windows.Forms.Label
    Friend WithEvents lblStanica As System.Windows.Forms.Label
    Friend WithEvents btnObrisi As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtOtpUprava = New System.Windows.Forms.TextBox
        Me.txtOtpravniBroj = New System.Windows.Forms.TextBox
        Me.dtpDatum = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnRecID = New System.Windows.Forms.Button
        Me.txtOtpravna = New System.Windows.Forms.TextBox
        Me.con = New System.Data.SqlClient.SqlConnection
        Me.daRecID = New System.Data.SqlClient.SqlDataAdapter
        Me.cmdRecID = New System.Data.SqlClient.SqlCommand
        Me.DsRecID1 = New BrisanjeSlogova.DsRecID
        Me.lblRecID = New System.Windows.Forms.Label
        Me.lblStanica = New System.Windows.Forms.Label
        Me.btnObrisi = New System.Windows.Forms.Button
        CType(Me.DsRecID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtOtpUprava
        '
        Me.txtOtpUprava.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtpUprava.Location = New System.Drawing.Point(8, 32)
        Me.txtOtpUprava.MaxLength = 4
        Me.txtOtpUprava.Name = "txtOtpUprava"
        Me.txtOtpUprava.Size = New System.Drawing.Size(96, 22)
        Me.txtOtpUprava.TabIndex = 1
        Me.txtOtpUprava.Text = ""
        Me.txtOtpUprava.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOtpravniBroj
        '
        Me.txtOtpravniBroj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtpravniBroj.Location = New System.Drawing.Point(256, 32)
        Me.txtOtpravniBroj.MaxLength = 4
        Me.txtOtpravniBroj.Name = "txtOtpravniBroj"
        Me.txtOtpravniBroj.Size = New System.Drawing.Size(104, 22)
        Me.txtOtpravniBroj.TabIndex = 3
        Me.txtOtpravniBroj.Text = ""
        Me.txtOtpravniBroj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpDatum
        '
        Me.dtpDatum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpDatum.Location = New System.Drawing.Point(368, 32)
        Me.dtpDatum.Name = "dtpDatum"
        Me.dtpDatum.Size = New System.Drawing.Size(112, 22)
        Me.dtpDatum.TabIndex = 4
        Me.dtpDatum.Value = New Date(2006, 9, 27, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Otp. uprava"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(112, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Otpravna stanica"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(256, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Otpravni broj"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(368, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Otpravni datum"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label11.Location = New System.Drawing.Point(488, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 23)
        Me.Label11.TabIndex = 5
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRecID
        '
        Me.btnRecID.Location = New System.Drawing.Point(16, 88)
        Me.btnRecID.Name = "btnRecID"
        Me.btnRecID.Size = New System.Drawing.Size(128, 32)
        Me.btnRecID.TabIndex = 6
        Me.btnRecID.Text = "RecID"
        '
        'txtOtpravna
        '
        Me.txtOtpravna.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtpravna.Location = New System.Drawing.Point(112, 32)
        Me.txtOtpravna.MaxLength = 7
        Me.txtOtpravna.Name = "txtOtpravna"
        Me.txtOtpravna.Size = New System.Drawing.Size(136, 22)
        Me.txtOtpravna.TabIndex = 2
        Me.txtOtpravna.Text = ""
        Me.txtOtpravna.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'con
        '
        Me.con.ConnectionString = "packet size=4096;data source=10.0.4.31;persist security info=False;initial catalo" & _
        "g=WinRoba;user=Radnik;password=roba2006"
        '
        'daRecID
        '
        Me.daRecID.SelectCommand = Me.cmdRecID
        Me.daRecID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "SlogKalk", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecID", "RecID"), New System.Data.Common.DataColumnMapping("Stanica", "Stanica")})})
        '
        'cmdRecID
        '
        Me.cmdRecID.CommandText = "[spRecID]"
        Me.cmdRecID.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmdRecID.Connection = Me.con
        Me.cmdRecID.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmdRecID.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OtUprava", System.Data.SqlDbType.VarChar, 4, "OtpUprava"))
        Me.cmdRecID.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OtStanica", System.Data.SqlDbType.VarChar, 7, "OtpStanica"))
        Me.cmdRecID.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OtBroj", System.Data.SqlDbType.Int, 4, "OtpBroj"))
        Me.cmdRecID.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OtDatum", System.Data.SqlDbType.DateTime, 8, "OtpDatum"))
        '
        'DsRecID1
        '
        Me.DsRecID1.DataSetName = "DsRecID"
        Me.DsRecID1.Locale = New System.Globalization.CultureInfo("sr-SP-Latn")
        '
        'lblRecID
        '
        Me.lblRecID.Location = New System.Drawing.Point(184, 72)
        Me.lblRecID.Name = "lblRecID"
        Me.lblRecID.Size = New System.Drawing.Size(120, 32)
        Me.lblRecID.TabIndex = 7
        Me.lblRecID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStanica
        '
        Me.lblStanica.Location = New System.Drawing.Point(312, 72)
        Me.lblStanica.Name = "lblStanica"
        Me.lblStanica.Size = New System.Drawing.Size(136, 32)
        Me.lblStanica.TabIndex = 8
        Me.lblStanica.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnObrisi
        '
        Me.btnObrisi.Location = New System.Drawing.Point(16, 136)
        Me.btnObrisi.Name = "btnObrisi"
        Me.btnObrisi.Size = New System.Drawing.Size(128, 32)
        Me.btnObrisi.TabIndex = 9
        Me.btnObrisi.Text = "Obrisi"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(616, 413)
        Me.Controls.Add(Me.btnObrisi)
        Me.Controls.Add(Me.lblStanica)
        Me.Controls.Add(Me.lblRecID)
        Me.Controls.Add(Me.txtOtpravna)
        Me.Controls.Add(Me.btnRecID)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDatum)
        Me.Controls.Add(Me.txtOtpravniBroj)
        Me.Controls.Add(Me.txtOtpUprava)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.Text = "Brisanje"
        CType(Me.DsRecID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub txtOtpUprava_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtpUprava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If txtOtpUprava.Text = " " Then
                MessageBox.Show("Unesite broj otpravne uprave!")
                txtOtpUprava.Focus()

            Else
                If txtOtpUprava.TextLength < 4 Then
                    txtOtpUprava.SelectAll()
                    MessageBox.Show("Unesite sifru uprave sa 4 znaka!")
                    txtOtpUprava.Focus()
                Else
                    txtOtpravna.Focus()
                    OtpravnaUprava = txtOtpUprava.Text
                End If

            End If

        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtOtpravniBroj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtpravniBroj.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If txtOtpravniBroj.Text = " " Then
                MessageBox.Show("Unesite otpravni broj!")
                txtOtpravniBroj.Focus()

            Else
                On Error Resume Next
                OtpravniBroj = CInt(txtOtpravniBroj.Text)
                If Err.Number <> 0 Then
                    MessageBox.Show("Unesite korektnu vrednost za otpravn broj!")
                    txtOtpravniBroj.Focus()
                Else
                    dtpDatum.Focus()
                End If

            End If

        End If
    End Sub

    Private Sub dtpDatum_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDatum.ValueChanged
        Datum = dtpDatum.Value.Date
    End Sub

    Private Sub dtpDatum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpDatum.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            Datum = dtpDatum.Value.Date
            Label11.Text = CStr(Datum)
            btnRecID.Focus()
        End If
    End Sub

    Private Sub txtOtpravna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtpravna.KeyPress

        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If txtOtpravna.Text = " " Then
                MessageBox.Show("Unesite broj otpravne stanice!")
                txtOtpravna.Focus()

            Else
                If txtOtpravna.TextLength <> 7 Then
                    txtOtpravna.SelectAll()
                    MessageBox.Show("Unesite sifru stanice sa 7 znakova!")
                    txtOtpravna.Focus()
                Else
                    txtOtpravniBroj.Focus()
                    OtpravnaStanica = txtOtpravna.Text
                End If

            End If

        End If
    End Sub

    Private Sub btnRecID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecID.Click

        DsRecID1.Clear()
        con.Open()
        Try
            cmdRecID.Connection = con
            cmdRecID.Parameters("@OtUprava").Value = OtpravnaUprava
            cmdRecID.Parameters("@OtStanica").Value = OtpravnaStanica
            cmdRecID.Parameters("@OtBroj").Value = OtpravniBroj
            cmdRecID.Parameters("@OtDatum").Value = Datum
            daRecID.Fill(DsRecID1)

        Catch ex As Exception
            MessageBox.Show("ex" & " " & Err.Number & " " & Err.Description)
        End Try
        con.Close()

        Try
            RecID = CInt(DsRecID1.Tables(0).Rows(0).Item(0))
            Stanica = DsRecID1.Tables(0).Rows(0).Item(1)

        Catch ex1 As Exception
            MessageBox.Show("ex1" & " " & Err.Number & " " & Err.Description)
        End Try
        lblRecID.Text = "RecID " & RecID

        lblStanica.Text = "Stanica " & Stanica

        btnObrisi.Focus()
    End Sub

    Private Sub btnObrisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObrisi.Click

    End Sub
End Class
