using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ModifyCustomerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerRoles_CustomerRoleId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "CustomerRoles");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerRoleId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerStatu",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Statu",
                table: "CustomerRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerRoles_CustomerRoleId",
                table: "Customers",
                column: "CustomerRoleId",
                principalTable: "CustomerRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerRoles_CustomerRoleId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerStatu",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Statu",
                table: "CustomerRoles");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerRoleId",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "CustomerRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerRoles_CustomerRoleId",
                table: "Customers",
                column: "CustomerRoleId",
                principalTable: "CustomerRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
