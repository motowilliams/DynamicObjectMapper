using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace DynamicObjectMapper
{
    public class DynamicObjectMapper<T> : IDynamicObjectMapper<T>
    {
        private IDictionary<string, object> _sourceList;
        private readonly IDictionary<MapCommand, ICommandHandler> _commandHandlers;

        public DynamicObjectMapper()
        {
            _commandHandlers = new Dictionary<MapCommand, ICommandHandler>();
            _commandHandlers.Add(MapCommand.DirectMap, new DirectMapCommandHandler());
            _commandHandlers.Add(MapCommand.Concat, new ConcatMapCommandHandler());
            _commandHandlers.Add(MapCommand.FlattenToCsv, new FlattenToCsvMapCommandHandler());
            _commandHandlers.Add(MapCommand.Multiply, new MultiplyMapCommandHandler());
            _commandHandlers.Add(MapCommand.Subtract, new SubtractMapCommandHandler());
            _commandHandlers.Add(MapCommand.Sum, new SumMapCommandHandler());
        }

        public DynamicObjectMapper(IDictionary<MapCommand, ICommandHandler> commandHandlers)
        {
            _commandHandlers = commandHandlers;
        }

        public dynamic Map(T source, IEnumerable<MapperConfig> mapperConfigs)
        {
            dynamic mappedObject = new ExpandoObject();

            if (_sourceList == null || _sourceList.Count == 0)
                _sourceList = source.GetType().GetProperties().Select(x => new { x.Name, Value = x.GetValue(source, null) }).ToDictionary(v => v.Name, v => v.Value);

            if (_sourceList.Count == 0) return null;

            foreach (MapperConfig config in mapperConfigs)
            {
                var kvp = mappedObject as IDictionary<string, object>;
                ICommandHandler commandHandler = _commandHandlers[config.MapCommand];
                kvp[config.DestinationName] = commandHandler.Handle(_sourceList, config);
            }
            return mappedObject;
        }
    }
}