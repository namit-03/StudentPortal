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
    public class StudentAttendancesTeacherController : ControllerBase
    {
        private readonly Project_1Context _context;

        public StudentAttendancesTeacherController(Project_1Context context)
        {
            _context = context;
        }

        // GET: api/StudentAttendancesTeacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentAttendance>>> GetStudentAttendance()
        {
            return await _context.StudentAttendance.ToListAsync();
        }

        // GET: api/StudentAttendancesTeacher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentAttendance>> GetStudentAttendance(int id)
        {
            var studentAttendance = await _context.StudentAttendance.FindAsync(id);

            if (studentAttendance == null)
            {
                return NotFound();
            }

            return studentAttendance;
        }

        // PUT: api/StudentAttendancesTeacher/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAttendance(int id, StudentAttendance studentAttendance)
        {
            if (id != studentAttendance.Rollno)
            {
                return BadRequest();
            }

            _context.Entry(studentAttendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAttendanceExists(id))
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

        // POST: api/StudentAttendancesTeacher
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentAttendance>> PostStudentAttendance(StudentAttendance studentAttendance)
        {
            _context.StudentAttendance.Add(studentAttendance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentAttendanceExists(studentAttendance.Rollno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentAttendance", new { id = studentAttendance.Rollno }, studentAttendance);
        }

        // DELETE: api/StudentAttendancesTeacher/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentAttendance>> DeleteStudentAttendance(int id)
        {
            var studentAttendance = await _context.StudentAttendance.FindAsync(id);
            if (studentAttendance == null)
            {
                return NotFound();
            }

            _context.StudentAttendance.Remove(studentAttendance);
            await _context.SaveChangesAsync();

            return studentAttendance;
        }

        private bool StudentAttendanceExists(int id)
        {
            return _context.StudentAttendance.Any(e => e.Rollno == id);
        }
    }
}
