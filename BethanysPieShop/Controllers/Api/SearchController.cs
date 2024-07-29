using BethanysPieShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;

        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        // GET API HTTP request. Gets all pies
        [HttpGet] 
        public IActionResult GetAll()
        {
            var allPies = _pieRepository.AllPies;
            return Ok(allPies); // Return status 200 and the JSON data called "allPies"
        }

        // Gets pie by id
        [HttpGet("{id}")] 
        public IActionResult GetById(int id)
        {
            // If the id is not able to match a pie, return not found error
            if (!_pieRepository.AllPies.Any(p => p.PieId == id))
                return NotFound();
            //return new JsonResult(_pieRepository.AllPies.Where(p =>p.PieId == id);
            return Ok(_pieRepository.AllPies.Where(p => p.PieId == id)); // Return status 200 and the JSON data of all pies filtered by requested id
        }

        //POST API HTTP request
        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<Pie> pies = new List<Pie>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                pies = _pieRepository.SearchPies(searchQuery);
            }
            return new JsonResult(pies);
        }
    }
}
