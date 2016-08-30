using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcVehicle.Data.Migrations
{
    public partial class Transmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hybrid",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Vehicle",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hybrid",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Vehicle");
        }
    }
}
