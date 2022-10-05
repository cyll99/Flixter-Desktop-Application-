
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
            this.panel_title = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_title
            // 
            this.panel_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(900, 45);
            this.panel_title.TabIndex = 0;
            // 
            // frmFilms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panel_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFilms";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.frmFilms_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_title_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_title;
    }
}