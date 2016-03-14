using System.Collections.Generic;
using Heroes;

namespace Heroes.Services
{
    public interface IRepository
    {
        List<AdventuringGear> GetAllAdventuringGear();
        List<Weapon> GetAllWeapons();
        T Get<T>(int id) where T : Model, new() ;
        void Update<T>(T model) where T : Model;
        T GetLatest<T>() where T : Model, new();
    }
}
