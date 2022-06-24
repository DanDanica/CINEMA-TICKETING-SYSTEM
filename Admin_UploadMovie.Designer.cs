namespace CinemaTicketing
{
    partial class Admin_UploadMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_UploadMovie));
            this.txtbx_MovieTitle = new System.Windows.Forms.TextBox();
            this.txtbx_MovieDirector = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstbx_MovieGenre = new System.Windows.Forms.ListBox();
            this.txtbx_MovieDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtbx_MovieID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbx_MoviePrice = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Upload = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picbx_MoviePoster = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbx_MoviePoster)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbx_MovieTitle
            // 
            this.txtbx_MovieTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(28)))));
            this.txtbx_MovieTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbx_MovieTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_MovieTitle.ForeColor = System.Drawing.Color.White;
            this.txtbx_MovieTitle.Location = new System.Drawing.Point(619, 127);
            this.txtbx_MovieTitle.Name = "txtbx_MovieTitle";
            this.txtbx_MovieTitle.Size = new System.Drawing.Size(268, 25);
            this.txtbx_MovieTitle.TabIndex = 1;
            this.txtbx_MovieTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_MovieTitle_KeyPress);
            // 
            // txtbx_MovieDirector
            // 
            this.txtbx_MovieDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(28)))));
            this.txtbx_MovieDirector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbx_MovieDirector.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_MovieDirector.ForeColor = System.Drawing.Color.White;
            this.txtbx_MovieDirector.Location = new System.Drawing.Point(619, 262);
            this.txtbx_MovieDirector.Name = "txtbx_MovieDirector";
            this.txtbx_MovieDirector.Size = new System.Drawing.Size(268, 25);
            this.txtbx_MovieDirector.TabIndex = 1;
            this.txtbx_MovieDirector.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_MovieDirector_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(366, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "UPLOAD MOVIE";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
            this.panel1.Controls.Add(this.lstbx_MovieGenre);
            this.panel1.Controls.Add(this.txtbx_MovieDescription);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txtbx_MovieID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtbx_MoviePrice);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Upload);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtbx_MovieDirector);
            this.panel1.Controls.Add(this.txtbx_MovieTitle);
            this.panel1.Controls.Add(this.picbx_MoviePoster);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 800);
            this.panel1.TabIndex = 5;
            // 
            // lstbx_MovieGenre
            // 
            this.lstbx_MovieGenre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(28)))));
            this.lstbx_MovieGenre.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbx_MovieGenre.ForeColor = System.Drawing.Color.White;
            this.lstbx_MovieGenre.FormattingEnabled = true;
            this.lstbx_MovieGenre.ItemHeight = 21;
            this.lstbx_MovieGenre.Items.AddRange(new object[] {
            "Comedy",
            "Romance",
            "Thriller",
            "Adventure",
            "Action",
            "Drama",
            "Crime",
            "Experimental",
            "Fantasy",
            "Historical",
            "Horror",
            "Sci-Fi",
            "Western",
            "Children\'s Literature",
            "Fable",
            "Dark Comedy",
            "Novella",
            "Classic Rock",
            "Rock",
            "Musical",
            "Animation",
            "Children\'s Film",
            "Jazz"});
            this.lstbx_MovieGenre.Location = new System.Drawing.Point(608, 523);
            this.lstbx_MovieGenre.Name = "lstbx_MovieGenre";
            this.lstbx_MovieGenre.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbx_MovieGenre.Size = new System.Drawing.Size(279, 109);
            this.lstbx_MovieGenre.TabIndex = 12;
            // 
            // txtbx_MovieDescription
            // 
            this.txtbx_MovieDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(28)))));
            this.txtbx_MovieDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbx_MovieDescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_MovieDescription.ForeColor = System.Drawing.Color.White;
            this.txtbx_MovieDescription.Location = new System.Drawing.Point(429, 362);
            this.txtbx_MovieDescription.Multiline = true;
            this.txtbx_MovieDescription.Name = "txtbx_MovieDescription";
            this.txtbx_MovieDescription.Size = new System.Drawing.Size(464, 124);
            this.txtbx_MovieDescription.TabIndex = 8;
            this.txtbx_MovieDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_MovieDescription_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(425, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(468, 19);
            this.label8.TabIndex = 49;
            this.label8.Text = "___________________________________________________";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(425, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 19);
            this.label7.TabIndex = 39;
            this.label7.Text = "MOVIE PRICE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(425, 533);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 19);
            this.label5.TabIndex = 34;
            this.label5.Text = "MOVIE GENRE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(425, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 19);
            this.label4.TabIndex = 36;
            this.label4.Text = "MOVIE DIRECTOR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(425, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "MOVIE TITLE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(425, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "MOVIE DESCRIPTION";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(576, 517);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 40);
            this.label13.TabIndex = 43;
            this.label13.Text = "|";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(612, 319);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 40);
            this.label12.TabIndex = 42;
            this.label12.Text = "|";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(576, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 40);
            this.label11.TabIndex = 41;
            this.label11.Text = "|";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(576, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 40);
            this.label10.TabIndex = 40;
            this.label10.Text = "|";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(576, 197);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 40);
            this.label14.TabIndex = 44;
            this.label14.Text = "|";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(419, 297);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(468, 19);
            this.label15.TabIndex = 45;
            this.label15.Text = "___________________________________________________";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(425, 233);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(468, 19);
            this.label18.TabIndex = 46;
            this.label18.Text = "___________________________________________________";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(425, 481);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(468, 19);
            this.label19.TabIndex = 47;
            this.label19.Text = "___________________________________________________";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(425, 636);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(468, 19);
            this.label20.TabIndex = 48;
            this.label20.Text = "___________________________________________________";
            // 
            // txtbx_MovieID
            // 
            this.txtbx_MovieID.Enabled = false;
            this.txtbx_MovieID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_MovieID.Location = new System.Drawing.Point(58, 148);
            this.txtbx_MovieID.Name = "txtbx_MovieID";
            this.txtbx_MovieID.Size = new System.Drawing.Size(266, 32);
            this.txtbx_MovieID.TabIndex = 10;
            this.txtbx_MovieID.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Movie ID";
            this.label6.Visible = false;
            // 
            // txtbx_MoviePrice
            // 
            this.txtbx_MoviePrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(28)))));
            this.txtbx_MoviePrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbx_MoviePrice.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_MoviePrice.ForeColor = System.Drawing.Color.White;
            this.txtbx_MoviePrice.Location = new System.Drawing.Point(619, 205);
            this.txtbx_MoviePrice.Name = "txtbx_MoviePrice";
            this.txtbx_MoviePrice.Size = new System.Drawing.Size(268, 25);
            this.txtbx_MoviePrice.TabIndex = 13;
            this.txtbx_MoviePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_MoviePrice_KeyPress);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(269, 738);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(399, 47);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "CANCEL";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Upload
            // 
            this.btn_Upload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(42)))), ((int)(((byte)(255)))));
            this.btn_Upload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Upload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Upload.FlatAppearance.BorderSize = 0;
            this.btn_Upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Upload.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Upload.ForeColor = System.Drawing.Color.White;
            this.btn_Upload.Location = new System.Drawing.Point(269, 685);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(399, 47);
            this.btn_Upload.TabIndex = 9;
            this.btn_Upload.Text = "UPLOAD FILM";
            this.btn_Upload.UseVisualStyleBackColor = false;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 70);
            this.panel2.TabIndex = 5;
            // 
            // picbx_MoviePoster
            // 
            this.picbx_MoviePoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbx_MoviePoster.Image = ((System.Drawing.Image)(resources.GetObject("picbx_MoviePoster.Image")));
            this.picbx_MoviePoster.Location = new System.Drawing.Point(77, 254);
            this.picbx_MoviePoster.Name = "picbx_MoviePoster";
            this.picbx_MoviePoster.Size = new System.Drawing.Size(212, 267);
            this.picbx_MoviePoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbx_MoviePoster.TabIndex = 0;
            this.picbx_MoviePoster.TabStop = false;
            this.picbx_MoviePoster.Click += new System.EventHandler(this.picbx_MoviePoster_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("SimSun", 220.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(208, 217);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(338, 367);
            this.label21.TabIndex = 50;
            this.label21.Text = "|";
            // 
            // Admin_UploadMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(955, 804);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin_UploadMovie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_UploadMovie";
            this.Load += new System.EventHandler(this.Admin_UploadMovie_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbx_MoviePoster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picbx_MoviePoster;
        private System.Windows.Forms.TextBox txtbx_MovieTitle;
        private System.Windows.Forms.TextBox txtbx_MovieDirector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Upload;
        private System.Windows.Forms.TextBox txtbx_MovieDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbx_MovieID;
        private System.Windows.Forms.ListBox lstbx_MovieGenre;
        private System.Windows.Forms.TextBox txtbx_MoviePrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
    }
}