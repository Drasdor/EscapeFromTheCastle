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

        public void Describe()
        {
            Console.Write("I have the following items in my bag: ");
            foreach (Item i in Contents)
            {
                Console.Write(i.GetName() + " ");
            }
            Console.WriteLine();
        }

        public void Add(Item i)
        {
            if (Contents.Count < MaxBagSize)
            {
                Contents.Add(i);
            }
            else
            {
                throw new ArgumentException("The bag is already full", "original");
            }
        }

        public void Use(int index)
        {
            Contents[index].Use();
            if (Contents[index].IsUsed() == true)
            {
                Contents.RemoveAt(index);
            }
        }

        public void Eat(int index, Character target)
        {
            Contents[index].Use(target);
            if (Contents[index].IsUsed() == true)
            {
                Contents.RemoveAt(index);
            }
        }

        public void Read(int index)
        {
            Contents[index].Use();
        }

        public void DropIndex(int index)
        {
            Contents.RemoveAt(index);
        }

        public void SetSize( int new_size)
        {
            MaxBagSize = new_size;
        }

        public int GetLength()
        {
            return Contents.Count;
        }

        public Item GetItem(int index)
        {
            return Contents[index];
        }
    }
}