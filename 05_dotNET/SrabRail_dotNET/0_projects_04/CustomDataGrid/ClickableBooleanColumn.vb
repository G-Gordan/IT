Public Class ClickableBooleanColumn
    Inherits DataGridBoolColumn

    'changed event
    Public Event BoolValueChanged As BoolValueChangedEventHandler

    'set variables to start tracking bool changes
    Protected Overloads Overrides Sub Edit(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
        lockValue = True
        beingEdited = True
        saveRow = rowNum
        saveValue = CBool(MyBase.GetColumnValueAtRow([source], rowNum))
        MyBase.Edit([source], rowNum, bounds, [readOnly], instantText, cellIsVisible)
    End Sub 'Edit

    'overridden to handle BoolChange event
    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        Dim colNum As Integer = Me.DataGridTableStyle.GridColumnStyles.IndexOf(Me)

        'used to handle the boolchanging
        ManageBoolValueChanging(rowNum, colNum)

        MyBase.Paint(g, bounds, [source], rowNum, backBrush, New SolidBrush(Color.Red), alignToRight)

    End Sub 'Paint 

    'turn off tracking bool changes
    Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean
        lockValue = True
        beingEdited = False
        Return MyBase.Commit(dataSource, rowNum)
    End Function 'Commit

    Private saveValue As Boolean = False
    Private saveRow As Integer = -1
    Private lockValue As Boolean = False
    Private beingEdited As Boolean = False
    Public Const VK_SPACE As Integer = 32

    'needed to get the space bar changing of the bool value
    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Shared Function GetKeyState(ByVal nVirtKey As Integer) As Short
    End Function

    'fire the bool change event if the value changes
    Private Sub ManageBoolValueChanging(ByVal rowNum As Integer, ByVal colNum As Integer)

        Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim mousePos As Point = dg.PointToClient(Control.MousePosition)
        Dim isClickInCell As Boolean = Control.MouseButtons = MouseButtons.Left AndAlso dg.GetCellBounds(dg.CurrentCell).Contains(mousePos)

        Dim changing As Boolean = dg.Focused AndAlso isClickInCell OrElse GetKeyState(VK_SPACE) < 0
        ' or spacebar
        If Not lockValue AndAlso beingEdited AndAlso changing AndAlso saveRow = rowNum Then
            saveValue = Not saveValue
            lockValue = False

            'fire the event
            Dim e As New BoolValueChangedEventArgs(rowNum, colNum, saveValue)
            RaiseEvent BoolValueChanged(Me, e)
        End If
        If saveRow = rowNum Then
            lockValue = False
        End If
    End Sub 'ManageBoolValueChanging
End Class
