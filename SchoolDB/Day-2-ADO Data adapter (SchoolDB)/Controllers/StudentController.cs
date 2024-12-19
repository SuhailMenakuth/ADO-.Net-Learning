using Day_2_ADO_Data_adapter__SchoolDB_.Models;
using Day_2_ADO_Data_adapter__SchoolDB_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_2_ADO_Data_adapter__SchoolDB_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentsService _studentsService;
        public StudentController(StudentsService studentService)
        {
            _studentsService = studentService;

        }
        // [HttpGet]
        //  public IActionResult GetAllStudents()
        //{
        //    try
        //    {
        //        List<Student> students = _studentsService.GetAllStudents();
        //        return Ok(students);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message =ex.Message });
        //    }
        //}

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                List<Student> students = _studentsService.GetAllStudents();
                return Ok(students);

            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }


        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            try
            {
               string AddedStudent = _studentsService.AddStudent(student);
                return Ok(AddedStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("id")]
        public IActionResult GetStudentByID(int id)
        {
            try
            {

                Student student = _studentsService.GetStudentByID(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }

        }

    }
}