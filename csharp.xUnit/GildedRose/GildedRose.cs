using GildedRoseKata.ItemTypes;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach(var item in Items)
        {
           var strategy = GetStrategy(item);
            strategy.UpdateQuality(item);
        }
    }

    private IUpdateQualityStrategy GetStrategy(Item item)
    {
        switch (item.Name)
        {
            case "Aged Brie":
                return new AgedBrieItem();
            case "Sulfuras, Hand of Ragnaros":
                return new SulfurasItem();
            case "Backstage passes to a TAFKAL80ETC concert":
                return new BackstagePassItem();
            case var name when name.StartsWith("Conjured "):
                return new ConjuredItem();
            default:
                return new StandardItem();
        }
    }
}