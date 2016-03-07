namespace Heroes.Models
{
    public class Weapon:Equipment
    {
        public string Damage { get; set; }
        public bool OneHanded { get; set; }
        public bool TwoHanded { get; set; }

    }
}
