using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    public  class Linq78
    {
        public static void  Func()
        {
            var sequenceD = new List<string> {
            "10,5 A1 Shop1",
            "20,5 A2 Shop2",
            "30,5 A1 Shop3",
            "40,5 A3 Shop4",
            "1 A4 Shop4"
        };
            var sequenceE = new List<string> {
            "1 Shop1 A1",
            "2 Shop2 A2",
            "3 Shop3 A1",
            "4 Shop4 A4"
        };
            var results = sequenceD
        .Select(line => line.Split())
        .Select(fields => new { Price = fields[0], Code = fields[1], Shop = fields[2] })
        .GroupBy(info => info.Code)
        .Join(sequenceE.Select(line => line.Split()),
              group => group.Key,
              fields => fields[2],
              (group, fields) => new
              {
                  Code = group.Key,
                  PurchaseCount = group.Count(),
                  MaxPrice = group.Max(g => decimal.Parse(g.Price)),
                  Shops = string.Join(", ", group.Select(g => g.Shop).Distinct())
              })
        .OrderBy(info => info.PurchaseCount)
        .ThenBy(info => info.Code).Distinct();
            foreach (var result in results)
            {
                Console.WriteLine($"{result.PurchaseCount} {result.Code} {result.MaxPrice}");
            };
        }
    }
}
