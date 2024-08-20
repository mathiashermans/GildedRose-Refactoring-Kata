using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    

    [Fact]
    // At the end of each day our system lowers both values for every item
    public void UpdateQuality_StandardItem_QualityDecreasesByOne()
    {
        // Given
        var quality = 2;
        IList<Item> Items = new List<Item> { Createitem("Item", 2, quality) };
        GildedRose app = new GildedRose(Items);

        // When
        app.UpdateQuality();

        // Then
        Assert.Equal(quality - 1, Items[0].Quality);
    }

    

    [Fact]
    // At the end of each day our system lowers both values for every item
    public void UpdateQuality_StandardItem_SellInDecreasesByOne()
    {

        // Given
        var sellIn = 2;
        IList<Item> Items = new List<Item> { Createitem("Item", sellIn, 2) };
        GildedRose app = new GildedRose(Items);
        
        // When
        app.UpdateQuality();
        
        // Then
        Assert.Equal(sellIn - 1, Items[0].SellIn);
    }

    [Fact]
    // Once the sell by date has passed, `Quality` degrades twice as fast
    public void UpdateQuality_ExpiredItem_QualityDecreasesByTwo()
    {
        // Given
        var quality = 2;
        IList<Item> Items = new List<Item> { Createitem("Item", 0, quality) };
        GildedRose app = new GildedRose(Items);
        
        // When
        app.UpdateQuality();
        
        // Then
        Assert.Equal(quality - 2, Items[0].Quality);
    }

    [Fact]
    // The `Quality` of an item is never negative
    public void UpdateQuality_ZeroQualityItem_QualityRemainsZero()
    {
        // Given
        var quality = 0;
        IList<Item> Items = new List<Item> { Createitem("Item", 0, quality) };
        GildedRose app = new GildedRose(Items);

        // When
        app.UpdateQuality();

        // Then
        Assert.Equal(quality, Items[0].Quality);
    }


    [Fact]
    // __"Aged Brie"__ actually increases in `Quality` the older it gets
    public void UpdateQuality_AgedBrie_QualityIncreasesByOne()
    {
        // Given
        var quality = 5;
        IList<Item> Items = new List<Item> { Createitem("Aged Brie", 10, quality) };
        GildedRose app = new GildedRose(Items);
        
        // When
        app.UpdateQuality();
        
        // Then
        Assert.Equal(quality + 1, Items[0].Quality);
    }

    [Fact]
    // The `Quality` of an item is never more than `50`
    public void UpdateQuality_MaxQualityItem_QualityRemainsAtFifty()
    {
        // Given
        var quality = 50;
        IList<Item> Items = new List<Item> { Createitem("Aged Brie", 10, quality) };
        GildedRose app = new GildedRose(Items);
        
        // When
        app.UpdateQuality();
        
        // Then
        Assert.Equal(quality, Items[0].Quality);
    }

    [Fact]
    // __"Sulfuras"__, being a legendary item, never has to be sold or decreases in `Quality`
    public void UpdateQuality_LegendaryItem_QualityAndSellInRemainTheSame()
    {
        // Given
        var sellIn = 10;
        var quality = 5;
        IList<Item> Items = new List<Item> { Createitem("Sulfuras, Hand of Ragnaros", sellIn, quality) };
        GildedRose app = new GildedRose(Items);
        
        // When
        app.UpdateQuality();
        
        // Then
        Assert.Equal(quality, Items[0].Quality);
        Assert.Equal(sellIn, Items[0].SellIn);
    }

    [Theory]
    /* 
    __"Backstage passes"__, like aged brie, increases in `Quality` as its `SellIn` value approaches;
	- `Quality` increases by `2` when there are `10` days or less and by `3` when there are `5` days or less but
	- `Quality` drops to `0` after the concert
    */
    [InlineData(1,20, 2)]
    [InlineData(1,10, 3)]
    [InlineData(1,5,4)]
    [InlineData(1,0,0)]
    public void UpdateQuality_BackstagePasses_QualityIncreasesAccordingToRules(int quality, int sellIn, int expectedQuality)
    {
        // Given
        IList<Item> Items = new List<Item> { Createitem("Backstage passes to a TAFKAL80ETC concert", sellIn, quality) };
        GildedRose app = new GildedRose(Items);
        
        // When
        app.UpdateQuality();
        
        // Then
        Assert.Equal(expectedQuality, Items[0].Quality);
    }
    private static Item Createitem(string name, int sellIn, int quality)
    {
        return new Item { Name = name, SellIn = sellIn, Quality = quality };
    }
}