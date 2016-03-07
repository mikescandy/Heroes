using System.Collections.Generic;
using System.Linq;
using Heroes;
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
            _database.CreateTable<AdventuringGear>();
            PopulateDatabase();

        }

        private void PopulateDatabase()
        {
            _database.Insert(new AdventuringGear { CostGP = 5, Description = "blah blah blah", Name = "Backpack", Weight = 10 });
            _database.Insert(new AdventuringGear { CostGP = 50, Description = "blah blah blah543453", Name = "Silk rope", Weight = 1 });
        }

        public List<AdventuringGear> GetAllAdventuringGear()
        {
            return _database.Table<AdventuringGear>().ToList();
        }
    }
}
