using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;
using System.IO;

namespace ToyRoboChallenge.Tests
{
    [TestFixture]
    public class PlaceCommandTests
    {
        [Test]
        public void ExecutePlacesRobo()
        {
            var robo = new Robo();
            var command = new PlaceCommand(1, 2, Facing.NORTH);

            command.Execute(robo);

            Assert.That(robo.X, Is.EqualTo(1)); 
            Assert.That(robo.Y, Is.EqualTo(2));
            Assert.That(robo.F, Is.EqualTo(Facing.NORTH));
        }
    }

    [TestFixture]
    public class MoveCommandTests
    {
        [Test]
        public void ExecuteMovesRobo()
        {
            var robo = new Robo();
            robo.Place(0, 0, Facing.NORTH);
            var command = new MoveCommand();

            command.Execute(robo);

            Assert.That(robo.X, Is.EqualTo(0) );
            Assert.That(robo.Y, Is.EqualTo(1));
        }
    }

    [TestFixture]
    public class LeftCommandTests
    {
        [Test]
        public void ExecuteTurnsRoboLeft()
        {
            var robo = new Robo();
            robo.Place(0, 0, Facing.NORTH);
            var command = new LeftCommand();

            command.Execute(robo);

            Assert.That(robo.F, Is.EqualTo(Facing.WEST));
        }
    }

    [TestFixture]
    public class RightCommandTests
    {
        [Test]
        public void ExecuteTurnsRoboRight()
        {
            var robo = new Robo();
            robo.Place(0, 0, Facing.NORTH);
            var command = new RightCommand();

            command.Execute(robo);

            Assert.That(robo.F, Is.EqualTo(Facing.EAST));
        }
    }



    [TestFixture]
    public class ReportCommandTests
    {
        [Test]
        public void ExecuteReportsRoboPosition()
        {
            var robo = new Robo();
            robo.Place(0, 0, Facing.NORTH);
            var command = new ReportCommand();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                command.Execute(robo);
                string expected = "0,0,NORTH\r\n";
                Assert.That(sw.ToString(), Is.EqualTo(expected));
            }
        }
    }

}
