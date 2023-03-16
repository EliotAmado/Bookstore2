using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore2.Models;

namespace Bookstore2.Controllers
{
    public class DonationController : Controller
    {
        public DonationController()
        {

        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Donation());
        }
        [HttpPost]
        public IActionResult Checkout(Donation donation)
        {

        }
    }
}
