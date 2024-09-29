using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementOfWatchedFilms.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntityMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Watched",
                schema: "domain",
                table: "Movies",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "UserScore",
                schema: "domain",
                table: "Movies",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Watched",
                schema: "domain",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "UserScore",
                schema: "domain",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
