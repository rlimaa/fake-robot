using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeRobot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RobotCommandRecords",
                table: "RobotCommandRecords");

            migrationBuilder.RenameTable(
                name: "RobotCommandRecords",
                newName: "Executions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Executions",
                table: "Executions",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Executions",
                table: "Executions");

            migrationBuilder.RenameTable(
                name: "Executions",
                newName: "RobotCommandRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RobotCommandRecords",
                table: "RobotCommandRecords",
                column: "Id");
        }
    }
}
