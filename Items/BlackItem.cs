using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Interfaces;

namespace csharp.Items
{   /// <summary>
    /// Category of items that degrade twice as fast
    /// Known items: "Conjured Mana Cake"
    /// </summary>
    class BlackItem : Item, IItemActions
    {
        public BlackItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void Update()
        {
            if (Quality > 0)
            {
                if (SellIn > 0 && Quality >= 2)
                    Quality -= 2;
                else if (SellIn < 0 && Quality >= 4)
                    Quality -= 4;
            }
            SellIn -= 1;
        }
    }
}
