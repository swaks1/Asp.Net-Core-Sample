using Asp.Core.ToDO.WebApi.App.Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Core.ToDO.WebApi.App.Layer.Models;

namespace Asp.Core.ToDO.WebApi.App.Layer.Repository.Implementaitons
{
    public class PeopleRepository : IPeopleRepository
    {
        AppDbContext database;

        public PeopleRepository(AppDbContext db)
        {
            this.database = db;
        }

        public bool DeletePerson(int personID)
        {
            var person = database.People.FirstOrDefault(p => p.PersonId == personID);

            if(person != null)
            {
                database.People.Remove(person);
                database.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Person> GetPeople()
        {
            return database.People.ToList(); 
        }

        public Person GetPersonById(int personID)
        {
            var person = database.People.FirstOrDefault(p => p.PersonId == personID);
            return person;          
        }

        public Person InsertPerson(Person person)
        {
            database.People.Add(person);
            database.SaveChanges();

            return person;
        }

        public Person UpdatePerson(Person person)
        {
            var dbPerson = database.People.FirstOrDefault(p => p.PersonId == person.PersonId);
            dbPerson.Name = person.Name;
            dbPerson.Age = person.Age;
            dbPerson.Picture = person.Picture;

            database.SaveChanges();

            return dbPerson;
        }
    }
}
