using System;
using Xunit;

namespace DynamicObjectMapper.Tests
{
    public class Map : Context
    {
        [Fact]
        public void Guid()
        {
            var mapper = new DynamicObjectMapper<TestObject>();
            Guid id = new Guid("9d020be8-3f97-4674-aeec-afc2735f64d5");
            TestObject testObject = new TestObject { Id = id };

            dynamic object2 = mapper.Map(testObject, new[] { _testConfigDictionary["GuidConfig"] });

            Assert.Equal(id, object2.Identification);
        }

        [Fact]
        public void Int()
        {
            var mapper = new DynamicObjectMapper<TestObject>();
            TestObject testObject = new TestObject { Age = 10 };

            dynamic object2 = mapper.Map(testObject, new[] { _testConfigDictionary["IntConfig"] });

            Assert.Equal(10, object2.Age);
        }

        [Fact]
        public void FlattenToCsv()
        {
            var mapper = new DynamicObjectMapper<TestObject>();
            TestObject testObject = new TestObject { Things = new[] { "Thing1", "Thing2", "Thing3" } };

            dynamic object2 = mapper.Map(testObject, new[] { _testConfigDictionary["FlattenToCsvConfig"] });

            Assert.Equal("Thing1,Thing2,Thing3", object2.FlattenedThings);
        }

        [Fact]
        public void Concat()
        {
            var mapper = new DynamicObjectMapper<TestObject>();
            TestObject testObject = new TestObject { FirstName = "Foo", LastName = "Bar", MiddleName = "J" };

            dynamic object2 = mapper.Map(testObject, new[] { _testConfigDictionary["ConcatConfig"] });

            Assert.Equal("Foo J Bar", object2.Name);
        }

        [Fact]
        public void String()
        {
            var mapper = new DynamicObjectMapper<TestObject>();
            TestObject testObject = new TestObject { FirstName = "Foo", LastName = "Bar" };

            dynamic object2 = mapper.Map(testObject, new[] { _testConfigDictionary["StringFirstNameConfig"], _testConfigDictionary["StringLastNameConfig"] });
            
            Assert.Equal("Foo", object2.FName);
            Assert.Equal("Bar", object2.LName);
        }
    }
}
