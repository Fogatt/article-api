
using Dapper;
using Article.Domain.StoreContext.Entities;
using Article.Domain.StoreContext.Queries;
using Article.Domain.StoreContext.Repositories;
using Article.Infra.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Article.Infra.StoreContext.Repositories
{
    public class ArticleRepository : IArticleRepository
    {

        private readonly StoreDataContext _context;

        public ArticleRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ArticleQueryResult> Get()
        {
            return _context
                .Connection
                .Query<ArticleQueryResult>(
                    "SELECT [Id],[Title],[CreateDate],[PublishedData],[Site],[AdGroup],[Bids],[Spending],[WinRate],[Impressions],[Clicks],[CTR] FROM [dbo].[Articles]", new { }
                    );
        }

        public ArticleQueryResult Get(Guid id)
        {
            return _context
                  .Connection
                  .Query<ArticleQueryResult>(
                      "SELECT [Id],[Title],[CreateDate],[PublishedData],[Site],[AdGroup],[Bids],[Spending],[WinRate],[Impressions],[Clicks],[CTR] FROM [dbo].[Articles] where id =@id", new { id = id }
                      ).FirstOrDefault();
        }

        public void Save(Article.Domain.StoreContext.Entities.Article article)
        {
            var sqlCommand = $"INSERT INTO [Articles] ([Id],[Title],[CreateDate],[PublishedData],[Site],[AdGroup],[Bids],[Spending],[WinRate],[Impressions],[Clicks],[CTR]) VALUES ('{article.Id}', '{article.Title}', '{DateTime.Now}', '{article.PublishedData}', '{article.Site}', '{article.AdGroup}', {article.Bids}, {article.Spending}, {article.WinRate}, {article.Impressions}, {article.Clicks}, {article.CTR})";
            _context.Connection.Execute(sqlCommand);
        }

        public void Update(Article.Domain.StoreContext.Entities.Article article)
        {
            _context.Connection.Execute("");
        }

        public void Delete(Guid id)
        {
            _context.Connection.Execute("");
        }
    }

}