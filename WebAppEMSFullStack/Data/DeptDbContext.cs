using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppEMSFullStack.Models;

namespace WebAppEMSFullStack.Data
{
    public class DeptDbContext : DbContext
    {
        public DeptDbContext (DbContextOptions<DeptDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppEMSFullStack.Models.DeptMaster> DeptMaster { get; set; } = default!;
    }
}
