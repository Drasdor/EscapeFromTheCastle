﻿using System;
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
            Backpack.SetSize(size);
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
                    Backpack.SetSize(5);
                    Actions.Add(new Action("firebolt"));
                    break;
                default:
                    throw new ArgumentException("Type does not exist");
            }
        }

        public void ModifyHealth(int modifier)
        {
            Health += modifier;

            if (Health < 1)
            {
                Health = 0;
                throw new ArgumentException("Character has died");
            }
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public int GetHealth()
        {
            return Health;
        }

        public int GetMaxHealth()
        {
            return MaxHealth;
        }

        public int GetCol()
        {
            return Location[0];
        }

        public int GetRow()
        {
            return Location[1];
        }

        public void Speak()
        {
            Console.WriteLine("My name is " + Name);
        }

        public void Move(int col, int row)
        {
            if (Location[0] + col < 0 || Location[0] + row < 0)
            {
                throw new ArgumentException($"Move ({col}, {row}) takes player outside of room!", "original");
            }

            Location[0] = Location[0] + col;
            Location[1] = Location[1] + row;
        }

        public void AddToBag(Item i)
        {
            Backpack.Add(i);
        }

        public void DescribeBackpack()
        {
            Backpack.Describe();
        }

        public void UseIndex(int index)
        {
            Backpack.Use(index);
        }
        public void EatIndex(int index)
        {
            Backpack.Eat(index, this);
        }

        public void ReadIndex(int index)
        {
            Backpack.Use(index);
        }

        public void DropIndex(int index)
        {
            Backpack.DropIndex(index);
        }

        public Item GetItem(int index)
        {
            return Backpack.GetItem(index);
        }

        public Boolean OnDoor()
        {
            return Door;
        }

        public void ActionMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("1 - Attack   2 - Use Item");
                    Console.WriteLine("3 - Move     4 - End Turn");
                    string input = Console.ReadLine();
                    foreach (Action a in Actions)
                    {
                        a.ActionOption();
                    }
                }
                catch
                {

                }
            } while (true);
        }
    }
}