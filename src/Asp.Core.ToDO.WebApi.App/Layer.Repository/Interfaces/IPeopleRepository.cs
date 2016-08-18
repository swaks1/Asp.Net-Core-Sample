using Asp.Core.ToDO.WebApi.App.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Core.ToDO.WebApi.App.Layer.Repository.Interfaces
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetPeople();
        Person GetPersonById(int personID);
        Person InsertPerson(Person person);
        bool DeletePerson(int personID);
        Person UpdatePerson(Person person);
       
    }
}
