using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameBox.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevices_Devices_devicesId",
                table: "GameDevices");

            migrationBuilder.DropIndex(
                name: "IX_GameDevices_devicesId",
                table: "GameDevices");

            migrationBuilder.DropColumn(
                name: "devicesId",
                table: "GameDevices");

            migrationBuilder.CreateIndex(
                name: "IX_GameDevices_DeviceId",
                table: "GameDevices",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevices_Devices_DeviceId",
                table: "GameDevices",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevices_Devices_DeviceId",
                table: "GameDevices");

            migrationBuilder.DropIndex(
                name: "IX_GameDevices_DeviceId",
                table: "GameDevices");

            migrationBuilder.AddColumn<int>(
                name: "devicesId",
                table: "GameDevices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameDevices_devicesId",
                table: "GameDevices",
                column: "devicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevices_Devices_devicesId",
                table: "GameDevices",
                column: "devicesId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
