using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Interfaces;

namespace csharp.Items
{   /// <summary>
    /// Category for items that won't change stats
    /// Known items: "Sulfuras, Hand of Ragnaros"
    /// </summary>
    class GoldenItem : Item, IItemActions
    {
        public GoldenItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void Update() { }
    }
}
