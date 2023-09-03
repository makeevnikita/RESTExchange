using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rest_exchange.Migrations
{
    /// <inheritdoc />
    public partial class DeleteManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCurrencyPaymentMethod");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "ClientCurreny",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientCurreny_PaymentMethodId",
                table: "ClientCurreny",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCurreny_PaymentMethod_PaymentMethodId",
                table: "ClientCurreny",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCurreny_PaymentMethod_PaymentMethodId",
                table: "ClientCurreny");

            migrationBuilder.DropIndex(
                name: "IX_ClientCurreny_PaymentMethodId",
                table: "ClientCurreny");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "ClientCurreny");

            migrationBuilder.CreateTable(
                name: "ClientCurrencyPaymentMethod",
                columns: table => new
                {
                    ClientCurrenciesId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethodsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCurrencyPaymentMethod", x => new { x.ClientCurrenciesId, x.PaymentMethodsId });
                    table.ForeignKey(
                        name: "FK_ClientCurrencyPaymentMethod_ClientCurreny_ClientCurrenciesId",
                        column: x => x.ClientCurrenciesId,
                        principalTable: "ClientCurreny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCurrencyPaymentMethod_PaymentMethod_PaymentMethodsId",
                        column: x => x.PaymentMethodsId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCurrencyPaymentMethod_PaymentMethodsId",
                table: "ClientCurrencyPaymentMethod",
                column: "PaymentMethodsId");
        }
    }
}
