using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    //Install-package Microsoft.EntityFrameworkCore
    //Install-package Microsoft.EntityFrameworkCore.SqlServer
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }
        public DbSet<User> UesrList { get; set; }
    }
}
