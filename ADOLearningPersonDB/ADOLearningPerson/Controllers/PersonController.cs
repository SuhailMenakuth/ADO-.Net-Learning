using ADOLearningPerson.Models;
using ADOLearningPerson.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADOLearningPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            try
            {
                var persons = _personService.GetAllPersons();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex.Message}");
            }

        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest("person data is null");
                }

                bool isAdded = _personService.AddPerson(person);

                if (isAdded)
                {
                    return CreatedAtAction(nameof(GetAllPersons), new { id = person.ID }, person);

                }
                else
                {
                    return StatusCode(500, "A problem occurred while handling your request");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server erro: {ex.Message}");
            }
        }

        [HttpGet("oldest")]
        public IActionResult GetOldestPersonName()
        {
            try
            {
                var oldestPersonName = _personService.GetOldestPerson();
                return Ok(new { Success = true, OldestPersonName = oldestPersonName });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody]Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
               bool isUpdated = _personService.UpdatePerson(person);
                if (isUpdated)
                {
                    return Ok(new { Success = true, Message = "person updated Successfully" });

                }
                return NotFound(new { Success = false, Message = "Person not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


    }
}
