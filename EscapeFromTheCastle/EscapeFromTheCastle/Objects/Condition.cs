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
                    throw new TypeNotFoundException("Type does not exist");
            }
        }
    }
}
