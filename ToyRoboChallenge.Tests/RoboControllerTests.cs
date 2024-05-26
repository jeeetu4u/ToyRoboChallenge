using NUnit.Framework;
using ToyRoboChallenge;

namespace ToyRoboChallenge.Tests
{
    [TestFixture]
    public class RoboControllerTests
    {
        private Robo _robo;
        private RoboController _controller;

        [SetUp]
        public void Setup()
        {
            _robo = new Robo();
            _controller = new RoboController(_robo);
        }

        [Test]
        public void ParseAndExecuteCommandExecutesPlaceCommand()
        {
            string[] commands = { "PLACE 1,2,EAST" };
            _controller.ParseAndExecuteCommand(commands);

            Assert.That(_robo.X, Is.EqualTo(1));
            Assert.That(_robo.Y, Is.EqualTo(2));
            Assert.That(_robo.F, Is.EqualTo(Facing.EAST));
        }

        [Test]
        public void ParseAndExecuteCommandExecutesMoveCommand()
        {
            string[] commands = { "PLACE 0,0,NORTH", "MOVE" };
            _controller.ParseAndExecuteCommand(commands);

            Assert.That(_robo.X, Is.EqualTo(0));
            Assert.That(_robo.Y, Is.EqualTo(1));
        }

        [Test]
        public void ParseAndExecuteCommandExecutesLeftCommand()
        {
            string[] commands = { "PLACE 0,0,NORTH", "LEFT" };
            _controller.ParseAndExecuteCommand(commands);

            Assert.That(_robo.F, Is.EqualTo(Facing.WEST));
        }

        [Test]
        public void ParseAndExecuteCommandExecutesRightCommand()
        {
            string[] commands = { "PLACE 0,0,NORTH", "RIGHT" };
            _controller.ParseAndExecuteCommand(commands);

            Assert.That(_robo.F, Is.EqualTo(Facing.EAST));
        }

        [Test]
        public void ParseAndExecuteCommandExecutesReportCommand()
        {
            string[] commands = { "PLACE 0,0,NORTH", "REPORT" };
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _controller.ParseAndExecuteCommand(commands);
                string expected = "0,0,NORTH\r\n";
                Assert.That(sw.ToString(), Is.EqualTo(expected));
            }
        }
    }
}
