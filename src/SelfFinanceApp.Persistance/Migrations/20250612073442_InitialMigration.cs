using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SelfFinanceApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    FinanceTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialOperations_FinancialTypes_FinanceTypeId",
                        column: x => x.FinanceTypeId,
                        principalTable: "FinancialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FinancialTypes",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name", "TransactionType" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bills", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rent", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Salary", 1 },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dividends", 1 }
                });

            migrationBuilder.InsertData(
                table: "FinancialOperations",
                columns: new[] { "Id", "DateCreated", "DateModified", "FinanceTypeId", "Name", "Amount", "Currency" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), "Paying bills 06-2023", 1000m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("22222222-2222-2222-2222-222222222222"), "Paying rent 06-2023", 1000m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333"), "Salary 06-2023", 3000m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("44444444-4444-4444-4444-444444444444"), "Dividend 06-2023", 100m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), "Paying bills 07-2023", 1000m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("22222222-2222-2222-2222-222222222222"), "Paying rent 07-2023", 1000m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-000000000007"), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333"), "Salary 07-2023", 3000m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-000000000008"), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("44444444-4444-4444-4444-444444444444"), "Dividend 07-2023", 100m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-000000000009"), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), "Paying bills 08-2023", 1000m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-00000000000a"), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("22222222-2222-2222-2222-222222222222"), "Paying rent 08-2023", 1000m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-00000000000b"), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333"), "Salary 08-2023", 3000m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-00000000000c"), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("44444444-4444-4444-4444-444444444444"), "Dividend 08-2023", 100m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-00000000000d"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), "Paying bills 09-2023", 1000m, "EUR" },
                    { new Guid("10000000-0000-0000-0000-00000000000e"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("22222222-2222-2222-2222-222222222222"), "Paying rent 09-2023", 1000m, "EUR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialOperations_FinanceTypeId",
                table: "FinancialOperations",
                column: "FinanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialOperations_Name",
                table: "FinancialOperations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTypes_Name",
                table: "FinancialTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialOperations");

            migrationBuilder.DropTable(
                name: "FinancialTypes");
        }
    }
}
