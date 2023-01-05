using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestPermitMicroAPI.Data;
using TestPermitMicroAPI.Models;

namespace TestPermitMicroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestPermitController : ControllerBase
    {
        private readonly TestPermitMicroAPIContext _context;

        public TestPermitController(TestPermitMicroAPIContext context)
        {
            _context = context;
        }

        // GET: api/TestPermit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TPTestPermit>>> GetTPTestPermits()
        {
            return await _context.TPTestPermits.ToListAsync();
        }

        // GET: api/TestPermit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TPTestPermit>> GetTPTestPermit(int id)
        {
            var tPTestPermit = await _context.TPTestPermits.FindAsync(id);
            

            if (tPTestPermit == null)
            {
                return NotFound();
            }

            return tPTestPermit;
        }

        // GET: api/TestPermit/ByPrmtNo/00245700000010201
        [HttpGet("ByPrmtNo/{prmtNo}")]
        public async Task<ActionResult<TPTestPermit>> GetTPTestPermitByPrmtNo(string prmtNo)
        {
            //var tPTestPermit = await _context.TPTestPermits.FindAsync(id);
            var tPTestPermit = await _context.TPTestPermits.FirstAsync(a => a.PrmtNo == prmtNo);

            if (tPTestPermit == null)
            {
                return NotFound();
            }

            return tPTestPermit;
        }

        // PUT: api/TestPermit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTPTestPermit(int id, TPTestPermit tPTestPermit)
        {
            if (id != tPTestPermit.ID)
            {
                return BadRequest();
            }

            _context.Entry(tPTestPermit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TPTestPermitExists(id))
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

        // POST: api/TestPermit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TPTestPermit>> PostTPTestPermit(TPTestPermit tPTestPermit)
        {
            _context.TPTestPermits.Add(tPTestPermit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTPTestPermit", new { id = tPTestPermit.ID }, tPTestPermit);
        }

        // DELETE: api/TestPermit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTPTestPermit(int id)
        {
            var tPTestPermit = await _context.TPTestPermits.FindAsync(id);
            if (tPTestPermit == null)
            {
                return NotFound();
            }

            _context.TPTestPermits.Remove(tPTestPermit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TPTestPermitExists(int id)
        {
            return _context.TPTestPermits.Any(e => e.ID == id);
        }
    }
}
