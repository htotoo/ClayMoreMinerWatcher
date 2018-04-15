namespace Claymore_watcher
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtSumm = new System.Windows.Forms.TextBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnClearErr = new System.Windows.Forms.Button();
            this.tbUpdateIntervall = new System.Windows.Forms.TrackBar();
            this.lblUpdateInterval = new System.Windows.Forms.Label();
            this.cmApiVisual1 = new Claymore_watcher.CmApiVisual();
            ((System.ComponentModel.ISupportInitialize)(this.tbUpdateIntervall)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSumm
            // 
            this.txtSumm.Location = new System.Drawing.Point(321, 39);
            this.txtSumm.Multiline = true;
            this.txtSumm.Name = "txtSumm";
            this.txtSumm.Size = new System.Drawing.Size(659, 159);
            this.txtSumm.TabIndex = 3;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(321, 12);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(84, 17);
            this.chkAuto.TabIndex = 5;
            this.chkAuto.Text = "Auto update";
            this.chkAuto.UseVisualStyleBackColor = true;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_TickAsync);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(303, 160);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 175);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(93, 175);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClearErr
            // 
            this.btnClearErr.Location = new System.Drawing.Point(174, 175);
            this.btnClearErr.Name = "btnClearErr";
            this.btnClearErr.Size = new System.Drawing.Size(75, 23);
            this.btnClearErr.TabIndex = 10;
            this.btnClearErr.Text = "Ack errors";
            this.btnClearErr.UseVisualStyleBackColor = true;
            this.btnClearErr.Click += new System.EventHandler(this.btnClearErr_Click);
            // 
            // tbUpdateIntervall
            // 
            this.tbUpdateIntervall.Location = new System.Drawing.Point(411, 8);
            this.tbUpdateIntervall.Maximum = 30;
            this.tbUpdateIntervall.Minimum = 1;
            this.tbUpdateIntervall.Name = "tbUpdateIntervall";
            this.tbUpdateIntervall.Size = new System.Drawing.Size(256, 45);
            this.tbUpdateIntervall.TabIndex = 11;
            this.tbUpdateIntervall.Value = 1;
            this.tbUpdateIntervall.ValueChanged += new System.EventHandler(this.tbUpdateIntervall_ValueChanged);
            // 
            // lblUpdateInterval
            // 
            this.lblUpdateInterval.AutoSize = true;
            this.lblUpdateInterval.Location = new System.Drawing.Point(673, 13);
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            this.lblUpdateInterval.Size = new System.Drawing.Size(80, 13);
            this.lblUpdateInterval.TabIndex = 12;
            this.lblUpdateInterval.Text = "1 sec /  update";
            // 
            // cmApiVisual1
            // 
            this.cmApiVisual1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmApiVisual1.Location = new System.Drawing.Point(12, 204);
            this.cmApiVisual1.MinimumSize = new System.Drawing.Size(659, 471);
            this.cmApiVisual1.Name = "cmApiVisual1";
            this.cmApiVisual1.Size = new System.Drawing.Size(964, 493);
            this.cmApiVisual1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 704);
            this.Controls.Add(this.lblUpdateInterval);
            this.Controls.Add(this.btnClearErr);
            this.Controls.Add(this.cmApiVisual1);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.txtSumm);
            this.Controls.Add(this.tbUpdateIntervall);
            this.Name = "Form1";
            this.Text = "Claymore Miner Watcher";
            ((System.ComponentModel.ISupportInitialize)(this.tbUpdateIntervall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSumm;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private CmApiVisual cmApiVisual1;
        private System.Windows.Forms.Button btnClearErr;
        private System.Windows.Forms.TrackBar tbUpdateIntervall;
        private System.Windows.Forms.Label lblUpdateInterval;
    }
}

