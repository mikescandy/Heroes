using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core;
using Core.Models;
using Core.Services;
using Heroes;
using Heroes.Models;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;
using SQLite.Net;
using System;
using SQLiteNetExtensions.Extensions;

namespace Heroes.Services
{
	public class Repository : IRepository
    {
        private readonly SQLiteConnection _database;

        public Repository()
        {
            _database = DependencyService.Get<ISqLite>().GetConnection();
			_database.CreateTable<Party>();
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

		public List<Character> GetAllCharactersNotInParties ()
		{
			return _database.GetAllWithChildren<Character> (m=>m.PartyId==0).ToList ();
		}

        public T Get<T>(int id) where T : Model, new()
        {
            return _database.Get<T>(id);
        }

        public List<T> GetMany<T>(List<int> ids) where T : Model, new()
        {
            return _database.Table<T>().Where(m => ids.Contains(m.ID)).ToList();
        }

		public List<T> GetAll<T> () where T : Model, new()
		{
			return _database.GetAllWithChildren<T> ().ToList ();
		}

		public List<T> GetAll<T> (System.Linq.Expressions.Expression<System.Func<T, bool>> predicate) where T : Model, new()
		{
			return _database.Table<T> ().Where(predicate).ToList ();
		}

        public void Update<T>(T model) where T : Model
        {
			model.DateUpdated = DateTime.Now.ToUniversalTime ().Ticks;
            _database.Update(model);
        }

        public T GetLatest<T>() where T : Model, new()
        {
            return _database.Table<T>().OrderByDescending(m => m.ID).FirstOrDefault();
        }

		public void Add<T>(List<T> data) where T : Model, new()
        {
			foreach (var item in data) {
				item.DateCreated = DateTime.Now.ToUniversalTime ().Ticks;
				item.DateUpdated = DateTime.Now.ToUniversalTime ().Ticks;
			}	

			_database.InsertAll(data);
        }

		public void Add<T> (T item) where T : Model, new()
		{
			item.DateCreated = DateTime.Now.ToUniversalTime ().Ticks;
			item.DateUpdated = DateTime.Now.ToUniversalTime ().Ticks;
			_database.Insert (item);
		}

        private void PopulateDatabase()
        {
            var settings = GetLatest<Settings>();
            if (settings == null)
            {
				var id = _database.Insert(new Party
					{
						Name = "Fellowship of the ring",
					});
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
					PartyId=id
                });
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
