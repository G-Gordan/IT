using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using VucaDozvole.Reports;


namespace VucaDozvole
{
    public class CExportPdf
    {
        private string XUSER, XPASW, XBAZA, XSERV;
        private string putanjaPdf = " ";
        private string mGodina = " ";
        private string Stampac = " ";
        public CExportPdf()     //D:\WebDOZVOLA0\Telefoni\CExportPdf.cs
        {
            //putanja0 = (string)HttpContext.Current.Session["mPath0"];
            //putanjaTMP = (string)HttpContext.Current.Session["mPathTMP"] + "\\";

            //if (!System.IO.Directory.Exists(putanjaTMP)) System.IO.Directory.CreateDirectory(putanjaTMP);


            XUSER = ConfigurationManager.AppSettings["KLJ_USER"];
            XPASW = ConfigurationManager.AppSettings["KLJ_PASW"];
            XBAZA = ConfigurationManager.AppSettings["KLJ_BAZA"];
            XSERV = ConfigurationManager.AppSettings["KLJ_SERV"];


            putanjaPdf = ConfigurationManager.AppSettings["putanjaPdf"];
            Stampac = ConfigurationManager.AppSettings["Stampac"];
            // mGodina = ConfigurationManager.AppSettings["Godina"]; 
            //mUprava = (int)HttpContext.Current.Application["mUprava"];
            //mUpravaC = mUprava.ToString();
            //mRep = "~/Reports/";

        }
        public string Exportuj(string mIzv, int mDoz)
        {
            CDataBase cd = new CDataBase();

            string poruka = " ";
            string mDestinacija = " ";
            string mDestPor = " ";
            string mMesecBr = "11";
            switch (mIzv)
            {

                case "SL":
                    // vidi malu dozvolu  sa slikom      
                    string QuerySL = String.Format("select * from List_Doz1({0})", mDoz);
                    DataTable dtSL = cd.VratiTabelu("dtSL", QuerySL);
                    DozvolaSL repSL = new DozvolaSL();

                    repSL.SetDatabaseLogon(XUSER, XPASW, XSERV, XBAZA);
                    repSL.SetDataSource(dtSL);

                    mDestinacija = putanjaPdf + "DozvolaVidi.pdf";
                    mDestPor = mDestinacija;
                    poruka = ExportPdf(repSL, mDestinacija);
                    if (poruka == "U") { poruka = mDestinacija; }
                    else { poruka = "*"; }

                    break;
                case "PR":

                    //stampaj malu dozvolu
                    string QueryPR = String.Format("select * from List_Doz1({0})", mDoz);
                    DataTable dtPR = cd.VratiTabelu("dtPR", QueryPR);
                    DozvolaPR7A repPR = new DozvolaPR7A();

                    repPR.SetDatabaseLogon(XUSER, XPASW, XSERV, XBAZA);
                    repPR.SetDataSource(dtPR);

                    //1. za printer
                    //repPR.PrintOptions.PrinterName = "HP LaserJet M1522 MFP Series PS";
                    // repPR.PrintOptions.PrinterName = "HP LaserJet 400 MFP M425 PCL 6";
                    //repPR.PrintOptions.PrinterName = "Lexmark E340 (MS)";
                    repPR.PrintOptions.PrinterName = Stampac;

                    try
                    {
                        repPR.PrintToPrinter(1, false, 0, 0);
                        poruka = "odstampano";
                        string rez = cd.Stampana(mDoz);
                    }
                    catch (Exception ex)
                    {
                        string tt = ex.Message;
                        poruka = "greska";

                    }
                    break;
                case "PRV":
                    // stampaj dozvolu ali prvo pogledaj   
                    string QueryPP = String.Format("select * from List_Doz1({0})", mDoz);
                    DataTable dtPP = cd.VratiTabelu("dtPP", QueryPP);
                    DozvolaPR7A repPP = new DozvolaPR7A();

                    repPP.SetDatabaseLogon(XUSER, XPASW, XSERV, XBAZA);
                    repPP.SetDataSource(dtPP);

                    mDestinacija = putanjaPdf + "DozvolaStampaj.pdf";
                    mDestPor = mDestinacija;
                    poruka = ExportPdf(repPP, mDestinacija);
                    if (poruka == "U") { poruka = mDestinacija; string rez = cd.Stampana(mDoz); }
                    else { poruka = "*"; }

                    break;
                case "A4":

                    //podloga za stampu dozvole na A4

                   // DozvolaA4 rep4 = new DozvolaA4();
                    // rep4.PrintOptions.PrinterName = "HP LaserJet M1522 MFP Series PS";
                    //rep4.PrintOptions.PrinterName = "HP LaserJet 400 MFP M425 PCL 6";

                    //try
                    //{
                    //    rep4.PrintToPrinter(1, false, 0, 0);
                    //    poruka = "odstampano";
                    //}
                    //catch ( Exception ex)
                    //{
                    //    string tt = ex.Message;
                    //    poruka = "greska";

                    //}

                    //mDestinacija = putanjaPdf + "DozvolaOkvirA4.pdf";
                    //mDestPor = mDestinacija;
                    //poruka = ExportPdf(rep4, mDestinacija);
                    //if (poruka == "U") { poruka = mDestinacija; }
                    //else { poruka = "*"; }


                    break;
                case "AA":

                    ////dozvola na A4
                    //string QueryAA = String.Format("select * from List_Doz1({0})", mDoz);
                    //DataTable dtAA = cd.VratiTabelu("dtAA", QueryAA);
                    //DozvolaPR7A repAA = new DozvolaPR7A();

                    //repAA.SetDatabaseLogon(XUSER, XPASW, XSERV, XBAZA);
                    //repAA.SetDataSource(dtAA);

                    ////// repAA.PrintOptions.PrinterName = "HP LaserJet M1522 MFP Series PS";
                    ////// repAA.PrintOptions.PrinterName = "HP LaserJet 400 MFP M425 PCL 6";
                    ////repAA.PrintOptions.PrinterName = "Lexmark E340 (MS)";
                    ////try
                    ////{
                    ////    repAA.PrintToPrinter(1, false, 0, 0);
                    ////    poruka = "odstampano";

                    ////    //CDataBase cd = new CDataBase();
                    ////    string uspesno = " ";
                    ////    uspesno = cd.Stampana(mDoz);
                    ////}
                    ////catch (Exception ex)
                    ////{
                    ////    string tt = ex.Message;
                    ////    poruka = "greska";

                    ////}



                    //mDestinacija = putanjaPdf + "D3.pdf";
                    //mDestPor = mDestinacija;
                    //poruka = ExportPdf(repAA, mDestinacija);
                    //if (poruka == "U") { poruka = mDestinacija; }
                    //else { poruka = "*"; }

                    // 

                    break;
                case "DOZ":
                    //// Dozvola  ????????????????????????????????
                    //string Queryd = "select * from  TBroj";
                    //DataTable dtDoz = cd.VratiTabelu("dDoz", Queryd);
                    ////DOZVOLA0 repDoz = new DOZVOLA0();    
                    //DLICE repDoz = new DLICE();

                    //repDoz.SetDatabaseLogon(XUSER, XPASW, XSERV, XBAZA);
                    //repDoz.SetDataSource(dtDoz);

                    //mDestinacija = putanjaPdf + "DozvolaLice.pdf";
                    //mDestPor = mDestinacija;
                    //poruka = ExportPdf(repDoz, mDestinacija);
                    //if (poruka == "U") { poruka = mDestinacija; }
                    //else { poruka = "*"; }
                    //////nalicje
                    ////DNALICJE repDozn = new DNALICJE();    

                    ////repDozn.SetDatabaseLogon(XUSER, XPASW, XSERV, XBAZA);
                    ////repDozn.SetDataSource(dtDoz);

                    ////mDestinacija = putanjaPdf + "DozvolaNalicje.pdf";
                    ////mDestPor = mDestinacija;
                    ////poruka = ExportPdf(repDoz, mDestinacija);
                    ////if (poruka == "U") { poruka = mDestinacija; }
                    ////else { poruka = "*"; }

                    break;
                case "DON":

                    ////nalicje
                    //string Queryn = "select * from  TBroj";
                    //DataTable dtDon = cd.VratiTabelu("dDon", Queryn);
                    //DNALICJE repDon = new DNALICJE();

                    //repDon.SetDatabaseLogon(XUSER, XPASW, XSERV, XBAZA);
                    //repDon.SetDataSource(dtDon);

                    //mDestinacija = putanjaPdf + "DozvolaNalicje.pdf";
                    //mDestPor = mDestinacija;
                    //poruka = ExportPdf(repDon, mDestinacija);
                    //if (poruka == "U") { poruka = mDestinacija; }
                    //else { poruka = "*"; }

                    //break;
                case "SP":

                    //spisak korisnika
                    string Querysp = "select * from Lista_korisnici";
                    DataTable dtSP = cd.VratiTabelu("dSP", Querysp);
                    DSPISAK repSP = new DSPISAK();

                    repSP.SetDatabaseLogon(XUSER, XPASW, XSERV, XBAZA);
                    repSP.SetDataSource(dtSP);

                    mDestinacija = putanjaPdf + "Spisak.pdf";
                    mDestPor = mDestinacija;
                    poruka = ExportPdf(repSP, mDestinacija);
                    if (poruka == "U") { poruka = mDestinacija; }
                    else { poruka = "*"; }

                    break;


                default:
                    break;
            }

            return poruka;
        }

        /* =================================================================*/
        private string ExportPdf(ReportDocument rep1, String mPath)
        /* =================================================================*/
        {
            string uspesno = "U";

            try
            {
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();

                CrDiskFileDestinationOptions.DiskFileName = mPath;

                CrExportOptions = rep1.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    //  ExportFormatType = CrystalDecisions.Shared.ExportFormatType.WordForWindows; //You can also choose WordForWindows, RichText, Excel, HTML40 and more.
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;

                }
                rep1.Export();
                rep1.Close();
                rep1.Dispose();

            }
            catch (Exception ex)
            {
                CDataBase cd = new CDataBase();
                string tt;
                tt = ex.Message;
                //int rez = cd.UnosGreske(tt);
                // mRbr = cd.mRbr;
                uspesno = "G";
            }

            return uspesno;

        }

        

    }
}