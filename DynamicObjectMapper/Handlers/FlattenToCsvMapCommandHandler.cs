using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicObjectMapper
{
    public class FlattenToCsvMapCommandHandler : ICommandHandler
    {
        public object Handle(IDictionary<string, object> sourceList, MapperConfig config)
        {
            string sourceName = config.SourceName.FirstOrDefault();
            if (sourceName == null)
                throw new ArgumentException("Incorrect field name for mapped to {0}", config.DestinationName);

            string[] values = sourceList.FirstOrDefault(x => x.Key.Equals(sourceName)).Value as string[];

            return string.Join(",", values);
        }
    }
}