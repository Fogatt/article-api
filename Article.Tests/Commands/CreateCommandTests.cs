using Microsoft.VisualStudio.TestTools.UnitTesting;
using Article.Domain.StoreContext.Commands.ArticleCommands.Inputs;
using System;

namespace Article.Tests
{
    [TestClass]
    public class CreateCommandTests
    {
        //When order is created, status should be "created"
        [TestMethod]
        public void ShouldValidateWhenComandIsValid()
        {
            var command = new CreateCommand();
            command.Title = "test";
            command.PublishedData = DateTime.Now;

            Assert.AreEqual(true, command.Validation());
        }

    }
}
