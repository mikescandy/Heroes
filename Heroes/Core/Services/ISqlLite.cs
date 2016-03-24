using SQLite;

namespace Core.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
