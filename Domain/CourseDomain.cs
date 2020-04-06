using StudentInfoManagement.Domains;
using StudentInfoManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoManagement.Domain
{
    public class CourseDomain : BaseDomain
    {
        public List<Course> Get(int CourseId)
        {
            var reader = this.GetReader($"select * from Courses ");
            var courses = new List<Course>();
            while (reader.Read())
            {
                var course = new Course();
                course.CourseId = reader.GetInt32(1);
                course.CourseName = reader.GetString(2);
                courses.Add(course);
            }
            return courses;
        }
    }
}
