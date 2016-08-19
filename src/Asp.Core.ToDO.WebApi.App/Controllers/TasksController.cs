using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asp.Core.ToDO.WebApi.App.Layer.Models;
using Asp.Core.ToDO.WebApi.App.Layer.Repository;
using Microsoft.EntityFrameworkCore;
using Asp.Core.ToDO.WebApi.App.Layer.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.Core.ToDO.WebApi.App.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        ITaskRepository taskRepository;
       

        public TasksController(ITaskRepository repository)
        {
            taskRepository = repository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<PersonTask> Get()
        {
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = taskRepository.GetTaskById(id);
            return Ok(task);
        }

        // POST api/values
        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]PersonTask task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (String.IsNullOrEmpty(task.Name))
                return BadRequest();

            var result = taskRepository.InsertTask(task);

            return Ok(result);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = taskRepository.DeleteTask(id);

            return Ok(task);
        }
    }
}
