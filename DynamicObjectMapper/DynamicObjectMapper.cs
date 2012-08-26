using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace DynamicObjectMapper
{
    public class DynamicObjectMapper<T> : IDynamicObjectMapper<T>
    {
        private readonly IDictionary<string, object> _sourceList;
        private readonly IDictionary<MapCommand, ICommandHandler> _commandHandlers;
        private readonly PropertyInfo[] _propertyInfoCollection;

        public DynamicObjectMapper(IDictionary<MapCommand, ICommandHandler> commandHandlers)
        {
            _commandHandlers = commandHandlers;
            _propertyInfoCollection = typeof(T).GetProperties();
            _sourceList = new Dictionary<string, object>();
        }

        public dynamic Map(T source, IEnumerable<MapperConfig> mapperConfigs)
        {
            dynamic mappedObject = new ExpandoObject();

            foreach (MapperConfig config in mapperConfigs)
            {
                //create local cache of the reflected data
                foreach (var sourceNameItem in config.SourceName.Where(sourceNameItem => _sourceList.ContainsKey(sourceNameItem) == false))
                    _sourceList.Add(sourceNameItem, _propertyInfoCollection.First(x => x.Name.Equals(sourceNameItem)).GetValue(source, null));

                var kvp = mappedObject as IDictionary<string, object>;
                ICommandHandler commandHandler = _commandHandlers[config.MapCommand];
                kvp[config.DestinationName] = commandHandler.Handle(_sourceList, config);
            }
            return mappedObject;
        }
    }
}