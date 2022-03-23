using Labb4_API.Services;
using Labb4_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IInterest<Person> _interest;

        public PersonController(IInterest<Person> interest)
        {
            _interest = interest;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                return Ok(await _interest.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            try
            {
                var result = await _interest.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreateNewPerson(Person newPerson)
        {
            try
            {
                if (newPerson == null)
                {
                    return BadRequest();
                }
                var createdPerson = await _interest.Add(newPerson);
                return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.PersonId }, createdPerson);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add data to database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> Delete(int id)
        {
            try
            {
                var interestToDelete = await _interest.GetSingle(id);
                if (interestToDelete == null)
                {
                    return NotFound($"Person with id {id} not found");
                }
                return await _interest.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete data to database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, Person person)
        {
            try
            {
                if (id != person.PersonId)
                {
                    return BadRequest("Person id doesn't match");
                }
                var personToUpdate = await _interest.GetSingle(id);
                if (personToUpdate == null)
                {
                    return NotFound($"Product with id {id} not found");
                }
                return await _interest.Update(person);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update data to database");
            }
        }

    }
}
