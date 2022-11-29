using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Outputtoolscreatedbycolumnadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "OutputTools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OutputTools_CreatedById",
                table: "OutputTools",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputTools_Users_CreatedById",
                table: "OutputTools",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutputTools_Users_CreatedById",
                table: "OutputTools");

            migrationBuilder.DropIndex(
                name: "IX_OutputTools_CreatedById",
                table: "OutputTools");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "OutputTools");
        }
    }
}
