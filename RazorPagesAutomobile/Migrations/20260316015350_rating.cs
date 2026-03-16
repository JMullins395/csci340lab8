using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesAutomobile.Migrations
{
    /// <inheritdoc />
    public partial class rating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MSRP",
                table: "Automobile",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Bodystyle",
                table: "Automobile",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bodystyle",
                table: "Automobile");

            migrationBuilder.AlterColumn<decimal>(
                name: "MSRP",
                table: "Automobile",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }
    }
}
