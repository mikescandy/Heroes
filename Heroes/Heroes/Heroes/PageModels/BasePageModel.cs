using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using PropertyChanged;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class BasePageModel: FreshBasePageModel
    {
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
