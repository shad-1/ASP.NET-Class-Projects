//Shad Baird
//2/2/2022

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie_DB.Models;
using Movie_DB.Enums;

namespace Movie_DB.Controllers
{
    public class HomeController : Controller
    {
        //bring in the Movies context. This may need to be renamed with multiple db contexts in the future.
        private MoviesContext _context;

        public HomeController(MoviesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Movies()
        {
            //todo: determine if there's a better way than viewbag. ViewModel?
            ///This is to load all of the movies
            List<Movie> movies = _context.Movies
                .Include(mv => mv.Category)
                .ToList();
            ViewBag.Movies = movies;
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.ToList<Category>();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie mv)
        {
            if(ModelState.IsValid)
            {
                //Add the category object for a given categoryID
                if(mv.Category == null)
                    mv.Category = _context.Categories.Single(c => c.CategoryID == mv.CategoryID);

                _context.Add(mv);
                _context.SaveChanges();

                //Redirect to movies view
                return RedirectToAction("Movies");
            }
            //If invalid, return the form.
            else
            {
                ViewBag.Categories = _context.Categories.ToList<Category>();
                return View(mv);
            }
            
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Wrap it in a try-catch block to handle weird errors.
            try
            {
                Movie mv = _context.Movies.Single(m => m.MovieID == id);
                ViewBag.Categories = _context.Categories.ToList<Category>();
                return View("AddMovie", mv);
            }
            catch
            {
                Console.WriteLine("Uhhh...we couldn't find the movie whose ID was submitted. This error should never trigger.");
                return RedirectToAction("Movies");
            }
            
        }
        [HttpPost]
        public IActionResult Edit(Movie mv)
        {
            if(ModelState.IsValid)
            {
                //For some reason, I am getting an ID of 0, every time. This is a lookup on all other properties 
                //Add the category object for a given categoryID
                if (mv.Category == null)
                    mv.Category = _context.Categories.Single(c => c.CategoryID == mv.CategoryID);

                // This is how Professor Hilton did it in the videos. Something weird is going on with duplicating records on update. 
                _context.Update<Movie>(mv);
                _context.SaveChanges();

                return RedirectToAction("Movies");
            }
            //If invalid, return the form.
            else
            {
                ViewBag.Categories = _context.Categories.ToList<Category>();
                return View("AddMovie", mv);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Movie mv = _context.Movies.Single(m => m.MovieID == id);
                return View(mv);

            }
            catch
            {
                Console.WriteLine("Something went wrong with fetching the movie. Debug the Delete GET controller.");
                return RedirectToAction("Movies");
            }
            
        }
        [HttpPost]
        public IActionResult Delete(Movie mv)
        {
            _context.Remove(mv);
            _context.SaveChanges();
            return RedirectToAction("Movies");
        }
    }
}
