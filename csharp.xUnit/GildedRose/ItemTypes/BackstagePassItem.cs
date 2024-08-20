using System;

namespace GildedRoseKata.ItemTypes;
public class BackstagePassItem : IUpdateQualityStrategy
{
    public void UpdateQuality(Item item)
    {      
        if (item.SellIn <= 0)
        {
            item.Quality = 0;
        }
        else {
            if (item.Quality < 50)
                item.Quality++;

            if (item.SellIn < 11 && item.Quality < 50)
                item.Quality++;

            if (item.SellIn < 6 && item.Quality < 50)
                item.Quality++;
        }

        item.SellIn--;
    }
}
