using ConsoleApp14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Consumer
{
    public string Street { get; set; }
    public int Code { get; set; }
    public int BirthYear { get; set; }
}

class Product
{
    public int ItemCode { get; set; }
    public string Country { get; set; }
    public string Category { get; set; }
}

class StoreItem
{
    public string StoreName { get; set; }
    public decimal Price { get; set; }
    public int ItemCode { get; set; }
}

class Purchase
{
    public int ItemCode { get; set; }
    public int ConsumerCode { get; set; }
    public string StoreName { get; set; }
}
internal class LiNQ100
    {
        public static void Func()
        {
        List<Consumer> consumers = new List<Consumer>
{
    new Consumer { Street = "ул. Ленина", Code = 1, BirthYear = 1990 },
    new Consumer { Street = "ул. Пушкина", Code = 2, BirthYear = 1985 },
    new Consumer { Street = "ул. Гагарина", Code = 3, BirthYear = 2000 },
    new Consumer { Street = "ул. Садовая", Code = 4, BirthYear = 1995 }
};

        List<Product> products = new List<Product>
{
    new Product { ItemCode = 100, Country = "Россия", Category = "Электроника" },
    new Product { ItemCode = 101, Country = "США", Category = "Электроника" },
    new Product { ItemCode = 102, Country = "Германия", Category = "Авто" },
    new Product { ItemCode = 103, Country = "Франция", Category = "Авто" }
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
    new Purchase { ItemCode = 100, ConsumerCode = 1, StoreName = "Магазин А" },
    new Purchase { ItemCode = 101, ConsumerCode = 1, StoreName = "Магазин А" },
    new Purchase { ItemCode = 102, ConsumerCode = 2, StoreName = "Магазин Б" },
    new Purchase { ItemCode = 103, ConsumerCode = 3, StoreName = "Магазин Б" },
    new Purchase { ItemCode = 100, ConsumerCode = 4, StoreName = "Магазин А" }
};
        var result = purchases
    .Join(consumers, p => p.ConsumerCode, c => c.Code, (p, c) => new { Purchase = p, Consumer = c })
    .Join(products, pc => pc.Purchase.ItemCode, pr => pr.ItemCode, (pc, pr) => new { pc.Consumer, pc.Purchase, Product = pr })
    .Join(storeItems, pcr => pcr.Purchase.ItemCode, si => si.ItemCode, (pcr, si) => new { pcr.Consumer, pcr.Product, StoreItem = si })
    .GroupBy(x => new { x.Product.Country, x.StoreItem.StoreName, x.Consumer.Code, x.Consumer.BirthYear })
    .Select(g => new
    {
        Country = g.Key.Country,
        StoreName = g.Key.StoreName,
        ConsumerCode = g.Key.Code,
        BirthYear = g.Key.BirthYear,
        TotalPrice = g.Sum(x => x.StoreItem.Price)
    })
    .GroupBy(x => new { x.Country, x.StoreName })
    .Select(g => new
    {
        Country = g.Key.Country,
        StoreName = g.Key.StoreName,
        MaxBirthYear = g.Max(x => x.BirthYear),
        Consumers = g.Where(x => x.BirthYear == g.Max(y => y.BirthYear)).OrderBy(x => x.ConsumerCode)
    })
    .OrderBy(x => x.Country).ThenBy(x => x.StoreName);

        StringBuilder output = new StringBuilder();
        foreach (var countryStore in result)
        {
            foreach (var consumer in countryStore.Consumers)
            {
                output.AppendLine($"{countryStore.Country} {countryStore.StoreName} {consumer.BirthYear} {consumer.ConsumerCode} {consumer.TotalPrice}");
            }
        }
        Console.WriteLine(output.ToString());
    }
    }

