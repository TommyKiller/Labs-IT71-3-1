using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class IncorrectInputFormatException : Exception
    {
        public IncorrectInputFormatException()
        { }

        public IncorrectInputFormatException(string message) : base(message)
        { }
    }

    public class PositionAlreadyExistsException : Exception
    {
        public PositionAlreadyExistsException()
        { }

        public PositionAlreadyExistsException(string message) : base(message)
        { }
    }

    public class PositionDoesNotExistException : Exception
    {
        public PositionDoesNotExistException()
        { }

        public PositionDoesNotExistException(string message) : base(message)
        { }
    }

    public class PositionCanNotHaveSubordinatesException : Exception
    {
        public PositionCanNotHaveSubordinatesException()
        { }

        public PositionCanNotHaveSubordinatesException(string message) : base(message)
        { }
    }

    public class PositionHasNoSubordinatesException : Exception
    {
        public PositionHasNoSubordinatesException()
        { }

        public PositionHasNoSubordinatesException(string message) : base(message)
        { }
    }

    public class CompanyHasNoEmployeesException : Exception
    {
        public CompanyHasNoEmployeesException()
        { }

        public CompanyHasNoEmployeesException(string message) : base(message)
        { }
    }

    public class CompanyHeadException : Exception
    {
        public CompanyHeadException()
        { }

        public CompanyHeadException(string message) : base(message)
        { }
    }

    public class NoMatchesFoundException : Exception
    {
        public NoMatchesFoundException()
        { }

        public NoMatchesFoundException(string message) : base(message)
        { }
    }

    public class UnknownTypeException : Exception
    {
        public UnknownTypeException()
        { }

        public UnknownTypeException(string message) : base(message)
        { }
    }
}
