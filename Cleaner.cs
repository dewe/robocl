using System.Collections.Generic;

namespace RoboCleaner
{
	public class Cleaner
	{
		// Int32 will handle max number of spots reached (i.e. max 10k * 200k)
		private readonly Dictionary<Position, bool> spots = new Dictionary<Position, bool>();

		public int CleanAt(Position position)
		{
			spots[position] = true;
			return UniqueSpots();
		}

		public int UniqueSpots()
		{
			return spots.Count;
		}
	}
}

