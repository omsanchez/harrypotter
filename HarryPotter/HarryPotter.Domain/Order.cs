using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HarryPotter.Domain
{
    public class Order
    {
        public string ClientEmail { get; set; }
        public IList<OrderItem> Items { get; set; }

        public Order()
        {
            this.Items = new List<OrderItem>();
        }

        public Order(IList<Book> books)
        {
            this.Items = new List<OrderItem>();
            foreach (Book book in books)
                this.AddBook(book, 0);
        }

        public double GeTotal()
        {
            double total = 0;
            foreach (OrderItem item in this.Items)
                total += item.Book.Price * item.Quantity;
            return total;
        }

        public OrderItem AddBook(Book book01, int quantity)
        {
            OrderItem item = new OrderItem(book01);
            item.Quantity = quantity;
            this.Items.Add(item);
            return item;
        }
    }
}
