﻿using System.Collections.Generic;
using FreshMvvm;
using Heroes;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class AddEquipmentPageModel : FreshBasePageModel 
    {
        private readonly IRepository _repository;
        public AddEquipmentPageModel(IRepository repository)
        {
            _repository = repository;
            AdventuringGears = _repository.GetAllAdventuringGear();

        }
        public List<AdventuringGear> AdventuringGears { get; set; }

        public AdventuringGear SelectedAdventuringGear { get; set; }
    }
}
