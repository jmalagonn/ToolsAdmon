using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ToolStateEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToolStateId",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ToolStates",
                columns: table => new
                {
                    ToolStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolStateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolStates", x => x.ToolStateId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ToolStateId",
                table: "Tools",
                column: "ToolStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_ToolStates_ToolStateId",
                table: "Tools",
                column: "ToolStateId",
                principalTable: "ToolStates",
                principalColumn: "ToolStateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_ToolStates_ToolStateId",
                table: "Tools");

            migrationBuilder.DropTable(
                name: "ToolStates");

            migrationBuilder.DropIndex(
                name: "IX_Tools_ToolStateId",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "ToolStateId",
                table: "Tools");
        }
    }
}
