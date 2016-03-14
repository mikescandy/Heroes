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
            PopulateDatabase();

        }

        private void PopulateDatabase()
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

        public T Get<T>(int id) where T : Model, new()
        {
            return _database.Get<T>(id);
        }

        public void Update<T>(T model) where T : Model
        {
            _database.Update(model);
        }

        public Character GetLatestCharacter()
        {
            return _database.Table<Character>().OrderByDescending(m => m.ID).FirstOrDefault();
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
