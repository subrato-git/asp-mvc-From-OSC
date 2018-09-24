using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ASPNET_MVC_Application.Models;

namespace ASPNET_MVC_Application.Controllers
{
    public class StudentController : Controller
    {
        IList<Student> studentList = new List<Student>() {
                    new Student(){ StudentId=1, StudentName="John", StudentAge = 18 },
                    new Student(){ StudentId=2, StudentName="Steve", StudentAge = 21 },
                    new Student(){ StudentId=3, StudentName="Bill", StudentAge = 25 },
                    new Student(){ StudentId=4, StudentName="Ram", StudentAge = 20 },
                    new Student(){ StudentId=5, StudentName="Ron", StudentAge = 31 },
                    new Student(){ StudentId=6, StudentName="Chris", StudentAge = 17 },
                    new Student(){ StudentId=7, StudentName="Rob", StudentAge = 19 }
                };
        // GET: Student
        public ActionResult Index()
        {
             String conString = "Data Source=OSC_HR_Mahfuzur;Initial Catalog=Student;Integrated Security=True";
             SqlConnection con = new SqlConnection(conString); 
             String query = "Select * from StudentInfo";
             SqlCommand cmd = new SqlCommand(query,con);

             var model = new List<Student>();       

             con.Open();
             SqlDataReader rdr = cmd.ExecuteReader();
             while (rdr.Read())
             {
                var student = new Student();
                student.StudentId = (int)rdr["Id"];
                student.StudentName = rdr["Name"].ToString();
                student.StudentAge =  (int)rdr["Age"];

                model.Add(student);
             }

             return View(model);  
        }

        public ActionResult Edit(int id)
        {
            String conString = "Data Source=OSC_HR_Mahfuzur;Initial Catalog=Student;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            String query = "Select * from StudentInfo";
            SqlCommand cmd = new SqlCommand(query, con);

           
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            var student = new Student();
            while (rdr.Read())
            {
                student.StudentId = (int)rdr["Id"];
                student.StudentName = rdr["Name"].ToString();
                student.StudentAge = (int)rdr["Age"];
                if (student.StudentId == id)
                {
                    break;
                }
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student std)
        {
            String conString = "Data Source = OSC_HR_Mahfuzur; Initial Catalog = Student; Integrated Security = True";
            SqlConnection con = new SqlConnection(conString);
            String query = "UPDATE StudentInfo SET Name = @StudentName, Age = @StudentAge WHERE Id = @StudentId;";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@StudentName", std.StudentName);
            cmd.Parameters.AddWithValue("@StudentAge", std.StudentAge);
            cmd.Parameters.AddWithValue("@StudentId", std.StudentId);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            return RedirectToAction("Index");
        }

    }
}