using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core;
using Core.Models;
using Core.Services;
using Heroes.Models;
using Newtonsoft.Json;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace Heroes.Services
{
    public class Repository : IRepository
    {
        private readonly SQLiteConnection database;

        public Repository ()
        {
            database = DependencyService.Get<ISqLite> ().GetConnection ();
            database.CreateTable<Party> ();
            database.CreateTable<Character> (); 
            database.CreateTable<AdventuringGear> ();
            database.CreateTable<Weapon> ();
            database.CreateTable<Settings> ();
            database.CreateTable<CharacterAdventuringGear> ();
            PopulateDatabase ();
        }

        public List<AdventuringGear> GetAllAdventuringGear ()
        {
            return database.Table<AdventuringGear> ().ToList ();
        }

        public List<Weapon> GetAllWeapons ()
        {
            return database.Table<Weapon> ().ToList ();
        }

        public List<Character> GetAllCharactersNotInParties ()
        {
            return database.GetAllWithChildren<Character> (m => m.PartyId == 0).ToList ();
        }

        public T Get<T> (int id) where T : Model, new()
        {
            var res = database.GetWithChildren<T> (id, true);
            database.GetChildren(res, true);
            return res;
        }

        public IList<T> GetMany<T> (IList<int> ids) where T : Model, new()
        {
            return database.Table<T> ().Where (m => ids.Contains (m.ID)).ToList ();
        }

        public IList<T> GetAll<T> () where T : Model, new()
        {
            return database.GetAllWithChildren<T> ().ToList ();
        }

        public IList<T> GetAll<T> (System.Linq.Expressions.Expression<System.Func<T, bool>> predicate) where T : Model, new()
        {
            return database.Table<T> ().Where (predicate).ToList ();
        }

        public void Update<T> (T model) where T : Model
        {
            model.DateUpdated = DateTime.Now.ToUniversalTime ().Ticks;
            database.InsertOrReplaceWithChildren (model);
        }

        public void Update<T>(IList<T> data) where T : Model
        {
            foreach (var item in data)
            {
                item.DateUpdated = DateTime.Now.ToUniversalTime().Ticks;
            }
            database.InsertOrReplaceAllWithChildren(data);
        }

        public void Save<T>(T model) where T : Model
        {
         var now =    DateTime.Now.ToUniversalTime().Ticks;
            model.DateUpdated = now;
            if (model.DateCreated == default(double))
            {
                model.DateCreated = now; ;
            }
            database.InsertOrReplaceWithChildren(model);
        }

        public void Save<T>(IList<T> data) where T : Model
        {
            var now = DateTime.Now.ToUniversalTime().Ticks;
            foreach (var item in data)
            {
                item.DateUpdated = now;
                if(item.DateCreated ==  default(double))
                {
                    item.DateCreated = now;
                }
            }
            database.InsertOrReplaceAllWithChildren(data);
        }


        public T GetLatest<T> () where T : Model, new()
        {
            return database.Table<T> ().OrderByDescending (m => m.ID).FirstOrDefault ();
        }

        public void Add<T> (IList<T> data) where T : Model, new()
        {
            foreach (var item in data)
            {
                item.DateCreated = DateTime.Now.ToUniversalTime ().Ticks;
                item.DateUpdated = DateTime.Now.ToUniversalTime ().Ticks;
            }

            database.InsertOrReplaceAllWithChildren (data);
        }

        public void Add<T> (T item) where T : Model, new()
        {
            item.DateCreated = DateTime.Now.ToUniversalTime ().Ticks;
            item.DateUpdated = DateTime.Now.ToUniversalTime ().Ticks;
            database.InsertOrReplaceWithChildren (item);
        }

        private void PopulateDatabase ()
        {
            var settings = GetLatest<Settings> ();
            if (settings == null)
            {
                var id = database.Insert (new Party {
                    Name = "Fellowship of the ring",
                });
                database.Insert (new Character {
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
                    PartyId = id
                });
                database.Insert (new Character {
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

                LoadData ();
                settings = new Settings { FirstRun = true };
                database.Insert (settings);
            }
        }

        private void LoadData ()
        {
            var weaponsJson = ResourceLoader.GetEmbeddedResourceString (GetType ().GetTypeInfo ().Assembly, "Weapons.json");
            var dynObj = JsonConvert.DeserializeObject<IList<Weapon>> (weaponsJson);
            Add (dynObj);
            var adventuringGearResource = ResourceLoader.GetEmbeddedResourceString (GetType ().GetTypeInfo ().Assembly, "AdventuringGear.json");
            var adventuringGears = JsonConvert.DeserializeObject<IList<AdventuringGear>> (adventuringGearResource);
            Add (adventuringGears);
        }
    }
}