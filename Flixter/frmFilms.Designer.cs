
namespace Flixter
{
    partial class frmFilms
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_precedent = new System.Windows.Forms.Button();
            this.btn_suivant = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(542, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(314, 193);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(23, 114);
            this.lbl_title.MinimumSize = new System.Drawing.Size(400, 30);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(400, 30);
            this.lbl_title.TabIndex = 2;
            this.lbl_title.Text = "label1";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 174);
            this.label1.MinimumSize = new System.Drawing.Size(400, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 250);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // btn_precedent
            // 
            this.btn_precedent.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_precedent.Enabled = false;
            this.btn_precedent.Location = new System.Drawing.Point(542, 343);
            this.btn_precedent.Name = "btn_precedent";
            this.btn_precedent.Size = new System.Drawing.Size(75, 23);
            this.btn_precedent.TabIndex = 4;
            this.btn_precedent.Text = "Precedent";
            this.btn_precedent.UseVisualStyleBackColor = false;
            this.btn_precedent.Click += new System.EventHandler(this.btn_precedent_Click);
            // 
            // btn_suivant
            // 
            this.btn_suivant.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_suivant.Location = new System.Drawing.Point(781, 343);
            this.btn_suivant.Name = "btn_suivant";
            this.btn_suivant.Size = new System.Drawing.Size(75, 23);
            this.btn_suivant.TabIndex = 5;
            this.btn_suivant.Text = "Suivant";
            this.btn_suivant.UseVisualStyleBackColor = false;
            this.btn_suivant.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmFilms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(900, 461);
            this.Controls.Add(this.btn_suivant);
            this.Controls.Add(this.btn_precedent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmFilms";
            this.Text = "Flixter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClosedFomr);
            this.Load += new System.EventHandler(this.frmFilms_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_title_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_precedent;
        private System.Windows.Forms.Button btn_suivant;
    }
}