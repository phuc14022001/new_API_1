using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamlai.Migrations
{
    public partial class Dbloai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "maloai",
                table: "hangHoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "loai",
                columns: table => new
                {
                    maloai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matenloai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loai", x => x.maloai);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hangHoa_maloai",
                table: "hangHoa",
                column: "maloai");

            migrationBuilder.AddForeignKey(
                name: "FK_hangHoa_loai_maloai",
                table: "hangHoa",
                column: "maloai",
                principalTable: "loai",
                principalColumn: "maloai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hangHoa_loai_maloai",
                table: "hangHoa");

            migrationBuilder.DropTable(
                name: "loai");

            migrationBuilder.DropIndex(
                name: "IX_hangHoa_maloai",
                table: "hangHoa");

            migrationBuilder.DropColumn(
                name: "maloai",
                table: "hangHoa");
        }
    }
}
