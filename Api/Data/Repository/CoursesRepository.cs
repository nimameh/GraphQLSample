using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;
using Microsoft.EntityFrameworkCore;

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
            var result = AppDbContext.Course.Include(x=>x.Reviews).ToList();
            return result;
        }

        public Course GetCourseById(int id)
        {
            return AppDbContext.Course.FirstOrDefault(n => n.Id == id);
        }

        public Course AddCourse(Course course)
        {
            AppDbContext.Course.Add(course);
            AppDbContext.SaveChanges();
            return course;
        }

        public Course UpdateCourse(int id, Course course)
        {
            var _course = AppDbContext.Course.FirstOrDefault(n => n.Id == id);
            _course.Name = course.Name;
            _course.Description = course.Description;
            _course.DateUpdated = DateTime.Now;
            AppDbContext.SaveChanges();

            return course;
        }

        public void DeleteCourse(int id)
        {
            var course = AppDbContext.Course.FirstOrDefault(n => n.Id == id);
            AppDbContext.Course.Remove(course);
            AppDbContext.SaveChanges();
        }
    }
}
