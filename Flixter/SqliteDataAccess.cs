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

                var query = "CREATE TABLE IF NOT EXISTS offline (adult CHAR(50), title CHAR(50), image BLOB, release_date TEXT, original_language TEXT, popularity NUMERIC, vote_count INTEGER, overview	TEXT)";

                cnn.Execute(query, new DynamicParameters());
            }
        }
        public static List<Film> LoadFilms()
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=./films.db;Version=3"))
            {
                var output = cnn.Query<Film>("select * from offline", new DynamicParameters());
                return output.ToList();
            }

        }
        
        public static void SaveFilm(Film film)
        {
            using (SQLiteConnection cnn = new SQLiteConnection("Data Source=./films.db;Version=3"))
            {
                cnn.Open();

              
                var backdrop = "https://image.tmdb.org/t/p/w342" + film.backdrop_path;
                //byte[] imageData = ReadFile(backdrop);
                // Image photo = new Bitmap(@"\Photos\Image20120601_1.jpeg");
                byte[] pic = ImageToByte(backdrop, System.Drawing.Imaging.ImageFormat.Jpeg);
                string sql = "insert into offline (title, overview, image, release_date, vote_count,id,original_language) values(@title, @overview, @pic,  @release_date, @vote_count, @id, @original_language)";
                string s = @"
                        insert into offline (title, overview, image, release_date, vote_count,id,original_language)
                        Select @title , @overview, @pic, @release_date, @release_date,@vote_count, @id, @original_language
                        Where not exists (
                            select * 
                            from offline 
                            where 
                                id = @id)
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

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        //Open file in to a filestream and read data in a byte array.
        static byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
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
    }


}
