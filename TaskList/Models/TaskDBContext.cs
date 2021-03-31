using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Models
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {

        }

        public DbSet<Task1> Tasks { get; set; }
        public IEnumerable<object> Task1 { get; internal set; }

    }
}
