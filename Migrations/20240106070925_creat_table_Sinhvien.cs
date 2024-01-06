using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranHoangDieu_131.Migrations
{
    /// <inheritdoc />
    public partial class creat_table_Sinhvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lophoc",
                table: "Lophoc");

            migrationBuilder.RenameTable(
                name: "Lophoc",
                newName: "Lophocs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lophocs",
                table: "Lophocs",
                column: "MaLop");

            migrationBuilder.CreateTable(
                name: "Sinhviens",
                columns: table => new
                {
                    Masinhvien = table.Column<double>(type: "REAL", nullable: false),
                    Tensinhvien = table.Column<int>(type: "INTEGER", nullable: false),
                    MaLop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinhviens", x => x.Masinhvien);
                    table.ForeignKey(
                        name: "FK_Sinhviens_Lophocs_MaLop",
                        column: x => x.MaLop,
                        principalTable: "Lophocs",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sinhviens_MaLop",
                table: "Sinhviens",
                column: "MaLop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sinhviens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lophocs",
                table: "Lophocs");

            migrationBuilder.RenameTable(
                name: "Lophocs",
                newName: "Lophoc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lophoc",
                table: "Lophoc",
                column: "MaLop");
        }
    }
}
