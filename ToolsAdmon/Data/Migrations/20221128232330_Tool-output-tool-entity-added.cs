using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tooloutputtoolentityadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToolOutputTools",
                columns: table => new
                {
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    OutputToolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolOutputTools", x => new { x.ToolId, x.OutputToolId });
                    table.ForeignKey(
                        name: "FK_ToolOutputTools_OutputTools_OutputToolId",
                        column: x => x.OutputToolId,
                        principalTable: "OutputTools",
                        principalColumn: "OutputToolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToolOutputTools_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "ToolId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToolOutputTools_OutputToolId",
                table: "ToolOutputTools",
                column: "OutputToolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToolOutputTools");
        }
    }
}
