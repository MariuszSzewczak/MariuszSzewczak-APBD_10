using System;
using Cw10.DTOs.Requests;
using Cw10.Models;
using Cw10.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController: ControllerBase
    {

        private IStudentDbService _service;
        public StudentsController(IStudentDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents()); 
        }
        

        [HttpPost]
        public IActionResult ModifyStudent(ModifyStudentRequest request)
        {
            try
            {
                Student student = _service.ModifyStudent(request);
                return Ok(student);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

        [HttpDelete]
        public IActionResult DeleteStudent(DeleteStudentRequest request)
        {
            try
            {
                Student student = _service.DeleteStudent(request);
                return Ok(student);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
        
    }
}