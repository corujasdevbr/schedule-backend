using Microsoft.EntityFrameworkCore.Migrations;

namespace CorujasDev.Schedule.Infra.Data.Migrations
{
    public partial class UpdatetableUserTypeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeUser",
                table: "Users",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeUser",
                table: "Users");
        }
    }
}
