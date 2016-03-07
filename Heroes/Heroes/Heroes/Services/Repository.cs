using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace Heroes.Services
{
    public class Repository : IRepository
    {
        private readonly SQLiteConnection _database;

        public Repository()
        {
            _database = DependencyService.Get<ISQLite>().GetConnection();
            _database.CreateTable<Character>();
        }
    }
}
