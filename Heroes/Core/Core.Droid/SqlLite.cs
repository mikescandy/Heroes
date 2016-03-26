using System.IO;
using Core.Droid;
using Core.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteAndroid))]
namespace Core.Droid
{
	public class SqLiteAndroid : ISQLite
	{
		const string SqliteFilename = "Heroes.db3";

		public SQLite.SQLiteConnection GetConnection()
		{
			var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, SqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path);
			// Return the database connection
			return conn;
		}
	}
}