using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models
{
    public class IDonationRepository
    {
        IQueryable<Donation> Donations { get; }
        void SaveDonation(Donation donation);
    }
}
