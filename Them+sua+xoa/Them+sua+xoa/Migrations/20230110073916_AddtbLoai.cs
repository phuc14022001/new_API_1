using Microsoft.EntityFrameworkCore.Migrations;

namespace Them_sua_xoa.Migrations
{
    public partial class AddtbLoai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "maLoai",
                table: "HangHoas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Loai",
                columns: table => new
                {
                    maLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai", x => x.maLoai);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoas_maLoai",
                table: "HangHoas",
                column: "maLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoas_Loai_maLoai",
                table: "HangHoas",
                column: "maLoai",
                principalTable: "Loai",
                principalColumn: "maLoai",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoas_Loai_maLoai",
                table: "HangHoas");

            migrationBuilder.DropTable(
                name: "Loai");

            migrationBuilder.DropIndex(
                name: "IX_HangHoas_maLoai",
                table: "HangHoas");

            migrationBuilder.DropColumn(
                name: "maLoai",
                table: "HangHoas");
        }
    }
}
