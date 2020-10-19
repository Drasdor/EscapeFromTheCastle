using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    class Condition
    {
        public Condition(string name)
        {
            switch (name)
            {
                case "bleed":
                    break;
                default:
                    throw new ArgumentException("Type does not exist");
            }
        }
    }
}
