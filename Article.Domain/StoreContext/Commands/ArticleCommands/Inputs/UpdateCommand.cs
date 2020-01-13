using System;
using FluentValidator;
using FluentValidator.Validation;
using Article.Shared.Commands;

namespace Article.Domain.StoreContext.Commands.ArticleCommands.Inputs
{
    public class UpdateCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
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

        //Validation the inputs commands came from front-end application
        public bool Validation()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(Title, 3, "Title", "Title must have at least three characters.")
                .HasMaxLen(Title, 400, "Title", "Tile must have at most four hundred characters.")
            );

            return Valid;
        }
    }
}
