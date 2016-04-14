using SQLiteNetExtensions.Attributes;
using Core.Models;

namespace Heroes.Models
{
    public class CharacterAdventuringGear : Model
    {
        [ForeignKey (typeof (Character))]
        public int CharacterId { get; set; }

        [ForeignKey (typeof (AdventuringGear))]
        public int AdventuringGearId { get; set; }

        public int Quantity { get; set; }
    }
}