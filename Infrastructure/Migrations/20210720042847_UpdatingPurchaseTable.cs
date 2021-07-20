using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdatingPurchaseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Purchase",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 9.9m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDateTime",
                table: "Purchase",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_UserId_MovieId",
                table: "Purchase",
                columns: new[] { "UserId", "MovieId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Purchase_UserId_MovieId",
                table: "Purchase");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Purchase",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 9.9m,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDateTime",
                table: "Purchase",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase",
                column: "UserId");
        }
    }
}
