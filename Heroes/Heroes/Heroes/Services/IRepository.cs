﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes.Models;

namespace Heroes.Services
{
    public interface IRepository
    {
        List<AdventuringGear> GetAllAdventuringGear();
    }
}
