using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.App.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Name_Length",
                table: "Users",
                sql: "LEN(Name) >= 1");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Role",
                table: "Users",
                sql: "[Role] BETWEEN 0 AND 3");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Surname_Length",
                table: "Users",
                sql: "LEN(Surname) >= 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Name_Length",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Role",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Surname_Length",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
