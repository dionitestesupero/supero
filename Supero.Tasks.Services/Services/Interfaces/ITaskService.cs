using Supero.Tasks.Domain;
using System.Collections.Generic;

namespace Supero.Tasks.Services
{
    public interface ITaskService
    {
        void Add(Task task);
        void Update(Task task);
        void Delete(int id);
        IEnumerable<Task> GetOpen();
        IEnumerable<Task> GetResolved();
    }
}
