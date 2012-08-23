using System;
using Xunit;

namespace DynamicObjectMapper.Tests
{
    public class Function : Context
    {
        [Fact]
        public void Multiply()
        {
            var mapper = new DynamicObjectMapper<TestObject>();
            TestObject testObject = new TestObject { Value1 = 1, Value2 = 2.1M, Value3 = 3.01D };

            dynamic object2 = mapper.Map(testObject, new[] { _testConfigDictionary["MultiplyConfig"] });

            Assert.Equal(6.321M, object2.TotalSumValue);
        }

        [Fact]
        public void Subtract()
        {
            var mapper = new DynamicObjectMapper<TestObject>();
            TestObject testObject = new TestObject { Value1 = 1, Value2 = 2.1M, Value3 = 3.01D };

            dynamic object2 = mapper.Map(testObject, new[] { _testConfigDictionary["SubtractConfig"] });

            Assert.Equal(-6.11M, object2.TotalSumValue);
        }

        [Fact]
        public void Sum()
        {
            var mapper = new DynamicObjectMapper<TestObject>();
            TestObject testObject = new TestObject { Value1 = 1, Value2 = 2.1M, Value3 = 3.01D };

            dynamic object2 = mapper.Map(testObject, new[] { _testConfigDictionary["SumConfig"] });

            Assert.Equal(6.11M, object2.TotalSumValue);
        }
    }
}