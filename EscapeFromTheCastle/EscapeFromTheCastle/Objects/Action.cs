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

        public static void ActionOption(Action sender)
        {
            switch (sender.Type)
            {
                case "Attack":
                    Console.WriteLine($"{sender.Name} - R:{sender.Range} D:{(sender.Health * -1)}");
                    break;
                default:
                    throw new ArgumentException("Type does not exist");
            }

        }
    }
}