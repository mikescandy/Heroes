﻿using System;
using Core.Models;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core
{
	public interface IGenericRepository
	{
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