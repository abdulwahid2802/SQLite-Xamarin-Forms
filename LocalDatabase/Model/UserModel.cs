using System;
using SQLite;
namespace LocalDatabase.Model
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(30)] // optional
        public string Name { get; set; }

        [MaxLength(1000)]   // optional
        public string Comment { get; set; }

        [MaxLength(25)]   // optional
        public string Email { get; set; }
    }
}
