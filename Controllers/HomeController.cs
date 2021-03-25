using FilmCollection_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection_v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public FilmDBContext _context; //context instance accessible from anywhere in controller

        public HomeController(ILogger<HomeController> logger, FilmDBContext filmDBContext)
        {
            _logger = logger;
            _context = filmDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Podcasts()
        {
            return View();
        }

        //Viewing Film Collection page
        public IActionResult Collection()
        {
            return View(_context.Films.OrderBy(f => f.FilmID));
        }

        [HttpGet]
        public IActionResult AddFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFilm(Film newFilm)
        {
            //check if the submitted values for the model attributes are within the given restraints
            if (ModelState.IsValid)//model is valid, add it to DB
            {
                _context.Add(newFilm);
                _context.SaveChanges();

                return RedirectToAction("Collection");
            }
            else //model is not valid, return to add page to notify user using validation summary
            {
                return View(newFilm);
            }
            
        }

        [HttpGet]
        public IActionResult EditFilm(int filmID)
        {
            //return the film found in the DB using the filmID that was passed in
            return View(_context.Films.Where(f => f.FilmID == filmID).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult EditFilm(Film filmToUpdate)
        {
            //check if the submitted values for the model attributes are within the given restraints
            if (ModelState.IsValid) //model is valid, update DB
            {
                _context.Films.Update(filmToUpdate);
                _context.SaveChanges();

                return RedirectToAction("Collection");
            }
            else//model is not valid, return to add page to notify user using validation summary
            {
                return View(filmToUpdate);
            }
        }

        public IActionResult DeleteFilm(int filmID)
        {
            //remove the film from the DB using the filmID that was passed in
            _context.Films.Remove(_context.Films.Where(f => f.FilmID == filmID).FirstOrDefault());
            _context.SaveChanges();

            return RedirectToAction("Collection");
        }

        //error page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
