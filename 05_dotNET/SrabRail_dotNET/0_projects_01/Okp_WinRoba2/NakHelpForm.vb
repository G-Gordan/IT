Imports System.Data.SqlClient
Public Class NakHelpForm
    Inherits System.Windows.Forms.Form
    Public dsNak1 As New DataSet
    Public dtNak1 As DataTable = New DataTable("dtNak1")

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
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold)
        Me.DataGrid1.CaptionText = "Izbor naknade"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 400
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(1024, 208)
        Me.DataGrid1.TabIndex = 0
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "SuperGrid"
        '
        'NakHelpForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(1024, 208)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NakHelpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub NakHelpForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''vazeca verzija!
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        dsNak1.Tables.Add(New DataTable("dtNak1"))

        Dim iiRowsAffected As Int32

        Dim nmStringNak As String = ""
        If (mDatumKalk >= (#1/15/2015#)) Then ' NOVI
            nmStringNak = "SELECT Naziv, Iznos1 From ZsNaknade " _
                        & "WHERE (Sifra = '" & bSifraNaknade & "')" & " AND (IvicniBroj = '" & bIvicniBroj & "')" _
                        & " AND (SifraVS = 0) AND (SifraValute = '17') " & " AND (Tarifa = '36')"
        Else
            nmStringNak = "SELECT Naziv, Iznos1 From ZsNaknade " _
                        & "WHERE (Sifra = '" & bSifraNaknade & "')" & " AND (IvicniBroj = '" & bIvicniBroj & "')" _
                        & " AND (SifraVS = " & CInt(IzborSaobracaja) & ") AND (SifraValute = '17') " & " AND (Tarifa = '36')"
        End If

        Dim adNakHelp As New SqlDataAdapter(nmStringNak, DbVeza)

        'Dim adNakHelp As New SqlDataAdapter("SELECT Naziv, Iznos1 From ZsNaknade " _
        '                                  & "WHERE (Sifra = '" & bSifraNaknade & "')" & " AND (IvicniBroj = '" & bIvicniBroj & "')" _
        '                                  & " AND (SifraVS = '" & IzborSaobracaja & "')" & " AND (Tarifa = '36')", DbVeza)
        iiRowsAffected = adNakHelp.Fill(dsNak1, "dtNak1")

        'If mTarifa = "68" Then
        '    Dim adNakHelp As New SqlDataAdapter("SELECT Naziv, Iznos1 From ZsNaknade " _
        '                                      & "WHERE (Sifra = '" & bSifraNaknade & "')" & " AND (IvicniBroj = '" & bIvicniBroj & "')" _
        '                                      & " AND (SifraVS = '" & IzborSaobracaja & "')" & " AND (Tarifa = '36')", DbVeza)
        '    iiRowsAffected = adNakHelp.Fill(dsNak1, "dtNak1")
        'Else
        '    Dim adNakHelp As New SqlDataAdapter("SELECT Naziv, Iznos1 From ZsNaknade " _
        '                                      & "WHERE (Sifra = '" & bSifraNaknade & "')" & " AND (IvicniBroj = '" & bIvicniBroj & "')" _
        '                                      & " AND (SifraVS = '" & IzborSaobracaja & "')" & " AND (Tarifa = '" & mTarifa & "')", DbVeza)
        '    iiRowsAffected = adNakHelp.Fill(dsNak1, "dtNak1")
        'End If

        Dim dvNak1 As DataView = dsNak1.Tables("dtNak1").DefaultView
        DataGrid1.DataSource = dvNak1
        DbVeza.Close()

        ''end vazeca verzija!
    End Sub

    Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'naziv
        mIzlaz3 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'iznos

        Close()
    End Sub
End Class
