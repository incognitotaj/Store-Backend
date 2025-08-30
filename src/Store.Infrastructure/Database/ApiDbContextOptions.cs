namespace Store.Infrastructure.Database;

public class ApiDbContextOptions
{
    public required string ConnectionString { get; set; }
    public required string DefaultSchema { get; set; } = "dbo";
    public required string MigrationHistoryTableName { get; set; } = "MigrationHistory";
}
