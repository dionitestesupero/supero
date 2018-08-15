using Supero.Tasks.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supero.Tasks.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void Add(Domain.Task task)
        {
            taskRepository.Add(task);
        }

        public IEnumerable<Domain.Task> GetOpen()
        {
            return taskRepository.GetOpen();
        }

        public IEnumerable<Domain.Task> GetResolved()
        {
            return taskRepository.GetResolved();
        }

        public void Update(Domain.Task task)
        {
            taskRepository.Update(task);
        }

        public void Delete(int id)
        {
            taskRepository.Delete(id);
        }
    }
}
