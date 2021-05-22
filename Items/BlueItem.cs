﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Interfaces;

namespace csharp.Items
{   /// <summary>
    /// Category of items that increase quality by 1
    /// Quality is limited to 50
    /// Known items: "Aged Brie"
    /// </summary>
    class BlueItem : Item, IItemActions
    {
        public BlueItem(string name, int sellIn, int quality)
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
            if (SellIn > 0 && IsQualityLower(50))
                Quality += 1;
            else if (SellIn <= 0 && IsQualityLower(50))
                Quality += 2;
        }

        bool IsQualityLower(int val)
        {
            return Quality < val;
        }
    }
}
