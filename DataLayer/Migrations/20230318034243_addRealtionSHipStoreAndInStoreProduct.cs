using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addRealtionSHipStoreAndInStoreProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoreID",
                table: "inStoreProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inStoreProducts_StoreID",
                table: "inStoreProducts",
                column: "StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_inStoreProducts_stores_StoreID",
                table: "inStoreProducts",
                column: "StoreID",
                principalTable: "stores",
                principalColumn: "StoreID");
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
