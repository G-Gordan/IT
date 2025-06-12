Public Delegate Sub BoolValueChangedEventHandler(ByVal sender As Object, ByVal e As BoolValueChangedEventArgs)


Public Class BoolValueChangedEventArgs
    Inherits EventArgs
    Private columnVal As Integer
    Private rowVal As Integer
    Private boolVal As Boolean


    Public Sub New(ByVal row As Integer, ByVal col As Integer, ByVal val As Boolean)
        rowVal = row
        columnVal = col
        boolVal = val
    End Sub 'New

    'column to be painted

    Public Property Column() As Integer
        Get
            Return columnVal
        End Get
        Set(ByVal Value As Integer)
            columnVal = value
        End Set
    End Property
    'row to be painted

    Public Property Row() As Integer
        Get
            Return rowVal
        End Get
        Set(ByVal Value As Integer)
            rowVal = value
        End Set
    End Property
    'current value to be painted

    Public ReadOnly Property BoolValue() As Boolean
        Get
            Return boolVal
        End Get
    End Property
End Class 'BoolValueChangedEventArgs
