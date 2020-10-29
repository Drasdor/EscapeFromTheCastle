using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    class InvalidUserInputException : Exception
    {
        public InvalidUserInputException()
        {
        }

        public InvalidUserInputException(string message)
            : base(message)
        {
        }

        public InvalidUserInputException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    class TypeNotFoundException : Exception
    {
        public TypeNotFoundException()
        {
        }

        public TypeNotFoundException(string message)
            : base(message)
        {
        }

        public TypeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    class DeathException : Exception
    {
        public DeathException()
        {
        }

        public DeathException(string message)
            : base(message)
        {
        }

        public DeathException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
