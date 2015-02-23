using System;

namespace RoboCleaner
{
	public class Navigator
	{
		readonly Cleaner cleaner;

		public Navigator (Cleaner cleaner)
		{
			this.cleaner = cleaner;
		}

		public void SetPosition(Position position)
		{
			cleaner.Clean(position);
		}
	}
}

