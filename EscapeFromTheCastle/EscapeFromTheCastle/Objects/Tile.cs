using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    public class Tile
    {
        private readonly char Base;
        private readonly Bag Chest;

        public Tile(char bottom)
        {
            Base = bottom;
            if (bottom == 'C')
            {
                Chest = new Bag(3);
            }
            else
            {
                Chest = new Bag(1);
            }
        }

        public static char GetChar(Tile sender)
        {
            if (sender.Base == '|')
            {
                return '|';
            }

            return sender.Base;
        }

        public static ConsoleColor GetColour(Tile sender)
        {
            char c = Tile.GetChar(sender);
            switch (c)
            {
                case '|':
                    return ConsoleColor.White;
                case 'X':
                    return ConsoleColor.DarkGray;
                case 'C':
                    return ConsoleColor.DarkYellow;
                case 'D':
                    return ConsoleColor.Cyan;
                default:
                    throw new ArgumentException("Type does not exist");
            }
        }
    }
}