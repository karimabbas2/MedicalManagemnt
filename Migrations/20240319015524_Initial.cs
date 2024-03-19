using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnoManagment.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeVacations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<int>(type: "int", nullable: false),
                    SubmissionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VDateFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    VDateTo = table.Column<DateOnly>(type: "date", nullable: false),
                    Returning = table.Column<DateOnly>(type: "date", nullable: false),
                    CountedDays = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVacations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeVacations");
        }
    }
}
