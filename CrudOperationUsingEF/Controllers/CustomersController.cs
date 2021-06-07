using CrudOperationUsingEF.Models;
using CrudOperationUsingEF.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperationUsingEF.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _dbContext;
        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            var customer = _dbContext.Customers.Include(c=>c.MembershipType).ToList();
            return View(customer);
        }
        public ActionResult New()
        {
            var membershipTypes = _dbContext.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes

            };
            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(x=>x.MembershipType).SingleOrDefault(c => c.Id == id);
            if(customer==null)
                return HttpNotFound();
            
            return View(customer);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {new  Customer{Id=1,Name="John" },
            new Customer{Id=2,Name="Tim" }
            };
        }
    }
}