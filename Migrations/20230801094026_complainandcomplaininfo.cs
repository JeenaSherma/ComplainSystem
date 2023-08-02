using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class complainandcomplaininfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "complains");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "complains");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "complains");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "complains");

            migrationBuilder.DropColumn(
                name: "ComplainerEmail",
                table: "complainerInfos");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "complains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "complainerInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "complainerInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "complainerInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "complainerInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_complains_CategoryId",
                table: "complains",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_complains_categories_CategoryId",
                table: "complains",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_complains_categories_CategoryId",
                table: "complains");

            migrationBuilder.DropIndex(
                name: "IX_complains_CategoryId",
                table: "complains");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "complains");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "complainerInfos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "complainerInfos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "complainerInfos");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "complainerInfos");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "complains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "complains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "complains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "complains",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainerEmail",
                table: "complainerInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
