using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace K123ShopApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginAttempt",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginAttempt",
                table: "Users");
        }
    }
}
