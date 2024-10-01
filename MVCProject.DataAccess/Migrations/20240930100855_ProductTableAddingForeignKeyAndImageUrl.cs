using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductTableAddingForeignKeyAndImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "ProductTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ProductTable",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CategoryId", "image" },
                values: new object[] { 2, "" });

            migrationBuilder.UpdateData(
                table: "ProductTable",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryId", "image" },
                values: new object[] { 3, "" });

            migrationBuilder.UpdateData(
                table: "ProductTable",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CategoryId", "image" },
                values: new object[] { 1, "" });

            migrationBuilder.UpdateData(
                table: "ProductTable",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryId", "image" },
                values: new object[] { 3, "" });

            migrationBuilder.UpdateData(
                table: "ProductTable",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CategoryId", "image" },
                values: new object[] { 1, "" });

            migrationBuilder.UpdateData(
                table: "ProductTable",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CategoryId", "image" },
                values: new object[] { 2, "" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTable_CategoryId",
                table: "ProductTable",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTable_CategoryTable_CategoryId",
                table: "ProductTable",
                column: "CategoryId",
                principalTable: "CategoryTable",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTable_CategoryTable_CategoryId",
                table: "ProductTable");

            migrationBuilder.DropIndex(
                name: "IX_ProductTable_CategoryId",
                table: "ProductTable");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductTable");

            migrationBuilder.DropColumn(
                name: "image",
                table: "ProductTable");
        }
    }
}
