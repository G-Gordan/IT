Imports System.Threading
Imports System.IO
Imports System.Web.Mail

Public Class clsMailer
    Private objThread As Thread
    Private Sub Start()
        '
        Dim i As Integer
        Dim iCnt As Integer
        Dim sContents As String
        Dim objMessage As MailMessage
        Dim objMail As SmtpMail
        Dim oDir As DirectoryInfo
        Dim oDataFiles() As FileInfo
        Dim oErrorFile As FileInfo

        Do
            'ReadFiles from DataDirectory
            'This will be the subfolder "Emails" 
            'under the System32 Directory
            oDir = New DirectoryInfo(DataDirectory)
            oDataFiles = oDir.GetFiles()

            Dim asParams() As String

            iCnt = oDataFiles.Length
            For i = 0 To iCnt - 1
                Try

                    Dim oFileStr As FileStream = New FileStream(oDataFiles(i).FullName, FileMode.Open, _
                    FileAccess.Read, FileShare.Read)

                    objMessage = New MailMessage()

                    Dim oReader As StreamReader = _
                        New StreamReader(oFileStr)
                    sContents = oReader.ReadToEnd
                    asParams = Split(sContents, DELIMITER)

                    oReader.Close()
                    oFileStr.Close()

                    objMessage.From = asParams(0)
                    objMessage.To = asParams(1)
                    objMessage.Subject = asParams(2)
                    objMessage.Body = asParams(3)
                    SmtpMail.Send(objMessage)
                    'if successful, delete the file
                    oFileStr.Close()

                    oDataFiles(i).Delete()




                Catch Ex As Exception
                    'On Error, Log Event


                    WriteToEventLog("The following Exception occurred: " & Ex.Message, AppName, EventLogEntryType.Error)
                    'copy file to error directory
                    oDataFiles(i).MoveTo(ErrorDirectory & oDataFiles(i).Name)
                End Try

            Next
            'In my tests, this seems to be necessary to 
            'keep the app from hogging CPU resources.

            'It shouldn't be, based on what I've read. 
            objThread.Sleep(2000)
        Loop

    End Sub
    Public Sub MonitorAndSend()
        'Entry point for for class
        'Starts mointoring and sending on
        'new thread
        Dim objThreadStart As New ThreadStart(AddressOf Me.Start)
        objThread = New Thread(objThreadStart)
        objThread.Start()

    End Sub
    
End Class
