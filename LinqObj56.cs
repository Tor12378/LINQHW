using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class LinqObj56
    {
        public static void Func()
        {
            var str = "C:\\Users\\Тимур\\source\\repos\\ConsoleApp14\\TextFile6.txt";
            var t = File.ReadAllLines(str).Select(x => x.Split(" ")).Select(t => new
            {
                Name = t[0],
                I = t[1]+"."+ t[2],
                Score=new List<int> { int.Parse(t[3]), int.Parse(t[4]), int.Parse(t[5]) },
                School = int.Parse(t[6])
            });
            var res=t.Where(x=>x.Score.Any(x=>x>=90)).OrderBy(x=>x.Name).ThenBy(x => x.I).ThenBy(x => x.School);
            if(res.Count() > 0)
            {
                foreach (var entry in res)
                {
                    Console.WriteLine("{0} {1} {2} ", entry.Name, entry.I,entry.School);

                }
            }
            else { Console.WriteLine("Требуемые учащиеся не найдены»."); }
        }
    }
}
