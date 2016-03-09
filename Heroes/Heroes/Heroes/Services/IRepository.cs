using System.Collections.Generic;
using Heroes;

namespace Heroes.Services
{
    public interface IRepository
    {
        List<AdventuringGear> GetAllAdventuringGear();
        List<Weapon> GetAllWeapons();
    }
}
