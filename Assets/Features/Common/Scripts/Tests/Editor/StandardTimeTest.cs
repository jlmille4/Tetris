using UnityEngine;
using System.Collections;
using NUnit.Framework;
using NSubstitute;


namespace gov.nasa.ksc.it.itacl.common.tests
{

    [TestFixture]
    [Category("Standard Time Test")]
    public class StandardTimeTest 
    {

        private StandardTime standardTime = null;

        [SetUp]
        public void SetUp()
        {
            standardTime = new StandardTime();
        }

        [TearDown]
        public void TearDown()
        {
            standardTime = null;
        }


        [Test]
        public void ShouldHaveCorrectDeltaTime()
        {
            Assert.AreEqual(Time.deltaTime, standardTime.DeltaTime, "Standard Time could not calculate delta time correctly");
        }

        [Test]
        public void ShouldHaveCorrectTimeSinceLevelLoaded()]
        {
        }



        
    }
}