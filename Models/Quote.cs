using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _413Final.Models
{
    public class Quote
    {
        //Quote, Author, and then optionally a Date, Subject and a Citation.
        [Key]
        [Required]
        public int QuoteID { get; set; }
        [Required]
        public string QuoteText { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Citation { get; set; }
    }
}
