using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BussinessLibrary.CommDB.Model;

namespace RecordLove.FileterEdit
{
    public delegate void ImageRerash();
    public partial class CreateImg : DevExpress.XtraEditors.XtraForm
    {
        public event ImageRerash Rerash;
        AccessModel model=new AccessModel();
        private string _hDid = string.Empty;
        public CreateImg(string id)
        {
            InitializeComponent();
            model.SetDb();
            _hDid = id;
        }

        private void btnImgFilter_Click(object sender, EventArgs e)
        {
            var fileDilalDialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = @"请选择文件",
                Filter = @"所有文件(*)|*.jpg;*.jpeg;*.gif;*.png;*.bmp",
                InitialDirectory = Application.StartupPath
            };
            if (fileDilalDialog.ShowDialog() != DialogResult.OK) return;
            string paths = fileDilalDialog.FileNames.Aggregate("", (current, path) => current + (current == "" ? path : ";" + path));
            btnImgFilter.Text = paths;
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            var path = btnImgFilter.Text.Trim().Split(';');
            var i = (from t in path where t.Trim() != "" where File.Exists(t) where _hDid != "" select t).Count(t => model.SaveImage(t, _hDid) > 0);
            if (Rerash == null && i == 0) return;
            MessageBox.Show("保存" + i + "张");
            Rerash();
            this.Close();
        }
    }
}