


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Security.Cryptography;


namespace BanSys_Ws.DAL
{
    public class DatabaseClass
    {
        System.Data.OleDb.OleDbTransaction dbtran;
       
        
        #region Properties

        public enum ConStringType
        {
            Configuration,
            General
        }
        //////////////////////////////////

        public OleDbConnection cn;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataSet ds;
        /////////////////////////////////

        #endregion

        #region Connection
        string connectionString;
        string FinalConn = "";

        public DatabaseClass(String ConnectionSting)
        {
            FinalConn = ConnectionSting;
            cn = new OleDbConnection(FinalConn);
        }


        public void OpenConnection()
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();
            }

           catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
       

        #endregion

        #region Command Execution Methods



        public DataTable ExecuteQuery(string sqlStmt)
        {
            cn = new OleDbConnection(FinalConn);
            cmd = new OleDbCommand(sqlStmt, cn);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            cmd.CommandTimeout = 600;
            try
            {
                OpenConnection();

                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex; // new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return ds.Tables[0];


        }
        public DataTable ExecuteQueryInsert(string sqlStmt)
        {
            cn = new OleDbConnection(FinalConn);
            cmd = new OleDbCommand(sqlStmt, cn);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            cmd.CommandTimeout = 600;
            try
            {
                OpenConnection();

                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex; // new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return ds.Tables[""];
        }

        public DataTable ExecuteQuery(OleDbCommand cmd)
        {
            // string str = Environment.UserName;         
            cn = new OleDbConnection(FinalConn);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            cmd.Connection = cn;
            cmd.CommandTimeout = 600;
            try
            {
                OpenConnection();

                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex; // new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return ds.Tables[0];
        }
        
       
       

        public int ExecuteNonQuery(OleDbCommand cmd)
        {
                       
            cn = new OleDbConnection(FinalConn);
            int recordsAffected;
            cmd.Connection = cn;
            cmd.CommandTimeout = 600;
            try
            {
                OpenConnection();

                recordsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                CloseConnection();
            }
            return recordsAffected;
        }
      


      
        






     




      
        
       
          
        

        #endregion
    }
}