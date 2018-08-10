using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if(customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                var customerExist = _context.Customers.Single(c => c.Id == customer.Id);

                //vsetky vlastnosti naraz, nemusi byt vraj vzdy ziaduce
                //TryUpdateModel(customerExist);

                //bezpecnejsie
                customerExist.Name = customer.Name;
                customerExist.Birthdate = customer.Birthdate;
                customerExist.MembershipTypeId = customer.MembershipTypeId;
                customerExist.IsSubscriberToNewsletter = customer.IsSubscriberToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {

            //var customers = GetCustomers();

            /*
            var customers = _context.Customers.Include(c => c.MembershipType);
            return View(customers);
            */

            if (User.IsInRole(RoleNames.CanManageMovies))
                return View("Index");

            return View("IndexReadOnly");
        }

        public ActionResult Details(int id)
        {

            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType);
            var customer = customers.SingleOrDefault(c=>c.Id==id);

            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);
        }

        //toto je hard-coded
        private IEnumerable<Customer>  GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=1, Name="John Smith"},
                new Customer{Id=2, Name="Mary Wiliams"}
            };
        }
    }
}