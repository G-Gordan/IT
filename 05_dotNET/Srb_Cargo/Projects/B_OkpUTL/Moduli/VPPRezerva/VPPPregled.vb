Imports System.Data.SqlClient
Public Class VPPPregled
    Inherits System.Windows.Forms.Form
    Dim dsVPP72_2 As New DataSet("dsVPP72_2")
    Dim bSifraVPP As Integer = 0
    Dim bbSkm As Integer = 0
    Dim bbTkm As Integer = 0
    Dim bbOpisVPP As String = ""

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
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VPPPregled))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Maroon
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Verdana", 9.0!)
        Me.DataGrid1.CaptionText = "Prevozni put"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 88)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 110
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(304, 200)
        Me.DataGrid1.TabIndex = 1
        '
        'DataGrid2
        '
        Me.DataGrid2.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid2.CaptionBackColor = System.Drawing.Color.Maroon
        Me.DataGrid2.CaptionFont = New System.Drawing.Font("Verdana", 9.0!)
        Me.DataGrid2.CaptionText = "Opis prevoznog puta"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(344, 8)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.PreferredColumnWidth = 180
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.Size = New System.Drawing.Size(216, 288)
        Me.DataGrid2.TabIndex = 2
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(344, 304)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 8
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOK.Location = New System.Drawing.Point(48, 304)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(96, 65)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "Prihvati"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(344, 8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(216, 277)
        Me.ListBox1.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(112, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(112, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 16)
        Me.Label3.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Uputna stanica"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Otpravna stanica"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(200, 304)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 64)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Izbor novog prevoznog puta"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'VPPPregled
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 390)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "VPPPregled"
        Me.Text = "Vanredni prevozni putevi"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub
    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        dsVPP72_2.Clear()
        bSifraVPP = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
        bbSkm = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
        bbTkm = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

        Dim ii2 As Int32 = 0
        Dim string2 As String = ""
        Dim NizNaziva As String

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        string2 = "SELECT OpisVPP " & _
                    " FROM dbo.Dalj_VPP " & _
                    " WHERE (SifraVPP = '" & bSifraVPP & "')"


        Dim ad2 As New SqlDataAdapter(string2, DbVeza)

        '        ii2 = ad2.Fill(dsNajave2)

        Try
            ii2 = ad2.Fill(dsVPP72_2)

            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            DataGrid2.DataSource = dsVPP72_2.Tables(0)

            Dim k As Int16
            Dim DuzinaPP As Int16 = 0
            Dim mObjekat As Object
            Dim PPCvor(29) As String
            Dim PPCvorNaziv(29) As String
            Dim bbPP As String = ""
            Dim bbPPNazivi As String = ""
            Dim PovVr As String

            bbPP = RTrim(DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 0))

            bbOpisVPP = bbPP ' ( za posle )

            bNadjiNizNazivaSt72L(bbPP, bbPPNazivi, PovVr)

            For k = 0 To 29
                PPCvor(k) = ""
                PPCvorNaziv(k) = ""
            Next

            DuzinaPP = Microsoft.VisualBasic.Len(bbPP) / 5      ' broj raskrsca - cvornih stanicana na PP

            Me.ListBox1.Items.Clear()
            For k = 0 To DuzinaPP - 1
                PPCvor(k) = Microsoft.VisualBasic.Mid(bbPP, (k + 1) * 5 - 4, 5)
                PPCvorNaziv(k) = Microsoft.VisualBasic.Mid(bbPPNazivi, (k + 1) * 20 - 19, 20)
                mObjekat = "  " & PPCvor(k) & "  " & PPCvorNaziv(k)
                Me.ListBox1.Items.Add(mObjekat)

            Next




        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub VPPPregled_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ii1 As Int32 = 0
        Dim dsVPP72_1 As New DataSet("dsVPP72_1")
        Dim string1 As String = ""
        Dim Povrvrednost As String

        bNadjiNazivStanice72L(mStanica1, bNazivStanice1, PovrVrednost)
        bNadjiNazivStanice72L(mStanica2, bNazivStanice2, PovrVrednost)

        Me.Label3.Text = mStanica1.ToString + " " + bNazivStanice1.ToString
        Me.Label4.Text = mStanica2.ToString + " " + bNazivStanice2.ToString



        string1 = "SELECT     SifraVPP, Skm, Tkm " & _
                        "FROM   Dalj_VPP " & _
                        "WHERE  (Stanica1 = '" & mStanica1 & "') And (Stanica2 = '" & mStanica2 & "')"


        Dim ad1 As New SqlDataAdapter(string1, DbVeza)

        ii1 = ad1.Fill(dsVPP72_1)

        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            DataGrid1.DataSource = dsVPP72_1.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try


    End Sub
    Public Sub bPotraziVPP(ByVal inStanica1 As String, ByVal inStanica2 As String, ByRef outDaNe As Boolean)
        Dim ii1 As Int32 = 0
        Dim dsVPP72_1 As New DataSet("dsVPP72_1")
        Dim string1 As String = "SELECT     SifraVPP, Skm, Tkm " & _
                                "FROM Dalj_VPP " & _
                                "WHERE (Stanica1 = '" & mStanica1 & " ') And (Stanica2 = '" & mStanica2 & "')"

        Dim ad1 As New SqlDataAdapter(string1, DbVeza)
        outDaNe = False

        ii1 = ad1.Fill(dsVPP72_1)

        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            DataGrid1.DataSource = dsVPP72_1.Tables(0)
            outDaNe = True

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Finally
            DbVeza.Close()

        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        bSkm = bbSkm
        bTkm = bbTkm
        'PrevozniPut = bSifraVPP

        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        bPP = ""
        Dim VPPForma As New VPP
        Me.Close()
        VPPForma.ShowDialog()

    End Sub
End Class

