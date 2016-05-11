using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core;
using Core.Services;
using Heroes.Models;
using Newtonsoft.Json;
using SQLiteNetExtensions.Extensions;

namespace Heroes.Services
{
    public class Repository : GenericRepository, IRepository
    {
        public Repository ()
        {
            Database.CreateTable<Party> ();
            Database.CreateTable<Character> (); 
            Database.CreateTable<AdventuringGear> ();
            Database.CreateTable<Weapon> ();
            Database.CreateTable<Settings> ();
            Database.CreateTable<CharacterAdventuringGear> ();
            PopulateDatabase ();
        }

        public List<AdventuringGear> GetAllAdventuringGear ()
        {
            return Database.Table<AdventuringGear> ().ToList ();
        }

        public List<Weapon> GetAllWeapons ()
        {
            return Database.Table<Weapon> ().ToList ();
        }

        public List<Character> GetAllCharactersNotInParties ()
        {
            return Database.GetAllWithChildren<Character> (m => m.PartyId == 0).ToList ();
        }

        private void PopulateDatabase ()
        {
            var settings = GetLatest<Settings> ();
            if (settings == null)
            {
                var id = Database.Insert (new Party {
                    Name = "Fellowship of the ring",
                });
                Database.Insert (new Character {
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
                Database.Insert (new Character {
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
                Database.Insert (settings);
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