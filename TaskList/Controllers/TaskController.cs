using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

            [HttpPost]
            [Route("PostTask")]
            public string PostTask([FromBody] PostTaskRequest message)
            {
                db.Tasks.Add(new Task1
                {
                    Text = message.Text,
                    Date = message.Date,
                    IsCompleted = message.IsCompleted,
                });
                db.SaveChanges();
                return "Posted";

            }

            [HttpGet]
            [Route("GetTask")]
            public GetTaskResponse GetTask([FromBody] GetTaskRequest message)
            {
                var task = db.Tasks.FirstOrDefault(x => x.Id == message.Id);
                var response = new GetTaskResponse();
                response.Text = task.Text;
                response.Date = task.Date;
                response.IsCompleted = task.IsCompleted;
                return response;
            }

            [HttpPut]
            [Route("PutTask")]
            public string PutTask([FromBody] PutTaskRequest message)
            {
                var update = db.Tasks.FirstOrDefault(x => x.Id == message.Id);
                {
                    if (update != null)
                    {
                        /*
                        update.Text = message.Text;
                        update.Date = message.Date;
                        */
                        update.IsCompleted = message.IsCompleted;
                        db.SaveChanges();
                    }
                    else
                    {
                        {
                            return "Not found";
                        }
                    }
                }
                return "Updated, Success!";
            }
            /*
            [HttpDelete]
            [Route("DeleteTask")]
            public
            */
          
    }
}
