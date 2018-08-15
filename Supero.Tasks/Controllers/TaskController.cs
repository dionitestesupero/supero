using Supero.Tasks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Supero.Tasks.Controllers
{
    public class TaskController : ApiController
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public IEnumerable<Domain.Task> GetResolved()
        {
            return taskService.GetResolved();
        }

        [HttpGet]
        public IEnumerable<Domain.Task> GetOpen()
        {
            return taskService.GetOpen();
        }

        [HttpPost]
        public void Save([FromBody]Domain.Task task)
        {
            taskService.Add(task);
        }

        [HttpPost]
        public void Update([FromBody]Domain.Task task)
        {
            taskService.Update(task);
        }

        [HttpPost]
        public void Delete([FromBody]Domain.Task task)
        {
            taskService.Delete(task.Id);
        }
    }
}