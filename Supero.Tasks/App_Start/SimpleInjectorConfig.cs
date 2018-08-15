using SimpleInjector;
using SimpleInjector.Lifestyles;
using Supero.Tasks.Database;
using Supero.Tasks.Database.Context;
using Supero.Tasks.Services;

namespace Supero.Tasks.App_Start
{
    public class SimpleInjectorConfig
    {
        public static Container GetContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<ITaskRepository, TaskRepository>();
            container.Register<ITaskService, TaskService>();

            container.Register(() => 
            {
                return new TaskContext();
            });

            return container;
        }
    }
}