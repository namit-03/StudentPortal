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
    public class StudentMarksController : ControllerBase
    {
        private readonly Project_1Context _context;

        public StudentMarksController(Project_1Context context)
        {
            _context = context;
        }

        // GET: api/StudentMarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentMarks>>> GetStudentMarks()
        {
            return await _context.StudentMarks.ToListAsync();
        }

        // GET: api/StudentMarks/5
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

       
    }
}
