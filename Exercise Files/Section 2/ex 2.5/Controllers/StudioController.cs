using Microsoft.AspNetCore.Mvc;
using DVDMovie.Models;
using DVDMovie.Models.BindingTargets;
using System.Collections.Generic;
namespace DVDMovie.Controllers
{
    [Route("api/studios")]
    public class StudioController : Controller
    {
        private DataContext context;
        public StudioController(DataContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IEnumerable<Studio> GetStudios()
        {
            return context.Studios;
        }
        [HttpPost]
        public IActionResult CreateStudio([FromBody]StudioData sdata)
        {
            if (ModelState.IsValid)
            {
                Studio s = sdata.Studio;
                context.Add(s);
                context.SaveChanges();
                return Ok(s.StudioId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
