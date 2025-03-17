using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace model.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    IssuedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Paid = table.Column<bool>(type: "INTEGER", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    RecipientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => new { x.Code, x.IssuedById });
                    table.ForeignKey(
                        name: "FK_Invoices_Organisations_IssuedById",
                        column: x => x.IssuedById,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Recipient_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    InvoiceCode = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceOrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_Invoices_InvoiceCode_InvoiceOrgId",
                        columns: x => new { x.InvoiceCode, x.InvoiceOrgId },
                        principalTable: "Invoices",
                        principalColumns: new[] { "Code", "IssuedById" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organisations",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Personal" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_IssuedById",
                table: "Invoices",
                column: "IssuedById");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RecipientId",
                table: "Invoices",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_InvoiceCode_InvoiceOrgId",
                table: "Position",
                columns: new[] { "InvoiceCode", "InvoiceOrgId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropTable(
                name: "Recipient");
        }
    }
}
