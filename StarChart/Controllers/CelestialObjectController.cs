using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        [ActionName("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.CelestialObjects.FindAsync(id);

            if (result != null)
            {
                result.Satellites.Add(result);
                return Ok();
            } 
            else
            {
                return NotFound();
            }
        }
    }
}
