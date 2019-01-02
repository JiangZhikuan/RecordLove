using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BussinessLibrary.CommDB
{
    public class DBXML
    {
        private  string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"xml\DBSetXML.xml";

        public string XmlReader()
        {
            try
            {
                if (!File.Exists(FilePath)) return "";
                XmlSerializer ser = new XmlSerializer(typeof(DbSet));
                TextReader textReader = new StreamReader(FilePath);
                DbSet db = (DbSet)ser.Deserialize(textReader);
                textReader.Close();
                return db.DbPath;
            }
            catch (Exception e)
            {
                Log.Log.WriterLog(e.Message);
                return "";
            }
        }

        public void XmlWriter(string path)
        {
            DbSet db=new DbSet();
            XmlSerializer ser=new XmlSerializer(typeof(DbSet));
            TextWriter writer=new StreamWriter(FilePath);
            db.DbPath = path;
            ser.Serialize(writer,db);
            writer.Close();
        }
    }

    public class DbSet
    {
        public string DbPath;
    }
}
