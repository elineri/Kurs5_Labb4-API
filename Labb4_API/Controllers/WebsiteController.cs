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
    public class WebsiteController : ControllerBase
    {
        private readonly IInterest<Website> _interest;

        public WebsiteController(IInterest<Website> interest)
        {
            _interest = interest;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWebsites()
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
        public async Task<ActionResult<Website>> GetWebsite(int id)
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

        [HttpPost("{id}")]
        public async Task<ActionResult<Website>> CreateNewWebsite(Website newWebsite)
        {
            try
            {
                if (newWebsite == null)
                {
                    return BadRequest();
                }
                var createdWebsite = await _interest.Add(newWebsite);
                return CreatedAtAction(nameof(GetWebsite), new { id = createdWebsite.WebsiteId }, createdWebsite);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create new website");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Website>> UpdateWebsite(int id, Website web)
        {
            try
            {
                if (id != web.WebsiteId)
                {
                    return BadRequest("Website id doesn't match");
                }
                var websiteToUpdate = await _interest.GetSingle(id);
                if (websiteToUpdate == null)
                {
                    return NotFound($"Website with id {id} not found");
                }
                return await _interest.Update(web);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update data to database");
            }
        }

        [HttpGet("person{id}")]
        public async Task<IActionResult> GetWebsitesPerPerson(int id)
        {
            try
            {
                var result = await _interest.WebsitesPerPerson(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database");
            }
        }

        [HttpPost("person{personId}interest{interestId}")]
        public async Task<ActionResult<Website>> NewPersonWebsite(Website newWebsite, int personId, int interestId)
        {
            try
            {
                if (newWebsite == null)
                {
                    BadRequest();
                }
                var createdPersonWebsite = await _interest.AddPersonWebsite(newWebsite, personId, interestId);
                return CreatedAtAction(nameof(GetWebsite), new { id = createdPersonWebsite.WebsiteId }, createdPersonWebsite);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
