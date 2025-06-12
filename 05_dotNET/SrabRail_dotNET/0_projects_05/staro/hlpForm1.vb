Imports System.Data.SqlClient

Public Class hlpForm1
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents dgContacts As System.Windows.Forms.DataGrid

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgContacts = New System.Windows.Forms.DataGrid
        CType(Me.dgContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgContacts
        '
        Me.dgContacts.DataMember = ""
        Me.dgContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgContacts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgContacts.Location = New System.Drawing.Point(0, 0)
        Me.dgContacts.Name = "dgContacts"
        Me.dgContacts.PreferredColumnWidth = 150
        Me.dgContacts.Size = New System.Drawing.Size(536, 86)
        Me.dgContacts.TabIndex = 0
        '
        'hlpForm1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 86)
        Me.Controls.Add(Me.dgContacts)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "hlpForm1"
        Me.Text = "UseDataAdapter"
        CType(Me.dgContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private SELECT_STRING As String = "SELECT * FROM ZsTrzNalepnice WHERE Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "'"

    'Private Const CONNECT_STRING As String = "Data Source=(local);Initial Catalog=WinRoba;Integrated Security=SSPI"
    Private mDataSet As DataSet

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim data_adapter As SqlDataAdapter
        data_adapter = New SqlDataAdapter(SELECT_STRING, DbVeza)

        data_adapter.TableMappings.Add("Table", "ZsTrzNalepnice")
        mDataSet = New DataSet
        data_adapter.Fill(mDataSet)

        Me.Text = "Brojevi sledecih tranzitnih nalepnica"
        dgContacts.SetDataBinding(mDataSet, "ZsTrzNalepnice")
        dgContacts.PreferredColumnWidth = 200
        dgContacts.Text = "Brojevi narednih tranzitnih nalepnica"

    End Sub
    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If mDataSet.HasChanges() Then
            Dim data_adapter As SqlDataAdapter
            Dim command_builder As SqlCommandBuilder

            data_adapter = New SqlDataAdapter(SELECT_STRING, DbVeza)
            data_adapter.TableMappings.Add("Table", "ZsTrzNalepnice")
            command_builder = New SqlCommandBuilder(data_adapter)

            data_adapter.Update(mDataSet)
            DbVeza.Close()
        End If
    End Sub
End Class
