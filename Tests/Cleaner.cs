using NUnit.Framework;
using System;
using RoboCleaner;

namespace Tests
{
	public class Cleaner
	{
		private ulong unique;
		private bool[,] spots = new bool[200001,200001]; // todo: BitArray

		public ulong CleanAt (Position position)
		{
			var xprim = position.x + 100000;
			var yprim = position.y + 100000;

			if (!spots[xprim, yprim]) {
				spots [xprim, yprim] = true;
				unique = unique + 1;
			}

			return UniqueSpots();
		}

		public ulong UniqueSpots ()
		{
			return unique;
		}
	}

}

