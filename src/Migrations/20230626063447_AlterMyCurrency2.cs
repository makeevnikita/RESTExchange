using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace rest_exchange.Migrations
{
    public partial class AlterMyCurrency2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCurrencyNetwork_ClientCurrency_ClientCurrenciesId",
                table: "ClientCurrencyNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_MyCurrency_ClientCurrency_Id",
                table: "MyCurrency");

            migrationBuilder.DropForeignKey(
                name: "FK_MyCurrency_Network_NetworkId",
                table: "MyCurrency");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ClientCurrency_ClientCurrencyId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_MyCurrency_NetworkId",
                table: "MyCurrency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCurrency",
                table: "ClientCurrency");

            migrationBuilder.DropColumn(
                name: "NetworkId",
                table: "MyCurrency");

            migrationBuilder.RenameTable(
                name: "ClientCurrency",
                newName: "ClientCurreny");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MyCurrency",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "MyCurrency",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MyCurrency",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "MyCurrency",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCurreny",
                table: "ClientCurreny",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MyCurrencyNetwork",
                columns: table => new
                {
                    MyCurrenciesId = table.Column<int>(type: "integer", nullable: false),
                    NetworksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCurrencyNetwork", x => new { x.MyCurrenciesId, x.NetworksId });
                    table.ForeignKey(
                        name: "FK_MyCurrencyNetwork_MyCurrency_MyCurrenciesId",
                        column: x => x.MyCurrenciesId,
                        principalTable: "MyCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyCurrencyNetwork_Network_NetworksId",
                        column: x => x.NetworksId,
                        principalTable: "Network",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyCurrencyNetwork_NetworksId",
                table: "MyCurrencyNetwork",
                column: "NetworksId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCurrencyNetwork_ClientCurreny_ClientCurrenciesId",
                table: "ClientCurrencyNetwork",
                column: "ClientCurrenciesId",
                principalTable: "ClientCurreny",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ClientCurreny_ClientCurrencyId",
                table: "Order",
                column: "ClientCurrencyId",
                principalTable: "ClientCurreny",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCurrencyNetwork_ClientCurreny_ClientCurrenciesId",
                table: "ClientCurrencyNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ClientCurreny_ClientCurrencyId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "MyCurrencyNetwork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCurreny",
                table: "ClientCurreny");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "MyCurrency");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MyCurrency");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "MyCurrency");

            migrationBuilder.RenameTable(
                name: "ClientCurreny",
                newName: "ClientCurrency");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MyCurrency",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "NetworkId",
                table: "MyCurrency",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCurrency",
                table: "ClientCurrency",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MyCurrency_NetworkId",
                table: "MyCurrency",
                column: "NetworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCurrencyNetwork_ClientCurrency_ClientCurrenciesId",
                table: "ClientCurrencyNetwork",
                column: "ClientCurrenciesId",
                principalTable: "ClientCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyCurrency_ClientCurrency_Id",
                table: "MyCurrency",
                column: "Id",
                principalTable: "ClientCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyCurrency_Network_NetworkId",
                table: "MyCurrency",
                column: "NetworkId",
                principalTable: "Network",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ClientCurrency_ClientCurrencyId",
                table: "Order",
                column: "ClientCurrencyId",
                principalTable: "ClientCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
