using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages =>(int) Math.Ceiling((double) TotalNumBooks / BooksPerPage); //casting double data type into and integer so code doesnt break and rounding it the the biggest whole number
    }
}
