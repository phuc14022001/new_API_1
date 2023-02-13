using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamlai.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hangHoa",
                columns: table => new
                {
                    Mahh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tenhh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dongia = table.Column<double>(type: "float", nullable: false),
                    giamgia = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hangHoa", x => x.Mahh);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hangHoa");
        }
    }
}
