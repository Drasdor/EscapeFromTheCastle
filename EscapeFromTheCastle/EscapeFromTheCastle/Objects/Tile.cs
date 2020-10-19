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

        public char GetChar()
        {
            if (Base == '|')
            {
                return '|';
            }

            return Base;
        }

        public ConsoleColor GetColour()
        {
            char c = GetChar();
            return c switch
            {
                '|' => ConsoleColor.White,
                'X' => ConsoleColor.DarkGray,
                'C' => ConsoleColor.DarkYellow,
                'D' => ConsoleColor.Cyan,
                _ => throw new ArgumentException("Type does not exist"),
            };
        }
    }
}