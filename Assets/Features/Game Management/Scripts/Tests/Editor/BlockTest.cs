using UnityEngine;
using System;
using System.Collections;
using NUnit.Framework;
using NSubstitute;
using gov.nasa.ksc.it.itacl.common;

namespace Tetris.Tests
{
    [TestFixture]
    [Category("Block Test")]
    public class BlockTest
    {
        private Block block;

        [SetUp]
        protected void setUp()
        {
            block = CreateTestBlock();
        }

        [TearDown]
        protected void tearDown()
        {
            GameObject.DestroyImmediate(block.gameObject);
        }

        public Block CreateTestBlock()
        {
            GameObject gameObject = new GameObject("Test Block");
            return gameObject.AddComponent<Block>();
        }

        [Test]
        public void ShouldMoveOnTic()
        {
            //arrange
            ITime time = Substitute.For<ITime>();
            time.TimeSinceLevelLoaded.Returns(1.0f); //one second
            block.Time = time;
            
            //Act
            bool pass = block.CanMove();

            //Assert
            Assert.That(pass, "Block can not move when supposed to");
        }

        [Test]
        public void ShouldNotMoveWhenOffTic()
        {
            ITime time = Substitute.For<ITime>();
            time.TimeSinceLevelLoaded.Returns(0.0f);
            block.Time = time;

            bool pass = block.CanMove();

            Assert.That(!pass, "Block moves when it should not");
        }

        [Test]
        public void ShouldMoveRightHorizontallyFromUpdate()
        {
            //arrange
            ITime time = Substitute.For<ITime>();
            time.TimeSinceLevelLoaded.Returns(1.0f);
            block.Time = time;
            
            IInput input = Substitute.For<IInput>();
            input.GetAxis("Horizontal").Returns(1);
            block.Input = input;
            block.IsActive = true;
            
            //Act
            block.Update();

            //Assert
            Assert.AreEqual(block.transform.position.x, 1.0f, "Block did not move horizontally");
        }

        [Test]
        public void ShouldNotMoveRightFromUpdateWhenOffTick()
        {
            //arrange
            ITime time = Substitute.For<ITime>();
            time.TimeSinceLevelLoaded.Returns(0.0f);
            block.Time = time;

            IInput input = Substitute.For<IInput>();
            input.GetAxis("Horizontal").Returns(1);
            block.Input = input;
            block.IsActive = true;

            //Act
            block.Update();

            //Assert
            Assert.AreEqual(block.transform.position.x, 0.0f, "Block should not have move horizontally");
        }

        [Test]
        public void ShouldMoveLeftHorizontallyFromUpdate()
        {
            //arrange
            ITime time = Substitute.For<ITime>();
            time.TimeSinceLevelLoaded.Returns(1.0f);
            block.Time = time;

            IInput input = Substitute.For<IInput>();
            input.GetAxis("Horizontal").Returns(-1);
            block.Input = input;
            block.IsActive = true;

            //Act
            block.Update();

            //Assert
            Assert.AreEqual(block.transform.position.x, -1.0f, "Block did not move horizontally");
        }

        [Test]
        public void ShouldNotMoveLeftFromUpdateWhenOffTick()
        {
            //arrange
            ITime time = Substitute.For<ITime>();
            time.TimeSinceLevelLoaded.Returns(0.0f);
            block.Time = time;

            IInput input = Substitute.For<IInput>();
            input.GetAxis("Horizontal").Returns(-1);
            block.Input = input;
            block.IsActive = true;

            //Act
            block.Update();

            //Assert
            Assert.AreEqual(block.transform.position.x, 0.0f, "Block should not have move horizontally");
        }


        [Test]
        public void ShouldNotMoveHorzontallyWhenPaused()
        {
            ITime time = Substitute.For<ITime>();
            time.TimeSinceLevelLoaded.Returns(30f);
            time.Pause();
            block.Time = time;

            IInput input = Substitute.For<IInput>();
            input.GetAxis("Horizontal").Returns(1);
            block.Input = input;
            
            Assert.AreEqual(block.transform.localPosition.x, 0, "Block should not have moved while paused");
        }

    }
}
