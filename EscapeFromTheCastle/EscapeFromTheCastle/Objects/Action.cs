using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    abstract class Action
    {
        protected string Name;

        // I might do a file with the actions

        public abstract void ActionOption();
    }

    class Attack : Action
    {
        protected int Health;
        protected int Range;

        public Attack(string name)
        {
            switch (name)
            {
                case "firebolt":                    
                    Name = "firebolt";
                    Health = -20;
                    Range = 10;
                    break;
                default:
                    throw new TypeNotFoundException();
            }
        }

        public override void ActionOption()
        {
            Console.WriteLine($"{Name} - Range : {Range} Damage : {Health * -1}");
        }
    }
}