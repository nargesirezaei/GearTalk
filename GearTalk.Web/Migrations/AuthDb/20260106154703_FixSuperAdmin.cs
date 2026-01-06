using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GearTalk.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class FixSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFE0E3CE-FBBB-4014-903E-92B9C86EA5D4",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f0fc8d6-cb5e-47bf-9212-84dcf669cb62", "superadmin@gearTalks.com", true, "SUPERADMIN@GEARTALKS.COM", "AQAAAAIAAYagAAAAEOCMQd7XNI4TLoa9KIBJf6dmn8LWVrIQKF/JO4o21e5Fv0xYBTRN85+Tk7RvJy8yRA==", "f215ff29-9277-4ac1-a6ad-e7e63a7c4cf0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFE0E3CE-FBBB-4014-903E-92B9C86EA5D4",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53764ad6-0ee6-45fe-82c1-ccad2dd39e0c", "SUPERADMIN@GEARTALKS.COM", false, null, "AQAAAAIAAYagAAAAEKvs6r6JrWhPVSbaWvt2A8BQjLNaXbxXPfIJvZc4g+AN0uRHOSx7XA/s2Ph9Zutdsg==", "d66579c2-44c5-41bb-9feb-eaee3aa5a532" });
        }
    }
}
