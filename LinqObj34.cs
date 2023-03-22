using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class LinqObj34
    {
        public static void Func()
        {
            var str = "C:\\Users\\Тимур\\source\\repos\\ConsoleApp14\\TextFile4.txt";
            var t = File.ReadAllLines(str).Select(x => x.Split(" ")).Select(t => new
            {
                Money = double.Parse(t[0]),
                Number = int.Parse(t[1]),
                Name = t[2]
            });
            var gr=t.Sum(x => x.Money)/t.Count(y=>y.Money>0);
            var res = t.Where(x => x.Money < gr).Select(y => new
            {
                M = y.Money,
                N = y.Number,
                Nam = y.Name,

                F= ((y.Number - 1) / 4) % (((y.Number - 1) / 4) % 9 + 1) + 1

            }).OrderByDescending(x => x.F).ThenBy(y => y.N); 
            foreach (var entry in res)
            {
                Console.WriteLine("{0} {1} {2} {3} ", entry.M, entry.N, entry.Nam,entry.F);

            }

        }
    }
    
}
