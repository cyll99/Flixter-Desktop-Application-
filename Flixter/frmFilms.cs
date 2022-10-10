using System;
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
    public partial class frmFilms : Form
    {
        int index = 0;
        public static List<Film> listFilm = Utilities.getMovieDbList();
        public frmFilms()
        {
            InitializeComponent();
        }

        private void frmFilms_Load(object sender, EventArgs e)
        {
            afficher(index);
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel_title_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_precedent_Click(object sender, EventArgs e)
        {
            index -= 1;
            afficher(index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index += 1;
            afficher(index);
        }

        public void afficher(int index)
        {
            if (index < 0 || index == listFilm.Count)
            {
                MessageBox.Show("Out of range", "Flixter");
                return;
            }
            Film film = listFilm.ElementAt(index);
            lbl_title.Text = film.title;
            label1.Text = film.overview;
            label1.MaximumSize = new Size(50, 0);
            pictureBox1.LoadAsync("https://image.tmdb.org/t/p/w342" + film.backdrop_path);
        }
    }
  
}
