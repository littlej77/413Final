using _413Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _413Final.Controllers
{
    public class HomeController : Controller
    {
        private IQuotesRepository _repo { get; set; }
        public HomeController(IQuotesRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var blah = _repo.Quotes
                .OrderBy(x => x.Author)
                .ToList();

            return View(blah);
        }

        //this is my extra credit portion. It calls a random QuoteID from 1 to the max number of quotes (so it changes as quotes get entered in)
        public IActionResult Random()
        {
            Random rnd = new Random();
            int rando = rnd.Next(1, _repo.Quotes.Max(x => x.QuoteID));

            var entry = _repo.Quotes.Single(x => x.QuoteID == rando);
            return View("Details", entry);
        }

        public IActionResult Details(int quoteid)
        {
            var entry = _repo.Quotes.Single(x => x.QuoteID == quoteid);
            return View("Details", entry);
        }

        [HttpGet]
        public IActionResult Edit(int quoteid)
        {
            var entry = _repo.Quotes.Single(x => x.QuoteID == quoteid);


            return View("Edit", entry);

        }

        [HttpPost]
        public IActionResult Edit(Quote qt)
        {
            _repo.EditQuote(qt);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Add()
        {
            Quote qt = new Quote();

            ViewBag.Quotes = _repo.Quotes.ToList();
            return View("Edit", qt);
        }

        [HttpPost]
        public IActionResult Add(Quote qt)
        {
            if (ModelState.IsValid)
            {
                qt.QuoteID = _repo.Quotes.Max(x => x.QuoteID) + 1;
                _repo.AddQuote(qt);

                return RedirectToAction("Index");
            }
            else // if invalid then send them back to the view with the info they had put in
            {
                ViewBag.Quotes = _repo.Quotes.ToList();

                return View("Edit");
            }
        }
        public IActionResult Delete(Quote qt)
        {
            _repo.DeleteQuote(qt);

            return RedirectToAction("Index");
        }

    }
}
