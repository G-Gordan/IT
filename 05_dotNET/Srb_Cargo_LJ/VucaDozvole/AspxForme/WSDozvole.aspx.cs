using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VucaDozvole.AspxForme
{
    public partial class WSDozvole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string MaxBroj()
        //**********************************************************************************
        {
            int mBroj = 0;
            string mBrojC = "0";
            CDataBase cd = new CDataBase();
            DataTable dt;
            String Query = "select  dbo.MaxBroj()";
            try
            {
                //mBroj =cd.VratiVrednostN(Query);
                //mBrojC = mBroj.ToString().PadLeft(4, '0');

                mBrojC = cd.VratiVrednost(Query).PadLeft(4, '0');
            }
            catch (Exception ex)
            {
                string exx = ex.ToString();
            }

            return mBrojC;

        }
        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string PostojiBroj(string mBroj)
        //**********************************************************************************
        {
            string mPostoji = "7";
           
            CDataBase cd = new CDataBase();           
            String Query = "select  dbo.PostojiBroj(" + mBroj + ")";
            try
            {               

                mPostoji = cd.VratiVrednost(Query);
            }
            catch (Exception ex)
            {
                string exx = ex.ToString();
            }

            return mPostoji;

        }
        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string DodajKorisnika(object Parametri4UDF)

        //**********************************************************************************
        {
            //List<Korisnik> aKor = new List<Korisnik>();
            Dictionary<string, object> tmp = (Dictionary<string, object>)Parametri4UDF;
            int mBroj = Convert.ToInt16(tmp["mBroj"]);
            string mIme = tmp["mIme"].ToString().Trim();
            string mZvanje = tmp["mZvanje"].ToString().Trim();
            string mPred = tmp["mPred"].ToString().Trim();
            string mOrg = tmp["mOrg"].ToString().Trim();
            string mReon = tmp["mReon"].ToString().Trim();
            string mBrLK = tmp["mBrLK"].ToString().Trim();
            string mSUP = tmp["mSUP"].ToString().Trim();

            //DateTime mDatum = Convert.ToDateTime(tmp["mDatum"]);
            string mDatum = tmp["mDatum"].ToString();
            int mStampa = Convert.ToInt16(tmp["mStampa"]);




            CDataBase cd = new CDataBase();
            string uspesno = " ";

            uspesno = cd.DodajKorisnika(mBroj, mIme, mZvanje, mPred, mOrg, mReon, mBrLK, mSUP, mDatum, mStampa);

            return uspesno;
        }
        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string IzmeniKorisnika(object Parametri4UDF)

        //**********************************************************************************
        {

            Dictionary<string, object> tmp = (Dictionary<string, object>)Parametri4UDF;
            int mBroj = Convert.ToInt16(tmp["mBroj"]);
            string mIme = tmp["mIme"].ToString().Trim();
            string mZvanje = tmp["mZvanje"].ToString().Trim();
            string mPred = tmp["mPred"].ToString().Trim();
            string mOrg = tmp["mOrg"].ToString().Trim();
            string mReon = tmp["mReon"].ToString().Trim();
            string mBrLK = tmp["mBrLK"].ToString().Trim();
            string mSUP = tmp["mSUP"].ToString().Trim();

            //DateTime mDatum = Convert.ToDateTime(tmp["mDatum"]);
            string mDatum = tmp["mDatum"].ToString();


            CDataBase cd = new CDataBase();
            string uspesno = " ";

            uspesno = cd.IzmeniKorisnika(mBroj, mIme, mZvanje, mPred, mOrg, mReon, mBrLK, mSUP, mDatum);

            return uspesno;
        }
        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string PrikaziKorisnike()
        //**********************************************************************************
        {
            List<Korisnik> aKor = new List<Korisnik>();
            CDataBase cd = new CDataBase();
            DataTable dt;
            dt = cd.VratiTabelu("dtDoz", "select * from dbo.Lista_Korisnici order by IdDoz");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Korisnik kor = new Korisnik();
                    kor.IdDoz = Convert.ToInt16(dr["IdDoz"]);
                    kor.IdDozC = dr["IdDoz"].ToString().PadLeft(4, '0');
                    kor.Ime = dr["Ime"].ToString();
                    kor.Zvanje = dr["Zvanje"].ToString();
                    kor.OrgDeo = dr["OrgDeo"].ToString();
                    kor.Preduzece = dr["Preduzece"].ToString();
                    kor.Reon = dr["Reon"].ToString();
                    kor.BrLK = dr["BrLK"].ToString();
                    kor.SUP = dr["SUP"].ToString();
                    kor.Datum = dr["Datum"].ToString();
                    kor.Stampa = Convert.ToInt16(dr["Stampa"]);
                    aKor.Add(kor);
                }
            }
            return new JavaScriptSerializer().Serialize(aKor);

        }
        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string PrikaziKorisnika1(string mBroj)
        //**********************************************************************************
        {
            int mIdDoz = Convert.ToInt16(mBroj);

            List<Korisnik> aKor = new List<Korisnik>();
            CDataBase cd = new CDataBase();
            DataTable dt;
            string Query = String.Format("select * from  List_Doz1({0})", mIdDoz);
            dt = cd.VratiTabelu("dtDoz", Query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Korisnik kor = new Korisnik();
                    kor.IdDoz = Convert.ToInt16(dr["IdDoz"]);
                    kor.IdDozC = dr["IdDoz"].ToString().PadLeft(4, '0');
                    kor.Ime = dr["Ime"].ToString();
                    kor.Zvanje = dr["Zvanje"].ToString();
                    kor.Preduzece = dr["Preduzece"].ToString();
                    kor.OrgDeo = dr["OrgDeo"].ToString();
                    kor.Reon = dr["Reon"].ToString();
                    kor.BrLK = dr["BrLK"].ToString();
                    kor.SUP = dr["SUP"].ToString();
                    kor.Datum = dr["Datum"].ToString();
                    kor.Stampa = Convert.ToInt16(dr["Stampa"]);
                    aKor.Add(kor);
                }
            }
            return new JavaScriptSerializer().Serialize(aKor);

        }
        //*************  REPORTS  and XLS  *************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //**********************************************************************************
        public static string FormirajListu(object Parametri4UDF)
        //**********************************************************************************
        {
            Dictionary<string, object> tmp = (Dictionary<string, object>)Parametri4UDF;


            string mRep = tmp["mRep"].ToString();
            int mDoz = Convert.ToInt16(tmp["mDoz"]);

            string por = "*";
            try
            {
                CExportPdf cex = new CExportPdf();
                por = cex.Exportuj(mRep, mDoz);
            }
            catch (Exception ex)
            {
                por = "*";
            }
            finally
            {
                // sqlConn.Close();
            }
            return por;
        }
        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        // public static string Stampana()
        public static string Stampana(string mBroj)

       //**********************************************************************************
        {

            int mIdDoz = Convert.ToInt16(mBroj);

            //  string mBroj = "5";
            CDataBase cd = new CDataBase();
            string uspesno = " ";

            uspesno = cd.Stampana(mIdDoz);

            return uspesno;
        }
        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string NapuniZaStampu(int mST)
        //**********************************************************************************
        {
            // 0 - neodstampane, 1-odstampane
            List<Korisnik> aKor = new List<Korisnik>();
            CDataBase cd = new CDataBase();
            //string QQ = string.Format("select IdDoz from dozvole where stampa={0}", mST);
            string QQ = " ";
            if (mST == 2)
            {
                QQ = "select IdDoz from dozvole order by IdDoz";
            }
            else
            {
                QQ = string.Format("select IdDoz from dozvole where stampa={0} order by IdDoz", mST);
            }
            DataTable dt;
            dt = cd.VratiTabelu("dtDoz", QQ);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Korisnik kor = new Korisnik();
                    kor.IdDoz = Convert.ToInt16(dr["IdDoz"]);
                    kor.IdDozC = dr["IdDoz"].ToString().PadLeft(4, '0');
                    aKor.Add(kor);
                }
            }
            return new JavaScriptSerializer().Serialize(aKor);

        }

        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        // public static string Stampana()
        public static string BrisiKorisnika(string mBroj)

    //**********************************************************************************
        {

            int mIdDoz = Convert.ToInt16(mBroj);

            //  string mBroj = "5";
            CDataBase cd = new CDataBase();
            string uspesno = " ";

            uspesno = cd.BrisiKorisnika(mIdDoz);

            return uspesno;
        }

        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string NapuniDozvole()
        //**********************************************************************************
        {

            List<Korisnik> aKor = new List<Korisnik>();
            CDataBase cd = new CDataBase();
            string QQ = string.Format("select IdDoz from dozvole order by IdDoz ");
            DataTable dt;
            dt = cd.VratiTabelu("dtDoz", QQ);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Korisnik kor = new Korisnik();
                    kor.IdDoz = Convert.ToInt16(dr["IdDoz"]);
                    kor.IdDozC = dr["IdDoz"].ToString().PadLeft(4, '0');
                    aKor.Add(kor);
                }
            }
            return new JavaScriptSerializer().Serialize(aKor);

        }

        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string DodajOveru(object Parametri4UDF)

        //**********************************************************************************
        {
            List<Overa> aOvera = new List<Overa>();
            Dictionary<string, object> tmp = (Dictionary<string, object>)Parametri4UDF;
            int mIdDoz = Convert.ToInt16(tmp["mIdDoz"]);
            int mGodina = Convert.ToInt16(tmp["mGodina"]);

            CDataBase cd = new CDataBase();
            string uspesno = " ";

            uspesno = cd.DodajOveru(mIdDoz, mGodina);
            int postoji = cd.mPostoji;
            if (postoji == 1) uspesno = "P";  //dupli- postoji brkola u bazi
            //if (uspesno == "U") if (cd.mPostoji == 2) uspesno = "B"; // neispravan kontrolni broj
            //if (uspesno == "U") if (cd.mPostoji == 3) uspesno = "L";  // duzina nije 12
            //if (uspesno == "U") if (cd.mPostoji == 4) uspesno = "S";  // postoji slovna oznaka u pom
            //if (uspesno == "U") if (cd.mPostoji == 5) uspesno = "K";  // postoji brkola u pom


            return uspesno;
        }

        //**********************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string PrikaziOverene()

        //**********************************************************************************
        {
            List<Overa> aOvera = new List<Overa>();
            CDataBase cd = new CDataBase();
            string QQ = string.Format("select * from  dbo.List_DozOv() ");
            DataTable dt;
            dt = cd.VratiTabelu("dtDoz", QQ);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Overa ov = new Overa();
                    ov.Broj = dr["Broj"].ToString();
                    ov.Godina = Convert.ToInt16(dr["Godina"]);
                    aOvera.Add(ov);
                }
            }
            return new JavaScriptSerializer().Serialize(aOvera);
        }



    }
}