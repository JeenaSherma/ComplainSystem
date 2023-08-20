using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class municipilitiesandruralmunicipalityadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfWards",
                table: "municipalities");

            migrationBuilder.DropColumn(
                name: "WardName",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "WardNumber",
                table: "branches");

            migrationBuilder.RenameColumn(
                name: "MunicipalityName",
                table: "municipalities",
                newName: "MunicipalityNameInNepali");

            migrationBuilder.AddColumn<string>(
                name: "MunicipalityNameInEnglish",
                table: "municipalities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BranchNameInEnglish",
                table: "branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BranchNameInNepali",
                table: "branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MunicipalityNameInEnglish",
                table: "municipalities");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "BranchNameInEnglish",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "BranchNameInNepali",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "branches");

            migrationBuilder.RenameColumn(
                name: "MunicipalityNameInNepali",
                table: "municipalities",
                newName: "MunicipalityName");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfWards",
                table: "municipalities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WardName",
                table: "branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WardNumber",
                table: "branches",
                type: "int",
                nullable: true);
        }
    }
}
