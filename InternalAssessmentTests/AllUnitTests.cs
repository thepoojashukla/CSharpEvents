using InternalAssessment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InternalAssessmentTests
{
    [TestClass]
    public class AllUnitTests
    {
        [TestMethod]
        public void TestSerialization()
        {
            LearnSerialization ls = new LearnSerialization();
            ls.TestSerialize();
        }

        [TestMethod]
        public void TestDeserialization()
        {
            LearnSerialization ls = new LearnSerialization();
            var sample = ls.TestDeserialize();
            Assert.AreEqual(5, sample.id);
            Assert.AreEqual("Pooja", sample.name);
            Console.WriteLine($"id:{sample.id}, name : {sample.name}");
        }
    }
}
