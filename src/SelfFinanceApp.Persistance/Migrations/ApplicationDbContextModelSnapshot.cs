﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfFinanceApp.Persistance.DatabaseContext;

#nullable disable

namespace SelfFinanceApp.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SelfFinanceApp.Domain.Aggregates.FinancialOperation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FinanceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FinanceTypeId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("FinancialOperations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("547c2245-d09e-4b20-b62d-a01837494bf5"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6004),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6005),
                            FinanceTypeId = new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"),
                            Name = "Paying bills 06-2023"
                        },
                        new
                        {
                            Id = new Guid("28a62127-cf52-4f43-bb7e-37c520eb1e2f"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6006),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6006),
                            FinanceTypeId = new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"),
                            Name = "Paying rent 06-2023"
                        },
                        new
                        {
                            Id = new Guid("aef9a0be-8017-4d8d-abd2-f331e6115b8e"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6007),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6008),
                            FinanceTypeId = new Guid("4cda61d0-a2c4-4415-bc07-85882a06dd64"),
                            Name = "Salary 06-2023"
                        },
                        new
                        {
                            Id = new Guid("d3c45fb2-31f7-432c-81dd-a30dae33840d"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6009),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6009),
                            FinanceTypeId = new Guid("cdb105cb-75ec-4dd7-933f-bc132eef42e2"),
                            Name = "Dividend 06-2023"
                        },
                        new
                        {
                            Id = new Guid("edae0f23-218e-4dd4-976d-6267cb1bf41b"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6010),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6010),
                            FinanceTypeId = new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"),
                            Name = "Paying bills 07-2023"
                        },
                        new
                        {
                            Id = new Guid("855f16cc-75a9-453e-8047-5ef4ef672ac7"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6011),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6012),
                            FinanceTypeId = new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"),
                            Name = "Paying rent 07-2023"
                        },
                        new
                        {
                            Id = new Guid("b8c505c5-081c-42cb-aba3-d49f2be6af4e"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6013),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6013),
                            FinanceTypeId = new Guid("4cda61d0-a2c4-4415-bc07-85882a06dd64"),
                            Name = "Salary 07-2023"
                        },
                        new
                        {
                            Id = new Guid("532409d5-280a-407f-a591-d1fdd7326569"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6016),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6017),
                            FinanceTypeId = new Guid("cdb105cb-75ec-4dd7-933f-bc132eef42e2"),
                            Name = "Dividend 07-2023"
                        },
                        new
                        {
                            Id = new Guid("22ff8b94-e19a-4869-89c8-b251ab97d992"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6018),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6018),
                            FinanceTypeId = new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"),
                            Name = "Paying bills 08-2023"
                        },
                        new
                        {
                            Id = new Guid("04f8a3b7-70c2-4adb-a344-df16d419b8f4"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6019),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6019),
                            FinanceTypeId = new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"),
                            Name = "Paying rent 08-2023"
                        },
                        new
                        {
                            Id = new Guid("c9cf6ae4-1402-46e0-89eb-99d9f40ed5b7"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6021),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6021),
                            FinanceTypeId = new Guid("4cda61d0-a2c4-4415-bc07-85882a06dd64"),
                            Name = "Salary 08-2023"
                        },
                        new
                        {
                            Id = new Guid("19d35009-f4d3-47ed-b659-3f71632da71f"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6022),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6022),
                            FinanceTypeId = new Guid("cdb105cb-75ec-4dd7-933f-bc132eef42e2"),
                            Name = "Dividend 08-2023"
                        },
                        new
                        {
                            Id = new Guid("0c6a785d-03cf-49ab-b3ed-56b28503edff"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6023),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6024),
                            FinanceTypeId = new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"),
                            Name = "Paying bills 09-2023"
                        },
                        new
                        {
                            Id = new Guid("0609fde0-d78b-40ea-9634-47bf1079f8e7"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6025),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(6025),
                            FinanceTypeId = new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"),
                            Name = "Paying rent 09-2023"
                        });
                });

            modelBuilder.Entity("SelfFinanceApp.Domain.Entities.FinancialType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("FinancialTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99bf341b-17e3-4cc7-9648-b86bde0faf7c"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5933),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5935),
                            Name = "Bills",
                            TransactionType = 2
                        },
                        new
                        {
                            Id = new Guid("c8ed5ec6-9aed-4139-b44a-dd86c5d1acd7"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5937),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5938),
                            Name = "Rent",
                            TransactionType = 2
                        },
                        new
                        {
                            Id = new Guid("4cda61d0-a2c4-4415-bc07-85882a06dd64"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5939),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5939),
                            Name = "Salary",
                            TransactionType = 1
                        },
                        new
                        {
                            Id = new Guid("cdb105cb-75ec-4dd7-933f-bc132eef42e2"),
                            DateCreated = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5949),
                            DateModified = new DateTime(2023, 11, 12, 9, 33, 17, 350, DateTimeKind.Utc).AddTicks(5949),
                            Name = "Dividends",
                            TransactionType = 1
                        });
                });

            modelBuilder.Entity("SelfFinanceApp.Domain.Aggregates.FinancialOperation", b =>
                {
                    b.HasOne("SelfFinanceApp.Domain.Entities.FinancialType", "FinanceType")
                        .WithMany("FinancialOperations")
                        .HasForeignKey("FinanceTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("SelfFinanceApp.Domain.ValueObjects.MonetaryValue", "Money", b1 =>
                        {
                            b1.Property<Guid>("FinancialOperationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Amount");

                            b1.Property<string>("Currency")
                                .HasMaxLength(3)
                                .HasColumnType("nvarchar(3)")
                                .HasColumnName("Currency");

                            b1.HasKey("FinancialOperationId");

                            b1.ToTable("FinancialOperations");

                            b1.WithOwner()
                                .HasForeignKey("FinancialOperationId");

                            b1.HasData(
                                new
                                {
                                    FinancialOperationId = new Guid("547c2245-d09e-4b20-b62d-a01837494bf5"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("28a62127-cf52-4f43-bb7e-37c520eb1e2f"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("aef9a0be-8017-4d8d-abd2-f331e6115b8e"),
                                    Amount = 3000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("d3c45fb2-31f7-432c-81dd-a30dae33840d"),
                                    Amount = 100m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("edae0f23-218e-4dd4-976d-6267cb1bf41b"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("855f16cc-75a9-453e-8047-5ef4ef672ac7"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("b8c505c5-081c-42cb-aba3-d49f2be6af4e"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("532409d5-280a-407f-a591-d1fdd7326569"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("22ff8b94-e19a-4869-89c8-b251ab97d992"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("04f8a3b7-70c2-4adb-a344-df16d419b8f4"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("c9cf6ae4-1402-46e0-89eb-99d9f40ed5b7"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("19d35009-f4d3-47ed-b659-3f71632da71f"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("0c6a785d-03cf-49ab-b3ed-56b28503edff"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("0609fde0-d78b-40ea-9634-47bf1079f8e7"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                });
                        });

                    b.Navigation("FinanceType");

                    b.Navigation("Money");
                });

            modelBuilder.Entity("SelfFinanceApp.Domain.Entities.FinancialType", b =>
                {
                    b.Navigation("FinancialOperations");
                });
#pragma warning restore 612, 618
        }
    }
}
