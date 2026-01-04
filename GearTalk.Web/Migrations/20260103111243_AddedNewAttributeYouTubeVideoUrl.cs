using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GearTalk.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewAttributeYouTubeVideoUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YouTubeVideoUrl",
                table: "CarReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YouTubeVideoUrl",
                table: "CarReviews");
        }
    }
}
