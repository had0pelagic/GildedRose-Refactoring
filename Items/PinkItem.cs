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
            else if (IsDateInBetween(5, 0) && IsLimitAbove(3) && IsQualityLower(50))
                Quality += 3;
            else if (IsDateInBetween(10, 5) && IsLimitAbove(2) && IsQualityLower(50))
                Quality += 2;
            else if (IsQualityLower(50))
                Quality += 1;
        }

        bool IsDateInBetween(int fDay, int sDay)
        {
            return fDay >= SellIn && sDay < SellIn;
        }

        bool IsLimitAbove(int increase)
        {
            return (Quality + increase) > 50 ? false : true;
        }

        bool IsQualityLower(int val)
        {
            return Quality < val;
        }
    }
}
