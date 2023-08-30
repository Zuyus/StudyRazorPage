using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class suabanguser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUsers_Username_Email",
                table: "AppUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Email",
                table: "AppUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Username",
                table: "AppUsers",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUsers_Email",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_Username",
                table: "AppUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Username_Email",
                table: "AppUsers",
                columns: new[] { "Username", "Email" },
                unique: true);
        }
    }
}
