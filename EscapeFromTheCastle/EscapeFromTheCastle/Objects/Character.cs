using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    public class Character
    {
        private readonly int MaxBagSize;
        private readonly string Name;
        private int Health;
        private readonly int MaxHealth;
        private readonly int[] Location = { 0, 0 };
        private readonly Bag Backpack = new Bag(1);
        private Boolean Door = false;
        private readonly List<Action> Actions = new List<Action>();

        public Character(string name, int health, int size)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            MaxBagSize = size;
            Bag.SetSize(Backpack, size);
        }

        public Character(string type, string name)
        {
            switch (type)
            {
                case "human":
                    Name = name;
                    Health = 100;
                    MaxHealth = 100;
                    MaxBagSize = 5;
                    Bag.SetSize(Backpack, 5);
                    Actions.Add(new Action("firebolt"));
                    break;
                default:
                    throw new ArgumentException("Type does not exist");
            }
        }

        public static void ModifyHealth(Character sender, int modifier)
        {
            sender.Health += modifier;

            if (sender.Health < 1)
            {
                sender.Health = 0;
                throw new ArgumentException("Character has died");
            }
            if (sender.Health > sender.MaxHealth)
            {
                sender.Health = sender.MaxHealth;
            }
        }

        public static int GetHealth(Character sender)
        {
            return sender.Health;
        }

        public static int GetMaxHealth(Character sender)
        {
            return sender.MaxHealth;
        }

        public static int GetCol(Character sender)
        {
            return sender.Location[0];
        }

        public static int GetRow(Character sender)
        {
            return sender.Location[1];
        }

        public static void Speak(Character sender)
        {
            Console.WriteLine("My name is " + sender.Name);
        }

        public static void Move(Character sender, int col, int row)
        {
            if (sender.Location[0] + col < 0 || sender.Location[0] + row < 0)
            {
                throw new ArgumentException($"Move ({col}, {row}) takes player outside of room!", "original");
            }

            sender.Location[0] = sender.Location[0] + col;
            sender.Location[1] = sender.Location[1] + row;
        }

        public static void AddToBag(Character sender, Item i)
        {
            Bag.Add(sender.Backpack, i);
        }

        public static void DescribeBackpack(Character sender)
        {
            Bag.Describe(sender.Backpack);
        }

        public static void UseIndex(Character sender, int index)
        {
            // I will try to do a switch using the get type function at some point
            Bag.Use(sender.Backpack, index);
        }
        public static void EatIndex(Character sender, int index)
        {
            Bag.Eat(sender.Backpack, index, sender);
        }

        public static void ReadIndex(Character sender, int index)
        {
            Bag.Use(sender.Backpack, index);
        }

        public static void DropIndex(Character sender, int index)
        {
            Bag.DropIndex(sender.Backpack, index);
        }

        public static Item GetItem(Character sender, int index)
        {
            return Bag.GetItem(sender.Backpack, index);
        }

        public static Boolean OnDoor(Character sender)
        {
            return sender.Door;
        }

        public static void ActionMenu(Character sender)
        {
            do
            {
                try
                {
                    Console.WriteLine("1 - Attack   2 - Use Item");
                    Console.WriteLine("3 - Move     4 - End Turn");
                    string input = Console.ReadLine();
                    foreach (Action a in sender.Actions)
                    {
                        Action.ActionOption(a);
                    }
                }
                catch
                {

                }
            } while (true);
        }
    }
}