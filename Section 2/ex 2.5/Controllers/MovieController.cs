using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVDMovie.Models;
using Microsoft.EntityFrameworkCore;
using DVDMovie.Models.BindingTargets;

namespace DVDMovie.Controllers
{
    [Route("api/movies")]
    public class MovieController : Controller
    {
        private DataContext context;
        public MovieController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public Movie GetMovie(long id)
        {
            //System.Threading.Thread.Sleep(5000);
            Movie result = context.Movies
                    .Include(m => m.Studio).ThenInclude(s => s.Movies)
                    .Include(m => m.Ratings)
                    .FirstOrDefault(m => m.MovieId == id);
            if (result != null)
            {
                if (result.Studio != null)
                {
                    result.Studio.Movies = result.Studio.Movies.Select(s =>
                    new Movie
                    {
                        MovieId = s.MovieId,
                        Name = s.Name,
                        Category = s.Category,
                        Description = s.Description,
                        Price = s.Price
                    });
                }
                if (result.Ratings != null)
                {
                    foreach (Rating r in result.Ratings)
                    {
                        r.Movie = null;
                    }
                }
            }
            return result;

        }
  
        [HttpGet]
        public IEnumerable<Movie> GetMovies(string category, string search,
                                            bool related = false)
        {
            IQueryable<Movie> query = context.Movies;
            if (!string.IsNullOrWhiteSpace(category))
            {
                string catLower = category.ToLower();
                query = query.Where(m => m.Category.ToLower().Contains(catLower));
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(m => m.Name.ToLower().Contains(searchLower)
                || m.Description.ToLower().Contains(searchLower));
            }

            if (related)
            {
                query = query.Include(m => m.Studio).Include(m => m.Ratings);
                List<Movie> data = query.ToList();
                data.ForEach(m =>
                {
                    if (m.Studio != null)
                    {
                        m.Studio.Movies = null;
                    }
                    if (m.Ratings != null)
                    {
                        m.Ratings.ForEach(r => r.Movie = null);
                    }
                });
                return data;
            }
            else
            {
                return query;
            }
        }
    [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieData mdata)
        {
            if (ModelState.IsValid)
            {
                Movie m = mdata.Movie;
                if (m.Studio != null && m.Studio.StudioId != 0)
                {
                    context.Attach(m.Studio);
                }
                context.Add(m);
                context.SaveChanges();
                return Ok(m.MovieId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
   }
}
