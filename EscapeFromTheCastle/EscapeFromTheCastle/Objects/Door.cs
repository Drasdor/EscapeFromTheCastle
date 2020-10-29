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

        private void UseKey(Key k)
        {
            if (Code != k.Use())
            {
                throw new ArgumentException("Incorrect Key");
            }
        }

        public void Unlock(Key k)
        {
            try
            {
                UseKey(k);
                Locked = false;
                Console.WriteLine("Unlocked");
            }
            catch
            {
                Console.WriteLine("Incorrect Key");
            }
        }

        public void Lock(Key k)
        {
            try
            {
                UseKey(k);
                Locked = true;
                Console.WriteLine("Locked");
            }
            catch
            {
                Console.WriteLine("Incorrect Key");
            }

        }

        public bool CheckLock()
        {
            return Locked;
        }
    }
}
