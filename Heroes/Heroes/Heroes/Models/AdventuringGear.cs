using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;
using Core.Models;

namespace Heroes.Models
{
    public class AdventuringGear : Equipment
    {
        [OneToMany]
        public List<CharacterAdventuringGear> CharacterAdventuringGears { get; set; }
    }
}