using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayFormat
{
    public class Person
    {
        public string name;
        public DateTime date;

        public Person(string n, DateTime d)
        {
            name = n;
            date = d;
        }

        public Person()
        {
            name = "New Person";
            date = DateTime.Today;
        }
    }
}