using System;
using Microsoft.EntityFrameworkCore;
using TestPermitMicroAPI.Models;

namespace TestPermitMicroAPI.Data
{
    public class TestPermitMicroAPIContext : DbContext
    {
        public TestPermitMicroAPIContext(DbContextOptions<TestPermitMicroAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TPTestPermit> TPTestPermits { get; set; }
    }
}
