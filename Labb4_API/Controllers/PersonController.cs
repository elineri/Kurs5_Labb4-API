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
    }
}
