using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanDongHo.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWatchDetailFieldsAndAdminSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "AppWatch",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CaseSizeMm",
                table: "AppWatch",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AppWatch",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "AppWatch",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovementType",
                table: "AppWatch",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WaterResistanceM",
                table: "AppWatch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppWatch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "CaseSizeMm", "ImageUrl", "LongDescription", "MovementType", "WaterResistanceM" },
                values: new object[] { "Orient", 40.50m, "https://images.unsplash.com/photo-1524592094714-0f0654e20314?auto=format&fit=crop&w=1200&q=80", "Orient Bambino Gen 2 mang phong cách thanh lịch cổ điển, phù hợp cho môi trường công sở và các dịp trang trọng.", "Automatic", 30 });

            migrationBuilder.UpdateData(
                table: "AppWatch",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "CaseSizeMm", "ImageUrl", "LongDescription", "MovementType", "WaterResistanceM" },
                values: new object[] { "Tissot", 40.00m, "https://images.unsplash.com/photo-1542496658-e33a6d0d50f6?auto=format&fit=crop&w=1200&q=80", "PRX Powermatic 80 nổi bật với thiết kế thể thao sang trọng và bộ máy mạnh mẽ có khả năng trữ cót dài.", "Automatic", 100 });

            migrationBuilder.UpdateData(
                table: "AppWatch",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "CaseSizeMm", "ImageUrl", "LongDescription", "MovementType", "WaterResistanceM" },
                values: new object[] { "Seiko", 42.50m, "https://images.unsplash.com/photo-1617625802912-cde586faf331?auto=format&fit=crop&w=1200&q=80", "Seiko 5 Sports SRPD55 là lựa chọn linh hoạt cho sử dụng hàng ngày với thiết kế khỏe khoắn và độ bền cao.", "Automatic", 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "AppWatch");

            migrationBuilder.DropColumn(
                name: "CaseSizeMm",
                table: "AppWatch");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AppWatch");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "AppWatch");

            migrationBuilder.DropColumn(
                name: "MovementType",
                table: "AppWatch");

            migrationBuilder.DropColumn(
                name: "WaterResistanceM",
                table: "AppWatch");
        }
    }
}
