using Microsoft.EntityFrameworkCore.Migrations;

namespace RubSort.DataStorageSystem.SqlMigrations
{
    public partial class FixRecyclingPointCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeoCoordinate_Altitude",
                schema: "dbo",
                table: "RecyclingPoints");

            migrationBuilder.DropColumn(
                name: "GeoCoordinate_Course",
                schema: "dbo",
                table: "RecyclingPoints");

            migrationBuilder.DropColumn(
                name: "GeoCoordinate_HorizontalAccuracy",
                schema: "dbo",
                table: "RecyclingPoints");

            migrationBuilder.DropColumn(
                name: "GeoCoordinate_Speed",
                schema: "dbo",
                table: "RecyclingPoints");

            migrationBuilder.DropColumn(
                name: "GeoCoordinate_VerticalAccuracy",
                schema: "dbo",
                table: "RecyclingPoints");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GeoCoordinate_Altitude",
                schema: "dbo",
                table: "RecyclingPoints",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GeoCoordinate_Course",
                schema: "dbo",
                table: "RecyclingPoints",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GeoCoordinate_HorizontalAccuracy",
                schema: "dbo",
                table: "RecyclingPoints",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GeoCoordinate_Speed",
                schema: "dbo",
                table: "RecyclingPoints",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GeoCoordinate_VerticalAccuracy",
                schema: "dbo",
                table: "RecyclingPoints",
                type: "double precision",
                nullable: true);
        }
    }
}
