using System.Collections.Generic;

namespace DynamicObjectMapper
{
    public interface IDynamicObjectMapper<T>
    {
        dynamic Map(T source, IEnumerable<MapperConfig> mapperConfigs);
    }
}