using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supero.Tasks.Database.Context;
using Supero.Tasks.Domain;

namespace Supero.Tasks.Database
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext taskContext;

        public TaskRepository(TaskContext taskContext)
        {
            this.taskContext = taskContext;
        }

        public void Add(Domain.Task task)
        {
            taskContext.Tasks.Add(task);

            taskContext.SaveChanges();
        }

        public IEnumerable<Domain.Task> GetOpen()
        {
            return taskContext.Tasks.Where(t => !t.Resolved);
        }

        public IEnumerable<Domain.Task> GetResolved()
        {
            return taskContext.Tasks.Where(t => t.Resolved);
        }

        public void Delete(int id)
        {
            var task = taskContext.Tasks.SingleOrDefault(t => t.Id == id);

            if (task != null)
            {
                taskContext.Tasks.Remove(task);

                taskContext.SaveChanges();
            }
        }

        public void Update(Domain.Task task)
        {
            taskContext.Tasks.Add(task);
            taskContext.Entry(task).State = EntityState.Modified;
            taskContext.SaveChanges();
        }
    }
}
