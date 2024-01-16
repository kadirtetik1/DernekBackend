using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Address",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserID",
                table: "Address",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_UserID",
                table: "Address",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_UserID",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_UserID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Address");
        }
    }
}
