using System;
using System.IO;

namespace RoboCleaner
{
    public class Robot
    {
        readonly Cleaner cleaner;
        readonly Navigator navigator;

        public Robot(Cleaner cleaner, Navigator navigator)
        {
            this.navigator = navigator;
            this.cleaner = cleaner;
        }

        public void Run(TextReader stdin, TextWriter stdout)
        {
            // init sequence
            var commands = ReadNumberOfCommands(stdin);
            var position = ReadStartingPosition(stdin);

            navigator.StartAt(position);

            for (int i = 0; i < commands; i++)
            {
                navigator.Move(stdin.ReadLine());
            }

            stdout.Write("=> Cleaned: {0}", cleaner.UniqueSpots());
        }

        private int ReadNumberOfCommands(TextReader stdin)
        {
            var commands = int.Parse(stdin.ReadLine());
            return commands;
        }

        private Position ReadStartingPosition(TextReader stdin)
        {
            var coords = Array.ConvertAll<string, int>(stdin.ReadLine().Split(' '), int.Parse);
            var position = new Position(coords[0], coords[1]);
            return position;
        }
    }
}

