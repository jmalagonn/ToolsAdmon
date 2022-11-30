using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Connectionstringchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_OutputTools_OutputToolId",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_Tools_OutputToolId",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "OutputToolId",
                table: "Tools");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OutputToolId",
                table: "Tools",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tools_OutputToolId",
                table: "Tools",
                column: "OutputToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_OutputTools_OutputToolId",
                table: "Tools",
                column: "OutputToolId",
                principalTable: "OutputTools",
                principalColumn: "OutputToolId");
        }
    }
}
