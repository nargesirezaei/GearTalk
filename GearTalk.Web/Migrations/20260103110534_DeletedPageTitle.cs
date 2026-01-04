using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GearTalk.Web.Migrations
{
    /// <inheritdoc />
    public partial class DeletedPageTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageTitle",
                table: "CarReviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PageTitle",
                table: "CarReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
