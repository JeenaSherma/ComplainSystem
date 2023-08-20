using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class branchadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_branches_municipalities_MunicipalityId",
                table: "branches");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipalityId",
                table: "branches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BranchNameInNepali",
                table: "branches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BranchNameInEnglish",
                table: "branches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BranchTypeId",
                table: "branches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficialWebsite",
                table: "branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WardId",
                table: "branches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "wards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchNameInEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchNameInNepali = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wards_municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_branches_BranchTypeId",
                table: "branches",
                column: "BranchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_branches_WardId",
                table: "branches",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_wards_MunicipalityId",
                table: "wards",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_branches_branchTypes_BranchTypeId",
                table: "branches",
                column: "BranchTypeId",
                principalTable: "branchTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_branches_municipalities_MunicipalityId",
                table: "branches",
                column: "MunicipalityId",
                principalTable: "municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_branches_wards_WardId",
                table: "branches",
                column: "WardId",
                principalTable: "wards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_branches_branchTypes_BranchTypeId",
                table: "branches");

            migrationBuilder.DropForeignKey(
                name: "FK_branches_municipalities_MunicipalityId",
                table: "branches");

            migrationBuilder.DropForeignKey(
                name: "FK_branches_wards_WardId",
                table: "branches");

            migrationBuilder.DropTable(
                name: "wards");

            migrationBuilder.DropIndex(
                name: "IX_branches_BranchTypeId",
                table: "branches");

            migrationBuilder.DropIndex(
                name: "IX_branches_WardId",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "BranchTypeId",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "OfficialWebsite",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "branches");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipalityId",
                table: "branches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BranchNameInNepali",
                table: "branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BranchNameInEnglish",
                table: "branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_branches_municipalities_MunicipalityId",
                table: "branches",
                column: "MunicipalityId",
                principalTable: "municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
