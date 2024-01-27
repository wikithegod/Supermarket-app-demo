namespace Supermarket_app
{
    partial class CameraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraForm));
            this.cboDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.kryptonButton7 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDevice
            // 
            this.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDevice.FormattingEnabled = true;
            this.cboDevice.Location = new System.Drawing.Point(180, 33);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(121, 21);
            this.cboDevice.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Select Camera";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(12, 77);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(410, 306);
            this.pictureBox.TabIndex = 14;
            this.pictureBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(467, 161);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(152, 24);
            this.lblCode.TabIndex = 15;
            this.lblCode.Text = "NO QR CODE?";
            this.lblCode.Click += new System.EventHandler(this.lblCode_Click);
            // 
            // kryptonButton7
            // 
            this.kryptonButton7.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.FormClose;
            this.kryptonButton7.Location = new System.Drawing.Point(635, -2);
            this.kryptonButton7.Name = "kryptonButton7";
            this.kryptonButton7.Size = new System.Drawing.Size(37, 26);
            this.kryptonButton7.TabIndex = 30;
            this.kryptonButton7.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton7.Values.Image")));
            this.kryptonButton7.Values.Text = "";
            this.kryptonButton7.Click += new System.EventHandler(this.kryptonButton7_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(499, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "Click me";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(663, 410);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kryptonButton7);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CameraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CameraForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraForm_FormClosing);
            this.Load += new System.EventHandler(this.CameraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCode;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton7;
        private System.Windows.Forms.Label label2;
    }
}