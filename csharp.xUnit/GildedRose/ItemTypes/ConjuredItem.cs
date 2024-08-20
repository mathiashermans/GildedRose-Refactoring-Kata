namespace GildedRoseKata.ItemTypes;
public class ConjuredItem : IUpdateQualityStrategy
{
    public void UpdateQuality(Item item)
    {
        if (item.Quality > 0)
            item.Quality-= 2;

        if (item.Quality > 0 && item.SellIn <= 0)
            item.Quality-= 4;

        item.SellIn--;

        if(item.Quality < 0)
            item.Quality = 0;
    }
}
