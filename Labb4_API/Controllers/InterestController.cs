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
    public class InterestController : ControllerBase
    {
        private IInterest<Interest> _interest;

        public InterestController(IInterest<Interest> interest)
        {
            _interest = interest;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
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
        public async Task<ActionResult<Interest>> GetInterest(int id)
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

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Interest>> CreateNewInterest(Interest newInterest)
        {
            try
            {
                if (newInterest == null)
                {
                    BadRequest();
                }
                var createdInterest = await _interest.Add(newInterest);
                return CreatedAtAction(nameof(GetInterest), new { id = newInterest.InterestId }, createdInterest);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Interest>> Delete(int id)
        {
            try
            {
                var interestToDelete = await _interest.GetSingle(id);
                if (interestToDelete == null)
                {
                    return NotFound($"Product with id {id} not found");
                }
                return await _interest.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete data to database");
            }
        }
    }
}
