﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tenants.Infrastructure.Data;

#nullable disable

namespace Tenants.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tenants.Domain.Entities.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentTenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentTenantId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("Tenants.Domain.Entities.TenantUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantUsers");
                });

            modelBuilder.Entity("Tenants.Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantUserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Tenants.Domain.Entities.Tenant", b =>
                {
                    b.HasOne("Tenants.Domain.Entities.Tenant", "ParentTenant")
                        .WithMany("SubTenants")
                        .HasForeignKey("ParentTenantId");

                    b.Navigation("ParentTenant");
                });

            modelBuilder.Entity("Tenants.Domain.Entities.TenantUser", b =>
                {
                    b.HasOne("Tenants.Domain.Entities.Tenant", "Tenant")
                        .WithMany("Users")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Tenants.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Tenants.Domain.Entities.TenantUser", "TenantUser")
                        .WithMany("Roles")
                        .HasForeignKey("TenantUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TenantUser");
                });

            modelBuilder.Entity("Tenants.Domain.Entities.Tenant", b =>
                {
                    b.Navigation("SubTenants");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Tenants.Domain.Entities.TenantUser", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
