using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Config
{
    public class ContextBaseApp : IdentityDbContext<ApplicationUser>
    {

        public ContextBaseApp(DbContextOptions<ContextBaseApp> options) : base(options)
        {

        }
    }
}
