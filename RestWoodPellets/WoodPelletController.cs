using Microsoft.AspNetCore.Mvc;
using WoodPelletsLib;

namespace RestWoodPellets
{
    [Route("api/woodpellets")]
    [ApiController]
    public class WoodPelletController : ControllerBase
    {
        private WoodPelletRepository woodPelletRepository;

        public WoodPelletController()
        {
            woodPelletRepository = new WoodPelletRepository();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<WoodPellet> allWoodPellets = woodPelletRepository.GetAll();
            return Ok(allWoodPellets); // Return 200 OK with the data
        }

        [HttpGet("{id}")]
        public ActionResult<WoodPellet> Get(int id)
        {
            WoodPellet wood = woodPelletRepository.GetById(id);
            if (wood == null)
            {
                return NotFound(); // Returner en HTTP 404 Not Found, hvis objektet ikke blev fundet.
            }
            return wood;
        }

        [HttpPost]
        public ActionResult<WoodPellet> Post([FromBody] WoodPellet wood)
        {
            WoodPellet newWood = woodPelletRepository.Add(wood);
            return CreatedAtAction("Get", new { id = newWood.Id }, newWood);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WoodPellet wood)
        {
            WoodPellet updatedWood = woodPelletRepository.Update(id, wood);
            if (updatedWood == null)
            {
                return NotFound(); // Returner HTTP 404 Not Found, hvis objektet ikke blev fundet.
            }
            return NoContent(); // Returner HTTP 204 No Content for en vellykket opdatering.
        }


    }
}
