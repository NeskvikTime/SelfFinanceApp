﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
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
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SelfFinanceApp.Domain.Aggregates.FinancialOperation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FinanceTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FinanceTypeId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FinancialOperations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("96cc5657-5952-4c3b-a42a-5e5f7b3e2726"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(982),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(983),
                            FinanceTypeId = new Guid("6f02e2db-3464-4859-b0cd-600b100e2c86"),
                            Name = "Paying bills 06-2023"
                        },
                        new
                        {
                            Id = new Guid("9be65141-fff9-4c86-b528-2de2fc9c8463"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(985),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(985),
                            FinanceTypeId = new Guid("213a6165-fe70-44e8-8745-6a80f0071c98"),
                            Name = "Paying rent 06-2023"
                        },
                        new
                        {
                            Id = new Guid("93ce69e6-9b35-45e5-b5f4-7fefd9fd8e6c"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(987),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(987),
                            FinanceTypeId = new Guid("18c4a168-e83c-4763-bed2-6bd565c455bf"),
                            Name = "Salary 06-2023"
                        },
                        new
                        {
                            Id = new Guid("b06dd3e9-55b9-4ded-a43f-631bc93a880d"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(988),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(988),
                            FinanceTypeId = new Guid("50f46a28-c0e5-4bb6-be11-01a9ee483dd2"),
                            Name = "Dividend 06-2023"
                        },
                        new
                        {
                            Id = new Guid("34e57bf4-bf10-4294-b065-c630e2a6783b"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(991),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(991),
                            FinanceTypeId = new Guid("6f02e2db-3464-4859-b0cd-600b100e2c86"),
                            Name = "Paying bills 07-2023"
                        },
                        new
                        {
                            Id = new Guid("1dee64d7-f084-42e3-a605-234366ef6657"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(993),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(993),
                            FinanceTypeId = new Guid("213a6165-fe70-44e8-8745-6a80f0071c98"),
                            Name = "Paying rent 07-2023"
                        },
                        new
                        {
                            Id = new Guid("77549b3a-f710-47bb-8f13-a9e17e38f196"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(994),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(994),
                            FinanceTypeId = new Guid("18c4a168-e83c-4763-bed2-6bd565c455bf"),
                            Name = "Salary 07-2023"
                        },
                        new
                        {
                            Id = new Guid("91711918-62ca-4351-892f-4828c7565fa6"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(995),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(996),
                            FinanceTypeId = new Guid("50f46a28-c0e5-4bb6-be11-01a9ee483dd2"),
                            Name = "Dividend 07-2023"
                        },
                        new
                        {
                            Id = new Guid("27f01d4c-37e0-49dd-aef5-e92c133439d0"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(997),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(998),
                            FinanceTypeId = new Guid("6f02e2db-3464-4859-b0cd-600b100e2c86"),
                            Name = "Paying bills 08-2023"
                        },
                        new
                        {
                            Id = new Guid("669adc27-0696-4bb0-853b-f6d0475d19a4"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(999),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(999),
                            FinanceTypeId = new Guid("213a6165-fe70-44e8-8745-6a80f0071c98"),
                            Name = "Paying rent 08-2023"
                        },
                        new
                        {
                            Id = new Guid("f80e1d73-594a-4b50-a815-badac614bebb"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1000),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1000),
                            FinanceTypeId = new Guid("18c4a168-e83c-4763-bed2-6bd565c455bf"),
                            Name = "Salary 08-2023"
                        },
                        new
                        {
                            Id = new Guid("8b344516-7529-46ae-9764-386d5f268fe2"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1002),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1002),
                            FinanceTypeId = new Guid("50f46a28-c0e5-4bb6-be11-01a9ee483dd2"),
                            Name = "Dividend 08-2023"
                        },
                        new
                        {
                            Id = new Guid("e506c87d-ed60-4db5-96b8-23de459e160c"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1057),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1058),
                            FinanceTypeId = new Guid("6f02e2db-3464-4859-b0cd-600b100e2c86"),
                            Name = "Paying bills 09-2023"
                        },
                        new
                        {
                            Id = new Guid("93f9f2f5-806e-4271-85e4-4526c284cd46"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1059),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(1059),
                            FinanceTypeId = new Guid("213a6165-fe70-44e8-8745-6a80f0071c98"),
                            Name = "Paying rent 09-2023"
                        });
                });

            modelBuilder.Entity("SelfFinanceApp.Domain.Entities.FinancialType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FinancialTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6f02e2db-3464-4859-b0cd-600b100e2c86"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(806),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(809),
                            Name = "Bills",
                            TransactionType = 2
                        },
                        new
                        {
                            Id = new Guid("213a6165-fe70-44e8-8745-6a80f0071c98"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(814),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(815),
                            Name = "Rent",
                            TransactionType = 2
                        },
                        new
                        {
                            Id = new Guid("18c4a168-e83c-4763-bed2-6bd565c455bf"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(816),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(817),
                            Name = "Salary",
                            TransactionType = 1
                        },
                        new
                        {
                            Id = new Guid("50f46a28-c0e5-4bb6-be11-01a9ee483dd2"),
                            DateCreated = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(818),
                            DateModified = new DateTime(2024, 10, 24, 13, 33, 14, 173, DateTimeKind.Utc).AddTicks(818),
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
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("numeric(18,2)")
                                .HasColumnName("Amount");

                            b1.Property<string>("Currency")
                                .HasMaxLength(3)
                                .HasColumnType("character varying(3)")
                                .HasColumnName("Currency");

                            b1.HasKey("FinancialOperationId");

                            b1.ToTable("FinancialOperations");

                            b1.WithOwner()
                                .HasForeignKey("FinancialOperationId");

                            b1.HasData(
                                new
                                {
                                    FinancialOperationId = new Guid("96cc5657-5952-4c3b-a42a-5e5f7b3e2726"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("9be65141-fff9-4c86-b528-2de2fc9c8463"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("93ce69e6-9b35-45e5-b5f4-7fefd9fd8e6c"),
                                    Amount = 3000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("b06dd3e9-55b9-4ded-a43f-631bc93a880d"),
                                    Amount = 100m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("34e57bf4-bf10-4294-b065-c630e2a6783b"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("1dee64d7-f084-42e3-a605-234366ef6657"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("77549b3a-f710-47bb-8f13-a9e17e38f196"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("91711918-62ca-4351-892f-4828c7565fa6"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("27f01d4c-37e0-49dd-aef5-e92c133439d0"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("669adc27-0696-4bb0-853b-f6d0475d19a4"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("f80e1d73-594a-4b50-a815-badac614bebb"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("8b344516-7529-46ae-9764-386d5f268fe2"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("e506c87d-ed60-4db5-96b8-23de459e160c"),
                                    Amount = 1000m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    FinancialOperationId = new Guid("93f9f2f5-806e-4271-85e4-4526c284cd46"),
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
