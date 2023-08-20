using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class virtualdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_qRinfos_MunicipalityId",
                table: "qRinfos");

            migrationBuilder.CreateIndex(
                name: "IX_qRinfos_MunicipalityId",
                table: "qRinfos",
                column: "MunicipalityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_qRinfos_MunicipalityId",
                table: "qRinfos");

            migrationBuilder.CreateIndex(
                name: "IX_qRinfos_MunicipalityId",
                table: "qRinfos",
                column: "MunicipalityId",
                unique: true);
        }
    }
}
