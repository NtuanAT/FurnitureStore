using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addConstrain_Store_InStoreProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoreID",
                table: "inStoreProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("19a69e71-e463-4d11-9e25-d061033b4126"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("1f2edbe3-23b8-44aa-a812-66607c7bc09e"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("3d72d978-9ee9-4e24-a798-01d08d9055f5"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("5d5d5c5c-1635-4c12-b5d5-babfbac9d0cc"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("66b36a90-2d75-4e9f-ae57-ebe0f17aebc4"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("6b1c6a60-6a1a-4df5-b0e3-8fb9c93ab55e"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("6bbd1c61-69cb-4de6-b7f6-4c144b62dc4a"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("777e83d8-b996-4186-a7b4-4d4a4c9e21a6"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("7ee570c1-2b7e-480a-8706-5e6d208fb6b9"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("90cb0a2d-5da5-4cf4-8e0c-4ecaa1704d4e"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("9b22f0b2-c7d2-466c-9737-0f68b32aa759"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("9ec8c30f-d6c1-47ba-9d62-c2128a7e374a"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("a88c904a-760d-40a9-879f-3e05c304d307"),
                column: "StoreID",
                value: new Guid("2f7c4295-4f2f-4651-891b-9b61b6e3adac"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("b0ec7e9d-6d29-47d5-b5bb-1bcb5ed312c5"),
                column: "StoreID",
                value: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("ba43d2f9-0763-43fc-9cfc-d37f57f8c7df"),
                column: "StoreID",
                value: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("d2d6bfc8-2c3c-42a6-816e-84a8c08e60b5"),
                column: "StoreID",
                value: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("dab37d9c-69f5-4d17-991c-8c4dded6901a"),
                column: "StoreID",
                value: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("e94db7d1-c1c9-4019-bd31-0ba7d319b361"),
                column: "StoreID",
                value: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("ee05d814-32c2-47a3-97a3-d6df16d9a72e"),
                column: "StoreID",
                value: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("f3c72cc3-d2e8-4296-bf34-712ddfabd5f9"),
                column: "StoreID",
                value: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("f3f30c95-8ba6-4bc6-bc27-fa0e99128a8b"),
                column: "StoreID",
                value: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("f57d030b-7b23-463d-8041-e33436c62f0e"),
                column: "StoreID",
                value: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.UpdateData(
                table: "inStoreProducts",
                keyColumn: "InStoreProductID",
                keyValue: new Guid("f7a0dd2a-1da5-4f45-b338-59306e48c802"),
                column: "StoreID",
                value: new Guid("ad6c7bb8-90a3-4f9a-abf8-be36acba1012"));

            migrationBuilder.CreateIndex(
                name: "IX_inStoreProducts_StoreID",
                table: "inStoreProducts",
                column: "StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_inStoreProducts_stores_StoreID",
                table: "inStoreProducts",
                column: "StoreID",
                principalTable: "stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inStoreProducts_stores_StoreID",
                table: "inStoreProducts");

            migrationBuilder.DropIndex(
                name: "IX_inStoreProducts_StoreID",
                table: "inStoreProducts");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "inStoreProducts");
        }
    }
}
