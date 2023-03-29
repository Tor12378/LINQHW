using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Consumer
    {
        public int Code { get; set; }
        public int BirthYear { get; set; }
        public string Street { get; set; }
    }

    class StoreItem
    {
        public string StoreName { get; set; }
        public decimal Price { get; set; }
        public int ItemCode { get; set; }
    }

    class Purchase
    {
        public int ConsumerCode { get; set; }
        public int ItemCode { get; set; }
        public string StoreName { get; set; }
    }
    internal class Linq89
    {
        public static void Func()
        {

            List<Consumer> consumers = new List<Consumer>
        {
            new Consumer { Code = 1, BirthYear = 1990, Street = "ул. Ленина" },
            new Consumer { Code = 2, BirthYear = 1985, Street = "ул. Пушкина" },
            new Consumer { Code = 3, BirthYear = 2000, Street = "ул. Гагарина" },
            new Consumer { Code = 4, BirthYear = 1995, Street = "ул. Садовая" }
        };

            List<StoreItem> storeItems = new List<StoreItem>
        {
            new StoreItem { StoreName = "Магазин А", Price = 1500m, ItemCode = 100 },
            new StoreItem { StoreName = "Магазин А", Price = 2000m, ItemCode = 101 },
            new StoreItem { StoreName = "Магазин Б", Price = 3000m, ItemCode = 102 },
            new StoreItem { StoreName = "Магазин Б", Price = 2500m, ItemCode = 103 }
        };

            List<Purchase> purchases = new List<Purchase>
        {
            new Purchase { ConsumerCode = 1, ItemCode = 100, StoreName = "Магазин А" },
            new Purchase { ConsumerCode = 1, ItemCode = 101, StoreName = "Магазин А" },
            new Purchase { ConsumerCode = 2, ItemCode = 102, StoreName = "Магазин Б" },
            new Purchase { ConsumerCode = 3, ItemCode = 103, StoreName = "Магазин Б" },
            new Purchase { ConsumerCode = 4, ItemCode = 100, StoreName = "Магазин А" }
        };
            var result = purchases
     .Join(consumers, p => p.ConsumerCode, c => c.Code, (p, c) => new { Purchase = p, Consumer = c })
     .Join(storeItems, pc => pc.Purchase.ItemCode, si => si.ItemCode, (pc, si) => new { pc.Consumer, pc.Purchase, StoreItem = si })
     .GroupBy(x => new { x.Purchase.StoreName, x.Consumer.Code, x.Consumer.BirthYear })
     .Select(g => new
     {
         StoreName = g.Key.StoreName,
         ConsumerCode = g.Key.Code,
         BirthYear = g.Key.BirthYear,
         TotalPrice = g.Sum(x => x.StoreItem.Price)
     })
     .GroupBy(x => x.StoreName)
     .Select(g => new
     {
         StoreName = g.Key,
         MinBirthYear = g.Min(x => x.BirthYear),
         Consumers = g.Where(x => x.BirthYear == g.Min(y => y.BirthYear)).OrderBy(x => x.ConsumerCode)
     })
     .OrderBy(x => x.StoreName);

            foreach (var store in result)
            {
                foreach (var consumer in store.Consumers)
                {
                    Console.WriteLine($"{store.StoreName} {consumer.ConsumerCode} {consumer.BirthYear} {consumer.TotalPrice}");
                }
            }

        }

        }
    }
