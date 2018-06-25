using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketQueue> TicketQueues { get; set; }
        public DbSet<ConfigItemType> ConfigItemTypes { get; set; }
        public DbSet<ConfigItem> ConfigItems { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Client> Clients { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ticket>()
                .HasOne(t => t.CreatedBy)
                .WithMany(u => u.CreatedTickets)
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
                .HasOne(t => t.AssignedTo)
                .WithMany(u => u.AssignedTickets)
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
                .HasOne(t => t.TicketType)
                .WithMany(y => y.Tickets)
                .HasForeignKey(t => t.TicketTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
              .HasOne(t => t.TicketStatus)
              .WithMany(y => y.Tickets)
              .HasForeignKey(t => t.TicketStatusId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
              .HasOne(t => t.TicketPriority)
              .WithMany(y => y.Tickets)
              .HasForeignKey(t => t.TicketPriorityId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
             .HasOne(t => t.TicketQueue)
             .WithMany(y => y.Tickets)
             .HasForeignKey(t => t.TicketQueueId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
             .HasOne(t => t.ConfigItem)
             .WithMany(y => y.Tickets)
             .HasForeignKey(t => t.ClientId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
             .HasOne(t => t.Client)
             .WithMany(y => y.Tickets)
             .HasForeignKey(t => t.ClientId)
             .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
