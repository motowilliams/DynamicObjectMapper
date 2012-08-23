using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicObjectMapper
{
    public class ConcatMapCommandHandler : ICommandHandler
    {
        public object Handle(IDictionary<string, object> sourceList, MapperConfig config)
        {
            return string.Join(" ", config.SourceName.Select(x => sourceList[x]));
        }
    }
}