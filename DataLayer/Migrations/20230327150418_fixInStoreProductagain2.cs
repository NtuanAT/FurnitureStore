using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixInStoreProductagain2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inStoreProducts_wareHouses_WareHouseID",
                table: "inStoreProducts");

            migrationBuilder.DropIndex(
                name: "IX_inStoreProducts_WareHouseID",
                table: "inStoreProducts");

            migrationBuilder.DropColumn(
                name: "WareHouseID",
                table: "inStoreProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WareHouseID",
                table: "inStoreProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inStoreProducts_WareHouseID",
                table: "inStoreProducts",
                column: "WareHouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_inStoreProducts_wareHouses_WareHouseID",
                table: "inStoreProducts",
                column: "WareHouseID",
                principalTable: "wareHouses",
                principalColumn: "WareHouseID");
        }
    }
}
