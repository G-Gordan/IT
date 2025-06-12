Imports System.ServiceProcess
Imports System.IO
Imports System.Collections
Imports System.Text
Imports System.Xml

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
        Me.Timer1.Interval = 6000
        '
        'Service1
        '
        Me.ServiceName = "Service1"
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
    ''''' C#
    '''' Funkcija cita xml fajl i vrsi verifikaciju u skladu sa xsd fajlom.
    '''' poziva funkcije za upis u bazu (iz klase CDB_SQL)
    '''Public Function Load(ByVal fi As XmlFileInfo, ByVal idFolderSuccess As Integer, ByVal idFolderFailed As Integer) As Integer
    '''    Try
    '''        Dim id_file As Integer = 0
    '''        Dim ftp_date As DateTime
    '''        'int id_stat = 0;
    '''        Dim country As String = ""
    '''        Dim station As String = ""
    '''        Dim operater As String = ""
    '''        Dim consignment_note As String = ""
    '''        Dim idParent As Long = 0
    '''        Dim doc As New XmlDocument
    '''        Dim settings As XmlReaderSettings = Nothing
    '''        Dim document As XmlDocument = Nothing

    '''        Try
    '''            CLog.Log(fi.sPath, "CXmlReader.Load.Validate")
    '''            settings = New XmlReaderSettings
    '''            settings.Schemas.Add(Nothing, fi.sSchemaFile)
    '''            settings.ValidationType = ValidationType.Schema
    '''            document = New XmlDocument
    '''            document.Load(fi.sPath)
    '''            Dim rdr As XmlReader = XmlReader.Create(New StringReader(document.InnerXml), settings)
    '''            While rdr.Read()


    '''            End While
    '''            rdr.Close()
    '''        Catch ex As Exception
    '''            CLog.Log(ex, "CXmlReader.LoadValidate")
    '''            m_DB.WriteXmlFile(id_file, Path.GetFileName(fi.sPath), fi.dtFtpDate, 4, fi.idFolder, idFolderFailed, _
    '''             "", "", "", "")
    '''            fi.idFile = id_file
    '''            Return 4
    '''        End Try


    '''        CLog.Log(("Write File: " & Path.GetFileName(fi.sPath) & " document:") + document.Name, "CXmlReader.Load.Write")
    '''        Dim NL As XmlNodeList = document.GetElementsByTagName("versandbhf")
    '''        For Each N__1 As XmlNode In NL
    '''            '<vw> (zemlja)       <bhfnr> (stanica)       <evu> (prevoznik)      <versandnr> (broj tovarnog lista)
    '''            For Each n__2 As XmlNode In N__1.ChildNodes
    '''                If n__2.Name = "vw" Then
    '''                    country = n__2.InnerText
    '''                End If
    '''                If n__2.Name = "bhfnr" Then
    '''                    station = n__2.InnerText
    '''                End If
    '''                If n__2.Name = "evu" Then
    '''                    operater = n__2.InnerText
    '''                End If
    '''                If n__2.Name = "versandnr" Then
    '''                    consignment_note = n__2.InnerText
    '''                End If
    '''            Next
    '''        Next
    '''        ' WRITE TO DB

    '''        ' Status je 3. Ako sve bude u redu sto je najcesce nema izmene sloga, samo se fajl pomeri sa direktorijuma 

    '''        If m_DB.WriteXmlFile(id_file, Path.GetFileName(fi.sPath), fi.dtFtpDate, 3, fi.idFolder, idFolderSuccess, _
    '''         country, station, operater, consignment_note) > 0 Then
    '''            fi.idFile = id_file

    '''            m_DB.BeginTransaction()
    '''            For Each n__2 As XmlNode In document.ChildNodes
    '''                If Not WriteNode(n__2, id_file, 1, idParent) Then
    '''                    m_DB.Rollback()
    '''                    Return 4
    '''                End If
    '''            Next
    '''            If m_DB.Commit() Then
    '''                Return 3
    '''            Else
    '''                Return 4
    '''            End If
    '''        Else
    '''            Return 4
    '''        End If
    '''    Catch ex As Exception
    '''        m_DB.Rollback()
    '''        CLog.Log(ex, "CXmlReader.Load")
    '''        Return 4
    '''    End Try
    '''End Function
    ''''' C#

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        Timer1.Enabled = True
        'fw = New StreamWriter(Environment.GetEnvironmentVariable("temp") & "\filesystem.log")
        'fsw = New FileSystemWatcher

        'If args.Length > 0 Then
        '    fsw.Path = args(0)
        '    fsw.IncludeSubdirectories = True
        'Else  ' default settings
        '    fsw.Path = "C:\"
        '    fsw.IncludeSubdirectories = False
        'End If

        'AddHandler fsw.Created, New FileSystemEventHandler(AddressOf File_Created)
        'AddHandler fsw.Deleted, New FileSystemEventHandler(AddressOf File_Deleted)
        'fsw.EnableRaisingEvents = True




    End Sub
    Private Sub Timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed



        Dim folderToZip As String
        folderToZip = "D:\KKK1"
        Dim path As String
        path = "D:\KKK"
        For Each File In folderToZip
            For Each extension In fileExtensions
                If LCase(oFSo.GetExtensionName(File)) = LCase(extension) Then
                    copyFile.CopyHere(File)
                    Dim i : i = 0
                    Dim target : target = oFSO.BuildPath(copyFile, oFSO.GetFileName(File))
                    While i < 100 And Not oFSO.FileExists(target)
                        i = i + 1
                        WScript.Sleep(10)
                    End While
                    Exit For
                End If
            Next
        Next


        Dim odredistefajla As String

        odredistefajla = "\\10.0.80.33\KKK1\proba.txt"
        'odredistefajla = "\\10.0.80.33\k"
        Dim qt As Integer, x As Integer
        Dim kopiraj As Boolean
        Dim path As String = "D:\"
        Dim folder As String, date_ As String, ZIP As String
        Dim TXTFile As String = path & "KKK\"
        'With TXTFile
        '    If "Text files (*.txt)|*.txt|All files (*.*)|*.*" Then
        '        FileCopy("d:\KKK\proba.txt", "\\10.0.80.33\KKK1\proba.txt")

        '    End If
        '    '.FilterIndex = 1
        '    '.InitialDirectory = "D:\KKK\"

        'End With
        'folder = TXTFile & "proba.txt"
        folder = odredistefajla
        FileCopy(TXTFile & "proba.txt", odredistefajla)
    End Sub
    'Public Sub File_Created(ByVal obj As Object, ByVal e As FileSystemEventArgs)
    '    fw.WriteLine(Now.ToShortDateString & " " & Now.ToShortTimeString & " - " & e.FullPath & " - Created")
    'End Sub

    'Public Sub File_Deleted(ByVal obj As Object, ByVal e As FileSystemEventArgs)
    '    fw.WriteLine(Now.ToShortDateString & " " & Now.ToShortTimeString & " - " & e.FullPath & " - Deleted")
    'End Sub


    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        fw.Close()
    End Sub


End Class
