using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieModelDbContext context1 { get; set; }

        //Constructor that makes Database context avaliable for every View
        public HomeController(ILogger<HomeController> logger, MovieModelDbContext context)
        {
            _logger = logger;
            context1 = context;
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
        public IActionResult MovieInput()
        {
            return View();
        }

        //On Post, adds Movie to Database if inputs are valid, redirects to show Movies in database

        [HttpPost]
        public IActionResult MovieInput(MovieModel m)
        {
            if(ModelState.IsValid)
            {
                context1.movies.Add(m);
                context1.SaveChanges();

                return View("MovieList", context1.movies);
            }

            return View();
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            return View(context1.movies);
        }

        //On Post, connected to Remove button, takes the Movie selected and deletes it from database

        [HttpPost]
        public IActionResult MovieList(int Id)
        {
            var record = context1.movies.Where(x => x.Id == Id).FirstOrDefault();

            if (record != null)
            {
                context1.movies.Remove(record);
                context1.SaveChanges();
            }

            return View(context1.movies);
        }

        //View for Edit movie button, populates with info passed from model to model

        [HttpGet]
        public IActionResult EditMovie(int Id)
        {
            var record = context1.movies.Where(x => x.Id == Id).FirstOrDefault();

            return View(record);
        }

        //On Post, finds the movie that is being edited and replaces it with entered information

        [HttpPost]
        public IActionResult EditMovie(int Id, MovieModel m)
        {
            var record = context1.movies.Where(x => x.Id == Id).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (record != null)
                {
                    context1.movies.Remove(record);
                    context1.SaveChanges();
                }


                context1.movies.Add(m);
                context1.SaveChanges();

                return View("MovieList", context1.movies);
            }

            return View("EditMovie", record);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
