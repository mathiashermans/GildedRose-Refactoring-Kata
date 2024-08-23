using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.ItemTypes;
public abstract class BaseItem : IUpdateQualityStrategy
{
    protected const int MaxQuality = 50;
    protected const int MinQuality = 0;

    public abstract void UpdateQuality(Item item);

    protected void DecreaseSellIn(Item item)
    {
        item.SellIn--;
    }

    protected virtual void DecreaseQuality(Item item)
    {
        if (item.Quality > MinQuality)
            item.Quality--;
    }

    protected virtual void IncreaseQuality(Item item)
    {
        if (item.Quality < MaxQuality)
            item.Quality++;
    }

    protected bool IsExpired(Item item)
    {
        return item.SellIn <= 0;
    }
}
