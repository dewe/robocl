using System.Collections.Generic;

namespace RoboCleaner
{
	public class Cleaner
	{
		// Int32 will handle max number of spots reached during lifetime (i.e. max 10k * 100k).
		private readonly HashSet<Position> cleanSpots = new HashSet<Position>();

		public virtual void Clean(Position position)
		{
			cleanSpots.Add(position);
		}

		public int UniqueSpots()
		{
			return cleanSpots.Count;
		}
	}
}

