using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class LinqObj23
    {
        public  static void Func()
        {
            var file = "C:\\Users\\Тимур\\source\\repos\\ConsoleApp14\\TextFile3.txt";
            var t = File.ReadAllLines(file).Select(x => x.Split(" ")).Select(y => new
            {
                LastName =y[0],
                Year = int.Parse(y[1]),
                School = int.Parse(y[2]),
            });
            var res = t
                .GroupBy(r => new { r.Year, r.School })
                .Select(gr => new { gr.Key.Year, gr.Key.School, Kol = gr.Count() }).OrderByDescending(x=>x.Year).ThenBy(y=>y.School);
            
            foreach (var entry in res )
            {
                Console.WriteLine("{0} {1} {2} ", entry.Year,entry.School,entry.Kol);
                
            }
        }
            
        
    }
}
