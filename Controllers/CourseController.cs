using ABC__university.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace ABC__university.Controllers
{
    public class CourseController : Controller
    {
        ABCDbContext myDB = new ABCDbContext();
        public ActionResult GetCourses()
        {
            List<Course> courseLst = new List<Course>();
            courseLst = (from obj in myDB.Courses
                         select obj).ToList();

            return View("Index");

        }
        public ActionResult GetCourse(int id)
        {
            Course obj = new Course();
            obj = (from xyz in myDB.Courses
                   where xyz.courseID == id
                   select xyz).FirstOrDefault();
            return View("Details");

        }
        public ActionResult InsertCourse()
        {
            Course obj = new Course();
            obj.courseName = "test";
            obj.isAvaible = true; 
        
            myDB.Courses.Add(obj);
            myDB.SaveChanges();
            return View("Index");
        }
        
    }
}