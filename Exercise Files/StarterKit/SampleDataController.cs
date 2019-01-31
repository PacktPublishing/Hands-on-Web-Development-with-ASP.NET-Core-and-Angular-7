using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVDMovie.Models;
using Microsoft.AspNetCore.Mvc;

namespace DVDMovie.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private DataContext context;
        public SampleDataController(DataContext ctx){
            context = ctx;
        }

        [HttpGet("[action]")]                   	
    	public Movie GetMovie()
    	{
        	return context.Movies.OrderBy(p => p.MovieId).First();
    	}
    }
}
