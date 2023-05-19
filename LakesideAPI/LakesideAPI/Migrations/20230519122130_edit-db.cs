using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LakesideAPI.Migrations
{
    public partial class editdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "PhanHoi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "urlImage",
                table: "GioiThieu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "PhanHoi");

            migrationBuilder.DropColumn(
                name: "urlImage",
                table: "GioiThieu");
        }
    }
}
