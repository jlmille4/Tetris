using UnityEngine;
using System.Collections;
using NUnit.Framework;
using NSubstitute;


namespace gov.nasa.ksc.it.itacl.common.tests
{
    [TestFixture]
    [Category("GameTime Tests")]
    internal class GameTimeTest
    {
        private GameTime gameTime = null;

        [SetUp]
        public void SetUp()
        {
            GameObject go = new GameObject("GameTime Test");
            gameTime = go.AddComponent<GameTime>();
        }

        [TearDown]
        public void TearDown()
        {
            GameObject.DestroyImmediate(gameTime.gameObject);
        }

        [Test]
        public void DeltaTimeShouldUpdateCorrectly()
        {
            ITime time = Substitute.For<ITime>();
            time.DeltaTime.Returns(0.25f);
            gameTime.Time = time;

            gameTime.Update();

            Assert.AreEqual(0.25f, gameTime.DeltaTime, "GameTime could not update delta time correctly");
        }

        [Test]
        public void DeltaTimeShouldPauseCorrectly()
        {
            ITime time = Substitute.For<ITime>();
            time.DeltaTime.Returns(0.25f);
            gameTime.Time = time;

            gameTime.Update();
            gameTime.Pause();
            gameTime.Update();

            Assert.AreEqual(0, gameTime.DeltaTime, "GameTime could not update delta time correctly");
        }

        [Test]
        public void DeltaTimeShouldPauseThenPlayCorrectly()
        {
            ITime time = Substitute.For<ITime>();
            time.DeltaTime.Returns(0.25f);
            gameTime.Time = time;

            gameTime.Update();
            gameTime.Pause();
            gameTime.Update();
            gameTime.Play();
            gameTime.Update();

            Assert.AreEqual(0.25f, gameTime.DeltaTime, "GameTime could not update delta time correctly");
        }


        [Test]
        public void TimeSinceLevelLoadedShouldUpdateCorrectly()
        {
            ITime time = Substitute.For<ITime>();
            time.DeltaTime.Returns(0.25f);
            gameTime.Time = time;

            for (int i = 0; i < 10;++i )
            {
                gameTime.Update();
            }

            Assert.AreEqual(2.5f, gameTime.TimeSinceLevelLoaded, "GameTime could not update TimeSinceLevelLoaded correctly");
        }

        [Test]
        public void TimeSinceLevelLoadedShouldUpdatePauseCorrectly()
        {
            ITime time = Substitute.For<ITime>();
            time.DeltaTime.Returns(0.25f);
            gameTime.Time = time;

            for (int i = 0; i < 10; ++i)
            {
                gameTime.Update();
            }

            gameTime.Pause();

            for (int i = 0; i < 10; ++i)
            {
                gameTime.Update();
            }

            Assert.AreEqual(2.5f, gameTime.TimeSinceLevelLoaded, "GameTime could not update TimeSinceLevelLoaded correctly");
        }

        [Test]
        public void TimeSinceLevelLoadedShouldUpdatePausePlayCorrectly()
        {
            ITime time = Substitute.For<ITime>();
            time.DeltaTime.Returns(0.25f);
            gameTime.Time = time;

            for (int i = 0; i < 10; ++i)
            {
                gameTime.Update();
            }

            gameTime.Pause();

            for (int i = 0; i < 10; ++i)
            {
                gameTime.Update();
            }


            gameTime.Play();

            for (int i = 0; i < 10; ++i)
            {
                gameTime.Update();
            }

            Assert.AreEqual(5.0f, gameTime.TimeSinceLevelLoaded, "GameTime could not update TimeSinceLevelLoaded correctly");
        }

        [Test]
        public void IsPlayingReportsPlayCorrectly()
        {
            ITime time = Substitute.For<ITime>();
            time.DeltaTime.Returns(0.25f);
            gameTime.Time = time;
            
            Assert.IsTrue(gameTime.IsPlaying, "GameTime could not correctly set the Playing state");
        }

        [Test]
        public void IsPlayingReportsPauseCorrectly()
        {
            ITime time = Substitute.For<ITime>();
            time.DeltaTime.Returns(0.25f);
            gameTime.Time = time;

            gameTime.Pause();

            Assert.IsFalse(gameTime.IsPlaying, "GameTime could not correctly set the Playing state");
        }
    }
}
