using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorujasDev.Schedule.Infra.Data.Migrations
{
    public partial class CreatetableLives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lives",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Thumbnail = table.Column<string>(type: "VARCHAR(350)", nullable: false),
                    Description = table.Column<string>(type: "Text", nullable: false),
                    Place = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "DateTime2(7)", nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lives_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lives_CategoryId",
                table: "Lives",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lives");
        }
    }
}
