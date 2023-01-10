using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Them_sua_xoa.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoas",
                columns: table => new
                {
                    maHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tenHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    donGia = table.Column<double>(type: "float", nullable: false),
                    giamGia = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoas", x => x.maHang);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoas");
        }
    }
}
