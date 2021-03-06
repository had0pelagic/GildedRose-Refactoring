using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Interfaces;

namespace csharp.Items
{   /// <summary>
    /// Category of items that degrade twice as fast as normal items (normal: Quality-1)
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
            QualityUpdate();
            SellIn--;
        }

        void QualityUpdate()
        {
            if (SellIn > 0 && IsQualityAboveLimit(2) && IsQualityAbove(0))
                Quality -= 2;
            else if (SellIn <= 0 && IsQualityAboveLimit(4) && IsQualityAbove(0))
                Quality -= 4;
        }

        bool IsQualityAboveLimit(int val)
        {
            return (Quality - val) >= 0 ? true : false;
        }

        bool IsQualityAbove(int val)
        {
            return Quality > val;
        }
    }
}
