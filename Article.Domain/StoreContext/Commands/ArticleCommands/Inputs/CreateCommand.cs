using FluentValidator;
using FluentValidator.Validation;
using Article.Shared.Commands;
using System;

namespace Article.Domain.StoreContext.Commands.ArticleCommands.Inputs
{
    public class CreateCommand : Notifiable, ICommand
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