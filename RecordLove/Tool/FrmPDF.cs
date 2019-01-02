using System;
using System.IO;
using System.Windows.Forms;
using Aspose.Words;
using BussinessLibrary;

namespace RecordLove.Tool
{
    public partial class FrmPDF : DevExpress.XtraEditors.XtraForm
    {
        public FrmPDF()
        {
            InitializeComponent();
        }

        private void btnFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openfile.Filter = @"Word文档|*.doc;*.docx;*.dot";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                btnFilePath.Text = openfile.FileName;
            }
        }

        private void btnChagePDF_Click(object sender, EventArgs e)
        {
            if (btnFilePath.Text == "") return;
            if (!File.Exists(btnFilePath.Text)) return;
            string path = btnFilePath.Text.Split('.')[0] + ".pdf";
            try
            {
                var doc = new Aspose.Words.Document(btnFilePath.Text);
                doc.Save(path, SaveFormat.Pdf);
                MessageBox.Show(@"转换完成!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"转换失败!" + ex.Message);
                throw;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(buttonEdit1.Text.Trim()=="")return;
            if(!File.Exists(buttonEdit1.Text))return;
            string path = buttonEdit1.Text.Split('.')[0] + ".doc";
            Wrod w=new Wrod();
            MessageBox.Show(w.SaveWrod(buttonEdit1.Text, path));
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openfile.Filter = @"PDF文档|*.pdf";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = openfile.FileName;
            }
        }
    }
}