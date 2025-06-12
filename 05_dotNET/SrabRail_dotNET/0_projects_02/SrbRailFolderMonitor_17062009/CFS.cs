using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;
using System.Configuration;

namespace SrbRailFolderMonitor
{
    class CFS
    {
        // Funkcija skenira prosledjeni direktorijum i xml fajlove koje pronadje dodaje u kolekciju.
        // Ako su fajlovi vec u kolekciji menja im status ukoliko je snimanje u toku ili je zavrseno.
        public static int ScanFolder(FolderInfo folder, ref List<XmlFileInfo> xmlfiles)
        {
            try
            {
                XmlFileInfo f=null;
                DirectoryInfo dir = new DirectoryInfo(folder.sFolderPath);
                int nStatus = 0, pos= -1;
                string extStr = "";
                string ext = "";
                string[] extArray = new string[20];
                char[] extSplitter = { ';' };
                bool b = false;

                // Koje ekstenzije se nadgledaju
                extStr = ConfigurationManager.AppSettings["monitor_extensions"];
                extArray = extStr.Split(extSplitter);

                foreach (FileInfo file in dir.GetFiles())
                {
                    // Da li je ekstenzija fajla medju predvidjenima
                    b = false;
                    for (int x = 0; x < extArray.Length; x++)
                    {
                        if (file.Extension == extArray[x])
                        {
                            b = true;
                            break;
                        }
                    }
                    if (!b) continue;

                    f = new XmlFileInfo();
                    f.lSize = file.Length;
                    f.sPath = file.FullName;
                    f.dtFtpDate = file.LastWriteTime;
                    f.sSchemaFile = folder.sFolderPath + "\\" + folder.sSchemaFile;
                    f.idFolder = folder.nIdFolder;
                    nStatus = 0;
                    pos = -1;

                    //CLog.Log(f.sPath, "CFS.ScanFolder");
                    foreach (XmlFileInfo xf in xmlfiles)
                    {
                        //CLog.Log(xf.sPath + " == " + f.sPath, "CFS.ScanFolder");
                        if (xf.sPath == f.sPath)
                        {
                            pos = xmlfiles.IndexOf(xf);
                            if (xf.lSize == f.lSize  &&  xf.nStatus <= 2) nStatus = 2; // snimljen (ista velicina kao u proslom citanju direktorijuma)
                            else if (xf.nStatus == 5) nStatus = 5; // greska u pomeranju sa direktorijuma u prethodnom prolazu
                            else nStatus = 1; // snimanje u toku
                            break;
                        }
                    }

                    f.nStatus = nStatus;
                    //CLog.Log(" Change/Add" + f.sPath + " pos=" + pos.ToString() + " nStatus=" + f.nStatus.ToString(), "CFS.ScanFolder");
                    if (pos >= 0) 
                        xmlfiles[pos].nStatus = nStatus;
                    else 
                        xmlfiles.Add(f);

                    //CLog.Log(f.sPath + " " + f.nStatus.ToString(), "CFS.ScanFolder");
                } // foreach
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "CFS.ScanFolder");
            }

            return xmlfiles.Count;
        }

        // Funkcija pomera fajl na zahtevani direktorijum. 
        // Ako fajl vec postoji menja mu ime i pokusava da iskopira kako bi se izbegle greske zbog slucajnog snimanja istog fajla na ftp server.
        // Logika snimanja u bazu ili kasnijeg citanja treba da predvidi ovu situaciju
        public static int MoveFile(string sSrcPath, string sDestFolder)
        {
            try
            {
                string sExt = "", sFileName = "", sFile = "";
                int i = 0, pos=0;

                sExt = System.IO.Path.GetExtension(sSrcPath);
                sFileName = System.IO.Path.GetFileNameWithoutExtension(sSrcPath);
                sFile = System.IO.Path.GetFileName(sSrcPath);
                while (System.IO.File.Exists(sDestFolder + "\\" + sFile))
                {
                    i++;
                    if (i > 50) break;
                    sFile = sFileName + "_" + i.ToString() + sExt;
                }

                //if (sSrcPath.IndexOf("T40224232.xml") >= 0) throw new Exception("Access denied"); // Samo za test ponasanja ako ne uspe File.Move operacija
                File.Move(sSrcPath, Path.Combine(sDestFolder, sFile));
                pos = sDestFolder.LastIndexOf("\\");
                sDestFolder = sDestFolder.Substring(pos + 1);
                CLog.Log(Path.GetFileName(sSrcPath) + " -> " + sDestFolder + "\\" + sFile, "XmlFilesLoader.MoveFiles");
                return 3;
            }
            catch (Exception ex) 
            {
                CLog.Log(ex, "CFS.MoveFile");
                return 5; // Nije uspelo pomeranje sa direktorijuma
            }
            return 3;
        }
    }
}
