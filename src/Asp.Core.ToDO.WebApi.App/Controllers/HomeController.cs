using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asp.Core.ToDO.WebApi.App.Layer.Repository.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace Asp.Core.ToDO.WebApi.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPeopleRepository peopleRepository;
        private readonly IHostingEnvironment hostingEnv;

        public HomeController(IPeopleRepository peopleRepository, IHostingEnvironment env)
        {
            this.peopleRepository = peopleRepository;
            this.hostingEnv = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonInfo(int id)
        {
           if(id == 0)
            {
                return BadRequest();
            }

            var person = peopleRepository.GetPersonById(id);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var json = JsonConvert.SerializeObject(person, serializerSettings);

            ViewBag.personJson = json;

            return View(person);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        
        public IActionResult PostPhoto(int id, IFormFile file)
        {
            var person = peopleRepository.GetPersonById(id);

            var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');

            //get the extension
            var extension = Path.GetExtension(filename);

            if (extension != ".jpg" && extension != ".png")
            {
                return BadRequest();
            }

            filename = person.Name +extension;

            person.Picture = filename;
            peopleRepository.UpdatePerson(person);

            filename = hostingEnv.WebRootPath + $@"\uploads\{filename}";
        
            using (FileStream fs = System.IO.File.Create(filename))
            {
                file.CopyTo(fs);
                fs.Flush();
            }


            return RedirectToAction("PersonInfo", new { id = person.PersonId });
        }
    }
}
