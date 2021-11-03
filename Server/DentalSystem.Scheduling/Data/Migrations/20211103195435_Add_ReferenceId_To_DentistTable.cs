using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalSystem.Scheduling.Migrations
{
    public partial class Add_ReferenceId_To_DentistTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReferenceId",
                table: "Dentist",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Dentist_ReferenceId",
                table: "Dentist",
                column: "ReferenceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dentist_ReferenceId",
                table: "Dentist");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Dentist");
        }
    }
}
