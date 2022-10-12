using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flixter
{
    class Database
    {
        private SQLiteConnection sQLiteConnection;

        public Database()
        {
            sQLiteConnection = new SQLiteConnection("Data Source=films.db");
            if (!File.Exists("./films.db")){
                SQLiteConnection.CreateFile("films.db");
            }
        }
                

    }
}
