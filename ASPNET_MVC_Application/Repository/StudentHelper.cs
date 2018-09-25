using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNET_MVC_Application.Models;

namespace ASPNET_MVC_Application.Repository
{
    
    public class StudentHelper
    {
        StudentDBContext db = new StudentDBContext();

        public List<StudentInfo> GetAllStudents()
        {
            try
            {
                return db.tStudent.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}