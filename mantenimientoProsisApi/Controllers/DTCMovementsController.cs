﻿using System;
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
    public class DTCMovementsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DTCMovementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DTCMovements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTCMovement>>> GetDTCMovements()
        {
            return await _context.DTCMovements.ToListAsync();
        }

        // GET: api/DTCMovements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTCMovement>> GetDTCMovement(int id)
        {
            var dTCMovement = await _context.DTCMovements.FindAsync(id);

            if (dTCMovement == null)
            {
                return NotFound();
            }

            return dTCMovement;
        }

        // PUT: api/DTCMovements/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDTCMovement(int id, DTCMovement dTCMovement)
        {
            if (id != dTCMovement.MovementId)
            {
                return BadRequest();
            }

            _context.Entry(dTCMovement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DTCMovementExists(id))
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

        // POST: api/DTCMovements
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DTCMovement>> PostDTCMovement(DTCMovement dTCMovement)
        {
            _context.DTCMovements.Add(dTCMovement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDTCMovement", new { id = dTCMovement.MovementId }, dTCMovement);
        }

        // DELETE: api/DTCMovements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTCMovement>> DeleteDTCMovement(int id)
        {
            var dTCMovement = await _context.DTCMovements.FindAsync(id);
            if (dTCMovement == null)
            {
                return NotFound();
            }

            _context.DTCMovements.Remove(dTCMovement);
            await _context.SaveChangesAsync();

            return dTCMovement;
        }

        private bool DTCMovementExists(int id)
        {
            return _context.DTCMovements.Any(e => e.MovementId == id);
        }
    }
}
