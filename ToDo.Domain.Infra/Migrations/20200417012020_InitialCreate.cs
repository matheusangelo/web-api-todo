using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Domain.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TODO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TITLE = table.Column<string>(type: "varchar(150)", nullable: false),
                    DONE = table.Column<bool>(type: "bit", nullable: false),
                    DATE = table.Column<DateTime>(nullable: false),
                    USER = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TODO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TODO");
        }
    }
}
