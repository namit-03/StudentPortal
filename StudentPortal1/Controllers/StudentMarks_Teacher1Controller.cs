using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal1.Models;

namespace StudentPortal1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMarks_Teacher1Controller : ControllerBase
    {
        private readonly Project_1Context _context;

        public StudentMarks_Teacher1Controller(Project_1Context context)
        {
            _context = context;
        }

        // GET: api/StudentMarks_Teacher1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentMarks>>> GetStudentMarks()
        {
            return await _context.StudentMarks.ToListAsync();
        }

        // GET: api/StudentMarks_Teacher1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentMarks>> GetStudentMarks(int id)
        {
            var studentMarks = await _context.StudentMarks.FindAsync(id);

            if (studentMarks == null)
            {
                return NotFound();
            }

            return studentMarks;
        }

        // PUT: api/StudentMarks_Teacher1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentMarks(int id, StudentMarks studentMarks)
        {
            if (id != studentMarks.Rollno)
            {
                return BadRequest();
            }

            _context.Entry(studentMarks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentMarksExists(id))
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

        // POST: api/StudentMarks_Teacher1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentMarks>> PostStudentMarks(StudentMarks studentMarks)
        {
            _context.StudentMarks.Add(studentMarks);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentMarksExists(studentMarks.Rollno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentMarks", new { id = studentMarks.Rollno }, studentMarks);
        }

        // DELETE: api/StudentMarks_Teacher1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentMarks>> DeleteStudentMarks(int id)
        {
            var studentMarks = await _context.StudentMarks.FindAsync(id);
            if (studentMarks == null)
            {
                return NotFound();
            }

            _context.StudentMarks.Remove(studentMarks);
            await _context.SaveChangesAsync();

            return studentMarks;
        }

        private bool StudentMarksExists(int id)
        {
            return _context.StudentMarks.Any(e => e.Rollno == id);
        }
    }
}
