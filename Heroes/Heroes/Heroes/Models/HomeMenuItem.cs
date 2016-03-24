using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Models
{
    public class HomeMenuItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetViewModel { get; set; }
    }
}
