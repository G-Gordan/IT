Imports System
Imports System.IO

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports CrystalDecisions.Shared


Public Class Form1

    'Inherits System.Windows.Forms.Form
    'Public Const ConnectionString As String = _
    '   "Server=10.0.4.31;DataBase=OkpWinRoba;User=roba214kp;Password=Katarina;Initial Catalog=ZsZah140;"
    ''Public Const ConnectionString As String = "Server=(local);DataBase=OkpWinRoba;User=sa;Password=sa"

    Dim slogTrans As SqlTransaction
    Dim Mesec As String
    Dim Godina As String

    Dim Saobracaj As String = 1
    Dim Smer As String
    Dim rv As Integer
    Dim rv1 As String
    ''Dim a As String = 140
    Private WithEvents mobjPkgEvents As DTS.Package

    Private Sub RunPackage()
        'Run the package stored in file C:\DTS_UE\TestPkg\VarPubsFields.dts.
        Dim objPackage As DTS.Package2
        Dim objStep As DTS.Step
        Dim objTask As DTS.Task
        Dim objExecPkg As DTS.ExecutePackageTask

        'On Error GoTo PackageError
        objPackage = New DTS.Package
        mobjPkgEvents = objPackage
        objPackage.FailOnError = True

        'Create the step and task. Specify the package to be run, and link the step to the task.
        objStep = objPackage.Steps.New
        objTask = objPackage.Tasks.New("DTSExecutePackageTask")
        objExecPkg = objTask.CustomTask
        'If a = "140" Then
        With objExecPkg
            .PackagePassword = "user"
            .FileName = "d:\roba\dts1\Zalihe140.dts"
            .Name = "ExecPkgTask"
        End With
        'Else
        'With objExecPkg
        '    .PackagePassword = "user"
        '    .FileName = "d:\roba\Zalihe160.dts"
        '    .Name = "ExecPkgTask"
        'End With
        'End If
        With objStep
            .TaskName = objExecPkg.Name
            .Name = "ExecPkgStep"
            .ExecuteInMainThread = True
        End With
        objPackage.Steps.Add(objStep)
        objPackage.Tasks.Add(objTask)

        'Run the package and release references.
        objPackage.Execute()

        objExecPkg = Nothing
        objTask = Nothing
        objStep = Nothing
        mobjPkgEvents = Nothing

        'objPackage.UnInitialize()

    End Sub

    Private Sub RunPackage1()
        'Run the package stored in file C:\DTS_UE\TestPkg\VarPubsFields.dts.
        Dim objPackage As DTS.Package2
        Dim objStep As DTS.Step
        Dim objTask As DTS.Task
        Dim objExecPkg As DTS.ExecutePackageTask

        'On Error GoTo PackageError
        objPackage = New DTS.Package
        mobjPkgEvents = objPackage
        objPackage.FailOnError = True

        'Create the step and task. Specify the package to be run, and link the step to the task.
        objStep = objPackage.Steps.New
        objTask = objPackage.Tasks.New("DTSExecutePackageTask")
        objExecPkg = objTask.CustomTask
        'If a = "140" Then
        With objExecPkg
            .PackagePassword = "user"
            .FileName = "d:\roba\dts\Zalihe165.dts"
            .Name = "ExecPkgTask"
        End With
        'Else
        '    With objExecPkg
        '        .PackagePassword = "user"
        '        .FileName = "d:\roba\Zalihe160.dts"
        '        .Name = "ExecPkgTask"
        '    End With
        'End If
        With objStep
            .TaskName = objExecPkg.Name
            .Name = "ExecPkgStep"
            .ExecuteInMainThread = True
        End With
        objPackage.Steps.Add(objStep)
        objPackage.Tasks.Add(objTask)

        'Run the package and release references.
        objPackage.Execute()

        objExecPkg = Nothing
        objTask = Nothing
        objStep = Nothing
        mobjPkgEvents = Nothing
        'PackageError:
        '        'Button1.Focus()
        '        MsgBox("Operacija je uspešno završena!")
    End Sub

    Private Sub RunPackage2()
        'Run the package stored in file C:\DTS_UE\TestPkg\VarPubsFields.dts.
        Dim objPackage As DTS.Package2
        Dim objStep As DTS.Step
        Dim objTask As DTS.Task
        Dim objExecPkg As DTS.ExecutePackageTask

        'On Error GoTo PackageError
        objPackage = New DTS.Package
        mobjPkgEvents = objPackage
        objPackage.FailOnError = True

        'Create the step and task. Specify the package to be run, and link the step to the task.
        objStep = objPackage.Steps.New
        objTask = objPackage.Tasks.New("DTSExecutePackageTask")
        objExecPkg = objTask.CustomTask
        'If a = "140" Then
        With objExecPkg
            .PackagePassword = "user"
            .FileName = "d:\roba\dts\Zalihe1401.dts"
            .Name = "ExecPkgTask"
        End With
        'Else
        '    With objExecPkg
        '        .PackagePassword = "user"
        '        .FileName = "d:\roba\Zalihe160.dts"
        '        .Name = "ExecPkgTask"
        '    End With
        'End If
        With objStep
            .TaskName = objExecPkg.Name
            .Name = "ExecPkgStep"
            .ExecuteInMainThread = True
        End With
        objPackage.Steps.Add(objStep)
        objPackage.Tasks.Add(objTask)

        'Run the package and release references.
        objPackage.Execute()

        objExecPkg = Nothing
        objTask = Nothing
        objStep = Nothing
        mobjPkgEvents = Nothing
        'PackageError:
        '        'Button1.Focus()
        '        MsgBox("Operacija je uspešno završena!")
    End Sub

    Private Sub RunPackage3()
        'Run the package stored in file C:\DTS_UE\TestPkg\VarPubsFields.dts.
        Dim objPackage As DTS.Package2
        Dim objStep As DTS.Step
        Dim objTask As DTS.Task
        Dim objExecPkg As DTS.ExecutePackageTask

        'On Error GoTo PackageError
        objPackage = New DTS.Package
        mobjPkgEvents = objPackage
        objPackage.FailOnError = True

        'Create the step and task. Specify the package to be run, and link the step to the task.
        objStep = objPackage.Steps.New
        objTask = objPackage.Tasks.New("DTSExecutePackageTask")
        objExecPkg = objTask.CustomTask
        'If a = "140" Then
        With objExecPkg
            .PackagePassword = "user"
            .FileName = "d:\roba\dts\Zalihe140NS.dts"
            .Name = "ExecPkgTask"
        End With
        'Else
        '    With objExecPkg
        '        .PackagePassword = "user"
        '        .FileName = "d:\roba\Zalihe160.dts"
        '        .Name = "ExecPkgTask"
        '    End With
        'End If
        With objStep
            .TaskName = objExecPkg.Name
            .Name = "ExecPkgStep"
            .ExecuteInMainThread = True
        End With
        objPackage.Steps.Add(objStep)
        objPackage.Tasks.Add(objTask)

        'Run the package and release references.
        objPackage.Execute()

        objExecPkg = Nothing
        objTask = Nothing
        objStep = Nothing
        mobjPkgEvents = Nothing
        'PackageError:
        '        'Button1.Focus()
        '        MsgBox("Operacija je uspešno završena!")
    End Sub

    Private Sub RunPackage4()
        'Run the package stored in file C:\DTS_UE\TestPkg\VarPubsFields.dts.
        Dim objPackage As DTS.Package2
        Dim objStep As DTS.Step
        Dim objTask As DTS.Task
        Dim objExecPkg As DTS.ExecutePackageTask

        'On Error GoTo PackageError
        objPackage = New DTS.Package
        mobjPkgEvents = objPackage
        objPackage.FailOnError = True

        'Create the step and task. Specify the package to be run, and link the step to the task.
        objStep = objPackage.Steps.New
        objTask = objPackage.Tasks.New("DTSExecutePackageTask")
        objExecPkg = objTask.CustomTask
        'If a = "140" Then
        With objExecPkg
            .PackagePassword = "user"
            .FileName = "d:\roba\dts\Zalihe1651.dts"
            .Name = "ExecPkgTask"
        End With
        'Else
        '    With objExecPkg
        '        .PackagePassword = "user"
        '        .FileName = "d:\roba\Zalihe160.dts"
        '        .Name = "ExecPkgTask"
        '    End With
        'End If
        With objStep
            .TaskName = objExecPkg.Name
            .Name = "ExecPkgStep"
            .ExecuteInMainThread = True
        End With
        objPackage.Steps.Add(objStep)
        objPackage.Tasks.Add(objTask)

        'Run the package and release references.
        objPackage.Execute()

        objExecPkg = Nothing
        objTask = Nothing
        objStep = Nothing
        mobjPkgEvents = Nothing
        'PackageError:
        '        'Button1.Focus()
        '        MsgBox("Operacija je uspešno završena!")
    End Sub

    Private Sub RunPackage5()
        'Run the package stored in file C:\DTS_UE\TestPkg\VarPubsFields.dts.
        Dim objPackage As DTS.Package2
        Dim objStep As DTS.Step
        Dim objTask As DTS.Task
        Dim objExecPkg As DTS.ExecutePackageTask

        On Error GoTo PackageError
        objPackage = New DTS.Package
        mobjPkgEvents = objPackage
        objPackage.FailOnError = True

        'Create the step and task. Specify the package to be run, and link the step to the task.
        objStep = objPackage.Steps.New
        objTask = objPackage.Tasks.New("DTSExecutePackageTask")
        objExecPkg = objTask.CustomTask
        'If a = "140" Then
        With objExecPkg
            .PackagePassword = "user"
            .FileName = "d:\roba\dts\Zalihe165NS.dts"
            .Name = "ExecPkgTask"
        End With
        'Else
        '    With objExecPkg
        '        .PackagePassword = "user"
        '        .FileName = "d:\roba\Zalihe160.dts"
        '        .Name = "ExecPkgTask"
        '    End With
        'End If
        With objStep
            .TaskName = objExecPkg.Name
            .Name = "ExecPkgStep"
            .ExecuteInMainThread = True
        End With
        objPackage.Steps.Add(objStep)
        objPackage.Tasks.Add(objTask)

        'Run the package and release references.
        objPackage.Execute()

        objExecPkg = Nothing
        objTask = Nothing
        objStep = Nothing
        mobjPkgEvents = Nothing
