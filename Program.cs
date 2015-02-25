using System;

namespace RoboCleaner
{
	class MainClass
	{
		public static void Main(string[] args)
		{
            var cleaner = new Cleaner();
            var navigator = new Navigator(cleaner);
            var robot = new Robot(cleaner, navigator);

            robot.Run(Console.In, Console.Out);
		}
	}
}
