using System;
using AutoMapper;

namespace Log.Service
{
    public class Mapping :IMapping
    {
        #region Constructors

        public Mapping()
        {
            Init();
        }

        #endregion

        #region Public Methods 

        public TK Map<T, TK>(T obj)
        {
            return Mapper.Map<T, TK>(obj);
        }

        #endregion

        #region Private Methods 

        private void Init()
        {
            Mapper.CreateMap<Domain.LogRecord, Model.LogItem>();
            Mapper.CreateMap<Domain.LogLevel, Model.LogLevel>();
            
            Mapper.CreateMap<Domain.SimpleAggregate, Model.LogAggregate>()
                  .ConvertUsing(x => new Model.LogAggregate{GroupItem = x.Id.GroupItem, Count =x.Count});
            Mapper.CreateMap<Domain.ApplicationErrorAggregate, Model.ApplicationErrorAggregate>()
                  .ConvertUsing(x =>
                                  {
                                      var result = new Model.ApplicationErrorAggregate {Application = x.Application};
                                      foreach(var logCount in x.Errors)
                                      {
                                          result.Errors.Add((Model.LogLevel) Enum.Parse(typeof(Model.LogLevel), Enum.GetName(typeof(Domain.LogLevel), logCount.Level)), logCount.Count);
                                      }
                                      return result;
                                  });

        } 

        #endregion
    }
}
