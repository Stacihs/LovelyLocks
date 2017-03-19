using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LovelyLocks.Data;

namespace LovelyLocks.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20170318232344_CartUpdate1")]
    partial class CartUpdate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LovelyLocks.Models.Cart", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("TransactionID");

                    b.HasIndex("ProductId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("LovelyLocks.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("LovelyLocks.Models.Cart", b =>
                {
                    b.HasOne("LovelyLocks.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
        }
    }
}
