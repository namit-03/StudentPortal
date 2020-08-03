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
    public class StudentRegistersController : ControllerBase
    {
        private readonly Project_1Context _context;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));
        public StudentRegistersController(Project_1Context context)
        {
            _context = context;
        }

        // GET: api/StudentRegisters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentRegister>>> GetStudentRegister()
        {
            return await _context.StudentRegister.ToListAsync();
        }

        // GET: api/StudentRegisters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentRegister>> GetStudentRegister(int id)
        {
            var studentRegister = await _context.StudentRegister.FindAsync(id);
            _log4net.Info("Student with given id has accesed DB");
            if (studentRegister == null)
            {
                return NotFound();
            }

            return studentRegister;
        }

        // PUT: api/StudentRegisters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentRegister(int id, StudentRegister studentRegister)
        {
            _log4net.Info("An Existing student has been modified");
            if (id != studentRegister.Rollno)
            {
                return BadRequest();
            }

            _context.Entry(studentRegister).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentRegisterExists(id))
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

        // POST: api/StudentRegisters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentRegister>> PostStudentRegister(StudentRegister studentRegister)
        {
            _context.StudentRegister.Add(studentRegister);
            _log4net.Info("A new student has been added");
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentRegisterExists(studentRegister.Rollno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentRegister", new { id = studentRegister.Rollno }, studentRegister);
        }

        // DELETE: api/StudentRegisters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentRegister>> DeleteStudentRegister(int id)
        {
            var studentRegister = await _context.StudentRegister.FindAsync(id);
            _log4net.Info("A  student has been deleted");
            if (studentRegister == null)
            {
                return NotFound();
            }

            _context.StudentRegister.Remove(studentRegister);
            await _context.SaveChangesAsync();

            return studentRegister;
        }

        private bool StudentRegisterExists(int id)
        {
            return _context.StudentRegister.Any(e => e.Rollno == id);
        }
    }
}
