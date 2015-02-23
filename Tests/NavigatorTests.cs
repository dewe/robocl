using NUnit.Framework;
using System;
using RoboCleaner;
using FakeItEasy;

namespace Tests
{
	[TestFixture]
	public class NavigatorTests
	{
		[SetUp]
		public void Before_each()
		{
		}

		[Test]
		public void Set_position_should_clean_pos()
		{
			var cleaner = A.Fake<Cleaner>();
			var navigator = new Navigator(cleaner);
			var position = new Position(123, 456);

			navigator.SetPosition(position);

			A.CallTo(() => cleaner.Clean(position)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}

