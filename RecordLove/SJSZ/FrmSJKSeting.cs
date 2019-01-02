using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using BussinessLibrary.CommDB;
using DevExpress.XtraEditors;

namespace RecordLove.SJSZ
{
    public partial class FrmSJKSeting : DevExpress.XtraEditors.XtraForm
    {
        DBXML xml=new DBXML();
        public FrmSJKSeting()
        {
            InitializeComponent();
            btnSJKPath.Text = xml.XmlReader();
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDilalDialog = new OpenFileDialog();
            fileDilalDialog.Multiselect = true;
            fileDilalDialog.Title = @"请选择文件";
            fileDilalDialog.Filter = @"所有文件(*)|*.mdb";
            fileDilalDialog.InitialDirectory = Application.StartupPath;
            if (fileDilalDialog.ShowDialog() == DialogResult.OK)
            {
                btnSJKPath.Text = fileDilalDialog.FileName;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            xml.XmlWriter(btnSJKPath.Text);
            MessageBox.Show(@"保存成功");
            this.Close();
        }
    }
}