using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Core.Pages;
using Heroes.Data;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public sealed class CharacterPageModel : BaseCharacterPageModel
    {
        public string Strength { get; set; }
        public string Dexterity { get; set; }
        public string Constitution { get; set; }
        public string Intelligence { get; set; }
        public string Wisdom { get; set; }
        public string Charisma { get; set; }
        public string StrengthModifier { get; set; }
        public string DexterityModifier { get; set; }
        public string ConstitutionModifier { get; set; }
        public string WisdomModifier { get; set; }
        public int[] RollToHit { get; set; }

        public ICommand EditCommand { get; set; }

        

        public CharacterPageModel(IRepository repository) : base(repository)
        {
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            App.Mapper.Map(Character, this);
            CalculateBonuses();
            CalculateHitModifiers();
            EditCommand = new Command(async () => await CoreMethods.PushPageModel<EditCharacterPageModel>(Character.ID, true));
        }

        public override void ReverseInit(object returndData)
        {
            var character = returndData as Character;
            if (character != null)
            {
                Repository.Update(character);
                Character = Repository.Get<Character>(character.ID);
            }
        }

        private void CalculateBonuses()
        {
            StrengthModifier = Tables.ModifierTable[Character.Strength].ToString();
            DexterityModifier = Tables.ModifierTable[Character.Dexterity].ToString();
            ConstitutionModifier = Tables.ModifierTable[Character.Constitution].ToString();
        }

        private void CalculateHitModifiers()
        {
            switch (Character.CharacterClass)
            {
                case CharacterClass.Cleric:
                case CharacterClass.Thieve:
                    GetClericAndThiefHitModifier();
                    break;
                case CharacterClass.Fighter:
                case CharacterClass.Dwarf:
                case CharacterClass.Elf:
                case CharacterClass.Halflingm:
                    GetFighterHitModifier();
                    break;
                case CharacterClass.MagicUser:
                    GetMageHitModifier();
                    break;
            }
        }

        private void GetMageHitModifier()
        {
            int[] table;
            switch (Character.Level)
            {
                case 1:
                case 2:
                case 3:
                    table = Tables.ToHitTable[1];
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                    table = Tables.ToHitTable[2];
                    break;
                case 8:
                case 9:
                case 10:
                    table = Tables.ToHitTable[3];
                    break;
                case 11:
                case 12:
                    table = Tables.ToHitTable[4];
                    break;
                case 13:
                    table = Tables.ToHitTable[5];
                    break;
                case 14:
                case 15:
                    table = Tables.ToHitTable[6];
                    break;
                case 16:
                case 17:
                case 18:
                    table = Tables.ToHitTable[7];
                    break;
                case 19:
                case 20:
                    table = Tables.ToHitTable[8];
                    break;
                case 21:
                case 22:
                case 23:
                    table = Tables.ToHitTable[9];
                    break;
                default:
                    table = Tables.ToHitTable[10];
                    break;

            }
            RollToHit = table.Skip(6).Take(10).ToArray();
        }

        private void GetFighterHitModifier()
        {
            int[] table;
            switch (Character.Level)
            {
                case 1:
                case 2:
                    table = Tables.ToHitTable[1];
                    break;
                case 3:
                    table = Tables.ToHitTable[2];
                    break;
                case 4:
                    table = Tables.ToHitTable[3];
                    break;
                case 5:
                    table = Tables.ToHitTable[4];
                    break;
                case 6:
                    table = Tables.ToHitTable[5];
                    break;
                case 7:
                case 8:
                    table = Tables.ToHitTable[6];
                    break;
                case 9:
                    table = Tables.ToHitTable[7];
                    break;
                case 10:
                case 11:
                    table = Tables.ToHitTable[8];
                    break;
                case 12:
                    table = Tables.ToHitTable[9];
                    break;
                case 13:
                    table = Tables.ToHitTable[10];
                    break;
                case 14:
                    table = Tables.ToHitTable[11];
                    break;
                case 15:
                    table = Tables.ToHitTable[12];
                    break;
                case 16:
                    table = Tables.ToHitTable[13];
                    break;
                case 17:
                    table = Tables.ToHitTable[14];
                    break;
                case 18:
                    table = Tables.ToHitTable[15];
                    break;
                case 19:
                    table = Tables.ToHitTable[16];
                    break;
                default:
                    table = Tables.ToHitTable[16];
                    break;

            }
            RollToHit = table.Skip(6).Take(10).ToArray();
        }

        private void GetClericAndThiefHitModifier()
        {
            int[] table;
            switch (Character.Level)
            {
                case 1:
                case 2:
                case 3:
                    table = Tables.ToHitTable[1];
                    break;
                case 4:
                case 5:
                    table = Tables.ToHitTable[2];
                    break;
                case 6:
                case 7:
                case 8:
                    table = Tables.ToHitTable[3];
                    break;
                case 9:
                case 10:
                    table = Tables.ToHitTable[4];
                    break;
                case 11:
                    table = Tables.ToHitTable[5];
                    break;
                case 12:
                    table = Tables.ToHitTable[6];
                    break;
                case 13:
                case 14:
                    table = Tables.ToHitTable[7];
                    break;
                case 15:
                case 16:
                    table = Tables.ToHitTable[8];
                    break;
                case 17:
                case 18:
                    table = Tables.ToHitTable[9];
                    break;
                case 19:
                case 20:
                    table = Tables.ToHitTable[10];
                    break;
                default:
                    table = Tables.ToHitTable[11];
                    break;

            }
            RollToHit = table.Skip(6).Take(10).ToArray();
        }
    }
}