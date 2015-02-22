using NUnit.Framework;
using System;
using RoboCleaner;

namespace Tests
{
	[TestFixture]
	public class CleanerTests
	{
		Cleaner cleaner;

		[SetUp]
		public void Before_each ()
		{
			cleaner = new Cleaner ();
		}

		[Test]
		public void Clean_single_spot_returns_1 ()
		{
			var position = new Position (100, 100);
			Assert.That (1 == cleaner.CleanAt (position));
		}

		[Test]
		public void Clean_same_spot_twice_reports_1_unique ()
		{
			cleaner.CleanAt (new Position (1, 1));
			cleaner.CleanAt (new Position (1, 1));

			Assert.That (1 == cleaner.UniqueSpots ());
		}

		[Test]
		public void Clean_two_different_spots_returns_2_unique ()
		{
			cleaner.CleanAt (new Position (1000, 1000));
			cleaner.CleanAt (new Position (20000, 20000));

			Assert.That (2 == cleaner.UniqueSpots ());
		}

		[Test]
		public void Should_handle_max_position_values ()
		{
			var position = new Position (100000, 100000);
			Assert.That (1 == cleaner.CleanAt (position));
		}

		[Test]
		public void Should_handle_min_position_values ()
		{
			var position = new Position (-100000, -100000);
			Assert.That (1 == cleaner.CleanAt (position));
		}

	}
}

