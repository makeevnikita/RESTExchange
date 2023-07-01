using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rest_exchange.Migrations
{
    public partial class AddingNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCurreny_PaymentMethod_PaymentMethodId",
                table: "ClientCurreny");

            migrationBuilder.DropForeignKey(
                name: "FK_MyCurrency_PaymentMethod_PaymentMethodId",
                table: "MyCurrency");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodId",
                table: "MyCurrency",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodId",
                table: "ClientCurreny",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCurreny_PaymentMethod_PaymentMethodId",
                table: "ClientCurreny",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyCurrency_PaymentMethod_PaymentMethodId",
                table: "MyCurrency",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCurreny_PaymentMethod_PaymentMethodId",
                table: "ClientCurreny");

            migrationBuilder.DropForeignKey(
                name: "FK_MyCurrency_PaymentMethod_PaymentMethodId",
                table: "MyCurrency");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodId",
                table: "MyCurrency",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodId",
                table: "ClientCurreny",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCurreny_PaymentMethod_PaymentMethodId",
                table: "ClientCurreny",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MyCurrency_PaymentMethod_PaymentMethodId",
                table: "MyCurrency",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id");
        }
    }
}
