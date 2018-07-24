using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customers>
            {
                new Customers {Name="Customer 1"},
                new Customers {Name="Customer 2"}
            };

            //string je pevny, lepsie ViewBag
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;


            var viewModel = new RandomMovieViewModel
            {
                Movie=movie,
                Customers=customers
            };

            return View(viewModel);

            //vraj najlepsie, ani ViewData, ani ViewBag
            //return View(movie);

            //takto alebo cez ViewData
            //return View(movie);
            

            // rozne typy ActionResult
            //return Content("Hi everyone!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrEmpty(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));
        }

        //pre dva roky to nie je tak jednoduche cez regex :)
        //[Route("movies/released/{year:regex(2015|2106)}/{month:regex(\\{d2})}")]
        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}