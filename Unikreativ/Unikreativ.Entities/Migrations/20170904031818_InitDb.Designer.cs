using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Unikreativ.Entities.Data;

namespace Unikreativ.Entities.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170904031818_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.Billing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateModified");

                    b.Property<Guid?>("ProjectId");

                    b.Property<double>("RateOfTask");

                    b.Property<Guid>("TasksRequestId");

                    b.Property<double>("Total");

                    b.Property<double>("WorkingTime");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TasksRequestId")
                        .IsUnique();

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignBy");

                    b.Property<string>("AssignTo");

                    b.Property<DateTime>("DateAssigned");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsCompleted");

                    b.Property<Guid?>("ProjectId");

                    b.Property<string>("TaskName");

                    b.Property<Guid?>("TasksRequestId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TasksRequestId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.MediaFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("FileName");

                    b.Property<Guid?>("TasksRequestId");

                    b.Property<string>("UploadDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TasksRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("MediaFiles");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AgreementDate");

                    b.Property<string>("ClientId");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("ProjectDescription");

                    b.Property<string>("ProjectName");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.SubTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateModified");

                    b.Property<Guid?>("ProjectId");

                    b.Property<string>("SubTaskName");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("SubTasks");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.TasksRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignBy");

                    b.Property<string>("AssignTo");

                    b.Property<double>("CompleteRate");

                    b.Property<double>("CostOfTask");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime>("Due");

                    b.Property<bool>("IsCompleted");

                    b.Property<Guid?>("ProjectId");

                    b.Property<DateTime>("StartDate");

                    b.Property<Guid?>("SubTaskId");

                    b.Property<string>("TaskName");

                    b.Property<double>("WorkingTime");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SubTaskId");

                    b.ToTable("TasksRequests");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<double>("ChargeRate");

                    b.Property<string>("CompanyName");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<string>("Industry");

                    b.Property<string>("JobTitle");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Unikreativ.Entities.Entities.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Unikreativ.Entities.Entities.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Unikreativ.Entities.Entities.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.Billing", b =>
                {
                    b.HasOne("Unikreativ.Entities.Entities.Project", "Project")
                        .WithMany("Billings")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Unikreativ.Entities.Entities.TasksRequest", "TasksRequest")
                        .WithOne("Billing")
                        .HasForeignKey("Unikreativ.Entities.Entities.Billing", "TasksRequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.Event", b =>
                {
                    b.HasOne("Unikreativ.Entities.Entities.Project", "Project")
                        .WithMany("Events")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Unikreativ.Entities.Entities.TasksRequest", "TasksRequest")
                        .WithMany()
                        .HasForeignKey("TasksRequestId");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.MediaFile", b =>
                {
                    b.HasOne("Unikreativ.Entities.Entities.TasksRequest", "TasksRequest")
                        .WithMany("MediaFiles")
                        .HasForeignKey("TasksRequestId");

                    b.HasOne("Unikreativ.Entities.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.Project", b =>
                {
                    b.HasOne("Unikreativ.Entities.Entities.User", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.SubTask", b =>
                {
                    b.HasOne("Unikreativ.Entities.Entities.Project", "Project")
                        .WithMany("SubTasks")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Unikreativ.Entities.Entities.TasksRequest", b =>
                {
                    b.HasOne("Unikreativ.Entities.Entities.Project", "Project")
                        .WithMany("TasksRequests")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Unikreativ.Entities.Entities.SubTask", "SubTask")
                        .WithMany("TasksRequests")
                        .HasForeignKey("SubTaskId");
                });
        }
    }
}
