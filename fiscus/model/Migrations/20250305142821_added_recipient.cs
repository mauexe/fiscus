using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace model.Migrations
{
    /// <inheritdoc />
    public partial class added_recipient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "paid",
                table: "invoices",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "recipient_id",
                table: "invoices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "total",
                table: "invoices",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "recipients",
                columns: table => new
                {
                    recipient_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipients", x => x.recipient_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoices_recipient_id",
                table: "invoices",
                column: "recipient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_recipients_recipient_id",
                table: "invoices",
                column: "recipient_id",
                principalTable: "recipients",
                principalColumn: "recipient_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_recipients_recipient_id",
                table: "invoices");

            migrationBuilder.DropTable(
                name: "recipients");

            migrationBuilder.DropIndex(
                name: "IX_invoices_recipient_id",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "paid",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "recipient_id",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "total",
                table: "invoices");
        }
    }
}
