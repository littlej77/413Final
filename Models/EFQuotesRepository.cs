using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413Final.Models
{
    public class EFQuotesRepository : IQuotesRepository
    {
        private QuoteDbContext _context { get; set; }

        public EFQuotesRepository (QuoteDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Quote> Quotes => _context.Quotes;

        public void SaveQuote(Quote qt)
        {
            _context.SaveChanges();
        }

        public void AddQuote(Quote qt)
        {
            _context.Add(qt);
            _context.SaveChanges();
        }

        public void EditQuote(Quote qt)
        {
            _context.Update(qt);
            _context.SaveChanges();
        }
        public void DeleteQuote(Quote qt)
        {
            _context.Remove(qt);
            _context.SaveChanges();
        }
    }
}
