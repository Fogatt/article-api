using System;
using FluentValidator;
using Article.Shared.Commands;

namespace Article.Domain.StoreContext.Commands.ArticleCommands.Inputs
{
    public class DeleteCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public bool Validation()
        {
            //check if guid is valid
            return true;
        }
    }
}