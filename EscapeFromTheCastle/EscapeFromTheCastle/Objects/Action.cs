using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    class Action
    {
        private readonly string Type;
        private readonly string Name;
        private readonly int Health;
        private readonly int Range;

        // I might do a file with the actions

        public Action(string name)
        {
            switch (name)
            {
                case "firebolt":
                    Type = "Attack";
                    Name = "firebolt";
                    Health = -20;
                    Range = 10;
                    break;
                default:
                    throw new ArgumentException("Type does not exist");
            }
        }

        public Action(string name, int damage)
        {

        }

        public void ActionOption()
        {
            switch (Type)
            {
                case "Attack":
                    Console.WriteLine($"{Name} - R:{Range} D:{Health * -1}");
                    break;
                default:
                    throw new ArgumentException("Type does not exist");
            }

        }
    }
}