using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Requests
{
    public class GetTaskResponse
    { 

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public bool IsCompleted { get; set; }
    }
}
