using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class initDB2703 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StoreAdminAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    StaffStoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdminStoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_accounts_stores_AdminStoreID",
                        column: x => x.AdminStoreID,
                        principalTable: "stores",
                        principalColumn: "StoreID");
                    table.ForeignKey(
                        name: "FK_accounts_stores_StaffStoreID",
                        column: x => x.StaffStoreID,
                        principalTable: "stores",
                        principalColumn: "StoreID");
                });

            migrationBuilder.CreateTable(
                name: "wareHouses",
                columns: table => new
                {
                    WareHouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wareHouses", x => x.WareHouseID);
                    table.ForeignKey(
                        name: "FK_wareHouses_accounts_AdminAccountID",
                        column: x => x.AdminAccountID,
                        principalTable: "accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inStoreProducts",
                columns: table => new
                {
                    InStoreProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    WareHouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inStoreProducts", x => x.InStoreProductID);
                    table.ForeignKey(
                        name: "FK_inStoreProducts_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inStoreProducts_stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inStoreProducts_wareHouses_WareHouseID",
                        column: x => x.WareHouseID,
                        principalTable: "wareHouses",
                        principalColumn: "WareHouseID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_AdminStoreID",
                table: "accounts",
                column: "AdminStoreID",
                unique: true,
                filter: "[AdminStoreID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_StaffStoreID",
                table: "accounts",
                column: "StaffStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_inStoreProducts_ProductID",
                table: "inStoreProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_inStoreProducts_StoreID",
                table: "inStoreProducts",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_inStoreProducts_WareHouseID",
                table: "inStoreProducts",
                column: "WareHouseID");

            migrationBuilder.CreateIndex(
                name: "IX_wareHouses_AdminAccountID",
                table: "wareHouses",
                column: "AdminAccountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inStoreProducts");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "wareHouses");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "stores");
        }
    }
}
