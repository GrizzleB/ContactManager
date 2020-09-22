using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ContactManager.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "DateAdded", "Email", "Firstname", "Lastname", "Organization", "Phone" },
                values: new object[] { 4, 1, new DateTime(2020, 9, 21, 20, 32, 16, 265, DateTimeKind.Local).AddTicks(4651), "gerhardt@gmail.com", "Ryan", "Gerhardt", null, "314-555-6279" });


            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Contacts",
                nullable: false,
                defaultValue: 0
                );


            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                });


            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "InvoiceId",
                value: 2
                );
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "InvoiceId",
                value: 1
                );
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "InvoiceId",
                value: 1
                );
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 4,
                column: "InvoiceId",
                value: 3
                );

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "Amount" },
                values: new object[] { 1, 250 }
                );
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "Amount" },
                values: new object[] { 2, 500 }
                );
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "Amount" },
                values: new object[] { 3, 750 }
                );
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "Amount" },
                values: new object[] { 4, 1000 }
                );


            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Invoices_InvoiceId",
                table: "Contacts",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Invoices_InvoiceId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Contacts");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 4);

        }
    }
}
