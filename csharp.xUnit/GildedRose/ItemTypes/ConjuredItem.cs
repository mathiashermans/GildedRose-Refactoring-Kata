namespace GildedRoseKata.ItemTypes;
public class ConjuredItem : StandardItem
{
    protected override void DecreaseQuality(Item item)
    {
        if (item.Quality > MinQuality)
            item.Quality--;

        if (item.Quality > MinQuality)
            item.Quality--;
    }
}
