using System;

namespace RoboCleaner
{
	public class Navigator
	{
		private Cleaner cleaner;
		private Position current;

		public Navigator(Cleaner cleaner)
		{
			this.cleaner = cleaner;
		}

		public virtual void StartAt(Position position)
		{
			current = position;
			cleaner.Clean(position);
		}

		public virtual Position Move(string command)
		{
			var nav = command.Split(' ');
			var direction = nav[0];
			var steps = int.Parse(nav[1]);

			for (int i = 0; i < steps; i++)
			{
				current = Step(current, direction);
				cleaner.Clean(current);
			}

			return current;
		}

		private Position Step(Position pos, string direction)
		{
			var x = pos.x;
			var y = pos.y;

			switch (direction)
			{
				case "E":
					x = x + 1;
					break;
				case "N":
					y = y + 1;
					break;
				case "S":
					y = y - 1;
					break;
				case "W":
					x = x - 1;
					break;
				default:
					break;
			}

			return new Position(x, y);
		}
	}
}

