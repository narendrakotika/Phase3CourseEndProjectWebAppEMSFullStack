using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppEMSFullStack.Models;

namespace WebAppEMSFullStack.Data
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext (DbContextOptions<EmpDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppEMSFullStack.Models.EmpProfiles> EmpProfiles { get; set; } = default!;
    }
}
