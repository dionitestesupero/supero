using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supero.Tasks.Database.Context
{
    public class TaskContext : DbContext
    {
        public TaskContext()
            :base("db")
        { }

        public DbSet<Domain.Task> Tasks { get; set; }
    }
}
