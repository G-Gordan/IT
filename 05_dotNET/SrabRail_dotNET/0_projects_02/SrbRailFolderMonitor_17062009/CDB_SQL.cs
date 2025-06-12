using System;
using System.Data;
using System.Windows;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Configuration;

namespace SrbRailFolderMonitor
{

    public class CDB_SQL
    {
        #region Data
        private SqlConnection conn;
        private SqlTransaction tran;
        private bool bTran;
        #endregion


        #region KonstruktorDestruktor
        public CDB_SQL()
        {
            conn = null;
            bTran = false;
            //Connect();
        }

        ~CDB_SQL()
        {
            //CLog.Log("~CDB_SQL ", "CDB_SQL");
            //Disconnect();
        }
        #endregion

        #region Konekcija
        public bool Connect()
        {
            try
            {
                // Konekcija
                string connstring = "";
                int nPwdCrypt = 0;
                connstring = ReadConnStringConfigFile("connectionString");
                nPwdCrypt = Convert.ToInt16(ReadConnStringConfigFile("PwdCrypt"));
                if (nPwdCrypt == 1)
                {
                    int pos1 = connstring.IndexOf("Password=");
                    int pos2 = connstring.IndexOf(";", pos1);
                    if (pos2 < 0) pos2 = connstring.Length;
                    string pwd1 = "Password=";
                    string pwd2 = connstring.Substring(pos1+9, pos2-(pos1+9));
                    byte[] encrypted = new byte[pwd2.Length];
                    for (int i=0; i<pwd2.Length; i++) 
                    {
                        encrypted[i] = Convert.ToByte(pwd2[i]);
                    }

                    RijndaelCryptography rijndael = new RijndaelCryptography();
                    string pwd3 = rijndael.Decrypt(encrypted);

                    connstring = connstring.Replace(pwd1 + pwd2, pwd1 + pwd3);
                    CLog.Log(connstring, "Connect()");

                }
                if (conn == null)
                    conn = new SqlConnection(connstring);

                if (conn.State != ConnectionState.Open)
                    conn.Open();
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CDB_SQL");
                return false;
            }
            if (conn.State == ConnectionState.Open)
            {
                CLog.Log("Connected", "CDB_SQL");
                return true;
            }
            else
                return false;
        }
        public void Disconnect()
        {
            try
            {
                CLog.Log("CDB_SQL::Disconnect() ", "CDB_SQL");
                if (conn != null) // && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CDB_SQL");
            }
        }

        private int ConnectionOpened()
        {
            try
            {
                // OPENED
                if (conn.State == ConnectionState.Open)
                {
                    if (ReadOne() > 0) return 1;
                    else
                    {
                        try
                        {
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            ;
                        }
                    }
                }

                CLog.Log("ConnectionOpened() state=" + ConnectionState.Closed.ToString(), "CDB_SQL");
                // CLOSED            
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        CLog.Log("ConnectionOpened() Connect()", "CDB_SQL");
                        Connect();
                    }
                    catch (Exception ex)
                    {
                        CLog.Log(ex, "CDB_SQL");
                    }
                    if (conn.State == ConnectionState.Open) return 1;
                }

                // BROKEN
                //if (conn.State == ConnectionState.Broken)
                //{
                //    conn.Close();
                //    Connect();
                //    if (conn.State == ConnectionState.Open) return 1;
                //}

