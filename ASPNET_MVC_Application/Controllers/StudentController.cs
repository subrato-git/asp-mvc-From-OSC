using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ASPNET_MVC_Application.Models;
using ASPNET_MVC_Application.Repository;

namespace ASPNET_MVC_Application.Controllers
{
    public class StudentController : Controller
    {
        StudentHelper repo = new StudentHelper();
        // GET: Student

        

        public ActionResult Index ()
        {
             //String conString = "Data Source=OSC_HR_Mahfuzur;Initial Catalog=Student;Integrated Security=True";
             //SqlConnection con = new SqlConnection(conString); 
             //String query = "Select * from StudentInfo";
             //SqlCommand cmd = new SqlCommand(query,con);

             //var modele = new List<Student>();       

             //con.Open();
             //SqlDataReader rdr = cmd.ExecuteReader();
             //while (rdr.Read())
             //{
             //   var student = new Student();
             //   student.Id = (int)rdr["Id"];
             //   student.Name = rdr["Name"].ToString();
             //   student.Age =  (int)rdr["Age"];

             //   modele.Add(student);
             //}

            var model = repo.GetAllStudents();

             return View(model);  
        }

        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentInfo std)
        {
            repo.InsertRecord(std);
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit (int id)
        {
            //String conString = "Data Source=OSC_HR_Mahfuzur;Initial Catalog=Student;Integrated Security=True";
            //SqlConnection con = new SqlConnection(conString);
            //String query = "Select * from StudentInfo";
            //SqlCommand cmd = new SqlCommand(query, con);


            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //var student = new StudentInfo();
            //while (rdr.Read())
            //{
            //    student.Id = (int)rdr["Id"];
            //    student.Name = rdr["Name"].ToString();
            //    student.Age = (int)rdr["Age"];
            //    if (student.Id == id)
            //    {
            //        break;
            //    }
            //}
            StudentInfo student = repo.GetSingleStudentRecord(id);

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit (StudentInfo std)
        {
            //String conString = "Data Source = OSC_HR_Mahfuzur; Initial Catalog = Student; Integrated Security = True";
            //SqlConnection con = new SqlConnection(conString);
            //String query = "UPDATE StudentInfo SET Name = @StudentName, Age = @StudentAge WHERE Id = @StudentId;";
            //SqlCommand cmd = new SqlCommand(query,con);
            //cmd.Parameters.AddWithValue("@StudentName", std.Name);
            //cmd.Parameters.AddWithValue("@StudentAge", std.Age);
            //cmd.Parameters.AddWithValue("@StudentId", std.Id);
            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            repo.Update(std);

            return RedirectToAction("Index");
        }

        public ActionResult Delete (int id)
        {
            //String conString = "Data Source=OSC_HR_Mahfuzur;Initial Catalog=Student;Integrated Security=True";
            //SqlConnection con = new SqlConnection(conString);
            //String query = "DELETE from StudentInfo WHERE Id = @id";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@id",id);

            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            repo.DeleteRecord(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details (int id)
        {
            //String conString = "Data Source=OSC_HR_Mahfuzur;Initial Catalog=Student;Integrated Security=True";
            //SqlConnection con = new SqlConnection(conString);
            //String query = "Select * from StudentInfo";
            //SqlCommand cmd = new SqlCommand(query, con);


            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //var student = new StudentInfo();
            //while (rdr.Read())
            //{
            //    student.Id = (int)rdr["Id"];
            //    student.Name = rdr["Name"].ToString();
            //    student.Age = (int)rdr["Age"];
            //    if (student.Id == id)
            //    {
            //        break;
            //    }
            //}

            return View(repo.GetSingleStudentRecord(id));
        }

        public ActionResult RazorSyntax ()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(String stdName)
        {
            StudentInfo single = repo.SearchStudentRecord(stdName);
            System.Diagnostics.Debug.WriteLine(single.Name);
            TempData["st"] = single;
            return RedirectToAction("SearchResult");
        }

        public ActionResult SearchResult()
        {
            StudentInfo s = new StudentInfo();
            s = (StudentInfo)TempData["st"];
            System.Diagnostics.Debug.WriteLine(s.Name);
            return View(s);
        }

    }
}