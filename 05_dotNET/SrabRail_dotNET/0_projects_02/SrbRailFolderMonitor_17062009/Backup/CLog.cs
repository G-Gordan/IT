using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SrbRailFolderMonitor
{
    class CLog
    {
        public static void Log(Exception ex, string source)
        {
            try
            {
                if (Convert.ToInt32(ConfigurationSettings.AppSettings["write_log"]) != 1) return;
                System.Diagnostics.EventLog.WriteEntry("SrbRailFolderMonitor " + source,
                                                   ex.Message,
                                                   System.Diagnostics.EventLogEntryType.Error, 100);
            }
            catch (Exception ex1)
            {
                ;
            }

        }
        public static void Log(string s, string source)
        {
            try
            {
                if (Convert.ToInt32(ConfigurationSettings.AppSettings["write_log"]) != 1) return;
                System.Diagnostics.EventLog.WriteEntry("SrbRailFolderMonitor " + source,
                                                   s,
                                                   System.Diagnostics.EventLogEntryType.Information, 100);
            }
            catch (Exception ex)
            {
                ;
            }
        }
    }
}
