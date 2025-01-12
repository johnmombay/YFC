using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.YFC.Migrations
{
    /// <inheritdoc />
    public partial class PastornMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pastor",
                table: "PastorMessages");

            migrationBuilder.AddColumn<int>(
                name: "PastorId",
                table: "PastorMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PastorMessages_PastorId",
                table: "PastorMessages",
                column: "PastorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PastorMessages_Pastors_PastorId",
                table: "PastorMessages",
                column: "PastorId",
                principalTable: "Pastors",
                principalColumn: "PastorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastorMessages_Pastors_PastorId",
                table: "PastorMessages");

            migrationBuilder.DropIndex(
                name: "IX_PastorMessages_PastorId",
                table: "PastorMessages");

            migrationBuilder.DropColumn(
                name: "PastorId",
                table: "PastorMessages");

            migrationBuilder.AddColumn<string>(
                name: "Pastor",
                table: "PastorMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
