using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security;
using System.IO;
using CRS_EncryptionData;
using CRS_EncryptionData.Algorithm;




//OLD WEB SERVESE


namespace BanSys_Ws
{
    /// <summary>
    /// Summary description for BanMethods
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class BanMethods : System.Web.Services.WebService
    {
        

        OleDbCommand command = new OleDbCommand();
       public string zzzz = @"Data Source = (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl)) ) ; User ID=crsdb;;Password=crsdb";
        DAL.DatabaseClass dbase = new DAL.DatabaseClass("Provider=MSDAORA;Data Source=orcl;User ID=crsdb;;Password=crsdb");

     




        #region old
        [WebMethod]
        public string SysDate()
        {
            try
            {
                string WQ = "select to_char(sysdate , 'DD-MM-YYYY HH24:Mi:SS') as sys from dual";
                return dbase.ExecuteQuery(WQ).Rows[0]["sys"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        //public string DESi(string i)
        //{
            
        //      //  string z = CRS_EncryptionData.Algorithm.DES_Algorithm.Encryption(i);
        //    //string o = CRS_EncryptionData.Algorithm.DES_Algorithm.Decryption(i);
        //  //  return   o;
        //}
        //[WebMethod]
        //public string DESd(string i)
        //{
        //    return CRS_EncryptionData.Algorithm.DES_Algorithm.Decryption(i);
        //}
        //CRS_EncryptionData.Algorithm.RSA_Algorithm r = new CRS_EncryptionData.Algorithm.RSA_Algorithm();
       
      
        public static byte[] toByte(string st)
        {

            return Encoding.ASCII.GetBytes(st);
        }
       
      
        //public string test(string txt)
        //{
        //    byte[] res;
        //    string o;

        //    using (Aes myAes = Aes.Create())
        //    {
        //    //   res =EncryptStringToBytes_Aes(txt, myAes.Key, myAes.IV);

        //    //  o = DecryptStringFromBytes_Aes(res, myAes.Key, myAes.IV);
        //    }



        // //   return Encoding.ASCII.GetString(res) +"******************" ;
        //}

        RSA_Algorithm ro = new RSA_Algorithm();
        [WebMethod]
        public string ddddd(string data)
        {


            return ro.Decryption(data);
        }
        public string rsatest(string data)
        {
            string s = data.Substring(0,5);
            data.Remove(0,5);

            return data;// ro.Decryption( ro.Encryption(data));
            
        }
        #endregion
        #region PROPARATES
        RSA_Algorithm RSA = new RSA_Algorithm();
        DES_Algorithm DES = new DES_Algorithm();
        BanSys_Ws.DAL.AES_Algorithm AES = new BanSys_Ws.DAL.AES_Algorithm();
        string Results, Results1, Results2, Results3, R3 ,Re;
        string s;
        DataTable dt = new DataTable();
        #endregion
        #region saved data
        [WebMethod]
            public bool saveddata(string data)
        {

            try
            {

            string flag = data.Substring(0,1);
            string data2= data.Substring(1);
            string[] a = data2.Split('õ');
            string s1 = a[0];
            string s2 = a[1];
            string s3 = a[2];

            if (flag == "!")
            {
                Results1 = RSA.Decryption(s1);
                Results2 = DES.Decryption(s2);
                Results3 = AES.Decryption(s3);
            }
            if (flag == "@")
            {
                Results1 = RSA.Decryption(s1);
                Results2 = AES.Decryption(s2);
                Results3 = DES.Decryption(s3);
            }
            if (flag == "#")
            {
                Results1 = AES.Decryption(s1);
                Results2 = RSA.Decryption(s2);
                Results3 = DES.Decryption(s3);
            }
            if (flag == "$")
            {
                Results1 = AES.Decryption(s1);
                Results2 = DES.Decryption(s2);
                Results3 = RSA.Decryption(s3);
            }
            if (flag == "%")
            {
                Results1 = DES.Decryption(s1);
                Results2 = RSA.Decryption(s2);
                Results3 = AES.Decryption(s3);
            }
            if (flag == "&")
            {
                Results1 = DES.Decryption(s1);
                Results2 = AES.Decryption(s2);
                Results3 = RSA.Decryption(s3);
            }

            Results = Results1 + Results2 + Results3;


            //string e = r1 + r2 + r3;
            string[] R = Results.Split('#');
           R3 = R[3] + "/" + R[4] + "/" + R[5];
                string r0 = Term(R[0]);
                string r1 = Term( R[1]);
                string r2 = Term( R[2]);
                string r6 = Term(R[6]);
                string r7 = Term(R[7]);
                string r8 = Term(R[8]);
                string r9 = Term(R[9]);
                string r10 = Term(R[10]);
                string r11 = Term(R[11]);
                string r12 = Term(R[12]);
                string r13 = Term(R[13]);
                string r14 = Term(R[14]);
                string r15 = Term(R[15]);
                string r16 = Term(R[16]);
                string r17 = Term(R[17]);
                string r18 = Term(R[18]);
                string r19 = Term(R[19]);
                string r20 = Term(R[20]);
                string r21 = Term(R[21]);
                string r22 = Term(R[22]);
                string r23 = Term(R[23]);
                string r24 = Term(R[24]);
                string r25 = Term(R[25]);
                string r26 = Term(R[26]);
                string r27 = Term(R[27]);
                string[] r272= r27.Split('\0');
                r27 = r272[0];

              
                string query = @"INSERT INTO CRSDB.INFO (
NATNUMBER,
 FNAME,
 FAMLE, 
BARTHDATE,
 NAME,
 SNAME, 
THNAME,
 FONAME, 
FATHER_NATIONALITY,
 COUNTRY_OF_BIRTH,
 OCCUPATION,
 SOCIAL_STATUS, 
BLOOD_TYPE,
 GENDER,
 PHONE,
 BIRTH_NUM, 
NAT_NUM,
 M_FNAME, 
M_SNAME,
 M_TNAME,
 M_FONAME,
 PLACE_OF_BIRTH,
 WORKPLACE,
 ADDRESS,
F_NAT_NUM,
 EDCATION) 
VALUES ('" + r19 + "','" + r0 + "', '" + r2 + "', '" + R3 + "', '" + r6 + "', '" +r7 + "', '" + r8 + "', '" +r9 + "', '" + r10 + "', '" + r11 + "', '" + r12 + "', '" + r13 + "', '" + r14 + "', '" + r15 + "', '" + r17 + "', '" + r18 + "', '" + r19 + "', '" + r24 + "', '" + r25 + "', '" + r26 + "', '" + r27 + "', '" + r21 + "', '" + r23 + "', '" + r22 + "', '" + r20 + "', '" + r16 + "')";
            DataTable dt = new DataTable();
            dt = dbase.ExecuteQueryInsert(query);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
         
        }
        public string Term(string str)
        {
            string[] t = str.Split('\0');
            return t[0];

        }

        #endregion
        #region retrev data
        [WebMethod]
        public string Rdata(string nat)
        {

            string data= getData(nat);
            Random r = new Random();
           
            int r1 = r.Next((data.Length * 10 / 100), (data.Length * 40 / 100));
            string s1 = data.Substring(0, r1);
            string a1 = data.Substring(r1);
            int r2 = r.Next((a1.Length * 10 / 100), (a1.Length * 70 / 100));
            string s2 = a1.Substring(0, r2);
            string s3 = a1.Substring(r2);
            int com = data.CompareTo(s1 + s2 + s3);
            return Random_selection(s1,s2,s3);

        }



        #endregion
        #region GET DATA
        public string getData(string nat)
        {

           
            string WQ = "SELECT * from info  where NATNUMBER  = '" + nat + "' ";
            try
            {
                dt = dbase.ExecuteQuery(WQ);
                for (int i = 0; i < 26; i++)
                {
                    Re += dt.Rows[0][i].ToString() + "#";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Re;


        }
        
        public string dtble(int pos)
        {
            return dt.Rows[0][pos].ToString() + "#";


        }
        #endregion
        #region Selection Algorithm

        string flag;
        public string Random_selection(string s1, string s2, string s3)
        {
            
            Random r = new Random();
            int RandomNum = r.Next((1), (6));

            // *********RSA----DES-----AES********flag = !
            if (RandomNum == 1)
            {
                Results1 = RSA.Encryption(s1);
                Results2 = DES.Encryption(s2);
                Results3 = AES.Encryption(s3);
                flag = "!";
            }
            // *********RSA----AES-----DES********flag =@
            if (RandomNum == 2)
            {
                Results1 = RSA.Encryption(s1);
                Results2 = AES.Encryption(s2);
                Results3 = DES.Encryption(s3);
                flag = "@";
            }
            // *********AES----RSA-----DES********flag =#
            if (RandomNum == 3)
            {
                Results1 = AES.Encryption(s1);
                Results2 = RSA.Encryption(s2);
                Results3 = DES.Encryption(s3);
                flag = "#";
            }
            // *********AES----DES-----RSA********flag =$
            if (RandomNum == 4)
            {
                Results1 = AES.Encryption(s1);
                Results2 = DES.Encryption(s2);
                Results3 = RSA.Encryption(s3);
                flag = "$";
            }
            // *********DES----RSA-----AES********flag =%
            if (RandomNum == 5)
            {

                Results1 = DES.Encryption(s1);
                Results2 = RSA.Encryption(s2);
                Results3 = AES.Encryption(s3);
                flag = "%";

            }
            // *********DES-----AES----RSA********flag =&
            if (RandomNum == 6)
            {
                Results1 = DES.Encryption(s1);
                Results2 = AES.Encryption(s2);
                Results3 = RSA.Encryption(s3);
                flag = "&";
            }
            Results = flag + Results1 + "õ" + Results2 + "õ" + Results3;


            return Results;
        }
        #endregion



        [WebMethod]
        

    }
}
