using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerTracking.Models;
using CustomerTracking.ViewModel;


namespace CustomerTracking.Controllers
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

            public ViewResult Index()
            {
                var customers = _context.Customers.ToList();

                return View(customers);
            }

            public ActionResult Details(int id)
            {
                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customer == null)
                    return HttpNotFound();

                return View(customer);
            }
            public ActionResult New()
            {
                var customers = _context.Customers.ToList();
                var viewModel = new CustomerFormViewModel
                {
                    Customers = customers
                };
                return View("CustomerForm", viewModel);
            }
            [HttpPost]
            public ActionResult Save(Customer customer)
            {
                if (customer.Id == 0)
                    _context.Customers.Add(customer);
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                    customerInDb.Name = customer.Name;
                    customerInDb.Email = customer.Email;
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
                };

                return View("CustomerForm", viewModel);
            }
            [HttpPost]
            public ActionResult Delete(Customer customer)
            {

                //Customer customer = _context.Customers.Find(id);
                var customerInDb = _context.Customers.Find(customer.Id);

                _context.Customers.Remove(customerInDb);


                _context.SaveChanges();

                return RedirectToAction("Index", "Customers");

            }

            public ActionResult DeletePage(int id)
            {
                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);


                var viewModel = new CustomerDeleteModel
                {
                    Customer = customer,
                };

                return View("CustomerDelete", viewModel);

            }
        }
}