PackageError:
        'Button1.Focus()
        MsgBox("Mozete da pokrenete formiranje izvestaja!")
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    '    Dim intCounter1 As Integer
    '    Dim str1SQL As String
    '    Dim objCommand1 As SqlClient.SqlCommand
    '    Dim objDAA As SqlClient.SqlDataAdapter
    '    Dim objDSS As New Data.DataSet
    '    'Dim outPovratnaVrednost As String = ""
    '    Dim RacMesec As String
    '    Dim RacGodina As String
    '    Dim RacMesec1 As String = ""
    '    Dim RacGodina1 As String = ""
    '    RacMesec = Microsoft.VisualBasic.Left(ComboBox1.Text, 2)
    '    RacGodina = ComboBox2.Text
    '    str1SQL = "SELECT     * " & _
    '         "FROM         dbo.ZsZal1401 INNER JOIN" & _
    '         " dbo.ZsZal140 ON dbo.ZsZal1401.Smer = dbo.ZsZal140.Smer AND dbo.ZsZal1401.Saobracaj = dbo.ZsZal140.Saobracaj AND " & _
    '         " dbo.ZsZal1401.SifraStanice = dbo.ZsZal140.SifraStanice AND dbo.ZsZal1401.RacGodina = dbo.ZsZal140.RacGodina AND " & _
    '         " dbo.ZsZal1401.RacMesec = dbo.ZsZal140.RacMesec " & _
    '         "WHERE     dbo.ZsZal1401.RacMesec  =  '" & RacMesec & "' and   dbo.ZsZal1401.RacGodina  =  '" & RacGodina & "'"


    '    objCommand1 = New SqlClient.SqlCommand(str1SQL, OkpDbVeza)
    '    'objCommand1.Connection.Open()
    '    objDAA = New SqlClient.SqlDataAdapter(str1SQL, OkpDbVeza)
    '    objDAA.Fill(objDSS)
    '    With objDSS.Tables(0)
    '        For intCounter1 = 0 To .Rows.Count - 1
    '            RacMesec1 = .Rows(intCounter1).Item("RacMesec")
    '            RacGodina1 = .Rows(intCounter1).Item("RacGodina")
    '        Next
    '    End With
    '    'If RacMesec1 = "" And RacGodina1 = "" Then
    '    RunPackage()
    '    RunPackage1()
    '    RunPackage2()
    '    RunPackage3()
    '    RunPackage4()
    '    RunPackage5()
    '    Update140(slogTrans, Saobracaj, RacMesec, RacGodina, rv)
    '    'Else : MsgBox("Datoteke za ovaj mesec su unete.")
    '    'End If
    'End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ComboBox1.Focus()
        If ComboBox1.Text = "" And ComboBox2.Text = "" Then
            Button1.Visible = True
        Else
            Button1.Visible = False
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    'Private Sub ComboBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.LostFocus
    '    Mesec = ComboBox1.Text
    '    Godina = ComboBox2.Text

    'End Sub

    Private Sub ComboBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        ComboBox2.Focus()
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub RazlikeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RazlikeToolStripMenuItem.Click

        Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        Godina = ComboBox2.Text

        Dim FIzv As New FormRazl
        Dim CRIzv As New RazlikeU
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "roba214kp"
        CRConec.Password = "Katarina"

        Dim param1 As String      'parametar koji se odnosi na korisnika
        Dim param2 As String

        param1 = Mesec
        param2 = Godina
        Try
            FIzv.CrystalReportViewer1.SelectionFormula = "{V_K140URazl.RacMesec}=('" & Mesec & "') And {V_K140URazl.RacGodina}=('" & Godina & "')"
            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        FIzv.Show()
    End Sub

    Private Sub VanRasponaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VanRasponaToolStripMenuItem.Click
        'Dim ObrMesec As String
        'Dim ObrGodina As String
        'ObrMesec = Microsoft.VisualBasic.Left(ComboBox1.Text, 2)
        'ObrGodina = ComboBox2.Text
        'VanRaspUn140(slogTrans, Saobracaj, ObrMesec, ObrGodina, rv)
        Dim FIzv As New FormVanRasp
        Dim CRIzv As New VanRaspU_K
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String      'parametar koji se odnosi na korisnika
        Dim param2 As String

        Godina = ComboBox2.Text
        param1 = Godina
        Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        param2 = Mesec
        Try
            FIzv.CrystalReportViewer1.SelectionFormula = "{V_VanRUn140_K.ObrGodina}=('" & Godina & "') and {V_VanRUn140_K.ObrMesec}=('" & Mesec & "')"
            'and {SlogKalk.PrBroj}= " & PrBroj & " and {SlogRoba.KolaStavka}= " & UkBr & ""
            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            FIzv.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'Dim FIzv As New FormVanRasp
        'Dim CRIzv As New VanRaspU
        'FIzv.CrystalReportViewer1().ReportSource = CRIzv
        ''Prijavljivanje na bazu
        'Dim CRConec As New ConnectionInfo
        'CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        'CRConec.ServerName = "10.0.4.31"
        'CRConec.DatabaseName = "OkpWinRoba"
        'CRConec.UserID = "radnik"
        'CRConec.Password = "roba2006"
        'Dim param1 As String      'parametar koji se odnosi na korisnika
        'Dim param2 As String
        ''Dim racMesec As String
        'Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        'param1 = Mesec
        'Godina = ComboBox2.Text
        'param2 = Godina
        'Try
        '    FIzv.CrystalReportViewer1.SelectionFormula = "{V_VanRUn140.ObrMesec}=('" & Mesec & "') And {V_VanRUn140.ObrGodina}=('" & Godina & "')"
        '    'and {SlogKalk.PrBroj}= " & PrBroj & " and {SlogRoba.KolaStavka}= " & UkBr & ""
        '    CRIzv.SetParameterValue(0, param1)
        '    CRIzv.SetParameterValue(1, param2)
        '    FIzv.Show()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        ''FIzv.Show()
    End Sub

    Private Sub NedostajuciToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NedostajuciToolStripMenuItem.Click

        Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        Godina = ComboBox2.Text
        'Update140Ned_K(slogTrans, Saobracaj, Mesec, rv)
        Update140Ned(slogTrans, Saobracaj, Mesec, Godina, rv)
        Dim FIzv As New FormNedU
        Dim CRIzv As New NedU
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "roba214kp"
        CRConec.Password = "Katarina"
        Dim param1 As String      'parametar koji se odnosi na korisnika
        Dim param2 As String
        param1 = Godina
        param2 = Mesec

        Try
            'FIzv.CrystalReportViewer1.SelectionFormula = "{V_NedU140.ObrGodina}=('" & Godina & "') And {V_NedU140.ObrMesec}=('" & Mesec & "') "
            'and {SlogKalk.PrBroj}= " & PrBroj & " and {SlogRoba.KolaStavka}= " & UkBr & ""
            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            FIzv.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'FIzv.Show()

    End Sub

    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        'If ComboBox1.Text = "" And ComboBox2.Text = "" Then
        '    Button1.Visible = True
        'Else
        '    Button1.Visible = False
        'End If
    End Sub

    Private Sub RazlikeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RazlikeToolStripMenuItem1.Click

        Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        Godina = ComboBox2.Text

        Dim FIzv As New FormRazl
        Dim CRIzv As New RazlikeU1
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "roba214kp"
        CRConec.Password = "Katarina"

        Dim param1 As String      'parametar koji se odnosi na korisnika
        Dim param2 As String

        param1 = Mesec
        param2 = Godina

        Try
            FIzv.CrystalReportViewer1.SelectionFormula = "{V_K165URazl.RacMesec}=('" & Mesec & "') And {V_K165URazl.RacGodina}=('" & Godina & "')"
            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        FIzv.Show()
    End Sub

    Private Sub VanRasponaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VanRasponaToolStripMenuItem1.Click
        Dim FIzv As New FormVanRasp
        Dim CRIzv As New VanRaspU1_K
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String      'parametar koji se odnosi na korisnika
        Dim param2 As String
        'Dim racMesec As String
        Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        param2 = Trim(Mesec)
        Godina = ComboBox2.Text
        param1 = Godina
        Try
            FIzv.CrystalReportViewer1.SelectionFormula = " {V_VanRUn165_K.ObrGodina}=('" & Godina & "') And {V_VanRUn165_K.ObrMesec}=('" & Mesec & "') "

            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            FIzv.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'FIzv.Show()
    End Sub

    Private Sub NedostajuciToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NedostajuciToolStripMenuItem1.Click

        Dim param1 As String      'parametar koji se odnosi na korisnika
        Dim param2 As String

        Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        param1 = Mesec
        Godina = ComboBox2.Text
        param2 = Godina

        Update140Ned(slogTrans, Saobracaj, Mesec, Godina, rv)
        Dim FIzv As New FormNedU
        Dim CRIzv As New NedU1
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "roba214kp"
        CRConec.Password = "Katarina"

        Try
            'FIzv.CrystalReportViewer1.SelectionFormula = " {V_NedU165.ObrGodina}=('" & Godina & "') And {V_NedU165.ObrMesec}=('" & Mesec & "') "

            CRIzv.SetParameterValue(1, param1)
            CRIzv.SetParameterValue(0, param2)
            FIzv.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'FIzv.Show()
        'Dim racMesec As String
       
        'FIzv.Show()
    End Sub

    Private Sub Nedostajući140ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nedostajući140ToolStripMenuItem.Click
        Update140Ned_K(slogTrans, Saobracaj, rv)
        Dim FIzv As New FormNedU
        Dim CRIzv As New NedU_K
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "roba214kp"
        CRConec.Password = "Katarina"

        FIzv.Show()
    End Sub

    Private Sub Nedostajući165ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Update140Ned_K(slogTrans, Saobracaj, rv)
        Dim FIzv As New FormNedU
        Dim CRIzv As New NedU1_K
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "roba214kp"
        CRConec.Password = "Katarina"

        FIzv.Show()
    End Sub

    Private Sub VanRaspona140ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

       
    End Sub

    Private Sub VanRaspona165ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim FIzv As New FormVanRasp
        Dim CRIzv As New VanRaspU1_K
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String      'parametar koji se odnosi na korisnika
        Dim param2 As String

        Godina = ComboBox2.Text
        param1 = Godina
        Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        param2 = Mesec
        Try
            FIzv.CrystalReportViewer1.SelectionFormula = "{V_VanRUn165_K.ObrGodina}=('" & Godina & "')and {V_VanRUn165_K.ObrMesec}=('" & Mesec & "')"
            'and {SlogKalk.PrBroj}= " & PrBroj & " and {SlogRoba.KolaStavka}= " & UkBr & ""
            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            FIzv.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub RazlikeToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        Godina = ComboBox2.Text

        Dim FIzv As New FormRazl
        Dim CRIzv As New RazlikeU
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "roba214kp"
        CRConec.Password = "Katarina"

        Dim param1 As String      'parametar koji se odnosi na korisnika
        Dim param2 As String

        param1 = Mesec
        param2 = Godina
        Try
            FIzv.CrystalReportViewer1.SelectionFormula = "{V_K140URazl.RacMesec}=('" & Mesec & "') And {V_K140URazl.RacGodina}=('" & Godina & "')"
            CRIzv.SetParameterValue(1, param1)
            CRIzv.SetParameterValue(0, param2)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        FIzv.Show()
    End Sub

    Private Sub Razlike165ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        Godina = ComboBox2.Text

        Dim FIzv As New FormRazl
        Dim CRIzv As New RazlikeU1
        FIzv.CrystalReportViewer1().ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "roba214kp"
        CRConec.Password = "Katarina"

        Dim param1 As String      'parametar koji se odnosi na korisnika
        Dim param2 As String

        param1 = Mesec
        param2 = Godina

        Try
            FIzv.CrystalReportViewer1.SelectionFormula = "{V_K165URazl.RacMesec}=('" & Mesec & "') And {V_K165URazl.RacGodina}=('" & Godina & "')"
            CRIzv.SetParameterValue(1, param1)
            CRIzv.SetParameterValue(0, param2)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        FIzv.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim result1 As DialogResult = MessageBox.Show("Da li ste sigurni da želite da učitate podatke?", _
               "Važno upozorenje!", _
               MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Dim intCounter1 As Integer
            Dim str1SQL As String
            Dim objCommand1 As SqlClient.SqlCommand
            Dim objDAA As SqlClient.SqlDataAdapter
            Dim objDSS As New Data.DataSet
            'Dim outPovratnaVrednost As String = ""
            Dim RacMesec As String
            Dim RacGodina As String
            Dim RacMesec1 As String = ""
            Dim RacGodina1 As String = ""
            RacMesec = ComboBox1.Text
            RacGodina = ComboBox2.Text
            str1SQL = "SELECT     * " & _
                 "FROM         dbo.ZsZal1401 INNER JOIN" & _
                 " dbo.ZsZal140 ON dbo.ZsZal1401.Smer = dbo.ZsZal140.Smer AND dbo.ZsZal1401.Saobracaj = dbo.ZsZal140.Saobracaj AND " & _
                 " dbo.ZsZal1401.SifraStanice = dbo.ZsZal140.SifraStanice AND dbo.ZsZal1401.RacGodina = dbo.ZsZal140.RacGodina AND " & _
                 " dbo.ZsZal1401.RacMesec = dbo.ZsZal140.RacMesec " & _
                 "WHERE     dbo.ZsZal1401.RacMesec  =  '" & RacMesec & "' and   dbo.ZsZal1401.RacGodina  =  '" & RacGodina & "'"


            objCommand1 = New SqlClient.SqlCommand(str1SQL, OkpDbVeza)
            'objCommand1.Connection.Open()
            objDAA = New SqlClient.SqlDataAdapter(str1SQL, OkpDbVeza)
            objDAA.Fill(objDSS)
            With objDSS.Tables(0)
                For intCounter1 = 0 To .Rows.Count - 1
                    RacMesec1 = .Rows(intCounter1).Item("RacMesec")
                    RacGodina1 = .Rows(intCounter1).Item("RacGodina")
                Next
            End With
            If RacMesec1 = "" And RacGodina1 = "" Then
                'RunPackage()
                'RunPackage1()
                'RunPackage2()
                'RunPackage3()
                'RunPackage4()
                'RunPackage5()
                Update140(slogTrans, Saobracaj, RacMesec, RacGodina, rv)
                UpdateBlag(slogTrans, RacMesec, RacGodina, rv1)
            Else : MsgBox("Datoteke za ovaj mesec su unete.")
            End If
        Else : ComboBox1.Focus()
        End If
    End Sub

   
    Private Sub IzveštajiZaPeriodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IzveštajiZaPeriodeToolStripMenuItem.Click

    End Sub

    Private Sub IzvestajiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IzvestajiToolStripMenuItem.Click

    End Sub
End Class

'Dim upit As String
'Dim ii1 As Int32 'Broj ucitanih slogova
'Dim ad1 As New SqlDataAdapter("Update(dbo.ZsZal140)" & _
'                                " SET Saobracaj = '1', Smer = '140'", OkpDbVeza) 'DataAdapter
'Dim ds1 As New DataSet("ds1") 'DataSet
'Try
'    ii1 = ad1.Fill(ds1)

'    If OkpDbVeza.State = ConnectionState.Closed Then
'        OkpDbVeza.Open()
'    End If
'    'DataGrid1.DataSource = ds1.Tables(0)

'Catch ex As Exception
'    MessageBox.Show("Baza nije otvorena!", "Informacija o pristupu bazi", _
'                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
'End Try
'OkpDbVeza.Close()

''    System.IO.File.WriteAllText("d:\Roba\Zahl140.txt", TextBox1.Text)


''    Dim myStream As Stream
''    Dim saveFileDialog1 As New SaveFileDialog()

''    saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
''    saveFileDialog1.FilterIndex = 2
''    saveFileDialog1.RestoreDirectory = True

''    If saveFileDialog1.ShowDialog() = DialogResult.OK Then
''        myStream = saveFileDialog1.OpenFile()
''        If (myStream IsNot Nothing) Then
''            ' Code to write the stream goes here.
''            myStream.Close()
''        End If
''    End If
''    ''If makcija = "Upd" Then
''    ''    System.IO.File.Delete(ToFile & "\" & broj1 & ".rtf")
''    ''TextBox1.SaveFile(ClientPath & "" & broj1 & ".rtf")
''    ''    System.IO.File.Copy(ClientPath & "" & broj1 & ".rtf", ToFile & "\" & broj1 & ".rtf")
''    ''Else

''    ''    '2.12.2011
''    ''    'GetFileSize(FromFile, mFileSize1)
''    ''    '2.12.2011
''    ''    Try
''    ''        RichTextBox1.SaveFile(ClientPath & "" & broj1 & ".rtf")
''    ''        'System.IO.File.Copy(ClientPath & "" & broj1 & ".rtf", ToFile & "\" & broj1 & ".rtf")
''    ''        'System.IO.File.Copy(ClientPath & "" & broj1 & ".rtf", "z:" & broj1 & ".rtf")
''    ''        System.IO.File.Copy(ClientPath & "" & broj1 & ".rtf", ToFile & "\" & broj1 & ".rtf")
''    ''    Catch ex As Exception
''    ''        rv = "Greska"
''    ''    End Try
''    ''    If rv <> "" Then Throw New Exception(rv)

''    ''End If

''    ''Dim xRedniBroj As Int16 = 0

''    ''Catch ex As Exception
''    ''    rv = ex.Message
''    ''Catch sqlex As SqlException
''    ''    MsgBox(sqlex.Message)
''    ''Finally
''    ''    If rv = "" Then
''    ''        slogTrans.Commit()
''    ''    Else
''    ''        slogTrans.Rollback()
''    ''    End If
''    ''    WebVeza.Close()

''    ''End Try
''    ''If rv <> "" Then
''    ''    MsgBox(rv, MsgBoxStyle.Exclamation, "Greška u upisu")
''    ''Else
''    ''    MsgBox("Uspešan upis u bazu", MsgBoxStyle.Information, "Inserted")

''    ''End If
''End Sub
