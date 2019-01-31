using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVDMovie.Models; 

namespace DVDMovie.Controllers
{
    [Route("api/movies")]
    public class MovieController : Controller
    {
        private DataContext context;
        public MovieController(DataContext ctx){
            context = ctx;
        }

        [HttpGet("{id}")]                   	
    	public Movie GetMovie(long id)
    	{
            System.Threading.Thread.Sleep(5000);
        	return context.Movies.Find(id);
    	}
    }
}
