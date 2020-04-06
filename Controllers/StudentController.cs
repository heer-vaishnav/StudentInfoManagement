using Microsoft.AspNetCore.Mvc;
using StudentInfoManagement.Domain;
using StudentInfoManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoManagement.Controller
{ 
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        public StudentController()
        {
            this.StudentDomain = new StudentDomain();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var student = this.StudentDomain.StudentGet();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            this.StudentDomain.StudentAdd(student);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Student student)
        {
            this.StudentDomain.StudentUpdate(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete()
        {
            return Ok();
        }

        private StudentDomain StudentDomain { get; set; }
    }
}
