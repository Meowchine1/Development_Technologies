using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Development_Technologies
{
    public class Name
    {
        public string name;
        public string surname;
        public string thirdname;

        public Name(string s, string n, string sec)
        {
            name = n;
            surname = s;
            thirdname = sec;

        }

        public void Show()
        {
            Console.WriteLine("{0} {1} {2}", surname, name, thirdname);
        }

    }

    public class Program
    {

        static void Main(string[] args)
        {
            string end = @"\data\FirstEx.txt";   
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            List<Name> spisok = new List<Name>();

            using (StreamReader input = new StreamReader(path + end))
            {
           
                while (!input.EndOfStream)
                {
                    string[] tmp = input.ReadLine().Split(' ');
                    Name person = new Name(tmp[0], tmp[1], tmp[2]);
                    spisok.Add(person);

                }

            }


            var sorted = spisok.OrderBy(t => t.surname)
                .ThenByDescending(t => t.name).ThenByDescending(t => t.surname).ThenByDescending(t => t.thirdname);

            foreach (var elem in sorted)
            {
                elem.Show();

            }




        }
    }
}


