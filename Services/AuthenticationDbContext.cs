using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sda.backend.minimalapi.Core.Auth.Models
{
    public class AuthenticationDbContext : IdentityDbContext<AuthenticationUser>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {
        }

        protected AuthenticationDbContext()
        {
        }
    }
}
