using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Models;
using TaskList.Requests;

namespace TaskList.Controllers
{   /*
    [ApiController]
    [Route("api/TaskController")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly TaskDBContext db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TaskDBContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [HttpGet]
        [Route("getTaskList")]

        public List<GetTaskListResponse> getTaskList()
        {
            return db.Tasks.Select(x => new GetTaskListResponse
            {
                Id = x.Id,
                Text = x.Text,
                Date = x.Date,
                IsCompleted = x.IsCompleted,
            }).ToList();
        }
           
        public IEnumerable<WeatherForecast> Get()
        {
            return db.Tasks.Select(x => )
        }
         


    }
*/
}
