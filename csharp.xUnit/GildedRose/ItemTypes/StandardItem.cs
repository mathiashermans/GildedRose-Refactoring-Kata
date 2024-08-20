namespace GildedRoseKata.ItemTypes;
public class StandardItem : IUpdateQualityStrategy
{
    public void UpdateQuality(Item item)
    {
        if(item.Quality > 0)
            item.Quality--;
        
        if(item.Quality > 0 && item.SellIn <= 0)
            item.Quality--;

        item.SellIn--;
    }
}
