using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace Heroes.Models
{
    public class AdventuringGear : Equipment
    {
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<CharacterAdventuringGear> CharacterAdventuringGears { get; set; }
    }
}