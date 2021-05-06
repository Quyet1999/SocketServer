using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SocketServer.Model
{
    public partial class Models : DbContext
    {
        public Models()
            : base("name=Models")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<HistoryUser> HistoryUsers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.StudentCode)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Computer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Computer>()
                .Property(e => e.Mac_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Computer>()
                .Property(e => e.IP_Address)
                .IsUnicode(false);
        }
    }
}
