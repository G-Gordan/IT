Imports System.ServiceProcess
Imports System.Web.Mail
Imports System.IO
Imports System.Diagnostics

Public Class Emailer

    Inherits System.ServiceProcess.ServiceBase
    Private oMailer As clsMailer
#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        ' This call is required by the Component Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call

    End Sub

    ' The main entry point for the process
    Shared Sub Main()
        'This is entry
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' More than one NT Service may run within the same process. To add
        ' another service to this process, change the following line to
        ' create a second service object. For example,
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New Emailer()}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)



    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.Container

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Emailer
        '
        Me.ServiceName = "Simple File-Based Emailer"

    End Sub

#End Region

    Protected Overrides Sub OnStart(ByVal args() As String)
        Dim oDir As DirectoryInfo
        oMailer = New clsMailer()

        'Create Error directory and 
        'Data Directory (System32/Emails, where
        'Emails will be stored
        oDir = New DirectoryInfo(ErrorDirectory)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        If Not oDir.Exists() Then oDir.Create()

        oDir = New DirectoryInfo(DataDirectory)
        If Not oDir.Exists Then oDir.Create()

        'This creates a new thread to 
        'monitor the application directory
        'and send e-mail.  See clsMailer
        'code
        oMailer.MonitorAndSend()
    End Sub

    Protected Overrides Sub OnStop()
        'cleanup code
    End Sub

End Class
