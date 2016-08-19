using Asp.Core.ToDO.WebApi.App.Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Core.ToDO.WebApi.App.Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.Core.ToDO.WebApi.App.Layer.Repository.Implementaitons
{
    public class TaskRepository : ITaskRepository
    {

        AppDbContext database;

        public TaskRepository(AppDbContext db)
        {
            database = db;
        }

        public PersonTask DeleteTask(int taskId)
        {
            var task = database.Tasks.FirstOrDefault(t => t.PersonTaskId == taskId);
            database.Tasks.Remove(task);
            database.SaveChanges();

            return task;
        }

        public PersonTask GetTaskById(int taskId)
        {
            var task = database.Tasks.Include(p => p.Person).FirstOrDefault(t => t.PersonId == taskId);
            return task;
        }

        public IEnumerable<PersonTask> GetTasks()
        {
            throw new NotImplementedException();
        }

        public PersonTask InsertTask(PersonTask task)
        {
            database.Tasks.Add(task);
            database.SaveChanges();
            return task;
        }

        public PersonTask UpdateTask(PersonTask person)
        {
            throw new NotImplementedException();
        }
    }
}
