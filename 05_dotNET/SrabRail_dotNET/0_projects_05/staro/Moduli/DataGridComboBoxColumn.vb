Public Class DataGridComboBoxColumn
    Inherits DataGridTextBoxColumn
    Public WithEvents ColumnComboBox As NoKeyUpCombo 'special class
    Private WithEvents cmSource As CurrencyManager
    Private mRowNum As Integer
    Private isEditing As Boolean
    Shared Sub New()
    End Sub
    Public Sub New()
        MyBase.New()
        ColumnComboBox = New NoKeyUpCombo
        AddHandler ColumnComboBox.SelectionChangeCommitted, _
        New EventHandler(AddressOf ComboStartEditing)
    End Sub
    Protected Overloads Overrides Sub Edit(ByVal source As CurrencyManager, _
    ByVal rowNum As Integer, ByVal bounds As Rectangle, ByVal readOnly1 As Boolean, _
    ByVal instantText As String, ByVal cellIsVisible As Boolean)
        MyBase.Edit(source, rowNum, bounds, readOnly1, instantText, cellIsVisible)
        mRowNum = rowNum
        cmSource = source
        ColumnComboBox.Parent = Me.TextBox.Parent
        ColumnComboBox.Location = Me.TextBox.Location
        ColumnComboBox.Size = New Size(Me.TextBox.Size.Width, ColumnComboBox.Size.Height)
        ColumnComboBox.Text = Me.TextBox.Text
        TextBox.Visible = False
        ColumnComboBox.Visible = True
        ColumnComboBox.BringToFront()
        ColumnComboBox.Focus()
    End Sub
    Protected Overloads Overrides Function Commit(ByVal dataSource As _
    CurrencyManager, ByVal rowNum As Integer) As Boolean
        If isEditing Then
            isEditing = False
            SetColumnValueAtRow(dataSource, rowNum, ColumnComboBox.Text)
        End If
        Return True
    End Function
    Private Sub ComboStartEditing(ByVal sender As Object, ByVal e As EventArgs)
        isEditing = True
        MyBase.ColumnStartedEditing(DirectCast(sender, Control))
    End Sub
    Private Sub LeaveComboBox(ByVal sender As Object, ByVal e As EventArgs) _
    Handles ColumnComboBox.Leave
        If isEditing Then
            SetColumnValueAtRow(cmSource, mRowNum, ColumnComboBox.Text)
            isEditing = False
            Invalidate()
        End If
        ColumnComboBox.Hide()
    End Sub
End Class
Public Class NoKeyUpCombo
    Inherits ComboBox
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg <> &H101 Then
            MyBase.WndProc(m)
        End If
    End Sub

End Class
