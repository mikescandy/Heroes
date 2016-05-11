using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core;
using Core.Models;
using Core.Services;
using Newtonsoft.Json;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace Core.Services
{
    public abstract class GenericRepository : IGenericRepository
    {
        protected readonly SQLiteConnection Database;

        public GenericRepository()
        {
            Database = DependencyService.Get<ISqLite> ().GetConnection ();
        }

        public T Get<T> (int id) where T : Model, new()
        {
            var res = Database.GetWithChildren<T> (id, true);
            Database.GetChildren(res, true);
            return res;
        }

        public IList<T> GetMany<T> (IList<int> ids) where T : Model, new()
        {
            return Database.Table<T> ().Where (m => ids.Contains (m.ID)).ToList ();
        }

        public IList<T> GetAll<T> () where T : Model, new()
        {
            return Database.GetAllWithChildren<T> ().ToList ();
        }

        public IList<T> GetAll<T> (System.Linq.Expressions.Expression<System.Func<T, bool>> predicate) where T : Model, new()
        {
            return Database.Table<T> ().Where (predicate).ToList ();
        }

        public void Update<T> (T model) where T : Model
        {
            model.DateUpdated = DateTime.Now.ToUniversalTime ().Ticks;
            Database.InsertOrReplaceWithChildren (model);
        }

        public void Update<T>(IList<T> data) where T : Model
        {
            foreach (var item in data)
            {
                item.DateUpdated = DateTime.Now.ToUniversalTime().Ticks;
            }
            Database.InsertOrReplaceAllWithChildren(data);
        }

        public void Save<T>(T model) where T : Model
        {
         var now =    DateTime.Now.ToUniversalTime().Ticks;
            model.DateUpdated = now;
            if (model.DateCreated == default(double))
            {
                model.DateCreated = now; ;
            }
            Database.InsertOrReplaceWithChildren(model);
        }

        public void Save<T>(IList<T> data) where T : Model
        {
            var now = DateTime.Now.ToUniversalTime().Ticks;
            foreach (var item in data)
            {
                item.DateUpdated = now;
                if(item.DateCreated ==  default(double))
                {
                    item.DateCreated = now;
                }
            }
            Database.InsertOrReplaceAllWithChildren(data);
        }


        public T GetLatest<T> () where T : Model, new()
        {
            return Database.Table<T> ().OrderByDescending (m => m.ID).FirstOrDefault ();
        }

        public void Add<T> (IList<T> data) where T : Model, new()
        {
            foreach (var item in data)
            {
                item.DateCreated = DateTime.Now.ToUniversalTime ().Ticks;
                item.DateUpdated = DateTime.Now.ToUniversalTime ().Ticks;
            }

            Database.InsertOrReplaceAllWithChildren (data);
        }

        public void Add<T> (T item) where T : Model, new()
        {
            item.DateCreated = DateTime.Now.ToUniversalTime ().Ticks;
            item.DateUpdated = DateTime.Now.ToUniversalTime ().Ticks;
            Database.InsertOrReplaceWithChildren (item);
        }
    }
}