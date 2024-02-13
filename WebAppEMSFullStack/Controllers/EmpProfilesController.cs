using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppEMSFullStack.Data;
using WebAppEMSFullStack.Models;

namespace WebAppEMSFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpProfilesController : ControllerBase
    {
        private readonly EmpDbContext _context;

        public EmpProfilesController(EmpDbContext context)
        {
            _context = context;
        }

        // GET: api/EmpProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpProfiles>>> GetEmpProfiles()
        {
          if (_context.EmpProfiles == null)
          {
              return NotFound();
          }
            return await _context.EmpProfiles.ToListAsync();
        }

        // GET: api/EmpProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpProfiles>> GetEmpProfiles(int id)
        {
          if (_context.EmpProfiles == null)
          {
              return NotFound();
          }
            var empProfiles = await _context.EmpProfiles.FindAsync(id);

            if (empProfiles == null)
            {
                return NotFound();
            }

            return empProfiles;
        }

        // PUT: api/EmpProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpProfiles(int id, EmpProfiles empProfiles)
        {
            if (id != empProfiles.EmpCode)
            {
                return BadRequest();
            }

            _context.Entry(empProfiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpProfilesExists(id))
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

        // POST: api/EmpProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpProfiles>> PostEmpProfiles(EmpProfiles empProfiles)
        {
          if (_context.EmpProfiles == null)
          {
              return Problem("Entity set 'EmpDbContext.EmpProfiles'  is null.");
          }
            _context.EmpProfiles.Add(empProfiles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpProfiles", new { id = empProfiles.EmpCode }, empProfiles);
        }

        // DELETE: api/EmpProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpProfiles(int id)
        {
            if (_context.EmpProfiles == null)
            {
                return NotFound();
            }
            var empProfiles = await _context.EmpProfiles.FindAsync(id);
            if (empProfiles == null)
            {
                return NotFound();
            }

            _context.EmpProfiles.Remove(empProfiles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpProfilesExists(int id)
        {
            return (_context.EmpProfiles?.Any(e => e.EmpCode == id)).GetValueOrDefault();
        }
    }
}
