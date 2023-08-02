using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class nametointofcomplainstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "complainStatus",
                table: "complains");

            migrationBuilder.AddColumn<int>(
                name: "complainStatusId",
                table: "complains",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "complainStatusId",
                table: "complains");

            migrationBuilder.AddColumn<string>(
                name: "complainStatus",
                table: "complains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
