using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebBanDongHo.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppWatch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppWatch", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppWatch",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "LastModifiedDate", "ModifiedBy", "Name", "Price", "ShortDescription", "Sku", "Stock" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Orient Bambino Gen 2", 5600000m, "Mẫu dress watch cổ điển, kính cong và máy cơ tự động.", "ORI-BAM-002", 8 },
                    { 2, 1, new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Tissot PRX Powermatic 80", 18500000m, "Thiết kế integrated bracelet hiện đại, dự trữ cót lên tới 80 giờ.", "TIS-PRX-080", 5 },
                    { 3, 1, new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Seiko 5 Sports SRPD55", 7900000m, "Dòng đồng hồ cơ bền bỉ, phong cách thể thao đa dụng.", "SEI-5S-SRPD55", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppWatch_Sku",
                table: "AppWatch",
                column: "Sku",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppWatch");
        }
    }
}
