using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Sport.Data
{
    public class SportContextFactory : IDesignTimeDbContextFactory<SportContext>
    {
        public SportContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SportContext>();
            optionsBuilder.UseSqlServer();

            return new SportContext(optionsBuilder.Options);
        }
    }
}
