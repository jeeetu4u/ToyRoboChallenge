using NUnit.Framework;
using ToyRoboChallenge;

namespace ToyRoboChallenge.Tests
{
    [TestFixture]
    public class RoboTests
    {
        private Robo _robo;

        [SetUp]
        public void Setup()
        {
            _robo = new Robo();
        }

        [Test]
        public void PlaceCommandSetsRoboPositionAndFacing()
        {
            _robo.Place(1, 2, Facing.NORTH);

            Assert.That(_robo.X, Is.EqualTo(1));
            Assert.That(_robo.Y, Is.EqualTo(2));
            Assert.That(_robo.F, Is.EqualTo(Facing.NORTH));
            Assert.IsTrue(_robo.IsPlaced);
        }

        [Test]
        public void MoveCommandUpdatesPositionBasedOnFacing()
        {
            _robo.Place(0, 0, Facing.NORTH);
            _robo.Move();

            Assert.That(_robo.X, Is.EqualTo(0));
            Assert.That(_robo.Y, Is.EqualTo(1));
        }

        [Test]
        public void LeftCommandUpdatesFacingDirection()
        {
            _robo.Place(0, 0, Facing.NORTH);
            _robo.Left();

            Assert.That(_robo.F, Is.EqualTo(Facing.WEST));
        }

        [Test]
        public void RightCommandUpdatesFacingDirection()
        {
            _robo.Place(0, 0, Facing.NORTH);
            _robo.Right();

            Assert.That(_robo.F, Is.EqualTo(Facing.EAST));
        }

        [Test]
        public void ReportReturnsCurrentPositionAndFacing()
        {
            _robo.Place(1, 2, Facing.EAST);
            string report = _robo.Report();

            Assert.That(report, Is.EqualTo("1,2,EAST"));
        }
    }
}