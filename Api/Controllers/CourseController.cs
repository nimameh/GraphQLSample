using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;
using Api.Data.Repository;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        public CoursesRepository CoursesRepository { get; }

        public CourseController(CoursesRepository coursesRepository)
        {

            CoursesRepository = coursesRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var allCourses = CoursesRepository.GetAll();
            return Ok(allCourses);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = CoursesRepository.GetCourseById(id);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Course course)
        {
            var addedCourse = CoursesRepository.AddCourse(course);
            return Ok(addedCourse);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Course course)
        {
            var updatedCourse = CoursesRepository.UpdateCourse(id, course);
            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CoursesRepository.DeleteCourse(id);
            return Ok();
        }
    }
}
