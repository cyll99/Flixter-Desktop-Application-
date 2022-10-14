using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Flixter
{
    class SqliteDataAccess
    {

        public static void CreateIfNotExists()
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=./films.db;Version=3"))
            {

                var query = "CREATE TABLE IF NOT EXISTS offline ( id INTEGER, title CHAR(50), image BLOB, release_date TEXT, original_language TEXT,  vote_count TEXT, vote_average TEXT, popularity TEXT, overview	TEXT)";

                cnn.Execute(query, new DynamicParameters());
            }
        }
        public static List<Film> LoadFilms()
        {
            List<Film> films = new List<Film>();
            using (SQLiteConnection cnn = new SQLiteConnection("Data Source=./films.db;Version=3"))
            {
                var query = "select * from offline";
                cnn.Open();

                SQLiteCommand sQLiteCommand = new SQLiteCommand(query, cnn);
                SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                if (sQLiteDataReader.HasRows)
                {
                    
                    while (sQLiteDataReader.Read())
                    {
                        Film film = new Film();
                        film.title = (string)sQLiteDataReader["title"];
                        film.release_date = (string)sQLiteDataReader["release_date"];
                        film.original_language = (string)sQLiteDataReader["original_language"];
                        film.vote_count = Convert.ToInt32(sQLiteDataReader["vote_count"]);
                        film.overview = (string)sQLiteDataReader["overview"];
                        byte[] image_byte = (byte[])sQLiteDataReader["image"];

                        Image newImage = byteArrayToImage(image_byte);

                        film.image = newImage;
                        films.Add(film);
                    }
                }

                return films;
            }

        }
        
        public static void SaveFilm(Film film)
        {
            using (SQLiteConnection cnn = new SQLiteConnection("Data Source=./films.db;Version=3"))
            {
                cnn.Open();

              
                var backdrop = "https://image.tmdb.org/t/p/w342" + film.backdrop_path;
           
                byte[] pic = ImageToByte(backdrop, System.Drawing.Imaging.ImageFormat.Jpeg);
                string sql = @"
                        insert into offline (title, overview, image, release_date, vote_count,id,original_language)
                        Select @title , @overview, @pic, @release_date,@vote_count, @id, @original_language
                        Where not exists (
                            select * 
                            from offline 
                            where 
                                id = @id
                            and overview = @overview
                            and image = @pic
                            and release_date = @release_date
                            and original_language = @original_language
                            and title = @title
                            and vote_count = @vote_count
)
                        ";
                using ( var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@title", film.title);
                    cmd.Parameters.AddWithValue("@overview", film.overview);
                    cmd.Parameters.AddWithValue("@pic", pic);
                    cmd.Parameters.AddWithValue("@release_date", film.release_date);
                    cmd.Parameters.AddWithValue("@vote_count", film.vote_count);
                    cmd.Parameters.AddWithValue("@id", film.id);
                    cmd.Parameters.AddWithValue("@original_language", film.original_language);
                    cmd.ExecuteNonQuery();
         
                }


            }
        }



        public static byte[] ImageToByte(string backdrop, System.Drawing.Imaging.ImageFormat format)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(backdrop);
            // Bitmap bitmap; 
            Image bitmap = new Bitmap(Image.FromStream(stream));

            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                bitmap.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
          
        }



        public static Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }


    }


}
