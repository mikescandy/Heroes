using System;
using Core.Models;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Heroes
{
	public class Party : Model
	{
		public string Name {get; set;}
		[OneToMany(CascadeOperations = CascadeOperation.All)]      // One to many relationship with Valuation
		public List<Character> Characters { get; set; }
	}
}