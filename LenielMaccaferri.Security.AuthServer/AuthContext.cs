using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LenielMaccaferri.Security.AuthServer
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
        {

        }

        public AuthContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }
    }

}