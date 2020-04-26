using Microsoft.EntityFrameworkCore.Migrations;

namespace Texter.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DestinationAddrDeviceId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SourceAddrDeviceId",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "DestinationAddr",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceAddr",
                table: "Messages",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "DestinationAddr", "SourceAddr" },
                values: new object[] { 100L, "Apple", "5678", "1234" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "DestinationAddr", "SourceAddr" },
                values: new object[] { 103L, "hi", "1234", "5678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 103L);

            migrationBuilder.DropColumn(
                name: "DestinationAddr",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SourceAddr",
                table: "Messages");

            migrationBuilder.AddColumn<long>(
                name: "DestinationAddrDeviceId",
                table: "Messages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SourceAddrDeviceId",
                table: "Messages",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DestinationAddrDeviceId",
                table: "Messages",
                column: "DestinationAddrDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SourceAddrDeviceId",
                table: "Messages",
                column: "SourceAddrDeviceId");

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
    }
}
