using DotNetCore_5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore_5.Data
{
    public class ApplicationDbContext :IdentityDbContext<IdentityUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<School> schools { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Class> classes { get; set; }
        public DbSet<GroupInfo> groupInfos { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Selection> selections { get; set; }
        public DbSet<ApplicationFrom> applicationFroms { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<SecBoard> SecBoards { get; set; }
        public DbSet<SlDetails> SlDetails { get; set; }
    }
}
