using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Configuration;


namespace SrbRailFolderMonitor
{
    // Objekat koji sadrzi jedan fajl sa najbitnijim podacima
    class XmlFileInfo : object
    {
        string spath;
        long lsize;
        int nstatus; // 0- new  1- save in progress  2- saved  3- Loaded (ready to move)  4- error (not for use)
        string sschemafile;
        DateTime dtftpdate;
        long id_file; // id koji fajl dobije kod upisa u bazu
        int id_folder;

        public XmlFileInfo()
        {
            spath = "";
            lsize = 0;
            nstatus = 0;
            sschemafile = "";
            id_file = 0;
        }

        public string sPath {
            get { return spath; }
            set { spath = value; }
        }
        public long lSize
        {
            get { return lsize; }
            set { lsize = value; }
        }
        public int nStatus
        {
            get { return nstatus; }
            set { nstatus = value; }
        }
        public bool IsMatch(XmlFileInfo fi)
        {
            return fi.sPath == sPath;
        }
        public string sSchemaFile
        {
            get { return sschemafile; }
            set { sschemafile = value; }
        }
        public DateTime dtFtpDate
        {
            get { return dtftpdate; }
            set { dtftpdate = value; }
        }
        public long idFile
        {
            get { return id_file; }
            set { id_file = value; }
        }
        public int idFolder
        {
            get { return id_folder; }
            set { id_folder = value; }
        }
    }

    // Onbjekat koji sadrzi jedan direktorijum. Direktorijumi koji se razmatraju se citaju iz baze.
    public class FolderInfo : object
    {
        string sfolderpath;
        int nidfoldertype; // 1-Za skeniranje 2-uspesno uvezeni  3-greska u citanju  4-ne koristi se
        int nidfolder;
        string sschemafile;
        public string sFolderPath 
        {
            get { return sfolderpath; }
            set { sfolderpath = value; }
        }
        public int nIdFolderType
        {
            get { return nidfoldertype; }
            set { nidfoldertype = value; }
        }
        public int nIdFolder
        {
            get { return nidfolder; }
            set { nidfolder = value; }
        }
        public string sSchemaFile
        {
            get { return sschemafile; }
            set { sschemafile = value; }
        }
    }

    // Klasa koja sadrzi kolekcije fajlova i direktorijuma, objekte za rad sa bazom i xml fajlovima
    // i obezbedjuje glavne funkcije koje se pozivaju iz servisa
    public class XmlFilesLoader
    {
        #region Data ClassData
        public List<FolderInfo> folders; 
        private List<XmlFileInfo> xmlfiles;
        private CDB_SQL m_DB;
        private CXmlReader m_XmlReader;

        //private int m_cnt = 0; // count of scanning folders
        private bool m_bDB = false;
        private FolderInfo FolderSuccess;
        private FolderInfo FolderFailed;
        #endregion

        public XmlFilesLoader() 
        {
            try
            {
                folders = new List<FolderInfo>();
                xmlfiles = new List<XmlFileInfo>();
                m_DB = new CDB_SQL();
                m_XmlReader = new CXmlReader();
                m_XmlReader.DB = m_DB;
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "XmlFilesLoader.XmlFilesLoader");
            }
        }

        public bool InitService(bool bForseInit, ref Timer t) // Konekcija, iz baze procitam spisak direktorijuma...
        {
            try
            {
                if (m_bDB && !bForseInit) return true; // Da se spisak direktorijuma ne cita na svaki timer

                try
                {
                    double di = Convert.ToDouble(ConfigurationManager.AppSettings["timer_interval"]);
                    t.Interval = di;
                }
                catch (Exception ext)
                {
                    CLog.Log("Set timer interval", "XmlFilesLoader.InitService");
                    CLog.Log(ext, "XmlFilesLoader.InitService");
                }
                if (!m_DB.Connect()) return false;
                if (m_DB.ReadFolders(ref folders) <= 0) return false;

                // Write folder collection to Log
                for (int i = 0; i < folders.Count; i++)
                {
                    if (folders[i].nIdFolderType == 2) FolderSuccess = folders[i];
                    if (folders[i].nIdFolderType == 3) FolderFailed = folders[i];
                    CLog.Log(folders[i].sFolderPath + " " + folders[i].sSchemaFile, "XmlFilesLoader.InitService");
                }
                m_bDB = true;
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "XmlFilesLoader.InitService");
                return false;
            }

            return true;
        }
        public void CloseConnection()
        {
            try
            {
                m_DB.Disconnect();
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "XmlFilesLoader.CloseConnection");
            }
        }

        public void ScanFolders() 
        {
            try
            {
                //CLog.Log("ScanFolders", "XmlFilesLoader.ScanFolders");
                for (int i = 0; i < folders.Count; i++)
                {
                    if (folders[i].nIdFolderType == 1) {
                        CFS.ScanFolder(folders[i], ref xmlfiles);
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "XmlFilesLoader.ScanFolders");
            }
        }

        public void LoadFiles()
        {
            // Redom otvaram proveravam parsiram i upisujem u bazu fajlove sa statusom 2
            // Nakon uspesnog snimanja menjam status na 3 kako bi kasnije bili pomereni sa direktorijuma
            // Uhvatiti greske ako nije moguce citanje, ako fajl sadrzi gresku i ako nije uspeo upis u bazu.
            // U slucaju greske promeniti status na 4 kako ne bi dalje ulazio u obradu
            // Logovati greske u sistem log (mozda slanje na e-mail)
            try
            {
                //CLog.Log("LoadFiles", "XmlFilesLoader.LoadFiles");

                foreach (XmlFileInfo f in xmlfiles)
                {
                    CLog.Log(f.sPath + " status=" + f.nStatus.ToString() + " size=" + f.lSize, "XmlFilesLoader.LoadFiles");
                    if (f.nStatus == 2)
                    {
                        int ret = m_XmlReader.Load(f, FolderSuccess.nIdFolder, FolderFailed.nIdFolder);

                        f.nStatus = ret;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("SrbRailFolderMonitor Application LoadFiles()",
                                                   ex.Message,
                                                   System.Diagnostics.EventLogEntryType.Error, 30);
            }
        }

        public void MoveFiles()
        {
            // Sve sa statusom 3 pomerati na success direktorijum, ako ne uspe status na 5.
            // sve sa statusom 4 probati da se pomere na failed, ako ne uspe status na 5.
            try
            {
                XmlFileInfo f=null;
                int i = 0;
                while (i < xmlfiles.Count)
                {
                    f = xmlfiles[i];
                    //CLog.Log(f.sPath + " status=" + f.nStatus.ToString() + " size=" + f.lSize, "XmlFilesLoader.MoveFiles");
                    if (f.nStatus == 3)
                    {
                        f.nStatus = CFS.MoveFile(f.sPath, FolderSuccess.sFolderPath);

                        if (f.nStatus == 3) xmlfiles.RemoveAt(i);
                        else
                        {
                            /* WRITE TO DB */
                            m_DB.UpdateXmlFile(f.idFile, 5);
                            i++;
                        }
                    }
                    else if (f.nStatus == 4)
                    {
                        f.nStatus = CFS.MoveFile(f.sPath, FolderFailed.sFolderPath);

                        if (f.nStatus <= 4) xmlfiles.RemoveAt(i);
                        else
                        {
                            /* WRITE TO DB */
                            m_DB.UpdateXmlFile(f.idFile, 5);
                            i++;
                        }
                    }
                    else
                    {
                        m_DB.UpdateXmlFile(f.idFile, 5);
                        i++;
                    }
                } // while
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "XmlFilesLoader.MoveFiles");
            }

        }
    }
}
