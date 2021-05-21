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


            //        Console.WriteLine("OMGHAI!");

            //        IList<Item> Items = new List<Item>{
            //            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            //            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            //            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            //            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            //            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            //            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
            //            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
            //            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
            //// this conjured item does not work properly yet
            //new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            //        };

            //        var app = new GildedRose(Items);


            //        for (var i = 0; i < 31; i++)
            //        {
            //            Console.WriteLine("-------- day " + i + " --------");
            //            Console.WriteLine("name, sellIn, quality");
            //            for (var j = 0; j < Items.Count; j++)
            //            {
            //                Console.WriteLine(Items[j]);
            //            }
            //            Console.WriteLine("");
            //            app.UpdateQuality();
            //        }
            //        Console.ReadLine();
        }
    }
}
