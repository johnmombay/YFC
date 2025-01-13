using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.YFC.Migrations
{
    /// <inheritdoc />
    public partial class groupcontents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunityArticles",
                columns: table => new
                {
                    CommunityArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityArticles", x => x.CommunityArticleId);
                    table.ForeignKey(
                        name: "FK_CommunityArticles_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityEvents",
                columns: table => new
                {
                    CommunityEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityEvents", x => x.CommunityEventId);
                    table.ForeignKey(
                        name: "FK_CommunityEvents_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityInfos",
                columns: table => new
                {
                    CommunityInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityInfos", x => x.CommunityInfoId);
                    table.ForeignKey(
                        name: "FK_CommunityInfos_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityLeaders",
                columns: table => new
                {
                    CommunityLeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityLeaders", x => x.CommunityLeaderId);
                    table.ForeignKey(
                        name: "FK_CommunityLeaders_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunitySchedules",
                columns: table => new
                {
                    CommunityScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunitySchedules", x => x.CommunityScheduleId);
                    table.ForeignKey(
                        name: "FK_CommunitySchedules_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinistryArticles",
                columns: table => new
                {
                    MinistryArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryArticles", x => x.MinistryArticleId);
                    table.ForeignKey(
                        name: "FK_MinistryArticles_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "MinistryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinistryEvents",
                columns: table => new
                {
                    MinistryEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryEvents", x => x.MinistryEventId);
                    table.ForeignKey(
                        name: "FK_MinistryEvents_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "MinistryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinistryInfos",
                columns: table => new
                {
                    MinistryInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryInfos", x => x.MinistryInfoId);
                    table.ForeignKey(
                        name: "FK_MinistryInfos_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "MinistryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinistryLeaders",
                columns: table => new
                {
                    MinistryLeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryLeaders", x => x.MinistryLeaderId);
                    table.ForeignKey(
                        name: "FK_MinistryLeaders_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "MinistryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinistrySchedules",
                columns: table => new
                {
                    MinistryScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistrySchedules", x => x.MinistryScheduleId);
                    table.ForeignKey(
                        name: "FK_MinistrySchedules_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "MinistryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityArticles_CommunityId",
                table: "CommunityArticles",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityEvents_CommunityId",
                table: "CommunityEvents",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityInfos_CommunityId",
                table: "CommunityInfos",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityLeaders_CommunityId",
                table: "CommunityLeaders",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunitySchedules_CommunityId",
                table: "CommunitySchedules",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_MinistryArticles_MinistryId",
                table: "MinistryArticles",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_MinistryEvents_MinistryId",
                table: "MinistryEvents",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_MinistryInfos_MinistryId",
                table: "MinistryInfos",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_MinistryLeaders_MinistryId",
                table: "MinistryLeaders",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_MinistrySchedules_MinistryId",
                table: "MinistrySchedules",
                column: "MinistryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityArticles");

            migrationBuilder.DropTable(
                name: "CommunityEvents");

            migrationBuilder.DropTable(
                name: "CommunityInfos");

            migrationBuilder.DropTable(
                name: "CommunityLeaders");

            migrationBuilder.DropTable(
                name: "CommunitySchedules");

            migrationBuilder.DropTable(
                name: "MinistryArticles");

            migrationBuilder.DropTable(
                name: "MinistryEvents");

            migrationBuilder.DropTable(
                name: "MinistryInfos");

            migrationBuilder.DropTable(
                name: "MinistryLeaders");

            migrationBuilder.DropTable(
                name: "MinistrySchedules");
        }
    }
}
