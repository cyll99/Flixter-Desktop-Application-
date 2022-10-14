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
/// <summary>
/// Nom : LAROSE
/// Prenom : Christ-Yan Love
/// Date : 13/10/2022
/// </summary>
namespace Flixter
{
    public partial class frmFilms : Form
    {
        int index = 0;
        public static List<Film> listFilm;
        public Film currentFilm;
        public delegate void delPassFilm(Film film);
        Graphics formGraphics;
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
            Graphics formGraphics = this.CreateGraphics();
            SolidBrush RedBrush = new SolidBrush(Color.Red);
            SolidBrush BlueBrush = new SolidBrush(Color.Blue);

            int x = 859, y = 12, cellSize = 20;

            if (Utilities.IsConnectedToInternet())
            {
                
                formGraphics.FillEllipse(BlueBrush, new Rectangle(x, y, cellSize, cellSize));
            }

            else
            {
                formGraphics.FillEllipse(RedBrush, new Rectangle(x, y, cellSize, cellSize));

            }

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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmFilmDetail detail = new frmFilmDetail(); 
            delPassFilm del = new delPassFilm(detail.getFilm);
            del(this.currentFilm);
            this.Hide();
            detail.ShowDialog();
            this.Show();
        }

        private void frmFilms_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush RedBrush = new SolidBrush(Color.Red);
            SolidBrush BlueBrush = new SolidBrush(Color.Blue);

            int x = 859, y = 12, cellSize = 20;
            formGraphics = e.Graphics;
            if (Utilities.IsConnectedToInternet())
            {

                //panelConnection.BackColor = Color.Blue;
                formGraphics.FillEllipse(BlueBrush, new Rectangle(x, y, cellSize, cellSize));
            }

            else
            {
                formGraphics.FillEllipse(RedBrush, new Rectangle(x, y, cellSize, cellSize));
                //panelConnection.BackColor = Color.Red;

            }


        }
    }
  
}
