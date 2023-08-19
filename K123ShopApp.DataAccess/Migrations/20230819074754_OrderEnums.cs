using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace K123ShopApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrderEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderEnum",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderEnum",
                table: "Orders");
        }
    }
}
