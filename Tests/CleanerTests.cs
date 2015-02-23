﻿using NUnit.Framework;
using System;
using RoboCleaner;

namespace Tests
{
	[TestFixture]
	public class CleanerTests
	{
		Cleaner cleaner;

		[SetUp]
		public void Before_each()
		{
			cleaner = new Cleaner();
		}

		[Test]
		public void Clean_single_spot_returns_1()
		{
			cleaner.Clean(new Position(100, 100));
			Assert.That(cleaner.UniqueSpots() == 1);
		}

		[Test]
		public void Clean_same_spot_twice_reports_1_unique()
		{
			cleaner.Clean(new Position(1, 1));
			cleaner.Clean(new Position(1, 1));
			Assert.That(cleaner.UniqueSpots() == 1);
		}

		[Test]
		public void Clean_two_different_spots_returns_2_unique()
		{
			cleaner.Clean(new Position(1000, 1000));
			cleaner.Clean(new Position(20000, 20000));
			Assert.That(cleaner.UniqueSpots() == 2);
		}

		[Test]
		public void Should_handle_edge_case_positions()
		{
			cleaner.Clean(new Position(0, 0));
			cleaner.Clean(new Position(100000, 100000));
			cleaner.Clean(new Position(-100000, -100000));
			Assert.That(cleaner.UniqueSpots() == 3);
		}
	}
}

