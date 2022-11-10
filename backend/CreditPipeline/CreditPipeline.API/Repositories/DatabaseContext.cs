using CreditPipeline.Model;
using Microsoft.EntityFrameworkCore;

namespace CreditPipeline.API.Repositories;

public sealed class DatabaseContext : DbContext
{
    #region Tables

    /// <summary>
    /// Таблица с данными о пользователях
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;
    
    /// <summary>
    /// Таблица с данными о стратегиях
    /// </summary>
    public DbSet<Strategy> Strategies { get; set; } = null!;
    
    /// <summary>
    /// Таблица с данными об истории стратегий
    /// </summary>
    public DbSet<StrategyHistory> StrategyHistories { get; set; } = null!;
    
    /// <summary>
    /// Таблица связей стратегий и метрик
    /// </summary>
    public DbSet<StrategyMetricRelation> StrategyMetricRelations { get; set; } = null!;
    
    /// <summary>
    /// Таблица с данными о метриках
    /// </summary>
    public DbSet<Metric> Metrics { get; set; } = null!;

    /// <summary>
    /// Заявки
    /// </summary>
    public DbSet<Request> Requests { get; set; } = null!;

    #endregion
    
    public DatabaseContext() { }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
    {
        if (Database.GetPendingMigrations().Any())
            Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Login).IsRequired();
            entity.Property(e => e.Password).IsRequired();
        });

        modelBuilder.Entity<Strategy>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Version).IsRequired();
            entity.Property(e => e.MinDept).IsRequired();
            entity.Property(e => e.MinDivorce).IsRequired();
            entity.Property(e => e.MaxPeriod).IsRequired();
            entity.Property(e => e.MaxSumma).IsRequired();

            entity.HasMany(e => e.Requests)
                .WithOne(e => e.Strategy)
                .HasForeignKey(e => e.StrategyId);
            
            entity.HasMany(e => e.StrategyMetricRelations)
                .WithOne(e => e.Strategy)
                .HasForeignKey(e => e.StrategyId);

            entity.HasMany(e => e.StrategyHistories)
                .WithOne(e => e.Strategy)
                .HasForeignKey(e => e.StrategyId);
        });

        modelBuilder.Entity<StrategyHistory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Version).IsRequired();
            entity.Property(e => e.Created).IsRequired().HasDefaultValueSql("now()");

            entity.HasOne(e => e.Strategy)
                .WithMany(e => e.StrategyHistories)
                .HasForeignKey(e => e.StrategyId);
        });

        modelBuilder.Entity<Metric>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Raw).IsRequired();
            
            entity.HasMany(e => e.StrategyMetricRelations)
                .WithOne(e => e.Metric)
                .HasForeignKey(e => e.MetricId);
        });
        
        modelBuilder.Entity<StrategyMetricRelation>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Strategy)
                .WithMany(e => e.StrategyMetricRelations)
                .HasForeignKey(e => e.StrategyId);
            
            entity.HasOne(e => e.Metric)
                .WithMany(e => e.StrategyMetricRelations)
                .HasForeignKey(e => e.MetricId);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Inn).IsRequired();
            entity.Property(e => e.MinDept).IsRequired();
            entity.Property(e => e.Period).IsRequired();
            entity.Property(e => e.Summa).IsRequired();
            entity.Property(e => e.Created).IsRequired().HasDefaultValueSql("now()");
            
            entity.HasOne(e => e.Strategy)
                .WithMany(e => e.Requests)
                .HasForeignKey(e => e.StrategyId);
        });

        base.OnModelCreating(modelBuilder);
    }
}
