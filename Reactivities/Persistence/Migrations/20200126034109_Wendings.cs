using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Wendings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RunBuilds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RunFirst = table.Column<DateTime>(nullable: false),
                    Run = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsEnbale = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunBuilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wendings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    MyGroom = table.Column<string>(nullable: true),
                    MyBride = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    IsEnbale = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wendings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunBuilds");

            migrationBuilder.DropTable(
                name: "Wendings");
        }
    }
}
