using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                if (item.Quality > 0 && item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality--;

                }
                else if (item.Quality < 50)
                {
                    item.Quality++;


                }

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Quality < 50)
                {

                    if (item.SellIn < 11)
                    {
                        item.Quality++;
                    }

                    if (item.SellIn < 6)
                    {
                        item.Quality++;
                    }

                    if (item.SellIn < 0)
                    {
                    }

                }

                item.SellIn--;

                if (item.Name == "Aged Brie" && item.SellIn < 0)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                    continue;
                }

                if ((item.SellIn < 0 && item.Name == "Backstage passes to a TAFKAL80ETC concert") || item.Quality <= 0)
                {
                    item.Quality = 0;
                }
                else
                {

                    item.Quality--;
                }


            }
        }
    }
}
