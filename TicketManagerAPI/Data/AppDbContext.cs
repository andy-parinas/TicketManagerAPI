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
        //public DbSet<TicketStatus> TicketStatuses { get; set; }
        //public DbSet<TicketPriority> TicketPriorities { get; set; }


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
        }

    }
}
