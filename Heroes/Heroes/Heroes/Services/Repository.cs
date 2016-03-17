using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Heroes;
using Heroes.Models;
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
            _database.CreateTable<Settings>();
            PopulateDatabase();
        }

        public List<AdventuringGear> GetAllAdventuringGear()
        {
            return _database.Table<AdventuringGear>().ToList();
        }

        public List<Weapon> GetAllWeapons()
        {
            return _database.Table<Weapon>().ToList();
        }

        public T Get<T>(int id) where T : Model, new()
        {
            return _database.Get<T>(id);
        }

        public List<T> GetMany<T>(List<int> ids) where T : Model, new()
        {
            return _database.Table<T>().Where(m => ids.Contains(m.ID)).ToList();
        }

        public void Update<T>(T model) where T : Model
        {
            _database.Update(model);
        }

        public T GetLatest<T>() where T : Model, new()
        {
            return _database.Table<T>().OrderByDescending(m => m.ID).FirstOrDefault();
        }

        public void Add<T>(List<T> data)
        {
            _database.InsertAll(data);
        }

        private void PopulateDatabase()
        {
            var settings = GetLatest<Settings>();
            if (settings == null)
            {
                _database.Insert(new Character
                {
                    Name = "Scypia the Acolyte",
                    CharacterClass = CharacterClass.Cleric,
                    Alignment = Alignment.Neutrality,
                    Level = 1,
                    Experience = 0,
                    MaxHP = 7,
                    CurrentHP = 7,
                    Strength = 9,
                    Dexterity = 9,
                    Constitution = 14,
                    Intelligence = 14,
                    Wisdom = 14,
                    Charisma = 18,
                });
                LoadData();
                settings = new Settings { FirstRun = true };
                _database.Insert(settings);
            }
        }

        private void LoadData()
        {
            var weaponsJson = ResourceLoader.GetEmbeddedResourceString(GetType().GetTypeInfo().Assembly, "Weapons.json");
            var dynObj = JsonConvert.DeserializeObject<List<Weapon>>(weaponsJson);
            Add(dynObj);
            var adventuringGearResource = ResourceLoader.GetEmbeddedResourceString(GetType().GetTypeInfo().Assembly, "AdventuringGear.json");
            var adventuringGears = JsonConvert.DeserializeObject<List<AdventuringGear>>(adventuringGearResource);
            Add(adventuringGears);
        }
    }
}
