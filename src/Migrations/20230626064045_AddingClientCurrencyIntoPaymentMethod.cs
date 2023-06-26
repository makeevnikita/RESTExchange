using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rest_exchange.Migrations
{
    public partial class AddingClientCurrencyIntoPaymentMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "ClientCurreny",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientCurreny_PaymentMethodId",
                table: "ClientCurreny",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCurreny_PaymentMethod_PaymentMethodId",
                table: "ClientCurreny",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id");
        }

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
        }
    }
}
