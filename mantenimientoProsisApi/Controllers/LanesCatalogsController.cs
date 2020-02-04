using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mantenimientoProsisApi.Context;
using mantenimientoProsisApi.Entities;

namespace mantenimientoProsisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanesCatalogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LanesCatalogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LanesCatalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanesCatalog>>> GetLanesCatalogs()
        {
            return await _context.LanesCatalogs.ToListAsync();
        }

        // GET: api/LanesCatalogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanesCatalog>> GetLanesCatalog(int id)
        {
            var lanesCatalog = await _context.LanesCatalogs.FindAsync(id);

            if (lanesCatalog == null)
            {
                return NotFound();
            }

            return lanesCatalog;
        }

        // PUT: api/LanesCatalogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanesCatalog(int id, LanesCatalog lanesCatalog)
        {
            if (id != lanesCatalog.CapufeLaneNum)
            {
                return BadRequest();
            }

            _context.Entry(lanesCatalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanesCatalogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LanesCatalogs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LanesCatalog>> PostLanesCatalog(LanesCatalog lanesCatalog)
        {
            _context.LanesCatalogs.Add(lanesCatalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanesCatalog", new { id = lanesCatalog.CapufeLaneNum }, lanesCatalog);
        }

        // DELETE: api/LanesCatalogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LanesCatalog>> DeleteLanesCatalog(int id)
        {
            var lanesCatalog = await _context.LanesCatalogs.FindAsync(id);
            if (lanesCatalog == null)
            {
                return NotFound();
            }

            _context.LanesCatalogs.Remove(lanesCatalog);
            await _context.SaveChangesAsync();

            return lanesCatalog;
        }

        private bool LanesCatalogExists(int id)
        {
            return _context.LanesCatalogs.Any(e => e.CapufeLaneNum == id);
        }
    }
}
