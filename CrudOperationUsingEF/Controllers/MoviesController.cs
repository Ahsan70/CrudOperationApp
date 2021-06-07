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
    public class MoviesController : Controller
    {
        private ApplicationDbContext _dbContext;
        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movies = _dbContext.Movies.Include(x => x.Genre).ToList();
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies.Include(x => x.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

           
            return View(movie);

        }
    }
}