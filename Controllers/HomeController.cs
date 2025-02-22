using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollectionApp.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieCollectionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieDbContext _context;

        // Inject the DbContext in the constructor
        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Joel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Addmovie()
        {
            // Fetch all categories from the DB
            var categories = _context.Categories.ToList();
    
            // Convert them into something the DropDownList understands
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
    
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Addmovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // New Action for Movie List Page
        public IActionResult MovieList()
        {
            var movies = _context.Movies.ToList(); // Fetch all movies
            return View(movies); // Pass to the MovieList.cshtml view
        }

        [HttpGet]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
        // GET: /Home/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Fetch the requested movie from DB
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            // Return the Edit.cshtml view, passing the movie
            return View(movie);
        }

// POST: /Home/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                // Tell EF we're updating this entity
                _context.Movies.Update(updatedMovie);
                _context.SaveChanges();

                // Go back to MovieList after saving
                return RedirectToAction("MovieList");
            }

            // If model validation fails, re-show form
            return View(updatedMovie);
        }
        // GET: /Home/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

// POST: /Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("MovieList");
        }


    }
}