﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fiscus.Model;

#nullable disable

namespace fiscus.Migrations
{
    [DbContext(typeof(FiscusDbContext))]
    partial class FiscusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("fiscus.Model.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DueTo")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DUE_TO");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("ISSUED_AT");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int")
                        .HasColumnName("RECIPIENT_ID");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.ToTable("INVOICES");
                });

            modelBuilder.Entity("fiscus.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int")
                        .HasColumnName("INVOICE_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NAME");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("PRICE");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("QUANTITY");

                    b.Property<decimal>("TaxRate")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("TAX_RATE");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("POSITIONS");
                });

            modelBuilder.Entity("fiscus.Model.Recipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CITY");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("COUNTRY");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NAME");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PHONE");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("POSTAL_CODE");

                    b.Property<string>("Salutation")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("SALUTATION");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("STREET");

                    b.HasKey("Id");

                    b.ToTable("RECIPIENTS");
                });

            modelBuilder.Entity("fiscus.Model.Invoice", b =>
                {
                    b.HasOne("fiscus.Model.Recipient", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("fiscus.Model.Position", b =>
                {
                    b.HasOne("fiscus.Model.Invoice", "Invoice")
                        .WithMany("Positions")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("fiscus.Model.Invoice", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
