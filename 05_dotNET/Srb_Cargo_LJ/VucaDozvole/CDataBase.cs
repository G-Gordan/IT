using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace VucaDozvole
{

    public class CDataBase
    {
        public string mNazivFajla;
        public int mInd;
        public int mPostoji;
        public int mSMS;
        public int mRoming;
        public int mMedjun;
        public int mPlacTelekomu;
        public int mNaRate;
        public int mUplatnice;
        public int mMaticna;
        public int mTelekom;
        public int mRacunObr;
        public int mBrojRac;

        //public Int16 mRezultat;
        //public Int16 mRezIzm;

        public string mKorisnickaLozinka;
        public string connectionString;
        public SqlConnection SQLConn = new SqlConnection();         //SqlConnection :
        public SqlCommand sqlcmd;// = new SqlCommand();             //SqlCommand    :
        public SqlDataReader dr;     //[NE TREBA KONSTRUKTOR]       //SqlDataReader :
        public SqlDataAdapter da = new SqlDataAdapter();            //SqlDataAdapter:
        public SqlTransaction tr;     //[NE TREBA KONSTRUKTOR]      //SqlTransaction:
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        /*OleDB promenljive*/
        public string OLEDBconnString;
        public OleDbConnection OleDBConn = new OleDbConnection();
        public OleDbDataAdapter oleAdapter;
        public OleDbCommand olecmd;

        //
        private string putanjaTxt = " ";
        private string mGodina = " ";
        public CDataBase()
        {
            this.connectionString = WebConfigurationManager.ConnectionStrings["local_connect"].ToString();

            putanjaTxt = ConfigurationManager.AppSettings["putanjaTxt"];
            mGodina = ConfigurationManager.AppSettings["Godina"];

        }
        public void KonektujSeNaBazu()
        //--------------------------------------------------------------
        {

            try
            {
                SQLConn.ConnectionString = this.connectionString;
                HandleSQLConnection(SQLConn);

            }
            catch (SqlException ex)
            {
                string tt = ex.Message;

            }

        }
        //-------------------------------------------------------------------
        public static void HandleSQLConnection(SqlConnection oCn)
        //-------------------------------------------------------------------
        {

            switch (oCn.State)
            {
                case (ConnectionState.Open): //the connection is open
                    {
                        //close then re-open
                        oCn.Close();
                        oCn.Open();
                    } break;
                case (ConnectionState.Closed): //connection is open
                    {
                        //open the connection
                        oCn.Open();
                    } break;
                default:
                    {
                        oCn.Close();
                        oCn.Open();
                    } break;
            }
        }
        //=======================================================================
        public DataTable VratiTabelu(string dtImeTabele, string dtSQLQuery)
        //=======================================================================
        {
            this.KonektujSeNaBazu();

            sqlcmd = this.SQLConn.CreateCommand();
            sqlcmd.CommandText = dtSQLQuery;                               //This tells it what SQL to execute
            sqlcmd.CommandType = CommandType.Text;

            this.da.SelectCommand = this.sqlcmd;
            DataTable dt = new DataTable(dtImeTabele);

            this.da.Fill(dt);

            this.SQLConn.Close();
            this.SQLConn.Dispose();
            return dt;
        }
        //==================================================================================================
        public List<T> DataTableToListZS<T>(string dtSQLQuery, string dtImeTabele) where T : class, new()
        //==================================================================================================
        {
            DataTable table = this.VratiTabelu(dtImeTabele, dtSQLQuery);
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
        //==============================================================
        public string VratiVrednost(string Query)
        //==============================================================
        {
            this.KonektujSeNaBazu();
            sqlcmd = this.SQLConn.CreateCommand();
            sqlcmd.CommandText = Query;
            sqlcmd.CommandType = CommandType.Text;

            string rezultat = "1";
            object result = sqlcmd.ExecuteScalar();
            if (result != null)
            {
                rezultat = result.ToString();
            }

            this.SQLConn.Close();
            this.SQLConn.Dispose();
            return rezultat;
        }
        //==============================================================
        public int VratiVrednostN(string Query)
        //==============================================================
        {
            this.KonektujSeNaBazu();
            sqlcmd = this.SQLConn.CreateCommand();
            sqlcmd.CommandText = Query;
            sqlcmd.CommandType = CommandType.Text;

            int rezultat = 0;
            object result = sqlcmd.ExecuteScalar();
            if (result != null)
            {
                rezultat = Convert.ToInt16(result);
            }

            this.SQLConn.Close();
            this.SQLConn.Dispose();
            return rezultat;
        }
        //==============================================================
        public string DodajKorisnika(int mIdDoz, string mIme, string mZvanje, string mPred, string mOrgDeo, string mReon, string mBrLK, string mSUP, string mDatum, int mStampa)
        //==============================================================
        {

            string rezultat = "U";
            string QueryU = string.Format("EXEC  DodajKorisnika {0}, N'{1}',N'{2}',N'{3}',N'{4}',N'{5}','{6}',N'{7}','{8}',{9} ",
                                                             mIdDoz, mIme, mZvanje, mPred, mOrgDeo, mReon, mBrLK, mSUP, mDatum, mStampa);
                                              //                0       1       2      3       4      5       6     7       8       9
            try
            {
                //this.KonektujSeNaBazu();
                //sqlcmd = this.SQLConn.CreateCommand();
                //sqlcmd.CommandText = "DodajKorisnika";
                //sqlcmd.Parameters.Add("@mIdDoz", SqlDbType.Int).Value = mIdDoz;
                //sqlcmd.Parameters.Add("@mIme", SqlDbType.Char).Value = mIme;
                //sqlcmd.Parameters.Add("@mZvanje", SqlDbType.Char).Value = mZvanje;
                //sqlcmd.Parameters.Add("@mPred", SqlDbType.Char).Value = mPred;
                //sqlcmd.Parameters.Add("@mOrgDeo", SqlDbType.Char).Value = mOrgDeo;
                //sqlcmd.Parameters.Add("@mReon", SqlDbType.Char).Value = mReon;
                //sqlcmd.Parameters.Add("@mBrLK", SqlDbType.Char).Value = mBrLK;
                //sqlcmd.Parameters.Add("@mSUP", SqlDbType.Char).Value = mSUP;
                //// sqlcmd.Parameters.Add("@mDatum", SqlDbType.DateTime).Value = mDatum;
                //sqlcmd.Parameters.Add("@mDatum", SqlDbType.Char).Value = mDatum;
                //sqlcmd.Parameters.Add("@mStampa", SqlDbType.Int).Value = mStampa;
                //sqlcmd.CommandType = CommandType.StoredProcedure;
                //sqlcmd.CommandTimeout = 500;

                //int rez = (int)sqlcmd.ExecuteNonQuery();
                //rezultat = "U";
                //this.SQLConn.Close();
               
                string rez = this.VratiVrednost(QueryU);

            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string IzmeniKorisnika(int mIdDoz, string mIme, string mZvanje, string mPred, string mOrgDeo, string mReon, string mBrLK, string mSUP, string mDatum)
        //==============================================================
        {

            string rezultat = "U";
            string QueryU = string.Format("EXEC  IzmeniKorisnika {0}, N'{1}',N'{2}',N'{3}',N'{4}',N'{5}','{6}',N'{7}','{8}' ",
                                                            mIdDoz, mIme, mZvanje, mPred, mOrgDeo, mReon, mBrLK, mSUP, mDatum);
                                            //                0       1       2      3       4      5       6     7       8       9
            try
            {
                //this.KonektujSeNaBazu();
                //sqlcmd = this.SQLConn.CreateCommand();
                //sqlcmd.CommandText = "IzmeniKorisnika";
                //sqlcmd.Parameters.Add("@mIdDoz", SqlDbType.Int).Value = mIdDoz;
                //sqlcmd.Parameters.Add("@mIme", SqlDbType.Char).Value = mIme;
                //sqlcmd.Parameters.Add("@mZvanje", SqlDbType.Char).Value = mZvanje;
                //sqlcmd.Parameters.Add("@mPred", SqlDbType.Char).Value = mPred;
                //sqlcmd.Parameters.Add("@mOrgDeo", SqlDbType.Char).Value = mOrgDeo;
                //sqlcmd.Parameters.Add("@mReon", SqlDbType.Char).Value = mReon;
                //sqlcmd.Parameters.Add("@mBrLK", SqlDbType.Char).Value = mBrLK;
                //sqlcmd.Parameters.Add("@mSUP", SqlDbType.Char).Value = mSUP;
                //// sqlcmd.Parameters.Add("@mDatum", SqlDbType.DateTime).Value = mDatum;
                //sqlcmd.Parameters.Add("@mDatum", SqlDbType.Char).Value = mDatum;
                //sqlcmd.CommandType = CommandType.StoredProcedure;
                //sqlcmd.CommandTimeout = 500;

                //int rez = (int)sqlcmd.ExecuteNonQuery();
                //rezultat = "U";
                //this.SQLConn.Close();

                string rez = this.VratiVrednost(QueryU);
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string Stampana(int mIdDoz)
        //==============================================================
        {
            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "Stampana";
                sqlcmd.Parameters.Add("@mIdDoz", SqlDbType.Int).Value = mIdDoz;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;
                int rez = (int)sqlcmd.ExecuteNonQuery();
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }

        //==============================================================
        public string BrisiKorisnika(int mIdDoz)
        //==============================================================
        {
            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "BrisiKorisnika";
                sqlcmd.Parameters.Add("@mIdDoz", SqlDbType.Int).Value = mIdDoz;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;
                int rez = (int)sqlcmd.ExecuteNonQuery();
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string DodajOveru(int mIdDoz, int mGodina)
        //==============================================================
        {

            string rezultat = "0";
            mPostoji = 9;
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "DodajOveru";


                sqlcmd.Parameters.Add("@mIdDoz", SqlDbType.Int).Value = mIdDoz;
                sqlcmd.Parameters.Add("@mGodina", SqlDbType.Int).Value = mGodina;
                sqlcmd.Parameters.Add("@mPostoji", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mPostoji"].Direction = ParameterDirection.Output;

                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                mPostoji = Convert.ToInt16(sqlcmd.Parameters["@mPostoji"].Value);


                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        // KKKKKKKKKKKKKKKKKKKKKKKKKKKKK
        //==============================================================
        public string IzvrsiExport(string mMesec, string mGodina, string mMesecu, string mGodinau)
        //==============================================================
        {

            string rezultat = "0";
            // int rr = 0;
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "ExportZaLD";

                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;

                sqlcmd.Parameters.Add("@mesecu", SqlDbType.Char).Value = mMesecu;
                sqlcmd.Parameters.Add("@godinau", SqlDbType.Char).Value = mGodinau;

                sqlcmd.Parameters.Add("@putanja", SqlDbType.VarChar).Value = putanjaTxt;

                sqlcmd.Parameters.Add("@NazivFajla", SqlDbType.VarChar).Value = "00000";
                sqlcmd.Parameters["@NazivFajla"].Direction = ParameterDirection.Output;

                //sqlcmd.Parameters.Add("@ind", SqlDbType.Int).Value = 0;
                //sqlcmd.Parameters["@ind"].Direction = ParameterDirection.Output;


                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                string mNazivFajla1 = (sqlcmd.Parameters["@NazivFajla"].Value).ToString();
                //mInd =Convert.ToInt16(sqlcmd.Parameters["@ind"].Value);
                mNazivFajla = putanjaTxt; ;
                rezultat = "U";
                // rr = 1;

                this.SQLConn.Close();
                //string rez = "U";

            }
            catch (Exception ex)
            {
                rezultat = "N";
                // rr = 0;

            }

            return rezultat;
        }
        //==============================================================
        public int PripremiRacun(string mMesec, string mGodina)
        //==============================================================
        {
            int rezultat = 0;
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "PripremiRacun";
                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;

                sqlcmd.Parameters.Add("@mBrojRac", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mBrojRac"].Direction = ParameterDirection.Output;

                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                mBrojRac = Convert.ToInt32(sqlcmd.Parameters["@mBrojRac"].Value);
                rezultat = mBrojRac;
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = 0;
            }
            return rezultat;
        }
        //==============================================================
        public string PripremiMaticnu(string mMesec, string mGodina)
        //==============================================================
        {
            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "PripremiMaticnu";
                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string PripremiTabele(string mTab, string mMesec, string mGodina)
        //==============================================================
        {
            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "PripremiTabele";
                sqlcmd.Parameters.Add("@mTab", SqlDbType.Char).Value = mTab;
                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string ObradiRacun(string mMesec, string mGodina)
        //==============================================================
        {
            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "MesecniRacun";
                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string DodajSlog(string mIdTab, string mBrTel, decimal mIznos, string mMesec, string mGodina)
        //==============================================================
        {

            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "DodajSlog";
                sqlcmd.Parameters.Add("@IdTab", SqlDbType.Char).Value = mIdTab;
                sqlcmd.Parameters.Add("@mBrTel", SqlDbType.Char).Value = mBrTel;
                sqlcmd.Parameters.Add("@mIznos", SqlDbType.Decimal).Value = mIznos;
                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string DodajSlogMT(string mJMBG, string mIme, string mOrg, string mBrTelMT, decimal mLimit, string mMesec, string mGodina)
        //==============================================================
        {

            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "DodajSlogMT";
                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;
                sqlcmd.Parameters.Add("@mJMBG", SqlDbType.Char).Value = mJMBG;
                sqlcmd.Parameters.Add("@mIme", SqlDbType.VarChar).Value = mIme;
                sqlcmd.Parameters.Add("@mOrg", SqlDbType.Char).Value = mOrg;
                sqlcmd.Parameters.Add("@mBrTelMT", SqlDbType.VarChar).Value = mBrTelMT;
                sqlcmd.Parameters.Add("@mLimit", SqlDbType.Decimal).Value = mLimit;


                sqlcmd.Parameters.Add("@mPostoji", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mPostoji"].Direction = ParameterDirection.Output;

                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                mPostoji = Convert.ToInt16(sqlcmd.Parameters["@mPostoji"].Value);
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string BrisiSlog(string mIdTab, string mBrTel, string mMesec, string mGodina)
        //==============================================================
        {
            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "BrisiSlog";
                sqlcmd.Parameters.Add("@IdTab", SqlDbType.Char).Value = mIdTab;
                sqlcmd.Parameters.Add("@mBrTel", SqlDbType.Char).Value = mBrTel;
                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string BrisiSlogMT(string mBrTel, string mMesec, string mGodina)
        //==============================================================
        {
            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "BrisiSlogMT";
                sqlcmd.Parameters.Add("@mBrTel", SqlDbType.Char).Value = mBrTel;
                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }

        //==============================================================
        public string IzmeniSlogMT(string mJMBG, string mIme, string mOrg, decimal mLimit, string mBrTel, string mMesec, string mGodina)
        //==============================================================
        {


            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "IzmeniSlogMT";
                sqlcmd.Parameters.Add("@mJMBG", SqlDbType.Char).Value = mJMBG;
                sqlcmd.Parameters.Add("@mIme", SqlDbType.NVarChar).Value = mIme;
                sqlcmd.Parameters.Add("@mOrg", SqlDbType.Char).Value = mOrg;
                sqlcmd.Parameters.Add("@mLimit", SqlDbType.Char).Value = mLimit;

                sqlcmd.Parameters.Add("@mBrTel", SqlDbType.Char).Value = mBrTel;
                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string ArhivirajMaticnu(string mMesec, string mGodina)
        //==============================================================
        {
            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "ArhivirajMaticnu";

                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();
                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }
        //==============================================================
        public string Statistika(string mMesec, string mGodina)
        //==============================================================
        {
            string rezultat = "0";
            try
            {
                this.KonektujSeNaBazu();
                sqlcmd = this.SQLConn.CreateCommand();
                sqlcmd.CommandText = "Statistika";

                sqlcmd.Parameters.Add("@mesec", SqlDbType.Char).Value = mMesec;
                sqlcmd.Parameters.Add("@godina", SqlDbType.Char).Value = mGodina;

                sqlcmd.Parameters.Add("@mSMS", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mSMS"].Direction = ParameterDirection.Output;

                sqlcmd.Parameters.Add("@mRoming", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mRoming"].Direction = ParameterDirection.Output;

                sqlcmd.Parameters.Add("@mMedjun", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mMedjun"].Direction = ParameterDirection.Output;

                sqlcmd.Parameters.Add("@mPlacTelekomu", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mPlacTelekomu"].Direction = ParameterDirection.Output;

                sqlcmd.Parameters.Add("@mNaRate", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mNaRate"].Direction = ParameterDirection.Output;

                sqlcmd.Parameters.Add("@mUplatnice", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mUplatnice"].Direction = ParameterDirection.Output;

                sqlcmd.Parameters.Add("@mMaticna", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mMaticna"].Direction = ParameterDirection.Output;

                sqlcmd.Parameters.Add("@mTelekom", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mTelekom"].Direction = ParameterDirection.Output;

                sqlcmd.Parameters.Add("@mRacunObr", SqlDbType.Int).Value = 0;
                sqlcmd.Parameters["@mRacunObr"].Direction = ParameterDirection.Output;

                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 500;

                int rez = (int)sqlcmd.ExecuteNonQuery();


                mSMS = Convert.ToInt16(sqlcmd.Parameters["@mSMS"].Value);
                mRoming = Convert.ToInt16(sqlcmd.Parameters["@mRoming"].Value);
                mMedjun = Convert.ToInt16(sqlcmd.Parameters["@mMedjun"].Value);
                mPlacTelekomu = Convert.ToInt16(sqlcmd.Parameters["@mPlacTelekomu"].Value);
                mNaRate = Convert.ToInt16(sqlcmd.Parameters["@mNaRate"].Value);
                mUplatnice = Convert.ToInt16(sqlcmd.Parameters["@mUplatnice"].Value);
                mMaticna = Convert.ToInt16(sqlcmd.Parameters["@mMaticna"].Value);
                mTelekom = Convert.ToInt16(sqlcmd.Parameters["@mTelekom"].Value);
                mRacunObr = Convert.ToInt16(sqlcmd.Parameters["@mRacunObr"].Value);

                rezultat = "U";
                this.SQLConn.Close();
            }
            catch (Exception ex)
            {
                rezultat = "N";
            }
            return rezultat;
        }

    }
}