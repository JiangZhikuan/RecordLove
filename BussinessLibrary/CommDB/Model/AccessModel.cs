using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using BussinessLibrary.CommDB.DAO;

namespace BussinessLibrary.CommDB.Model
{
    public class AccessModel
    {
        private IDAO dao = null;
        private AccessDAO m_accessDao = new AccessDAO();

        public void SetDb()
        {
            DBXML xml = new DBXML();
            string dbServer = xml.XmlReader();
            if(!File.Exists(dbServer))return;
            m_accessDao.Init(
                string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data source={0};jet oledb:database password=admin;",
                    dbServer));
            dao = m_accessDao;
        }

        public DataTable GetDataTable(string tablename, string filter)
        {
            return dao != null ? dao.GetDataTable(tablename, filter) : null;
        }
        
        public void UpdateDataTable(string tablename, DataTable table)
        {
            if (dao != null)
            {
                dao.UpdateDateTable(tablename, table);
            }
        }

        public DataTable GetDataTableBySql(string sql)
        {
            if (dao != null)
            {
                return dao.GeyDataTableBySql(sql);
            }
            else return null;
        }
        public int ExecuteSql(string sql)
        {
            if (dao != null)
            {
                return dao.ExecuteSql(sql);
            }
            else
            {
                return -1;
            }
        }

        public int SaveImage(string fileter,string hdid)
        {
            if (dao != null)
            {
                return dao.SaveImage(fileter,hdid);
            }
            else
            {
                return -1;
            }
        }
    }
}
