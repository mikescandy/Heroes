using SQLite;

namespace Heroes
{
    public abstract class Equipment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int CostGP { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
    }
}
