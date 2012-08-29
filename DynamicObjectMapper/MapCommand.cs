using System;

namespace DynamicObjectMapper
{
    [Serializable]
    public enum MapCommand
    {
        DirectMap,
        Concat,
        FlattenToCsv,
        Sum,
        Subtract,
        Multiply
    }
}