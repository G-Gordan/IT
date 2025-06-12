Imports System.Data
Imports System
'''Imports System.Data.OleDb
'''Imports System.Data.SqlClient
'''Imports System.IO
'''Imports System.Collections
'''Imports System.Configuration

'''Module Util
'''#Region "Write"
'''    Public Function WriteXmlFile(ByRef id_file As Integer, ByVal file_name As String, ByVal ftp_date As DateTime, ByVal id_stat As Integer, ByVal id_folder_src As Integer, ByVal id_folder_dest As Integer, _
'''    ByVal country As String, ByVal station As String, ByVal operater As String, ByVal consignment_note As String) As Integer
'''        'if (ConnectionOpened() <= 0) return 0;

'''        Try
'''            'ConnectionOpened()
'''            Dim cmd As New SqlCommand
'''            cmd.Connection = conn
'''            cmd.Parameters.Clear()
'''            cmd.CommandType = CommandType.StoredProcedure
'''            cmd.Transaction = tran
'''            cmd.CommandText = "ins_xml_files"

'''            cmd.Parameters.Add("@id_file", SqlDbType.Int).Value = DBNull.Value
'''            cmd.Parameters("@id_file").Direction = ParameterDirection.InputOutput
'''            cmd.Parameters.Add("@file_name", SqlDbType.NVarChar).Value = file_name
'''            cmd.Parameters.Add("@load_date", SqlDbType.DateTime).Value = DateTime.Now
'''            cmd.Parameters.Add("@ftp_date", SqlDbType.DateTime).Value = ftp_date
'''            cmd.Parameters.Add("@id_stat", SqlDbType.Int).Value = id_stat
'''            cmd.Parameters.Add("@id_folder_src", SqlDbType.Int).Value = id_folder_src
'''            cmd.Parameters.Add("@id_folder_dest", SqlDbType.Int).Value = id_folder_dest
'''            cmd.Parameters.Add("@country", SqlDbType.NVarChar).Value = country
'''            cmd.Parameters.Add("@station", SqlDbType.NVarChar).Value = station
'''            cmd.Parameters.Add("@operater", SqlDbType.NVarChar).Value = operater
'''            cmd.Parameters.Add("@consignment_note", SqlDbType.NVarChar).Value = consignment_note

'''            Dim ret As Integer = cmd.ExecuteNonQuery()

'''            id_file = Convert.ToInt32(cmd.Parameters("@id_file").Value)
'''        Catch ex As Exception
'''            CLog.Log(ex, "CDB_SQL.WriteXmlFile")
'''            Return 0
'''        End Try

'''        Return 1
'''    End Function

'''    Public Function UpdateXmlFile(ByVal id_file As Long, ByVal id_stat As Integer) As Integer
'''        'if (ConnectionOpened() <= 0) return 0;

'''        Try
'''            ConnectionOpened()
'''            Dim cmd As New SqlCommand
'''            cmd.Connection = conn
'''            cmd.Parameters.Clear()
'''            cmd.CommandType = CommandType.StoredProcedure
'''            cmd.Transaction = tran
'''            cmd.CommandText = "upd_xml_files"

'''            cmd.Parameters.Add("@id_file", SqlDbType.Int).Value = id_file
'''            cmd.Parameters.Add("@id_stat", SqlDbType.Int).Value = id_stat

'''            Dim ret As Integer = cmd.ExecuteNonQuery()
'''        Catch ex As Exception
'''            CLog.Log(ex, "CDB_SQL.UpdateXmlFile")
'''            Return 0
'''        End Try

'''        Return 1
'''    End Function
'''    Public Function WriteXmlNode(ByRef idNode As Long, ByVal idParent As Long, ByVal id_file As Long, ByVal idNodeType As Long, ByVal sNodeType As String, ByVal sNodeName As String, _
'''    ByVal sNodeValue As String, ByVal sParentNodeName As String) As Integer
'''        'if (ConnectionOpened() <= 0) return 0;

'''        Try
'''            Dim cmd As New SqlCommand
'''            cmd.Connection = conn
'''            cmd.Parameters.Clear()
'''            cmd.CommandType = CommandType.StoredProcedure
'''            cmd.Transaction = tran
'''            cmd.CommandText = "ins_xml_nodes"

'''            cmd.Parameters.Add("@id_node", SqlDbType.Int).Value = DBNull.Value
'''            cmd.Parameters("@id_node").Direction = ParameterDirection.InputOutput
'''            cmd.Parameters.Add("@id_parent", SqlDbType.Int).Value = idParent
'''            cmd.Parameters.Add("@id_node_type", SqlDbType.Int).Value = idNodeType
'''            cmd.Parameters.Add("@node_type_name", SqlDbType.NVarChar).Value = sNodeType
'''            cmd.Parameters.Add("@id_file", SqlDbType.Int).Value = id_file
'''            cmd.Parameters.Add("@node_name", SqlDbType.NVarChar).Value = sNodeName
'''            cmd.Parameters.Add("@node_value", SqlDbType.NVarChar).Value = sNodeValue
'''            cmd.Parameters.Add("@parent_node_name", SqlDbType.NVarChar).Value = sParentNodeName

'''            Dim ret As Integer = cmd.ExecuteNonQuery()

'''            idNode = Convert.ToInt64(cmd.Parameters("@id_node").Value)
'''        Catch ex As Exception
'''            CLog.Log(ex, "CDB_SQL.WriteXmlNode")
'''            Return 0
'''        End Try

'''        Return 1
'''    End Function

'''    Public Function WriteXmlAttribute(ByRef idAttr As Long, ByVal idNode As Long, ByVal sAttrName As String, ByVal sAttrValue As String) As Integer
'''        'if (ConnectionOpened() <= 0) return 0;

'''        Try
'''            Dim cmd As New SqlCommand
'''            cmd.Connection = conn
'''            cmd.Parameters.Clear()
'''            cmd.CommandType = CommandType.StoredProcedure
'''            cmd.Transaction = tran
'''            cmd.CommandText = "ins_node_attributes"

'''            cmd.Parameters.Add("@id_attr", SqlDbType.Int).Value = DBNull.Value
'''            cmd.Parameters("@id_attr").Direction = ParameterDirection.InputOutput
'''            cmd.Parameters.Add("@id_node", SqlDbType.Int).Value = idNode
'''            cmd.Parameters.Add("@attr_name", SqlDbType.NVarChar).Value = sAttrName
'''            cmd.Parameters.Add("@attr_value", SqlDbType.NVarChar).Value = sAttrValue

'''            Dim ret As Integer = cmd.ExecuteNonQuery()

'''            idAttr = Convert.ToInt64(cmd.Parameters("@id_attr").Value)
'''        Catch ex As Exception
'''            CLog.Log(ex, "CDB_SQL.WriteXmlAttribute")
'''            Return 0
'''        End Try

'''        Return 1
'''    End Function

'''#End Region

'''End Module
