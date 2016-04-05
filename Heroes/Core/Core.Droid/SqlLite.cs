using System;
using System.IO;
using Core.Droid;
using Core.Services;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace Core.Droid
{
    public class SQLiteAndroid : ISqLite
    {
        private const string SqliteFilename = "Heroes.db3";

        public SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, SqliteFilename);
            // Create the connection

            var conn = new SQLiteConnection(new SQLitePlatformAndroid(), path);
            // Return the database connection
            return conn;
        }
    }
}