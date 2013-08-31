using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Log.Service
{
    public static class Mapping 
    {
        static Mapping()
        {
            
            Init();

        }

        public static TK Map<T, TK>(T obj)
        {
            return Mapper.Map<T, TK>(obj);
        }

        private static void Init()
        {
            Mapper.CreateMap<Domain.LogRecord, Model.LogItem>();
            Mapper.CreateMap<Domain.LogLevel, Model.LogLevel>();
            Mapper.CreateMap<Domain.SimpleAggregate, Model.LogAggregate>()
                  .ConvertUsing(x => new Model.LogAggregate{GroupItem = x.Id.GroupItem, Count =x.Count});
              
            
                //.ForMember(dest => dest.Key, x => x.MapFrom(source => source.Id.Application ))
                //.ForMember(dest => dest.Value, x => x.MapFrom(source => source.Count));
        }



    }
}
