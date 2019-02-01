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
        [HttpPut("{id}")]
        public IActionResult ReplaceStudio(long id,
               [FromBody] StudioData sdata)
        {
            if (ModelState.IsValid)
            {
                Studio s = sdata.Studio;
                s.StudioId = id;
                context.Update(s);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudio(long id)
        {
            context.Remove(new Studio { StudioId = id });
            context.SaveChanges();
            return Ok(id);
        }

    }
}
