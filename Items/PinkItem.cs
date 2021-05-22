using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Interfaces;

namespace csharp.Items
{   /// <summary>
    /// Category for items that increase quality by 1 while SellIn approaches
    /// Quality increases by 2 when 10 or less days are left
    /// Quality increases by 3 when 5 or less days are left
    /// Quality drops to 0 after concert
    /// Quality is limited to 50
    /// Known items: "Backstage passes to a TAFKAL80ETC concert"
    /// </summary>
    class PinkItem : Item, IItemActions
    {
        public PinkItem(string name, int sellIn, int quality)
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
            if (SellIn <= 0)
                Quality = 0;

            else if (Quality < 50)
            {
                if (SellIn <= 10 && SellIn > 5 && ExceedLimit(2))
                    Quality += 2;
                else if (SellIn <= 5 && SellIn != 0 && ExceedLimit(3))
                    Quality += 3;
                else
                    Quality += 1;
            }
        }

        bool ExceedLimit(int val)
        {
            return (Quality + val) > 50 ? false : true;
        }
    }
}
