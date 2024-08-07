using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vodorod.test.task.data.access.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RateEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cur_OfficialRate = table.Column<decimal>(type: "numeric", nullable: false),
                    Cur_Abbreviation = table.Column<string>(type: "text", nullable: false),
                    Cur_Scale = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateEntity", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateEntity");
        }
    }
}
