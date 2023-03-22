using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class LinqObj67
    {
        public static void Func()
        {
            var str = "C:\\Users\\Тимур\\source\\repos\\ConsoleApp14\\TextFile7.txt";
            var t = File.ReadAllLines(str).Select(x => x.Split(" ")).Select(t => new
            {
                Class = int.Parse(t[0]),
                Predmet = t[1],
                LastName = t[2],
                Name = t[3],
                Score= int.Parse(t[4])
            });
            var res = t.GroupBy(x => x.LastName).Select(x => new
            {
                
                all2 = x.Where(x => x.Score == 2).Count(),
                LastName = x.Key,
            }).Where(x=>x.all2>0).Join(t, 
             p => p.LastName, 
             c => c.LastName, 
             (p, c) => new { LastName = p.LastName, Class = c.Class,  Name= c.Name,Kol=p.all2 }).Distinct().OrderByDescending(x=>x.Class).ThenBy(x => x.LastName) ;
            if (res.Count() > 0)
            {
                foreach (var entry in res)
                {
                    Console.WriteLine("{1} {0} {1} {3} ", entry.LastName, entry.Class, entry.Name, entry.Kol);

                }
            }
            else { Console.WriteLine("Требуемые учащиеся не найдены»."); }
            

        }
    }
}
