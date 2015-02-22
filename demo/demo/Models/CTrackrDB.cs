using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace demo.Models
{
    public class CTrackrDB : DbContext
    {
        public DbSet<cigar> Cigars { get; set; }
        public DbSet<cigarReview> CigarReviews { get; set; }
    }
}