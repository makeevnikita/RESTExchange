using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rest_exchange.Migrations
{
    public partial class AlterNetwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NetworkId",
                table: "MyCurrency",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MyCurrency_NetworkId",
                table: "MyCurrency",
                column: "NetworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyCurrency_Network_NetworkId",
                table: "MyCurrency",
                column: "NetworkId",
                principalTable: "Network",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyCurrency_Network_NetworkId",
                table: "MyCurrency");

            migrationBuilder.DropIndex(
                name: "IX_MyCurrency_NetworkId",
                table: "MyCurrency");

            migrationBuilder.DropColumn(
                name: "NetworkId",
                table: "MyCurrency");
        }
    }
}
