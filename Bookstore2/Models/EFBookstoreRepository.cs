using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models //this is doing what we used to do in the controller
{
    public class EFBookstoreRepository : IBookStoreRepository   //like inhereting from this file
    {
        private BookstoreContext context { get; set; }
        public EFBookstoreRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
