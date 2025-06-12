Imports System.IO
Public Class Form1
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgrExcelContents As System.Windows.Forms.DataGrid
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.dgrExcelContents = New System.Windows.Forms.DataGrid
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.dgrExcelContents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(168, 440)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'dgrExcelContents
        '
        Me.dgrExcelContents.DataMember = ""
        Me.dgrExcelContents.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrExcelContents.Location = New System.Drawing.Point(360, 32)
        Me.dgrExcelContents.Name = "dgrExcelContents"
        Me.dgrExcelContents.PreferredColumnWidth = 100
        Me.dgrExcelContents.Size = New System.Drawing.Size(200, 384)
        Me.dgrExcelContents.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(320, 440)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 40)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 486)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgrExcelContents)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgrExcelContents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim objPresumablyExcel As IDataObject = Clipboard.GetDataObject()

            If Not objPresumablyExcel Is Nothing Then

                If (objPresumablyExcel.GetDataPresent(DataFormats.CommaSeparatedValue)) Then

                    Dim srReadExcel As New StreamReader(CType(objPresumablyExcel.GetData(DataFormats.CommaSeparatedValue), Stream))
                    Dim sFormattedData As String
                    Dim charDelimiterArray() As Char = {","}
                    Dim tblExcel2WinData As New DataTable

                    While (srReadExcel.Peek() > 0)
                        Dim arrSplitData As Array
                        Dim iLoopCounter As Integer = 0

                        sFormattedData = srReadExcel.ReadLine()
                        arrSplitData = sFormattedData.Split(charDelimiterArray)

                        If tblExcel2WinData.Columns.Count <= 0 Then
                            For iLoopCounter = 0 To arrSplitData.GetUpperBound(0)
                                tblExcel2WinData.Columns.Add()
                            Next
                            iLoopCounter = 0
                        End If

                        Dim rowNew As DataRow
                        rowNew = tblExcel2WinData.NewRow()

                        For iLoopCounter = 0 To arrSplitData.GetUpperBound(0)
                            rowNew(iLoopCounter) = arrSplitData.GetValue(iLoopCounter)
                        Next
                        iLoopCounter = 0

                        tblExcel2WinData.Rows.Add(rowNew)
                        rowNew = Nothing

                    End While

                    srReadExcel.Close()
                    dgrExcelContents.DataSource = tblExcel2WinData.DefaultView()
                Else
                    MsgBox("Nista nije selektovano u Excel dokumentu!")
                End If
            Else
                MsgBox("Empty Clipboard!")
            End If
        Catch exp As Exception
            MsgBox(exp.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dgrExcelContents.DataSource = Nothing
    End Sub
End Class
