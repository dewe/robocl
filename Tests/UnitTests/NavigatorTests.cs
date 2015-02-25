using FakeItEasy;
using NUnit.Framework;
using RoboCleaner;

namespace Tests
{
    [TestFixture]
    public class NavigatorTests
    {
        Cleaner cleaner;
        Navigator navigator;

        [SetUp]
        public void Before_each()
        {
            cleaner = A.Fake<Cleaner>();
            navigator = new Navigator(cleaner);
        }

        [Test]
        public void Move_N_should_increase_Y()
        {
            navigator.StartAt(new Position(100, 100));
            var pos = navigator.Move("N 1");
            Assert.AreEqual(new Position(100, 101), pos);
        }

        [Test]
        public void Move_S_should_decrease_Y()
        {
            navigator.StartAt(new Position(100, 100));
            var pos = navigator.Move("S 1");
            Assert.AreEqual(new Position(100, 99), pos);
        }

        [Test]
        public void Move_E_should_increase_X()
        {
            navigator.StartAt(new Position(100, 100));
            var pos = navigator.Move("E 1");
            Assert.AreEqual(new Position(101, 100), pos);
        }

        [Test]
        public void Move_W_should_decrease_X()
        {
            navigator.StartAt(new Position(100, 100));
            var pos = navigator.Move("W 1");
            Assert.AreEqual(new Position(99, 100), pos);
        }

        [Test]
        public void Move_multiple_steps()
        {
            navigator.StartAt(new Position(0, 0));
            var pos = navigator.Move("N 4711");
            Assert.AreEqual(new Position(0, 4711), pos);
        }

        [Test]
        public void Sequential_moves_should_add_up()
        {
            navigator.StartAt(new Position(0, 0));

            navigator.Move("N 1");
            navigator.Move("N 1");
            navigator.Move("E 1");
            navigator.Move("S 1");
            navigator.Move("W 1");

            var pos = navigator.Move("W 1");
            Assert.AreEqual(new Position(-1, 1), pos);
        }

        [Test]
        public void Zero_step_should_not_move()
        {
            navigator.StartAt(new Position(0, 0));
            var pos = navigator.Move("N 0");
            Assert.AreEqual(new Position(0, 0), pos);
        }

        [Test]
        public void Starting_position_should_be_cleaned()
        {
            var position = new Position(123, 456);
            navigator.StartAt(position);
            A.CallTo(() => cleaner.Clean(position)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Zero_step_should_not_clean()
        {
            navigator.StartAt(new Position(10, 10));
            A.CallTo(() => cleaner.Clean(new Position(10, 10))).MustHaveHappened(Repeated.Exactly.Once);

            navigator.Move("N 0");
            A.CallTo(() => cleaner.Clean(new Position(10, 10))).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Move_to_new_postion_should_clean_all_positions_on_the_way()
        {
            navigator.StartAt(new Position(10, 10));
            navigator.Move("W 10000");
            A.CallTo(() => cleaner.Clean(A<Position>._)).MustHaveHappened(Repeated.Exactly.Times(10001));
        }
    }
}

