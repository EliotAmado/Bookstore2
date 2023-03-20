using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models
{
    public interface IDonationRepository
    {
        IQueryable<Donation> Donations { get; }
        void SaveDonation(Donation donation);
    }
}

//Im halfway through the last set of assignment 11 videos so its not complete lol