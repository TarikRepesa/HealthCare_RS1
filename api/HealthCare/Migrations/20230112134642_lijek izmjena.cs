using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class lijekizmjena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jacina",
                table: "Lijek");

            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Lijek");

            migrationBuilder.AlterColumn<double>(
                name: "Cijena",
                table: "Lijek",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<double>(
                name: "KolicinaNaStanju",
                table: "Lijek",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Nuspojave",
                table: "Lijek",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Upozorenja",
                table: "Lijek",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KolicinaNaStanju",
                table: "Lijek");

            migrationBuilder.DropColumn(
                name: "Nuspojave",
                table: "Lijek");

            migrationBuilder.DropColumn(
                name: "Upozorenja",
                table: "Lijek");

            migrationBuilder.AlterColumn<float>(
                name: "Cijena",
                table: "Lijek",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<float>(
                name: "Jacina",
                table: "Lijek",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "Lijek",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
