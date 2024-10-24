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
                    { new Guid("18c4a168-e83c-4763-bed2-6bd565c455bf"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(816), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(817), "Salary", 1 },
                    { new Guid("213a6165-fe70-44e8-8745-6a80f0071c98"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(814), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(815), "Rent", 2 },
                    { new Guid("50f46a28-c0e5-4bb6-be11-01a9ee483dd2"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(818), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(818), "Dividends", 1 },
                    { new Guid("6f02e2db-3464-4859-b0cd-600b100e2c86"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(806), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(809), "Bills", 2 }
                });

            migrationBuilder.InsertData(
                table: "FinancialOperations",
                columns: new[] { "Id", "DateCreated", "DateModified", "FinanceTypeId", "Name", "Amount", "Currency" },
                values: new object[,]
                {
                    { new Guid("1dee64d7-f084-42e3-a605-234366ef6657"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(993), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(993), new Guid("213a6165-fe70-44e8-8745-6a80f0071c98"), "Paying rent 07-2023", 1000m, "EUR" },
                    { new Guid("27f01d4c-37e0-49dd-aef5-e92c133439d0"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(997), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(998), new Guid("6f02e2db-3464-4859-b0cd-600b100e2c86"), "Paying bills 08-2023", 1000m, "EUR" },
                    { new Guid("34e57bf4-bf10-4294-b065-c630e2a6783b"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(991), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(991), new Guid("6f02e2db-3464-4859-b0cd-600b100e2c86"), "Paying bills 07-2023", 1000m, "EUR" },
                    { new Guid("669adc27-0696-4bb0-853b-f6d0475d19a4"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(999), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(999), new Guid("213a6165-fe70-44e8-8745-6a80f0071c98"), "Paying rent 08-2023", 1000m, "EUR" },
                    { new Guid("77549b3a-f710-47bb-8f13-a9e17e38f196"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(994), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(994), new Guid("18c4a168-e83c-4763-bed2-6bd565c455bf"), "Salary 07-2023", 1000m, "EUR" },
                    { new Guid("8b344516-7529-46ae-9764-386d5f268fe2"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1002), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1002), new Guid("50f46a28-c0e5-4bb6-be11-01a9ee483dd2"), "Dividend 08-2023", 1000m, "EUR" },
                    { new Guid("91711918-62ca-4351-892f-4828c7565fa6"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(995), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(996), new Guid("50f46a28-c0e5-4bb6-be11-01a9ee483dd2"), "Dividend 07-2023", 1000m, "EUR" },
                    { new Guid("93ce69e6-9b35-45e5-b5f4-7fefd9fd8e6c"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(987), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(987), new Guid("18c4a168-e83c-4763-bed2-6bd565c455bf"), "Salary 06-2023", 3000m, "EUR" },
                    { new Guid("93f9f2f5-806e-4271-85e4-4526c284cd46"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1059), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1059), new Guid("213a6165-fe70-44e8-8745-6a80f0071c98"), "Paying rent 09-2023", 1000m, "EUR" },
                    { new Guid("96cc5657-5952-4c3b-a42a-5e5f7b3e2726"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(982), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(983), new Guid("6f02e2db-3464-4859-b0cd-600b100e2c86"), "Paying bills 06-2023", 1000m, "EUR" },
                    { new Guid("9be65141-fff9-4c86-b528-2de2fc9c8463"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(985), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(985), new Guid("213a6165-fe70-44e8-8745-6a80f0071c98"), "Paying rent 06-2023", 1000m, "EUR" },
                    { new Guid("b06dd3e9-55b9-4ded-a43f-631bc93a880d"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(988), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(988), new Guid("50f46a28-c0e5-4bb6-be11-01a9ee483dd2"), "Dividend 06-2023", 100m, "EUR" },
                    { new Guid("e506c87d-ed60-4db5-96b8-23de459e160c"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1057), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1058), new Guid("6f02e2db-3464-4859-b0cd-600b100e2c86"), "Paying bills 09-2023", 1000m, "EUR" },
                    { new Guid("f80e1d73-594a-4b50-a815-badac614bebb"), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1000), new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1000), new Guid("18c4a168-e83c-4763-bed2-6bd565c455bf"), "Salary 08-2023", 1000m, "EUR" }
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
