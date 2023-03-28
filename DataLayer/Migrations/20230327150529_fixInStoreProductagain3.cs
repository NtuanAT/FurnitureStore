using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixInStoreProductagain3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoreID",
                table: "inStoreProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
