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
        private readonly ILogger<HomeController> _logger;

        private NewMovieContext movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, NewMovieContext newMovie)
        {
            _logger = logger;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
