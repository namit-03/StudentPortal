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
    public class StudentAttendanceController : ControllerBase
    {
        private readonly Project_1Context _context;

        public StudentAttendanceController(Project_1Context context)
        {
            _context = context;
        }

        // GET: api/StudentAttendance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentAttendance>>> GetStudentAttendance()
        {
            return await _context.StudentAttendance.ToListAsync();
        }

        // GET: api/StudentAttendance/5
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

     
    }
}
