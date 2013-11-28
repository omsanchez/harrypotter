using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HarryPotter.Domain.Tests
{

    [TestFixture]
    public class OrderTests
    {
        private Order _order;

        [Test]
        public void New_CreateInstanceWith2Books_Create2Items()
        { 
            IList<Book> books = new List<Book>();
            books.Add(new Book() { Id = 1 });
            books.Add(new Book() { Id = 2 });
            this._order = new Order(books);
            Assert.AreEqual(2, this._order.Items.Count);
            Assert.AreEqual(books[0], this._order.Items[0].Book);
            Assert.AreEqual(books[1], this._order.Items[1].Book);
        }

        [Test]
        public void GetTotal_OneBook_Get8Pesos()
        {
            Book book = new Book() { Price = 8 };
            IList<Book> booksInOrder = new List<Book>();
            booksInOrder.Add(book);
            this._order = new Order(booksInOrder);
            double totalCalculated = this._order.GeTotal();
            Assert.AreEqual(8, totalCalculated);
        }
    }
}
