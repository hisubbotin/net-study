using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context (DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.Models.Student> Student { get; set; }
    }
}
