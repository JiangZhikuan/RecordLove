using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace BussinessLibrary.CommDB.DAO
{
    class AccessDAO:IDAO
    {

        private IDbConnection m_DBConnection = null;
        public void Init(string conncting)
        {
            if (m_DBConnection != null && m_DBConnection.State == ConnectionState.Open)
            {
                m_DBConnection.Close();
            }
            m_DBConnection=new OleDbConnection();
            m_DBConnection.ConnectionString = conncting;
            m_DBConnection.Open();
        }

        public bool Test()
        {
            if (m_DBConnection!=null)
            {
                if (m_DBConnection.State == ConnectionState.Open) return true;
                else
                {
                    try
                    {
                        m_DBConnection.Open();
                        if (m_DBConnection.State == ConnectionState.Open) return true;
                        else return false;
                    }
                    catch (Exception)
                    {

                        return false;
                    }   
                }
            }
            else
            {
                return false;
            }
        }

        private IDbCommand CreateCommand()
        {
            if (m_DBConnection != null)
            {
                if (m_DBConnection.State != ConnectionState.Open)
                {
                    m_DBConnection.Open();
                }
                return m_DBConnection.State == ConnectionState.Open ? m_DBConnection.CreateCommand() : null;
            }
            else return null;
        }

        private IDbDataAdapter CreateDataAdapter(IDbCommand selectccmd)
        {
            if (m_DBConnection != null)
            {
                OleDbDataAdapter dap=new OleDbDataAdapter(selectccmd as OleDbCommand);
                return dap;
            }
            else return null;
        }

        private IDbDataAdapter CreateUpdateDataAdapter(string tablename)
        {
            if (m_DBConnection != null)
            {
                IDbCommand cmd = CreateCommand();
                cmd.CommandText = "select * from " + tablename;
                IDbDataAdapter dap = CreateDataAdapter(cmd);

                OleDbCommandBuilder builder=new OleDbCommandBuilder(dap as OleDbDataAdapter);
                dap.InsertCommand = builder.GetInsertCommand();
                dap.UpdateCommand = builder.GetUpdateCommand();
                return dap;
            }
            else return null;
        }

        public System.Data.DataTable GetDataTable(string tablename, string filter)
        {
            IDbCommand cmd = CreateCommand();
            IDataAdapter myAdapter = CreateDataAdapter(cmd);
            try
            {
                if (cmd != null)
                {
                    if (filter != null)
                    {
                        if (filter.Trim() == string.Empty)
                        {
                            cmd.CommandText = "select * from " + tablename;
                        }
                        else
                        {
                            cmd.CommandText = "select * from " + tablename + " where " + filter;
                        }
                        DataSet ds = new DataSet();
                        myAdapter.Fill(ds);
                        return ds.Tables[0];
                    }
                    else return null;
                }
                else return null;
            }
            catch (Exception e)
            {
                Log.Log.WriterLog(e.Message);
                return null;
            }
        }

        public void UpdateDateTable(string tablename, System.Data.DataTable table)
        {
            IDbDataAdapter dap = CreateUpdateDataAdapter(tablename);
            OleDbDataAdapter oledap = dap as OleDbDataAdapter;
            oledap.Update(table);
        }

        public System.Data.DataTable GeyDataTableBySql(string sql)
        {
            IDbCommand cmd = CreateCommand();
            IDataAdapter myAdatapter = CreateDataAdapter(cmd);
            try
            {
                if (cmd != null)
                {
                    cmd.CommandText = sql;
                    DataSet ds = new DataSet();
                    myAdatapter.Fill(ds);
                    return ds.Tables[0];
                }
                else return null;
            }
            catch (Exception e)
            {
                Log.Log.WriterLog(e.Message);
                return null;
            }
        }

        public int ExecuteSql(string sql)
        {
            IDbCommand cmd = CreateCommand();
            try
            {
                cmd.CommandText = sql;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Log.Log.WriterLog(e.Message);
                return -1;
            }
        }

        public int SaveImage(string filter,string hdid)
        {
            try
            {
                FileStream fs = new FileStream(filter, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                byte[] buffer = br.ReadBytes((int) fs.Length);
                fs.Close();
                br.Close();
                OleDbCommand com =
                    new OleDbCommand(
                        "insert into  MHJY_Image  values('" + Guid.NewGuid().ToString() + "','" + hdid + "','" + filter.Split('\\')[filter.Split('\\').Length-1] + "',@pic,'" +
                        filter.Split('.')[filter.Split('.').Length - 1] +
                        "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", (OleDbConnection) m_DBConnection);

                ((OleDbParameter) com.Parameters.Add("@pic", OleDbType.Binary)).Value = buffer;
                return com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return -1;
                Log.Log.WriterLog(e.Message);
            }
        }
    }
}
