using System;
using Article.Shared.Entities;

namespace Article.Domain.StoreContext.Entities
{

    public class Article : Entity
    {
        public Article(string title, DateTime publishedData, string site, string adGroup, decimal bids, decimal spending, decimal winRate, decimal impressions, int clicks, decimal cTR)
        {
            Title = title;
            PublishedData = publishedData;
            Site = site;
            AdGroup = adGroup;
            Bids = bids;
            Spending = spending;
            WinRate = winRate;
            Impressions = impressions;
            Clicks = clicks;
            CTR = cTR;
        }

        public string Title { get; private set; }
        public DateTime PublishedData { get; private set; }
        public string Site { get; private set; }
        public string AdGroup { get; private set; }
        public decimal Bids { get; private set; }
        public decimal Spending { get; private set; }
        public decimal WinRate { get; private set; }
        public decimal Impressions { get; private set; }
        public int Clicks { get; private set; }
        public decimal CTR { get; private set; }

        public override string ToString()
        {
            return Title;
        }

    }

}