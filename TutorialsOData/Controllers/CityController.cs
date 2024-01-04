using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using TutorialsOData.Contexts;

namespace TutorialsOData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        [EnableQuery(PageSize = 5)]
        public IActionResult GetPeople()
        {
            // Veri kaynağınızdan ürünleri getirme işlemi
            return Ok(_context.Cities);
        }
    }
}
