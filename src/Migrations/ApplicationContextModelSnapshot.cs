﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace rest_exchange.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClientCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("ClientCurrency", (string)null);
                });

            modelBuilder.Entity("ClientCurrencyNetwork", b =>
                {
                    b.Property<int>("ClientCurrenciesId")
                        .HasColumnType("integer");

                    b.Property<int>("NetworksId")
                        .HasColumnType("integer");

                    b.HasKey("ClientCurrenciesId", "NetworksId");

                    b.HasIndex("NetworksId");

                    b.ToTable("ClientCurrencyNetwork");
                });

            modelBuilder.Entity("MyAddresses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Address")
                        .HasMaxLength(256)
                        .HasColumnType("integer");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("integer");

                    b.Property<int>("NetworkId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("NetworkId");

                    b.ToTable("MyAddress");
                });

            modelBuilder.Entity("Network", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Network");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientAddress")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("ClientCurrencyId")
                        .HasColumnType("integer");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GiveNetworkId")
                        .HasColumnType("integer");

                    b.Property<decimal>("GiveSum")
                        .HasColumnType("numeric");

                    b.Property<int>("MyAddressId")
                        .HasColumnType("integer");

                    b.Property<int>("MyCurrencyId")
                        .HasColumnType("integer");

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.Property<string>("RandomString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ReceiveNetworkId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ReceiveSum")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClientCurrencyId");

                    b.HasIndex("GiveNetworkId");

                    b.HasIndex("MyAddressId");

                    b.HasIndex("MyCurrencyId");

                    b.HasIndex("ReceiveNetworkId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MyCurrency", b =>
                {
                    b.HasBaseType("ClientCurrency");

                    b.Property<decimal>("Fund")
                        .HasColumnType("numeric");

                    b.Property<int?>("PaymentMethodId")
                        .HasColumnType("integer");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("MyCurrency", (string)null);
                });

            modelBuilder.Entity("ClientCurrencyNetwork", b =>
                {
                    b.HasOne("ClientCurrency", null)
                        .WithMany()
                        .HasForeignKey("ClientCurrenciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Network", null)
                        .WithMany()
                        .HasForeignKey("NetworksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyAddresses", b =>
                {
                    b.HasOne("MyCurrency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Network", "Network")
                        .WithMany()
                        .HasForeignKey("NetworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Network");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("ClientCurrency", "ClientCurrency")
                        .WithMany()
                        .HasForeignKey("ClientCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Network", "GiveNetwork")
                        .WithMany()
                        .HasForeignKey("GiveNetworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAddresses", "MyAddress")
                        .WithMany()
                        .HasForeignKey("MyAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCurrency", "MyCurrency")
                        .WithMany()
                        .HasForeignKey("MyCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Network", "ReceiveNetwork")
                        .WithMany()
                        .HasForeignKey("ReceiveNetworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientCurrency");

                    b.Navigation("GiveNetwork");

                    b.Navigation("MyAddress");

                    b.Navigation("MyCurrency");

                    b.Navigation("ReceiveNetwork");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.HasOne("Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MyCurrency", b =>
                {
                    b.HasOne("ClientCurrency", null)
                        .WithOne()
                        .HasForeignKey("MyCurrency", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaymentMethod", null)
                        .WithMany("MyCurrencies")
                        .HasForeignKey("PaymentMethodId");
                });

            modelBuilder.Entity("PaymentMethod", b =>
                {
                    b.Navigation("MyCurrencies");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
