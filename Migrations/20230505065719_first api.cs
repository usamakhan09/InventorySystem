using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventrySystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class firstapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemsQuantity = table.Column<int>(type: "int", nullable: false),
                    ItemsType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
