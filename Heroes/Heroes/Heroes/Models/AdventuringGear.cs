using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace Heroes.Models
{
    public class AdventuringGear : Equipment
    {
        [ManyToMany(typeof(CharacterAdventuringGear))]
        public List<Character> Characters { get; set; }
    }
}