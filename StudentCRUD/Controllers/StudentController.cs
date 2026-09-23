using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Model;

namespace StudentCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Ali" },
            new Student { Id = 2, Name = "Ahmed" }
        };

        // GET: api/Student
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(students);
        }

        // GET: api/Student/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Add(Model.Student student)
        {
            student.Id = students.Count + 1;

            students.Add(student);

            return Ok(student);
        }

        // PUT: api/Student/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var existingStudent = students.FirstOrDefault(x => x.Id == id);

            if (existingStudent == null)
                return NotFound("Student not found");

            existingStudent.Name = student.Name;

            return Ok(existingStudent);
        }

        // DELETE: api/Student/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound("Student not found");

            students.Remove(student);

            return Ok("Student deleted successfully");
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new
            {
                status = "Success",
                message = "Student CRUD API is running",
                timestamp = DateTime.UtcNow
            });
        }
    }
}
