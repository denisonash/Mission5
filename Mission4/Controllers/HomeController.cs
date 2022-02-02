using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = movieContext.Categories.ToList();
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
                ViewBag.Categories = movieContext.Categories.ToList();

                return View(mov);
            }
            
        }

        public IActionResult MovieList()
        {
            // Get all the movies. I decided to organize them by Category
            var movies = movieContext.movies
                .Include(m => m.Category)
                .OrderBy(m => m.Category)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movie = movieContext.movies.Single(x => x.MovieID == movieid);

            // Sends to new movie form with the data that already exists for that movie.
            return View("NewMovieForm", movie);
        }

        [HttpPost]
        public IActionResult Edit(NewMovie info)
        {
            movieContext.Update(info);
            movieContext.SaveChanges();

            // Got back to movie list after update
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = movieContext.movies.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(NewMovie info)
        {
            movieContext.movies.Remove(info);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
