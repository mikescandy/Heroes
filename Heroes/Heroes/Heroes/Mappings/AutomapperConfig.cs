using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

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
            });
            Mapper = config.CreateMapper();
        }
    }
}
