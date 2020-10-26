using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel
{
    public class SplitwiseDbContext : IdentityDbContext<User>
    {
        public SplitwiseDbContext(DbContextOptions<SplitwiseDbContext> options) : base(options)
        {

        }
        public DbSet<Group> Group { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Payer> Payer { get; set; }
        public DbSet<Payee> Payee { get; set; }
        public DbSet<Settlement> Settlement { get; set; }
    }
}
