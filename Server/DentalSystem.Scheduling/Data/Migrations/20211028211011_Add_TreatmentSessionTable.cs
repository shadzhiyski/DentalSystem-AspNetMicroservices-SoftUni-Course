using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalSystem.Scheduling.Migrations
{
    public partial class Add_TreatmentSessionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreatmentSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DentalTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    End = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentSession_DentalTeam_DentalTeamId",
                        column: x => x.DentalTeamId,
                        principalTable: "DentalTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentSession_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentSession_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentSession_DentalTeamId",
                table: "TreatmentSession",
                column: "DentalTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentSession_PatientId",
                table: "TreatmentSession",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentSession_ReferenceId",
                table: "TreatmentSession",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentSession_TreatmentId",
                table: "TreatmentSession",
                column: "TreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentSession");
        }
    }
}
