using System;
using SQLite;

namespace MyAppTest
{
    public class User
    {
        public User()
        {
        }

        [PrimaryKey, AutoIncrement, Column("_UserId")]
        public int UserId { get; set; }

        [MaxLength(250)]
        public string EmailAddress { get; set; }

        [MaxLength(250)]
        public string Password { get; set; }

    }
}
