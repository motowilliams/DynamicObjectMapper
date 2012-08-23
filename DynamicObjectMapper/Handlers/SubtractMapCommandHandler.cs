using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicObjectMapper
{
    public class SubtractMapCommandHandler : ICommandHandler
    {
        public object Handle(IDictionary<string, object> sourceList, MapperConfig config)
        {
            return config.SourceName.Select(x => Decimal.Parse(sourceList[x].ToString())).Aggregate<decimal, decimal>(0, (current, number) => current - number);
        }
    }
}