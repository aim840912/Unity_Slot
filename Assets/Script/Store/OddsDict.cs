using System.Collections.Generic;
public class OddsDict
{
    public static readonly Dictionary<Odds, int> dicNormal = new Dictionary<Odds, int>()
    {
        { Odds.gura, 300 },
        { Odds.ame, 200 },
        { Odds.anySeven, 50 },
        { Odds.ina, 100 },
        { Odds.kronii, 50 },
        { Odds.mumei, 30 },
        { Odds.anyBar, 10 },
        { Odds.sana, 20 },
        { Odds.bae, 18 },
        { Odds.fauna, 16 },
        { Odds.irys, 14 },
        { Odds.hololive, 10 },
    };

    public static readonly Dictionary<Odds, int> dictOverall = new Dictionary<Odds, int>
    {
        { Odds.gura, 700 },
        { Odds.ame, 500 },
        { Odds.anySeven, 200 },
        { Odds.ina, 200 },
        { Odds.kronii, 100 },
        { Odds.mumei, 80 },
        { Odds.anyBar, 40 },
        { Odds.sana, 80 },
        { Odds.bae, 70 },
        { Odds.fauna, 60 },
        { Odds.irys, 50 },
        { Odds.hololive, 40 },
        { Odds.anyFruit, 15 }
    };
    public static readonly Dictionary<Odds, Dictionary<int, int>> dictSpecial = new Dictionary<Odds, Dictionary<int, int>>()
    {
        {
            Odds.gura,
            new Dictionary<int, int>()
            {
                { 8, 200 },
                { 7, 140 },
                { 6, 70 },
                { 5, 30 },
                { 4, 12 },
                { 3, 6 },
                { 2, 3 },
            }
        },
        {
            Odds.ame,
            new Dictionary<int, int>()
            {
                { 8, 150 },
                { 7, 100 },
                { 6, 50 },
                { 5, 20 },
                { 4, 8 },
                { 3, 4 },
                { 2, 2 },
            }
        },
        {
            Odds.anySeven,
            new Dictionary<int, int>()
            {
                { 8, 60 },
                { 7, 40 },
                { 6, 20 },
                { 5, 10 },
                { 4, 5 },
                { 3, 2 },
                { 2, 1 },
            }
        }
    };
}
