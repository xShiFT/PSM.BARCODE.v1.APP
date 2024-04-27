using System.ComponentModel.DataAnnotations;

namespace PSM.Barcode.Models;

public class BarcodePairs
{
	[Key]
	public required string BarCode { get; set; }
	public required string OutCode { get; set; }
}

public class Users
{
	[Key]
	public int UserId { get;set; }
	public required string Login { get; set; }
	public required string Password { get; set; }
	public required string FName { get; set; }
	public required string MName { get; set; }
	public required string SName { get; set; }
}