using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flixter
{
    public partial class frmFilmDetail : Form
    {
        public frmFilms mainForm;
        private Film currentFilm;
        public const String VIDEO_URL = "https://api.themoviedb.org/3/movie/{0}/videos?api_key=a07e22bc18f5cb106bfe4cc1f83ad8ed";

        public frmFilmDetail()
        {
            InitializeComponent();
        }
        //get film from main form
        public void getFilm(Film film_from_form)
        {
            currentFilm = film_from_form;
        }

        private void frmFilmDetail_Load(object sender, EventArgs e)
        {
            string html = "<html><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='600' height='300' frameborder='0' allowfullscreen></iframe>";
            html += "</body></html>";
            this.webBrowser1.DocumentText = string.Format(html, getYoutubeKey());

            //set the labels
            label1.MaximumSize = new Size(50, 0);

            lblDate.Text = currentFilm.release_date;
            lblLanguage.Text = currentFilm.original_language;
            lblTitle.Text = currentFilm.title;
            label5.Text = Convert.ToString(currentFilm.vote_count);
            label3.Text = Convert.ToString(currentFilm.vote_average);
            label8.Text = Convert.ToString(currentFilm.popularity);
            label1.Text = currentFilm.overview;
            
        }

     
  
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;// close this form
        }

        /// <summary>
        /// return film's key to watch on youtube
        /// </summary>
        /// <returns></returns>
        private String getYoutubeKey()
        {

            String reponse = "";
            String youtubeKey = "";

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    reponse = webClient.DownloadString(String.Format(VIDEO_URL, currentFilm.id));
                }

                using (JsonDocument document = JsonDocument.Parse(reponse))
                {
                    JsonElement root = document.RootElement;
                    JsonElement resultsList = root.GetProperty("results");

                    int i = 0;
                    while (true)
                    {
                        String type = resultsList[i].GetProperty("type").ToString();
                        youtubeKey = resultsList[i].GetProperty("key").ToString();
                        if (type.Equals("Clip"))
                        {
                            break;
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return youtubeKey;
        }
    }
}
