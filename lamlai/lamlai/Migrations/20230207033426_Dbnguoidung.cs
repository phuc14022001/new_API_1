using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamlai.Migrations
{
    public partial class Dbnguoidung : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    passWord = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    hoTen = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_UseName",
                table: "NguoiDung",
                column: "UseName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguoiDung");
        }
    }
}
