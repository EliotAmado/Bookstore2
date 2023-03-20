using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models //this is doing what we used to do in the controller
{
    public class EFBookstoreRepository : IDonationRepository   //like inhereting from this file
    {
        private BookstoreContext context { get; set; }
        public EFBookstoreRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Donation> Donations => context.Donations.Include(x => x.Lines);

        public void SaveDonation(Donation donation)
        {
            throw new NotImplementedException();
        }
    }
}
//He ends the video with the error so i guess im on 6