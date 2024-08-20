namespace GildedRoseKata.ItemTypes;
public class AgedBrieItem : IUpdateQualityStrategy
{
    public void UpdateQuality(Item item)
    {
        if(item.Quality < 50)
            item.Quality++;

        if (item.SellIn <= 0 && item.Quality < 50)
            item.Quality++;

        item.SellIn--;
    }
}
