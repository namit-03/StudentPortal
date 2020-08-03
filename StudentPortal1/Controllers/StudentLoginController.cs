using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal1.Models;
using StudentPortal1.DependencyInjection;


namespace StudentPortal1.Controllers
{
   
    [Route("api/[controller]")]
  
    [ApiController]
    public class StudentLoginController : ControllerBase
    {
     readonly IStudentLogin context;

        public StudentLoginController(IStudentLogin _context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("GetDetails")]
        public IActionResult GetStudentLogins()
        {

            try
            {
                var loginvalue = context.GetStudentLogins();
                if (loginvalue == null)
                {
                    return NotFound();
                }

                return Ok(loginvalue);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetStudentLogin(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var data = context.GetStudentLogin(id);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateDetail")]
        public IActionResult UpdateDetail(int id, string password)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = context.UpDateStudent(id, password);

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }




        [HttpPost]
        [Route("AddDetail/{id}")]
        public IActionResult AddDetail(Models.StudentLogin model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = context.AddStudentLogin(model);
                    if (id == 1)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteDetail")]
        public IActionResult DeleteDetail(int id)
        {


            if (id == 0)
            {
                return BadRequest(id);
            }

            try
            {
                var result = context.DeleteStudentLogin(id);
                if (result == 0)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(id);
            }
        }
    }
}
