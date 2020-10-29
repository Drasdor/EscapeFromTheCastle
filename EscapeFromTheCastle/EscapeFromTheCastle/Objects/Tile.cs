using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    public class Tile
    {
        private readonly char Base;
        private readonly Bag Chest;
        private Character CharOnTile;
        private char IndexOnTile = '9';

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

        public void AddCharacter(Character c, char index)
        {
            CharOnTile = c;
            IndexOnTile = index;
        }

        public char GetChar()
        {
            if (Base == '|')
            {
                return '|';
            }
            else if (CharOnTile != null)
            {
                return IndexOnTile;
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
                '0' => ConsoleColor.DarkGreen,
                '1' => ConsoleColor.DarkGreen,
                '2' => ConsoleColor.DarkGreen,
                '3' => ConsoleColor.DarkGreen,
                _ => throw new TypeNotFoundException("Type does not exist"),
            };
        }
    }
}