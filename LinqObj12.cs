using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class LinqObj12
    {
        public static void Func()
        {
            string sourceFileName = "C:\\Users\\Тимур\\source\\repos\\ConsoleApp14\\TextFile2.txt";

            var secondLine = int.Parse(File.ReadLines(sourceFileName).First());
            var sourceSequence = File.ReadAllLines(sourceFileName).Skip(1)
                .Select(line => line.Split(' '))
                .Select(fields => new
                {
                    Duration = int.Parse(fields[0]),
                    Code = int.Parse(fields[1]),
                    Month = int.Parse(fields[2]),
                    Year = int.Parse(fields[3])
                }); ;

            var groupedByYear = sourceSequence.GroupBy(c => c.Year).Select(group =>
            {
                var year = group.Key;
                var groupByMonth = group.GroupBy(c => c.Month);
                var m = groupByMonth.Where(x => x.Sum(c => c.Duration) > group.Sum(v => v.Duration) * secondLine / 100).Select(m => m.Key).ToList();
                return new { Year = year, MonthsCount = m.Count, Months = m };
            }).Where(u=>u.MonthsCount > 0).OrderByDescending(u => u.MonthsCount).ThenBy(u => u.Year);
            foreach (var entry in groupedByYear)
            {
                Console.WriteLine("{0} {1}", entry.MonthsCount, entry.Year);
                Console.WriteLine("Months: {0}", string.Join(", ", entry.Months));
            }
        }
    }
}
