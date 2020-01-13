using Microsoft.VisualStudio.TestTools.UnitTesting;
using Article.Domain.StoreContext.Entities;
using Article.Domain.StoreContext.ValueObjects;

namespace Article.Tests
{
    
    // Working with: The Red/Green/Refactor cycle.
    // * Create a unit tests that fails
    // * Write production code that makes that test pass.
    // * Clean up the mess you just made. (refatory)
    
    //[TestClass]
    public class UnitTestSample
    {
        // * First -> create a unit test that fails like the example bellow:
        //[TestMethod]
        public void Sample1()
        {
            Assert.Fail();
        }

        // * Second -> Write production code that makes that test pass.
        //[TestMethod]
        public void ShouldReturnNotificationWhenCarIsNotValid()
        {
            var vehicle = "motorcicle";
            var isCar =  vehicle == "car" ? true : false;
            Assert.IsFalse(isCar);
        }

         // * Third -> Clean up the mess you just made.
         // That means, delete the method Sample1 or Write some good stuff in there (refatory)


        // Again, many people have written about this cycle. Indeed the idea derives from Kent Beck’s original injunction:
        // Make it work. Make it right. Make it fast.
        // Another way to think about this idea is:
        //  Getting software to work is only half of the job.


        //[TestMethod]
        public void TestMethod1()
        {
            
            //customer's needs
            var name = new Name("Lucas", "Marinho");
            var document = new Document("12344567890");
            var email = new Email("lucasmarinho@email.com");

            var customer = new Customer(name,document,email,"73837337");

            //Products that someone will buy
            var mouse = new Product("Mouse", "Item of the computer department", "image.png", 59.90M, 10);
            var keyboard = new Product("Keyboard", "Item of the computer department", "image.png", 89.90M, 10);
            var printer = new Product("Printer", "Item of the computer department", "image.png", 459.90M, 10);
            var memoryCardSlot = new Product("Memory Card Slot", "Item of the computer department", "image.png", 259.90M, 10);
            var HdSata = new Product("HD SATA", "Item of the computer department", "image.png", 599.90M, 10);
            var ComputerScreen = new Product("Computer Screen", "Item of the computer department", "image.png", 359.90M, 10);
            var MotherBoard = new Product("Mother Board", "Item of the computer department", "image.png", 959.90M, 10);

            var order = new Order(customer);

            // order.AddItem(new OrderItem(mouse,2));
            // order.AddItem(new OrderItem(keyboard,2));
            // order.AddItem(new OrderItem(printer,2));
            // order.AddItem(new OrderItem(memoryCardSlot,2));
            // order.AddItem(new OrderItem(HdSata,2));
            // order.AddItem(new OrderItem(ComputerScreen,2));
            // order.AddItem(new OrderItem(MotherBoard,2));

            //create an order
            order.Place();

            //Check if the order is valid
            var valid = order.Valid;

            //payment (simulate)
            order.Pay();

            //shipping (simulate)
            order.Ship();

            //cancel (simulate)
            order.Cancel();

        }
    }
}
