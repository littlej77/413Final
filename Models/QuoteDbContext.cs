using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413Final.Models
{
    public class QuoteDbContext : DbContext 
    {
        public QuoteDbContext (DbContextOptions<QuoteDbContext> options) : base(options)
        {

        }

        public DbSet<Quote> Quotes { get; set; }

        ////seed the database
        //protected override void OnModelCreating(ModelBuilder mb)
        //{
        //    _ = mb.Entity<Quote>().HasData(

        //        new Quote
        //        {
        //            QuoteID = 1,
        //            QuoteText = "No one can make you feel inferior without your consent.",
        //            Author = "Eleanor Roosevelt",
        //            Date = 06 / 01 / 1941 12:00:00 AM,

        //        },
        
    }
}
