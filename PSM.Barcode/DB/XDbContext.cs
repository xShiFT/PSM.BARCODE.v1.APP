using Microsoft.EntityFrameworkCore;

namespace PSM.Barcode.DB;

public class XDbContext: DbContext
{
	public DbSet<BarcodePairs> BarcodePairs { get; set; }
	public DbSet<Users> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		string pathDbSqlite = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PSM.Barcode.db3");
		optionsBuilder.UseSqlite($"Filename={pathDbSqlite}");
	}
}
