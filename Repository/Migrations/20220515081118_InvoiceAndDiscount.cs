using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class InvoiceAndDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DiscountAmount",
                table: "Invoices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "Invoices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Statu",
                table: "Discounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Statu",
                table: "Discounts");
        }
    }
}
