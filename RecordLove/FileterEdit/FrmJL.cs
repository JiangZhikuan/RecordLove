using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using BussinessLibrary.CommDB.Model;
using DevExpress.XtraEditors;

namespace RecordLove.FileterEdit
{

    public delegate void TrreeRearsh();
    public partial class FrmJL : DevExpress.XtraEditors.XtraForm
    {
        public event TrreeRearsh Rearsh;
        AccessModel model=new AccessModel();
        private DataRow _mRows;
        public FrmJL()
        {
            InitializeComponent();
            model.SetDb();
        }

        public FrmJL(DataRow dr)
        {
            _mRows = dr;
            InitializeComponent();
            model.SetDb();
            txtHDMC.Text = _mRows["HDMC"].ToString();
            txtHDRQ.DateTime = Convert.ToDateTime(dr["HDRQ"].ToString());
            txtHDDD.Text = dr["HDDD"].ToString();
            txtHDNR.Text = dr["HDNR"].ToString();
        }

        public FrmJL(DataRow dr,bool show)
        {
            _mRows = dr;
            InitializeComponent();
            txtHDMC.Text = _mRows["HDMC"].ToString();
            txtHDRQ.DateTime = Convert.ToDateTime(dr["HDRQ"].ToString());
            txtHDDD.Text = dr["HDDD"].ToString();
            txtHDNR.Text = dr["HDNR"].ToString();
            btnSave.Visible = show;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if (_mRows!=null)
            {
                dt = model.GetDataTable("MHJY_Tab", "MBBSM='"+_mRows["MBBSM"]+"'");
                dt.Rows[0]["HDMC"] = txtHDMC.Text;
                dt.Rows[0]["HDRQ"] = txtHDRQ.DateTime;
                dt.Rows[0]["HDDD"] = txtHDDD.Text;
                dt.Rows[0]["HDNR"] = txtHDNR.Text;
            }
            else
            {
                dt = model.GetDataTable("MHJY_Tab", "");
                if (dt == null) return;
                dt.Clear();
                DataRow dr = dt.NewRow();
                dr["MBBSM"] = Guid.NewGuid().ToString();
                dr["HDMC"] = txtHDMC.Text;
                dr["HDRQ"] = txtHDRQ.DateTime;
                dr["HDDD"] = txtHDDD.Text;
                dr["HDNR"] = txtHDNR.Text;
                dt.Rows.Add(dr);
            }
            model.UpdateDataTable("MHJY_Tab", dt);
            MessageBox.Show(@"保存完成");
            if (Rearsh == null) return;
            this.Rearsh();
            Close();
        }
    }
}