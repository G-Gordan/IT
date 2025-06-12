Imports System.ServiceProcess
Imports System.IO

Public Class MyNewService

    Inherits System.ServiceProcess.ServiceBase
    Dim fsw As FileSystemWatcher
    Dim fw As StreamWriter


#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        ' This call is required by the Component Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call

    End Sub

    'UserService overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' The main entry point for the process
    <MTAThread()> _
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' More than one NT Service may run within the same process. To add
        ' another service to this process, change the following line to
        ' create a second service object. For example,
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New MyNewService}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    Friend WithEvents Timer1 As System.Timers.Timer
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Timer1 = New System.Timers.Timer
        Me.EventLog1 = New System.Diagnostics.EventLog
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 6000
        '
        'EventLog1
        '
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        '
        'MyNewService
        '
        Me.ServiceName = "Service1"
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
    


    Protected Overrides Sub OnStart(ByVal args() As String)
       
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        Timer1.Enabled = True

        'Dim qt As Integer, x As Integer
        'Dim kopiraj As Boolean
        'Dim path As String = "D:\"
        'Dim folder As String, date_ As String, ZIP As String
        'Dim TXTFile As String = path & "\KKK.txt"

        'FileCopy("D:\KKK\proba.txt", "D:\KKK1\")
        'qt = 1

        '18.11.
        fw = New StreamWriter(Environment.GetEnvironmentVariable("d:\") & "\*.txt")
        fsw = New FileSystemWatcher

        If args.Length > 0 Then
            fsw.Path = args(0)
            fsw.IncludeSubdirectories = True
        Else  ' default settings
            fsw.Path = "D:\"
            fsw.IncludeSubdirectories = False
        End If

        'AddHandler fsw.Created, New FileSystemEventHandler(AddressOf File_Created)
        'AddHandler fsw.Deleted, New FileSystemEventHandler(AddressOf File_Deleted)
        fsw.EnableRaisingEvents = True


        '18.11.
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Timer1.Enabled = False

    End Sub

    Private Sub Timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed
        

        Dim MyLog As New EventLog   ' create a new event log
        ' Check if the the Event Log Exists
        If Not MyLog.SourceExists("MyNewService") Then
            MyLog.CreateEventSource("MyNewService", "MyNewservice Log")
            ' Create Log
        End If
        MyLog.Source = "MyNewService"
        ' Write to the Log
        MyLog.WriteEntry("MyNewService Log", "This is log on " & _
                          CStr(TimeOfDay), _
                          EventLogEntryType.Information)

        'Dim odredistefajla As String

        'odredistefajla = "\\10.0.80.33\k\proba.txt"
        'FileCopy("D:\KKK\proba.txt", odredistefajla)

        'traženje putanje
        Dim odredistefajla As String

        odredistefajla = "\\10.0.80.33\k\proba.txt"
        Dim qt As Integer, x As Integer
        Dim kopiraj As Boolean
        Dim path As String = "D:\"
        Dim folder As String, date_ As String, ZIP As String
        Dim TXTFile As String = path & "KKK\"
        folder = TXTFile & "proba.txt"
        FileCopy(TXTFile & "proba.txt", odredistefajla)

        'qt = 1
        'FileCopy(Source & File, Destination & File, False)
        'kopiraj=save("test1/pera.txt", "test2/pera.txt");
        'if(kopiraj)echo('Kopiranje uspelo');
        'Else : die("Nece ici...")
        'End If
        'ubaceno

        'qt = CType(MyNewServiceService.Ini.ReadIni(INIFile, _
        '"General", "Number"), System.Int32)
        'For x = 1 To qt
        '    folder = MyNewServiceService.Ini.ReadIni(INIFile, "Folders", x)
        '    'Zip File name ZIP = folder & "DataBase.zip"
        '    date_ = CStr(FileDateTime(ZIP))
        '    If MyNewServiceService.Ini.ReadIni(INIFile, "Dates", x) <> date_ Then
        '        Me.ExtractArchive(ZIP, folder)
        '        MyNewServiceService.Ini.WriteIni(INIFile, "Dates", x, date_)
        '    End If
        'Next

        'ubaceno

    End Sub

    Private Sub EventLog1_EntryWritten(ByVal sender As System.Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles EventLog1.EntryWritten
        If e.Entry.Source = "MyNewService" Then
            Console.WriteLine("Entry written by my app. Message: " & _
               e.Entry.Message)
        Else
            Console.WriteLine("Entry written by another application. ")
        End If
    End Sub

    Private Sub FileSystemWatcher1_Changed(ByVal sender As System.Object, ByVal e As System.IO.FileSystemEventArgs)

    End Sub
End Class
