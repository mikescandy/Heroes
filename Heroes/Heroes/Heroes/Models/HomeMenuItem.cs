using System;

namespace Heroes.Models
{
    public class HomeMenuItem
    {
        public string Title { get; set; }

        public string Icon { get; set; }

        public Type TargetViewModel { get; set; }
    }
}