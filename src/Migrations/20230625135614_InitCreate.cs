using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace rest_exchange.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCurrency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Network",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientCurrencyNetwork",
                columns: table => new
                {
                    ClientCurrenciesId = table.Column<int>(type: "integer", nullable: false),
                    NetworksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCurrencyNetwork", x => new { x.ClientCurrenciesId, x.NetworksId });
                    table.ForeignKey(
                        name: "FK_ClientCurrencyNetwork_ClientCurrency_ClientCurrenciesId",
                        column: x => x.ClientCurrenciesId,
                        principalTable: "ClientCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCurrencyNetwork_Network_NetworksId",
                        column: x => x.NetworksId,
                        principalTable: "Network",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Fund = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCurrency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyCurrency_ClientCurrency_Id",
                        column: x => x.Id,
                        principalTable: "ClientCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyCurrency_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<int>(type: "integer", maxLength: 256, nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    NetworkId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyAddress_MyCurrency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "MyCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyAddress_Network_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Network",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    RandomString = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GiveSum = table.Column<decimal>(type: "numeric", nullable: false),
                    ReceiveSum = table.Column<decimal>(type: "numeric", nullable: false),
                    MyCurrencyId = table.Column<int>(type: "integer", nullable: false),
                    ClientCurrencyId = table.Column<int>(type: "integer", nullable: false),
                    GiveNetworkId = table.Column<int>(type: "integer", nullable: false),
                    ReceiveNetworkId = table.Column<int>(type: "integer", nullable: false),
                    ClientName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ClientAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    MyAddressId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_ClientCurrency_ClientCurrencyId",
                        column: x => x.ClientCurrencyId,
                        principalTable: "ClientCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_MyAddress_MyAddressId",
                        column: x => x.MyAddressId,
                        principalTable: "MyAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_MyCurrency_MyCurrencyId",
                        column: x => x.MyCurrencyId,
                        principalTable: "MyCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Network_GiveNetworkId",
                        column: x => x.GiveNetworkId,
                        principalTable: "Network",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Network_ReceiveNetworkId",
                        column: x => x.ReceiveNetworkId,
                        principalTable: "Network",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCurrencyNetwork_NetworksId",
                table: "ClientCurrencyNetwork",
                column: "NetworksId");

            migrationBuilder.CreateIndex(
                name: "IX_MyAddress_CurrencyId",
                table: "MyAddress",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MyAddress_NetworkId",
                table: "MyAddress",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_MyCurrency_PaymentMethodId",
                table: "MyCurrency",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientCurrencyId",
                table: "Order",
                column: "ClientCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_GiveNetworkId",
                table: "Order",
                column: "GiveNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MyAddressId",
                table: "Order",
                column: "MyAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MyCurrencyId",
                table: "Order",
                column: "MyCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ReceiveNetworkId",
                table: "Order",
                column: "ReceiveNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCurrencyNetwork");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MyAddress");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "MyCurrency");

            migrationBuilder.DropTable(
                name: "Network");

            migrationBuilder.DropTable(
                name: "ClientCurrency");

            migrationBuilder.DropTable(
                name: "PaymentMethod");
        }
    }
}