                // RECREATE
                CLog.Log("ConnectionOpened() Recreate Connect", "CDB_SQL");
                conn.Dispose();
                conn = null;
                Connect();
                if (conn.State == ConnectionState.Open) return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                CLog.Log("SQL ConnectionOpened 2 " + ex.Message, "CDB_SQL");
                CLog.Log(ex, "CDB_SQL");
            }
            return 0;
        }
        private int ReadOne()
        {
            int n = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                //OracleDataReader reader;


                cmd.Connection = conn;
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select getdate()";

                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    //n = Convert.ToInt32(reader[0]);
                    n = 1;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                CLog.Log("ReadOne(): " + ex, "CDB_SQL");
                return 0;
            }

            return n;
        }

        #endregion

        #region Transakcija tran
        public bool BeginTransaction()
        {
            try
            {
                //CLog.Log("bTran=" + bTran.ToString(), "CDB_SQL.BeginTransaction");
                bTran = false;

                if (conn == null)
                    return false;

                if (conn.State == ConnectionState.Open) 
                {
                    tran = conn.BeginTransaction();
                    bTran = true;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CDB_SQL.BeginTransaction");
                return false;
            }
        }
        public bool Commit()
        {
            try
            {
                //CLog.Log("bTran=" + bTran.ToString(), "CDB_SQL.Commit");
                if (!bTran) return false;
                bTran = false;

                if (conn == null)
                    return false;

                if (conn.State == ConnectionState.Open)
                {
                    tran.Commit();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CDB_SQL.Commit");
                return false;
            }
        }
        public bool Rollback()
        {
            try
            {
                CLog.Log("bTran=" + bTran.ToString(), "CDB_SQL.Rollback");
                if (!bTran) return false;
                bTran = false;

                if (conn == null)
                    return false;

                if (conn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CDB_SQL.Rollback");
                return false;
            }
        }
        #endregion

        #region Read
        private string ReadConnStringConfigFile(string s)
        {
            try
            {
                string str;
                str = ConfigurationManager.AppSettings[s]; 
                CLog.Log(str, "CDB_SQL");
                return str;
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CDB_SQL");
                return null;
            }
        }

        public int ReadFolders(ref List<FolderInfo> folders)
        {
            if (ConnectionOpened() <= 0) return 0;

            int n = 0;
            int c = 0;
            System.Data.DataRow row;
            try
            {
                FolderInfo fi;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select id_folder_type, id_folder, isnull(folder_path, '') folder_path, isnull(schema_file, '') schema_file from folders order by id_folder_type, id_folder";

                //CLog.Log(cmd.CommandText, "CDB_SQL");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (Convert.ToInt16(reader["id_folder_type"]) != 4)
                    {
                        //Log("ReadFolders: " + Convert.ToString(reader["folder_path"]));
                        fi = new FolderInfo();
                        fi.nIdFolderType = Convert.ToInt16(reader["id_folder_type"]);
                        fi.nIdFolder = Convert.ToInt16(reader["id_folder"]);
                        fi.sFolderPath = Convert.ToString(reader["folder_path"]);
                        fi.sSchemaFile = Convert.ToString(reader["schema_file"]);

                        folders.Add(fi);
                        n++;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                folders = null;
                CLog.Log(ex, "CDB_SQL");
            }

            return n;
        }
       #endregion

        #region Write
        public int WriteXmlFile(ref int id_file,
	                            string file_name,
	                            DateTime ftp_date,
	                            int id_stat,
	                            int id_folder_src,
	                            int id_folder_dest,
	                            string country,
	                            string station,
                                string operater,
	                            string consignment_note)
        {
            //if (ConnectionOpened() <= 0) return 0;

            try
            {
                ConnectionOpened();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tran;
                cmd.CommandText = "ins_xml_files";

                cmd.Parameters.Add("@id_file", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters["@id_file"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@file_name", SqlDbType.NVarChar).Value = file_name;
                cmd.Parameters.Add("@load_date", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@ftp_date", SqlDbType.DateTime).Value = ftp_date;
                cmd.Parameters.Add("@id_stat", SqlDbType.Int).Value = id_stat;
                cmd.Parameters.Add("@id_folder_src", SqlDbType.Int).Value = id_folder_src;
                cmd.Parameters.Add("@id_folder_dest", SqlDbType.Int).Value = id_folder_dest;
                cmd.Parameters.Add("@country", SqlDbType.NVarChar).Value = country;
                cmd.Parameters.Add("@station", SqlDbType.NVarChar).Value = station;
                cmd.Parameters.Add("@operater", SqlDbType.NVarChar).Value = operater;
                cmd.Parameters.Add("@consignment_note", SqlDbType.NVarChar).Value = consignment_note;

                int ret = cmd.ExecuteNonQuery();

                id_file = Convert.ToInt32(cmd.Parameters["@id_file"].Value);
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CDB_SQL.WriteXmlFile");                
                return 0;
            }

            return 1;
        }

        public int UpdateXmlFile(long id_file,
                                int id_stat)
        {
            //if (ConnectionOpened() <= 0) return 0;

            try
            {
                ConnectionOpened();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tran;
                cmd.CommandText = "upd_xml_files";

                cmd.Parameters.Add("@id_file", SqlDbType.Int).Value = id_file;
                cmd.Parameters.Add("@id_stat", SqlDbType.Int).Value = id_stat;

                int ret = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CDB_SQL.UpdateXmlFile");
                return 0;
            }

            return 1;
        }

        
        public int WriteXmlNode(ref long idNode, long idParent, long id_file, long idNodeType, string sNodeType, string sNodeName, string sNodeValue, string sParentNodeName)
        {
            //if (ConnectionOpened() <= 0) return 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tran;
                cmd.CommandText = "ins_xml_nodes";

                cmd.Parameters.Add("@id_node", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters["@id_node"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@id_parent", SqlDbType.Int).Value = idParent;
                cmd.Parameters.Add("@id_node_type", SqlDbType.Int).Value = idNodeType;
                cmd.Parameters.Add("@node_type_name", SqlDbType.NVarChar).Value = sNodeType;
                cmd.Parameters.Add("@id_file", SqlDbType.Int).Value = id_file;
                cmd.Parameters.Add("@node_name", SqlDbType.NVarChar).Value = sNodeName;
                cmd.Parameters.Add("@node_value", SqlDbType.NVarChar).Value = sNodeValue;
                cmd.Parameters.Add("@parent_node_name", SqlDbType.NVarChar).Value = sParentNodeName;
 
                int ret = cmd.ExecuteNonQuery();

                idNode = Convert.ToInt64(cmd.Parameters["@id_node"].Value);
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CDB_SQL.WriteXmlNode");
                return 0;
            }

            return 1;
        }

        public int WriteXmlAttribute(ref long idAttr, long idNode, string sAttrName, string sAttrValue)
        {
            //if (ConnectionOpened() <= 0) return 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tran;
                cmd.CommandText = "ins_node_attributes";

                cmd.Parameters.Add("@id_attr", SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters["@id_attr"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@id_node", SqlDbType.Int).Value = idNode;
                cmd.Parameters.Add("@attr_name", SqlDbType.NVarChar).Value = sAttrName;
                cmd.Parameters.Add("@attr_value", SqlDbType.NVarChar).Value = sAttrValue;

                int ret = cmd.ExecuteNonQuery();

                idAttr = Convert.ToInt64(cmd.Parameters["@id_attr"].Value);
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CDB_SQL.WriteXmlAttribute");
                return 0;
            }

            return 1;
        }
        
        #endregion
    }

}