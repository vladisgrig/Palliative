using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palliative.Data;

namespace Palliative.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly PalliativeDbContext _dbContext;

        public TasksController(Palliative.Data.PalliativeDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        private void InitTasks()
        {
            var tasks = new List<Palliative.Models.Task.Task>();
            tasks.Add(new Models.Task.Task
            {
                Id = 1,
                Title = "Прием лекарства",
                Start = new DateTime(2020, 5, 3, 20, 0, 0),
                IsPeriodic = true,
                End = new DateTime(2020, 6, 3, 20, 0, 0),
                IntervalInDays = 1
            });
            tasks.Add(new Models.Task.Task
            {
                Id = 2,
                Title = "Измерение давления",
                Start = new DateTime(2020, 5, 3, 21, 0, 0),
                IsPeriodic = false
            });

            _dbContext.Tasks.AddRange(tasks);
            _dbContext.SaveChanges();
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<Palliative.Models.Task.Task> Get()
        {
            if (!_dbContext.Tasks.Any())
            {
                InitTasks();
            }
            return _dbContext.Tasks.ToList();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        public Models.Task.Task Get(int id)
        {
            if (!_dbContext.Tasks.Any())
            {
                InitTasks();
            }
            return _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        }
    }
}
