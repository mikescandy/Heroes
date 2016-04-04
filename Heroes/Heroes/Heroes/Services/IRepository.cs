using System.Collections.Generic;
using Core.Models;
using Heroes;
using System.Linq.Expressions;
using System;

namespace Heroes.Services
{
    public interface IRepository
    {
        List<AdventuringGear> GetAllAdventuringGear();
		List<Weapon> GetAllWeapons();
		List<Character> GetAllCharactersNotInParties();
		T Get<T>(int id) where T : Model, new() ;
		List<T> GetMany<T>(List<int> ids) where T : Model, new();
		List<T> GetAll<T>() where T : Model, new();
		List<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : Model, new();
		void Update<T>(T model) where T : Model;
        T GetLatest<T>() where T : Model, new();
		void Add<T>(List<T> data) where T : Model, new();
		void Add<T>(T item) where T : Model, new();
    }
}
