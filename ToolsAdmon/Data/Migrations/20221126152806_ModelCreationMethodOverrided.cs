using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelCreationMethodOverrided : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToolStates",
                columns: new[] { "ToolStateId", "ToolStateName" },
                values: new object[,]
                {
                    { 1, "Available" },
                    { 2, "Damaged" },
                    { 3, "Lent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToolStates",
                keyColumn: "ToolStateId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToolStates",
                keyColumn: "ToolStateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToolStates",
                keyColumn: "ToolStateId",
                keyValue: 3);
        }
    }
}
