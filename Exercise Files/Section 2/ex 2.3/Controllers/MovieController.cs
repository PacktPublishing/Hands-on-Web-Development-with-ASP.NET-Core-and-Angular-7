using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVDMovie.Models;
using Microsoft.EntityFrameworkCore;

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
                    .Include(m => m.Studio).ThenInclude(s=>s.Movies)
                    .Include(m => m.Ratings)
                    .FirstOrDefault(m => m.MovieId == id);
            if (result != null)
            {
                if (result.Studio != null)
                {
                    result.Studio.Movies = result.Studio.Movies.Select(s=>
                    new Movie{
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
    }
}
