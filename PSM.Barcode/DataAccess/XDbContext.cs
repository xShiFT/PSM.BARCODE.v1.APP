using PSM.Barcode.Models;
using PSM.Barcode.Utilities;
using Microsoft.EntityFrameworkCore;

namespace PSM.Barcode.DataAccess;

public class XDbContext: DbContext
{
	public DbSet<BarcodePairs> BarcodePairs { get; set; }
	public DbSet<Users> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		string connectionDb = $"Filename={PathDB.GetPath("test.db")}";
		optionsBuilder.UseSqlite(connectionDb);
	}
}
