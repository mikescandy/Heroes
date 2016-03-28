using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Core.Validation
{
    public interface IValidatableControl
    {
        string Identifier { get; set; }

        Entry Entry { get; set; }

        Label Message { get; set; }

        void SetMessage(string message);

        void SetMessageColor(Color color);

        void Clear();

        bool HasError { get; set; }
    }

}
