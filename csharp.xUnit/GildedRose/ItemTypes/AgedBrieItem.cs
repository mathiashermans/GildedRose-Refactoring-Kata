namespace GildedRoseKata.ItemTypes;
public class AgedBrieItem : BaseItem
{
    public override void UpdateQuality(Item item)
    {
        IncreaseQuality(item);
        if (IsExpired(item))
            IncreaseQuality(item);

        DecreaseSellIn(item);
    }
}
