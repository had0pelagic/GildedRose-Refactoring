using System.Collections.Generic;
using csharp.Interfaces;

namespace csharp
{
    public class GildedRose
    {
        IList<IItemActions> Items;

        public GildedRose(IList<IItemActions> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.Update();
            }
        }
    }
}
