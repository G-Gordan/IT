using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace SrbRailFolderMonitor
{
    // Klasa koja cita xml fajl, radi validaciju i poziva upis u bazu
    class CXmlReader
    {
        private CDB_SQL m_DB;

        public CDB_SQL DB
        {
            get { return m_DB; }
            set { m_DB = value; }
        }

        // Funkcija cita xml fajl i vrsi verifikaciju u skladu sa xsd fajlom.
        // poziva funkcije za upis u bazu (iz klase CDB_SQL)
        public int Load(XmlFileInfo fi, int idFolderSuccess, int idFolderFailed)
        {
            try
            {
                int id_file = 0;
                DateTime ftp_date;
                //int id_stat = 0;
                string country = "";
                string station = "";
                string operater = "";
                string consignment_note = "";
                long idParent = 0;
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = null;
                XmlDocument document = null;

                try
                {
                    CLog.Log(fi.sPath, "CXmlReader.Load.Validate");
                    settings = new XmlReaderSettings();
                    settings.Schemas.Add(null, fi.sSchemaFile);
                    settings.ValidationType = ValidationType.Schema;
                    document = new XmlDocument();
                    document.Load(fi.sPath);
                    XmlReader rdr = XmlReader.Create(new StringReader(document.InnerXml), settings);
                    while (rdr.Read())
                    {
                        ;
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    CLog.Log(ex, "CXmlReader.LoadValidate");
                    m_DB.WriteXmlFile(ref id_file, Path.GetFileName(fi.sPath), fi.dtFtpDate, 4, fi.idFolder, idFolderFailed, "", "", "", "");
                    fi.idFile = id_file;
                    return 4;
                }


                CLog.Log("Write File: " + Path.GetFileName(fi.sPath) + " document:" + document.Name , "CXmlReader.Load.Write");
                XmlNodeList NL = document.GetElementsByTagName("versandbhf");
                foreach (XmlNode N in NL)
                {
                    //<vw> (zemlja)       <bhfnr> (stanica)       <evu> (prevoznik)      <versandnr> (broj tovarnog lista)
                    foreach (XmlNode n in N.ChildNodes)
                    {
                        if (n.Name == "vw") country = n.InnerText;
                        if (n.Name == "bhfnr") station = n.InnerText;
                        if (n.Name == "evu") operater = n.InnerText;
                        if (n.Name == "versandnr") consignment_note = n.InnerText;
                    }
               }
               /* WRITE TO DB*/
               /* Status je 3. Ako sve bude u redu sto je najcesce nema izmene sloga, samo se fajl pomeri sa direktorijuma */
               if (m_DB.WriteXmlFile(ref id_file, Path.GetFileName(fi.sPath), fi.dtFtpDate, 3, fi.idFolder, idFolderSuccess, country, station, operater, consignment_note) > 0)
               {
                   fi.idFile = id_file;

                   m_DB.BeginTransaction();
                   foreach (XmlNode n in document.ChildNodes)
                   {
                       if (!WriteNode(n, id_file, 1, idParent))
                       {
                           m_DB.Rollback();
                           return 4;
                       }
                   }
                   if (m_DB.Commit()) return 3;
                   else return 4;
               }
               else
               {
                   return 4;
               }
            }
            catch (Exception ex)
            {
                m_DB.Rollback();
                CLog.Log(ex, "CXmlReader.Load");
                return 4;
            }
        }

        // Rekurzivna funkcija koja treba da upisu slog u bazu i pozove funkciju za upis atributa ako ih nod poseduje
        private bool WriteNode(XmlNode N, long id_file, int deep, long idParent)
        {
            int pos = 0;
            string sNodeName = "";
            string sNodeValue = "";
            string sParentNodeName = "";
            long idNode = 0, idNodeType = 0;
            string sNodeType = "";
            bool bLast=false;

            try
            {
                deep++;
                if (deep > 100)
                {
                    CLog.Log("Deep > 100", "CXmlReader.WriteNode");
                    return false;
                }
                
                //string s = "Node: " + " deep=" + deep.ToString() + " Name=" + N.Name + " " + " Type=" + N.NodeType.ToString() + " ";
                sNodeName = N.Name;
                sParentNodeName = N.ParentNode.Name;

                /* WRITE TO DB*/
                //if (N.HasChildNodes)
                //CLog.Log("Node: " + N.Name + " Type=" + N.NodeType.ToString() + " deep=" + deep.ToString() + " ", "CXmlReader.WriteNode");
                pos = 1;
                sNodeType = N.NodeType.ToString();
                idNodeType = Convert.ToInt64(N.NodeType);
                switch (N.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        break;
                    case XmlNodeType.Text:
                        sNodeValue = N.InnerText;
                        bLast = true;
                        break;
                    case XmlNodeType.Element:
                        if (N.ChildNodes.Count == 1 && N.FirstChild.NodeType == XmlNodeType.Text)
                        {
                            sNodeValue = N.InnerText;
                            bLast = true;
                            break;
                        }
                        break;
                    case XmlNodeType.Comment:
                        break;
                    default:
                        break;
                }

                if (m_DB.WriteXmlNode(ref idNode, idParent, id_file, idNodeType, sNodeType, sNodeName, sNodeValue, sParentNodeName) > 0)
                {
                    pos = 2;
                    if (!bLast)
                    {
                        if (N.NodeType != XmlNodeType.XmlDeclaration && N.Attributes.Count > 0)
                        {
                            pos = 3;
                            if (!WriteAttributes(N, idNode)) return false;
                        }
                    }
                    pos = 4;
                    if (!bLast)
                    {
                        if (N.HasChildNodes)
                        {
                            pos = 5;
                            foreach (XmlNode n in N.ChildNodes)
                            {
                                pos = 6;
                                if (!WriteNode(n, id_file, deep, idNode)) return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CXmlReader.WriteNode " + pos.ToString());
                return false;
            }
        }

        // Funkcija koja treba da upise atribute noda
        private bool WriteAttributes(XmlNode N, long idNode)
        {
            try
            {
                long idAttr = 0;
                foreach (XmlAttribute a in N.Attributes)
                {
                    /* WRITE TO DB*/
                    m_DB.WriteXmlAttribute(ref idAttr, idNode, a.Name, a.Value);
                    //CLog.Log("Attribute: " + a.Name + "=" + a.Value, "CXmlReader.WriteAttributes");
                }
                return true;
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CXmlReader.WriteAttributes");
                return false;
            }
        }
    }
}
