using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413Final.Models
{
    public interface IQuotesRepository 
    {
        IQueryable<Quote> Quotes { get; }

        public void SaveQuote(Quote qt);
        public void AddQuote(Quote qt);
        public void DeleteQuote(Quote qt);
        public void EditQuote(Quote qt);

    }
}
