﻿using AutoMapper;
using Heroes.Models;
using Heroes.PageModels;

namespace Heroes.Mappings
{
    public class AutomapperConfig
    {
        public readonly IMapper Mapper;

        public AutomapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Character, EditCharacterPageModel>();

                cfg.CreateMap<Party, ListItemViewModel>()
                    .ForMember(m => m.Image, opt => opt.UseValue("people.png"))
                    .ForMember(m => m.IsReal, opt => opt.UseValue(true))
                    .ForMember(m => m.TimeStamp, opt => opt.MapFrom(src => src.DateUpdated))
                    .ForMember(m => m.ItemType, opt => opt.UseValue(ItemType.Party))
                    .ForMember(m => m.LineOne, opt => opt.MapFrom(src => string.Format("Number of characters: {0}", src.Characters.Count)));

                cfg.CreateMap<Character, ListItemViewModel>()
                    .ForMember(m => m.Image, opt => opt.UseValue("user.png"))
                    .ForMember(m => m.IsReal, opt => opt.UseValue(true))
                    .ForMember(m => m.TimeStamp, opt => opt.MapFrom(src => src.DateUpdated))
                    .ForMember(m => m.ItemType, opt => opt.UseValue(ItemType.Character))
                    .ForMember(m => m.LineOne, opt => opt.MapFrom(src => string.Format("Class: {0}", src.CharacterClass)))
                    .ForMember(m => m.LineTwo, opt => opt.MapFrom(src => string.Format("Level: {0}", src.Level)))
                    .ForMember(m => m.LineThree, opt => opt.MapFrom(src => string.Format("XP: {0}", src.Experience)));

                cfg.CreateMap<Character, CharacterPageModel>()
                    .ForMember(m => m.StrengthModifier, opt => opt.Ignore())
                    .ForMember(m => m.DexterityModifier, opt => opt.Ignore())
                    .ForMember(m => m.ConstitutionModifier, opt => opt.Ignore())
                    .ForMember(m => m.WisdomModifier, opt => opt.Ignore())
                    .ForMember(m => m.IntelligenceModifer, opt => opt.Ignore())
                    .ForMember(m => m.CharismaModifer, opt => opt.Ignore())
                    .ForMember(m => m.WisdomModifier, opt => opt.Ignore())
                    .ForMember(m => m.RollToHit, opt => opt.Ignore());

            });
            Mapper = config.CreateMapper();
        }
    }
}