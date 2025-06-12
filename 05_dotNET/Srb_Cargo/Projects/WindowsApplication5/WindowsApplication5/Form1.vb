
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public ConnectionString As String = " Server = 10.0.4.31;database=OkpWinRoba;user =roba214kp; password=Katarina"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ObrMesec As String
        Dim ObrGodina As String
        Dim rv As String
        Dim Raspod As String

        ObrGodina = ComboBox1.Text
        ObrMesec = ComboBox2.Text
        'Dim Rasp As DataRow = Raspod(ConnectionString, ObrMesec, ObrGodina, rv)

        Util.Raspod(ConnectionString, ObrMesec, ObrGodina, rv)

        'poziva izvestaj
        Dim FIzv As New Form2
        Dim CRIzv As New Raspodela2014
        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"


        Dim param1 As String 'parametar koji se odnosi na stanicu prispeća
        Dim param2 As String 'parametar koji se odnosi na korisnika

        param1 = ObrGodina
        param2 = ObrMesec

        Try
            FIzv.CrystalReportViewer1.SelectionFormula = "{RaspodelaRanko1.Godina}=('" & ObrGodina & "') and {RaspodelaRanko1.ObrMes}= '" & ObrMesec & "' "

            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)

            FIzv.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub ComboBox1_KeyPress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

End Class
