using SQLite;

namespace Core.Services
{
    public interface ISqLite
    {
        SQLiteConnection GetConnection();
    }
}
