using SQLite.Net;

namespace Core.Services
{
    public interface ISqLite
    {
        SQLiteConnection GetConnection ();
    }
}