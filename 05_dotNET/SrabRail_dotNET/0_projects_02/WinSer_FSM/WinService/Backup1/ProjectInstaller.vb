Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)> Public Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    Friend WithEvents ServiceProcessInstaller1 As System.ServiceProcess.ServiceProcessInstaller
    Friend WithEvents ServiceInstaller1 As System.ServiceProcess.ServiceInstaller

    'Required by the Component Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ServiceProcessInstaller1 = New System.ServiceProcess.ServiceProcessInstaller()
        Me.ServiceInstaller1 = New System.ServiceProcess.ServiceInstaller()
        '
        'ServiceProcessInstaller1
        '
        Me.ServiceProcessInstaller1.Account = ServiceProcess.ServiceAccount.LocalSystem
        'Me.ServiceProcessInstaller1.Password = Nothing
        'Me.ServiceProcessInstaller1.Username = Nothing
        '
        'ServiceInstaller1
        '
        Me.ServiceInstaller1.ServiceName = "Simple File-Based Emailer"
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.ServiceProcessInstaller1, Me.ServiceInstaller1})

    End Sub

#End Region

End Class
