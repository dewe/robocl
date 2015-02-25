using FakeItEasy;
using System.IO;
using NUnit.Framework;
using RoboCleaner;

namespace Tests
{
    [TestFixture]
    public class RobotTests
    {
        Robot robot;
        Cleaner cleaner;
        Navigator navigator;

        [SetUp]
        public void Before_each()
        {
            cleaner = A.Fake<Cleaner>();
            navigator = A.Fake<Navigator>();
            robot = new Robot(cleaner, navigator);
        }

        [Test]
        public void Commands_are_forwarded_to_navigator()
        {
            var input = new StringReader("1\n6 7\nS 42");
            var output = new StringWriter();

            robot.Run(input, output);

            A.CallTo(() => navigator.Move("S 42")).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Second_input_sets_starting_positon()
        {
            var input = new StringReader("0\n6 7\n");
            var output = new StringWriter();

            robot.Run(input, output);

            A.CallTo(() => navigator.StartAt(new Position(6, 7))).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}

