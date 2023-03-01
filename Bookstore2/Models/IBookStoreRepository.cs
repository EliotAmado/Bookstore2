using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models
{
    public interface IBookStoreRepository //interface means layout/template for a class
    {
        IQueryable<Book> Books { get; }
    }
}
