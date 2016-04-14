using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Models;

namespace Core.Services
{
    public interface IGenericRepository
    {
        T Get<T> (int id) where T : Model, new();

        IList<T> GetMany<T> (IList<int> ids) where T : Model, new();

        IList<T> GetAll<T> () where T : Model, new();

        IList<T> GetAll<T> (Expression<Func<T, bool>> predicate) where T : Model, new();

        void Update<T> (T model) where T : Model; 

        void Update<T>(IList<T> data) where T : Model;

        void Save<T>(T model) where T : Model;

        void Save<T>(IList<T> data) where T : Model;

        T GetLatest<T> () where T : Model, new();

        void Add<T> (IList<T> data) where T : Model, new();

        void Add<T> (T item) where T : Model, new();
    }
}