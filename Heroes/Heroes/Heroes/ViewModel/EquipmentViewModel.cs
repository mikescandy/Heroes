using System.ComponentModel;
using System.Runtime.CompilerServices;
using Heroes.Annotations;
using Heroes.Models;
using PropertyChanged;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class EquipmentViewModel : INotifyPropertyChanged
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }

        public double Weight { get; set; }

        public bool IsSelected { get; set; }

        public bool CheckboxVisible { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public EquipmentViewModel (AdventuringGear gear)
        {
            Name = gear.Name;
            Cost = gear.Cost;
            Weight = gear.Weight;
            ID = gear.ID;
            IsSelected = false;
            CheckboxVisible = false;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}