using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;
using System.Net;

namespace SrbRailFolderMonitor
{
    public partial class SrbRailFoldersMonitor : ServiceBase
    {
        private Timer t = null;
        private XmlFilesLoader m_XmlFilesLoader;

        public SrbRailFoldersMonitor()
        {
            InitializeComponent();
            m_XmlFilesLoader = new XmlFilesLoader();
            t = new Timer(10000); // Ovo treba da bude podesivo u app.config
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
        }

        #region StartStopPauseContinue
        protected override void OnStart(string[] args)
        {
            m_XmlFilesLoader.InitService(true, ref t); // Nije dobro ovde jer mozda jos nije startovan sql server ali treba zbog stop/start servisa
            t.Start();
        }

        protected override void OnStop()
        {
            t.Stop();
            m_XmlFilesLoader.CloseConnection();
        }

        protected override void OnPause()
        {
            t.Stop();
            m_XmlFilesLoader.CloseConnection();
        }

        protected override void OnContinue()
        {
            t.Start();
        }
        #endregion

        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                //System.Diagnostics.EventLog.WriteEntry("SrbRailFolderMonitor application", "t_Elapsed");

                // Timer ne treba da otkucava dok se ne obrade svi pristigli fajlovi
                t.Stop();
                m_XmlFilesLoader.InitService(false, ref t);
                m_XmlFilesLoader.ScanFolders();
                m_XmlFilesLoader.LoadFiles();
                m_XmlFilesLoader.MoveFiles();
                t.Start();
            }
            catch (Exception ex)
            {
                CLog.Log(ex, "Service1.t_Elapsed"); // Za slucaj da se desi "unhandled" exception
            }
        }
    }
}
