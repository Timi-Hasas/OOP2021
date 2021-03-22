using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    class Author
    {
        public Author(string firstName, string lastName, DateTime birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDay.Year;
                if (BirthDay.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
        public int TotalArticles { get; set; } = 0;
        public override string ToString()
        {
            string author = $"{FirstName} {LastName}";
            author += $"\nBirthday: {BirthDay.Date} (Age: {Age})";
            return author;
        }
    }
}
