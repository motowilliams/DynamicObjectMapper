using System;

namespace DynamicObjectMapper
{
    public class MapperConfig
    {
        public string[] SourceName { get; set; }
        public string DestinationName { get; set; }
        public MapCommand MapCommand { get; set; }
    }
}