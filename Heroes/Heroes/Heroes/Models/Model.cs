using SQLite;

namespace Heroes
{
    public abstract class Model
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
