using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo_Cozuum.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Eylemler",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Eylemler_UserID",
                table: "Eylemler",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Eylemler_AspNetUsers_UserID",
                table: "Eylemler",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eylemler_AspNetUsers_UserID",
                table: "Eylemler");

            migrationBuilder.DropIndex(
                name: "IX_Eylemler_UserID",
                table: "Eylemler");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Eylemler");
        }
    }
}
