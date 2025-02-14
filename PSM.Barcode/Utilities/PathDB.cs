﻿namespace PSM.Barcode.Utilities;

public class PathDB
{
	public static string GetPath(string nameDb)
	{
		string pathDbSqlite = string.Empty;
		if (DeviceInfo.Platform == DevicePlatform.Android)
		{
			pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			pathDbSqlite = Path.Combine(pathDbSqlite, nameDb);
		}
		else if (DeviceInfo.Platform == DevicePlatform.iOS)
		{
			pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			pathDbSqlite = Path.Combine(pathDbSqlite, "..", "Library", nameDb);

		}
		return pathDbSqlite;
	}
}
