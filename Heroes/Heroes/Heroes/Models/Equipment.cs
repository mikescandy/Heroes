using Core.Models;

namespace Heroes.Models
{
    public abstract class Equipment : Model
    {
        public string Name { get; set; }

        public double Cost { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }
    }
}