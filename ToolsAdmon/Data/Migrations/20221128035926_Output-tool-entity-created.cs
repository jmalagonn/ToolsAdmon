using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Outputtoolentitycreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OutputToolId",
                table: "Tools",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OutputToolStates",
                columns: table => new
                {
                    OutputToolStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutputToolStateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputToolStates", x => x.OutputToolStateId);
                });

            migrationBuilder.CreateTable(
                name: "OutputTools",
                columns: table => new
                {
                    OutputToolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutputDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutputToolStateId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ResponsibleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputTools", x => x.OutputToolId);
                    table.ForeignKey(
                        name: "FK_OutputTools_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutputTools_OutputToolStates_OutputToolStateId",
                        column: x => x.OutputToolStateId,
                        principalTable: "OutputToolStates",
                        principalColumn: "OutputToolStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutputTools_Users_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OutputToolStates",
                columns: new[] { "OutputToolStateId", "OutputToolStateName" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Closed" }
                });

            migrationBuilder.UpdateData(
                table: "ToolStates",
                keyColumn: "ToolStateId",
                keyValue: 1,
                column: "ToolStateName",
                value: "Disponible");

            migrationBuilder.UpdateData(
                table: "ToolStates",
                keyColumn: "ToolStateId",
                keyValue: 2,
                column: "ToolStateName",
                value: "Con novedad");

            migrationBuilder.UpdateData(
                table: "ToolStates",
                keyColumn: "ToolStateId",
                keyValue: 3,
                column: "ToolStateName",
                value: "Prestado");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_OutputToolId",
                table: "Tools",
                column: "OutputToolId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputTools_CompanyId",
                table: "OutputTools",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputTools_OutputToolStateId",
                table: "OutputTools",
                column: "OutputToolStateId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputTools_ResponsibleId",
                table: "OutputTools",
                column: "ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_OutputTools_OutputToolId",
                table: "Tools",
                column: "OutputToolId",
                principalTable: "OutputTools",
                principalColumn: "OutputToolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_OutputTools_OutputToolId",
                table: "Tools");

            migrationBuilder.DropTable(
                name: "OutputTools");

            migrationBuilder.DropTable(
                name: "OutputToolStates");

            migrationBuilder.DropIndex(
                name: "IX_Tools_OutputToolId",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "OutputToolId",
                table: "Tools");

            migrationBuilder.UpdateData(
                table: "ToolStates",
                keyColumn: "ToolStateId",
                keyValue: 1,
                column: "ToolStateName",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "ToolStates",
                keyColumn: "ToolStateId",
                keyValue: 2,
                column: "ToolStateName",
                value: "Damaged");

            migrationBuilder.UpdateData(
                table: "ToolStates",
                keyColumn: "ToolStateId",
                keyValue: 3,
                column: "ToolStateName",
                value: "Lent");
        }
    }
}
