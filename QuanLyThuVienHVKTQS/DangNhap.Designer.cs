
namespace QuanLyThuVienHVKTQS
{
    partial class DangNhap
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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
               this.pictureBox1 = new System.Windows.Forms.PictureBox();
               this.dangkybtn = new System.Windows.Forms.Button();
               this.dangnhapbtn = new System.Windows.Forms.Button();
               this.passwordtxt = new System.Windows.Forms.TextBox();
               this.usernametxt = new System.Windows.Forms.TextBox();
               this.label2 = new System.Windows.Forms.Label();
               this.label1 = new System.Windows.Forms.Label();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
               this.SuspendLayout();
               // 
               // pictureBox1
               // 
               this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
               this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
               this.pictureBox1.Location = new System.Drawing.Point(0, 0);
               this.pictureBox1.Name = "pictureBox1";
               this.pictureBox1.Size = new System.Drawing.Size(474, 249);
               this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
               this.pictureBox1.TabIndex = 0;
               this.pictureBox1.TabStop = false;
               this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
               // 
               // dangkybtn
               // 
               this.dangkybtn.BackColor = System.Drawing.Color.LightSalmon;
               this.dangkybtn.Location = new System.Drawing.Point(255, 166);
               this.dangkybtn.Margin = new System.Windows.Forms.Padding(4);
               this.dangkybtn.Name = "dangkybtn";
               this.dangkybtn.Size = new System.Drawing.Size(100, 28);
               this.dangkybtn.TabIndex = 12;
               this.dangkybtn.Text = "Đăng ký";
               this.dangkybtn.UseVisualStyleBackColor = false;
               this.dangkybtn.Click += new System.EventHandler(this.dangkybtn_Click);
               // 
               // dangnhapbtn
               // 
               this.dangnhapbtn.BackColor = System.Drawing.Color.LightSalmon;
               this.dangnhapbtn.Location = new System.Drawing.Point(111, 166);
               this.dangnhapbtn.Margin = new System.Windows.Forms.Padding(4);
               this.dangnhapbtn.Name = "dangnhapbtn";
               this.dangnhapbtn.Size = new System.Drawing.Size(100, 28);
               this.dangnhapbtn.TabIndex = 11;
               this.dangnhapbtn.Text = "Đăng Nhập";
               this.dangnhapbtn.UseVisualStyleBackColor = false;
               this.dangnhapbtn.Click += new System.EventHandler(this.dangnhapbtn_Click);
               // 
               // passwordtxt
               // 
               this.passwordtxt.Location = new System.Drawing.Point(195, 102);
               this.passwordtxt.Margin = new System.Windows.Forms.Padding(4);
               this.passwordtxt.Name = "passwordtxt";
               this.passwordtxt.PasswordChar = '*';
               this.passwordtxt.Size = new System.Drawing.Size(160, 22);
               this.passwordtxt.TabIndex = 10;
               // 
               // usernametxt
               // 
               this.usernametxt.Location = new System.Drawing.Point(195, 54);
               this.usernametxt.Margin = new System.Windows.Forms.Padding(4);
               this.usernametxt.Name = "usernametxt";
               this.usernametxt.Size = new System.Drawing.Size(160, 22);
               this.usernametxt.TabIndex = 9;
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.BackColor = System.Drawing.Color.LightSalmon;
               this.label2.Location = new System.Drawing.Point(109, 102);
               this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(69, 17);
               this.label2.TabIndex = 8;
               this.label2.Text = "Password";
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.BackColor = System.Drawing.Color.LightSalmon;
               this.label1.Location = new System.Drawing.Point(109, 54);
               this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(75, 17);
               this.label1.TabIndex = 7;
               this.label1.Text = "UserName";
               // 
               // DangNhap
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(474, 249);
               this.Controls.Add(this.dangkybtn);
               this.Controls.Add(this.dangnhapbtn);
               this.Controls.Add(this.passwordtxt);
               this.Controls.Add(this.usernametxt);
               this.Controls.Add(this.label2);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.pictureBox1);
               this.Name = "DangNhap";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "DangNhap";
               this.Load += new System.EventHandler(this.DangNhap_Load);
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button dangkybtn;
        private System.Windows.Forms.Button dangnhapbtn;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.TextBox usernametxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}