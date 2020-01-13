using System;
using System.Collections.Generic;
using Article.Domain.StoreContext.Queries;

namespace Article.Domain.StoreContext.Repositories
{
    public interface IArticleRepository
    {
        void Save(Article.Domain.StoreContext.Entities.Article article);
        void Update(Article.Domain.StoreContext.Entities.Article article);
        void Delete(Guid id);

        IEnumerable<ArticleQueryResult> Get();

        ArticleQueryResult Get(Guid id);

    }
}