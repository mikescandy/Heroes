﻿using SQLite;

namespace Core.Models
{
    public abstract class Model
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}