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
    public class CourseController
    {
        public CourseController()
        {
            this.CourseDomain = new CourseDomain();
        }
        private CourseDomain CourseDomain { get; set; }
    }
}
