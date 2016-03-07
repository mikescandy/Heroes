using System.Collections.Generic;
using Heroes.Models;

namespace Heroes.Services
{
    public interface IRepository
    {
        List<AdventuringGear> GetAllAdventuringGear();
    }
}
