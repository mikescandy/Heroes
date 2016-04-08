using System;

namespace Core.Navigation
{
    public struct NavigationObject
    {
        public Type DestinationViewModel { get; set; }

        public object PayLoad{ get; set; }

        public bool Modal{ get; set; }
    }
}