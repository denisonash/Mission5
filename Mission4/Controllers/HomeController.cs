using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private NewMovieContext movieContext { get; set; }

        public HomeController(NewMovieContext newMovie)
        {
            movieContext = newMovie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMovieForm(NewMovie mov)
        {
            if (ModelState.IsValid)
            {
                // Add changes to database
                movieContext.Add(mov);
                // Save Changes to database
                movieContext.SaveChanges();
                return View("Confirmation", mov);
            }
            else
            {
                return View(mov);
            }
            
        }

    }
}
