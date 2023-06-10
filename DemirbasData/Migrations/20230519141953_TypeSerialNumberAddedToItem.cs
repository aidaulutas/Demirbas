using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemirbasData.Migrations
{
    /// <inheritdoc />
    public partial class TypeSerialNumberAddedToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "DeliveryHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "DeliveryHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
