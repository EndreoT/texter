using Microsoft.EntityFrameworkCore.Migrations;

namespace Texter.Migrations
{
    public partial class add_relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Devices_DestinationIdDeviceId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Devices_SourceIdDeviceId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DestinationIdDeviceId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SourceIdDeviceId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DestinationIdDeviceId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SourceIdDeviceId",
                table: "Messages");

            migrationBuilder.AddColumn<long>(
                name: "DestinationAddrDeviceId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SourceAddrDeviceId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Devices",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "DeviceId", "Address" },
                values: new object[] { 1L, "1234" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "DeviceId", "Address" },
                values: new object[] { 2L, "5678" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DestinationAddrDeviceId",
                table: "Messages",
                column: "DestinationAddrDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SourceAddrDeviceId",
                table: "Messages",
                column: "SourceAddrDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Address",
                table: "Devices",
                column: "Address",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Devices_DestinationAddrDeviceId",
                table: "Messages",
                column: "DestinationAddrDeviceId",
                principalTable: "Devices",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Devices_SourceAddrDeviceId",
                table: "Messages",
                column: "SourceAddrDeviceId",
                principalTable: "Devices",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Devices_DestinationAddrDeviceId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Devices_SourceAddrDeviceId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DestinationAddrDeviceId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SourceAddrDeviceId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Devices_Address",
                table: "Devices");

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "DestinationAddrDeviceId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SourceAddrDeviceId",
                table: "Messages");

            migrationBuilder.AddColumn<long>(
                name: "DestinationIdDeviceId",
                table: "Messages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SourceIdDeviceId",
                table: "Messages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Devices",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DestinationIdDeviceId",
                table: "Messages",
                column: "DestinationIdDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SourceIdDeviceId",
                table: "Messages",
                column: "SourceIdDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Devices_DestinationIdDeviceId",
                table: "Messages",
                column: "DestinationIdDeviceId",
                principalTable: "Devices",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Devices_SourceIdDeviceId",
                table: "Messages",
                column: "SourceIdDeviceId",
                principalTable: "Devices",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
