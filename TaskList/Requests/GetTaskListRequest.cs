using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Requests
{
    public class GetTaskListRequest
    {
        public bool IsCompleted { get; set; }
    }
}
