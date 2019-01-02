namespace RecordLove.FileterEdit
{
    partial class CreateImg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImgFilter = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnupload = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnImgFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImgFilter
            // 
            this.btnImgFilter.Location = new System.Drawing.Point(83, 24);
            this.btnImgFilter.Name = "btnImgFilter";
            this.btnImgFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnImgFilter.Size = new System.Drawing.Size(164, 20);
            this.btnImgFilter.TabIndex = 0;
            this.btnImgFilter.Click += new System.EventHandler(this.btnImgFilter_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "图片位置:";
            // 
            // btnupload
            // 
            this.btnupload.Location = new System.Drawing.Point(83, 72);
            this.btnupload.Name = "btnupload";
            this.btnupload.Size = new System.Drawing.Size(75, 23);
            this.btnupload.TabIndex = 2;
            this.btnupload.Text = "上传";
            this.btnupload.Click += new System.EventHandler(this.btnupload_Click);
            // 
            // CreateImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 124);
            this.Controls.Add(this.btnupload);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnImgFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CreateImg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.btnImgFilter.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit btnImgFilter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnupload;
    }
}