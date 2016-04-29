using System;
using System.Linq;

namespace Core.Pages
{
    public class TransientPageModel : BasePageModel
    {
        public TransientPageModel()
        {
            Transient = true;
        }
    }
}
