using SQLite;

namespace Xam_test_01.Models
{
    public class BrojacRezultataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Tema { get; set; }
        public int Rezultat { get; set; }
        public int Level { get; set; }
    }
}
