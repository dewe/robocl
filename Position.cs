namespace RoboCleaner
{
	public struct Position
	{
		public readonly int x;
		public readonly int y;

		public Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static bool operator ==(Position p1, Position p2)
		{
			return p1.x == p2.x & p1.y == p2.y;
		}

		public static bool operator !=(Position p1, Position p2)
		{
			return !(p1 == p2);
		}
	}
}

