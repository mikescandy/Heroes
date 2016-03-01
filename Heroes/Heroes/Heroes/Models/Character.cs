﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes
{
    public class Character
    {
        public string Name { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public uint Level { get; set; }
        public uint Experience { get; set; }
        public uint Strength { get; set; }
    }

    public enum CharacterClass
    {
        Fighter,
        Dwarf

    }
}
