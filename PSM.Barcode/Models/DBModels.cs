using System.ComponentModel.DataAnnotations;

namespace PSM.Barcode.Models;

public class BarcodePairs
{
	[Key]
	public required string Barcode { get; set; }
	public string Outcode { get; set; }
}

public class Users
{
	[Key]
	public int UserId { get;set; }
	public string Login { get; set; }
	public string Password { get; set; }
	public string FName { get; set; }
	public string MName { get; set; }
	public string SName { get; set; }
}