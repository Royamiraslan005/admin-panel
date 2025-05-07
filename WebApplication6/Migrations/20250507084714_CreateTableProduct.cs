using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "categories");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
