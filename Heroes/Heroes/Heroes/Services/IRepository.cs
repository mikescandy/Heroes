using System.Collections.Generic;
using Core.Services;
using Heroes.Models;

namespace Heroes.Services
{
    public interface IRepository:IGenericRepository
    {
        List<AdventuringGear> GetAllAdventuringGear ();

        List<Weapon> GetAllWeapons ();

        List<Character> GetAllCharactersNotInParties ();
    }
}