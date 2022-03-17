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
        private IInterestRepository<Person> _interest;

        public PersonController(IInterestRepository<Person> interest)
        {
            _interest = interest;
        }
    }
}
