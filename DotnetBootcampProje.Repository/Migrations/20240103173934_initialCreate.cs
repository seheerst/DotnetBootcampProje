using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetBootcampProje.Repository.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { 1, new DateTime(2024, 1, 3, 20, 39, 34, 417, DateTimeKind.Local).AddTicks(2990), "1.Sınıf" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { 2, new DateTime(2024, 1, 3, 20, 39, 34, 417, DateTimeKind.Local).AddTicks(3011), "2.Sınıf" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { 3, new DateTime(2024, 1, 3, 20, 39, 34, 417, DateTimeKind.Local).AddTicks(3013), "3.Sınıf" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassId", "CreatedDate", "Email", "Name", "Phone" },
                values: new object[] { 1, 1, new DateTime(2024, 1, 3, 20, 39, 34, 417, DateTimeKind.Local).AddTicks(3600), "ali@test.com", "Ali Yılmaz", "5555555" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassId", "CreatedDate", "Email", "Name", "Phone" },
                values: new object[] { 2, 2, new DateTime(2024, 1, 3, 20, 39, 34, 417, DateTimeKind.Local).AddTicks(3603), "gizem@test.com", "Gizem Tosun", "5555555" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassId", "CreatedDate", "Email", "Name", "Phone" },
                values: new object[] { 3, 3, new DateTime(2024, 1, 3, 20, 39, 34, 417, DateTimeKind.Local).AddTicks(3605), "ayse@test.com", "Ayşe kaya", "5555555" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "Name", "Number", "TeacherId" },
                values: new object[] { 1, new DateTime(2024, 1, 3, 20, 39, 34, 417, DateTimeKind.Local).AddTicks(3372), "Seher Selin", "290", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "Name", "Number", "TeacherId" },
                values: new object[] { 2, new DateTime(2024, 1, 3, 20, 39, 34, 417, DateTimeKind.Local).AddTicks(3376), "Şevval Özdemir", "100", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "Name", "Number", "TeacherId" },
                values: new object[] { 3, new DateTime(2024, 1, 3, 20, 39, 34, 417, DateTimeKind.Local).AddTicks(3378), "Ceren Soysal", "100", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
