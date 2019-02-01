using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DVDMovie.Models;
using DVDMovie.Models.BindingTargets;

namespace DVDMovie.Controllers
{
    [Route("/api/session")]
    public class SessionValuesController : Controller
    {
        [HttpGet("cart")]
        public IActionResult GetCart()
        {
            return Ok(HttpContext.Session.GetString("cart"));
        }
        [HttpPost("cart")]
        public void StoreCart([FromBody] MovieSelection[] movies)
        {
            var jsonData = JsonConvert.SerializeObject(movies);
            HttpContext.Session.SetString("cart", jsonData);
        }
        [HttpGet("checkout")]
        public IActionResult GetCheckout()
        {
            return Ok(HttpContext.Session.GetString("checkout"));
        }
        [HttpPost("checkout")]
        public void StoreCheckout([FromBody] CheckoutState data)
        {
            HttpContext.Session.SetString("checkout",
            JsonConvert.SerializeObject(data));
        }

    }
}
