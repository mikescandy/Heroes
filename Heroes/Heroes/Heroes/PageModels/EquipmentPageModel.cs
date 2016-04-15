using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;
using Core.Extensions;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public sealed class EquipmentPageModel : BaseCharacterPageModel
    {
        public double TotalWeight
        { 
            get {
                //Repository.GetAll<AdventuringGear>(Character.CharacterAdventuringGears.Select(m=>m.AdventuringGearId)).Sum(m=>m.);
                return 0;
            } 
        }

        public EquipmentPageModel (IRepository repository) : base(repository)
        {
        }

        public override void Init (object initData)
        {
            base.Init (initData);
            AddEquipmentCommand = new Command (async () => await CoreMethods.PushPageModel<AddEquipmentPageModel> (null, true));
            CharacterAdventuringGears = Character.CharacterAdventuringGears.ToObservable ();
            CharacterAdventuringGears.CollectionChanged += AdventuringGearsOnCollectionChanged;
        }

        public ObservableCollection<CharacterAdventuringGear> CharacterAdventuringGears { get; set; }

        public ICommand AddEquipmentCommand { get; set; }

        public override void ReverseInit (object returndData)
        {
            var item = returndData as EquipmentViewModel;
            if (item != null)
            {
                AddAdventuringGear (item.ID);
            }
            else
            {
                var items = returndData as List<EquipmentViewModel>;

                if (items != null)
                {
                    
                    foreach (var iitem in items)
                    {
                        AddAdventuringGear (item.ID);
                    }
                }
            }

            Repository.Save (Character);
            Character = Repository.Get<Character> (Character.ID);
            Refresh();
            base.ReverseInit (returndData);
        }
        
        private void Refresh()
        {
            CharacterAdventuringGears = Character.CharacterAdventuringGears.ToObservable();
        }

        private void AddAdventuringGear(int id)
        {
           // Character.CharacterAdventuringGears.Add(Repository.Get<AdventuringGear>(id));
            if (Character.CharacterAdventuringGears.Select (m => m.AdventuringGearId).Contains (id)) 
            {
                Character.CharacterAdventuringGears.First (m => m.AdventuringGearId == id).Quantity++;
            } 
            else 
            {
                Character.CharacterAdventuringGears.Add(new CharacterAdventuringGear
                {
                    AdventuringGearId = id,
                    CharacterId = Character.ID,
                    Quantity = 1
                });
            }
        }

        private void AdventuringGearsOnCollectionChanged (object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            RaisePropertyChanged ("TotalWeight");
        }
    }
}