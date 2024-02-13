using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameBox.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gameDevices_Games_GameId",
                table: "gameDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_gameDevices_devices_devicesId",
                table: "gameDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_categories_CategoryId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gameDevices",
                table: "gameDevices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_devices",
                table: "devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "gameDevices",
                newName: "GameDevices");

            migrationBuilder.RenameTable(
                name: "devices",
                newName: "Devices");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_gameDevices_devicesId",
                table: "GameDevices",
                newName: "IX_GameDevices_devicesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDevices",
                table: "GameDevices",
                columns: new[] { "GameId", "DeviceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevices_Devices_devicesId",
                table: "GameDevices",
                column: "devicesId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevices_Games_GameId",
                table: "GameDevices",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevices_Devices_devicesId",
                table: "GameDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDevices_Games_GameId",
                table: "GameDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDevices",
                table: "GameDevices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "GameDevices",
                newName: "gameDevices");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "devices");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameIndex(
                name: "IX_GameDevices_devicesId",
                table: "gameDevices",
                newName: "IX_gameDevices_devicesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gameDevices",
                table: "gameDevices",
                columns: new[] { "GameId", "DeviceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_devices",
                table: "devices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_gameDevices_Games_GameId",
                table: "gameDevices",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gameDevices_devices_devicesId",
                table: "gameDevices",
                column: "devicesId",
                principalTable: "devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_categories_CategoryId",
                table: "Games",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
