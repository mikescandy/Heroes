using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Pages;
using FluentValidation.Internal;
using FreshMvvm;
using PropertyChanged;

namespace Heroes
{
    [ImplementPropertyChanged]
    public abstract class BasePageModel: FreshBasePageModel, IBasePageModel
    {
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
