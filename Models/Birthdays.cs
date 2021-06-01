using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mobile_App.Models
{
    public class Birthdays
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime Date { get; set; }



    }
}
