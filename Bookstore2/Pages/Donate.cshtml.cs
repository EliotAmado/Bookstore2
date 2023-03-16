using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore2.Infrastructure;
using Bookstore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore2.Pages
{
    public class DonateModel : PageModel
    {
        private IBookStoreRepository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; } //sets variable ReturnUrl

        public DonateModel (IBookStoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";  //Sets Variable ReturnUrl to something
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            //we will load up our data 
            Book p = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(p, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });


        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book); //to remove we will search for item and pass it to the remove item method which will remove it and update our session with the new information without the item in the basket.
            return RedirectToPage(new {ReturnUrl = returnUrl}); //set the return url to the returned url that was passed in
        }

    }
}
