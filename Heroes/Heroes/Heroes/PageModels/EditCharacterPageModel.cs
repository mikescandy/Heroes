using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FreshMvvm;
using Heroes;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Heroes.Validators;
using System.Reflection;

namespace Heroes
{
	[ImplementPropertyChanged]
	public class EditCharacterPageModel : BasePageModel
	{
		private readonly IRepository _repository;
		private readonly CharacterValidator _validator;

		public string Name { get; set; }

		public string NameValidationError { get; set; }

		public CharacterClass CharacterClass { get; set; }

		public Alignment Alignment { get; set; }

		public uint Level { get; set; }

		public uint Experience { get; set; }

		public uint Strength { get; set; }

		public uint Dexterity { get; set; }

		public uint Constitution { get; set; }

		public uint Intelligence { get; set; }

		public uint Wisdom { get; set; }

		public uint Charisma { get; set; }

		public int MaxHP { get; set; }

		[DependsOn("Name")]
		public bool IsValid
		{
			get
			{
				var validationResult = _validator.Validate(this);
				if (validationResult.IsValid)
				{
					foreach (var property in this.GetType().GetTypeInfo().DeclaredProperties.Where(m => m.Name.EndsWith("ValidationError")).ToList())
					{
						property.SetValue(this, string.Empty);
						RaisePropertyChanged(property.Name);
					}
					return true;
				}
				foreach (var result in validationResult.Errors)
				{
					var validationProperty = this.GetType().GetTypeInfo().GetDeclaredProperty(result.PropertyName + "ValidationError");
					if (validationProperty != null)
					{
						validationProperty.SetValue(this, result.ErrorMessage);
						RaisePropertyChanged(validationProperty.Name);
					}
				}
				return true;
			}
		}

		public ObservableCollection<string> Alignments { get; set; }

		public EditCharacterPageModel(IRepository repository)
		{
			Alignments = new ObservableCollection<string>(Enum.GetNames(typeof(Alignment)).ToList());
			_repository = repository;
			_validator = new CharacterValidator();
		}

		public override void Init(object initData)
		{
			base.Init(initData);
			var characterId = (int)initData;
			App.Mapper.Map(_repository.Get<Character>(characterId), this);
			NameValidationError = "aaa";
		}

		public override void ReverseInit(object returndData)
		{
			base.ReverseInit(returndData);
		}
	}
}
