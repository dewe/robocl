using System;

namespace RoboCleaner
{
	class MainClass
	{
		public static void Main(string[] args)
		{

            var cleaner = new Cleaner();
            var navigator = new Navigator(cleaner);

            // init sequence
            var commands = int.Parse(Console.ReadLine());
            var coords = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), int.Parse);
            navigator.StartAt(new Position(coords[0], coords[1]));

            // run robot
            for (int i = 0; i < commands; i++)
            {
                navigator.Move(Console.ReadLine());
            }

            Console.Write("=> Cleaned: {0}", cleaner.UniqueSpots());
		}
	}
}
