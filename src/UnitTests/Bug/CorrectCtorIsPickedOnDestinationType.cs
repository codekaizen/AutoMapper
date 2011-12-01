using NUnit.Framework;

namespace AutoMapper.UnitTests.Bug
{
    using System;

    [TestFixture]
    public class CorrectCtorIsPickedOnDestinationType : AutoMapperSpecBase
    {
        public class SourceClass { }

        public class DestinationClass
        {
            public DestinationClass() { }

            public DestinationClass(Int32 type)
            {
                TestType = type;
            }

            public Int32 TestType { get; private set; }
        }

        [Test]
        public void Should_pick_a_ctor_which_best_matches()
        {
            Mapper.CreateMap<SourceClass, DestinationClass>();

            var source = new SourceClass();

            object dest = Mapper.Map<DestinationClass>(source);
        }
    }
}
