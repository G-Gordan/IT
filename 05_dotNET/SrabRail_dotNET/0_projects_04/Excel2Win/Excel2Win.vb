'*************************************************************************************
'Author:    Sids (Siddharth Upadhya)
'Date:      6th March, 2004
'About:     Code sample to extract and bind copied data from an Excel sheet 
'           to a DataGrid Control
'*************************************************************************************
Imports System.IO

Public Class Excel2Win
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
    Friend WithEvents grpGrid As System.Windows.Forms.GroupBox
    Friend WithEvents dgrExcelContents As System.Windows.Forms.DataGrid
    Friend WithEvents btnCopyPaste As System.Windows.Forms.Button
    Friend WithEvents btnClearGrid As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpGrid = New System.Windows.Forms.GroupBox
        Me.dgrExcelContents = New System.Windows.Forms.DataGrid
        Me.btnCopyPaste = New System.Windows.Forms.Button
        Me.btnClearGrid = New System.Windows.Forms.Button
        Me.grpGrid.SuspendLayout()
        CType(Me.dgrExcelContents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpGrid
        '
        Me.grpGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpGrid.Controls.Add(Me.dgrExcelContents)
        Me.grpGrid.Location = New System.Drawing.Point(8, 64)
        Me.grpGrid.Name = "grpGrid"
        Me.grpGrid.Size = New System.Drawing.Size(504, 248)
        Me.grpGrid.TabIndex = 0
        Me.grpGrid.TabStop = False
        '
        'dgrExcelContents
        '
        Me.dgrExcelContents.DataMember = ""
        Me.dgrExcelContents.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrExcelContents.Location = New System.Drawing.Point(16, 24)
        Me.dgrExcelContents.Name = "dgrExcelContents"
        Me.dgrExcelContents.Size = New System.Drawing.Size(472, 208)
        Me.dgrExcelContents.TabIndex = 0
        '
        'btnCopyPaste
        '
        Me.btnCopyPaste.Location = New System.Drawing.Point(116, 24)
        Me.btnCopyPaste.Name = "btnCopyPaste"
        Me.btnCopyPaste.Size = New System.Drawing.Size(137, 23)
        Me.btnCopyPaste.TabIndex = 1
        Me.btnCopyPaste.Text = "Copy from Excel to Grid"
        '
        'btnClearGrid
        '
        Me.btnClearGrid.Location = New System.Drawing.Point(268, 24)
        Me.btnClearGrid.Name = "btnClearGrid"
        Me.btnClearGrid.Size = New System.Drawing.Size(136, 23)
        Me.btnClearGrid.TabIndex = 2
        Me.btnClearGrid.Text = "Clear Grid"
        '
        'Excel2Win
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 319)
        Me.Controls.Add(Me.btnClearGrid)
        Me.Controls.Add(Me.btnCopyPaste)
        Me.Controls.Add(Me.grpGrid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Excel2Win"
        Me.Text = "Excel 2 Win"
        Me.grpGrid.ResumeLayout(False)
        CType(Me.dgrExcelContents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCopyPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyPaste.Click

        Try
            'Read the copied data from the Clipboard
            Dim objPresumablyExcel As IDataObject = Clipboard.GetDataObject()

            'Proceed if some copied data is present
            If Not objPresumablyExcel Is Nothing Then

                'Next proceed only of the copied data is in the CSV format indicating Excel content
                If (objPresumablyExcel.GetDataPresent(DataFormats.CommaSeparatedValue)) Then

                    'Cast the copied data in the CommaSeparatedValue format & hold in a StreamReader Object
                    Dim srReadExcel As New StreamReader(CType(objPresumablyExcel.GetData(DataFormats.CommaSeparatedValue), Stream))
                    Dim sFormattedData As String

                    'Set the delimiter character for use in splitting the copied data
                    Dim charDelimiterArray() As Char = {","}

                    'Define a DataTable to hold the copied data for binding to the DataGrid
                    Dim tblExcel2WinData As New DataTable

                    'Loop till no further data is available
                    While (srReadExcel.Peek() > 0)
                        'Array to hold the split data for each row
                        Dim arrSplitData As Array

                        'Multipurpose Loop Counter
                        Dim iLoopCounter As Integer = 0

                        'Read a line of data from the StreamReader object
                        sFormattedData = srReadExcel.ReadLine()

                        'Split the string contents into an array
                        arrSplitData = sFormattedData.Split(charDelimiterArray)

                        If tblExcel2WinData.Columns.Count <= 0 Then
                            For iLoopCounter = 0 To arrSplitData.GetUpperBound(0)
                                tblExcel2WinData.Columns.Add()
                            Next
                            iLoopCounter = 0
                        End If

                        'Row to hold a single row of the Excel Data
                        Dim rowNew As DataRow
                        rowNew = tblExcel2WinData.NewRow()


                        For iLoopCounter = 0 To arrSplitData.GetUpperBound(0)
                            rowNew(iLoopCounter) = arrSplitData.GetValue(iLoopCounter)
                        Next
                        iLoopCounter = 0

                        'Add the row back to the DataTable
                        tblExcel2WinData.Rows.Add(rowNew)

                        rowNew = Nothing
                    End While

                    'Close the StreamReader object
                    srReadExcel.Close()

                    'Bind the data to the DataGrid
                    dgrExcelContents.DataSource = tblExcel2WinData.DefaultView()
                Else
                    MsgBox("Clipboard data does not seem to be copied from Excel!")
                End If
            Else
                MsgBox("Clipboard is empty!")
            End If
        Catch exp As Exception
            MsgBox(exp.Message)
        End Try

    End Sub

    Private Sub btnClearGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearGrid.Click
        dgrExcelContents.DataSource = Nothing
    End Sub
End Class
