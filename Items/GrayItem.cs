using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Interfaces;

namespace csharp.Items
{   /// <summary>
    /// Category for items that decrease quality by 1 
    /// Known items: "+5 Dexterity Vest", "Elixir of the Mongoose"
    /// </summary>
    class GrayItem : Item, IItemActions
    {
        public GrayItem(string name, int sellIn, int quality)
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
            if (SellIn > 0 && IsQualityAbove(0))
                Quality -= 1;
            else if (SellIn <= 0 && IsQualityAbove(0))
                Quality -= 2;
        }

        bool IsQualityAbove(int val)
        {
            return Quality > val;
        }
    }
}
