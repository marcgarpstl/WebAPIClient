using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class ServieDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAvalible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalServices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalServices");
        }
    }
}
