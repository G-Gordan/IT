'''Imports System.Collections
'''Imports System.Text
'''Imports System.Xml
'''Imports System.IO


''''Public Class CXmlReader
'''Namespace SrbRailFolderMonitor
'''    ' Klasa koja cita xml fajl, radi validaciju i poziva upis u bazu
'''    Class CXmlReader
'''        Private m_DB As CDB_SQL

'''        Public Property DB() As CDB_SQL
'''            Get
'''                Return m_DB
'''            End Get
'''            Set(ByVal Value As CDB_SQL)
'''                m_DB = value
'''            End Set
'''        End Property

'''        ' Funkcija cita xml fajl i vrsi verifikaciju u skladu sa xsd fajlom.
'''        ' poziva funkcije za upis u bazu (iz klase CDB_SQL)
'''        Public Function Load(ByVal fi As XmlFileInfo, ByVal idFolderSuccess As Integer, ByVal idFolderFailed As Integer) As Integer
'''            Try
'''                Dim id_file As Integer = 0
'''                Dim ftp_date As DateTime
'''                'int id_stat = 0;
'''                Dim country As String = ""
'''                Dim station As String = ""
'''                Dim operater As String = ""
'''                Dim consignment_note As String = ""
'''                Dim idParent As Long = 0
'''                Dim doc As New XmlDocument
'''                Dim settings As XmlReaderSettings = Nothing
'''                Dim document As XmlDocument = Nothing

