using System.IO;
using Core.Droid;
using Core.Services;
using Xamarin.Forms;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency (typeof(SqLiteAndroid))]
namespace Core.Droid
{
	public class SqLiteAndroid : ISqLite
	{
		private const string SqliteFilename = "Heroes.db3";

		public SQLite.Net.SQLiteConnection GetConnection ()
		{
			var documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine (documentsPath, SqliteFilename);
			// Create the connection
			var conn = new SQLite.Net.SQLiteConnection (new SQLitePlatformAndroid (), SqliteFilename);
			// Return the database connection
			return conn;
		}
	}
}