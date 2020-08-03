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
    public class TeacherLoginController : ControllerBase
    {
       readonly ITeacherLogin context;

        public TeacherLoginController(ITeacherLogin _context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("GetDetails")]
        public IActionResult GetTeacherLogins()
        {

            try
            {
                var loginvalue = context.GetTeacherLogins();
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
        [Route("GetDetail/{id}")]
        public IActionResult GetTeacherLogin(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var data = context.GetTeacherLogin(id);
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
        public IActionResult UpdateDetail(int id=7, string password="704")
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var result = context.UpDateTeacher(id, password);

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
        public IActionResult AddDetail(TeacherLogin model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = context.AddTeacherLogin(model);
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
        [Route("DeleteDetail/{id}")]
        public IActionResult DeleteDetail(int id)
        {


            if (id == 0)
            {
                return BadRequest(id);
            }

            try
            {
                var result = context.DeleteTeacherLogin(id);
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
