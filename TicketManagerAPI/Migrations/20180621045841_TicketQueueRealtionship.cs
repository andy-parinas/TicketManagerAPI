using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TicketManagerAPI.Migrations
{
    public partial class TicketQueueRealtionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketQueueId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketQueueId",
                table: "Tickets",
                column: "TicketQueueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketQueues_TicketQueueId",
                table: "Tickets",
                column: "TicketQueueId",
                principalTable: "TicketQueues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketQueues_TicketQueueId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketQueueId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketQueueId",
                table: "Tickets");
        }
    }
}
