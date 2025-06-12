using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Configuration;

namespace SrbRailFolderMonitor
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

           //WriteEncryptedPwd(Context.Parameters["UserName"], Context.Parameters["UserPass"], Context.Parameters["DataSource"], Context.Parameters["Catalog"]); 
        }

        void WriteEncryptedPwd(string sUser, string sPwd, string sDataSource, string sInitialCatalog)
        {
            try
            {
                System.Diagnostics.EventLog.WriteEntry("SrbRailFolderMonitor Setup",
                                                        "WriteEncryptedPwd",
                                                        System.Diagnostics.EventLogEntryType.Information, 2);

                RijndaelCryptography rijndael = new RijndaelCryptography();

                rijndael.Encrypt(sPwd);

                string connstr;
                connstr = ConfigurationManager.AppSettings["connectionString"];
                System.Diagnostics.EventLog.WriteEntry("SrbRailFolderMonitor Setup",
                                                        connstr,
                                                        System.Diagnostics.EventLogEntryType.Information, 2);

                ReplaceValue(connstr, "User ID=", sUser);
                ReplaceValue(connstr, "Password=", rijndael.Encrypted.ToString());
                ReplaceValue(connstr, "Data Source=", sDataSource);
                ReplaceValue(connstr, "Initial Catalog=", sInitialCatalog);

                System.Diagnostics.EventLog.WriteEntry("SrbRailFolderMonitor Setup",
                                                        connstr,
                                                        System.Diagnostics.EventLogEntryType.Information, 2);
                // Snimanje u App.config
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["connectionString"].Value = connstr;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings"); 
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "ProjectInstaller.WriteEncryptedPwd");
                return;
            }

        }

        string ReplaceValue(string s, string skey, string snewvalue)
        {
            try
            {
                string sret = "";
                int pos1 = s.IndexOf(skey);
                int pos2 = s.IndexOf(";", pos1);
                if (pos2 < 0) pos2 = s.Length;
                string strval = s.Substring(pos1 + skey.Length, pos2 - (pos1 + skey.Length));

                sret = s.Replace(skey + strval, skey + snewvalue);
                return sret;
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "ProjectInstaller.ReplaceValue");
                return null;
            }
        }
    }
}