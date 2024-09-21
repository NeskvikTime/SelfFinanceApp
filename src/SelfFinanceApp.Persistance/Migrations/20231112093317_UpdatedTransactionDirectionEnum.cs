using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SelfFinanceApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTransactionDirectionEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("29d75494-9dd1-4c10-8bee-98d428799b9f"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("2bd3e809-66a4-4979-a0e8-103d0c02418c"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("61973c5e-62d9-4cf3-81c0-4690914a21a7"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("6f233ccc-5d7e-4a42-a804-2f26806e6c52"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("6fcd2a3e-ef43-4edc-b6c7-7aeaaa97b55c"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("7810396b-5642-44a6-aa70-72badfab9739"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("b230237d-528f-4243-ba2e-69b3aafc7f72"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("b8af3e17-c4e6-44e7-b8ba-4075b5f76b94"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("bdef6e09-eec7-433a-90be-efd62ccca1e2"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("c886ba9b-8a1a-4c7c-baf4-f9d2e81e978e"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("cb1e939d-b5f8-407d-ba0d-32e15b5027e9"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("d92216be-9d16-46da-906f-d96c984b95c5"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("f8fc23aa-9713-4e6d-a71e-4314a6a02bb8"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("fe59224c-92a2-4f9b-9d1c-73d521b80522"));

            migrationBuilder.DeleteData(
                table: "FinancialTypes",
                keyColumn: "Id",
                keyValue: new Guid("53e1dde8-8665-4889-a864-54bb47abfca7"));

            migrationBuilder.DeleteData(
                table: "FinancialTypes",
                keyColumn: "Id",
                keyValue: new Guid("666751e6-7409-48bf-9d7a-4ef3b161a52c"));

            migrationBuilder.DeleteData(
                table: "FinancialTypes",
                keyColumn: "Id",
                keyValue: new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"));

            migrationBuilder.DeleteData(
                table: "FinancialTypes",
                keyColumn: "Id",
                keyValue: new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"));

            migrationBuilder.InsertData(
                table: "FinancialTypes",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name", "TransactionType" },
                values: new object[,]
                {
                    { new Guid("4cda61d0-a2c4-4415-bc07-85882a06dd64"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5939), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5939), "Salary", 1 },
                    { new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5933), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5935), "Bills", 2 },
                    { new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5937), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5938), "Rent", 2 },
                    { new Guid("cdb105cb-75ec-4dd7-933f-bc132eef42e2"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5949), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5949), "Dividends", 1 }
                });

            migrationBuilder.InsertData(
                table: "FinancialOperations",
                columns: new[] { "Id", "DateCreated", "DateModified", "FinanceTypeId", "Name", "Amount", "Currency" },
                values: new object[,]
                {
                    { new Guid("04f8a3b7-70c2-4adb-a344-df16d419b8f4"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6019), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6019), new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"), "Paying rent 08-2023", 1000m, "EUR" },
                    { new Guid("0609fde0-d78b-40ea-9634-47bf1079f8e7"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6025), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6025), new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"), "Paying rent 09-2023", 1000m, "EUR" },
                    { new Guid("0c6a785d-03cf-49ab-b3ed-56b28503edff"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6023), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6024), new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"), "Paying bills 09-2023", 1000m, "EUR" },
                    { new Guid("19d35009-f4d3-47ed-b659-3f71632da71f"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6022), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6022), new Guid("cdb105cb-75ec-4dd7-933f-bc132eef42e2"), "Dividend 08-2023", 1000m, "EUR" },
                    { new Guid("22ff8b94-e19a-4869-89c8-b251ab97d992"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6018), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6018), new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"), "Paying bills 08-2023", 1000m, "EUR" },
                    { new Guid("28a62127-cf52-4f43-bb7e-37c520eb1e2f"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6006), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6006), new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"), "Paying rent 06-2023", 1000m, "EUR" },
                    { new Guid("532409d5-280a-407f-a591-d1fdd7326569"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6016), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6017), new Guid("cdb105cb-75ec-4dd7-933f-bc132eef42e2"), "Dividend 07-2023", 1000m, "EUR" },
                    { new Guid("547c2245-d09e-4b20-b62d-a01837494bf5"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6004), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6005), new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"), "Paying bills 06-2023", 1000m, "EUR" },
                    { new Guid("855f16cc-75a9-453e-8047-5ef4ef672ac7"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6011), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6012), new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"), "Paying rent 07-2023", 1000m, "EUR" },
                    { new Guid("aef9a0be-8017-4d8d-abd2-f331e6115b8e"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6007), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6008), new Guid("4cda61d0-a2c4-4415-bc07-85882a06dd64"), "Salary 06-2023", 3000m, "EUR" },
                    { new Guid("b8c505c5-081c-42cb-aba3-d49f2be6af4e"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6013), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6013), new Guid("4cda61d0-a2c4-4415-bc07-85882a06dd64"), "Salary 07-2023", 1000m, "EUR" },
                    { new Guid("c9cf6ae4-1402-46e0-89eb-99d9f40ed5b7"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6021), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6021), new Guid("4cda61d0-a2c4-4415-bc07-85882a06dd64"), "Salary 08-2023", 1000m, "EUR" },
                    { new Guid("d3c45fb2-31f7-432c-81dd-a30dae33840d"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6009), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6009), new Guid("cdb105cb-75ec-4dd7-933f-bc132eef42e2"), "Dividend 06-2023", 100m, "EUR" },
                    { new Guid("edae0f23-218e-4dd4-976d-6267cb1bf41b"), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6010), new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6010), new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"), "Paying bills 07-2023", 1000m, "EUR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("04f8a3b7-70c2-4adb-a344-df16d419b8f4"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("0609fde0-d78b-40ea-9634-47bf1079f8e7"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("0c6a785d-03cf-49ab-b3ed-56b28503edff"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("19d35009-f4d3-47ed-b659-3f71632da71f"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("22ff8b94-e19a-4869-89c8-b251ab97d992"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("28a62127-cf52-4f43-bb7e-37c520eb1e2f"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("532409d5-280a-407f-a591-d1fdd7326569"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("547c2245-d09e-4b20-b62d-a01837494bf5"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("855f16cc-75a9-453e-8047-5ef4ef672ac7"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("aef9a0be-8017-4d8d-abd2-f331e6115b8e"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("b8c505c5-081c-42cb-aba3-d49f2be6af4e"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("c9cf6ae4-1402-46e0-89eb-99d9f40ed5b7"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("d3c45fb2-31f7-432c-81dd-a30dae33840d"));

            migrationBuilder.DeleteData(
                table: "FinancialOperations",
                keyColumn: "Id",
                keyValue: new Guid("edae0f23-218e-4dd4-976d-6267cb1bf41b"));

            migrationBuilder.DeleteData(
                table: "FinancialTypes",
                keyColumn: "Id",
                keyValue: new Guid("4cda61d0-a2c4-4415-bc07-85882a06dd64"));

            migrationBuilder.DeleteData(
                table: "FinancialTypes",
                keyColumn: "Id",
                keyValue: new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"));

            migrationBuilder.DeleteData(
                table: "FinancialTypes",
                keyColumn: "Id",
                keyValue: new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"));

            migrationBuilder.DeleteData(
                table: "FinancialTypes",
                keyColumn: "Id",
                keyValue: new Guid("cdb105cb-75ec-4dd7-933f-bc132eef42e2"));

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
        }
    }
}
