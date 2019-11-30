using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QL_Hocsinh.Migrations
{
    public partial class innitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    TenKhoa = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    TenMon = table.Column<string>(maxLength: 200, nullable: true),
                    SoTinChi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LopHocPhans",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    NamHoc = table.Column<int>(nullable: false),
                    HocKi = table.Column<int>(nullable: false),
                    Mon = table.Column<string>(maxLength: 200, nullable: true),
                    DiemGK = table.Column<float>(nullable: false),
                    DiemCK = table.Column<float>(nullable: false),
                    KhoaID = table.Column<string>(nullable: true),
                    MonHocID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LopHocPhans_Khoas_KhoaID",
                        column: x => x.KhoaID,
                        principalTable: "Khoas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhans_MonHocs_MonHocID",
                        column: x => x.MonHocID,
                        principalTable: "MonHocs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    HoTen = table.Column<string>(maxLength: 200, nullable: true),
                    Namsinh = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(maxLength: 11, nullable: true),
                    LopHocPhanID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SinhViens_LopHocPhans_LopHocPhanID",
                        column: x => x.LopHocPhanID,
                        principalTable: "LopHocPhans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhans_KhoaID",
                table: "LopHocPhans",
                column: "KhoaID");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhans_MonHocID",
                table: "LopHocPhans",
                column: "MonHocID");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_LopHocPhanID",
                table: "SinhViens",
                column: "LopHocPhanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "LopHocPhans");

            migrationBuilder.DropTable(
                name: "Khoas");

            migrationBuilder.DropTable(
                name: "MonHocs");
        }
    }
}
