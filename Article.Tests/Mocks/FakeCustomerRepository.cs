using System;
using System.Collections.Generic;
using Article.Domain.StoreContext.Queries;
using Article.Domain.StoreContext.Repositories;

namespace Article.Tests
{
    public class FakeCustomerRepository : IArticleRepository
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public ArticleQueryResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.StoreContext.Entities.Article article)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.StoreContext.Entities.Article article)
        {
            throw new NotImplementedException();
        }
    }
}
