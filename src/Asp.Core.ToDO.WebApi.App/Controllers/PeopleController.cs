using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asp.Core.ToDO.WebApi.App.Layer.Models;
using Asp.Core.ToDO.WebApi.App.Layer.Repository;
using Asp.Core.ToDO.WebApi.App.Layer.Repository.Interfaces;



// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.Core.ToDO.WebApi.App.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository peopleRepository;


        public PeopleController(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }

     
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return peopleRepository.GetPeople();
        }
      
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return peopleRepository.GetPersonById(id);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if(ModelState.IsValid)
            {
                person.Picture = "default.png";
                peopleRepository.InsertPerson(person);
                return new ObjectResult(person);
            }

            return BadRequest();
           
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = peopleRepository.DeletePerson(id);
            if (result)
            {
                return Ok("Person Deleted");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person person)
        {
            if (ModelState.IsValid)
            {                
                peopleRepository.UpdatePerson(person);
                return new ObjectResult(person);
            }

            return BadRequest();

        }
       
   
    }
}
