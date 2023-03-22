using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class LinqObj1
    {
        public static void Func()
        {
            string sourceFileName = "C:\\Users\\Тимур\\source\\repos\\ConsoleApp14\\TextFile1.txt";


            var sourceSequence = File.ReadAllLines(sourceFileName)
                .Select(line => line.Split(' '))
                .Select(fields => new
                {
                    Code = int.Parse(fields[0]),
                    Year = int.Parse(fields[1]),
                    Month = int.Parse(fields[2]),
                    Duration = int.Parse(fields[3])
                });


            var lastMinDurationElement = sourceSequence.Aggregate((a, b) => a.Duration >= b.Duration?b:a);
            Console.WriteLine("{0} {1} {2}", lastMinDurationElement.Duration, lastMinDurationElement.Year, lastMinDurationElement.Month);
        }
    }
}
