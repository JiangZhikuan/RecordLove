namespace RecordLove.FileterEdit
{
    partial class FrmJL
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
            this.txtHDMC = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtHDDD = new DevExpress.XtraEditors.TextEdit();
            this.txtHDRQ = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtHDNR = new DevExpress.XtraEditors.MemoEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDMC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDDD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDRQ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDRQ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDNR.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHDMC
            // 
            this.txtHDMC.Location = new System.Drawing.Point(83, 18);
            this.txtHDMC.Name = "txtHDMC";
            this.txtHDMC.Size = new System.Drawing.Size(351, 20);
            this.txtHDMC.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "活动名称:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "活动日期:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(225, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "活动地点:";
            // 
            // txtHDDD
            // 
            this.txtHDDD.Location = new System.Drawing.Point(292, 56);
            this.txtHDDD.Name = "txtHDDD";
            this.txtHDDD.Size = new System.Drawing.Size(142, 20);
            this.txtHDDD.TabIndex = 5;
            // 
            // txtHDRQ
            // 
            this.txtHDRQ.EditValue = null;
            this.txtHDRQ.Location = new System.Drawing.Point(83, 56);
            this.txtHDRQ.Name = "txtHDRQ";
            this.txtHDRQ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHDRQ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHDRQ.Size = new System.Drawing.Size(120, 20);
            this.txtHDRQ.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 89);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "活动内容：";
            // 
            // txtHDNR
            // 
            this.txtHDNR.Location = new System.Drawing.Point(83, 87);
            this.txtHDNR.Name = "txtHDNR";
            this.txtHDNR.Size = new System.Drawing.Size(351, 119);
            this.txtHDNR.TabIndex = 8;
            this.txtHDNR.UseOptimizedRendering = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(359, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmJL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 257);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHDNR);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtHDRQ);
            this.Controls.Add(this.txtHDDD);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtHDMC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmJL";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.txtHDMC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDDD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDRQ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDRQ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDNR.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtHDMC;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtHDDD;
        private DevExpress.XtraEditors.DateEdit txtHDRQ;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MemoEdit txtHDNR;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}