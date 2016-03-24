using Core.Services;

using Heroes.Droid;

using Xamarin.Forms;

using System.IO;

[assembly: Dependency(typeof(SqLiteAndroid))]
namespace Heroes.Droid
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