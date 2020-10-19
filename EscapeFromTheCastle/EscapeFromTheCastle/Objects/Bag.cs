using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    public class Bag
    {
        private int MaxBagSize;
        private readonly List<Item> Contents = new List<Item>();

        public Bag(int size)
        {
            MaxBagSize = size;
        }

        public static void Describe(Bag sender)
        {
            Console.Write("I have the following items in my bag: ");
            foreach (Item i in sender.Contents)
            {
                Console.Write(Item.GetName(i) + " ");
            }
            Console.WriteLine();
        }

        public static void Add(Bag sender, Item i)
        {
            if (sender.Contents.Count < sender.MaxBagSize)
            {
                sender.Contents.Add(i);
            }
            else
            {
                throw new ArgumentException("The bag is already full", "original");
            }
        }

        public static void Use(Bag sender, int index)
        {
            Item.Use(sender.Contents[index]);
            if (Item.IsUsed(sender.Contents[index]) == true)
            {
                sender.Contents.RemoveAt(index);
            }
        }

        public static void Eat(Bag sender, int index, Character target)
        {
            Food.Use((Food)sender.Contents[index], target);
            if (Item.IsUsed(sender.Contents[index]) == true)
            {
                sender.Contents.RemoveAt(index);
            }
        }

        public static void Read(Bag sender, int index)
        {
            Note.Use(sender.Contents[index]);
        }

        public static void DropIndex(Bag sender, int index)
        {
            sender.Contents.RemoveAt(index);
        }

        public static void SetSize(Bag sender, int new_size)
        {
            sender.MaxBagSize = new_size;
        }

        public static int GetLength(Bag sender)
        {
            return sender.Contents.Count;
        }

        public static Item GetItem(Bag sender, int index)
        {
            return sender.Contents[index];
        }
    }
}