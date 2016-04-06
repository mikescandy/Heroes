using System.Collections.Generic;
using Core.Models;
using SQLiteNetExtensions.Attributes;

namespace Heroes.Models
{
    public class Party : Model
    {
        public string Name { get; set; }

        [OneToMany (CascadeOperations = CascadeOperation.All)]      // One to many relationship with Valuation
        public List<Character> Characters { get; set; }
    }
}