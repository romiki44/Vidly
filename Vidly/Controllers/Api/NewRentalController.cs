using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            // (!ModelState.IsValid)
              //return BadRequest("Request is not valid");

            if (newRental.MoviesIds.Count == 0)
                return BadRequest("Zero movies request");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Invalid customer Id");

            var movies = _context.Movies.Where(m => newRental.MoviesIds.Contains(m.Id)).ToList();
            if (movies == null)
                return BadRequest("No valid movie Id request");

            if (movies.Count != newRental.MoviesIds.Count)
                return BadRequest("One or more movies Id are invalid");


            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest(string.Format("Movie with Id={0} is not available", movie.Id));

                Rental rental = new Rental
                {
                    //CustomerId = newRental.CustomerId,
                    //MovieId = movie.Id,
                    Customer = customer,
                    Movie=movie,
                    DateRented = DateTime.Now
                };


                _context.Rentals.Add(rental);
                movie.NumberAvailable--;
                    
            }
            _context.SaveChanges();

            //int customerId = newRental.CustomerId;
            //return Created(new Uri(Request.RequestUri + "/" + customerId), newRental);
            return Ok();
        }

        public IHttpActionResult GetCustomerRental(int id)
        {
            var allCustomerRentals = _context.Rentals.Where(r => r.CustomerId == id).ToList();
            if (allCustomerRentals == null)
                return NotFound();

            NewRentalDto rentalDto = new NewRentalDto();
            rentalDto.CustomerId = id;
            rentalDto.MoviesIds = new List<int>();

            foreach(Rental rental in allCustomerRentals)
            {
                rentalDto.MoviesIds.Add(rental.MovieId);
            }

            return (Ok(rentalDto));
        }
    }
}

