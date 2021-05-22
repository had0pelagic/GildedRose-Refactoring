using csharp.Interfaces;
using csharp.Items;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        /// <summary>
        /// Test if Quality decreases by 1, multiple
        /// </summary>
        [Test]
        public void Test_IfSellInAndQualityDecreases_Multiple()
        {
            var items = new List<IItemActions> {
                new GrayItem ("+5 Dexterity Vest", 10, 20),
                new BlueItem ("Aged Brie", 2, 0),
                new PinkItem ("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new GoldenItem ("Sulfuras, Hand of Ragnaros", 0, 80),
                new BlackItem ("Conjured Mana Cake", 3, 6)
            };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual("+5 Dexterity Vest, 9, 19", items[0].ToString());
            Assert.AreEqual("Aged Brie, 1, 1", items[1].ToString());
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert, 14, 21", items[2].ToString());
            Assert.AreEqual("Sulfuras, Hand of Ragnaros, 0, 80", items[3].ToString());
            Assert.AreEqual("Conjured Mana Cake, 2, 4", items[4].ToString());
        }
        /// <summary>
        /// Test if Quality decreases by 1
        /// </summary>
        [Test]
        public void Test_IfQualityDecreases_DecreaseBy1()
        {
            var item = new GrayItem("+5 Dexterity Vest", 10, 20);

            item.Update();

            Assert.AreEqual(19, item.Quality);
        }
        /// <summary>
        /// Test if Quality decreases by 2
        /// </summary>
        [Test]
        public void Test_IfQualityDecreases_DecreaseBy2()
        {
            var item = new BlackItem("Conjured Mana Cake", 3, 6);

            item.Update();

            Assert.AreEqual(4, item.Quality);
        }
        /// <summary>
        /// Test if Quality decreases double the amount when SellIn is 0 or lower
        /// </summary>
        [Test]
        public void Test_IfQualityDecreases_DecreaseDouble()
        {
            var items = new List<IItemActions> {
                new GrayItem("+5 Dexterity Vest", 0, 20),
                new BlackItem("Conjured Mana Cake", 0, 6)
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("+5 Dexterity Vest, -1, 18", items[0].ToString());
            Assert.AreEqual("Conjured Mana Cake, -1, 2", items[1].ToString());
        }
        /// <summary>
        /// Test if Quality becomes negative
        /// </summary>
        [Test]
        public void Test_IfQualityBecomesNegative()
        {
            var items = new List<IItemActions> {
                new GrayItem("+5 Dexterity Vest", 0, 0),
                new BlackItem("Conjured Mana Cake", 0, 0),
                new GrayItem("Elixir of the Mongoose", 10, 0),
                new BlackItem("Conjured Mana Cake", 11, 0)
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("+5 Dexterity Vest, -1, 0", items[0].ToString());
            Assert.AreEqual("Conjured Mana Cake, -1, 0", items[1].ToString());
            Assert.AreEqual("Elixir of the Mongoose, 9, 0", items[2].ToString());
            Assert.AreEqual("Conjured Mana Cake, 10, 0", items[3].ToString());
        }
        /// <summary>
        /// Test if Quality increases by 1
        /// </summary>
        [Test]
        public void Test_IfQualityIncreases_WhenSellInAbove10_By1()
        {
            var item = new BlueItem("Aged Brie", 15, 0);

            item.Update();

            Assert.AreEqual(1, item.Quality);
        }
        /// <summary>
        /// Test if Quality increases by 2 when SellIn is between 10 and 5
        /// </summary>
        [Test]
        public void Test_IfQualityIncreases_WhenSellInBetween10And5_By2()
        {
            var item = new PinkItem("Backstage passes to a TAFKAL80ETC concert", 8, 0);

            item.Update();

            Assert.AreEqual(2, item.Quality);
        }
        /// <summary>
        /// Test if Quality increases by 3 when SellIn is lower than 5
        /// </summary>
        [Test]
        public void Test_IfQualityIncreases_WhenSellInBelow5_By3()
        {
            var item = new PinkItem("Backstage passes to a TAFKAL80ETC concert", 4, 0);

            item.Update();

            Assert.AreEqual(3, item.Quality);
        }
        /// <summary>
        /// Test if Quality is limited to 50
        /// </summary>
        [Test]
        public void Test_IfQuality_IsLimitedTo50()
        {
            var item = new PinkItem("Backstage passes to a TAFKAL80ETC concert", 4, 50);

            item.Update();

            Assert.AreEqual(50, item.Quality);
        }
        /// <summary>
        /// Test if Quality drops to 0 after concert ( when SellIn equal or less than 0)
        /// </summary>
        [Test]
        public void Test_IfQualityDrops_To0()
        {
            var item = new PinkItem("Backstage passes to a TAFKAL80ETC concert", 0, 50);

            item.Update();

            Assert.AreEqual(0, item.Quality);
        }
        /// <summary>
        /// Test if Quality and SellIn values stay the same
        /// </summary>
        [Test]
        public void Test_IfQualityAndSellIn_StaysTheSame()
        {
            var items = new List<IItemActions> {
                new GoldenItem ("Sulfuras, Hand of Ragnaros", 0, 80),
                new GoldenItem ("Sulfuras, Hand of Ragnaros", 1, 80),
                new GoldenItem ("Sulfuras, Hand of Ragnaros", 9, 80),
                new GoldenItem ("Sulfuras, Hand of Ragnaros", 8, 80),
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Sulfuras, Hand of Ragnaros, 0, 80", items[0].ToString());
            Assert.AreEqual("Sulfuras, Hand of Ragnaros, 1, 80", items[1].ToString());
            Assert.AreEqual("Sulfuras, Hand of Ragnaros, 9, 80", items[2].ToString());
            Assert.AreEqual("Sulfuras, Hand of Ragnaros, 8, 80", items[3].ToString());
        }
    }
}
