using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Models;
using TaskList.Requests;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("api/TaskController")]
    public class TaskController : ControllerBase
    {

            private readonly TaskDBContext db;
            public TaskController(TaskDBContext db)
            {
                
                this.db = db;
            }

            [HttpGet]
            [Route("getTaskList")]
            public List<GetTaskListResponse> getTaskLists()
            {
                return db.Tasks.Select(x => new GetTaskListResponse
                {
                    Id = x.Id,
                    Text = x.Text,
                    Date = x.Date,
                    IsCompleted = x.IsCompleted,
                }).ToList();
            }
          
    }
}
