using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set; } //coming out of repository
        public PageInfo PageInfo { get; set; }

    }
}
