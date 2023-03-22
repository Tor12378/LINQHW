using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class LinqObj45
    {
        public static void Func()
        {
            var str = "C:\\Users\\Тимур\\source\\repos\\ConsoleApp14\\TextFile5.txt";
            var t = File.ReadAllLines(str).Select(x => x.Split(" ")).Select(t => new
            {
                Name = t[0],
                Price = int.Parse(t[1]),
                Num = int.Parse(t[2]),
                Street = t[3],
            });
            var res = t.GroupBy(x => new { Str = x.Street, Nam = x.Name }).Select(gr => new { gr.Key.Str, gr.Key.Nam, Kol = gr.Count() }).GroupBy(x => x.Str).Select(g =>

            new
            {
                S = g.Key,
                K = g.Count()

            }).OrderBy(x => x.S) ; 
             
            
            foreach (var entry in res)
            {
                Console.WriteLine("{0} {1}  ", entry.S, entry.K);

            }

        }
    }
}
