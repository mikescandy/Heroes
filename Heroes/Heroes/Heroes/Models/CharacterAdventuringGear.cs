using SQLiteNetExtensions.Attributes;
using Core.Models;

namespace Heroes.Models
{
    public class CharacterAdventuringGear : Model
    {
        [ForeignKey (typeof (Character))]
        public int CharacterId { get; set; }

        [ManyToOne]
        public Character Character { get; set; }

        [ForeignKey (typeof (AdventuringGear))]
        public int AdventuringGearId { get; set; }

        [ManyToOne]
        public AdventuringGear AdventuringGear { get; set; }

        public int Quantity { get; set; }
    }
}