using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicObjectMapper
{
    public class MultiplyMapCommandHandler : ICommandHandler
    {
        public object Handle(IDictionary<string, object> sourceList, MapperConfig config)
        {
            return config.SourceName.Select(x => Decimal.Parse(sourceList[x].ToString())).Aggregate<decimal, decimal>(1, (current, number) => current * number);
        }
    }
}