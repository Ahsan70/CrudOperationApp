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
          
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = GetMembershipTypes()

            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel=new CustomerFormViewModel
                {
                    Customer=customer,
                    MembershipTypes= GetMembershipTypes()
                };
                return View("CustomerForm",viewModel);
            }
            if(customer.Id==0)
            _dbContext.Customers.Add(customer);
            else
            {
                var customerIndb = _dbContext.Customers.Single(x => x.Id == customer.Id);
                customerIndb.Name = customer.Name;
                customerIndb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerIndb.BirthDate = customer.BirthDate;
                customerIndb.MembershipTypeId = customer.MembershipTypeId;

            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(x=> x.Id==id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = GetMembershipTypes()
            };
            return View("CustomerForm",viewModel);
        }
        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(x=>x.MembershipType).SingleOrDefault(c => c.Id == id);
            if(customer==null)
                return HttpNotFound();
            
            return View(customer);
        }
        public IEnumerable<MembershipType>GetMembershipTypes()
        {
          return  _dbContext.MembershipTypes.ToList();
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