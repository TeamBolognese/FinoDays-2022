// <auto-generated />
using System;
using CreditPipeline.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CreditPipeline.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221110030105_AddNameToStrategy")]
    partial class AddNameToStrategy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CreditPipeline.Model.Metric", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Raw")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Metrics");
                });

            modelBuilder.Entity("CreditPipeline.Model.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("MinDept")
                        .HasColumnType("double precision");

                    b.Property<double>("Period")
                        .HasColumnType("double precision");

                    b.Property<Guid>("StrategyId")
                        .HasColumnType("uuid");

                    b.Property<double>("Summa")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("StrategyId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("CreditPipeline.Model.Strategy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("MaxPeriod")
                        .HasColumnType("double precision");

                    b.Property<double>("MaxSumma")
                        .HasColumnType("double precision");

                    b.Property<double>("MinDept")
                        .HasColumnType("double precision");

                    b.Property<double>("MinDivorce")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Strategies");
                });

            modelBuilder.Entity("CreditPipeline.Model.StrategyHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid>("StrategyId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StrategyId");

                    b.ToTable("StrategyHistories");
                });

            modelBuilder.Entity("CreditPipeline.Model.StrategyMetricRelation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("MetricId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StrategyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MetricId");

                    b.HasIndex("StrategyId");

                    b.ToTable("StrategyMetricRelations");
                });

            modelBuilder.Entity("CreditPipeline.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CreditPipeline.Model.Request", b =>
                {
                    b.HasOne("CreditPipeline.Model.Strategy", "Strategy")
                        .WithMany("Requests")
                        .HasForeignKey("StrategyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Strategy");
                });

            modelBuilder.Entity("CreditPipeline.Model.StrategyHistory", b =>
                {
                    b.HasOne("CreditPipeline.Model.Strategy", "Strategy")
                        .WithMany("StrategyHistories")
                        .HasForeignKey("StrategyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Strategy");
                });

            modelBuilder.Entity("CreditPipeline.Model.StrategyMetricRelation", b =>
                {
                    b.HasOne("CreditPipeline.Model.Metric", "Metric")
                        .WithMany("StrategyMetricRelations")
                        .HasForeignKey("MetricId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CreditPipeline.Model.Strategy", "Strategy")
                        .WithMany("StrategyMetricRelations")
                        .HasForeignKey("StrategyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Metric");

                    b.Navigation("Strategy");
                });

            modelBuilder.Entity("CreditPipeline.Model.Metric", b =>
                {
                    b.Navigation("StrategyMetricRelations");
                });

            modelBuilder.Entity("CreditPipeline.Model.Strategy", b =>
                {
                    b.Navigation("Requests");

                    b.Navigation("StrategyHistories");

                    b.Navigation("StrategyMetricRelations");
                });
#pragma warning restore 612, 618
        }
    }
}
