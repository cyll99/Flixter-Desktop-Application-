﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flixter
{
	public partial class SplashScreen : Form
	{
		frmFilms form = new frmFilms();
		public SplashScreen()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
			progressBar1.Increment(1);
			if (progressBar1.Value == 100)
            {
				timer1.Stop();
				
				form.Show();
				this.Hide();
			}
				
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
