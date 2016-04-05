using System;
using System.IO;
using Core.Services;
using Heroes.iOS;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteiOS))]
namespace Heroes.iOS
{
    public class SQLiteiOS : ISqLite
    {
        private const string SqliteFilename = "Heroes.db3";

        public SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, SqliteFilename);
            // Create the connection

            var conn = new SQLiteConnection(new SQLitePlatformIOS(), path);
            // Return the database connection
            return conn;
        }
    }
}