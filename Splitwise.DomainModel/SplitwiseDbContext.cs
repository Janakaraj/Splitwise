using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Splitwise.DomainModel
{
    public class SplitwiseDbContext : IdentityDbContext<User>
    {
        #region Properties
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Payer> Payers { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        #endregion
        #region Public methods
        public SplitwiseDbContext(DbContextOptions<SplitwiseDbContext> options) : base(options)
        {

        }
        #endregion
    }
}
