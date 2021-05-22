using System;
using System.Collections.Generic;
using csharp.Items;
using csharp.Interfaces;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<IItemActions> Items = new List<IItemActions> {
                new GrayItem ("+5 Dexterity Vest", 10, 20),
                new BlueItem ("Aged Brie", 2, 0),
                new GrayItem ("Elixir of the Mongoose", 5, 7),
                new GoldenItem ("Sulfuras, Hand of Ragnaros", 0, 80),
                new GoldenItem ("Sulfuras, Hand of Ragnaros", -1, 80),
                new PinkItem ("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new PinkItem("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                new PinkItem ("Backstage passes to a TAFKAL80ETC concert", 5, 49),
                new BlackItem ("Conjured Mana Cake", 3, 6)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var item in Items)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
            Console.ReadLine();
        }
    }
}
