using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVDMovie.Models;
using Microsoft.EntityFrameworkCore;
using DVDMovie.Models.BindingTargets;
using Microsoft.AspNetCore.JsonPatch;

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
        public IActionResult GetMovies(string category, string search,
                                            bool related = false,bool metadata = false)
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
                return metadata ? CreateMetadata(data) : Ok(data);
            }
            else
            {
                return metadata ? CreateMetadata(query) : Ok(query);
            }
        }
         private IActionResult CreateMetadata(IEnumerable<Movie> movies)
        {
            return Ok(new
            {
                data = movies,
                categories = context.Movies.Select(m => m.Category)
            .Distinct().OrderBy(m => m)
            });
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
        [HttpPut("{id}")]
        public IActionResult ReplaceMovie(long id, [FromBody] MovieData mData)
        {
            if (ModelState.IsValid)
            {
                Movie m = mData.Movie;
                m.MovieId = id;
                if (m.Studio != null && m.Studio.StudioId != 0)
                {
                    context.Attach(m.Studio);
                }
                context.Update(m);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

         [HttpPatch("{id}")]
        public IActionResult UpdateMovie(long id,
            [FromBody]JsonPatchDocument<MovieData> patch)
        {
            Movie movie = context.Movies
            .Include(m => m.Studio)
            .First(m => m.MovieId == id);
            MovieData mdata = new MovieData { Movie = movie };
            patch.ApplyTo(mdata, ModelState);
            if (ModelState.IsValid && TryValidateModel(mdata))
            {
                if (movie.Studio != null && movie.Studio.StudioId != 0)
                {
                    context.Attach(movie.Studio);
                }
                context.SaveChanges();
                return Ok(movie);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult  DeleteMovie(long id)
        {
            context.Movies.Remove(new Movie { MovieId = id });
            context.SaveChanges();
            return Ok(id);
        }

    }
}
