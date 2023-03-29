using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class UpdateDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wareHouses_accounts_AdminAccountID",
                table: "wareHouses");

            migrationBuilder.DropIndex(
                name: "IX_wareHouses_AdminAccountID",
                table: "wareHouses");

            migrationBuilder.DropColumn(
                name: "AdminAccountID",
                table: "wareHouses");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderID);
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "AccountID", "AccountStatus", "AdminStoreID", "Password", "Role", "StaffStoreID", "Username" },
                values: new object[,]
                {
                    { new Guid("3802d434-b94e-4aab-b4c0-91acfc298c47"), 0, null, "wowsuchmath", 2, null, "einstein" },
                    { new Guid("9fc8a324-fe80-4b48-b106-273d511bf0f4"), 0, null, "bobthebob", 2, null, "bobross" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductID", "Category", "Price", "ProductName" },
                values: new object[,]
                {
                    { new Guid("0314642e-0eda-473a-9f1e-487acea7b191"), "Bedroom Furniture", 200.0, "Nightstand" },
                    { new Guid("2ed1ddce-f6b7-4f50-8636-954aad785bda"), "Bedroom Furniture", 800.0, "Mattress" },
                    { new Guid("57acf196-c71c-49b0-aad1-a1fe004f23fe"), "Living Room Furniture", 1500.0, "Sofa Set" },
                    { new Guid("7f19b793-7023-4751-bcae-b8c25688beef"), "Dining Room Furniture", 1200.0, "Dining Table" },
                    { new Guid("870bd28d-2b95-4e23-b0f9-0db46e924a87"), "Dining Room Furniture", 1500.0, "Japan Cabinet" },
                    { new Guid("8b36a544-4377-40c7-bb36-7471c14fe502"), "Living Room Furniture", 300.0, "Coffee Table" },
                    { new Guid("b54d41b5-e213-41ba-8435-b7f3d6234fa7"), "Dining Room Furniture", 150.0, "Dining Chair" },
                    { new Guid("bd614703-badc-4d12-970a-27c64b59847b"), "Bedroom Furniture", 1000.0, "Bed Frame" },
                    { new Guid("c1b0c347-ffd4-466e-8966-0fb02971b4ca"), "Home Office Furniture", 1000.0, "Bookcase" },
                    { new Guid("f32f6db0-fa3d-44b3-98e3-39b2ffc0afc7"), "Living Room Furniture", 500.0, "Armchair" }
                });

            migrationBuilder.InsertData(
                table: "stores",
                columns: new[] { "StoreID", "Location", "Status", "StoreAdminAccountID", "StoreName" },
                values: new object[,]
                {
                    { new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"), "New York", 0, new Guid("8f7b3e92-3c7e-4b1d-a7a1-1f1c7d2f2a2a"), "Classy Furniture" },
                    { new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"), "Los Angeles", 0, new Guid("1f7d3e82-4c8f-5b2e-b2c0-2f2d8c1e1d1d"), "Artisan Furniture" }
                });

            migrationBuilder.InsertData(
                table: "wareHouses",
                columns: new[] { "WareHouseID", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("c4b89d97-95c7-4d97-bf8a-3cb3e2b058e3"), "Chicago", "Chicago South Warehouse #9" },
                    { new Guid("d1c7f3ab-3f18-46c9-9a0b-25e16f80bf7f"), "Miami", "Miami Dock Warehouse" }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "AccountID", "AccountStatus", "AdminStoreID", "Password", "Role", "StaffStoreID", "Username" },
                values: new object[,]
                {
                    { new Guid("1f7d3e82-4c8f-5b2e-b2c0-2f2d8c1e1d1d"), 0, new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"), "654321", 0, null, "admin2" },
                    { new Guid("7f6e5d4c-3b2a-1f0e-d9c8-7654a3210b1c"), 0, null, "Football123", 1, new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"), "davidlee" },
                    { new Guid("8f7b3e92-3c7e-4b1d-a7a1-1f1c7d2f2a2a"), 0, new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"), "123456", 0, null, "admin1" },
                    { new Guid("a5b6c7d8-e9f0-1a2b-3c4d-5e6f7a8b9c0d"), 0, null, "12345678", 1, new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"), "johndoe" },
                    { new Guid("b4e3c2d1-f0e9-d8c7-b6a5-4193f8271c36"), 0, null, "qwertyuiop", 1, new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"), "amandabrown" },
                    { new Guid("d1c2b3a4-9e8f-7a6b-5c4d-3f2e1c0d9a8b"), 0, null, "Baseball123", 1, new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"), "sarahjones" }
                });

            migrationBuilder.InsertData(
                table: "inStoreProducts",
                columns: new[] { "InStoreProductID", "BelongTo", "ProductID", "Quantity", "Status" },
                values: new object[,]
                {
                    { new Guid("19a69e71-e463-4d11-9e25-d061033b4126"), new Guid("c4b89d97-95c7-4d97-bf8a-3cb3e2b058e3"), new Guid("c1b0c347-ffd4-466e-8966-0fb02971b4ca"), 4, 2 },
                    { new Guid("1f2edbe3-23b8-44aa-a812-66607c7bc09e"), new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"), new Guid("b54d41b5-e213-41ba-8435-b7f3d6234fa7"), 10, 1 },
                    { new Guid("3d72d978-9ee9-4e24-a798-01d08d9055f5"), new Guid("d1c7f3ab-3f18-46c9-9a0b-25e16f80bf7f"), new Guid("870bd28d-2b95-4e23-b0f9-0db46e924a87"), 1, 2 },
                    { new Guid("5d5d5c5c-1635-4c12-b5d5-babfbac9d0cc"), new Guid("d1c7f3ab-3f18-46c9-9a0b-25e16f80bf7f"), new Guid("0314642e-0eda-473a-9f1e-487acea7b191"), 3, 2 },
                    { new Guid("66b36a90-2d75-4e9f-ae57-ebe0f17aebc4"), new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"), new Guid("c1b0c347-ffd4-466e-8966-0fb02971b4ca"), 8, 1 },
                    { new Guid("6b1c6a60-6a1a-4df5-b0e3-8fb9c93ab55e"), new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"), new Guid("0314642e-0eda-473a-9f1e-487acea7b191"), 15, 1 },
                    { new Guid("6bbd1c61-69cb-4de6-b7f6-4c144b62dc4a"), new Guid("c4b89d97-95c7-4d97-bf8a-3cb3e2b058e3"), new Guid("57acf196-c71c-49b0-aad1-a1fe004f23fe"), 3, 1 },
                    { new Guid("777e83d8-b996-4186-a7b4-4d4a4c9e21a6"), new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"), new Guid("2ed1ddce-f6b7-4f50-8636-954aad785bda"), 10, 1 },
                    { new Guid("7ee570c1-2b7e-480a-8706-5e6d208fb6b9"), new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"), new Guid("7f19b793-7023-4751-bcae-b8c25688beef"), 3, 1 },
                    { new Guid("90cb0a2d-5da5-4cf4-8e0c-4ecaa1704d4e"), new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"), new Guid("f32f6db0-fa3d-44b3-98e3-39b2ffc0afc7"), 10, 1 },
                    { new Guid("9b22f0b2-c7d2-466c-9737-0f68b32aa759"), new Guid("c4b89d97-95c7-4d97-bf8a-3cb3e2b058e3"), new Guid("b54d41b5-e213-41ba-8435-b7f3d6234fa7"), 5, 1 },
                    { new Guid("9ec8c30f-d6c1-47ba-9d62-c2128a7e374a"), new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"), new Guid("8b36a544-4377-40c7-bb36-7471c14fe502"), 20, 1 },
                    { new Guid("a88c904a-760d-40a9-879f-3e05c304d307"), new Guid("c4b89d97-95c7-4d97-bf8a-3cb3e2b058e3"), new Guid("bd614703-badc-4d12-970a-27c64b59847b"), 7, 1 },
                    { new Guid("b0ec7e9d-6d29-47d5-b5bb-1bcb5ed312c5"), new Guid("d1c7f3ab-3f18-46c9-9a0b-25e16f80bf7f"), new Guid("b54d41b5-e213-41ba-8435-b7f3d6234fa7"), 0, 0 },
                    { new Guid("ba43d2f9-0763-43fc-9cfc-d37f57f8c7df"), new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"), new Guid("8b36a544-4377-40c7-bb36-7471c14fe502"), 5, 2 },
                    { new Guid("d2d6bfc8-2c3c-42a6-816e-84a8c08e60b5"), new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"), new Guid("2ed1ddce-f6b7-4f50-8636-954aad785bda"), 2, 1 },
                    { new Guid("dab37d9c-69f5-4d17-991c-8c4dded6901a"), new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"), new Guid("870bd28d-2b95-4e23-b0f9-0db46e924a87"), 2, 1 },
                    { new Guid("e94db7d1-c1c9-4019-bd31-0ba7d319b361"), new Guid("c4b89d97-95c7-4d97-bf8a-3cb3e2b058e3"), new Guid("8b36a544-4377-40c7-bb36-7471c14fe502"), 10, 1 },
                    { new Guid("ee05d814-32c2-47a3-97a3-d6df16d9a72e"), new Guid("d1c7f3ab-3f18-46c9-9a0b-25e16f80bf7f"), new Guid("2ed1ddce-f6b7-4f50-8636-954aad785bda"), 5, 0 },
                    { new Guid("f3c72cc3-d2e8-4296-bf34-712ddfabd5f9"), new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"), new Guid("57acf196-c71c-49b0-aad1-a1fe004f23fe"), 5, 1 },
                    { new Guid("f3f30c95-8ba6-4bc6-bc27-fa0e99128a8b"), new Guid("c4b89d97-95c7-4d97-bf8a-3cb3e2b058e3"), new Guid("7f19b793-7023-4751-bcae-b8c25688beef"), 1, 2 },
                    { new Guid("f57d030b-7b23-463d-8041-e33436c62f0e"), new Guid("d1c7f3ab-3f18-46c9-9a0b-25e16f80bf7f"), new Guid("bd614703-badc-4d12-970a-27c64b59847b"), 0, 0 },
                    { new Guid("f7a0dd2a-1da5-4f45-b338-59306e48c802"), new Guid("d1c7f3ab-3f18-46c9-9a0b-25e16f80bf7f"), new Guid("f32f6db0-fa3d-44b3-98e3-39b2ffc0afc7"), 2, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "AccountID",
                keyValue: new Guid("1f7d3e82-4c8f-5b2e-b2c0-2f2d8c1e1d1d"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "AccountID",
                keyValue: new Guid("3802d434-b94e-4aab-b4c0-91acfc298c47"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "AccountID",
                keyValue: new Guid("7f6e5d4c-3b2a-1f0e-d9c8-7654a3210b1c"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "AccountID",
                keyValue: new Guid("8f7b3e92-3c7e-4b1d-a7a1-1f1c7d2f2a2a"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "AccountID",
                keyValue: new Guid("9fc8a324-fe80-4b48-b106-273d511bf0f4"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "AccountID",
                keyValue: new Guid("a5b6c7d8-e9f0-1a2b-3c4d-5e6f7a8b9c0d"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "AccountID",
                keyValue: new Guid("b4e3c2d1-f0e9-d8c7-b6a5-4193f8271c36"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "AccountID",
                keyValue: new Guid("d1c2b3a4-9e8f-7a6b-5c4d-3f2e1c0d9a8b"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("19a69e71-e463-4d11-9e25-d061033b4126"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("1f2edbe3-23b8-44aa-a812-66607c7bc09e"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("3d72d978-9ee9-4e24-a798-01d08d9055f5"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("5d5d5c5c-1635-4c12-b5d5-babfbac9d0cc"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("66b36a90-2d75-4e9f-ae57-ebe0f17aebc4"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("6b1c6a60-6a1a-4df5-b0e3-8fb9c93ab55e"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("6bbd1c61-69cb-4de6-b7f6-4c144b62dc4a"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("777e83d8-b996-4186-a7b4-4d4a4c9e21a6"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("7ee570c1-2b7e-480a-8706-5e6d208fb6b9"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("90cb0a2d-5da5-4cf4-8e0c-4ecaa1704d4e"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("9b22f0b2-c7d2-466c-9737-0f68b32aa759"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("9ec8c30f-d6c1-47ba-9d62-c2128a7e374a"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("a88c904a-760d-40a9-879f-3e05c304d307"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("b0ec7e9d-6d29-47d5-b5bb-1bcb5ed312c5"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("ba43d2f9-0763-43fc-9cfc-d37f57f8c7df"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("d2d6bfc8-2c3c-42a6-816e-84a8c08e60b5"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("dab37d9c-69f5-4d17-991c-8c4dded6901a"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("e94db7d1-c1c9-4019-bd31-0ba7d319b361"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("ee05d814-32c2-47a3-97a3-d6df16d9a72e"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("f3c72cc3-d2e8-4296-bf34-712ddfabd5f9"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("f3f30c95-8ba6-4bc6-bc27-fa0e99128a8b"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("f57d030b-7b23-463d-8041-e33436c62f0e"));

            migrationBuilder.DeleteData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("f7a0dd2a-1da5-4f45-b338-59306e48c802"));

            migrationBuilder.DeleteData(
                table: "wareHouses",
                keyColumn: "WareHouseID",
                keyValue: new Guid("c4b89d97-95c7-4d97-bf8a-3cb3e2b058e3"));

            migrationBuilder.DeleteData(
                table: "wareHouses",
                keyColumn: "WareHouseID",
                keyValue: new Guid("d1c7f3ab-3f18-46c9-9a0b-25e16f80bf7f"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("0314642e-0eda-473a-9f1e-487acea7b191"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("2ed1ddce-f6b7-4f50-8636-954aad785bda"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("57acf196-c71c-49b0-aad1-a1fe004f23fe"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("7f19b793-7023-4751-bcae-b8c25688beef"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("870bd28d-2b95-4e23-b0f9-0db46e924a87"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("8b36a544-4377-40c7-bb36-7471c14fe502"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("b54d41b5-e213-41ba-8435-b7f3d6234fa7"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("bd614703-badc-4d12-970a-27c64b59847b"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("c1b0c347-ffd4-466e-8966-0fb02971b4ca"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("f32f6db0-fa3d-44b3-98e3-39b2ffc0afc7"));

            migrationBuilder.DeleteData(
                table: "stores",
                keyColumn: "StoreID",
                keyValue: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.DeleteData(
                table: "stores",
                keyColumn: "StoreID",
                keyValue: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminAccountID",
                table: "wareHouses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_wareHouses_AdminAccountID",
                table: "wareHouses",
                column: "AdminAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_wareHouses_accounts_AdminAccountID",
                table: "wareHouses",
                column: "AdminAccountID",
                principalTable: "accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
