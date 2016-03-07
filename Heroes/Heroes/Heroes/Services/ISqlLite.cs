using SQLite;

namespace Heroes.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