'''                Try
'''                    CLog.Log(fi.sPath, "CXmlReader.Load.Validate")
'''                    settings = New XmlReaderSettings
'''                    settings.Schemas.Add(Nothing, fi.sSchemaFile)
'''                    settings.ValidationType = ValidationType.Schema
'''                    document = New XmlDocument
'''                    document.Load(fi.sPath)
'''                    Dim rdr As XmlReader = XmlReader.Create(New StringReader(document.InnerXml), settings)
'''                    While rdr.Read()


'''                    End While
'''                    rdr.Close()
'''                Catch ex As Exception
'''                    CLog.Log(ex, "CXmlReader.LoadValidate")
'''                    m_DB.WriteXmlFile(id_file, Path.GetFileName(fi.sPath), fi.dtFtpDate, 4, fi.idFolder, idFolderFailed, _
'''                     "", "", "", "")
'''                    fi.idFile = id_file
'''                    Return 4
'''                End Try


'''                CLog.Log(("Write File: " & Path.GetFileName(fi.sPath) & " document:") + document.Name, "CXmlReader.Load.Write")
'''                Dim NL As XmlNodeList = document.GetElementsByTagName("versandbhf")
'''                For Each N__1 As XmlNode In NL
'''                    '<vw> (zemlja)       <bhfnr> (stanica)       <evu> (prevoznik)      <versandnr> (broj tovarnog lista)
'''                    For Each n__2 As XmlNode In N__1.ChildNodes
'''                        If n__2.Name = "vw" Then
'''                            country = n__2.InnerText
'''                        End If
'''                        If n__2.Name = "bhfnr" Then
'''                            station = n__2.InnerText
'''                        End If
'''                        If n__2.Name = "evu" Then
'''                            operater = n__2.InnerText
'''                        End If
'''                        If n__2.Name = "versandnr" Then
'''                            consignment_note = n__2.InnerText
'''                        End If
'''                    Next
'''                Next
'''                ' WRITE TO DB

'''                ' Status je 3. Ako sve bude u redu sto je najcesce nema izmene sloga, samo se fajl pomeri sa direktorijuma 

'''                If m_DB.WriteXmlFile(id_file, Path.GetFileName(fi.sPath), fi.dtFtpDate, 3, fi.idFolder, idFolderSuccess, _
'''                 country, station, operater, consignment_note) > 0 Then
'''                    fi.idFile = id_file

'''                    m_DB.BeginTransaction()
'''                    For Each n__2 As XmlNode In document.ChildNodes
'''                        If Not WriteNode(n__2, id_file, 1, idParent) Then
'''                            m_DB.Rollback()
'''                            Return 4
'''                        End If
'''                    Next
'''                    If m_DB.Commit() Then
'''                        Return 3
'''                    Else
'''                        Return 4
'''                    End If
'''                Else
'''                    Return 4
'''                End If
'''            Catch ex As Exception
'''                m_DB.Rollback()
'''                CLog.Log(ex, "CXmlReader.Load")
'''                Return 4
'''            End Try
'''        End Function

'''        ' Rekurzivna funkcija koja treba da upisu slog u bazu i pozove funkciju za upis atributa ako ih nod poseduje
'''        Private Function WriteNode(ByVal N__1 As XmlNode, ByVal id_file As Long, ByVal deep As Integer, ByVal idParent As Long) As Boolean
'''            Dim pos As Integer = 0
'''            Dim sNodeName As String = ""
'''            Dim sNodeValue As String = ""
'''            Dim sParentNodeName As String = ""
'''            Dim idNode As Long = 0, idNodeType As Long = 0
'''            Dim sNodeType As String = ""
'''            Dim bLast As Boolean = False

'''            Try
'''                deep += 1
'''                If deep > 100 Then
'''                    CLog.Log("Deep > 100", "CXmlReader.WriteNode")
'''                    Return False
'''                End If

'''                'string s = "Node: " + " deep=" + deep.ToString() + " Name=" + N.Name + " " + " Type=" + N.NodeType.ToString() + " ";
'''                sNodeName = N__1.Name
'''                sParentNodeName = N__1.ParentNode.Name

'''                ' WRITE TO DB

'''                'if (N.HasChildNodes)
'''                'CLog.Log("Node: " + N.Name + " Type=" + N.NodeType.ToString() + " deep=" + deep.ToString() + " ", "CXmlReader.WriteNode");
'''                pos = 1
'''                sNodeType = N__1.NodeType.ToString()
'''                idNodeType = Convert.ToInt64(N__1.NodeType)
'''                Select Case N__1.NodeType
'''                    Case XmlNodeType.XmlDeclaration
'''                        Exit Select
'''                    Case XmlNodeType.Text
'''                        sNodeValue = N__1.InnerText
'''                        bLast = True
'''                        Exit Select
'''                    Case XmlNodeType.Element
'''                        If N__1.ChildNodes.Count = 1 AndAlso N__1.FirstChild.NodeType = XmlNodeType.Text Then
'''                            sNodeValue = N__1.InnerText
'''                            bLast = True
'''                            Exit Select
'''                        End If
'''                        Exit Select
'''                    Case XmlNodeType.Comment
'''                        Exit Select
'''                    Case Else
'''                        Exit Select
'''                End Select

'''                If m_DB.WriteXmlNode(idNode, idParent, id_file, idNodeType, sNodeType, sNodeName, _
'''                 sNodeValue, sParentNodeName) > 0 Then
'''                    pos = 2
'''                    If Not bLast Then
'''                        If N__1.NodeType <> XmlNodeType.XmlDeclaration AndAlso N__1.Attributes.Count > 0 Then
'''                            pos = 3
'''                            If Not WriteAttributes(N__1, idNode) Then
'''                                Return False
'''                            End If
'''                        End If
'''                    End If
'''                    pos = 4
'''                    If Not bLast Then
'''                        If N__1.HasChildNodes Then
'''                            pos = 5
'''                            For Each n__2 As XmlNode In N__1.ChildNodes
'''                                pos = 6
'''                                If Not WriteNode(n__2, id_file, deep, idNode) Then
'''                                    Return False
'''                                End If
'''                            Next
'''                        End If
'''                    End If
'''                    Return True
'''                Else
'''                    Return False
'''                End If
'''            Catch ex As Exception
'''                CLog.Log(ex, "CXmlReader.WriteNode " & pos.ToString())
'''                Return False
'''            End Try
'''        End Function

'''        ' Funkcija koja treba da upise atribute noda
'''        Private Function WriteAttributes(ByVal N As XmlNode, ByVal idNode As Long) As Boolean
'''            Try
'''                Dim idAttr As Long = 0
'''                For Each a As XmlAttribute In N.Attributes
'''                    ' WRITE TO DB

'''                    'CLog.Log("Attribute: " + a.Name + "=" + a.Value, "CXmlReader.WriteAttributes");
'''                    m_DB.WriteXmlAttribute(idAttr, idNode, a.Name, a.Value)
'''                Next
'''                Return True
'''            Catch ex As Exception
'''                CLog.Log(ex, "CXmlReader.WriteAttributes")
'''                Return False
'''            End Try
'''        End Function
'''    End Class
'''End Namespace

''''End Class
