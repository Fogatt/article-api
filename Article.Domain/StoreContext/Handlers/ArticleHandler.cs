using FluentValidator;
using Article.Domain.StoreContext.Commands.ArticleCommands.Inputs;
using Article.Domain.StoreContext.Commands.ArticleCommands.Outputs;
using Article.Domain.StoreContext.Repositories;
using Article.Shared.Commands;

namespace Article.Domain.StoreContext.Handlers
{
    public class ArticleHandler :
        Notifiable,
        ICommandHandler<CreateCommand>,
        ICommandHandler<UpdateCommand>,
        ICommandHandler<DeleteCommand>
    {
        private readonly IArticleRepository _repository;

        public ArticleHandler(IArticleRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCommand command)
        {
            //Create entities
            var article = new Article.Domain.StoreContext.Entities.Article(
                command.Title,
                command.PublishedData,
                command.Site,
                command.AdGroup,
                command.Bids,
                command.Spending,
                command.WinRate,
                command.Impressions,
                command.Clicks,
                command.CTR
            );

            if (Invalid)
                return new CommandResult(
                    false,
                    "Please, check the inputs bellow:",
                    Notifications
                ); //if invalid don't go ahead with the data to save it on database 

            //Save customer
            _repository.Save(article);

            //return results to screen
            return new CommandResult(
                true,
                "Article has saved successfully",
                null
             );
        }

        public ICommandResult Handle(UpdateCommand command)
        {
            //Create entities
            var article = new Article.Domain.StoreContext.Entities.Article(
                command.Title,
                command.PublishedData,
                command.Site,
                command.AdGroup,
                command.Bids,
                command.Spending,
                command.WinRate,
                command.Impressions,
                command.Clicks,
                command.CTR
            );

            //update id - that is created automatically 
            article.UpdateId(command.Id);

            if (Invalid)
                return new CommandResult(
                    false,
                    "Please, check the inputs bellow:",
                    Notifications
                ); //if invalid don't go ahead with the data to save it on database 

            //Update on the database
            _repository.Update(article);

            //return results to screen
            return new CommandResult(
                true,
                "Article has updated successfully",
                null
             );
        }

        public ICommandResult Handle(DeleteCommand Command)
        {

            if (Invalid)
                return new CommandResult(
                    false,
                    "Please, check the inputs bellow:",
                    Notifications
                ); //if invalid don't go ahead with the data to save it on database 

            //Delete customer
            _repository.Delete(Command.Id);

            //return results to screen
            return new CommandResult(
                true,
                "Article has deleted successfully",
                null
             );
        }
    }
}