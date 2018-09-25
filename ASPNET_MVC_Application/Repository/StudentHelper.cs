using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNET_MVC_Application.Models;
using System.Data.Entity.Migrations;
using System.IO;

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

        public void InsertRecord (StudentInfo std)
        {
            try
            {
                db.tStudent.Add(std);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void Update (StudentInfo std)
        {
            try
            {
                db.tStudent.AddOrUpdate(std);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public StudentInfo GetSingleStudentRecord(int id)
        {
            try
            {
                StudentInfo st = db.tStudent.SingleOrDefault(c => c.Id == id);
                db.Database.Log = Console.WriteLine;
                return st;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteRecord (int id)
        {
            try
            {
                var employer = new StudentInfo { Id = id };
                db.tStudent.Attach(employer);
                db.tStudent.Remove(employer);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}