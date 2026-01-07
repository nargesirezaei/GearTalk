using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GearTalk.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class changedsuperadmintonarges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFE0E3CE-FBBB-4014-903E-92B9C86EA5D4",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c4581ebf-0851-4a19-9313-e539a5c947cb", "narges@gearTalks.com", "NARGES@GEARTALKS.COM", "NARGES@GEARTALKS.COM", "AQAAAAIAAYagAAAAEOB6UL1rnQb9tIq5+B0FSMVI0UB3IzI8i5e2s6316huW1z+JKSySfMF9h/fY06vQ7g==", "17a4a772-8dad-4b1e-939a-6b4ec250f258", "narges@gearTalks.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFE0E3CE-FBBB-4014-903E-92B9C86EA5D4",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5f0fc8d6-cb5e-47bf-9212-84dcf669cb62", "superadmin@gearTalks.com", "SUPERADMIN@GEARTALKS.COM", "SUPERADMIN@GEARTALKS.COM", "AQAAAAIAAYagAAAAEOCMQd7XNI4TLoa9KIBJf6dmn8LWVrIQKF/JO4o21e5Fv0xYBTRN85+Tk7RvJy8yRA==", "f215ff29-9277-4ac1-a6ad-e7e63a7c4cf0", "superadmin@gearTalks.com" });
        }
    }
}
