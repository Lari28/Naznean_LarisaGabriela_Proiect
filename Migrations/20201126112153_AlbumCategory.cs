using Microsoft.EntityFrameworkCore.Migrations;

namespace Naznean_LarisaGabriela_Proiect.Migrations
{
    public partial class AlbumCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordID",
                table: "Album",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AlbumCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AlbumCategory_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_RecordID",
                table: "Album",
                column: "RecordID");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumCategory_AlbumID",
                table: "AlbumCategory",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumCategory_CategoryID",
                table: "AlbumCategory",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Record_RecordID",
                table: "Album",
                column: "RecordID",
                principalTable: "Record",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Record_RecordID",
                table: "Album");

            migrationBuilder.DropTable(
                name: "AlbumCategory");

            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Album_RecordID",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "RecordID",
                table: "Album");
        }
    }
}
