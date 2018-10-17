using System.Collections.Generic;
using ComputerGeneratedStories.Persistense.Interfaces;

namespace ComputerGeneratedStories.Persistense
{
    public class FakeRepository : IRepository
    {
        /// <summary>
        ///     Get sentences from storage.
        /// </summary>
        /// <remarks> Seems to be very slow on big data clusters </remarks>
        /// <returns> Available sentences </returns>
        public List<string> GetSentences()
        {
            return new List<string>
            {
                @"[Analyst Firm] analyst [Analyst Name] is out today with a bullish research note on [Company], upgrading the stock two notches -- all the way from [Previous Rating] to [Rating] -- with a price target of $[Target] a share, which implies a [% from current price]% upside/downside from current levels.",
                @"[Analyst Firm] analyst [Analyst Name] is singing [Company]'s praises, upgrading the stock from [Previous Rating] to [Rating] with a price target of $[Target]. That implies [Company] shares could rise/fall [% from current price] in 12 months.",
                @"[Analyst Firm] analyst [Analyst Name] released a bullish note on shares of [Company] suggesting that expectations for the company are more reasonable now than earlier in the year. The analyst upgrades the stock to [Rating] from [Previous Rating], with a price target of $[Target], which represents a potential upside/downside of [% from current price]% from its current share price.",
                @"[Analyst Firm] analyst [Analyst Name] just announced a big upgrade on [Company] stock. The reason: From current share price of $[Current price] a share, the analyst believes the stock could rise nearly [% from current price]% over the next 12 months.",
                @"[Company] received a vote of confidence from Wall Street as [Analyst Firm] analyst [Analyst Name] reiterated his [Rating] rating on the company, while also reaffirming his 12 month price target of $[Target] — a [% from current price]% upside/downside from current levels. ",
                @"In a recent note, [Analyst Firm] analyst [Analyst Name] backed the firm’s [Rating] rating for [Company], placing a price target of $[Target] (a [% from current price]% upside/downside potential) for the company’s stock."
            };
        }
    }
}