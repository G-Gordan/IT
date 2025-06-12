
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class Upit_1


    'Private Sub OtpBrSt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtpBrSt.Click
    'Dim cryRpt As New ReportDocument
    'cryRpt.Load(C:\Users\gordan.grujic\Documents\Visual Studio 2008\Projects\WindowsApplication3\WindowsApplication3\CROtpBrSt.rpt)
    'CROtpBrSt.ReportSource = cryRpt
    'CROtpBrSt.Refresh()
    'End Sub

    Private Sub OtpBrSt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtpBrSt.Click
        Dim FIzv As New FormaZaCryRep           'FormaZaCryRep - naziv fome iz koje se poziva CR izvestaj i iz te klase se pravi objekat FIzv
        Dim CRIzv As New CROtpBrSt              'CROtpBrSt - naziv CR izvestaja koji se poziva i iz te klase se pravi objekat CRIzv
        FIzv.CrystalReportViewer1().ReportSource = CRIzv

        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "gordan"
        CRConec.Password = "Soba596"

        'Dim param1 As String      'parametar koji se odnosi na korisnika    -----------ovo su parametri, ako ih imaš
        'Dim param2 As String
        'param1 = Godina
        'param2 = Mesec

        'Try
        'CRIzv.SetParameterValue(0, param1)
        'CRIzv.SetParameterValue(1, param2)
        'FIzv.Show()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        FIzv.Show()
        'Form2.Show()  
    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()

    End Sub
End Class
