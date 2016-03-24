using Core.Models;
using Heroes.Models;

namespace Heroes
{
    public class Character:Model
    {
        public string Name { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public Alignment Alignment { get; set; }
        public uint Level { get; set; }
        public uint Experience { get; set; }
        public uint Strength { get; set; }
        public uint Dexterity { get; set; }
        public uint Constitution { get; set; }
        public uint Intelligence { get; set; }
        public uint Wisdom { get; set; }
        public uint Charisma { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get;set; }
    }
}
