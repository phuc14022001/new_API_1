using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamlai.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Tinhtrang = table.Column<int>(type: "int", nullable: false),
                    nguoinhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDH);
                });

            migrationBuilder.CreateTable(
                name: "ChitietDonHang",
                columns: table => new
                {
                    MaDH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mahh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Soluongton = table.Column<int>(type: "int", nullable: false),
                    Dongia = table.Column<double>(type: "float", nullable: false),
                    giamgia = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitietDonHang", x => new { x.MaDH, x.Mahh });
                    table.ForeignKey(
                        name: "FK_DonHangCT_DonHang",
                        column: x => x.MaDH,
                        principalTable: "DonHang",
                        principalColumn: "MaDH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangCT_HangHoa",
                        column: x => x.Mahh,
                        principalTable: "hangHoa",
                        principalColumn: "Mahh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChitietDonHang_Mahh",
                table: "ChitietDonHang",
                column: "Mahh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChitietDonHang");

            migrationBuilder.DropTable(
                name: "DonHang");
        }
    }
}
