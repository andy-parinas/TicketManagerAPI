﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TicketManagerAPI.Data;

namespace TicketManagerAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketManagerAPI.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("ClientTypeId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientTypeId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TicketManagerAPI.Models.ClientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ClientTypes");
                });

            modelBuilder.Entity("TicketManagerAPI.Models.ConfigItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<int>("ConfigItemTypeId");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ConfigItemTypeId");

                    b.ToTable("ConfigItems");
                });

            modelBuilder.Entity("TicketManagerAPI.Models.ConfigItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ConfigItemTypes");
                });

            modelBuilder.Entity("TicketManagerAPI.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssignedToId");

                    b.Property<int>("ClientId");

                    b.Property<int>("ConfigItemId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedById");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Details")
                        .IsRequired();

                    b.Property<string>("Number")
                        .IsRequired();

                    b.Property<int>("TicketPriorityId");

                    b.Property<int>("TicketQueueId");

                    b.Property<int>("TicketStatusId");

                    b.Property<int>("TicketTypeId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("TicketPriorityId");

                    b.HasIndex("TicketQueueId");

                    b.HasIndex("TicketStatusId");

                    b.HasIndex("TicketTypeId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketManagerAPI.Models.TicketPriority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FirstResponseMinutes");

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ResolutionHours");

                    b.HasKey("Id");

                    b.ToTable("TicketPriorities");
                });

            modelBuilder.Entity("TicketManagerAPI.Models.TicketQueue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("TicketQueues");
                });

            modelBuilder.Entity("TicketManagerAPI.Models.TicketStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TicketStatus");
                });

            modelBuilder.Entity("TicketManagerAPI.Models.TicketType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("TicketManagerAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TicketManagerAPI.Models.Client", b =>
                {
                    b.HasOne("TicketManagerAPI.Models.ClientType", "ClientType")
                        .WithMany("Clients")
                        .HasForeignKey("ClientTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketManagerAPI.Models.ConfigItem", b =>
                {
                    b.HasOne("TicketManagerAPI.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketManagerAPI.Models.ConfigItemType", "ConfigItemType")
                        .WithMany("ConfigItems")
                        .HasForeignKey("ConfigItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketManagerAPI.Models.Ticket", b =>
                {
                    b.HasOne("TicketManagerAPI.Models.User", "AssignedTo")
                        .WithMany("AssignedTickets")
                        .HasForeignKey("AssignedToId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TicketManagerAPI.Models.Client", "Client")
                        .WithMany("Tickets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TicketManagerAPI.Models.ConfigItem", "ConfigItem")
                        .WithMany("Tickets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TicketManagerAPI.Models.User", "CreatedBy")
                        .WithMany("CreatedTickets")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TicketManagerAPI.Models.TicketPriority", "TicketPriority")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketPriorityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TicketManagerAPI.Models.TicketQueue", "TicketQueue")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketQueueId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TicketManagerAPI.Models.TicketStatus", "TicketStatus")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketStatusId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TicketManagerAPI.Models.TicketType", "TicketType")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
