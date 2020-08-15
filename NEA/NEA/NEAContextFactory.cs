using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA
{
    public class NEAContextFactory : IDesignTimeDbContextFactory<NEAContext>
    {
        public NEAContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NEAContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NEA;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new NEAContext(optionsBuilder.Options);
        }
    }
}
