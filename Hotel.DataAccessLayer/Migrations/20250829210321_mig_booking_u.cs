using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_booking_u : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desription",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Desription",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
