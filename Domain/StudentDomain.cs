using StudentInfoManagement.Domains;
using StudentInfoManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoManagement.Domain
{
    public class StudentDomain : BaseDomain
    {
        //public bool IsLogin(Student student)
        //{
        //    var reader = this.GetReader($"select * from Students where Name='{student.StudentName}' and EmailId = '{student.StudentEmailId}'");
        //    var isLoggedIn = false;
        //    while (reader.Read())
        //    {
        //        isLoggedIn = true;
        //    }
        //    return isLoggedIn;
        //}

        public List<Student> StudentGet()
        {
            var reader = this.GetReader($"select * from Students ");
            var students = new List<Student>();
            while (reader.Read())
            {
                var student = new Student();
                student.StudentName = reader.GetString(2);
                student.StudentEmailId = reader.GetString(3);
                student.StudentMobileNo = reader.GetString(4);
                student.FeesPaid = reader.GetBoolean(5);
                student.CourseId = reader.GetInt16(6);
                students.Add(student);
            }
            return students;
        }

        public void StudentAdd(Student student)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=StudentInfo;Integrated Security=True");
            SqlCommand cmd = new SqlCommand($"spInsert", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
            cmd.Parameters.AddWithValue("@StudentEmail", student.StudentEmailId);
            cmd.Parameters.AddWithValue("@StudentMobileNo", student.StudentMobileNo);
            cmd.Parameters.AddWithValue("@FeesPaid", student.FeesPaid);
            cmd.ExecuteNonQuery();
        }

        public void StudentUpdate(Student student)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=StudentInfo;Integrated Security=True");
            SqlCommand cmd = new SqlCommand($"SpUpdate", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
            cmd.Parameters.AddWithValue("@StudentEmail", student.StudentEmailId);
            cmd.Parameters.AddWithValue("@StudentMobileNo", student.StudentMobileNo);
            cmd.Parameters.AddWithValue("@FeesPaid", student.FeesPaid);
            cmd.ExecuteNonQuery();
        }

        public void StudentDelete(Student student)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=StudentInfo;Integrated Security=True");
            SqlCommand cmd = new SqlCommand($"spDelete", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.Remove(student.StudentId);
        }
    }
}