using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace BussinessLibrary.CommDB.DAO
{
    interface IDAO
    {
        //初始化
        void Init(string conncting);

        //测试连接
        bool Test();

        //单表查询数据
        DataTable GetDataTable(string tablename, string filter);

        //更新数据库
        void UpdateDateTable(string tablename, DataTable table);

        //任意sql查询
        DataTable GeyDataTableBySql(string sql);

        //执行sql
        int ExecuteSql(string sql);

        //保存图片
        int SaveImage(string filter,string hdid);
    }
}
