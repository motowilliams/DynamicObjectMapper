using System;
using System.Collections.Generic;

namespace DynamicObjectMapper.Tests
{
    public class Context
    {
        protected readonly Dictionary<string, MapperConfig> _testConfigDictionary;
        protected Dictionary<MapCommand, ICommandHandler> commandHandlers;

        public Context()
        {
            string json = string.Empty;
            json += "[";
            json += "  { \"MapCommand\" : \"Subtract\", \"DestinationName\" : \"TotalSumValue\", \"SourceName\" : [ \"Value1\",\"Value2\",\"Value3\" ] }";
            json += ", { \"MapCommand\" : \"Sum\", \"DestinationName\" : \"TotalSumValue\", \"SourceName\" : [ \"Value1\",\"Value2\",\"Value3\" ] }";
            json += ", { \"MapCommand\" : \"DirectMap\", \"DestinationName\" : \"Identification\", \"SourceName\" : [ \"Id\" ] }";
            json += ", { \"MapCommand\" : \"DirectMap\", \"DestinationName\" : \"Age\", \"SourceName\" : [ \"Age\" ] }";
            json += ", { \"MapCommand\" : \"FlattenToCsv\", \"DestinationName\" : \"FlattenedThings\", \"SourceName\" : [ \"Things\" ] }";
            json += ", { \"MapCommand\" : \"Concat\", \"DestinationName\" : \"Name\", \"SourceName\" : [ \"FirstName\", \"MiddleName\", \"LastName\" ] }";
            json += ", { \"MapCommand\" : \"DirectMap\", \"DestinationName\" : \"FName\", \"SourceName\" : [ \"FirstName\" ] }";
            json += ", { \"MapCommand\" : \"DirectMap\", \"DestinationName\" : \"LName\", \"SourceName\" : [ \"LastName\" ] }";
            json += ", { \"MapCommand\" : \"Multiply\", \"DestinationName\" : \"TotalSumValue\", \"SourceName\" : [ \"Value1\",\"Value2\",\"Value3\" ] }";
            json += "]";

            List<MapperConfig> _mapperConfigs = ServiceStack.Text.JsonSerializer.DeserializeFromString<List<MapperConfig>>(json);

            _testConfigDictionary = new Dictionary<string, MapperConfig>();
            _testConfigDictionary.Add("SubtractConfig", _mapperConfigs[0]);
            _testConfigDictionary.Add("SumConfig", _mapperConfigs[1]);
            _testConfigDictionary.Add("GuidConfig", _mapperConfigs[2]);
            _testConfigDictionary.Add("IntConfig", _mapperConfigs[3]);
            _testConfigDictionary.Add("FlattenToCsvConfig", _mapperConfigs[4]);
            _testConfigDictionary.Add("ConcatConfig", _mapperConfigs[5]);
            _testConfigDictionary.Add("StringFirstNameConfig", _mapperConfigs[6]);
            _testConfigDictionary.Add("StringLastNameConfig", _mapperConfigs[7]);
            _testConfigDictionary.Add("MultiplyConfig", _mapperConfigs[8]);

            commandHandlers = new Dictionary<MapCommand, ICommandHandler>();
            commandHandlers.Add(MapCommand.DirectMap, new DirectMapCommandHandler());
            commandHandlers.Add(MapCommand.Concat, new ConcatMapCommandHandler());
            commandHandlers.Add(MapCommand.FlattenToCsv, new FlattenToCsvMapCommandHandler());
            commandHandlers.Add(MapCommand.Multiply, new MultiplyMapCommandHandler());
            commandHandlers.Add(MapCommand.Subtract, new SubtractMapCommandHandler());
            commandHandlers.Add(MapCommand.Sum, new SumMapCommandHandler());
        }
    }
}