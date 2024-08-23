using System;

namespace GildedRoseKata.ItemTypes;
public class BackstagePassItem : BaseItem
{
    private const int FirstQualityIncreaseThreshold = 10;
    private const int SecondQualityIncreaseThreshold = 5;


    public override void UpdateQuality(Item item)
    {
        if (IsExpired(item))
            ResetQualityToZero(item);
        else
        {
            IncreaseQuality(item);
            IncreaseQualityWhenFirstTreshholdReached(item);
            IncreaseQualityWhenSecondTreshholdReached(item);
        }

        DecreaseSellIn(item);
    }

    protected override void IncreaseQuality(Item item)
    {
        if (item.Quality < MaxQuality)
            item.Quality++;
    }

    private void IncreaseQualityWhenFirstTreshholdReached(Item item)
    {
        if (item.SellIn <= FirstQualityIncreaseThreshold)
            IncreaseQuality(item);
    }

    private void IncreaseQualityWhenSecondTreshholdReached(Item item)
    {
        if (item.SellIn <= SecondQualityIncreaseThreshold)
            IncreaseQuality(item);
    }

    private void ResetQualityToZero(Item item)
    {
        item.Quality = 0;
    }


}
