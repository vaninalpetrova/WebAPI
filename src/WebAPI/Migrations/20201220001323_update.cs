using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsUsersMappings_Products_ProductId",
                table: "ProductsUsersMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsUsersMappings_User_UserId",
                table: "ProductsUsersMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePackages_User_UserId",
                table: "ServicePackages");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsUsersMappings",
                table: "ProductsUsersMappings");

            migrationBuilder.DropColumn(
                name: "FavoriteWeb",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "ProductsUsersMappings",
                newName: "ProductsUsersMapping");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsUsersMappings_UserId",
                table: "ProductsUsersMapping",
                newName: "IX_ProductsUsersMapping_UserId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ServicePackages",
                type: "DECIMAL(15, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsUsersMapping",
                table: "ProductsUsersMapping",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsUsersMapping_Products_ProductId",
                table: "ProductsUsersMapping",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsUsersMapping_AspNetUsers_UserId",
                table: "ProductsUsersMapping",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePackages_AspNetUsers_UserId",
                table: "ServicePackages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsUsersMapping_Products_ProductId",
                table: "ProductsUsersMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsUsersMapping_AspNetUsers_UserId",
                table: "ProductsUsersMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePackages_AspNetUsers_UserId",
                table: "ServicePackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsUsersMapping",
                table: "ProductsUsersMapping");

            migrationBuilder.RenameTable(
                name: "ProductsUsersMapping",
                newName: "ProductsUsersMappings");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsUsersMapping_UserId",
                table: "ProductsUsersMappings",
                newName: "IX_ProductsUsersMappings_UserId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ServicePackages",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(15, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteWeb",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsUsersMappings",
                table: "ProductsUsersMappings",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsUsersMappings_Products_ProductId",
                table: "ProductsUsersMappings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsUsersMappings_User_UserId",
                table: "ProductsUsersMappings",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePackages_User_UserId",
                table: "ServicePackages",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
