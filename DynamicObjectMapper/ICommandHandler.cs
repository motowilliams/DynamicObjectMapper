using System;
using System.Collections.Generic;

namespace DynamicObjectMapper
{
    public interface ICommandHandler
    {
        object Handle(IDictionary<string, object> sourceList, MapperConfig config);
    }
}