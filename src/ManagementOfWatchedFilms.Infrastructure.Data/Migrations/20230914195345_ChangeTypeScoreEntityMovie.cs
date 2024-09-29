using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementOfWatchedFilms.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeScoreEntityMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserScore",
                schema: "domain",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "UserScore",
                schema: "domain",
                table: "Movies",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
