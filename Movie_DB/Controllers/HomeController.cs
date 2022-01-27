//Shad Baird
//1/26/2022

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie_DB.Models;

namespace Movie_DB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //bring in the Movies context. This may need to be renamed with multiple db contexts in the future.
        private MoviesContext _context;

        public HomeController(ILogger<HomeController> logger, MoviesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Movies()
        {
            List<Movie> movies = _context.Movies.ToList();
            ViewBag.Movies = movies;
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie mv)
        {
            _context.Add(mv);
            _context.SaveChanges();
            // An attempt to redirect to the Movies page, but it might not be so.
            //This list is expected in the viewbag.
            List<Movie> movies = _context.Movies.ToList();
            ViewBag.Movies = movies;
            return View("Movies");
        }

        public IActionResult Podcast()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
