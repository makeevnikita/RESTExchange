﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using src.Models;

#nullable disable

namespace rest_exchange.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230701061822_AddingNavigationProperty")]
    partial class AddingNavigationProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

            modelBuilder.Entity("MyCurrencyNetwork", b =>
                {
                    b.Property<int>("MyCurrenciesId")
                        .HasColumnType("integer");

                    b.Property<int>("NetworksId")
                        .HasColumnType("integer");

                    b.HasKey("MyCurrenciesId", "NetworksId");

                    b.HasIndex("NetworksId");

                    b.ToTable("MyCurrencyNetwork");
                });

            modelBuilder.Entity("src.Models.ClientCurrency", b =>
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

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("integer");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("ClientCurreny");
                });

            modelBuilder.Entity("src.Models.MyAddresses", b =>
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

            modelBuilder.Entity("src.Models.MyCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Fund")
                        .HasColumnType("numeric");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("integer");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("MyCurrency");
                });

            modelBuilder.Entity("src.Models.Network", b =>
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

            modelBuilder.Entity("src.Models.Order", b =>
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

            modelBuilder.Entity("src.Models.OrderStatus", b =>
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

            modelBuilder.Entity("src.Models.PaymentMethod", b =>
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

            modelBuilder.Entity("src.Models.Role", b =>
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

            modelBuilder.Entity("src.Models.User", b =>
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

            modelBuilder.Entity("ClientCurrencyNetwork", b =>
                {
                    b.HasOne("src.Models.ClientCurrency", null)
                        .WithMany()
                        .HasForeignKey("ClientCurrenciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("src.Models.Network", null)
                        .WithMany()
                        .HasForeignKey("NetworksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyCurrencyNetwork", b =>
                {
                    b.HasOne("src.Models.MyCurrency", null)
                        .WithMany()
                        .HasForeignKey("MyCurrenciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("src.Models.Network", null)
                        .WithMany()
                        .HasForeignKey("NetworksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("src.Models.ClientCurrency", b =>
                {
                    b.HasOne("src.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("ClientCurrencies")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("src.Models.MyAddresses", b =>
                {
                    b.HasOne("src.Models.MyCurrency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("src.Models.Network", "Network")
                        .WithMany()
                        .HasForeignKey("NetworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Network");
                });

            modelBuilder.Entity("src.Models.MyCurrency", b =>
                {
                    b.HasOne("src.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("MyCurrencies")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("src.Models.Order", b =>
                {
                    b.HasOne("src.Models.ClientCurrency", "ClientCurrency")
                        .WithMany()
                        .HasForeignKey("ClientCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("src.Models.Network", "GiveNetwork")
                        .WithMany()
                        .HasForeignKey("GiveNetworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("src.Models.MyAddresses", "MyAddress")
                        .WithMany()
                        .HasForeignKey("MyAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("src.Models.MyCurrency", "MyCurrency")
                        .WithMany()
                        .HasForeignKey("MyCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("src.Models.Network", "ReceiveNetwork")
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

            modelBuilder.Entity("src.Models.User", b =>
                {
                    b.HasOne("src.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("src.Models.PaymentMethod", b =>
                {
                    b.Navigation("ClientCurrencies");

                    b.Navigation("MyCurrencies");
                });

            modelBuilder.Entity("src.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
