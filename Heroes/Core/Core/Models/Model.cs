﻿using SQLite.Net.Attributes;

namespace Core.Models
{
    public abstract class Model
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public double DateCreated { get; set; }

        public double DateUpdated { get; set; }
    }
}