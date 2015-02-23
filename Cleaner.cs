using System.Collections.Generic;

namespace RoboCleaner
{
	public class Cleaner
	{
		// Int32 will handle max number of spots reached during lifetime (i.e. max 10k * 100k).
		private readonly Dictionary<Position, bool> spots = new Dictionary<Position, bool>();

		public virtual void Clean(Position position)
		{
			spots[position] = true;
		}

		public int UniqueSpots()
		{
			return spots.Count;
		}
	}
}

