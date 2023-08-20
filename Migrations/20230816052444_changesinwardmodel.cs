using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class changesinwardmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "wards");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "wards");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "wards");

            migrationBuilder.RenameColumn(
                name: "BranchNameInNepali",
                table: "wards",
                newName: "WardNameInNepali");

            migrationBuilder.RenameColumn(
                name: "BranchNameInEnglish",
                table: "wards",
                newName: "WardNameInEnglish");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WardNameInNepali",
                table: "wards",
                newName: "BranchNameInNepali");

            migrationBuilder.RenameColumn(
                name: "WardNameInEnglish",
                table: "wards",
                newName: "BranchNameInEnglish");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "wards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "wards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "wards",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
