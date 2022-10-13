using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flixter
{
    public partial class frmFilms : Form
    {
        int index = 0;
        public static List<Film> listFilm;
        public Film currentFilm;
        public frmFilms()
        {
         
            InitializeComponent();
            changeColor();
        }

    

        private void frmFilms_Load(object sender, EventArgs e)
        {
            afficher(index);
            changeColor();

        }

        /// <summary>
        /// change the color of the panel to indicate wether there's connection or not
        /// </summary>
        public void changeColor()
        {
            if (Utilities.IsConnectedToInternet())
                panelConnection.BackColor = Color.Blue;
            else
                panelConnection.BackColor = Color.Red;

        }


        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel_title_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            changeColor();

        }

       

        private void btn_precedent_Click(object sender, EventArgs e)
        {
            index -= 1;
            afficher(index);
            changeColor();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            index += 1;
            afficher(index);
            changeColor();

        }
        /// <summary>
        /// display film from website or database
        /// </summary>
        /// <param name="index"></param>
        public void afficher(int index)
        {
          

            if (Utilities.IsConnectedToInternet())
            {// films from api
                listFilm = Utilities.getMovieDbList();
                Film film = listFilm.ElementAt(index);
                currentFilm = film;
                Console.WriteLine(currentFilm.video.ToString());
                SqliteDataAccess.SaveFilm(film);

                lbl_title.Text = film.title;
                label1.Text = film.overview;
                label1.MaximumSize = new Size(50, 0);
                pictureBox1.LoadAsync("https://image.tmdb.org/t/p/w342" + film.backdrop_path);
            }
            else
            {// films from database
                listFilm = SqliteDataAccess.LoadFilms();
                Film film = listFilm.ElementAt(index);
                currentFilm = film;
                lbl_title.Text = film.title;
                label1.Text = film.overview;
                label1.MaximumSize = new Size(50, 0);
                pictureBox1.Image = film.image;
            }

            if (index > 0)
                btn_precedent.Enabled = true;
            else
                btn_precedent.Enabled = false;


            if (index == listFilm.Count - 1)
                btn_suivant.Enabled = false;
            else
                btn_suivant.Enabled = true;

        }

        private void ClosedFomr(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//close application
        }
        /// <summary>
        /// send user to detail page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_detail_Click(object sender, EventArgs e)
        {
            frmFilmDetail detail = new frmFilmDetail();
            detail.mainForm = this;
            this.Hide();
            detail.ShowDialog();
            this.Show();

            
        }
    }
  
}
