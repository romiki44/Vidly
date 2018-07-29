﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>
            {
                new Customer{Id=1, Name="John Smith"},
                new Customer{Id=2, Name="Mary Wiliams"}
            };

        // GET: Customers
        public ActionResult Index()
        {
            
            return View(customers);
        }

        public ActionResult Details(int id)
        {

            var customer = customers.Single(c=>c.Id==id);

            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);
        }
    }
}