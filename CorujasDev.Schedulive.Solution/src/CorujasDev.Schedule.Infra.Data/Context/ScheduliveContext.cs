using CorujasDev.Schedulive.Domain.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CorujasDev.Schedule.Infra.Data.Context
{
    public class ScheduliveContext : DbContext
    {
        public DbSet<UserDomain> Users { get; set; }

        public ScheduliveContext()
        {

        }

        public ScheduliveContext(DbContextOptions<ScheduliveContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Verifica se o contexto já não esta configurado, caso não eseja utiliza a string de conexão abaixo
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Schedulive;integrated security=true");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                        entry.Property("UpdateDate").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("CreatedDate").IsModified = false;
                        entry.Property("UpdateDate").CurrentValue = DateTime.Now;
                    }
                }

                return base.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduliveContext).Assembly);
        }
    }
}
