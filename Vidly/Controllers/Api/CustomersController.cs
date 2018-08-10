using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/customers
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!string.IsNullOrEmpty(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos=customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>( customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            //return customerDto;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
        }

        //PUT /api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerToEdit = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToEdit == null)
                return BadRequest();


            Mapper.Map(customerDto, customerToEdit);

            /* netreba, update cez Mapper
            customerToEdit.Name = customerDto.Name;
            customerToEdit.Birthdate = customerDto.Birthdate;
            customerToEdit.IsSubscriberToNewsletter = customerDto.IsSubscriberToNewsletter;
            customerToEdit.MembershipTypeId = customerDto.MembershipTypeId;
            */
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerToDelete = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToDelete == null)
                NotFound();

            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();

            return Ok();
        }


    }
}
