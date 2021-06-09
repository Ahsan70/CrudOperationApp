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
        public ActionResult Index()
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

        public ActionResult New()
        {
            var viewModel = new MovieFromViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.ReleaseDate = DateTime.Now.AddDays(23);
                movie.DateAdded = DateTime.Now;
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var movieIndb = _dbContext.Movies.Single(x => x.Id == movie.Id);
                movieIndb.Name = movie.Name;
                movieIndb.GenreId = movie.GenreId;
                
                movieIndb.NumberInStock = movie.NumberInStock;

            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}