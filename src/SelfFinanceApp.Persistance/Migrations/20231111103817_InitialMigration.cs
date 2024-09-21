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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    FinanceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    { new Guid("53e1dde8-8665-4889-a864-54bb47abfca7"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3432), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3432), "Dividends", 1 },
                    { new Guid("666751e6-7409-48bf-9d7a-4ef3b161a52c"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3430), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3431), "Salary", 1 },
                    { new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3425), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3425), "Bills", 2 },
                    { new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3428), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3428), "Rent", 2 }
                });

            migrationBuilder.InsertData(
                table: "FinancialOperations",
                columns: new[] { "Id", "DateCreated", "DateModified", "FinanceTypeId", "Name", "Amount", "Currency" },
                values: new object[,]
                {
                    { new Guid("29d75494-9dd1-4c10-8bee-98d428799b9f"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3485), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3485), new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"), "Paying bills 06-2023", 1000m, "EUR" },
                    { new Guid("2bd3e809-66a4-4979-a0e8-103d0c02418c"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3487), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3487), new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"), "Paying rent 06-2023", 1000m, "EUR" },
                    { new Guid("61973c5e-62d9-4cf3-81c0-4690914a21a7"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3505), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3505), new Guid("53e1dde8-8665-4889-a864-54bb47abfca7"), "Dividend 07-2023", 1000m, "EUR" },
                    { new Guid("6f233ccc-5d7e-4a42-a804-2f26806e6c52"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3500), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3500), new Guid("53e1dde8-8665-4889-a864-54bb47abfca7"), "Dividend 06-2023", 100m, "EUR" },
                    { new Guid("6fcd2a3e-ef43-4edc-b6c7-7aeaaa97b55c"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3514), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3514), new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"), "Paying bills 09-2023", 1000m, "EUR" },
                    { new Guid("7810396b-5642-44a6-aa70-72badfab9739"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3498), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3499), new Guid("666751e6-7409-48bf-9d7a-4ef3b161a52c"), "Salary 06-2023", 3000m, "EUR" },
                    { new Guid("b230237d-528f-4243-ba2e-69b3aafc7f72"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3507), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3508), new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"), "Paying rent 08-2023", 1000m, "EUR" },
                    { new Guid("b8af3e17-c4e6-44e7-b8ba-4075b5f76b94"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3511), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3511), new Guid("666751e6-7409-48bf-9d7a-4ef3b161a52c"), "Salary 08-2023", 1000m, "EUR" },
                    { new Guid("bdef6e09-eec7-433a-90be-efd62ccca1e2"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3501), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3501), new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"), "Paying bills 07-2023", 1000m, "EUR" },
                    { new Guid("c886ba9b-8a1a-4c7c-baf4-f9d2e81e978e"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3515), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3515), new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"), "Paying rent 09-2023", 1000m, "EUR" },
                    { new Guid("cb1e939d-b5f8-407d-ba0d-32e15b5027e9"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3512), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3512), new Guid("53e1dde8-8665-4889-a864-54bb47abfca7"), "Dividend 08-2023", 1000m, "EUR" },
                    { new Guid("d92216be-9d16-46da-906f-d96c984b95c5"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3502), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3503), new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"), "Paying rent 07-2023", 1000m, "EUR" },
                    { new Guid("f8fc23aa-9713-4e6d-a71e-4314a6a02bb8"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3504), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3504), new Guid("666751e6-7409-48bf-9d7a-4ef3b161a52c"), "Salary 07-2023", 1000m, "EUR" },
                    { new Guid("fe59224c-92a2-4f9b-9d1c-73d521b80522"), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3506), new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3506), new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"), "Paying bills 08-2023", 1000m, "EUR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialOperations_FinanceTypeId",
                table: "FinancialOperations",
                column: "FinanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialOperations_Name",
                table: "FinancialOperations",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTypes_Name",
                table: "FinancialTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
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
