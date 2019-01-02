using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLibrary.CommDB;
using BussinessLibrary.CommDB.Model;
using BussinessLibrary.Node;
using DevExpress.Utils;
using DevExpress.XtraTreeList;
using RecordLove.FileterEdit;
using RecordLove.SJSZ;
using RecordLove.Tool;
using ICSharpCode.SharpZipLib.Zip;

namespace RecordLove
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        readonly AccessModel _model=new AccessModel();
        readonly DBXML _xml=new DBXML();
        public MainForm()
        {
            InitializeComponent();
            if (_xml.XmlReader().Trim() != ""&&File.Exists(_xml.XmlReader()))
                _model.SetDb();
            else
            {
                var sjk=new FrmSJKSeting();
                sjk.ShowDialog();
                _model.SetDb();
            }
            LoadTree();
        }

        #region  文件
        //创建活动
        private void btnCreat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var jl = new FrmJL();
            jl.Rearsh += new TrreeRearsh(LoadTree);
            jl.ShowDialog();
        }
        //刷新
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadTree();
        }
        //目录显示
        private void btnRQML_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dockPanel4.Show();
        }
        //相片显示
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // panelContainer1.Show();
        }

        #endregion


        #region 工具
        //Wrod转PDF工具
        private void btnChagePDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var pdf = new FrmPDF();
            pdf.ShowDialog();
        }

        #endregion

        #region  系统设置
        //数据库设置
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmSjk = new FrmSJKSeting();
            frmSjk.ShowDialog();
        }

        #endregion
       
        //显示活动树
        private void LoadTree()
        {
            var dt = _model.GetDataTable("MHJY_Tab", "");
            if (dt == null || dt.Rows.Count <= 0) return;
            treeView1.Nodes.Clear();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var list = new TreeNode {Text = dt.Rows[i]["HDMC"].ToString(), Tag = dt.Rows[i]};
                var dtImg = _model.GetDataTable("MHJY_Image", "BSM='" + dt.Rows[i]["MBBSM"] + "'");
                for (var j = 0; j < dtImg.Rows.Count; j++)
                {
                    var treeList = new TreeNode();
                    treeList.Text = dtImg.Rows[j]["ImgName"].ToString();
                    var img = new ImgNode
                    {
                        ImgId = dtImg.Rows[j]["MBBSM"].ToString(),
                        HdId =dtImg.Rows[j]["BSM"].ToString()
                    };
                    treeList.Tag = img;
                    list.Nodes.Add(treeList);
                }
                treeView1.Nodes.Add(list);
            }
        }

        /// 显示图片
        private void LoadImage(string bsm)
        {
            double con = 1.00;
            DataTable dt = _model.GetDataTable("MHJY_Image", "MBBSM='" + bsm + "'");
            if (dt == null || dt.Rows.Count <= 0) return;
            byte[] buffer = dt.Rows[0]["Image"] as byte[];
            if (buffer == null) return;
            Stream ms = new MemoryStream(buffer);
            Bitmap bmtemp = new Bitmap(ms);
            con = (double)800 / (double)bmtemp.Width > (double)600 / (double)bmtemp.Height ? (double)600 / (double)bmtemp.Height : (double)800 / (double)bmtemp.Width;
            Image img = new Bitmap(bmtemp, (int)(con * bmtemp.Width), (int)(con * bmtemp.Height));
            pictureEdit2.Image = img;
        }

        //点击加载相片
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Level != 1) return;
            var img = treeView1.SelectedNode.Tag as ImgNode;
            if(img==null)return;
            LoadImage(img.ImgId);
        }

#region 目录树右击事件
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)return;
            if(treeView1.SelectedNode.Level == 0)
            {
                treeView1.ContextMenuStrip = MenuStripHD;
            }
            if (treeView1.SelectedNode.Level == 1)
            {
                treeView1.ContextMenuStrip = MenuStripImg;
            }
        }
        
        #region 活动右键
        private void 创建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var jl = new FrmJL();
            jl.Rearsh+=new TrreeRearsh(LoadTree);
            jl.ShowDialog();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = treeView1.SelectedNode.Tag as DataRow;
            if (dr == null) return;
            var jl = new FrmJL(dr);
            jl.Rearsh += new TrreeRearsh(LoadTree);
            jl.ShowDialog();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = treeView1.SelectedNode.Tag as DataRow;
            if (rows == null) return;
            const MessageBoxButtons mess = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show(@"确认删除当权活动么?", @"提示", mess);
            if(dr!=DialogResult.OK)return;
            if (
                _model.ExecuteSql("DELETE FROM MHJY_Tab WHERE MBBSM='" + rows["MBBSM"] +
                                  "'") <= 0) return;
            _model.ExecuteSql("DELETE FROM MHJY_Image WHERE BSM='" + rows["MBBSM"] + "'");
            LoadTree();
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = treeView1.SelectedNode.Tag as DataRow;
            if (dr == null) return;
            var jl = new FrmJL(dr,false);
            jl.ShowDialog();
        }

        private void 上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = treeView1.SelectedNode.Tag as DataRow;
            if (dr == null) return;
            var img = new CreateImg( dr["MBBSM"].ToString());
            img.Rerash += new ImageRerash(LoadTree);
            img.ShowDialog();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var size = 0;
            try
            {
                var dr = treeView1.SelectedNode.Tag as DataRow;
                if (dr == null) return;
                var dialog = new FolderBrowserDialog {Description = "请选择文件夹"};
                if (dialog.ShowDialog() != DialogResult.OK) return;
                var foldpath = dialog.SelectedPath;
                var path = Application.StartupPath + "\\ImageTemp";
                if (!File.Exists(path + "\\" + dr["HDMC"]))
                {
                    var dir = new DirectoryInfo(path);
                    dir.CreateSubdirectory(dr["HDMC"].ToString());
                }
                var dtImg = _model.GetDataTable("MHJY_Image", "BSM='" + dr["MBBSM"] + "'");
                if (dtImg == null)return;
                for (var i = 0; i < dtImg.Rows.Count; i++)
                {
                    var fileBytes = (Byte[]) dtImg.Rows[i]["Image"];
                    var bw =
                        new BinaryWriter(
                            File.Open(
                                path + "\\" + dr["HDMC"] + "\\" + dtImg.Rows[i]["ImgName"] + "." +
                                dtImg.Rows[i]["ImageType"], FileMode.OpenOrCreate));
                    if (fileBytes != null)
                    {
                        size++;
                        bw.Write(fileBytes);
                    }
                    bw.Close();
                }
                if (File.Exists(path + "\\" + dr["HDMC"])) return;
                (new FastZip()).CreateZip(foldpath + "\\" + dr["HDMC"] + ".zip", path + "\\" + dr["HDMC"], true, "");
                MessageBox.Show("导出完成"+size+"张");
                var fdir = new DirectoryInfo(path);
                var fileinfo = fdir.GetFileSystemInfos(); //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo) //判断是否文件夹
                    {
                        var subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true); //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName); //删除指定文件
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 相片右击操作
        private void 上传ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null) return;
            var imgNode = treeView1.SelectedNode.Tag as ImgNode;
            if (imgNode == null) return;
            var img = new CreateImg(imgNode.HdId);
            img.Rerash += new ImageRerash(LoadTree);
            img.ShowDialog();
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null) return;
            var imgNode = treeView1.SelectedNode.Tag as ImgNode; 
            if(imgNode==null)return;
            if (_model.ExecuteSql("DELETE FROM MHJY_Image WHERE MBBSM='" + imgNode.ImgId + "'") <= 0) return;
            LoadTree();
        }
        #endregion


#endregion



    }
}
