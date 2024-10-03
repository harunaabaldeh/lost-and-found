using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaceFound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlaceFound",
                table: "LostDocuments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceFound",
                table: "LostDocuments");
        }
    }
}
