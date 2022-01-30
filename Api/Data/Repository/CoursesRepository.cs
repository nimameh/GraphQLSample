using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;

namespace Api.Data.Repository
{
    public class CoursesRepository
    {
        public AppDbContext AppDbContext { get; }

        public CoursesRepository(AppDbContext context)
        {
            AppDbContext = context;
        }

        public List<Course> GetAll()
        {
            return AppDbContext.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return AppDbContext.Courses.FirstOrDefault(n => n.Id == id);
        }

        public Course AddCourse(Course course)
        {
            AppDbContext.Courses.Add(course);
            AppDbContext.SaveChanges();
            return course;
        }

        public Course UpdateCourse(int id, Course course)
        {
            var _course = AppDbContext.Courses.FirstOrDefault(n => n.Id == id);
            _course.Name = course.Name;
            _course.Description = course.Description;
            _course.Review = course.Review;
            _course.DateUpdated = DateTime.Now;
            AppDbContext.SaveChanges();

            return course;
        }

        public void DeleteCourse(int id)
        {
            var course = AppDbContext.Courses.FirstOrDefault(n => n.Id == id);
            AppDbContext.Courses.Remove(course);
            AppDbContext.SaveChanges();
        }
    }
}
