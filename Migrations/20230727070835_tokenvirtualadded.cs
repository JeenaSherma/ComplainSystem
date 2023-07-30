using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class tokenvirtualadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tokens_ComplainId",
                table: "tokens");

            migrationBuilder.CreateIndex(
                name: "IX_tokens_ComplainId",
                table: "tokens",
                column: "ComplainId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tokens_ComplainId",
                table: "tokens");

            migrationBuilder.CreateIndex(
                name: "IX_tokens_ComplainId",
                table: "tokens",
                column: "ComplainId");
        }
    }
}
