using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicObjectMapper
{
    public class DirectMapCommandHandler : ICommandHandler
    {
        public object Handle(IDictionary<string, object> sourceList, MapperConfig config)
        {
            return sourceList[config.SourceName.First()];
        }
    }
}