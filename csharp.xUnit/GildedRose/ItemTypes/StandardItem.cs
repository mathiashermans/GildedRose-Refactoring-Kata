namespace GildedRoseKata.ItemTypes;
public class StandardItem : BaseItem
{
    public override void UpdateQualityAndSellIn(Item item)
    {
        DecreaseQuality(item);
        if (IsExpired(item))
            DecreaseQuality(item);

        DecreaseSellIn(item);
    }
}
