Imports System.IO
Public Class FileSystemMonitor

    Public Shared Sub Main()
        Dim fsw As New FileSystemWatcher    ' create an object of FileSystemWatcher

        ' set properties of FileSystemWatcher object
        fsw.Path = "D:\"
        fsw.IncludeSubdirectories = True

        ' add event handlers 
        AddHandler fsw.Created, New FileSystemEventHandler(AddressOf File_Created)
        AddHandler fsw.Deleted, New FileSystemEventHandler(AddressOf File_Deleted)

        fsw.EnableRaisingEvents = True  ' enable monitoring

        Console.WriteLine("Started Monitoring D:\ folder. Press enter key to stop.")
        Console.ReadLine()

    End Sub

    ' event handler to handle created event 
    Public Shared Sub File_Created(ByVal obj As Object, ByVal e As FileSystemEventArgs)
        Console.WriteLine(e.FullPath & " - Created")
    End Sub

    ' event handler to handle deleted event 
    Public Shared Sub File_Deleted(ByVal obj As Object, ByVal e As FileSystemEventArgs)
        Console.WriteLine(e.FullPath & " - Deleted")
    End Sub

End Class

