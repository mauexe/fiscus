using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace model.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organisations",
                columns: table => new
                {
                    organisation_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organisations", x => x.organisation_id);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    code = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    organisation_id = table.Column<int>(type: "INTEGER", nullable: false),
                    link = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => new { x.code, x.organisation_id });
                    table.ForeignKey(
                        name: "FK_invoices_organisations_organisation_id",
                        column: x => x.organisation_id,
                        principalTable: "organisations",
                        principalColumn: "organisation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    price = table.Column<decimal>(type: "TEXT", nullable: false),
                    InvoiceCode = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceOrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.position_id);
                    table.ForeignKey(
                        name: "FK_positions_invoices_InvoiceCode_InvoiceOrgId",
                        columns: x => new { x.InvoiceCode, x.InvoiceOrgId },
                        principalTable: "invoices",
                        principalColumns: new[] { "code", "organisation_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoices_organisation_id",
                table: "invoices",
                column: "organisation_id");

            migrationBuilder.CreateIndex(
                name: "IX_positions_InvoiceCode_InvoiceOrgId",
                table: "positions",
                columns: new[] { "InvoiceCode", "InvoiceOrgId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "organisations");
        }
    }
}
