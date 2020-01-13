using System;

namespace Article.Domain.StoreContext.Queries
{
    public class ArticleQueryResult
    {
        public string Title { get; set; }
        public DateTime PublishedData { get; set; }
        public string Site { get; set; }
        public string AdGroup { get; set; }
        public decimal Bids { get; set; }
        public decimal Spending { get; set; }
        public decimal WinRate { get; set; }
        public decimal Impressions { get; set; }
        public int Clicks { get; set; }
        public decimal CTR { get; set; }

    }
}