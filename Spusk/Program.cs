using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Spusk
{
    class Program
    {
        static void Main(string[] args)
        {
            string end = @"\data\SecEx.txt";
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            using (StreamReader reader = new StreamReader(path + end))
            {
                int n = int.Parse(reader.ReadLine());
                int index = 0;

                string tm = reader.ReadToEnd();
                StringBuilder a = new StringBuilder(tm);
                for (int i = 0; i < a.Length;)
                {
                    if (char.IsPunctuation(a[i]))
                    {
                        a.Remove(i, 1);
                    }
                    else
                    {
                        if (char.IsWhiteSpace(a[i]))
                        {
                            a[i] = ' ';
                        }
                        ++i;
                    }
                }
                string[] tmp = a.ToString().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int[][] myArr = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    myArr[i] = new int[i];
                }
                int[,] mas = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        mas[i, j] = int.Parse(tmp[index]);
                        index++;
                    }

                }

                for (int i = n - 1; i > 0; i--)
                {
                    for (int j = 0; j < n - 1; j++)
                    {
                        int max = (mas[i, j] > mas[i, j + 1]) ? mas[i, j] : mas[i, j + 1];
                        mas[i - 1, j] += max;
                    }

                }

                Console.WriteLine(mas[0, 0]);

            }

        }
    }
}
