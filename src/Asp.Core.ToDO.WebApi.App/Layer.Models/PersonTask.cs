using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Core.ToDO.WebApi.App.Layer.Models
{
    public class PersonTask
    {
        public int PersonTaskId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public virtual int PersonId { get; set; }

        [JsonIgnore]
        public virtual Person Person { get; set; }
    }
}
