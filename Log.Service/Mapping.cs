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
            Mapper.CreateMap<Log.Enum.LogLevel, Log.Enum.LogLevel>();
            
            Mapper.CreateMap<Domain.ApplicationErrorAggregate, Model.ApplicationErrorAggregate>()
                  .ConvertUsing(ConvertAggregate);

        } 

        private Model.ApplicationErrorAggregate ConvertAggregate(Domain.ApplicationErrorAggregate domainAgg)
        {
            var result = new Model.ApplicationErrorAggregate { Application = domainAgg.Application };
            foreach (var logCount in domainAgg.Errors)
            {
                var key = logCount.Level;
                var value = logCount.Count;
                result.Errors.Add(key, value);
            }
            return result;
        }

        #endregion
    }
}
