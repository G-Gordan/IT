Imports System.ServiceProcess
Imports System.IO

Public Class Service1
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
        ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    Friend WithEvents Timer1 As System.Timers.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Timer1 = New System.Timers.Timer
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Service1
        '
        Me.ServiceName = "Service1"
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        fw = New StreamWriter(Environment.GetEnvironmentVariable("temp") & "\filesystem.log")
        fsw = New FileSystemWatcher

        If args.Length > 0 Then
            fsw.Path = args(0)
            fsw.IncludeSubdirectories = True
        Else  ' default settings
            fsw.Path = "C:\"
            fsw.IncludeSubdirectories = False
        End If

        AddHandler fsw.Created, New FileSystemEventHandler(AddressOf File_Created)
        AddHandler fsw.Deleted, New FileSystemEventHandler(AddressOf File_Deleted)
        fsw.EnableRaisingEvents = True

    End Sub
    Public Sub File_Created(ByVal obj As Object, ByVal e As FileSystemEventArgs)
        fw.WriteLine(Now.ToShortDateString & " " & Now.ToShortTimeString & " - " & e.FullPath & " - Created")
    End Sub

    Public Sub File_Deleted(ByVal obj As Object, ByVal e As FileSystemEventArgs)
        fw.WriteLine(Now.ToShortDateString & " " & Now.ToShortTimeString & " - " & e.FullPath & " - Deleted")
    End Sub


    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        fw.Close()
    End Sub

End Class
