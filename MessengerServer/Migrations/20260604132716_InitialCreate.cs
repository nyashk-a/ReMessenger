using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    SUID = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    OwnerSUID = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Bio = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Avatar = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.SUID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    SUID = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Owner = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Membership = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.SUID);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    UserSUID = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    ChatSUID = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    UserRole = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => new { x.UserSUID, x.ChatSUID });
                });

            migrationBuilder.CreateTable(
                name: "UserDevices",
                columns: table => new
                {
                    UserSUID = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    deviceID = table.Column<byte>(type: "smallint", nullable: false),
                    sessionID = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    isSynced = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDevices", x => new { x.UserSUID, x.deviceID, x.sessionID });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    SUID = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Surname = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Bio = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Avatar = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.SUID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "UserDevices");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
