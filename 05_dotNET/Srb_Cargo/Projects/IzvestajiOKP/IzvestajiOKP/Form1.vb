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
    Dim Ugovor As String

    Dim Saobracaj As String = 1
    Dim Smer As String
    Dim rv As Integer
    Dim rv1 As String
    ''Dim a As String = 140
    'Private WithEvents mobjPkgEvents As DTS.Package

    

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

    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        'If ComboBox1.Text = "" And ComboBox2.Text = "" Then
        '    Button1.Visible = True
        'Else
        '    Button1.Visible = False
        'End If
    End Sub


    'Private Sub VanRasponaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VanRasponaToolStripMenuItem1.Click
    '    Dim FIzv As New FormVanRasp
    '    Dim CRIzv As New VanRaspU1_K
    '    FIzv.CrystalReportViewer1().ReportSource = CRIzv
    '    'Prijavljivanje na bazu
    '    Dim CRConec As New ConnectionInfo
    '    CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
    '    CRConec.ServerName = "10.0.4.31"
    '    CRConec.DatabaseName = "OkpWinRoba"
    '    CRConec.UserID = "radnik"
    '    CRConec.Password = "roba2006"

    '    Dim param1 As String      'parametar koji se odnosi na korisnika
    '    Dim param2 As String
    '    'Dim racMesec As String
    '    Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
    '    param2 = Trim(Mesec)
    '    Godina = ComboBox2.Text
    '    param1 = Godina
    '    Try
    '        FIzv.CrystalReportViewer1.SelectionFormula = " {V_VanRUn165_K.ObrGodina}=('" & Godina & "') And {V_VanRUn165_K.ObrMesec}=('" & Mesec & "') "

    '        CRIzv.SetParameterValue(0, param1)
    '        CRIzv.SetParameterValue(1, param2)
    '        FIzv.Show()
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    'FIzv.Show()
    'End Sub

   

    Private Sub CODinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CODinToolStripMenuItem.Click
        Dim FIzv As New Form2
        Dim CRIzv As New Proba
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
        Dim param3 As String
        Dim Mesec As String
        Ugovor = Ugovor1.Text
        param1 = Ugovor
        Mesec = Trim(Microsoft.VisualBasic.Left(ComboBox1.Text, 2))
        param2 = Trim(Mesec)
        Godina = ComboBox2.Text
        param3 = Godina
        Try
            'FIzv.CrystalReportViewer1.SelectionFormula = " {tempTranzitCoMakis_dm01.ObrMesec}=('" & Mesec & "') And {tempTranzitCoMakis_dm01.ObrGodina}=('" & Godina & "')   "
            '" left({tempTranzitCOMakis_dm01.Ugovor},3)=('" & Ug & "') "
            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            CRIzv.SetParameterValue(2, param3)
            FIzv.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class

