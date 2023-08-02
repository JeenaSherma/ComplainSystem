using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class complainstsforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "complainStatusId",
                table: "complains",
                newName: "ComplainStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_complains_ComplainStatusId",
                table: "complains",
                column: "ComplainStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_complains_complainStatuses_ComplainStatusId",
                table: "complains",
                column: "ComplainStatusId",
                principalTable: "complainStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_complains_complainStatuses_ComplainStatusId",
                table: "complains");

            migrationBuilder.DropIndex(
                name: "IX_complains_ComplainStatusId",
                table: "complains");

            migrationBuilder.RenameColumn(
                name: "ComplainStatusId",
                table: "complains",
                newName: "complainStatusId");
        }
    }
}
