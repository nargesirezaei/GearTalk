using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GearTalk.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddCarCategoryIdToCarReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCategoryCarReview");

            migrationBuilder.AddColumn<Guid>(
                name: "CarCategoryId",
                table: "CarReviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CarReviews_CarCategoryId",
                table: "CarReviews",
                column: "CarCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReviews_CarCategories_CarCategoryId",
                table: "CarReviews",
                column: "CarCategoryId",
                principalTable: "CarCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReviews_CarCategories_CarCategoryId",
                table: "CarReviews");

            migrationBuilder.DropIndex(
                name: "IX_CarReviews_CarCategoryId",
                table: "CarReviews");

            migrationBuilder.DropColumn(
                name: "CarCategoryId",
                table: "CarReviews");

            migrationBuilder.CreateTable(
                name: "CarCategoryCarReview",
                columns: table => new
                {
                    CarReviewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategoryCarReview", x => new { x.CarReviewsId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_CarCategoryCarReview_CarCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "CarCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCategoryCarReview_CarReviews_CarReviewsId",
                        column: x => x.CarReviewsId,
                        principalTable: "CarReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCategoryCarReview_CategoriesId",
                table: "CarCategoryCarReview",
                column: "CategoriesId");
        }
    }
}
