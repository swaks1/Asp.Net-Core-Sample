using Asp.Core.ToDO.WebApi.App.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Core.ToDO.WebApi.App.Layer.Repository.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<PersonTask> GetTasks();

        PersonTask GetTaskById(int taskId);

        PersonTask InsertTask(PersonTask task);

        PersonTask DeleteTask(int taskId);

        PersonTask UpdateTask(PersonTask person);
    }
}
