namespace CinemaTicketing
{
    partial class User_BookingOfTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_BookingOfTicket));
            this.lbl_MovieDirector = new System.Windows.Forms.Label();
            this.lbl_MovieGenre = new System.Windows.Forms.Label();
            this.lbl_MovieTitle = new System.Windows.Forms.Label();
            this.lbl_MovieDescription = new System.Windows.Forms.Label();
            this.pnl_Description = new System.Windows.Forms.Panel();
            this.btn_Book = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shadow1 = new System.Windows.Forms.Panel();
            this.pbx_moviepic = new System.Windows.Forms.PictureBox();
            this.pnl_Description.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_moviepic)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_MovieDirector
            // 
            this.lbl_MovieDirector.AutoSize = true;
            this.lbl_MovieDirector.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MovieDirector.ForeColor = System.Drawing.Color.White;
            this.lbl_MovieDirector.Location = new System.Drawing.Point(359, 466);
            this.lbl_MovieDirector.Name = "lbl_MovieDirector";
            this.lbl_MovieDirector.Size = new System.Drawing.Size(86, 23);
            this.lbl_MovieDirector.TabIndex = 6;
            this.lbl_MovieDirector.Text = "Director";
            this.lbl_MovieDirector.Visible = false;
            // 
            // lbl_MovieGenre
            // 
            this.lbl_MovieGenre.AutoSize = true;
            this.lbl_MovieGenre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MovieGenre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(187)))), ((int)(((byte)(14)))));
            this.lbl_MovieGenre.Location = new System.Drawing.Point(37, 23);
            this.lbl_MovieGenre.Name = "lbl_MovieGenre";
            this.lbl_MovieGenre.Size = new System.Drawing.Size(71, 23);
            this.lbl_MovieGenre.TabIndex = 4;
            this.lbl_MovieGenre.Text = "Genre";
            // 
            // lbl_MovieTitle
            // 
            this.lbl_MovieTitle.AutoSize = true;
            this.lbl_MovieTitle.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MovieTitle.ForeColor = System.Drawing.Color.White;
            this.lbl_MovieTitle.Location = new System.Drawing.Point(51, 459);
            this.lbl_MovieTitle.Name = "lbl_MovieTitle";
            this.lbl_MovieTitle.Size = new System.Drawing.Size(95, 47);
            this.lbl_MovieTitle.TabIndex = 5;
            this.lbl_MovieTitle.Text = "Title";
            this.lbl_MovieTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_MovieDescription
            // 
            this.lbl_MovieDescription.AutoSize = true;
            this.lbl_MovieDescription.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MovieDescription.ForeColor = System.Drawing.Color.White;
            this.lbl_MovieDescription.Location = new System.Drawing.Point(37, 58);
            this.lbl_MovieDescription.Name = "lbl_MovieDescription";
            this.lbl_MovieDescription.Size = new System.Drawing.Size(103, 21);
            this.lbl_MovieDescription.TabIndex = 4;
            this.lbl_MovieDescription.Text = "Description";
            // 
            // pnl_Description
            // 
            this.pnl_Description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
            this.pnl_Description.Controls.Add(this.btn_Book);
            this.pnl_Description.Controls.Add(this.lbl_MovieDescription);
            this.pnl_Description.Controls.Add(this.lbl_MovieGenre);
            this.pnl_Description.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Description.Location = new System.Drawing.Point(0, 524);
            this.pnl_Description.Name = "pnl_Description";
            this.pnl_Description.Size = new System.Drawing.Size(650, 286);
            this.pnl_Description.TabIndex = 13;
            // 
            // btn_Book
            // 
            this.btn_Book.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(42)))), ((int)(((byte)(255)))));
            this.btn_Book.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Book.BackgroundImage")));
            this.btn_Book.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Book.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Book.FlatAppearance.BorderSize = 0;
            this.btn_Book.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Book.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Book.Location = new System.Drawing.Point(59, 187);
            this.btn_Book.Name = "btn_Book";
            this.btn_Book.Size = new System.Drawing.Size(549, 77);
            this.btn_Book.TabIndex = 12;
            this.btn_Book.UseVisualStyleBackColor = false;
            this.btn_Book.Click += new System.EventHandler(this.btn_Book_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.btn_Back);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(650, 66);
            this.panel3.TabIndex = 18;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(117, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(227, 37);
            this.label21.TabIndex = 91;
            this.label21.Text = "Movie Preview";
            // 
            // btn_Back
            // 
            this.btn_Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Back.BackgroundImage")));
            this.btn_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Back.FlatAppearance.BorderSize = 0;
            this.btn_Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Back.Location = new System.Drawing.Point(21, 3);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(60, 60);
            this.btn_Back.TabIndex = 92;
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(226, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Directed by:";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 267);
            this.panel1.TabIndex = 19;
            // 
            // shadow1
            // 
            this.shadow1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.shadow1.Location = new System.Drawing.Point(207, 114);
            this.shadow1.Name = "shadow1";
            this.shadow1.Size = new System.Drawing.Size(238, 303);
            this.shadow1.TabIndex = 20;
            // 
            // pbx_moviepic
            // 
            this.pbx_moviepic.BackColor = System.Drawing.Color.Transparent;
            this.pbx_moviepic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbx_moviepic.Image = ((System.Drawing.Image)(resources.GetObject("pbx_moviepic.Image")));
            this.pbx_moviepic.Location = new System.Drawing.Point(206, 107);
            this.pbx_moviepic.Name = "pbx_moviepic";
            this.pbx_moviepic.Size = new System.Drawing.Size(239, 306);
            this.pbx_moviepic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_moviepic.TabIndex = 1;
            this.pbx_moviepic.TabStop = false;
            // 
            // User_BookingOfTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(650, 810);
            this.Controls.Add(this.pbx_moviepic);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnl_Description);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shadow1);
            this.Controls.Add(this.lbl_MovieDirector);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_MovieTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "User_BookingOfTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User_BookingOfTicket";
            this.Load += new System.EventHandler(this.User_BookingOfTicket_Load);
            this.pnl_Description.ResumeLayout(false);
            this.pnl_Description.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_moviepic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_moviepic;
        private System.Windows.Forms.Label lbl_MovieDirector;
        private System.Windows.Forms.Label lbl_MovieGenre;
        private System.Windows.Forms.Label lbl_MovieTitle;
        private System.Windows.Forms.Label lbl_MovieDescription;
        private System.Windows.Forms.Button btn_Book;
        private System.Windows.Forms.Panel pnl_Description;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Panel shadow1;
        private System.Windows.Forms.Label label21;
    }
}