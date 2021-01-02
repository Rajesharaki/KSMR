namespace VoiceAssistance
{
    partial class VoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceForm));
            this.ChangeGender = new System.Windows.Forms.ComboBox();
            this.btnimg = new System.Windows.Forms.Button();
            this.btnWel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CName = new System.Windows.Forms.Label();
            this.lnktext = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeGender
            // 
            this.ChangeGender.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ChangeGender.Font = new System.Drawing.Font("Playball", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeGender.ForeColor = System.Drawing.Color.White;
            this.ChangeGender.FormattingEnabled = true;
            this.ChangeGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.ChangeGender.Location = new System.Drawing.Point(924, 142);
            this.ChangeGender.Name = "ChangeGender";
            this.ChangeGender.Size = new System.Drawing.Size(121, 33);
            this.ChangeGender.TabIndex = 4;
            this.ChangeGender.Text = "Male";
            // 
            // btnimg
            // 
            this.btnimg.BackgroundImage = global::VoiceAssistance.Properties.Resources.IconMic2;
            this.btnimg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnimg.ForeColor = System.Drawing.Color.Black;
            this.btnimg.Location = new System.Drawing.Point(924, -20);
            this.btnimg.Margin = new System.Windows.Forms.Padding(0);
            this.btnimg.Name = "btnimg";
            this.btnimg.Size = new System.Drawing.Size(123, 153);
            this.btnimg.TabIndex = 3;
            this.btnimg.UseVisualStyleBackColor = true;
            // 
            // btnWel
            // 
            this.btnWel.BackgroundImage = global::VoiceAssistance.Properties.Resources.james_donovan_kFHz9Xh3PPU_unsplash;
            this.btnWel.Font = new System.Drawing.Font("Playball", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWel.ForeColor = System.Drawing.Color.Yellow;
            this.btnWel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnWel.Location = new System.Drawing.Point(260, 53);
            this.btnWel.Name = "btnWel";
            this.btnWel.Size = new System.Drawing.Size(661, 51);
            this.btnWel.TabIndex = 2;
            this.btnWel.Text = ".............................................";
            this.btnWel.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::VoiceAssistance.Properties.Resources.IMG_20201220_092117_2_;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // CName
            // 
            this.CName.AutoSize = true;
            this.CName.BackColor = System.Drawing.Color.Aqua;
            this.CName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CName.Font = new System.Drawing.Font("Orbitron", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.CName.Image = global::VoiceAssistance.Properties.Resources.BlackWallpepar1;
            this.CName.Location = new System.Drawing.Point(487, 142);
            this.CName.Margin = new System.Windows.Forms.Padding(60);
            this.CName.Name = "CName";
            this.CName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CName.Size = new System.Drawing.Size(225, 35);
            this.CName.TabIndex = 0;
            this.CName.Text = "....K....S....M...R....";
            this.CName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lnktext
            // 
            this.lnktext.BackColor = System.Drawing.Color.Black;
            this.lnktext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lnktext.Font = new System.Drawing.Font("Playball", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnktext.ForeColor = System.Drawing.Color.Yellow;
            this.lnktext.Location = new System.Drawing.Point(219, -1);
            this.lnktext.Name = "lnktext";
            this.lnktext.Size = new System.Drawing.Size(702, 19);
            this.lnktext.TabIndex = 5;
            this.lnktext.Text = ".......Paste Link Here.......";
            this.lnktext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VoiceForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1064, 174);
            this.Controls.Add(this.lnktext);
            this.Controls.Add(this.ChangeGender);
            this.Controls.Add(this.btnimg);
            this.Controls.Add(this.btnWel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CName);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VoiceForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "...K...S...M...R....";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VoiceForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VoiceForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VoiceForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnWel;
        private System.Windows.Forms.Button btnimg;
        private System.Windows.Forms.ComboBox ChangeGender;
        private System.Windows.Forms.TextBox lnktext;
    }
}