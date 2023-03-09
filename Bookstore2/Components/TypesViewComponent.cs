using Bookstore2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookStoreRepository Repo { get; set; }

        public TypesViewComponent (IBookStoreRepository temp)
        {
            Repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData.Values["bookType"];

            var types = Repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
