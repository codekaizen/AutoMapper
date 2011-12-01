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
                Type = type;
            }

            public Int32 Type { get; private set; }
        }

        [Test]
        public void Should_pick_a_ctor_which_best_matches()
        {
            Mapper.CreateMap<SourceClass, DestinationClass>();

            var source = new SourceClass();

            Mapper.Map<DestinationClass>(source);
        }
    }
}
