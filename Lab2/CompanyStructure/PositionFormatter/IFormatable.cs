using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public interface IFormatable
    {
        public abstract void AcceptFormatter(PositionFormatter formatter);
    }
}
