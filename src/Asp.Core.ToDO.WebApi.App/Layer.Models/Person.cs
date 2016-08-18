using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Core.ToDO.WebApi.App.Layer.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }

        public string Picture { get; set; }
    }
}
