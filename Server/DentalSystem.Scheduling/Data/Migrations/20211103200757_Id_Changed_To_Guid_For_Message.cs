using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalSystem.Scheduling.Migrations
{
    public partial class Id_Changed_To_Guid_For_Message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Messages", table: "Messages");
            migrationBuilder.DropColumn(name: "Id", table: "Messages");
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false);
            migrationBuilder.AddPrimaryKey(name: "PK_Messages", table: "Messages", "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Messages", table: "Messages");
            migrationBuilder.DropColumn(name: "Id", table: "Messages");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Messages",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey(name: "PK_Messages", table: "Messages", "Id");
        }
    }
}
