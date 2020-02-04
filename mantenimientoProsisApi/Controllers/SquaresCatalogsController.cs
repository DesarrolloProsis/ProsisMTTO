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
    public class SquaresCatalogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SquaresCatalogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SquaresCatalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquaresCatalog>>> GetSquaresCatalogs()
        {
            return await _context.SquaresCatalogs.ToListAsync();
        }

        // GET: api/SquaresCatalogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SquaresCatalog>> GetSquaresCatalog(int id)
        {
            var squaresCatalog = await _context.SquaresCatalogs.FindAsync(id);

            if (squaresCatalog == null)
            {
                return NotFound();
            }

            return squaresCatalog;
        }

        // PUT: api/SquaresCatalogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSquaresCatalog( string param1, int id, SquaresCatalog squaresCatalog)
        {
            if (id != squaresCatalog.SquareNum)
            {
                return BadRequest();
            }

            _context.Entry(squaresCatalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SquaresCatalogExists(id))
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

        // POST: api/SquaresCatalogs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SquaresCatalog>> PostSquaresCatalog(SquaresCatalog squaresCatalog)
        {
            _context.SquaresCatalogs.Add(squaresCatalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSquaresCatalog", new { id = squaresCatalog.SquareNum }, squaresCatalog);
        }

        // DELETE: api/SquaresCatalogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SquaresCatalog>> DeleteSquaresCatalog(int id)
        {
            var squaresCatalog = await _context.SquaresCatalogs.FindAsync(id);
            if (squaresCatalog == null)
            {
                return NotFound();
            }

            _context.SquaresCatalogs.Remove(squaresCatalog);
            await _context.SaveChangesAsync();

            return squaresCatalog;
        }

        private bool SquaresCatalogExists(int id)
        {
            return _context.SquaresCatalogs.Any(e => e.SquareNum == id);
        }
    }
}
