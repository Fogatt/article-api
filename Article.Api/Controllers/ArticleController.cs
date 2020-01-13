
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Article.Domain.StoreContext.Commands.ArticleCommands.Outputs;
using Article.Domain.StoreContext.Handlers;
using Article.Domain.StoreContext.Repositories;
using Article.Shared.Commands;
using Article.Domain.StoreContext.Commands.ArticleCommands.Inputs;
using Article.Domain.StoreContext.Queries;

namespace Article.Api.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _repository;
        private readonly ArticleHandler _handler;
        public ArticleController(IArticleRepository repository, ArticleHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet] //select
        [Route("v1/articles")]
        public IEnumerable<ArticleQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/articles/{id}")]
        public ArticleQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpPost] //insert
        [Route("v1/articles")]
        public ICommandResult Post([FromBody]CreateCommand command)
        {
            var result = (CommandResult)_handler.Handle(command);
            return result;
        }
    }
}