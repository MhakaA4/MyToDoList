using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MitchelleList.Models;

namespace MitchelleList.Infrastructure
{
    public class MitchelleListContext : DbContext
    {
        public MitchelleListContext(DbContextOptions<MitchelleListContext> options)
            :base(options)
        {
        }
        public DbSet<Models.todolist> todolist { get; set; }
    }
}
