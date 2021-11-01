using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    class Programm
    {

        static void Main(string[] args)
        {
            var hashtb = new CustomDic<int, string>(100);
            hashtb.Add(1, "Hash");
            hashtb.Add(11, "SGU");
            hashtb.Add(45, "EPAM");

            foreach (var elem in hashtb)
            {
                
            
            }
            Console.WriteLine(hashtb.Search(45, "EPAM"));

        }


    }
}
