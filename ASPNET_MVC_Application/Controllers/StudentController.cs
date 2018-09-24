using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNET_MVC_Application.Models;

namespace ASPNET_MVC_Application.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var studentList = new List<Student>{
                            new Student() { StudentId = 1, StudentName = "John", StudentAge = 18 } ,
                            new Student() { StudentId = 2, StudentName = "Steve", StudentAge = 21 } ,
                            new Student() { StudentId = 3, StudentName = "Bill",  StudentAge = 25 } ,
                            new Student() { StudentId = 4, StudentName = "Ram" , StudentAge = 20 } ,
                            new Student() { StudentId = 5, StudentName = "Ron" , StudentAge = 31 } ,
                            new Student() { StudentId = 4, StudentName = "Chris" , StudentAge = 17 } ,
                            new Student() { StudentId = 4, StudentName = "Rob" , StudentAge = 19 }
                        };

            return View(studentList);  
        }
    }
}