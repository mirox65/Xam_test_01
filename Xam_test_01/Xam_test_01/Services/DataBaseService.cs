using SQLite;
using System.IO;
using System.Threading.Tasks;
using Xam_test_01.Models;
using Xamarin.Essentials;

namespace Xam_test_01.Services
{
    public static class DataBaseService
    {
        static SQLiteConnection db;

        static async Task Init()
        {
            if (db != null)
            {
               return;
            }
            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteConnection(databasePath);

            db.CreateTable<BrojacRezultata>();
        }
        
        public static async Task InsertInto(string tema, int rezultat, int level)
        {
            await Init();
            var unos = new BrojacRezultata
            {
                Tema = tema,
                Rezultat = rezultat,
                Level = level
            };

            db.Insert(unos);
        }

        public static async Task<int> SelectLevel(string tema)
        {
            await Init();

            int level;

            var query = db.Table<BrojacRezultata>().Where(t => t.Tema.Equals(tema)).OrderByDescending(x => x.Level).FirstOrDefault();
            var result = query;

            if (result is null)
            {
                level = 1;
            }
            else
            {
                level = result.Level;
            }
            return level;
        }

        public static async Task<int> SelectCount(string tema, int level)
        {
            await Init();

            var query = db.Table<BrojacRezultata>().Where(t => t.Tema.Equals(tema) && t.Level.Equals(level)).Count();
            var ukupno = query;

            return ukupno;
        }

        public static async Task<int> SelectCorrectCount(string tema, int level)
        {
            await Init();

            var query = db.Table<BrojacRezultata>().Where(t => t.Tema.Equals(tema) && t.Rezultat.Equals(1) && t.Level.Equals(level)).Count();
            var tocniRezultati = query;

            return tocniRezultati;
        }

    }
}
