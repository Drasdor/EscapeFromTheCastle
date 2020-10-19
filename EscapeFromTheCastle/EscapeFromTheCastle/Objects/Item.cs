using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace EscapeFromTheCastle
{
    public class Item
    {
        protected string Name;
        protected string Description;
        protected bool Used;

        public Item(string name)
        {
            switch (name)
            {
                case "torch":
                    Name = "torch";
                    Description = "An item used to light up dark places";
                    Used = false;
                    break;
                case "knife":
                    Name = "knife";
                    Description = "A basic weapon that can also be used to eat food";
                    Used = false;
                    break;
                case "chicken":
                    Name = "chicken";
                    Description = "Some tasty chicken to eat and boost your health";
                    Used = false;
                    break;
                case "water":
                    Name = "water";
                    Description = "Just some plain old water";
                    break;
                case "message":
                    Name = "message";
                    Description = "A note left by someone else... Who could it be?";
                    break;
                case "key":
                    Name = "key";
                    Description = "An old key used to open a door, it'll work on one of these doors";
                    break;
                default:
                    throw new ArgumentException("Type does not exist");
            }
        }

        public string GetName()
        {
            return Name;
        }

        public void Describe()
        {
            Console.WriteLine(Description);
        }

        public void Use()
        {
            if (Used == true)
            {
                throw new ArgumentException("Item already used");
            }
            Used = true;
        }

        public virtual void Use(Character target)
        {
        }

        public bool IsUsed()
        {
            return Used;
        }
    }

    public class Food : Item
    {
        private readonly int Health;

        public Food(string name) : base(name)
        {
            switch (name)
            {
                case "chicken":
                    Health = 20;
                    break;
                case "water":
                    Health = 10;
                    break;
                default:
                    throw new ArgumentException("Type does not exist");
            }
        }

        public override void Use(Character eater)
        {
            eater.ModifyHealth(Health);
            Used = true;
        }
    }

    public class Weapon : Item
    {
        private readonly int Damage;
        private readonly int Range;

        public Weapon(string name) : base(name)
        {
            switch (name)
            {
                case "knife":
                    Damage = 5;
                    Range = 1;
                    break;
                default:
                    throw new ArgumentException("Type does not exist");
            }
        }
    }

    public class Note : Item
    {
        private readonly string Text;

        public Note(string name, string text) : base(name)
        {
            Text = text;
        }

        public void Use(Note sender)
        {
            Console.WriteLine(Text);
        }
    }

    public class Key : Item
    {
        private readonly string Code;

        public Key(string code) : base("key")
        {
            Code = code;
        }

        public new string Use()
        {
            return Code;
        }
    }
}

/*Console.WriteLine(Item.get_name(torch));
            Item.describe(torch);
            Item.use(torch);
            Item.use(torch);
*/

/*Character c = Team.GetCharacter(players, 0);
            Character.ModifyHealth(c, -50);
            Character.AddToBag(c, chicken);
            Character.EatIndex(c, 2);
            Console.WriteLine(Character.GetHealth(c));
            Team.UpdateHealth(players);*/

/*Note message = new Note("message", "Shut up back there");
            Note.Describe(message);
            Note.Use(message);*/