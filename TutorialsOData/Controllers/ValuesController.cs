using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using TutorialsOData.Contexts;
using TutorialsOData.Models;

namespace TutorialsOData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ValuesController : ODataController
    {
        private readonly AppDbContext _context;

        public ValuesController(AppDbContext context)
        {
            _context = context;
        }

        /* GET: /api/Values
            /api/Values?$filter=Age ge 30
            /api/Values?$orderby=Age desc
            /api/Values?$top=10&$skip=20
            /api/Values?$select=Name,Age
            ve benzeri...
         */
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            // Veri kaynağınızdan ürünleri getirme işlemi
            return Ok(_context.Peoples);
        }

        // GET: /api/Values/2
        [HttpGet("{id}")]
        [EnableQuery]
        public IActionResult GetById(int id)
        {
            // Veri kaynağınızdan ürünleri id'ye göre getirme işlemi
            return Ok(_context.Peoples.FirstOrDefault(x => x.Id == id));
        }

        // POST: /api/Values
        [HttpPost]
        [EnableQuery]
        public IActionResult Post([FromBody] People person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Peoples.Add(person);
            _context.SaveChanges();

            return Ok(person);
        }

        // PUT: /api/Values/3
        [HttpPut("{id}")]
        [EnableQuery]
        public IActionResult Put(int id, [FromBody] People updatedPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedPerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedPerson).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(updatedPerson);
        }

        // PATCH: /api/Values/2
        [HttpPatch("{id}")]
        [EnableQuery]
        public IActionResult Patch(int id, [FromBody] Delta<People> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _context.Peoples.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            delta.Patch(person);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(person);
        }

        // DELETE: /api/Values/2
        [HttpDelete("{id}")]
        [EnableQuery]
        public IActionResult Delete(int id)
        {
            var person = _context.Peoples.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.Peoples.Remove(person);
            _context.SaveChanges();

            return NoContent();
        }

        // GET: /api/Values/GetPerson
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetPerson(ODataQueryOptions<People> options)
        {
            // OData sorgularına erişim
            var filter = options.Filter?.RawValue;
            var orderBy = options.OrderBy?.RawValue;

            // Veri tabanından sorguya uygun veri çek
            var queryableData = _context.Peoples.AsQueryable();
            var result = options.ApplyTo(queryableData);

            // Sonuçları döndür
            return Ok(result);
        }

        private bool PersonExists(int key)
        {
            return _context.Peoples.Any(p => p.Id == key);
        }
    }
}
