using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiKestrel.Controllers
{
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("people/all")]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return new[]
            {
                new Person { Name = "Ana" },
                new Person { Name = "Felipe" },
                new Person { Name = "Emillia" }
            };
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}