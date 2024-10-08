﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfFinanceApp.Persistance.DatabaseContext;

#nullable disable

namespace SelfFinanceApp.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231111103817_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("29d75494-9dd1-4c10-8bee-98d428799b9f"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3485),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3485),
                            FinanceTypeId = new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"),
                            Name = "Paying bills 06-2023"
                        },
                        new
                        {
                            Id = new Guid("2bd3e809-66a4-4979-a0e8-103d0c02418c"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3487),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3487),
                            FinanceTypeId = new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"),
                            Name = "Paying rent 06-2023"
                        },
                        new
                        {
                            Id = new Guid("7810396b-5642-44a6-aa70-72badfab9739"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3498),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3499),
                            FinanceTypeId = new Guid("666751e6-7409-48bf-9d7a-4ef3b161a52c"),
                            Name = "Salary 06-2023"
                        },
                        new
                        {
                            Id = new Guid("6f233ccc-5d7e-4a42-a804-2f26806e6c52"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3500),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3500),
                            FinanceTypeId = new Guid("53e1dde8-8665-4889-a864-54bb47abfca7"),
                            Name = "Dividend 06-2023"
                        },
                        new
                        {
                            Id = new Guid("bdef6e09-eec7-433a-90be-efd62ccca1e2"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3501),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3501),
                            FinanceTypeId = new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"),
                            Name = "Paying bills 07-2023"
                        },
                        new
                        {
                            Id = new Guid("d92216be-9d16-46da-906f-d96c984b95c5"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3502),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3503),
                            FinanceTypeId = new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"),
                            Name = "Paying rent 07-2023"
                        },
                        new
                        {
                            Id = new Guid("f8fc23aa-9713-4e6d-a71e-4314a6a02bb8"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3504),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3504),
                            FinanceTypeId = new Guid("666751e6-7409-48bf-9d7a-4ef3b161a52c"),
                            Name = "Salary 07-2023"
                        },
                        new
                        {
                            Id = new Guid("61973c5e-62d9-4cf3-81c0-4690914a21a7"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3505),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3505),
                            FinanceTypeId = new Guid("53e1dde8-8665-4889-a864-54bb47abfca7"),
                            Name = "Dividend 07-2023"
                        },
                        new
                        {
                            Id = new Guid("fe59224c-92a2-4f9b-9d1c-73d521b80522"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3506),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3506),
                            FinanceTypeId = new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"),
                            Name = "Paying bills 08-2023"
                        },
                        new
                        {
                            Id = new Guid("b230237d-528f-4243-ba2e-69b3aafc7f72"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3507),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3508),
                            FinanceTypeId = new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"),
                            Name = "Paying rent 08-2023"
                        },
                        new
                        {
                            Id = new Guid("b8af3e17-c4e6-44e7-b8ba-4075b5f76b94"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3511),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3511),
                            FinanceTypeId = new Guid("666751e6-7409-48bf-9d7a-4ef3b161a52c"),
                            Name = "Salary 08-2023"
                        },
                        new
                        {
                            Id = new Guid("cb1e939d-b5f8-407d-ba0d-32e15b5027e9"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3512),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3512),
                            FinanceTypeId = new Guid("53e1dde8-8665-4889-a864-54bb47abfca7"),
                            Name = "Dividend 08-2023"
                        },
                        new
                        {
                            Id = new Guid("6fcd2a3e-ef43-4edc-b6c7-7aeaaa97b55c"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3514),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3514),
                            FinanceTypeId = new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"),
                            Name = "Paying bills 09-2023"
                        },
                        new
                        {
                            Id = new Guid("c886ba9b-8a1a-4c7c-baf4-f9d2e81e978e"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3515),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3515),
                            FinanceTypeId = new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"),
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
                            Id = new Guid("f74f1256-4668-4738-b36a-d6db4de8bff6"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3425),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3425),
                            Name = "Bills",
                            TransactionType = 2
                        },
                        new
                        {
                            Id = new Guid("f9142c1e-148d-4675-a660-bd72c0691bb6"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3428),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3428),
                            Name = "Rent",
                            TransactionType = 2
                        },
                        new
                        {
                            Id = new Guid("666751e6-7409-48bf-9d7a-4ef3b161a52c"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3430),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3431),
                            Name = "Salary",
                            TransactionType = 1
                        },
                        new
                        {
                            Id = new Guid("53e1dde8-8665-4889-a864-54bb47abfca7"),
                            DateCreated = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3432),
                            DateModified = new DateTime(2023, 11, 11, 10, 38, 17, 685, DateTimeKind.Utc).AddTicks(3432),
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
                                    FinancialOperationId = new Guid("29d75494-9dd1-4c10-8bee-98d428799b9f"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("2bd3e809-66a4-4979-a0e8-103d0c02418c"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("7810396b-5642-44a6-aa70-72badfab9739"),
                                    Amount = 3000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("6f233ccc-5d7e-4a42-a804-2f26806e6c52"),
                                    Amount = 100m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("bdef6e09-eec7-433a-90be-efd62ccca1e2"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("d92216be-9d16-46da-906f-d96c984b95c5"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("f8fc23aa-9713-4e6d-a71e-4314a6a02bb8"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("61973c5e-62d9-4cf3-81c0-4690914a21a7"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("fe59224c-92a2-4f9b-9d1c-73d521b80522"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("b230237d-528f-4243-ba2e-69b3aafc7f72"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("b8af3e17-c4e6-44e7-b8ba-4075b5f76b94"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("cb1e939d-b5f8-407d-ba0d-32e15b5027e9"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("6fcd2a3e-ef43-4edc-b6c7-7aeaaa97b55c"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("c886ba9b-8a1a-4c7c-baf4-f9d2e81e978e"),
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
