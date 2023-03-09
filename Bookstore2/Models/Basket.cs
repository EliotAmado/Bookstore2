using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models
{
    public class Basket
        //functionality to add item to list of basket line items.
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>(); //first class declares second class instastiates

        public void AddItem (Book proj, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Book.BookId == proj.BookId)
                .FirstOrDefault();

            if(line == null)
            {
                Items.Add(new BasketLineItem
                    {
                        Book = proj,
                        Quantity = qty
                    });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);
            return sum;
        }

    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
