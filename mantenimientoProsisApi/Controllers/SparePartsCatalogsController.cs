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
    public class SparePartsCatalogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SparePartsCatalogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SparePartsCatalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SparePartsCatalog>>> GetSparePartsCatalogs()
        {
            return await _context.SparePartsCatalogs.ToListAsync();
        }

        // GET: api/SparePartsCatalogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SparePartsCatalog>> GetSparePartsCatalog(string id)
        {
            var sparePartsCatalog = await _context.SparePartsCatalogs.FindAsync(id);

            if (sparePartsCatalog == null)
            {
                return NotFound();
            }

            return sparePartsCatalog;
        }

        // PUT: api/SparePartsCatalogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSparePartsCatalog(string id, SparePartsCatalog sparePartsCatalog)
        {
            if (id != sparePartsCatalog.NumPart)
            {
                return BadRequest();
            }

            _context.Entry(sparePartsCatalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SparePartsCatalogExists(id))
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

        // POST: api/SparePartsCatalogs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SparePartsCatalog>> PostSparePartsCatalog(SparePartsCatalog sparePartsCatalog)
        {
            _context.SparePartsCatalogs.Add(sparePartsCatalog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SparePartsCatalogExists(sparePartsCatalog.NumPart))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSparePartsCatalog", new { id = sparePartsCatalog.NumPart }, sparePartsCatalog);
        }

        // DELETE: api/SparePartsCatalogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SparePartsCatalog>> DeleteSparePartsCatalog(string id)
        {
            var sparePartsCatalog = await _context.SparePartsCatalogs.FindAsync(id);
            if (sparePartsCatalog == null)
            {
                return NotFound();
            }

            _context.SparePartsCatalogs.Remove(sparePartsCatalog);
            await _context.SaveChangesAsync();

            return sparePartsCatalog;
        }

        private bool SparePartsCatalogExists(string id)
        {
            return _context.SparePartsCatalogs.Any(e => e.NumPart == id);
        }
    }
}
