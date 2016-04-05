using System.Collections.Generic;
using Core.Models;
using Heroes;
using System.Linq.Expressions;
using System;
using Core;
using Core.Services;

namespace Heroes.Services
{
    public interface IRepository:IGenericRepository
    {
        List<AdventuringGear> GetAllAdventuringGear ();

        List<Weapon> GetAllWeapons ();

        List<Character> GetAllCharactersNotInParties ();
    }
}
