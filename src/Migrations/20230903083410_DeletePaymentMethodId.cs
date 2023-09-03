using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rest_exchange.Migrations
{
    /// <inheritdoc />
    public partial class DeletePaymentMethodId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "ClientCurreny");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "ClientCurreny",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
