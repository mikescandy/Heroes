using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Heroes;
using Newtonsoft.Json;
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
            _database.CreateTable<Weapon>();
            PopulateDatabase();

        }

        private void PopulateDatabase()
        {
            _database.Insert(new AdventuringGear { Cost = 5, Description = "blah blah blah", Name = "Backpack", Weight = 10 });
            _database.Insert(new AdventuringGear { Cost = 50, Description = "blah blah blah543453", Name = "Silk rope", Weight = 1 });
            LoadData();
        }

        public List<AdventuringGear> GetAllAdventuringGear()
        {
            return _database.Table<AdventuringGear>().ToList();
        }

        public List<Weapon> GetAllWeapons()
        {
            return _database.Table<Weapon>().ToList();
        }


        public void Add<T>(List<T> data)
        {
            _database.InsertAll(data);
        }

        private void LoadData()
        {
            var weaponsJson = ResourceLoader.GetEmbeddedResourceString(GetType().GetTypeInfo().Assembly, "Weapons.json");
            var dynObj = JsonConvert.DeserializeObject<List<Weapon>>(weaponsJson);
            Add(dynObj);
        }
    }
}
