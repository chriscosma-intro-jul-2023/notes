using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDirectoryApi.Migrations
{
    /// <inheritdoc />
    public partial class AddlayoffscheduletoEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsScheduledForLayoff",
                table: "Employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsScheduledForLayoff",
                table: "Employees");
        }
    }
}
