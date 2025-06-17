using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.YFC.Migrations
{
    /// <inheritdoc />
    public partial class AddAlbums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunityAlbums",
                columns: table => new
                {
                    CommunityAlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityAlbums", x => x.CommunityAlbumId);
                    table.ForeignKey(
                        name: "FK_CommunityAlbums_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinistryAlbums",
                columns: table => new
                {
                    MinistryAlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinistryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryAlbums", x => x.MinistryAlbumId);
                    table.ForeignKey(
                        name: "FK_MinistryAlbums_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "MinistryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityAlbums_CommunityId",
                table: "CommunityAlbums",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_MinistryAlbums_MinistryId",
                table: "MinistryAlbums",
                column: "MinistryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityAlbums");

            migrationBuilder.DropTable(
                name: "MinistryAlbums");
        }
    }
}
