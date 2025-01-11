using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.YFC.Migrations
{
    /// <inheritdoc />
    public partial class CommunityMinistry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    CommunityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.CommunityId);
                });

            migrationBuilder.CreateTable(
                name: "Ministries",
                columns: table => new
                {
                    MinistryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministries", x => x.MinistryId);
                });

            migrationBuilder.CreateTable(
                name: "CommunitiesInfos",
                columns: table => new
                {
                    CommunityInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Leaders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    News = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calendar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunitiesInfos", x => x.CommunityInfoId);
                    table.ForeignKey(
                        name: "FK_CommunitiesInfos_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinistriesInfos",
                columns: table => new
                {
                    MinistryInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryId = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Leaders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    News = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calendar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistriesInfos", x => x.MinistryInfoId);
                    table.ForeignKey(
                        name: "FK_MinistriesInfos_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "MinistryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesInfos_CommunityId",
                table: "CommunitiesInfos",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_MinistriesInfos_MinistryId",
                table: "MinistriesInfos",
                column: "MinistryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunitiesInfos");

            migrationBuilder.DropTable(
                name: "MinistriesInfos");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Ministries");
        }
    }
}
