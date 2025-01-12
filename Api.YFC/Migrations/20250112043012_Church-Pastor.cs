using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.YFC.Migrations
{
    /// <inheritdoc />
    public partial class ChurchPastor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunitiesInfos");

            migrationBuilder.DropTable(
                name: "MinistriesInfos");

            migrationBuilder.CreateTable(
                name: "Churches",
                columns: table => new
                {
                    ChurchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Churches", x => x.ChurchId);
                });

            migrationBuilder.CreateTable(
                name: "PastorMessages",
                columns: table => new
                {
                    PastorMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pastor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastorMessages", x => x.PastorMessageId);
                });

            migrationBuilder.CreateTable(
                name: "Pastors",
                columns: table => new
                {
                    PastorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastors", x => x.PastorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Churches");

            migrationBuilder.DropTable(
                name: "PastorMessages");

            migrationBuilder.DropTable(
                name: "Pastors");

            migrationBuilder.CreateTable(
                name: "CommunitiesInfos",
                columns: table => new
                {
                    CommunityInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calendar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leaders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    News = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Calendar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leaders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    News = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
