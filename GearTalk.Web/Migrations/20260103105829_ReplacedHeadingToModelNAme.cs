using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GearTalk.Web.Migrations
{
    /// <inheritdoc />
    public partial class ReplacedHeadingToModelNAme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Heading",
                table: "CarReviews",
                newName: "ModelName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelName",
                table: "CarReviews",
                newName: "Heading");
        }
    }
}
