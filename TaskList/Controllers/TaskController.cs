using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using TaskList.Models;
using TaskList.Requests;
using System.Text.Json;
using System.Web.Http;
using Microsoft.AspNetCore.Cors;

namespace TaskList.Controllers
{
   
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/TaskController")]
    public class TaskController : ControllerBase
    {

            private readonly TaskDBContext db;
            public TaskController(TaskDBContext db)
            {
                
                this.db = db;
            }

            [Microsoft.AspNetCore.Mvc.HttpGet]
            [Microsoft.AspNetCore.Mvc.Route("getTaskList")]
       
        public List<GetTaskListResponse> GetTaskLists(bool IsCompleted)
            {
                return db.Tasks.Where(s=>s.IsCompleted == IsCompleted).Select(x => new GetTaskListResponse
                {
                    Id = x.Id,
                    Text = x.Text,
                    Date = x.Date,
                    IsCompleted = x.IsCompleted,
                }).ToList();
            }

        [EnableCors("Policy1")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("PostTask")]
        public object PostTask([Microsoft.AspNetCore.Mvc.FromBody] PostTaskRequest message)
        {
            var item = new Task1
            {
                Text = message.Text,
                Date = message.Date,
                IsCompleted = message.IsCompleted,
            };
                db.Tasks.Add(item);
                db.SaveChanges();
            return item;

            }

            [Microsoft.AspNetCore.Mvc.HttpGet]
            [Microsoft.AspNetCore.Mvc.Route("GetTask")]
        public GetTaskResponse GetTask([Microsoft.AspNetCore.Mvc.FromBody] GetTaskRequest message)
            {
                var task = db.Tasks.FirstOrDefault(x => x.Id == message.Id);
                var response = new GetTaskResponse();
                response.Text = task.Text;
                response.Date = task.Date;
                response.IsCompleted = task.IsCompleted;
                return response;
            }

            [Microsoft.AspNetCore.Mvc.HttpPut]
            [Microsoft.AspNetCore.Mvc.Route("PutTaskIsCompleted")]
        public string PutTaskIsCompleted([Microsoft.AspNetCore.Mvc.FromBody] PutTaskRequest message)
            {
                var task = db.Tasks.FirstOrDefault(x => x.Id == message.Id);
                
                    if (task != null)
                    {
                        task.IsCompleted = true;
                        db.SaveChanges();
                    }
                    else
                    {
                        {
                            return "Not found";
                        }
                    }
                
                return "Updated, Success!";
            }
            

            [Microsoft.AspNetCore.Mvc.HttpDelete]
            
            [Microsoft.AspNetCore.Mvc.Route("DeleteTask")]
       
        public string DeleteTask([Microsoft.AspNetCore.Mvc.FromBody]  DeleteTaskRequest taskId)
            {

                
                    /*
                    var task = db.Tasks.Where(s => s.Id == id);
                    db.Tasks.Remove(task);
                    */
                    var task = db.Tasks.Single(x => x.Id == taskId.Id);
                    db.Tasks.Remove(task);
                    db.SaveChanges();


               

                return "Task deleted";

            }
        

    }
}
