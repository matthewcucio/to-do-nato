using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todoapp.Models;

namespace Todoapp.Data
{
    public class TodoappContext : DbContext
    {
        public TodoappContext (DbContextOptions<TodoappContext> options)
            : base(options)
        {
        }

        public DbSet<Todoapp.Models.ToDoItemModel> ToDoItemModel { get; set; } = default!;
    }
}
