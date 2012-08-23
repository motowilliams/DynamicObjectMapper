using System;

namespace DynamicObjectMapper.Tests
{
    public class TestObject
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string[] Things { get; set; }
        public int Age { get; set; }
        public Guid Id { get; set; }
        public int Value1 { get; set; }
        public Decimal Value2 { get; set; }
        public double Value3 { get; set; }
    }
}