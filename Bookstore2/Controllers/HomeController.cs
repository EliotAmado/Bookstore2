using Bookstore2.Models;
using Bookstore2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Controllers
{
    public class HomeController : Controller //controller is using the repository
    {
        private IBookStoreRepository repo;

        public HomeController (IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)  //results on a page we will display
        {
            int PageSize = 5;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * PageSize)
                .Take(PageSize), //how many results you want on your age

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = PageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);

        }
    }
}
