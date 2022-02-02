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
            var newCourse = new Course()
            {
                Name = course.Name,
                Description = course.Description,
                DateAdded = course.DateAdded,
                DateUpdated = course.DateUpdated
            };
            AppDbContext.Course.Add(newCourse);
            AppDbContext.SaveChanges();

            foreach (var review in course.Reviews)
            {
                var newReview = new Review()
                {
                    Comment = review.Comment,
                    CourseId = newCourse.Id
                };
                AppDbContext.Review.Add(newReview);
                AppDbContext.SaveChanges();
            }
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
