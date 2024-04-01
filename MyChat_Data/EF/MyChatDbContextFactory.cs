using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Data.EF
{
    public class MyChatDbContextFactory : IDesignTimeDbContextFactory<MyChatDbContext>
    {
        public MyChatDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var conectionString = configuration.GetConnectionString("MyChatDb");

            var optionBuilder = new DbContextOptionsBuilder<MyChatDbContext>();
            optionBuilder.UseSqlServer(conectionString);

            return new MyChatDbContext(optionBuilder.Options);
        }
    }
}
