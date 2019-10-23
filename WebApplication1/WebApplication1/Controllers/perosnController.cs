using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IDataRepository<persons> _dataRepository;

        public PersonController(IDataRepository<persons> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<persons> person = _dataRepository.GetAll();
            return Ok(person);
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            persons persons = _dataRepository.Get(id);

            if (persons == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(persons);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] persons persons)
        {
            if (persons == null)
            {
                return BadRequest("Employee is null.");
            }

            _dataRepository.Add(persons);
            return CreatedAtRoute(
                  "Get",
                  new { Id = persons.EmployeeId },
                  persons);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] persons persons)
        {
            if (persons == null)
            {
                return BadRequest("Employee is null.");
            }

            persons person = _dataRepository.Get(id);
            if (person == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Update(person, persons);
            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            persons persons = _dataRepository.Get(id);
            if (persons == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Delete(persons);
            return NoContent();
        }
    }
}