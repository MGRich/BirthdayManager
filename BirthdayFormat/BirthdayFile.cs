using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BirthdayFormat
{
    public class BirthdayFile
    {
        public List<Person> people = new List<Person>();

        public BirthdayFile(string s)
        {
            getPeople(File.Open(s, FileMode.Open));
        }

        public BirthdayFile(Stream s)
        {
            getPeople(s);
        }

        public BirthdayFile(Person[] p)
        {
            people = p.ToList();
        }

        private void getPeople(Stream s)
        {
            string readString()
            {
                StringBuilder sb = new StringBuilder();
                while (true)
                {
                    int t = s.ReadByte();
                    if (t == 0x00) return sb.ToString();
                    sb.Append((char)t);
                }
            }

            while (s.Position < s.Length)
            {
                string n = readString();
                int m = s.ReadByte();
                int d = s.ReadByte();
                byte[] b = new byte[2];
                s.Read(b, 0, 2);
                int y = BitConverter.ToInt16(b, 0);
                DateTime date = new DateTime(y, m, d);
                people.Add(new Person(n, date));
                Console.WriteLine(s.Position + " " + s.Length);
            }
            s.Close();
        }

        public void write(Stream s)
        {
            foreach (Person p in people)
            {
                s.Write(Encoding.Default.GetBytes(p.name), 0, p.name.Length);
                s.WriteByte(0);
                s.WriteByte((byte)p.date.Month);
                s.WriteByte((byte)p.date.Day);
                short t = (short)p.date.Year;
                s.Write(BitConverter.GetBytes(t), 0, 2);
            }
            s.Close();
        }

        public void write(string s)
        {
            if (File.Exists(s)) write(File.Open(s, FileMode.Truncate));
            else write(File.Open(s, FileMode.Create));
        }
    }
}