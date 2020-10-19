using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EscapeFromTheCastle
{
    class Door
    {
        private bool Locked;
        private readonly string Code;

        public Door(bool locked, string code)
        {
            Locked = locked;
            Code = code;
        }

        private static void UseKey(Door sender, Key k)
        {
            if (sender.Code != Key.Use(k))
            {
                throw new Exception("Incorrect Key");
            }
        }

        public static void Unlock(Door sender, Key k)
        {
            try
            {
                UseKey(sender, k);
                sender.Locked = false;
                Console.WriteLine("Unlocked");
            }
            catch
            {
                Console.WriteLine("Incorrect Key");
            }
        }

        public static void Lock(Door sender, Key k)
        {
            try
            {
                UseKey(sender, k);
                sender.Locked = true;
                Console.WriteLine("Locked");
            }
            catch
            {
                Console.WriteLine("Incorrect Key");
            }

        }

        public static bool CheckLock(Door sender)
        {
            return sender.Locked;
        }
    }
}
