using NUnit.Framework;
using System;
using RoboCleaner;

namespace Tests
{
	public struct Position
	{
		public readonly int x;
		public readonly int y;

		public Position (int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}

